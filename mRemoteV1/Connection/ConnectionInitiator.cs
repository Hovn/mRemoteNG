using mRemoteNG.App;
using mRemoteNG.Connection.Protocol;
using mRemoteNG.Connection.Protocol.RDP;
using mRemoteNG.Container;
using mRemoteNG.Messages;
using mRemoteNG.Tools;
using mRemoteNG.UI.Forms;
using mRemoteNG.UI.Panels;
using mRemoteNG.UI.Window;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabPage = Crownwood.Magic.Controls.TabPage;


namespace mRemoteNG.Connection
{
    public class ConnectionInitiator : IConnectionInitiator
    {
        private readonly PanelAdder _panelAdder = new PanelAdder();
        private readonly List<string> _activeConnections = new List<string>();

        /// <summary>
        /// List of unique IDs of the currently active connections
        /// </summary>
        public IEnumerable<string> ActiveConnections => _activeConnections;

        public void OpenConnection(ContainerInfo containerInfo, ConnectionInfo.Force force = ConnectionInfo.Force.None)
        {
            OpenConnection(containerInfo, force, null);

        }

        public void OpenConnection(ConnectionInfo connectionInfo)
        {
            try
            {
                OpenConnection(connectionInfo, ConnectionInfo.Force.None);
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace(Language.strConnectionOpenFailed, ex);
            }
        }

        public void OpenConnection(ConnectionInfo connectionInfo, ConnectionInfo.Force force)
        {
            try
            {
                OpenConnection(connectionInfo, force, null);
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace(Language.strConnectionOpenFailed, ex);
            }
        }

        public bool SwitchToOpenConnection(ConnectionInfo connectionInfo)
        {
            var interfaceControl = FindConnectionContainer(connectionInfo);
            if (interfaceControl == null) return false;
            var connectionWindow = (ConnectionWindow)interfaceControl.FindForm();
            connectionWindow?.Focus();
            var findForm = (ConnectionWindow)interfaceControl.FindForm();
            findForm?.Show(FrmMain.Default.pnlDock);
            var tabPage = (TabPage)interfaceControl.Parent;
            tabPage.Selected = true;
            return true;
        }

        #region Private
        //连接容器
        private void OpenConnection(ContainerInfo containerInfo, ConnectionInfo.Force force, Form conForm)
        {
            var children = containerInfo.Children;
            if (children.Count == 0) return;
            foreach (var child in children)
            {
                var childAsContainer = child as ContainerInfo;
                if (childAsContainer != null)
                {
                    OpenConnection(childAsContainer, force, conForm);
                }
                else
                {
                    OpenConnection(child, force, conForm);
                    //await Task.Delay(500);  //CBH 批量打开容器内连接，每次延时500ms
                }
            }
            //List<ConnectionInfo>.Enumerator enumerator = default(List<ConnectionInfo>.Enumerator);
        }

        //连接服务器 原有方法（去掉_ORI）
        private void OpenConnection(ConnectionInfo connectionInfo, ConnectionInfo.Force force, Form conForm)
        {
            try
            {
                if (connectionInfo == null || (connectionInfo.Hostname == "" && connectionInfo.Protocol != ProtocolType.IntApp))
                {
                    Runtime.MessageCollector.AddMessage(MessageClass.WarningMsg, Language.strConnectionOpenFailedNoHostname);
                    return;
                }

                StartPreConnectionExternalApp(connectionInfo);

                //CBH 优化
                //原版方法：如果是从连接树节点启动的话，如果是外部工具（即便尝试集成未打钩），还是会尝试在窗口中新建标签页打开（标签页创建后马上又销毁，屏幕会闪一下）
                //优化：判断连接项是外部工具，并且该外部工具未勾选‘尝试集成’，则直接启动外部工具，不再尝试在新标签页中打开
                if (connectionInfo.Protocol == ProtocolType.IntApp && connectionInfo.ExtApp != "")
                {
                    ExternalTool extAppByName = Runtime.ExternalToolsService.GetExtAppByName(connectionInfo.ExtApp);
                    if (extAppByName != null && !extAppByName.TryIntegrate)
                    {
                        //未勾选‘尝试集成’则直接启动外部工具
                        extAppByName.Start(connectionInfo);
                        return;
                    }
                }
                //优化结束

                //如果已打开，切换到打开的标签页
                if ((force & ConnectionInfo.Force.DoNotJump) != ConnectionInfo.Force.DoNotJump)
                {
                    if (SwitchToOpenConnection(connectionInfo))
                        return;
                }

                var protocolFactory = new ProtocolFactory();
                var newProtocol = protocolFactory.CreateProtocol(connectionInfo);

                var connectionPanel = SetConnectionPanel(connectionInfo, force);
                if (string.IsNullOrEmpty(connectionPanel)) return;
                var connectionForm = SetConnectionForm(conForm, connectionPanel);
                var connectionContainer = SetConnectionContainer(connectionInfo, connectionForm);
                SetConnectionFormEventHandlers(newProtocol, connectionForm);
                SetConnectionEventHandlers(newProtocol);
                BuildConnectionInterfaceController(connectionInfo, newProtocol, connectionContainer);

                newProtocol.Force = force;

                if (newProtocol.Initialize() == false)
                {
                    newProtocol.Close();
                    return;
                }

                if (newProtocol.Connect() == false)
                {
                    newProtocol.Close();
                    return;
                }

                connectionInfo.OpenConnections.Add(newProtocol);
                _activeConnections.Add(connectionInfo.ConstantID);
                FrmMain.Default.SelectedConnection = connectionInfo;
                //await Task.Delay(500);  //CBH 打开连接后，延时500ms  方法签名必须是 async Task 才有效
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace(Language.strConnectionOpenFailed, ex);
            }
        }

        //CBH 替换 OpenConnection 的方法 （去掉_CBH）。暂未使用
        private void OpenConnection_CBH(ConnectionInfo connectionInfo, ConnectionInfo.Force force, Form conForm)
        {
            this.OpenConnection_CBH(connectionInfo, force, conForm, false);
        }


        //CBH 修改，增加入参：是否来自容器。暂未使用
        private void OpenConnection_CBH(ConnectionInfo connectionInfo, ConnectionInfo.Force force, Form conForm, bool fromContainer)
        {
            try
            {
                if (connectionInfo.Hostname == "" && connectionInfo.Protocol != ProtocolType.IntApp)
                {
                    Runtime.MessageCollector.AddMessage(MessageClass.WarningMsg, Language.strConnectionOpenFailedNoHostname);
                    return;
                }

                StartPreConnectionExternalApp(connectionInfo);

                //start---------------------------  CBH 相比原版方法增加的特殊处理逻辑！！！--------------------
                //如果连接是使用外部工具的 ，并且配置的外部工具不为空
                if (connectionInfo.Protocol == ProtocolType.IntApp && connectionInfo.ExtApp != "")
                {
                    ExternalTool extAppByName = Runtime.ExternalToolsService.GetExtAppByName(connectionInfo.ExtApp);
                    if (extAppByName != null && !extAppByName.TryIntegrate)
                    {
                        //未勾选‘尝试集成’则直接启动外部工具，避免在新标签也中打开（屏幕会闪一下）
                        extAppByName.Start(connectionInfo);
                        return;
                    }

                    //不是来自容器的批量启动，并且使用的是 Radmin 外部工具，进行特殊优化
                    //CBH：后续应该还需要优化代码
                    if (extAppByName != null && !fromContainer && extAppByName.DisplayName.StartsWith("Radmin", StringComparison.OrdinalIgnoreCase))
                    {
                        //为 Radmin 特殊优化：尝试集成：强制关闭 TryIntegrate = false
                        new ExternalTool("", "", "", "", false)
                        {
                            DisplayName = extAppByName.DisplayName,
                            FileName = extAppByName.FileName,
                            Arguments = extAppByName.Arguments,
                            WorkingDir = extAppByName.WorkingDir,
                            RunElevated = extAppByName.RunElevated,
                            WaitForExit = extAppByName.WaitForExit,
                            WaitAfterStart = extAppByName.WaitAfterStart,
                            TryIntegrate = false,
                            ShowOnToolbar = false
                        }.Start(connectionInfo);
                        return;
                    }
                }
                //end---------------------------  CBH 增加的特殊处理逻辑！！！--------------------



                if ((force & ConnectionInfo.Force.DoNotJump) != ConnectionInfo.Force.DoNotJump)
                {
                    if (SwitchToOpenConnection(connectionInfo))
                        return;
                }

                var protocolFactory = new ProtocolFactory();
                var newProtocol = protocolFactory.CreateProtocol(connectionInfo);
                var connectionPanel = SetConnectionPanel(connectionInfo, force);
                if (string.IsNullOrEmpty(connectionPanel)) 
                    return;

                var connectionForm = SetConnectionForm(conForm, connectionPanel);
                var connectionContainer = SetConnectionContainer(connectionInfo, connectionForm);
                SetConnectionFormEventHandlers(newProtocol, connectionForm);
                SetConnectionEventHandlers(newProtocol);
                BuildConnectionInterfaceController(connectionInfo, newProtocol, connectionContainer);

                newProtocol.Force = force;

                if (newProtocol.Initialize() == false)
                {
                    newProtocol.Close();
                    return;
                }

                if (newProtocol.Connect() == false)
                {
                    newProtocol.Close();
                    return;
                }

                connectionInfo.OpenConnections.Add(newProtocol);
                _activeConnections.Add(connectionInfo.ConstantID);
                FrmMain.Default.SelectedConnection = connectionInfo;
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace(Language.strConnectionOpenFailed, ex);
            }
        }

        private static void StartPreConnectionExternalApp(ConnectionInfo connectionInfo)
        {
            if (connectionInfo.PreExtApp == "") return;
            var extA = Runtime.ExternalToolsService.GetExtAppByName(connectionInfo.PreExtApp);
            extA?.Start(connectionInfo);
        }

        private static InterfaceControl FindConnectionContainer(ConnectionInfo connectionInfo)
        {
            if (connectionInfo.OpenConnections.Count <= 0) return null;
            for (var i = 0; i <= Runtime.WindowList.Count - 1; i++)
            {
                var window = Runtime.WindowList[i] as ConnectionWindow;
                var connectionWindow = window;
                if (connectionWindow?.TabController == null) continue;
                foreach (TabPage t in connectionWindow.TabController.TabPages)
                {
                    var ic = t.Controls[0] as InterfaceControl;
                    if (ic == null) continue;
                    if (ic.Info == connectionInfo)
                    {
                        return ic;
                    }
                }
            }
            return null;
        }

        private static string SetConnectionPanel(ConnectionInfo connectionInfo, ConnectionInfo.Force force)
        {
            var connectionPanel = "";
            if (connectionInfo.Panel == "" || (force & ConnectionInfo.Force.OverridePanel) == ConnectionInfo.Force.OverridePanel | Settings.Default.AlwaysShowPanelSelectionDlg)
            {
                var frmPnl = new frmChoosePanel();
                if (frmPnl.ShowDialog() == DialogResult.OK)
                {
                    connectionPanel = frmPnl.Panel;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                connectionPanel = connectionInfo.Panel;
            }
            return connectionPanel;
        }

        private Form SetConnectionForm(Form conForm, string connectionPanel)
        {
            var connectionForm = conForm ?? Runtime.WindowList.FromString(connectionPanel);

            if (connectionForm == null)
                connectionForm = _panelAdder.AddPanel(connectionPanel);
            else
                ((ConnectionWindow)connectionForm).Show(FrmMain.Default.pnlDock);

            connectionForm.Focus();
            return connectionForm;
        }

        private static Control SetConnectionContainer(ConnectionInfo connectionInfo, Form connectionForm)
        {
            Control connectionContainer = ((ConnectionWindow)connectionForm).AddConnectionTab(connectionInfo);

            if (connectionInfo.Protocol != ProtocolType.IntApp) return connectionContainer;

            var extT = Runtime.ExternalToolsService.GetExtAppByName(connectionInfo.ExtApp);

            if(extT == null) return connectionContainer;

            if (extT.Icon != null)
                ((TabPage)connectionContainer).Icon = extT.Icon;

            return connectionContainer;
        }

        private static void SetConnectionFormEventHandlers(ProtocolBase newProtocol, Form connectionForm)
        {
            newProtocol.Closed += ((ConnectionWindow)connectionForm).Prot_Event_Closed;
        }

        private void SetConnectionEventHandlers(ProtocolBase newProtocol)
        {
            newProtocol.Disconnected += Prot_Event_Disconnected;
            newProtocol.Connected += Prot_Event_Connected;
            newProtocol.Closed += Prot_Event_Closed;
            newProtocol.ErrorOccured += Prot_Event_ErrorOccured;
        }

        private static void BuildConnectionInterfaceController(ConnectionInfo connectionInfo, ProtocolBase newProtocol, Control connectionContainer)
        {
            newProtocol.InterfaceControl = new InterfaceControl(connectionContainer, newProtocol, connectionInfo);
        }
        #endregion

        #region Event handlers
        private static void Prot_Event_Disconnected(object sender, string disconnectedMessage)
        {
            try
            {
                if (sender is VncSharp.RemoteDesktop)
                {
                    Runtime.MessageCollector.AddMessage(MessageClass.InformationMsg, string.Format(Language.strProtocolEventDisconnected, @"VncSharp Disconnected."), true);
                    return;
                }

                Runtime.MessageCollector.AddMessage(MessageClass.InformationMsg, string.Format(Language.strProtocolEventDisconnected, disconnectedMessage), true);

                var prot = (ProtocolBase)sender;
                if (prot.InterfaceControl.Info.Protocol != ProtocolType.RDP) return;
                var reasonCode = disconnectedMessage.Split("\r\n".ToCharArray())[0];
                var desc = disconnectedMessage.Replace("\r\n", " ");

                if (Convert.ToInt32(reasonCode) > 3)
                    Runtime.MessageCollector.AddMessage(MessageClass.WarningMsg, Language.strRdpDisconnected + Environment.NewLine + desc);
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace(Language.strProtocolEventDisconnectFailed, ex);
            }
        }

        private void Prot_Event_Closed(object sender)
        {
            try
            {
                var prot = (ProtocolBase)sender;
                Runtime.MessageCollector.AddMessage(MessageClass.InformationMsg, Language.strConnenctionCloseEvent, true);
                string connDetail;
                if (prot.InterfaceControl.Info.Hostname == "" && prot.InterfaceControl.Info.Protocol == ProtocolType.IntApp)
                    connDetail = prot.InterfaceControl.Info.ExtApp;
                else if (prot.InterfaceControl.Info.Hostname != "")
                    connDetail = prot.InterfaceControl.Info.Hostname;
                else
                    connDetail = "UNKNOWN";

                Runtime.MessageCollector.AddMessage(MessageClass.InformationMsg, string.Format(Language.strConnenctionClosedByUser, connDetail, prot.InterfaceControl.Info.Protocol, Environment.UserName));
                prot.InterfaceControl.Info.OpenConnections.Remove(prot);
                if (_activeConnections.Contains(prot.InterfaceControl.Info.ConstantID))
                    _activeConnections.Remove(prot.InterfaceControl.Info.ConstantID);

                if (prot.InterfaceControl.Info.PostExtApp == "") return;
                var extA = Runtime.ExternalToolsService.GetExtAppByName(prot.InterfaceControl.Info.PostExtApp);
                extA?.Start(prot.InterfaceControl.Info);
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace(Language.strConnenctionCloseEventFailed, ex);
            }
        }

        private static void Prot_Event_Connected(object sender)
        {
            var prot = (ProtocolBase)sender;
            Runtime.MessageCollector.AddMessage(MessageClass.InformationMsg, Language.strConnectionEventConnected, true);
            Runtime.MessageCollector.AddMessage(MessageClass.InformationMsg, string.Format(Language.strConnectionEventConnectedDetail, prot.InterfaceControl.Info.Hostname, prot.InterfaceControl.Info.Protocol, Environment.UserName, prot.InterfaceControl.Info.Description, prot.InterfaceControl.Info.UserField));
        }

        private static void Prot_Event_ErrorOccured(object sender, string errorMessage)
        {
            try
            {
                Runtime.MessageCollector.AddMessage(MessageClass.InformationMsg, Language.strConnectionEventErrorOccured, true);
                var prot = (ProtocolBase)sender;

                if (prot.InterfaceControl.Info.Protocol != ProtocolType.RDP) return;
                if (Convert.ToInt32(errorMessage) > -1)
                    Runtime.MessageCollector.AddMessage(MessageClass.WarningMsg, string.Format(Language.strConnectionRdpErrorDetail, errorMessage, RdpProtocol.FatalErrors.GetError(errorMessage)));
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace(Language.strConnectionEventConnectionFailed, ex);
            }
        }
        #endregion
    }
}
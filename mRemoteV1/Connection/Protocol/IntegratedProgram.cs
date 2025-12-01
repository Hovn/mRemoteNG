using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using mRemoteNG.App;
using mRemoteNG.Messages;
using mRemoteNG.Tools;

namespace mRemoteNG.Connection.Protocol
{
	public class IntegratedProgram : ProtocolBase
	{
        #region Private Fields
        private ExternalTool _externalTool;
        private IntPtr _handle;
        private Process _process;
        #endregion

        #region Public Methods
		public override bool Initialize()
		{
		    if (InterfaceControl.Info == null)
				return base.Initialize();

		    _externalTool = Runtime.ExternalToolsService.GetExtAppByName(InterfaceControl.Info.ExtApp);

			if (_externalTool == null)
			{
				Runtime.MessageCollector?.AddMessage(MessageClass.ErrorMsg, string.Format(Language.CouldNotFindExternalTool, InterfaceControl.Info.ExtApp));
				return false;
			}

			_externalTool.ConnectionInfo = InterfaceControl.Info;

		    return base.Initialize();
		}
				
		public override bool Connect()
		{
            //Console.WriteLine("CBH _externalTool.TryIntegrate: " + _externalTool.TryIntegrate);
            try
			{
                Runtime.MessageCollector?.AddMessage(MessageClass.InformationMsg, $"Attempting to start: {_externalTool.DisplayName}", true);

                if (_externalTool.TryIntegrate == false)
				{
					_externalTool.Start(InterfaceControl.Info);
                    /* Don't call close here... There's nothing for the override to do in this case since 
                     * _process is not created in this scenario. When returning false, ProtocolBase.Close()
                     * will be called - which is just going to call IntegratedProgram.Close() again anyway...
                     * Close();
                     */
                    Runtime.MessageCollector?.AddMessage(MessageClass.InformationMsg, $"Assuming no other errors/exceptions occurred immediately before this message regarding {_externalTool.DisplayName}, the next \"closed by user\" message can be ignored", true);
                    return false;
				}

                var argParser = new ExternalToolArgumentParser(_externalTool.ConnectionInfo);
			    _process = new Process
			    {
			        StartInfo =
			        {
			            UseShellExecute = true,
			            FileName = argParser.ParseArguments(_externalTool.FileName),
			            Arguments = argParser.ParseArguments(_externalTool.Arguments)
			        },
			        EnableRaisingEvents = true
			    };

                _process.Exited += ProcessExited;
                //CBH 针对RadminConnect的特殊集成处理，判断文件名（不带后缀）是不是RadminConnect
                bool isRadminConnect = Path.GetFileNameWithoutExtension(_process.StartInfo.FileName).Equals("RadminConnect", StringComparison.OrdinalIgnoreCase);
                //Console.WriteLine("CBH _process.StartInfo.FileName: " + _process.StartInfo.FileName+"|"+isRadminConnect);
                if (isRadminConnect)//_externalTool.DisplayName == "Radmin"
                    _process.Exited -= ProcessExited;//取消订阅事件

                _process.Start();

                //CBH 针对RadminConnect进行个性化处理，尝试集成后续窗口
                if (isRadminConnect)//_process.ProcessName == "RadminConnect" || _process.ProcessName == "AutoHotkey"
                {
                    _process.WaitForExit();
                    //uint radmin_hwnd = (uint)_process.ExitCode;
                    int radmin_pid = _process.ExitCode;
                    if (radmin_pid > 0)
                    {
                        _process = Process.GetProcessById(radmin_pid);//替换目标进程为实际的radmin进程
                        //IntPtr _hwnd = _process.MainWindowHandle;
                        _process.EnableRaisingEvents = true;   // 关键一步，否则事件不会被 CLR 转发
                        _process.Exited += ProcessExited;//注册订阅事件
                        Thread.Sleep(_externalTool.WaitAfterStart);
                        //Console.WriteLine("CBH radmin_process:" +radmin_process.ProcessName + "|"+radmin_process.Id + "|"  + radmin_hwnd);
                    }
                    else
                    {
                        ProcessExited(_process, EventArgs.Empty);
                        //Event_Closed(this);
                        Runtime.MessageCollector?.AddMessage(MessageClass.WarningMsg, Language.strConnectionOpenFailed);
                    }

                }
                //Console.WriteLine("CBH _process: " + _process.Id + "|" + _process.ProcessName);

                _process.WaitForInputIdle(Settings.Default.MaxPuttyWaitTime * 1000);//等对方窗口创建完成

                var startTicks = Environment.TickCount;
				while (_handle.ToInt32() == 0 & Environment.TickCount < startTicks + Settings.Default.MaxPuttyWaitTime * 1000)
				{
					_process.Refresh();
					if (_process.MainWindowTitle != "Default IME")
					{
						_handle = _process.MainWindowHandle;//找到真正的顶级窗口句柄
                    }
                    if (_handle.ToInt32() == 0)
					{
						Thread.Sleep(0);
					}
				}
						
				NativeMethods.SetParent(_handle, InterfaceControl.Handle);//把顶级窗变成子窗
				Runtime.MessageCollector?.AddMessage(MessageClass.InformationMsg, Language.strIntAppStuff, true);
				Runtime.MessageCollector?.AddMessage(MessageClass.InformationMsg, string.Format(Language.strIntAppHandle, _handle), true);
				Runtime.MessageCollector?.AddMessage(MessageClass.InformationMsg, string.Format(Language.strIntAppTitle, _process.MainWindowTitle), true);
				Runtime.MessageCollector?.AddMessage(MessageClass.InformationMsg, string.Format(Language.strIntAppParentHandle, InterfaceControl.Parent.Handle), true);
						
				Resize(this, new EventArgs());//修正大小、样式、填充当前Tab等
				base.Connect();
				return true;
			}
			catch (Exception ex)
			{
				Runtime.MessageCollector?.AddExceptionMessage(Language.strIntAppConnectionFailed, ex);
				return false;
			}
		}
				
		public override void Focus()
		{
			try
			{
				if (ConnectionWindow.InTabDrag) return;
				NativeMethods.SetForegroundWindow(_handle);
			}
			catch (Exception ex)
			{
				Runtime.MessageCollector.AddExceptionMessage(Language.strIntAppFocusFailed, ex);
			}
		}
				
		public override void Resize(object sender, EventArgs e)
		{
			try
			{
				if (InterfaceControl.Size == Size.Empty) return;
                NativeMethods.MoveWindow(_handle, -SystemInformation.FrameBorderSize.Width, -(SystemInformation.CaptionHeight + SystemInformation.FrameBorderSize.Height), InterfaceControl.Width + SystemInformation.FrameBorderSize.Width * 2, InterfaceControl.Height + SystemInformation.CaptionHeight + SystemInformation.FrameBorderSize.Height * 2, true);
			}
			catch (Exception ex)
			{
				Runtime.MessageCollector.AddExceptionMessage(Language.strIntAppResizeFailed, ex);
			}
		}
				
		public override void Close()
		{
            /* only attempt this if we have a valid process object
             * Non-integated tools will still call base.Close() and don't have a valid process object.
             * See Connect() above... This just muddies up the log.
             */
            if (_process != null)
		    {
		        try
		        {
		            if (!_process.HasExited)
		            {
		                _process.Kill();
		            }
		        }
		        catch (Exception ex)
		        {
		            Runtime.MessageCollector.AddExceptionMessage(Language.strIntAppKillFailed, ex);
		        }

		        try
		        {
		            if (!_process.HasExited)
		            {
		                _process.Dispose();
		            }
		        }
		        catch (Exception ex)
		        {
		            Runtime.MessageCollector.AddExceptionMessage(Language.strIntAppDisposeFailed, ex);
		        }
		    }

		    base.Close();
		}
        #endregion
        
        #region Private Methods
		private void ProcessExited(object sender, EventArgs e)
		{
            //Console.WriteLine("CBH ProcessExited: " );
            Event_Closed(this);
		}
        #endregion
		
        #region Enumerations
		public enum Defaults
		{
			Port = 0
		}
        #endregion
	}
}
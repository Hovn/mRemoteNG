using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using mRemoteNG.App;
using mRemoteNG.Connection;
using mRemoteNG.Connection.Protocol;
using mRemoteNG.Container;
using mRemoteNG.Tools;
using mRemoteNG.Tree;
using mRemoteNG.Tree.Root;
// ReSharper disable UnusedParameter.Local


namespace mRemoteNG.UI.Controls
{
    public sealed class ConnectionContextMenu : ContextMenuStrip
    {
        private ToolStripMenuItem _cMenTreeAddConnection;
        private ToolStripMenuItem _cMenTreeAddFolder;
        private ToolStripSeparator _cMenTreeSep1;
        private ToolStripMenuItem _cMenTreeConnect;
        private ToolStripMenuItem _cMenTreeConnectWithOptions;
        private ToolStripMenuItem _cMenTreeConnectWithOptionsDontConnectToConsoleSession;
        private ToolStripMenuItem _cMenTreeConnectWithOptionsConnectToConsoleSession;
        private ToolStripMenuItem _cMenTreeConnectWithOptionsConnectInFullscreen;
        private ToolStripMenuItem _cMenTreeConnectWithOptionsNoCredentials;
        private ToolStripMenuItem _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting;
        private ToolStripMenuItem _cMenTreeDisconnect;
        private ToolStripSeparator _cMenTreeSep2;
        private ToolStripMenuItem _cMenTreeToolsTransferFile;
        private ToolStripMenuItem _cMenTreeToolsSort;
        private ToolStripMenuItem _cMenTreeToolsSortAscending;
        private ToolStripMenuItem _cMenTreeToolsSortDescending;
        private ToolStripSeparator _cMenTreeSep3;
        private ToolStripMenuItem _cMenTreeRename;
        private ToolStripMenuItem _cMenTreeDelete;
        private ToolStripSeparator _cMenTreeSep4;
        private ToolStripMenuItem _cMenTreeMoveUp;
        private ToolStripMenuItem _cMenTreeMoveDown;
        private ToolStripMenuItem _cMenTreeToolsExternalApps;
        private ToolStripMenuItem _cMenTreeDuplicate;
        private ToolStripMenuItem _cMenTreeImport;
        private ToolStripMenuItem _cMenTreeExportFile;
        private ToolStripSeparator _toolStripSeparator1;
        private ToolStripMenuItem _cMenTreeImportFile;
        private ToolStripMenuItem _cMenTreeImportActiveDirectory;
        private ToolStripMenuItem _cMenTreeImportPortScan;
        private readonly ConnectionTree _connectionTree;
        private readonly IConnectionInitiator _connectionInitiator;


        public ConnectionContextMenu(ConnectionTree connectionTree)
        {
            _connectionTree = connectionTree;
            _connectionInitiator = new ConnectionInitiator();
            InitializeComponent();
            ApplyLanguage(); 
            EnableShortcutKeys();
            Opening += (sender, args) =>
            {
                AddExternalApps();

                //CBH Debug -------------------
                //Console.WriteLine($"--- Debug at {DateTime.Now} ---");
                //Console.WriteLine(_connectionTree.SelectedNode!=null? $"单个选中节点：{_connectionTree.SelectedNode.Name}" : "单个选中节点：无");
                //Console.WriteLine("多个选中节点："+_connectionTree.SelectedNodes.Count);
                //if (_connectionTree.SelectedNodes.Count > 0)
                //{
                //    var str = "";
                //    foreach (var obj in _connectionTree.SelectedNodes)
                //    {
                //        var node = (ConnectionInfo)obj;
                //        str += (node.Name+" | ");
                //    }
                //    Console.WriteLine($"多个选中节点: {str}");
                //}
                //Console.WriteLine("--- End ------");

                //不建议再以如下来判断是否弹右键菜单了，改用选中的数量
                //if (_connectionTree.SelectedNode == null)
                if (_connectionTree.SelectedNodes == null || _connectionTree.SelectedNodes.Count == 0)
                {
                    args.Cancel = true;
                    return;
                }
                ShowHideMenuItems();
            };
        }

        private void InitializeComponent()
        {
            _cMenTreeConnect = new ToolStripMenuItem();
            _cMenTreeConnectWithOptions = new ToolStripMenuItem();
            _cMenTreeConnectWithOptionsConnectToConsoleSession = new ToolStripMenuItem();
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession = new ToolStripMenuItem();
            _cMenTreeConnectWithOptionsConnectInFullscreen = new ToolStripMenuItem();
            _cMenTreeConnectWithOptionsNoCredentials = new ToolStripMenuItem();
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting = new ToolStripMenuItem();
            _cMenTreeDisconnect = new ToolStripMenuItem();
            _cMenTreeSep1 = new ToolStripSeparator();
            _cMenTreeToolsExternalApps = new ToolStripMenuItem();
            _cMenTreeToolsTransferFile = new ToolStripMenuItem();
            _cMenTreeSep2 = new ToolStripSeparator();
            _cMenTreeDuplicate = new ToolStripMenuItem();
            _cMenTreeRename = new ToolStripMenuItem();
            _cMenTreeDelete = new ToolStripMenuItem();
            _cMenTreeSep3 = new ToolStripSeparator();
            _cMenTreeImport = new ToolStripMenuItem();
            _cMenTreeImportFile = new ToolStripMenuItem();
            _cMenTreeImportActiveDirectory = new ToolStripMenuItem();
            _cMenTreeImportPortScan = new ToolStripMenuItem();
            _cMenTreeExportFile = new ToolStripMenuItem();
            _cMenTreeSep4 = new ToolStripSeparator();
            _cMenTreeAddConnection = new ToolStripMenuItem();
            _cMenTreeAddFolder = new ToolStripMenuItem();
            _toolStripSeparator1 = new ToolStripSeparator();
            _cMenTreeToolsSort = new ToolStripMenuItem();
            _cMenTreeToolsSortAscending = new ToolStripMenuItem();
            _cMenTreeToolsSortDescending = new ToolStripMenuItem();
            _cMenTreeMoveUp = new ToolStripMenuItem();
            _cMenTreeMoveDown = new ToolStripMenuItem();


            // 
            // cMenTree
            // 
            Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Items.AddRange(new ToolStripItem[] {
                _cMenTreeConnect,
                _cMenTreeConnectWithOptions,
                _cMenTreeDisconnect,
                _cMenTreeSep1,
                _cMenTreeToolsExternalApps,
                _cMenTreeToolsTransferFile,
                _cMenTreeSep2,
                _cMenTreeDuplicate,
                _cMenTreeRename,
                _cMenTreeDelete,
                _cMenTreeSep3,
                _cMenTreeImport,
                _cMenTreeExportFile,
                _cMenTreeSep4,
                _cMenTreeAddConnection,
                _cMenTreeAddFolder,
                _toolStripSeparator1,
                _cMenTreeToolsSort,
                _cMenTreeMoveUp,
                _cMenTreeMoveDown
            });
            Name = "cMenTree";
            RenderMode = ToolStripRenderMode.Professional;
            Size = new System.Drawing.Size(200, 364);
            // 
            // cMenTreeConnect
            // 
            _cMenTreeConnect.Image = Resources.Play;
            _cMenTreeConnect.Name = "_cMenTreeConnect";
            _cMenTreeConnect.Size = new System.Drawing.Size(199, 22);
            _cMenTreeConnect.Text = "Connect";
            _cMenTreeConnect.Click += OnConnectClicked;
            // 
            // cMenTreeConnectWithOptions
            // 
            _cMenTreeConnectWithOptions.DropDownItems.AddRange(new ToolStripItem[] {
                _cMenTreeConnectWithOptionsConnectToConsoleSession,
                _cMenTreeConnectWithOptionsDontConnectToConsoleSession,
                _cMenTreeConnectWithOptionsConnectInFullscreen,
                _cMenTreeConnectWithOptionsNoCredentials,
                _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting
            });
            _cMenTreeConnectWithOptions.Name = "_cMenTreeConnectWithOptions";
            _cMenTreeConnectWithOptions.Size = new System.Drawing.Size(199, 22);
            _cMenTreeConnectWithOptions.Text = "Connect (with options)";
            // 
            // cMenTreeConnectWithOptionsConnectToConsoleSession
            // 
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Image = Resources.monitor_go;
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Name = "_cMenTreeConnectWithOptionsConnectToConsoleSession";
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Size = new System.Drawing.Size(245, 22);
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Text = "Connect to console session";
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Click += OnConnectToConsoleSessionClicked;
            // 
            // cMenTreeConnectWithOptionsDontConnectToConsoleSession
            // 
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession.Image = Resources.monitor_delete;
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession.Name = "_cMenTreeConnectWithOptionsDontConnectToConsoleSession";
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession.Size = new System.Drawing.Size(245, 22);
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession.Text = "Don\'t connect to console session";
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession.Visible = false;
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession.Click += OnDontConnectToConsoleSessionClicked;
            // 
            // cMenTreeConnectWithOptionsConnectInFullscreen
            // 
            _cMenTreeConnectWithOptionsConnectInFullscreen.Image = Resources.arrow_out;
            _cMenTreeConnectWithOptionsConnectInFullscreen.Name = "_cMenTreeConnectWithOptionsConnectInFullscreen";
            _cMenTreeConnectWithOptionsConnectInFullscreen.Size = new System.Drawing.Size(245, 22);
            _cMenTreeConnectWithOptionsConnectInFullscreen.Text = "Connect in fullscreen";
            _cMenTreeConnectWithOptionsConnectInFullscreen.Click += OnConnectInFullscreenClicked;
            // 
            // cMenTreeConnectWithOptionsNoCredentials
            // 
            _cMenTreeConnectWithOptionsNoCredentials.Image = Resources.key_delete;
            _cMenTreeConnectWithOptionsNoCredentials.Name = "_cMenTreeConnectWithOptionsNoCredentials";
            _cMenTreeConnectWithOptionsNoCredentials.Size = new System.Drawing.Size(245, 22);
            _cMenTreeConnectWithOptionsNoCredentials.Text = "Connect without credentials";
            _cMenTreeConnectWithOptionsNoCredentials.Click += OnConnectWithNoCredentialsClick;
            // 
            // cMenTreeConnectWithOptionsChoosePanelBeforeConnecting
            // 
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Image = Resources.Panels;
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Name = "_cMenTreeConnectWithOptionsChoosePanelBeforeConnecting";
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Size = new System.Drawing.Size(245, 22);
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Text = "Choose panel before connecting";
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Click += OnChoosePanelBeforeConnectingClicked;
            // 
            // cMenTreeDisconnect
            // 
            _cMenTreeDisconnect.Image = Resources.Pause;
            _cMenTreeDisconnect.Name = "_cMenTreeDisconnect";
            _cMenTreeDisconnect.Size = new System.Drawing.Size(199, 22);
            _cMenTreeDisconnect.Text = "Disconnect";
            _cMenTreeDisconnect.Click += OnDisconnectClicked;
            // 
            // cMenTreeSep1
            // 
            _cMenTreeSep1.Name = "_cMenTreeSep1";
            _cMenTreeSep1.Size = new System.Drawing.Size(196, 6);
            // 
            // cMenTreeToolsExternalApps
            // 
            _cMenTreeToolsExternalApps.Image = Resources.ExtApp;
            _cMenTreeToolsExternalApps.Name = "_cMenTreeToolsExternalApps";
            _cMenTreeToolsExternalApps.Size = new System.Drawing.Size(199, 22);
            _cMenTreeToolsExternalApps.Text = "External Applications";
            // 
            // cMenTreeToolsTransferFile
            // 
            _cMenTreeToolsTransferFile.Image = Resources.SSHTransfer;
            _cMenTreeToolsTransferFile.Name = "_cMenTreeToolsTransferFile";
            _cMenTreeToolsTransferFile.Size = new System.Drawing.Size(199, 22);
            _cMenTreeToolsTransferFile.Text = "Transfer File (SSH)";
            _cMenTreeToolsTransferFile.Click += OnTransferFileClicked;
            // 
            // cMenTreeSep2
            // 
            _cMenTreeSep2.Name = "_cMenTreeSep2";
            _cMenTreeSep2.Size = new System.Drawing.Size(196, 6);
            // 
            // cMenTreeDuplicate
            // 
            _cMenTreeDuplicate.Image = Resources.page_copy;
            _cMenTreeDuplicate.Name = "_cMenTreeDuplicate";
            _cMenTreeDuplicate.Size = new System.Drawing.Size(199, 22);
            _cMenTreeDuplicate.Text = "Duplicate";
            _cMenTreeDuplicate.Click += OnDuplicateClicked;
            // 
            // cMenTreeRename
            // 
            _cMenTreeRename.Image = Resources.Rename;
            _cMenTreeRename.Name = "_cMenTreeRename";
            _cMenTreeRename.Size = new System.Drawing.Size(199, 22);
            _cMenTreeRename.Text = "Rename";
            _cMenTreeRename.Click += OnRenameClicked;
            // 
            // cMenTreeDelete
            // 
            _cMenTreeDelete.Image = Resources.Delete;
            _cMenTreeDelete.Name = "_cMenTreeDelete";
            _cMenTreeDelete.Size = new System.Drawing.Size(199, 22);
            _cMenTreeDelete.Text = "Delete";
            _cMenTreeDelete.Click += OnDeleteClicked;
            // 
            // cMenTreeSep3
            // 
            _cMenTreeSep3.Name = "_cMenTreeSep3";
            _cMenTreeSep3.Size = new System.Drawing.Size(196, 6);
            // 
            // cMenTreeImport
            // 
            _cMenTreeImport.DropDownItems.AddRange(new ToolStripItem[] {
                _cMenTreeImportFile,
                _cMenTreeImportActiveDirectory,
                _cMenTreeImportPortScan
            });
            _cMenTreeImport.Name = "_cMenTreeImport";
            _cMenTreeImport.Size = new System.Drawing.Size(199, 22);
            _cMenTreeImport.Text = "&Import";
            // 
            // cMenTreeImportFile
            // 
            _cMenTreeImportFile.Name = "_cMenTreeImportFile";
            _cMenTreeImportFile.Size = new System.Drawing.Size(226, 22);
            _cMenTreeImportFile.Text = "Import from &File...";
            _cMenTreeImportFile.Click += OnImportFileClicked;
            // 
            // cMenTreeImportActiveDirectory
            // 
            _cMenTreeImportActiveDirectory.Name = "_cMenTreeImportActiveDirectory";
            _cMenTreeImportActiveDirectory.Size = new System.Drawing.Size(226, 22);
            _cMenTreeImportActiveDirectory.Text = "Import from &Active Directory...";
            _cMenTreeImportActiveDirectory.Click += OnImportActiveDirectoryClicked;
            // 
            // cMenTreeImportPortScan
            // 
            _cMenTreeImportPortScan.Name = "_cMenTreeImportPortScan";
            _cMenTreeImportPortScan.Size = new System.Drawing.Size(226, 22);
            _cMenTreeImportPortScan.Text = "Import from &Port Scan...";
            _cMenTreeImportPortScan.Click += OnImportPortScanClicked;
            // 
            // cMenTreeExportFile
            // 
            _cMenTreeExportFile.Name = "_cMenTreeExportFile";
            _cMenTreeExportFile.Size = new System.Drawing.Size(199, 22);
            _cMenTreeExportFile.Text = "&Export to File...";
            _cMenTreeExportFile.Click += OnExportFileClicked;
            // 
            // cMenTreeSep4
            // 
            _cMenTreeSep4.Name = "_cMenTreeSep4";
            _cMenTreeSep4.Size = new System.Drawing.Size(196, 6);
            // 
            // cMenTreeAddConnection
            // 
            _cMenTreeAddConnection.Image = Resources.Connection_Add;
            _cMenTreeAddConnection.Name = "_cMenTreeAddConnection";
            _cMenTreeAddConnection.Size = new System.Drawing.Size(199, 22);
            _cMenTreeAddConnection.Text = "New Connection";
            _cMenTreeAddConnection.Click += OnAddConnectionClicked;
            // 
            // cMenTreeAddFolder
            // 
            _cMenTreeAddFolder.Image = Resources.Folder_Add;
            _cMenTreeAddFolder.Name = "_cMenTreeAddFolder";
            _cMenTreeAddFolder.Size = new System.Drawing.Size(199, 22);
            _cMenTreeAddFolder.Text = "New Folder";
            _cMenTreeAddFolder.Click += OnAddFolderClicked;
            // 
            // ToolStripSeparator1
            // 
            _toolStripSeparator1.Name = "_toolStripSeparator1";
            _toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // cMenTreeToolsSort
            // 
            _cMenTreeToolsSort.DropDownItems.AddRange(new ToolStripItem[] {
                _cMenTreeToolsSortAscending,
                _cMenTreeToolsSortDescending
            });
            _cMenTreeToolsSort.Name = "_cMenTreeToolsSort";
            _cMenTreeToolsSort.Size = new System.Drawing.Size(199, 22);
            _cMenTreeToolsSort.Text = "Sort";
            // 
            // cMenTreeToolsSortAscending
            // 
            _cMenTreeToolsSortAscending.Image = Resources.Sort_AZ;
            _cMenTreeToolsSortAscending.Name = "_cMenTreeToolsSortAscending";
            _cMenTreeToolsSortAscending.Size = new System.Drawing.Size(161, 22);
            _cMenTreeToolsSortAscending.Text = "Ascending (A-Z)";
            _cMenTreeToolsSortAscending.Click += OnSortAscendingClicked;
            // 
            // cMenTreeToolsSortDescending
            // 
            _cMenTreeToolsSortDescending.Image = Resources.Sort_ZA;
            _cMenTreeToolsSortDescending.Name = "_cMenTreeToolsSortDescending";
            _cMenTreeToolsSortDescending.Size = new System.Drawing.Size(161, 22);
            _cMenTreeToolsSortDescending.Text = "Descending (Z-A)";
            _cMenTreeToolsSortDescending.Click += OnSortDescendingClicked;
            // 
            // cMenTreeMoveUp
            // 
            _cMenTreeMoveUp.Image = Resources.Arrow_Up;
            _cMenTreeMoveUp.Name = "_cMenTreeMoveUp";
            _cMenTreeMoveUp.Size = new System.Drawing.Size(199, 22);
            _cMenTreeMoveUp.Text = "Move up";
            _cMenTreeMoveUp.Click += OnMoveUpClicked;
            // 
            // cMenTreeMoveDown
            // 
            _cMenTreeMoveDown.Image = Resources.Arrow_Down;
            _cMenTreeMoveDown.Name = "_cMenTreeMoveDown";
            _cMenTreeMoveDown.Size = new System.Drawing.Size(199, 22);
            _cMenTreeMoveDown.Text = "Move down";
            _cMenTreeMoveDown.Click += OnMoveDownClicked;
        }

        private void ApplyLanguage()
        {
            _cMenTreeConnect.Text = Language.strConnect;
            _cMenTreeConnectWithOptions.Text = Language.strConnectWithOptions;
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Text = Language.strConnectToConsoleSession;
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession.Text = Language.strDontConnectToConsoleSessionMenuItem;
            _cMenTreeConnectWithOptionsConnectInFullscreen.Text = Language.strConnectInFullscreen;
            _cMenTreeConnectWithOptionsNoCredentials.Text = Language.strConnectNoCredentials;
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Text = Language.strChoosePanelBeforeConnecting;
            _cMenTreeDisconnect.Text = Language.strMenuDisconnect;

            _cMenTreeToolsExternalApps.Text = Language.strMenuExternalTools;
            _cMenTreeToolsTransferFile.Text = Language.strMenuTransferFile;

            _cMenTreeDuplicate.Text = Language.strDuplicate;
            _cMenTreeRename.Text = Language.strRename;
            _cMenTreeDelete.Text = Language.strMenuDelete;

            _cMenTreeImport.Text = Language.strImportMenuItem;
            _cMenTreeImportFile.Text = Language.strImportFromFileMenuItem;
            _cMenTreeImportActiveDirectory.Text = Language.strImportAD;
            _cMenTreeImportPortScan.Text = Language.strImportPortScan;
            _cMenTreeExportFile.Text = Language.strExportToFileMenuItem;

            _cMenTreeAddConnection.Text = Language.strAddConnection;
            _cMenTreeAddFolder.Text = Language.strAddFolder;

            _cMenTreeToolsSort.Text = Language.strSort;
            _cMenTreeToolsSortAscending.Text = Language.strSortAsc;
            _cMenTreeToolsSortDescending.Text = Language.strSortDesc;
            _cMenTreeMoveUp.Text = Language.strMoveUp;
            _cMenTreeMoveDown.Text = Language.strMoveDown;
        }

        //CBH 根据 选中节点 类型的不同，菜单项针对性进行启用或禁用
        internal void ShowHideMenuItems()
        {
            try
            {
                Enabled = true;
                EnableMenuItemsRecursive(Items);
                //CBH 多选节点的场景时构建特殊的右键菜单
                if (_connectionTree.SelectedNodes.Count > 1)
                {
                    //ShowHideMenuItemsForMultiConnectionNode(_connectionTree.SelectedNodes);
                    ShowHideMenuItemsForMultiConnectionNode();
                    return;
                }

                //PuTTY会话已保存 根节点
                if (_connectionTree.SelectedNode is RootPuttySessionsNodeInfo)
                {
                    ShowHideMenuItemsForRootPuttyNode();
                }
                //连接 根节点
                else if (_connectionTree.SelectedNode is RootNodeInfo)
                {
                    ShowHideMenuItemsForRootConnectionNode();
                }
                //容器节点
                else if (_connectionTree.SelectedNode is ContainerInfo)
                {
                    ShowHideMenuItemsForContainer(_connectionTree.SelectedNode);
                }
                //PuTTY会话 常规节点
                else if (_connectionTree.SelectedNode is PuttySessionInfo)
                {
                    ShowHideMenuItemsForPuttyNode(_connectionTree.SelectedNode);
                }
                //默认节点（服务器 常规节点）
                else
                {
                    ShowHideMenuItemsForConnectionNode(_connectionTree.SelectedNode);
                }
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace("ShowHideMenuItems (UI.Controls.ConnectionContextMenu) failed", ex);
            }
        }

        //CBH 多选节点的场景时构建特殊的右键菜单
        internal void ShowHideMenuItemsForMultiConnectionNode()
        {
            _cMenTreeConnect.Enabled = true;  //连接
            _cMenTreeConnectWithOptions.Enabled = false;  //连接（选项）
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Enabled = false;//子菜单
            _cMenTreeConnectWithOptionsConnectInFullscreen.Enabled = false;//子菜单
            _cMenTreeConnectWithOptionsNoCredentials.Enabled = false;//子菜单
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Enabled = false;//子菜单
            _cMenTreeDisconnect.Enabled = true;  //断开连接

            _cMenTreeToolsExternalApps.Enabled = true;  //外部工具
            _cMenTreeToolsTransferFile.Enabled = false;

            _cMenTreeDuplicate.Enabled = false;
            _cMenTreeRename.Enabled = false;
            _cMenTreeDelete.Enabled = true;  //删除

            _cMenTreeImport.Enabled = false;
            _cMenTreeExportFile.Enabled = false;

            _cMenTreeAddConnection.Enabled = false;
            _cMenTreeAddFolder.Enabled = false;

            _cMenTreeToolsSort.Enabled = false;
            _cMenTreeMoveUp.Enabled = false;
            _cMenTreeMoveDown.Enabled = false;
        }

        //PuTTY会话已保存 根节点
        internal void ShowHideMenuItemsForRootPuttyNode()
        {
            _cMenTreeConnect.Enabled = false;
            _cMenTreeConnectWithOptions.Enabled = false;
            _cMenTreeDisconnect.Enabled = false;

            _cMenTreeToolsExternalApps.Enabled = false;
            _cMenTreeToolsTransferFile.Enabled = false;

            _cMenTreeDuplicate.Enabled = false;
            _cMenTreeRename.Enabled = false;
            _cMenTreeDelete.Enabled = false;

            _cMenTreeImport.Enabled = false;
            _cMenTreeExportFile.Enabled = false;

            _cMenTreeAddConnection.Enabled = false;
            _cMenTreeAddFolder.Enabled = false;

            _cMenTreeToolsSort.Enabled = false;
            _cMenTreeMoveUp.Enabled = false;
            _cMenTreeMoveDown.Enabled = false;
        }

        //连接 根节点  //的表示 true 启用
        internal void ShowHideMenuItemsForRootConnectionNode()
        {
            _cMenTreeConnect.Enabled = false;
            _cMenTreeConnectWithOptions.Enabled = false;
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Enabled = false;//子菜单
            _cMenTreeConnectWithOptionsConnectInFullscreen.Enabled = false;//子菜单
            //
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Enabled = false;//子菜单
            _cMenTreeDisconnect.Enabled = false;
            
            _cMenTreeToolsExternalApps.Enabled = false;
            _cMenTreeToolsTransferFile.Enabled = false;
            
            _cMenTreeDuplicate.Enabled = false;
            //_cMenTreeRename.Enabled = false;
            _cMenTreeDelete.Enabled = false;
            
            //_cMenTreeImport.Enabled = false;
            //_cMenTreeExportFile.Enabled = false;
            
            //_cMenTreeAddConnection.Enabled = false;
            //_cMenTreeAddFolder.Enabled = false;

            //_cMenTreeToolsSort.Enabled = false;
            _cMenTreeMoveUp.Enabled = false;
            _cMenTreeMoveDown.Enabled = false;
         }

        //容器节点
        internal void ShowHideMenuItemsForContainer(ConnectionInfo connectionInfo)
        {
            //连接选项子菜单
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Enabled = false;
            _cMenTreeConnectWithOptionsConnectInFullscreen.Enabled = false;

            //如果有打开的连接。则启用‘断开连接’
            var openConnections = ((ContainerInfo)connectionInfo).Children.Sum(child => child.OpenConnections.Count);
            _cMenTreeDisconnect.Enabled = (openConnections > 0);

            //CBH 容器也可以使用外部工具
            _cMenTreeToolsExternalApps.Enabled = true;
            _cMenTreeToolsTransferFile.Enabled = false;
        }

        //PuTTY会话 常规节点
        internal void ShowHideMenuItemsForPuttyNode(ConnectionInfo connectionInfo)
        {
            //连接选项子菜单
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Enabled = false;
            _cMenTreeConnectWithOptionsConnectInFullscreen.Enabled = false;
            
            _cMenTreeAddConnection.Enabled = false;
            _cMenTreeAddFolder.Enabled = false;

            if (connectionInfo.OpenConnections.Count == 0)
                _cMenTreeDisconnect.Enabled = false;

            if (!(connectionInfo.Protocol == ProtocolType.SSH1 || connectionInfo.Protocol == ProtocolType.SSH2))
                _cMenTreeToolsTransferFile.Enabled = false;

            _cMenTreeDuplicate.Enabled = false;
            _cMenTreeRename.Enabled = false;
            _cMenTreeDelete.Enabled = false;

            _cMenTreeImport.Enabled = false;
            _cMenTreeExportFile.Enabled = false;

            _cMenTreeToolsSort.Enabled = false;
            _cMenTreeMoveUp.Enabled = false;
            _cMenTreeMoveDown.Enabled = false;
        }

        //默认节点（服务器 常规节点）
        internal void ShowHideMenuItemsForConnectionNode(ConnectionInfo connectionInfo)
        {
            //如果没有打开的连接。则禁用‘断开连接’
            if (connectionInfo.OpenConnections.Count == 0)
                _cMenTreeDisconnect.Enabled = false;

            if (!(connectionInfo.Protocol == ProtocolType.SSH1 || connectionInfo.Protocol == ProtocolType.SSH2))
                _cMenTreeToolsTransferFile.Enabled = false;

            if (!(connectionInfo.Protocol == ProtocolType.RDP || connectionInfo.Protocol == ProtocolType.ICA))
            {
                _cMenTreeConnectWithOptionsConnectToConsoleSession.Enabled = false;
                _cMenTreeConnectWithOptionsConnectInFullscreen.Enabled = false;
            }

            if (connectionInfo.Protocol == ProtocolType.IntApp)
                _cMenTreeConnectWithOptionsNoCredentials.Enabled = false;
        }

        internal void DisableShortcutKeys()
        {
            _cMenTreeConnect.ShortcutKeys = Keys.None;
            _cMenTreeDuplicate.ShortcutKeys = Keys.None;
            _cMenTreeRename.ShortcutKeys = Keys.None;
            _cMenTreeDelete.ShortcutKeys = Keys.None;
            _cMenTreeMoveUp.ShortcutKeys = Keys.None;
            _cMenTreeMoveDown.ShortcutKeys = Keys.None;
        }

        internal void EnableShortcutKeys()
        {
            _cMenTreeConnect.ShortcutKeys = ((Keys.Control | Keys.Shift) | Keys.C);
            _cMenTreeDuplicate.ShortcutKeys = Keys.Control | Keys.D;
            _cMenTreeRename.ShortcutKeys = Keys.F2;
            _cMenTreeDelete.ShortcutKeys = Keys.Delete;
            _cMenTreeMoveUp.ShortcutKeys = Keys.Control | Keys.Up;
            _cMenTreeMoveDown.ShortcutKeys = Keys.Control | Keys.Down;
        }

        //启用所有菜单项及子菜单项
        private static void EnableMenuItemsRecursive(ToolStripItemCollection items, bool enable = true)
        {
            foreach (ToolStripItem item in items)
            {
                var menuItem = item as ToolStripMenuItem;
                if (menuItem == null)
                {
                    continue;
                }
                menuItem.Enabled = enable;
                if (menuItem.HasDropDownItems)
                {
                    EnableMenuItemsRecursive(menuItem.DropDownItems, enable);
                }
            }
        }

        private void AddExternalApps()
        {
            try
            {
                ResetExternalAppMenu();

                foreach (ExternalTool extTool in Runtime.ExternalToolsService.ExternalTools)
                {
                    var menuItem = new ToolStripMenuItem
                    {
                        Text = extTool.DisplayName,
                        Tag = extTool,
                        Image = extTool.Image
                    };
                    //CBH 字体：连接项右键外部工具菜单可使用自定义字体
                    menuItem.Font = Settings.Default.ConnectionTreeWindowExtAppsMenuFont;
                    menuItem.Click += OnExternalToolClicked;
                    _cMenTreeToolsExternalApps.DropDownItems.Add(menuItem);
                }
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace("cMenTreeTools_DropDownOpening failed (UI.Window.ConnectionTreeWindow)", ex);
            }
        }

        private void ResetExternalAppMenu()
        {
            if (_cMenTreeToolsExternalApps.DropDownItems.Count <= 0) return;
            for (var i = _cMenTreeToolsExternalApps.DropDownItems.Count - 1; i >= 0; i--)
                _cMenTreeToolsExternalApps.DropDownItems[i].Dispose();

            _cMenTreeToolsExternalApps.DropDownItems.Clear();
        }

        //菜单点击处理逻辑
        #region Click handlers
        private void OnConnectClicked(object sender, EventArgs e)
        {
            if (_connectionTree.SelectedNodes.Count > 0) //单选/多选节点时
            {
                foreach (ConnectionInfo node in _connectionTree.SelectedNodes)
                {
                    var asContainer = node as ContainerInfo;
                    if (asContainer != null)
                    {
                        //连接容器下的所有服务器
                        _connectionInitiator.OpenConnection(asContainer, ConnectionInfo.Force.DoNotJump);
                    }
                    else
                    {
                        _connectionInitiator.OpenConnection(node, ConnectionInfo.Force.DoNotJump);
                        //await Task.Delay(1500);  //CBH 批量打开多选的多个连接，每次延时
                    }

                }
            }


            //ORI
            //var selectedNodeAsContainer = _connectionTree.SelectedNode as ContainerInfo;
            //if (selectedNodeAsContainer != null)
            //    _connectionInitiator.OpenConnection(selectedNodeAsContainer, ConnectionInfo.Force.DoNotJump);
            //else
            //    _connectionInitiator.OpenConnection(_connectionTree.SelectedNode, ConnectionInfo.Force.DoNotJump);
        }

        private void OnConnectToConsoleSessionClicked(object sender, EventArgs e)
        {
            var selectedNodeAsContainer = _connectionTree.SelectedNode as ContainerInfo;
            if (selectedNodeAsContainer != null)
                _connectionInitiator.OpenConnection(selectedNodeAsContainer, ConnectionInfo.Force.UseConsoleSession | ConnectionInfo.Force.DoNotJump);
            else
                _connectionInitiator.OpenConnection(_connectionTree.SelectedNode, ConnectionInfo.Force.UseConsoleSession | ConnectionInfo.Force.DoNotJump);
        }

        private void OnDontConnectToConsoleSessionClicked(object sender, EventArgs e)
        {
            var selectedNodeAsContainer = _connectionTree.SelectedNode as ContainerInfo;
            if (selectedNodeAsContainer != null)
                _connectionInitiator.OpenConnection(selectedNodeAsContainer, ConnectionInfo.Force.DontUseConsoleSession | ConnectionInfo.Force.DoNotJump);
            else
                _connectionInitiator.OpenConnection(_connectionTree.SelectedNode, ConnectionInfo.Force.DontUseConsoleSession | ConnectionInfo.Force.DoNotJump);
        }

        private void OnConnectInFullscreenClicked(object sender, EventArgs e)
        {
            var selectedNodeAsContainer = _connectionTree.SelectedNode as ContainerInfo;
            if (selectedNodeAsContainer != null)
                _connectionInitiator.OpenConnection(selectedNodeAsContainer, ConnectionInfo.Force.Fullscreen | ConnectionInfo.Force.DoNotJump);
            else
                _connectionInitiator.OpenConnection(_connectionTree.SelectedNode, ConnectionInfo.Force.Fullscreen | ConnectionInfo.Force.DoNotJump);
        }

        private void OnConnectWithNoCredentialsClick(object sender, EventArgs e)
        {
            var selectedNodeAsContainer = _connectionTree.SelectedNode as ContainerInfo;
            if (selectedNodeAsContainer != null)
                _connectionInitiator.OpenConnection(selectedNodeAsContainer, ConnectionInfo.Force.NoCredentials);
            else
                _connectionInitiator.OpenConnection(_connectionTree.SelectedNode, ConnectionInfo.Force.NoCredentials);
        }

        private void OnChoosePanelBeforeConnectingClicked(object sender, EventArgs e)
        {
            var selectedNodeAsContainer = _connectionTree.SelectedNode as ContainerInfo;
            if (selectedNodeAsContainer != null)
                _connectionInitiator.OpenConnection(selectedNodeAsContainer, ConnectionInfo.Force.OverridePanel | ConnectionInfo.Force.DoNotJump);
            else
                _connectionInitiator.OpenConnection(_connectionTree.SelectedNode, ConnectionInfo.Force.OverridePanel | ConnectionInfo.Force.DoNotJump);
        }

        //CBH
        private void OnDisconnectClicked(object sender, EventArgs e)
        {
            if (_connectionTree.SelectedNodes.Count > 0) //单选/多选节点时
            {
                foreach (ConnectionInfo node in _connectionTree.SelectedNodes)
                {
                    DisconnectConnection(node);
                }
            }

            //DisconnectConnection(_connectionTree.SelectedNode);
        }

        public void DisconnectConnection(ConnectionInfo connectionInfo)
        {
            try
            {
                if (connectionInfo == null) return;
                var nodeAsContainer = connectionInfo as ContainerInfo;
                if (nodeAsContainer != null)
                {
                    foreach (var child in nodeAsContainer.Children)
                    {
                        for (var i = 0; i <= child.OpenConnections.Count - 1; i++)
                        {
                            child.OpenConnections[i].Disconnect();
                        }
                    }
                }
                else
                {
                    for (var i = 0; i <= connectionInfo.OpenConnections.Count - 1; i++)
                    {
                        connectionInfo.OpenConnections[i].Disconnect();
                    }
                }
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace("DisconnectConnection (UI.Window.ConnectionTreeWindow) failed", ex);
            }
        }

        private void OnTransferFileClicked(object sender, EventArgs e)
        {
            //CBH 文件传输(SSH) 菜单 使用自定义的传输工具，配置成某个外部工具的名字，比如 WinSCP
            //非SSH协议的节点，菜单会默认置灰，不可使用
            string connectionTreeWindowSSHTransferFileMenuUse = Settings.Default.ConnectionTreeWindowSSHTransferFileMenuUse;
            if (!string.IsNullOrEmpty(connectionTreeWindowSSHTransferFileMenuUse) && connectionTreeWindowSSHTransferFileMenuUse != "Default")
            {
                ConnectionInfo selectedNode = this._connectionTree.SelectedNode;
                ExternalTool extAppByName = Runtime.ExternalToolsService.GetExtAppByName(connectionTreeWindowSSHTransferFileMenuUse);
                if (extAppByName != null)
                {
                    extAppByName.Start(selectedNode);
                    return;
                }
            }

            SshTransferFile();
        }

        public void SshTransferFile()
        {
            try
            {
                Windows.Show(WindowType.SSHTransfer);
                Windows.SshtransferForm.Hostname = _connectionTree.SelectedNode.Hostname;
                Windows.SshtransferForm.Username = _connectionTree.SelectedNode.Username;
                Windows.SshtransferForm.Password = _connectionTree.SelectedNode.Password;
                Windows.SshtransferForm.Port = Convert.ToString(_connectionTree.SelectedNode.Port);
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace("SSHTransferFile (UI.Window.ConnectionTreeWindow) failed", ex);
            }
        }

        private void OnDuplicateClicked(object sender, EventArgs e)
        {
            _connectionTree.DuplicateSelectedNode();
        }

        private void OnRenameClicked(object sender, EventArgs e)
        {
            _connectionTree.RenameSelectedNode();
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            //CBH 不弹框确认，直接删除
            _connectionTree.DeleteSelectedNodes();
            //if (_connectionTree.SelectedNodes.Count > 1)// 如果 >1 则为多选模式，不弹框，直接删除
            //{
            //    _connectionTree.DeleteSelectedNodes();
            //    return;
            //}
           
            //ORI 会弹框确认
            //_connectionTree.DeleteSelectedNode();
        }

        private void OnImportFileClicked(object sender, EventArgs e)
        {
            ContainerInfo selectedNodeAsContainer;
            if (_connectionTree.SelectedNode == null)
                selectedNodeAsContainer = Runtime.ConnectionsService.ConnectionTreeModel.RootNodes.First();
            else
                selectedNodeAsContainer = _connectionTree.SelectedNode as ContainerInfo ?? _connectionTree.SelectedNode.Parent;
            Import.ImportFromFile(selectedNodeAsContainer);
        }

        private void OnImportActiveDirectoryClicked(object sender, EventArgs e)
        {
            Windows.Show(WindowType.ActiveDirectoryImport);
        }

        private void OnImportPortScanClicked(object sender, EventArgs e)
        {
            Windows.Show(WindowType.PortScan);
        }

        private void OnExportFileClicked(object sender, EventArgs e)
        {
            Export.ExportToFile(_connectionTree.SelectedNode, Runtime.ConnectionsService.ConnectionTreeModel);
        }

        private void OnAddConnectionClicked(object sender, EventArgs e)
        {
            _connectionTree.AddConnection();
        }

        private void OnAddFolderClicked(object sender, EventArgs e)
        {
            _connectionTree.AddFolder();
        }

        private void OnSortAscendingClicked(object sender, EventArgs e)
        {
            _connectionTree.SortRecursive(_connectionTree.SelectedNode, ListSortDirection.Ascending);
        }

        private void OnSortDescendingClicked(object sender, EventArgs e)
        {
            _connectionTree.SortRecursive(_connectionTree.SelectedNode, ListSortDirection.Descending);
        }

        private void OnMoveUpClicked(object sender, EventArgs e)
        {
            _connectionTree.SelectedNode.Parent.PromoteChild(_connectionTree.SelectedNode);
        }

        private void OnMoveDownClicked(object sender, EventArgs e)
        {
            _connectionTree.SelectedNode.Parent.DemoteChild(_connectionTree.SelectedNode);
        }

        private void OnExternalToolClicked(object sender, EventArgs e)
        {
            //ORI
            //StartExternalApp((ExternalTool)((ToolStripMenuItem)sender).Tag);

            //CBH
            StartExternalApp_CBH((ExternalTool)((ToolStripMenuItem)sender).Tag);
            //StartExternalApp_CBH((ExternalTool)((ToolStripMenuItem)sender).Tag, _connectionTree.SelectedNode);
        }

        //原始方法：只允许在常规 服务器及PuTTY节点上使用（不允许在容器类型上执行）
        private void StartExternalApp(ExternalTool externalTool)
        {
            try
            {
                if (_connectionTree.SelectedNode.GetTreeNodeType() == TreeNodeType.Connection | _connectionTree.SelectedNode.GetTreeNodeType() == TreeNodeType.PuttySession)
                    externalTool.Start(_connectionTree.SelectedNode);
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace("cMenTreeToolsExternalAppsEntry_Click failed (UI.Window.ConnectionTreeWindow)", ex);
            }
        }

        //CBH  支持在多选节点上启动外部工具
        private async void StartExternalApp_CBH(ExternalTool externalTool)
        {
            try
            {
                if (_connectionTree.SelectedNodes.Count > 0) //单选/多选节点时
                {
                    foreach (ConnectionInfo node in _connectionTree.SelectedNodes)
                    {
                        StartExternalApp_CBH(externalTool, node);
                        await Task.Delay(externalTool.WaitAfterStart); //每启动一个等待一会
                    }
                }

            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace("cMenTreeToolsExternalAppsEntry_Click failed (UI.Window.ConnectionTreeWindow)", ex);
            }
        }

        //CBH
        //如果是在容器上执行外部工具，则循环子节点逐一执行外部工具。
        //保留 2 s 延迟逻辑；若将来需要并发启动，可再把 Delay 换成 SemaphoreSlim 等。
        //方法签名仍然保持 async void，因为看起来是事件处理器；如果是普通业务方法，建议改为 async Task。
        private async void StartExternalApp_CBH(ExternalTool externalTool, ConnectionInfo node)
        {
            try
            {
                TreeNodeType nodeType = node.GetTreeNodeType();
                // 1. 处理容器分支
                if (node is ContainerInfo container && nodeType == TreeNodeType.Container)
                {
                    if (container.Children.Count == 0)
                        return;

                    foreach (ConnectionInfo child in container.Children)
                    {
                        StartExternalApp_CBH(externalTool, child);   // 递归
                        await Task.Delay(externalTool.WaitAfterStart); // 每启动一个等待一会，使用配置文件配置
                    }
                    //return;
                }

                // 2. 处理普通连接或 PuTTY 会话
                else if (nodeType == TreeNodeType.Connection || nodeType == TreeNodeType.PuttySession)
                {
                    externalTool.Start(node);
                }
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace("cMenTreeToolsExternalAppsEntry_Click failed (UI.Window.ConnectionTreeWindow)", ex);
            }
        }

        
        #endregion
    }
}
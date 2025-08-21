using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using mRemoteNG.App;
using mRemoteNG.Connection;
using mRemoteNG.Connection.Protocol;
using mRemoteNG.Messages;
// ReSharper disable ArrangeAccessorOwnerBody

namespace mRemoteNG.Tools
{
    public class ExternalTool : INotifyPropertyChanged
    {
        private readonly IConnectionInitiator _connectionInitiator = new ConnectionInitiator();
        private string _displayName;
        private string _fileName;
        private bool _waitForExit;
        private int _waitAfterStart = 0;
        private string _arguments;
        private string _workingDir;
        private bool _tryIntegrate;
        private bool _showOnToolbar = false;
        private bool _runElevated;

        #region Public Properties

        public string DisplayName
        {
            get { return _displayName; }
            set { SetField(ref _displayName, value, nameof(DisplayName)); }
        }

        public string FileName
        {
            get { return _fileName; }
            set { SetField(ref _fileName, value, nameof(FileName)); }
        }

        public bool WaitForExit
        {
            get { return _waitForExit; }
            set
            {
                // WaitForExit cannot be turned on when TryIntegrate is true
                if (TryIntegrate)
                    return;
                SetField(ref _waitForExit, value, nameof(WaitForExit));
            }
        }

        public int WaitAfterStart
        {
            get { return _waitAfterStart; }
            set
            {
                // WaitAfterStart cannot be turned on when TryIntegrate is true
                if (TryIntegrate)
                    return;
                SetField(ref _waitAfterStart, value, nameof(WaitAfterStart));
            }
        }


        public string Arguments
        {
            get { return _arguments; }
            set { SetField(ref _arguments, value, nameof(Arguments)); }
        }

        public string WorkingDir
        {
            get { return _workingDir; }
            set { SetField(ref _workingDir, value, nameof(WorkingDir)); }
        }

        public bool TryIntegrate
        {
            get { return _tryIntegrate; }
            set
            {
                // WaitForExit cannot be turned on when TryIntegrate is true
                if (value)
                {
                    WaitForExit = false;
                    //WaitAfterStart = 0;
                }
                   
                SetField(ref _tryIntegrate, value, nameof(TryIntegrate));
            }
        }

        public bool ShowOnToolbar
        {
            get { return _showOnToolbar; }
            set { SetField(ref _showOnToolbar, value, nameof(ShowOnToolbar)); }
        }

        public bool RunElevated
        {
            get { return _runElevated; }
            set { SetField(ref _runElevated, value, nameof(RunElevated)); }
        }

        public ConnectionInfo ConnectionInfo { get; set; }
        
        public Icon Icon
        {
            get {
                if (File.Exists(this.FileName))
                {
                    return MiscTools.GetIconFromFile(this.FileName);
                }
                Icon icon = ConnectionIcon.FromString(Path.GetFileNameWithoutExtension(this.FileName));
                if (icon != null)
                {
                    return icon;
                }
                return Resources.mRemote_Icon;
            }
        }

        public Image Image
        {
            get { return Icon?.ToBitmap() ?? Resources.mRemote_Icon.ToBitmap(); }
        }

        #endregion
        
        public ExternalTool(string displayName = "", string fileName = "", string arguments = "", string workingDir = "", bool runElevated = false)
        {
            DisplayName = displayName;
            FileName = fileName;
            Arguments = arguments;
            WorkingDir = workingDir;
            RunElevated = runElevated;
        }

        public void Start(ConnectionInfo startConnectionInfo = null)
        {
            try
            {
                if (string.IsNullOrEmpty(FileName))
                {
                    Runtime.MessageCollector.AddMessage(MessageClass.ErrorMsg, "ExternalApp.Start() failed: FileName cannot be blank.");
                    return;
                }
                
                ConnectionInfo = startConnectionInfo;
                
                if (TryIntegrate)
                    StartIntegrated();
                else
                    StartExternalProcess();
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionMessage("ExternalApp.Start() failed.", ex);
            }
        }

        private void StartExternalProcess()
        {
            var process = new Process();
            SetProcessProperties(process, ConnectionInfo);
            process.Start();

            Console.WriteLine("WaitForExit:"+ WaitForExit+ " , WaitAfterStart:"+ WaitAfterStart);
            if (WaitForExit)  
            {
                process.WaitForExit();
                return;
            }

            //CBH
            //-1 时 表示等待退出，大于0 表示等待相应的时间
            if (WaitAfterStart == -1)  //等效于 WaitForExit=true
            {
                process.WaitForExit();
            }
            else if(WaitAfterStart > 0)
            {
                //await Task.Delay(WaitAfterStart);  //异步式  方法签名应该必须是 async Task 才有效
                Thread.Sleep(WaitAfterStart);  //阻塞式
            }
        }

        private void SetProcessProperties(Process process, ConnectionInfo startConnectionInfo)
        {
            var argParser = new ExternalToolArgumentParser(startConnectionInfo);
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = argParser.ParseArguments(FileName);
            process.StartInfo.Arguments = argParser.ParseArguments(Arguments);
            if (WorkingDir != "") process.StartInfo.WorkingDirectory = argParser.ParseArguments(WorkingDir);
            if (RunElevated) process.StartInfo.Verb = "runas";
        }

        private void StartIntegrated()
        {
            try
            {
                var newConnectionInfo = BuildConnectionInfoForIntegratedApp();
                _connectionInitiator.OpenConnection(newConnectionInfo);
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionMessage("ExternalApp.StartIntegrated() failed.", ex);
            }
        }

        private ConnectionInfo BuildConnectionInfoForIntegratedApp()
        {
            var newConnectionInfo = GetAppropriateInstanceOfConnectionInfo();
            SetConnectionInfoFields(newConnectionInfo);
            return newConnectionInfo;
        }

        private ConnectionInfo GetAppropriateInstanceOfConnectionInfo()
        {
            var newConnectionInfo = ConnectionInfo == null ? new ConnectionInfo() : ConnectionInfo.Clone();
            return newConnectionInfo;
        }

        private void SetConnectionInfoFields(ConnectionInfo newConnectionInfo)
        {
            newConnectionInfo.Protocol = ProtocolType.IntApp;
            newConnectionInfo.ExtApp = DisplayName;
            //newConnectionInfo.Name = DisplayName;  //CBH 修正 名字还应保持原名字，否则传递给外部工具的 %name% 会变为外部工具名
            newConnectionInfo.Panel = Language.strMenuExternalTools;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChangedEvent(object sender, string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            RaisePropertyChangedEvent(this, propertyName);
            return true;
        }
    }
}
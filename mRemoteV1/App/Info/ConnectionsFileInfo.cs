using System;
using System.IO;

namespace mRemoteNG.App.Info
{
	public static class ConnectionsFileInfo
    {
        public static readonly string DefaultConnectionsPath = Path.Combine(SettingsFileInfo.SettingsPath, "conf");
        public static readonly string DefaultConnectionsFile = "confCons.xml";
        //public static readonly string DefaultConnectionsFileNew = "confConsNew.xml";
        public static readonly double ConnectionFileVersion = 2.6;

        /// <summary>
        /// 把任意绝对路径 targetFullPath 转成相对于程序集目录的
        /// 相对路径（带 .. 的格式）；若无法相对化则原样返回。
        /// </summary>
        public static string MakeRelativeIfPossible(string targetFilePath)
        {
            if (string.IsNullOrWhiteSpace(targetFilePath))
                return targetFilePath;

            //var baseDir = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
            var baseDir = Path.GetFullPath(SettingsFileInfo.SettingsPath);
            if (!baseDir.EndsWith(Path.DirectorySeparatorChar.ToString()))
                baseDir = baseDir + Path.DirectorySeparatorChar;
            var targetPath = Path.GetFullPath(targetFilePath);

            //---Debug---
            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            //Console.WriteLine(baseDir);
            //Console.WriteLine(targetFilePath);
            //Console.WriteLine(targetPath);
            
            //string workDir = Environment.CurrentDirectory;
            //string workDir2 = Directory.GetCurrentDirectory();
            //string workDir3 = AppDomain.CurrentDomain.BaseDirectory;
            //string workDir4 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //Console.WriteLine(workDir);
            //Console.WriteLine(workDir2);
            //Console.WriteLine(workDir3);
            //Console.WriteLine(workDir4);
            //workDir - workDir4 结果打印：
            //D:\DEV\VisualStudioProjects\mRemoteNG\mRemoteV1\bin\Release Portable
            //D:\DEV\VisualStudioProjects\mRemoteNG\mRemoteV1\bin\Release Portable
            //D:\DEV\VisualStudioProjects\mRemoteNG\mRemoteV1\bin\Release Portable\
            //D:\DEV\VisualStudioProjects\mRemoteNG\mRemoteV1\bin\Release Portable
            //---Debug---

            if (targetPath.StartsWith(baseDir, StringComparison.OrdinalIgnoreCase))
            {
                //API方式：.NET Framework 4.7.1 以下没有 Path.GetRelativePath，可用 Uri 代替
                //string subPath = Path.GetRelativePath(baseDir, targetFullPath);

                //Uri 方式
                string subPath = new Uri(baseDir).MakeRelativeUri(new Uri(targetPath)).ToString().Replace('/', Path.DirectorySeparatorChar);
                Console.WriteLine(subPath);

                //截取方式：去掉相同前缀，再删掉可能多余的首个分隔符
                //string subPath2 = targetPath.Substring(baseDir.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                //Console.WriteLine(subPath2);

                return subPath;
            }

            return targetFilePath;

        }
    }
}
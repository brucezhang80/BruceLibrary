using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;
using Microsoft.Win32;
using System.Threading;

namespace BruceLibrary
{
    /// <summary>
    /// 应用程序相关操作类
    /// </summary>
    public class ProgrameUtility
    {
        #region 构造函数
        public readonly static ProgrameUtility Current = new ProgrameUtility();
        private ProgrameUtility()
        { }   
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取程序版本信息
        ///   "版本号：" + fvi.FileVersion + "\n" +
        ///   "主要版本号：" + fvi.FileMajorPart + "\n" +
        ///   "次要版本号：" + fvi.FileMinorPart + "\n" +
        ///   "内部版本号：" + fvi.FileBuildPart + "\n" +
        ///   "专用部件号：" + fvi.FilePrivatePart,
        /// </summary>
        /// <param name="FilePath">程序地址，默认值为当前程序地址</param>
        public FileVersionInfo GetVersionInfo(string FilePath = "")
        {
            //获取文件地址
            if (FilePath == "")
                FilePath = Application.ExecutablePath;
            //获取文件版本信息
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(FilePath);
            if (fvi != null)
                return fvi;
            else
                return null;
        }

        /// <summary>
        /// 设置应用程序开机启动
        /// </summary>
        /// <param name="started">是否开机启动</param>
        /// <param name="exeName">程序名称</param>
        /// <param name="path">程序路径</param>
        /// <returns>true: 设置成功 false:设置失败</returns>
        /// <example>SetProgrameRunWhenPCStart(true,"App","D:\\App.exe")</example>
        public bool SetProgrameRunWhenPCStart(bool started, string exeName, string path)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//打开注册表子项 
            if (key == null) key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            if (started == true)
            {
                try
                {
                    key.SetValue(exeName, path);//设置为开机启动 
                    key.Close();
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    key.DeleteValue(exeName);//取消开机启动 
                    key.Close();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        private static Mutex mutex = null;
        /// <summary>
        /// 只允许程序运行一次
        /// </summary>
        /// <param name="strSystemName">程序名称如：NotePad</param>
        /// <example>GlobalMutex("NotePad")</example>
        public void GlobalMutex(string strSystemName)
        {
            // 是否第一次创建mutex
            bool newMutexCreated = false;
            string mutexName = "Global\\" + strSystemName;//系统名称，Global为全局，表示即使通过通过虚拟桌面连接过来，也只是允许运行一次
            try
            {
                mutex = new Mutex(false, mutexName, out newMutexCreated);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Thread.Sleep(1000);
                Environment.Exit(1);
            }

            // 第一次创建mutex
            if (newMutexCreated)
            {
                //Console.WriteLine("程序已启动");
            }
            else
            {
                //MessageUtil.ShowTips("另一个窗口已在运行，不能重复运行。");
                Thread.Sleep(1000);
                Environment.Exit(1);//退出程序
            }
        } 
        #endregion

        #region 私有方法
        
        #endregion
    }
}

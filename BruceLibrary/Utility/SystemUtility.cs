using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace BruceLibrary
{
    /// <summary>
    /// 系统相关操作类
    /// </summary>
    public class SystemUtility
    {
        #region 构造函数
        private readonly static SystemUtility _instance = new SystemUtility();
        private SystemUtility()
        { }

        public SystemUtility Instance
        {
            get { return _instance; }
        }   
        #endregion

        #region 公有函数
        /// <summary>
        /// 获取CPU序列号
        /// </summary>
        /// <returns>CPU序列号</returns>
        public static string GetCPUSerialNumber()
        {

            string cpuSerialNo = string.Empty;
            ManagementClass managementClass = new ManagementClass("Win32_Processor");
            ManagementObjectCollection managementObjectCollection = managementClass.GetInstances();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                // 可能是有多个
                cpuSerialNo = managementObject.Properties["ProcessorId"].Value.ToString();
                break;
            }
            return cpuSerialNo;
        }

        /// <summary>
        /// 获取硬盘序列号
        /// </summary>
        /// <returns>硬盘序列号</returns>
        public string GetHddInfo()
        {
            ManagementClass mobj = new ManagementClass("Win32_PhysicalMedia");
            ManagementObjectCollection moc = mobj.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                return mo.Properties["SerialNumber"].Value.ToString();
            }
            return "";
        }
        #endregion

        #region 私有函数
        
        #endregion
    }
}

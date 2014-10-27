﻿/*****************************************************************
 * 创建人：布鲁斯张
 * 时  间：2014-10-17
 * 描  述：获取硬件相关信息工具类
 *        获取指定设备相关信息
 *****************************************************************/
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
    public class HardwareUtility
    {
        #region 属性
        /// <summary>
        /// 枚举win32 api
        /// </summary>
        public enum HardwareEnum
        {
            // 硬件
            Win32_Processor, // CPU 处理器
            Win32_PhysicalMemory, // 物理内存条
            Win32_Keyboard, // 键盘
            Win32_PointingDevice, // 点输入设备，包括鼠标。
            Win32_FloppyDrive, // 软盘驱动器
            Win32_DiskDrive, // 硬盘驱动器
            Win32_CDROMDrive, // 光盘驱动器
            Win32_BaseBoard, // 主板
            Win32_BIOS, // BIOS 芯片
            Win32_ParallelPort, // 并口
            Win32_SerialPort, // 串口
            Win32_SerialPortConfiguration, // 串口配置
            Win32_SoundDevice, // 多媒体设置，一般指声卡。
            Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
            Win32_USBController, // USB 控制器
            Win32_NetworkAdapter, // 网络适配器
            Win32_NetworkAdapterConfiguration, // 网络适配器设置
            Win32_Printer, // 打印机
            Win32_PrinterConfiguration, // 打印机设置
            Win32_PrintJob, // 打印机任务
            Win32_TCPIPPrinterPort, // 打印机端口
            Win32_POTSModem, // MODEM
            Win32_POTSModemToSerialPort, // MODEM 端口
            Win32_DesktopMonitor, // 显示器
            Win32_DisplayConfiguration, // 显卡
            Win32_DisplayControllerConfiguration, // 显卡设置
            Win32_VideoController, // 显卡细节。
            Win32_VideoSettings, // 显卡支持的显示模式。
            // 操作系统
            Win32_TimeZone, // 时区
            Win32_SystemDriver, // 驱动程序
            Win32_DiskPartition, // 磁盘分区
            Win32_LogicalDisk, // 逻辑磁盘
            Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
            Win32_LogicalMemoryConfiguration, // 逻辑内存配置
            Win32_PageFile, // 系统页文件信息
            Win32_PageFileSetting, // 页文件设置
            Win32_BootConfiguration, // 系统启动配置
            Win32_ComputerSystem, // 计算机信息简要
            Win32_OperatingSystem, // 操作系统信息
            Win32_StartupCommand, // 系统自动启动程序
            Win32_Service, // 系统安装的服务
            Win32_Group, // 系统管理组
            Win32_GroupUser, // 系统组帐号
            Win32_UserAccount, // 用户帐号
            Win32_Process, // 系统进程
            Win32_Thread, // 系统线程
            Win32_Share, // 共享
            Win32_NetworkClient, // 已安装的网络客户端
            Win32_NetworkProtocol, // 已安装的网络协议
            Win32_PnPEntity,//all device
        }
        //默认提供信息，其他信息可通过方法获取
        public string CpuID;
        public string MacAddress;
        public string DiskID;
        public string IpAddress;
        public string LoginUserName;
        public string ComputerName;
        public string SystemType;
        public string TotalPhysicalMemory; //单位：M
        #endregion

        #region 构造函数
        public readonly static HardwareUtility Current = new HardwareUtility();
        private HardwareUtility()
        { } 
        #endregion

        #region 公有函数
        /// <summary>
        /// 获取CPU序列号
        /// </summary>
        /// <returns>CPU序列号</returns>
        public string GetCPUSerialNumber()
        {

            string cpuSerialNo = string.Empty;
            var managementClass = new ManagementClass("Win32_Processor");
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
            var mobj = new ManagementClass("Win32_PhysicalMedia");
            ManagementObjectCollection moc = mobj.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                return mo.Properties["SerialNumber"].Value.ToString();
            }
            return "";
        }

        /// <summary>
        /// 通过WindowsAPI获取windows设备信息
        /// </summary>
        /// <param name="hardType">设备类型</param>
        /// <param name="propKey">设备相关属性</param>
        /// <returns></returns>
        /// <example>
        /// public int GetComNum()
        /// {
        ///     int comNum = -1;
        ///     string[] strArr = GetHarewareInfo(HardwareEnum.Win32_PnPEntity, "Name");
        ///     foreach (string s in strArr)
        ///     {
        ///         if (s.Length >= 23 && s.Contains("CH340"))
        ///         {
        ///             int start = s.IndexOf("(") + 3;
        ///             int end = s.IndexOf(")");
        ///             comNum = Convert.ToInt32(s.Substring(start + 1, end - start - 1));
        ///         }
        ///     }
        ///     return comNum;
        /// }
        /// </example>
        private string[] GetHarewareInfo(HardwareEnum hardType, string propKey)
        {
            List<string> strs = new List<string>();
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties[propKey].Value != null)
                        {
                            String str = hardInfo.Properties[propKey].Value.ToString();
                            strs.Add(str);
                        }

                    }
                }
                return strs.ToArray();
            }
            catch
            {
                return null;
            }
            finally
            {
                strs = null;
            }
        }
        #endregion

        #region 私有函数
        
        #endregion
    }
}

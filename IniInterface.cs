using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TFS_Helper
{
    /// <summary>
    /// INI读写辅助类
    /// </summary>
    public class IniInterface
    {
        private static string strIniFilename = "Setting.ini";
        private static string strIniFilePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + strIniFilename;

        /// <summary>
        /// 读INI文件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string strSection, string strKey)
        {
            try
            {
                StringBuilder sb = new StringBuilder(1024);
                WinAPI.GetPrivateProfileString(strSection, strKey, "", sb, 1024, strIniFilePath);
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetValue(string strSection, string strKey, string strValue)
        {
            try
            {
                WinAPI.WritePrivateProfileString(strSection, strKey, strValue, strIniFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

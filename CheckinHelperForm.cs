using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace TFS_Helper
{
    /// <summary>
    /// checkin代码使用窗口类
    /// </summary>
    public partial class CheckinHelperForm : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CheckinHelperForm()
        {
            InitializeComponent();

            InitControl();
            InitData();
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ok_button_Click(object sender, EventArgs e)
        {
            if (CodeCheck() == false)
            {
                return;
            }

            try
            {
                string strTemp = code_tfs_textBox.Text.Trim();
                IntPtr hHandle = MainForm.m_tagTFSWindowInfo.m_hContentCtrl;
                if (hHandle == IntPtr.Zero)
                {
                    MainForm.ErrorMessage("TFS注释控件句柄为空！");
                    return;
                }

                // 将生成的信息发送到TFS注释窗口
                StringBuilder strContent = new StringBuilder(4096);
                strContent.Append(strTemp);
                WinAPI.SendMessage(hHandle, WinAPI.WM_SETTEXT, strContent.Capacity, strContent);

                // 内容复制到粘贴板
                Clipboard.SetDataObject(strTemp);

                this.Close();
            }
            catch (System.Exception ex)
            {
                MainForm.ErrorMessage(ex.ToString());
            }
        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void code_type_comboBox_TextChanged(object sender, EventArgs e)
        {
            code_tfs_textBox.Text = GeneralCodeInfo();
        }

        private void code_info_textBox_TextChanged(object sender, EventArgs e)
        {
            code_tfs_textBox.Text = GeneralCodeInfo();
        }

        private void code_textBox_TextChanged(object sender, EventArgs e)
        {
            code_tfs_textBox.Text = GeneralCodeInfo();
        }

        private void code_type_comboBox_Enter(object sender, EventArgs e)
        {
            code_type_comboBox.SelectAll();
        }

        private void code_info_textBox_Enter(object sender, EventArgs e)
        {
            code_info_textBox.SelectAll();
        }

        private void code_textBox_Enter(object sender, EventArgs e)
        {
            code_textBox.SelectAll();
        }

        private void code_tfs_textBox_Enter(object sender, EventArgs e)
        {
            code_tfs_textBox.SelectAll();
        }

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        private void InitControl()
        {
            code_type_comboBox.SelectedIndex = 0;
            code_type_comboBox.Focus();
        }

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitData()
        {
            // 【需求:AAAA】BALABALABALABALA
            string strContent = MainForm.m_tagTFSWindowInfo.m_strContent;
            TFSRecord obj = TFSRecord.GetObjectFormString(strContent);
            if (obj != null)
            {
                // 将解析的结果赋值给控件
                code_type_comboBox.Text = obj.checkinObj.m_strType;
                code_info_textBox.Text = obj.checkinObj.m_strTypeInfo;
                code_textBox.Text = obj.checkinObj.m_strContent;

                // 根据解析信息更新数据
                GeneralCodeInfo();
            }
        }

        /// <summary>
        /// 生成提交代码的字符串信息
        /// </summary>
        /// <returns></returns>
        private string GeneralCodeInfo()
        {
            CheckinRecord obj = new CheckinRecord();
            obj.m_strType = code_type_comboBox.Text.Trim();
            obj.m_strTypeInfo = code_info_textBox.Text.Trim();
            obj.m_strContent = code_textBox.Text.Trim();

            string strRet = CheckinRecord.GetStringFormObject(obj);
            return strRet;
        }

        /// <summary>
        /// 输入内容检查
        /// </summary>
        /// <returns></returns>
        private bool CodeCheck()
        {
            if (code_info_textBox.Text.Trim() == "")
            {
                code_info_textBox.Focus();
                MainForm.WarningMessage("类型信息不能为空！");
                return false;
            }

            if (code_textBox.Text.Trim() == "")
            {
                code_textBox.Focus();
                MainForm.WarningMessage("说明不能为空！");
                return false;
            }

            return true;
        }
    }
}

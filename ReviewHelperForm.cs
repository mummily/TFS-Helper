using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;

namespace TFS_Helper
{
    /// <summary>
    /// Review信息处理类
    /// </summary>
    public partial class ReviewHelperForm : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ReviewHelperForm()
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
            // 内容检查
            if (ReviewCheck() == false)
            {
                return;
            }

            try
            {
                // 注释信息
                string strTemp = review_tfs_textBox.Text.Trim();
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // 信息添加到数据库
                DBRecord dbRecord = new DBRecord();
                dbRecord.m_iTfsID = MainForm.m_tagTFSWindowInfo.m_iID;
                dbRecord.m_strGroupName = MainForm.m_tagTFSWindowInfo.m_strGroupName;
                dbRecord.m_strCoder = MainForm.m_tagTFSWindowInfo.m_strCheckin;
                dbRecord.m_strCodeDate = MainForm.m_tagTFSWindowInfo.m_strCheckinDate;
                dbRecord.m_strReviewer = review_name_textBox.Text.Trim();
                dbRecord.m_strReviewDate = DateTime.Now.ToShortDateString();
                dbRecord.m_iReviewLine = int.Parse(review_line_textBox.Text);
                dbRecord.m_strContent = strTemp;
                DatabaseInterface.AddRecord(dbRecord);

                // 发送邮件
                if (review_mail_checkBox.CheckState == CheckState.Checked)
                {
                    SendMail();
                }

                // 设置Review标签
                string strTFSContent = MainForm.m_tagTFSWindowInfo.m_strContent;
                StringBuilder strContent = new StringBuilder(4096);
                strContent.Append(strTFSContent);
                if (strTFSContent.Length > 0 && strTFSContent[0] != '*')
                {
                    WinAPI.SendMessage(MainForm.m_tagTFSWindowInfo.m_hContentCtrl, WinAPI.WM_SETTEXT, strContent.Capacity, strContent);
                    WinAPI.SendMessage(MainForm.m_tagTFSWindowInfo.m_hContentCtrl, WinAPI.WM_CHAR, (IntPtr)'*', IntPtr.Zero);
                }

                this.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.Close();
            }
            catch (System.Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
                MainForm.ErrorMessage(ex.ToString());
            }
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void review_name_textBox_Enter(object sender, EventArgs e)
        {
            review_name_textBox.SelectAll();
        }

        private void review_name_textBox_TextChanged(object sender, EventArgs e)
        {
            review_tfs_textBox.Text = GeneralReviewInfo();
        }

        private void review_line_textBox_Enter(object sender, EventArgs e)
        {
            review_line_textBox.Select(0, review_line_textBox.Value.ToString().Length);
        }

        private void review_line_textBox_ValueChanged(object sender, EventArgs e)
        {
            review_tfs_textBox.Text = GeneralReviewInfo();
        }

        private void review_type_comboBox_Enter(object sender, EventArgs e)
        {
            review_type_comboBox.SelectAll();
        }

        private void review_level_comboBox_Enter(object sender, EventArgs e)
        {
            review_level_comboBox.SelectAll();
        }

        private void review_module_textBox_Enter(object sender, EventArgs e)
        {
            review_module_textBox.SelectAll();
        }

        private void review_position_textBox_Enter(object sender, EventArgs e)
        {
            review_position_textBox.SelectAll();
        }

        private void review_textBox_Enter(object sender, EventArgs e)
        {
            review_textBox.SelectAll();
        }

        private void review_tfs_textBox_Enter(object sender, EventArgs e)
        {
            review_tfs_textBox.SelectAll();
        }

        private void review_tfsid_textBox_Enter(object sender, EventArgs e)
        {
            review_tfsid_textBox.Select(0, review_tfsid_textBox.Value.ToString().Length);
        }

        private void review_mail_textBox_Enter(object sender, EventArgs e)
        {
            review_mail_textBox.SelectAll();
        }

        /// <summary>
        /// Review无问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void review_no_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            bool bFlag = review_no_checkBox.CheckState == CheckState.Unchecked;

            review_type_comboBox.Enabled = bFlag;
            review_level_comboBox.Enabled = bFlag;
            review_module_textBox.Enabled = bFlag;
            review_position_textBox.Enabled = bFlag;
            review_line_textBox.Enabled = bFlag;
            review_textBox.Enabled = bFlag;
            revier_add_button.Enabled = bFlag;
            revier_del_button.Enabled = bFlag;
            review_listBox.Enabled = bFlag;

            // 重新生成TFS注释信息
            review_tfs_textBox.Text = GeneralReviewInfo();
        }

        /// <summary>
        /// 发送Mail CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void review_mail_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            review_tfsid_textBox.Enabled = review_mail_checkBox.CheckState == CheckState.Checked;
            review_mail_textBox.Enabled = review_tfsid_textBox.Enabled;
        }

        /// <summary>
        /// 问题级别选择改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void review_level_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strLevel = review_level_comboBox.Text;
            List<string> types = MainForm.ReadQuestionType(strLevel);

            review_type_comboBox.Items.Clear();
            foreach (var item in types)
            {
                review_type_comboBox.Items.Add(item);
            }

            if (review_type_comboBox.Items.Count > 0)
            {
                review_type_comboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 添加问题按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void revier_add_button_Click(object sender, EventArgs e)
        {
            // 检查输入信息
            if ( review_module_textBox.Text == "")
            {
                review_module_textBox.Focus();
                MainForm.WarningMessage("问题模块内容不能为空!");
                return;
            }
            if (review_position_textBox.Text == "")
            {
                review_position_textBox.Focus();
                MainForm.WarningMessage("问题位置内容不能为空!");
                return;
            }
            if (review_textBox.Text == "")
            {
                review_textBox.Focus();
                MainForm.WarningMessage("问题说明内容不能为空!");
                return;
            }

            QuestionRecord obj = new QuestionRecord();
            obj.m_strType = review_type_comboBox.Text.Trim();
            obj.m_strLevel = review_level_comboBox.Text.Trim();
            obj.m_strStatus = "打开";
            obj.m_strModuleName = review_module_textBox.Text.Trim();
            obj.m_strLocation = review_position_textBox.Text.Trim();
            obj.m_strQDes = review_textBox.Text.Trim();
            obj.m_strADes = "请补充";
            string strQuestion = QuestionRecord.GetStringFormObject(obj);

            // 增加列表信息
            int iIdx = review_listBox.Items.Add(strQuestion);
            review_listBox.SelectedIndex = iIdx;

            // 更新TFS注释
            review_tfs_textBox.Text = GeneralReviewInfo();
        }

        /// <summary>
        /// 删除问题按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void revier_del_button_Click(object sender, EventArgs e)
        {
            // 删除列表信息
            if (review_listBox.SelectedIndex >= 0)
            {
                int iIdx = review_listBox.SelectedIndex;
                review_listBox.Items.RemoveAt(iIdx);

                if (review_listBox.Items.Count > iIdx)
                {
                    review_listBox.SelectedIndex = iIdx;
                }
                else if (review_listBox.Items.Count > 0)
                {
                    review_listBox.SelectedIndex = 0;
                }
            }

            // 更新TFS注释
            review_tfs_textBox.Text = GeneralReviewInfo();
        }

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        private void InitControl()
        {
            review_no_checkBox.CheckState = CheckState.Unchecked;
            review_mail_checkBox.CheckState = CheckState.Checked;
            review_tfsid_textBox.Enabled = true;
            review_mail_textBox.Enabled = true;
            review_name_textBox.Focus();
            review_listBox.BackColor = review_tfs_textBox.BackColor;
            review_listBox.Enabled = true;
        }

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitData()
        {
            review_name_textBox.Text = System.Environment.UserName;
            review_tfsid_textBox.Value = MainForm.m_tagTFSWindowInfo.m_iID;
            review_mail_textBox.Text = MainForm.m_tagTFSWindowInfo.m_strCheckin;
            review_tfs_textBox.Text = GeneralReviewInfo();

            // 填充问题级别
            List<string> levels = MainForm.ReadQuestionLevel();
            foreach (var item in levels)
            {
                review_level_comboBox.Items.Add(item);
            }
            if (review_level_comboBox.Items.Count > 0)
            {
                review_level_comboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 生成Review的字符串信息
        /// </summary>
        /// <returns></returns>
        private string GeneralReviewInfo()
        {
            // 注释信息可以往后面追加，不过存到数据库就不用存已有信息，只用显示处理Review的字符串信息
            string strRet = "";
            string strReviewer = review_name_textBox.Text.Trim();
            bool bFlag = review_no_checkBox.CheckState == CheckState.Checked;

            if (strReviewer == "")
            {
                return strRet;
            }

            ReviewRecord obj = new ReviewRecord();
            obj.m_strReviewer = review_name_textBox.Text.Trim();
            obj.m_strReviewDate = DateTime.Now.ToLongDateString().ToString();
            if (review_line_textBox.Text.Trim() == "")
            {
                obj.m_iReviewLine = 0;
            }
            else
            {
                obj.m_iReviewLine = int.Parse(review_line_textBox.Text);
            }
            obj.m_bResultFlag = bFlag;

            if (obj.m_bResultFlag == false)
            { // 有问题的场合记录问题
                for (int iIdx = 0; iIdx < review_listBox.Items.Count; ++iIdx)
                {
                    string strQuestion = review_listBox.Items[iIdx].ToString();
                    QuestionRecord objQuestion = QuestionRecord.GetObjectFormString(strQuestion);
                    obj.m_QuestionList.Add(objQuestion);
                }
            }

            if (strRet != "")
            {
                strRet += "\r\n";
            }
            strRet += ReviewRecord.GetStringFormObject(obj);
            return strRet;
        }

        /// <summary>
        /// 检查内容信息
        /// </summary>
        /// <returns></returns>
        private bool ReviewCheck()
        {
            // Review者不能为空
            string strTemp = review_name_textBox.Text.Trim();
            if (strTemp == "")
            {
                review_name_textBox.Focus();
                MainForm.WarningMessage("走查者不能为空！");
                return false;
            }

            if (review_line_textBox.Text == "")
            {
                review_line_textBox.Focus();
                MainForm.WarningMessage("走查行数不能为空!");
                return false;
            }

            // 问题列表不能为空
            if (review_listBox.Items.Count == 0 &&
                review_no_checkBox.CheckState == CheckState.Unchecked)
            {
                review_type_comboBox.Focus();
                MainForm.WarningMessage("走查问题不能为空！");
                return false;
            }

            // 发送邮件处理
            if (review_mail_checkBox.CheckState == CheckState.Checked)
            {
                // 变更集ID不能为空
                if (review_tfsid_textBox.Text.Trim() == "")
                {
                    review_tfsid_textBox.Focus();
                    MainForm.WarningMessage("变更集ID不能为空！");
                    return false;
                }

                // 邮箱地址是否为空
                if (review_mail_textBox.Text.Trim() == "")
                {
                    review_mail_textBox.Focus();
                    MainForm.WarningMessage("收件人地址不能为空！");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        private void SendMail()
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

                string strTo = review_mail_textBox.Text.Trim() + "@hollysys.net";
                string strTFSID = review_tfsid_textBox.Text.Trim();
                mailItem.To = strTo;
                mailItem.Subject = "变更集: " + strTFSID + " 走查结果通知邮件";
                mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;

                string strContent = review_tfs_textBox.Text;
                strContent = strContent.Replace("\r\n", "<br/>");
                strContent = "您好：<br/><br/>" + strContent + "<br/><br/>此邮件为TFS提交记录集Review自动邮件通知，不用回复！";
                mailItem.HTMLBody = strContent;

                ((Outlook._MailItem)mailItem).Send();

                mailItem = null;
                outlookApp = null;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}

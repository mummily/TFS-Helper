using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace TFS_Helper
{
    public partial class ModifyHelperForm : Form
    {
        /// <summary>
        /// 数据库记录ID
        /// </summary>
        private int m_id = 0;

        /// <summary>
        /// Review对象
        /// </summary>
        private ReviewRecord m_reviewObj = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ModifyHelperForm(int id, ReviewRecord reviewObj)
        {
            InitializeComponent();

            InitControl();

            this.m_id = id;
            this.m_reviewObj = reviewObj;
            if (this.m_reviewObj != null)
            {                
                InitData();
            }
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ok_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // 更新数据库信息
                string strReview = ReviewRecord.GetStringFormObject(m_reviewObj);
                DatabaseInterface.ModRecord(m_id, strReview);

                // 给走查者发送邮件
                if (mod_mail_checkBox.CheckState == CheckState.Checked)
                {
                    SendMail();
                }

                this.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.DialogResult = DialogResult.OK;
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Review问题记录选择改变时更新处理问题状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mod_question_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mod_question_listBox.SelectedItems.Count == 0)
            { // 无选择项目
                return;
            }

            string strQuestion = mod_question_listBox.SelectedItem.ToString();
            QuestionRecord questionObj = QuestionRecord.GetObjectFormString(strQuestion);

            bool bFlag = questionObj.m_strStatus == "打开";

            mod_type_comboBox.Text = questionObj.m_strType;
            mod_level_comboBox.Text = questionObj.m_strLevel;
            mod_module_textBox.Text = questionObj.m_strModuleName;
            mod_position_textBox.Text = questionObj.m_strLocation;
            mod_question_textBox.Text = questionObj.m_strQDes;
            mod_answer_textBox.Text = questionObj.m_strADes;
            mod_answer_textBox.Enabled = bFlag;
            mod_button.Enabled = bFlag;
            no_button.Enabled = bFlag;
        }

        /// <summary>
        /// 获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mod_answer_textBox_Enter(object sender, EventArgs e)
        {
            mod_answer_textBox.SelectAll();
        }

        /// <summary>
        /// 关闭问题按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mod_button_Click(object sender, EventArgs e)
        {
            // 信息检查
            string strTemp = mod_answer_textBox.Text.Trim();
            if (strTemp == "")
            {
                MainForm.WarningMessage("确认说明不能为空！");
                mod_answer_textBox.Focus();
                return;
            }

            // 获取对应的问题对象
            int iQuestionIdx = mod_question_listBox.SelectedIndex;
            QuestionRecord questionObj = m_reviewObj.m_QuestionList[iQuestionIdx];

            // 更改的问题信息
            questionObj.m_strStatus = "关闭";
            questionObj.m_strADes = mod_answer_textBox.Text.Trim();

            // 更新List显示
            strTemp = QuestionRecord.GetStringFormObject(questionObj);
            mod_question_listBox.Items.RemoveAt(iQuestionIdx);
            mod_question_listBox.Items.Insert(iQuestionIdx, strTemp);
            mod_question_listBox.SelectedIndex = iQuestionIdx;
        }

        /// <summary>
        /// 不是问题按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void no_button_Click(object sender, EventArgs e)
        {
            // 信息检查
            string strTemp = mod_answer_textBox.Text.Trim();
            if (strTemp == "")
            {
                MainForm.WarningMessage("确认说明不能为空！");
                mod_answer_textBox.Focus();
                return;
            }

            // 获取对应的问题对象
            int iQuestionIdx = mod_question_listBox.SelectedIndex;
            QuestionRecord questionObj = m_reviewObj.m_QuestionList[iQuestionIdx];

            // 更改的问题信息
            questionObj.m_strStatus = "不是问题";
            questionObj.m_strADes = mod_answer_textBox.Text.Trim();

            // 更新List显示
            strTemp = QuestionRecord.GetStringFormObject(questionObj);
            mod_question_listBox.Items.RemoveAt(iQuestionIdx);
            mod_question_listBox.Items.Insert(iQuestionIdx, strTemp);
            mod_question_listBox.SelectedIndex = iQuestionIdx;
        }

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        private void InitControl()
        {
            // 发送邮件默认选择
            mod_mail_checkBox.CheckState = CheckState.Checked;
        }

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitData()
        {
            int iCount = m_reviewObj.m_QuestionList.Count();
            for (int iIdx = 0; iIdx < iCount; ++iIdx)
            {
                QuestionRecord questionObj = m_reviewObj.m_QuestionList[iIdx];
                string strQuestion = QuestionRecord.GetStringFormObject(questionObj);
                mod_question_listBox.Items.Add(strQuestion);
            }

            // 默认选择第一个
            if (mod_question_listBox.Items.Count > 0)
            {
                mod_question_listBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 给走查者发送邮件
        /// </summary>
        private void SendMail()
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

                string strTo = m_reviewObj.m_strReviewer + "@hollysys.net";
                string strTFSID = m_reviewObj.m_strTFSId.ToString();
                mailItem.To = strTo;
                mailItem.Subject = "变更集: " + strTFSID + " 走查问题处理通知邮件";
                mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;

                string strContent = ReviewRecord.GetStringFormObject(m_reviewObj);
                strContent = strContent.Replace("\r\n", "<br/>");
                strContent = "您好：<br/><br/>" + strContent + "<br/><br/>此邮件为走查问题处理结果自动邮件通知，不用回复！";
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

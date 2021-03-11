using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace TFS_Helper
{
    public partial class TFSRecordForm : Form
    {
        /// <summary>
        /// 设置的默认分组信息
        /// </summary>
        public static string m_strGroupName = "";

        /// <summary>
        /// 构造函数
        /// </summary>
        public TFSRecordForm()
        {
            InitializeComponent();

            InitControl();
            InitData();
        }

        /// <summary>
        /// 保存检索条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TFSRecordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 提交和Review名称提供记忆功能
            string strCoder = this.search_code_textBox.Text.Trim();
            IniInterface.SetValue("Search", "Checkin", strCoder);
            string strReviewer = this.search_review_textBox.Text.Trim();
            IniInterface.SetValue("Search", "Reviewer", strReviewer);
        }

        /// <summary>
        /// 检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // 检索条件对象
                DBSearchCondition condition = new DBSearchCondition();
                if (search_id_numericUpDown.Text.Trim() != "")
                {
                    condition.m_iTfsId = int.Parse(search_id_numericUpDown.Text.Trim());
                }
                condition.m_strGroupName = search_group_comboBox.Text.Trim();
                condition.m_strCoder = search_code_textBox.Text.Trim();
                condition.m_strReviewer = search_review_textBox.Text.Trim();

                string strDate = search_start_dateTimePicker.Text.Trim();
                condition.m_strReviewDateStart = DateTime.Parse(strDate).ToShortDateString();
                strDate = search_end_dateTimePicker.Text.Trim();
                condition.m_strReviewDateEnd = DateTime.Parse(strDate).ToShortDateString();

                // 检索数据库信息
                MySqlDataReader reader = DatabaseInterface.SearchRecord(condition);
                if (reader.HasRows == false)
                {
                    this.record_listView.Items.Clear();
                    this.Cursor = System.Windows.Forms.Cursors.Arrow;
                    MainForm.WarningMessage("没有检索到数据！");
                    return;
                }

                // 填充List
                this.FillList(reader);
                reader.Close();

                this.Cursor = System.Windows.Forms.Cursors.Arrow;
            }
            catch (System.Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
                MainForm.ErrorMessage(ex.ToString());
            }
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void export_button_Click(object sender, EventArgs e)
        {
            if (this.record_listView.Items.Count == 0)
            {
                MainForm.WarningMessage("没有需要导出的记录信息！");
                return;
            }

            // 选择导出的路径
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
                ofd.ValidateNames = true;
                ofd.CheckPathExists = true;
                ofd.CheckFileExists = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = ofd.FileName;

                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    int iRet = ExportExcel(strFileName);
                    this.Cursor = System.Windows.Forms.Cursors.Arrow;

                    MainForm.WarningMessage(string.Format("共导出{0}条记录！", iRet));
                }
            }
            catch (System.Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
                string strMsg = string.Format("导出Excel出错，信息如下:{0}", ex.ToString());
                MainForm.ErrorMessage(strMsg);
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

        private void search_id_numericUpDown_Enter(object sender, EventArgs e)
        {
            search_id_numericUpDown.Select(0, search_id_numericUpDown.Value.ToString().Length);
        }

        private void search_code_textBox_Enter(object sender, EventArgs e)
        {
            search_code_textBox.SelectAll();
        }

        private void search_start_dateTimePicker_Enter(object sender, EventArgs e)
        {
        }

        private void search_end_dateTimePicker_Enter(object sender, EventArgs e)
        {
        }

        private void search_review_textBox_Enter(object sender, EventArgs e)
        {
            search_review_textBox.SelectAll();
        }

        /// <summary>
        /// 双击List处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void record_listView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = record_listView.SelectedItems[0];
                int id = int.Parse(item.SubItems[0].Text);
                string strReview = item.SubItems[8].Text;
                ReviewRecord reviewObj = ReviewRecord.GetObjectFormString(strReview);
                reviewObj.m_strTFSId = item.SubItems[1].Text;
                if (reviewObj == null)
                {
                    MainForm.ErrorMessage(string.Format("内容格式错误: {0}", strReview));
                    return;
                }
                if (reviewObj.m_QuestionList.Count == 0)
                {
                    MainForm.WarningMessage("没有要处理的走查问题！");
                    return;
                }

                // 显示对应问题窗口
                ModifyHelperForm form = new ModifyHelperForm(id, reviewObj);
                form.ShowDialog();
            }
            catch (System.Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
                MainForm.ErrorMessage(ex.ToString());
            }
        }

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        private void InitControl()
        {
            //单选时,选择整行
            this.record_listView.FullRowSelect = true;

            this.record_listView.Columns.Add("编号", 40, HorizontalAlignment.Center);
            this.record_listView.Columns.Add("变更集ID", 60, HorizontalAlignment.Center);
            this.record_listView.Columns.Add("资源组名", 70, HorizontalAlignment.Left);
            this.record_listView.Columns.Add("签入者", 100, HorizontalAlignment.Left);
            this.record_listView.Columns.Add("提交时间", 80, HorizontalAlignment.Left);
            this.record_listView.Columns.Add("走查者", 100, HorizontalAlignment.Left);
            this.record_listView.Columns.Add("走查时间", 80, HorizontalAlignment.Left);
            this.record_listView.Columns.Add("走查行数", 60, HorizontalAlignment.Left);
            this.record_listView.Columns.Add("走查内容", -2, HorizontalAlignment.Left);
        }

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitData()
        {
            // 检索条件部分
            this.search_id_numericUpDown.Text = "";

            // 资源组信息
            this.search_group_comboBox.Items.Add("");
            string[] groups = MainForm.ReadGroup();
            if (groups != null)
            {
                foreach (var item in groups)
                {
                    this.search_group_comboBox.Items.Add(item);
                }
                this.search_group_comboBox.Text = TFSRecordForm.m_strGroupName;
            }

            // 提交和Review名称提供记忆功能
            string strCoder = IniInterface.GetValue("Search", "Checkin").Trim();
            this.search_code_textBox.Text = strCoder;
            string strReviewer = IniInterface.GetValue("Search", "Reviewer").Trim();
            this.search_review_textBox.Text = strReviewer;

            // 清空List
            this.record_listView.Items.Clear();

            // 清空统计信息
            UpdateStatuesBar(0, 0, 0, 0);
        }

        /// <summary>
        /// 填充List数据
        /// </summary>
        /// <param name="reader"></param>
        private void FillList(MySqlDataReader reader)
        {
            try
            {
                // 清空List
                this.record_listView.Items.Clear();
                UpdateStatuesBar(0, 0, 0, 0);

                // 统计检索到的数据
                int iRecord = 0;
                int iCode = 0;
                int iQuestion = 0;
                int iNoQuestion = 0;

                // 填充Reader数据
                ListViewItem item = null;
                string strDate = "";
                while (reader.Read())
                {
                    item = new ListViewItem();
                    item.SubItems[0].Text = reader["id"].ToString();
                    item.SubItems.Add(reader["tfs_id"].ToString());
                    item.SubItems.Add(reader["group_name"].ToString());
                    item.SubItems.Add(reader["coder"].ToString());
                    strDate = reader["code_date"].ToString();
                    item.SubItems.Add(DateTime.Parse(strDate).Date.ToShortDateString());
                    item.SubItems.Add(reader["reviewer"].ToString());
                    strDate = reader["review_date"].ToString();
                    item.SubItems.Add(DateTime.Parse(strDate).Date.ToShortDateString());
                    item.SubItems.Add(reader["code_line"].ToString());
                    string strContent = reader["content"].ToString();
                    item.SubItems.Add(strContent);

                    // 统计总代码行数
                    iCode += int.Parse(reader["code_line"].ToString());

                    // 有没有关闭的问题，背景色设置为黄色
                    ReviewRecord reviewObj = ReviewRecord.GetObjectFormString(strContent);
                    if (reviewObj != null)
                    {
                        // 统计总问题数
                        iQuestion += reviewObj.m_QuestionList.Count;

                        for (int iIdx = 0; iIdx < reviewObj.m_QuestionList.Count; ++iIdx)
                        {
                            if (QuestionRecord.QuestionIsClose(reviewObj.m_QuestionList[iIdx]) == false)
                            {
                                item.BackColor = Color.Yellow;

                                // 统计未解决的问题数
                                iNoQuestion += 1;
                            }
                        }
                    }

                    this.record_listView.Items.Add(item);
                }

                // 总记录数
                iRecord = this.record_listView.Items.Count;

                // 更新状态栏显示
                UpdateStatuesBar(iRecord, iCode, iQuestion, iNoQuestion);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 导出Excel信息
        /// </summary>
        /// <param name="strExcelFile"></param>
        /// <returns></returns>
        private int ExportExcel(string strExcelFile)
        {
            int iRecordCount = 0;
            OleDbConnection connectObj = null;
            OleDbCommand commandObj = null;

            try
            {
                // 打开连接
                string strConnect = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + strExcelFile + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=0'";
                connectObj = new OleDbConnection(strConnect);
                connectObj.Open();

                // 导出到第一个Sheet
                DataTable sheetsName = connectObj.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                string strSheet = sheetsName.Rows[0][2].ToString();

                commandObj = connectObj.CreateCommand();
                int iItemCount = this.record_listView.Items.Count;
                for (int iIdx = 0; iIdx < iItemCount; ++iIdx)
                {
                    string strReview = this.record_listView.Items[iIdx].SubItems[8].Text.Trim();
                    ReviewRecord reviewObj = ReviewRecord.GetObjectFormString(strReview);
                    if (reviewObj == null)
                    {
                        continue;
                    }

                    int iReviewLine = reviewObj.m_iReviewLine;
                    reviewObj.m_strTFSId = this.record_listView.Items[iIdx].SubItems[1].Text.Trim();
                    reviewObj.m_strCoder = this.record_listView.Items[iIdx].SubItems[3].Text.Trim();
                    String strGroup = this.record_listView.Items[iIdx].SubItems[2].Text.Trim();
                    for (int jIdx = 0; jIdx < reviewObj.m_QuestionList.Count; ++jIdx)
                    {
                        QuestionRecord questionObj = reviewObj.m_QuestionList[jIdx];

                        // 对问题描述中的单引号进行转义，因为这个在随后执行ExecuteNonQuery会导致异常
                        string[] newStrs = Regex.Split(questionObj.m_strQDes, "'");
                        questionObj.m_strQDes = string.Join("''", newStrs);

                        string strSQL = string.Format("INSERT INTO [{0}] VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{12}')",
                            strSheet,
                            reviewObj.m_strReviewDate,         // 走查日期
                            questionObj.m_strModuleName,       // 模块名称
                            reviewObj.m_strTFSId,              // 变更集
                            iReviewLine,                       // 代码行数
                            strGroup,                          // 资源组
                            reviewObj.m_strReviewer,           // 走查者
                            reviewObj.m_strCoder,              // 作者
                            questionObj.m_strQDes,             // 问题描述
                            questionObj.m_strLocation,         // 位置
                            questionObj.m_strType,             // 问题类型
                            questionObj.m_strLevel,            // 问题级别
                            questionObj.m_strADes,             // 修改说明
                            questionObj.m_strStatus);          // 状态
                        
                        commandObj.CommandText = strSQL;
                        commandObj.ExecuteNonQuery();
                        iRecordCount += 1;

                        // 一个变更集的代码行数只在一个问题中体现，其他问题都填0，避免重复计算
                        iReviewLine = 0;
                    }
                }

                return iRecordCount;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (commandObj != null)
                {
                    commandObj.Dispose();
                    commandObj = null;
                }

                if (connectObj != null)
                {
                    connectObj.Close();
                    connectObj.Dispose();
                    connectObj = null;
                }
            }
        }

        /// <summary>
        /// 显示状态栏
        /// </summary>
        /// <param name="iRecord"></param>
        /// <param name="iCode"></param>
        /// <param name="iQuestion"></param>
        /// <param name="iNoQuestion"></param>
        private void UpdateStatuesBar(int iRecord, int iCode, int iQuestion, int iNoQuestion)
        {
            string strValue = "";

            strValue = string.Format("记录条数: {0}", iRecord);
            this.record_total1.Text = strValue;
            strValue = string.Format("代码行数: {0}", iCode);
            this.record_total2.Text = strValue;
            strValue = string.Format("总问题数: {0}", iQuestion);
            this.record_total3.Text = strValue;
            strValue = string.Format("未解决问题数: {0}", iNoQuestion);
            this.record_total4.Text = strValue;
        }
    }
}

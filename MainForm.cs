using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Generic;
using Microsoft.Win32;

namespace TFS_Helper
{
    public partial class MainForm : Form
    {
        // 界面类型定义
        enum FormType { None, Checkin, Review };

        // 用户自定义消息
        private static int MSG_SHOWDIALOG = 0x0400/*WM_USER*/ + 1;

        // 全局变量定义
        public static TFSWindowInfo m_tagTFSWindowInfo;
        private static int m_iControlIdx = 0;
        private static IntPtr m_hMainForm = IntPtr.Zero;
        private static WinAPI.HookProc m_KeyboardHookProcedure = null;
        private static int m_hHook = 0;
        private static FormType m_emFormType = FormType.None;
        private static string m_strCheckinHotKey = "";
        private static string m_strReviewHotKey = "";

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            MainForm.m_hMainForm = this.Handle;
            MainForm.m_tagTFSWindowInfo = new TFSWindowInfo();

            InitControl();
            InitData();
        }

        /// <summary>
        /// 消息提示窗口统一接口
        /// </summary>
        /// <param name="strMsg"></param>
        public static void WarningMessage(string strMsg)
        {
            MessageBox.Show(strMsg, "TFS助手", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 消息提示窗口统一接口
        /// </summary>
        /// <param name="strMsg"></param>
        public static void ErrorMessage(string strMsg)
        {
            MessageBox.Show(strMsg, "TFS助手", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 询问消息窗口统一接口
        /// </summary>
        /// <param name="strMsg"></param>
        public static DialogResult QuestionMessage(string strMsg)
        {
            return MessageBox.Show(strMsg, "TFS助手", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == MSG_SHOWDIALOG)
            { // 显示对话框
                Form helper = null;

                // 从界面获取最新的IP地址，并检查
                IPAddress ip;
                string strServer = this.db_ip_textBox.Text.Trim();
                if (IPAddress.TryParse(strServer, out ip) == false)
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;

                    this.db_ip_textBox.Focus();
                    this.db_ip_textBox.SelectAll();
                    MainForm.ErrorMessage("数据库服务器地址为空或者格式不正确！");
                    return;
                }

                MySqlSetting.m_strDataSource = strServer;
                MainForm.m_tagTFSWindowInfo.m_strGroupName = this.group_name_comboBox.Text.Trim();
                if (MainForm.m_emFormType == FormType.Checkin)
                {
                    if (MainForm.m_tagTFSWindowInfo.m_hContentCtrl == IntPtr.Zero)
                    {
                        return;
                    }

                    helper = new CheckinHelperForm();
                }
                else if (MainForm.m_emFormType == FormType.Review)
                {
                    if (MainForm.m_tagTFSWindowInfo.m_hContentCtrl == IntPtr.Zero ||
                        MainForm.m_tagTFSWindowInfo.m_hIDCtrl == IntPtr.Zero ||
                        MainForm.m_tagTFSWindowInfo.m_hCheckinCtrl == IntPtr.Zero ||
                        MainForm.m_tagTFSWindowInfo.m_hCheckinDateCtrl == IntPtr.Zero)
                    {
                        return;
                    }

                    helper = new ReviewHelperForm();
                }

                WinAPI.Rect rect = new WinAPI.Rect();
                WinAPI.GetWindowRect(helper.Handle, out rect);
                int x = (int)m.WParam - (rect.Right - rect.Left) / 2;
                int y = (int)m.LParam - (rect.Bottom - rect.Top) / 2;
                int cx = rect.Right - rect.Left;
                int cy = rect.Bottom - rect.Top;
                WinAPI.SetWindowPos(helper.Handle, IntPtr.Zero/*HWND_TOP*/, x, y, cx, cy, 0x0040/*SWP_SHOWWINDOW*/);

                helper.Show();
                WinAPI.SetActiveWindow(helper.Handle);
                WinAPI.SetForegroundWindow(helper.Handle);
            }
        }

        /// <summary>
        /// 大小改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 退出程序确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.QuestionMessage("确定要退出程序？") == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 窗口关闭时卸载钩子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // 保存配置文件
                IniInterface.SetValue("Database", "Server", this.db_ip_textBox.Text.Trim());
                IniInterface.SetValue("Group", "Name", this.group_name_comboBox.Text.Trim());
                IniInterface.SetValue("HotKey", "Checkin", this.key_checkin_textBox.Text.Trim());
                IniInterface.SetValue("HotKey", "Review", this.key_review_textBox.Text.Trim());
            }
            catch (System.Exception ex)
            {
            }

            // 卸载钩子
            if (m_hHook != 0)
            {
                WinAPI.UnhookWindowsHookEx(m_hHook);
                m_hHook = 0;
            }
        }

        /// <summary>
        /// 按键事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            string strKey = "";
            if (e.Alt)
            {
                strKey += strKey == "" ? "Alt" : "+Alt";
            }
            if (e.Control)
            {
                strKey += strKey == "" ? "Control" : "+Control";
            }
            if (e.Shift)
            {
                strKey += strKey == "" ? "Shift" : "+Shift";
            }

            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                strKey += strKey == "" ? e.KeyCode.ToString() : "+" + e.KeyCode.ToString();
            }
            else
            { // 没有按下字母键，其他都不算
                strKey = "";
            }

            if (this.ActiveControl == key_checkin_textBox)
            {
                key_checkin_textBox.Text = strKey;
                MainForm.m_strCheckinHotKey = strKey;

            }
            else if (this.ActiveControl == key_review_textBox)
            {
                key_review_textBox.Text = strKey;
                MainForm.m_strReviewHotKey = strKey;
            }
        }

        // 安装键盘钩子
        private void start_button_Click(object sender, EventArgs e)
        {
            if (m_hHook != 0)
            { // 钩子已经安装
                return;
            }

            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                m_KeyboardHookProcedure = new WinAPI.HookProc(MainForm.KeyboardHookProc);
                m_hHook = WinAPI.SetWindowsHookEx(13/*WH_KEYBOARD_L*/, m_KeyboardHookProcedure, WinAPI.GetModuleHandle(curModule.ModuleName), 0);
                if (m_hHook == 0)
                {
                    int iError = WinAPI.GetLastError();
                    string strMsg = "开始服务错误(错误码:" + iError.ToString() + ")！";
                    ErrorMessage(strMsg);
                    return;
                }

                // 启动成功
                stop_button.Enabled = true;
                start_button.Enabled = false;
                stop_button.Focus();
            }
        }

        // 卸载键盘钩子
        private void stop_button_Click(object sender, EventArgs e)
        {
            if (m_hHook != 0)
            {
                WinAPI.UnhookWindowsHookEx(m_hHook);
                m_hHook = 0;
            }

            // 停止成功
            stop_button.Enabled = false;
            start_button.Enabled = true;
            start_button.Focus();
        }

        /// <summary>
        /// 获得焦点全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void db_ip_textBox_Enter(object sender, EventArgs e)
        {
            db_ip_textBox.SelectAll();
        }

        /// <summary>
        /// 获得焦点全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void key_checkin_textBox_Enter(object sender, EventArgs e)
        {
            key_checkin_textBox.SelectAll();
        }

        /// <summary>
        /// 获得焦点全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void key_review_textBox_Enter(object sender, EventArgs e)
        {
            key_review_textBox.SelectAll();
        }

        // 任务栏图标处理，双击图标显示主对话框
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Review信息管理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void record_button_Click(object sender, EventArgs e)
        {
            // 检查服务器设置是否合法
            IPAddress ip;
            string strServer = this.db_ip_textBox.Text.Trim();
            if (IPAddress.TryParse(strServer, out ip) == false)
            {
                this.db_ip_textBox.Focus();
                this.db_ip_textBox.SelectAll();
                MainForm.ErrorMessage("数据库服务器地址为空或者格式不正确！");
                return;
            }

            MySqlSetting.m_strDataSource = strServer;
            TFSRecordForm.m_strGroupName = this.group_name_comboBox.Text;
            TFSRecordForm form = new TFSRecordForm();
            form.ShowDialog();
        }

        /// <summary>
        /// 开机自动运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autorun_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            string path = Application.ExecutablePath;
            RegistryKey rKey = Registry.LocalMachine;
            RegistryKey rSubKey = rKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");

            if (autorun_checkBox.CheckState == CheckState.Checked)
            {
                rSubKey.SetValue("JcShutdown", path);
            }
            else
            {
                rSubKey.DeleteValue("JcShutdown", false);
            }

            rSubKey.Close();
            rKey.Close();
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 第一次启动时，开始服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            WinAPI.SendMessage(this.start_button.Handle, WinAPI.BM_CLICK, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// 钩子处理函数
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private static int KeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (wParam.ToInt32() == WinAPI.WM_KEYDOWN)
            {
                WinAPI.KBDLLHOOKSTRUCT keyStruct = (WinAPI.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WinAPI.KBDLLHOOKSTRUCT));
                HotKey checkKey = new HotKey(MainForm.m_strCheckinHotKey);
                HotKey reviewKey = new HotKey(MainForm.m_strReviewHotKey);

                MainForm.m_emFormType = FormType.None;
                if (checkKey.m_bAlt == ((Control.ModifierKeys & Keys.Alt) == Keys.Alt) &&
                    checkKey.m_bCtrl == ((Control.ModifierKeys & Keys.Control) == Keys.Control) &&
                    checkKey.m_bShift == ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) &&
                    checkKey.m_iKey == keyStruct.vkCode)
                {
                    MainForm.m_emFormType = FormType.Checkin;
                }
                else if (reviewKey.m_bAlt == ((Control.ModifierKeys & Keys.Alt) == Keys.Alt) &&
                    reviewKey.m_bCtrl == ((Control.ModifierKeys & Keys.Control) == Keys.Control) &&
                    reviewKey.m_bShift == ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) &&
                    reviewKey.m_iKey == keyStruct.vkCode)
                {
                    MainForm.m_emFormType = FormType.Review;
                }

                if (MainForm.m_emFormType != FormType.None)
                {
                    ThreadStart threadStart = new ThreadStart(KeyboardThreadProc);
                    Thread thread = new Thread(threadStart);
                    thread.Start();
                }
            }

            return WinAPI.CallNextHookEx(m_hHook, nCode, wParam, lParam);
        }

        /// <summary>
        /// 按键处理线程函数
        /// </summary>
        private static void KeyboardThreadProc()
        {
            IntPtr hWnd = WinAPI.GetForegroundWindow();
            if (hWnd == IntPtr.Zero)
            {
                return;
            }

            // 获取窗口Title
            var strTitle = new StringBuilder(1024);
            WinAPI.GetWindowText(hWnd, strTitle, strTitle.Capacity);

            string strPatternCheckIn = @"签入 - 源文件";
            string strPatternReview = @".+号变更集的详细信息 - 源文件";
            MatchCollection collCheckIn = Regex.Matches(strTitle.ToString(), strPatternCheckIn);
            MatchCollection collReview = Regex.Matches(strTitle.ToString(), strPatternReview);
            if ((collCheckIn.Count != 0 || collReview.Count != 0) &&
                MainForm.m_hMainForm != IntPtr.Zero)
            {
                if (collCheckIn.Count != 0 &&
                    MainForm.m_emFormType == FormType.Review)
                { // 签入窗口不能打开Review画面
                    return;
                }
                if (collReview.Count != 0 &&
                    MainForm.m_emFormType == FormType.Checkin)
                { // Review窗口不能打开签入画面
                    return;
                }

                // TFS窗口信息解析
                int iFlag = collCheckIn.Count;
                MainForm.m_iControlIdx = 0;
                WinAPI.CallBack callBackEnumChildWindows = new WinAPI.CallBack(ChildWindowProcess);
                WinAPI.EnumChildWindows(hWnd, callBackEnumChildWindows, iFlag);

                // 计算位置，准备显示对话框
                WinAPI.Rect rect = new WinAPI.Rect();
                WinAPI.GetWindowRect(hWnd, out rect);
                IntPtr x = (IntPtr)(rect.Left + (rect.Right - rect.Left) / 2);
                IntPtr y = (IntPtr)(rect.Top + (rect.Bottom - rect.Top) / 2);

                // 发送消息，由主界面显示对话框
                WinAPI.PostMessage(MainForm.m_hMainForm, MSG_SHOWDIALOG, x, y);
            }
        }

        /// <summary>
        /// 枚举窗口找子控件，并记录对应的信息
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private static bool ChildWindowProcess(IntPtr hWnd, int lParam)
        {
            StringBuilder strTitle = new StringBuilder(4096);
            WinAPI.SendMessage(hWnd, WinAPI.WM_GETTEXT, strTitle.Capacity, strTitle);

            StringBuilder strClass = new StringBuilder(1024);
            WinAPI.GetClassName(hWnd, strClass, strClass.Capacity);
            if (strClass.ToString().IndexOf("EDIT") < 0)
            { // 非EDIT控件不处理
                return true;
            }

            if (lParam > 0)
            { // 签入的界面遍历第四个是注释信息，其他的不处理
                if (MainForm.m_iControlIdx == 0)
                {
                    MainForm.m_tagTFSWindowInfo.m_hIDCtrl = IntPtr.Zero;
                    MainForm.m_tagTFSWindowInfo.m_iID = -1;
                    MainForm.m_tagTFSWindowInfo.m_hCheckinCtrl = IntPtr.Zero;
                    MainForm.m_tagTFSWindowInfo.m_strCheckin = "";
                    MainForm.m_tagTFSWindowInfo.m_hCheckinDateCtrl = IntPtr.Zero;
                    MainForm.m_tagTFSWindowInfo.m_strCheckinDate = "";

                    MainForm.m_tagTFSWindowInfo.m_hContentCtrl = hWnd;
                    MainForm.m_tagTFSWindowInfo.m_strContent = strTitle.ToString();
                }

                MainForm.m_iControlIdx += 1;
            }
            else
            { // Review的界面遍历顺序如下
                if (MainForm.m_iControlIdx == 0)
                {
                    MainForm.m_tagTFSWindowInfo.m_hContentCtrl = hWnd;
                    MainForm.m_tagTFSWindowInfo.m_strContent = strTitle.ToString();
                }
                else if (MainForm.m_iControlIdx == 1)
                {
                    MainForm.m_tagTFSWindowInfo.m_hCheckinDateCtrl = hWnd;
                    MainForm.m_tagTFSWindowInfo.m_strCheckinDate = DateTime.Parse(strTitle.ToString()).Date.ToShortDateString();
                }
                else if (MainForm.m_iControlIdx == 2)
                {
                    MainForm.m_tagTFSWindowInfo.m_hIDCtrl = hWnd;
                    MainForm.m_tagTFSWindowInfo.m_iID = int.Parse(strTitle.ToString());
                }
                else if (MainForm.m_iControlIdx == 3)
                {
                    MainForm.m_tagTFSWindowInfo.m_hCheckinCtrl = hWnd;
                    // 有的TFS此处包括 域号，所以要处理拆分处理下
                    // 第一种 zhaoliping，不用处理
                    // 第二种 Hollysys\zhaoliping，只保留zhaoliping
                    string strChecker = strTitle.ToString().Trim();
                    string[] sArray = strChecker.Split('\\');
                    if (sArray.Length == 2)
                    {
                        strChecker = sArray[1];
                    }
                    else
                    {
                        strChecker = sArray[0];
                    }
                    MainForm.m_tagTFSWindowInfo.m_strCheckin = strChecker;
                }

                MainForm.m_iControlIdx += 1;
            }

            return true;
        }

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        private void InitControl()
        {
            start_button.Enabled = true;
            stop_button.Enabled = false;
            autorun_checkBox.CheckState = CheckState.Checked;

            start_button.Focus();
        }

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitData()
        {
            try
            {
                // 加载数据库信息
                string strServer = IniInterface.GetValue("Database", "Server").Trim();
                this.db_ip_textBox.Text = strServer;

                // 加载资源组信息
                string strGroups = IniInterface.GetValue("Group", "Names").Trim();
                string[] groups = Regex.Split(strGroups, ",");
                group_name_comboBox.Items.Clear();
                foreach (var item in groups)
                {
                    group_name_comboBox.Items.Add(item);
                }

                // 当前资源组
                string strGroup = IniInterface.GetValue("Group", "Name").Trim();
                if (strGroup != "")
                {
                    group_name_comboBox.Text = strGroup;
                }
                else
                {
                    group_name_comboBox.SelectedIndex = 0;
                }

                // 读取快捷键信息
                string strCheckinKey = IniInterface.GetValue("HotKey", "Checkin").Trim();
                key_checkin_textBox.Text = strCheckinKey;
                MainForm.m_strCheckinHotKey = strCheckinKey;
                string strReviewKey = IniInterface.GetValue("HotKey", "Review").Trim();
                key_review_textBox.Text = strReviewKey;
                MainForm.m_strReviewHotKey = strReviewKey;
            }
            catch (System.Exception ex)
            {
                this.db_ip_textBox.Text = "";
            }
        }

        /// <summary>
        /// 读取配置文件的组信息
        /// </summary>
        /// <returns></returns>
        public static string[] ReadGroup()
        {
            string strGroups = IniInterface.GetValue("Group", "Names");
            return Regex.Split(strGroups, ",", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 读取问题的级别信息
        /// </summary>
        /// <returns></returns>
        public static List<string> ReadQuestionLevel()
        {
            List<string> retList = new List<string>();

            int iCount = int.Parse(IniInterface.GetValue("Question", "Count"));
            for (int iIdx = 1; iIdx <= iCount; ++iIdx)
            {
                string strKey = string.Format("Level_{0}", iIdx);
                string strValue = IniInterface.GetValue("Question", strKey);
                retList.Add(strValue);
            }

            return retList;
        }

        /// <summary>
        /// 读取问题指定级别对应的类型信息
        /// </summary>
        /// <returns></returns>
        public static List<string> ReadQuestionType(string strLevel)
        {
            List<string> retList = new List<string>();

            int iCount = int.Parse(IniInterface.GetValue("Question", "Count"));
            for (int iIdx = 1; iIdx <= iCount; ++iIdx)
            {
                string strKey = string.Format("Level_{0}", iIdx);
                string strValue = IniInterface.GetValue("Question", strKey);
                if (strValue == strLevel)
                {
                    strKey = string.Format("Type_{0}", iIdx);
                    strValue = IniInterface.GetValue("Question", strKey);

                    string[] types = Regex.Split(strValue, ",", RegexOptions.IgnoreCase);
                    foreach (var item in types)
                    {
                        retList.Add(item);
                    }

                    break;
                }
            }

            return retList;
        }
    }

    /// <summary>
    /// 按键信息结构体
    /// </summary>
    public class HotKey
    {
        /// <summary>
        /// Alt键是否按下
        /// </summary>
        public bool m_bAlt;

        /// <summary>
        /// Ctrl键是否按下
        /// </summary>
        public bool m_bCtrl;

        /// <summary>
        /// Shift键是否按下
        /// </summary>
        public bool m_bShift;

        /// <summary>
        /// 字母键
        /// </summary>
        public int m_iKey;

        public HotKey(string strKey)
        {
            m_bAlt = false;
            m_bCtrl = false;
            m_bShift = false;
            m_iKey = -1;

            // 参数判断
            if (strKey.Trim() == "")
            {
                return;
            }

            // 解析参数
            string[] keys = strKey.Split('+');
            foreach (var item in keys)
            {
                if (item == "Alt")
                {
                    m_bAlt = true;
                }
                else if (item == "Control")
                {
                    m_bCtrl = true;
                }
                else if (item == "Shift")
                {
                    m_bShift = true;
                }
                else
                {
                    m_iKey = (int)item[0];
                }

            }
        }
    }
}

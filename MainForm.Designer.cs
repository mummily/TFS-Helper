namespace TFS_Helper
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.start_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.service_groupBox = new System.Windows.Forms.GroupBox();
            this.db_groupBox = new System.Windows.Forms.GroupBox();
            this.db_ip_textBox = new System.Windows.Forms.TextBox();
            this.db_ip_label = new System.Windows.Forms.Label();
            this.exit_button = new System.Windows.Forms.Button();
            this.record_button = new System.Windows.Forms.Button();
            this.group_groupBox = new System.Windows.Forms.GroupBox();
            this.group_name_comboBox = new System.Windows.Forms.ComboBox();
            this.group_name_label = new System.Windows.Forms.Label();
            this.key_groupBox = new System.Windows.Forms.GroupBox();
            this.key_review_label = new System.Windows.Forms.Label();
            this.key_checkin_label = new System.Windows.Forms.Label();
            this.key_review_textBox = new System.Windows.Forms.TextBox();
            this.key_checkin_textBox = new System.Windows.Forms.TextBox();
            this.autorun_checkBox = new System.Windows.Forms.CheckBox();
            this.service_groupBox.SuspendLayout();
            this.db_groupBox.SuspendLayout();
            this.group_groupBox.SuspendLayout();
            this.key_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(11, 23);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(80, 25);
            this.start_button.TabIndex = 1;
            this.start_button.Text = "开始";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(97, 23);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(80, 25);
            this.stop_button.TabIndex = 2;
            this.stop_button.Text = "停止";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // service_groupBox
            // 
            this.service_groupBox.Controls.Add(this.start_button);
            this.service_groupBox.Controls.Add(this.stop_button);
            this.service_groupBox.Location = new System.Drawing.Point(12, 10);
            this.service_groupBox.Name = "service_groupBox";
            this.service_groupBox.Size = new System.Drawing.Size(386, 60);
            this.service_groupBox.TabIndex = 0;
            this.service_groupBox.TabStop = false;
            this.service_groupBox.Text = "服务控制";
            // 
            // db_groupBox
            // 
            this.db_groupBox.Controls.Add(this.db_ip_textBox);
            this.db_groupBox.Controls.Add(this.db_ip_label);
            this.db_groupBox.Location = new System.Drawing.Point(12, 79);
            this.db_groupBox.Name = "db_groupBox";
            this.db_groupBox.Size = new System.Drawing.Size(188, 56);
            this.db_groupBox.TabIndex = 3;
            this.db_groupBox.TabStop = false;
            this.db_groupBox.Text = "数据库设置";
            // 
            // db_ip_textBox
            // 
            this.db_ip_textBox.Location = new System.Drawing.Point(67, 20);
            this.db_ip_textBox.Name = "db_ip_textBox";
            this.db_ip_textBox.Size = new System.Drawing.Size(108, 21);
            this.db_ip_textBox.TabIndex = 4;
            this.db_ip_textBox.Enter += new System.EventHandler(this.db_ip_textBox_Enter);
            // 
            // db_ip_label
            // 
            this.db_ip_label.AutoSize = true;
            this.db_ip_label.Location = new System.Drawing.Point(12, 23);
            this.db_ip_label.Name = "db_ip_label";
            this.db_ip_label.Size = new System.Drawing.Size(53, 12);
            this.db_ip_label.TabIndex = 0;
            this.db_ip_label.Text = "服务器IP";
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(316, 274);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(80, 25);
            this.exit_button.TabIndex = 12;
            this.exit_button.Text = "退出";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // record_button
            // 
            this.record_button.Location = new System.Drawing.Point(9, 231);
            this.record_button.Name = "record_button";
            this.record_button.Size = new System.Drawing.Size(105, 25);
            this.record_button.TabIndex = 10;
            this.record_button.Text = "走查信息管理";
            this.record_button.UseVisualStyleBackColor = true;
            this.record_button.Click += new System.EventHandler(this.record_button_Click);
            // 
            // group_groupBox
            // 
            this.group_groupBox.Controls.Add(this.group_name_comboBox);
            this.group_groupBox.Controls.Add(this.group_name_label);
            this.group_groupBox.Location = new System.Drawing.Point(208, 79);
            this.group_groupBox.Name = "group_groupBox";
            this.group_groupBox.Size = new System.Drawing.Size(190, 56);
            this.group_groupBox.TabIndex = 5;
            this.group_groupBox.TabStop = false;
            this.group_groupBox.Text = "资源组设置";
            // 
            // group_name_comboBox
            // 
            this.group_name_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.group_name_comboBox.FormattingEnabled = true;
            this.group_name_comboBox.Location = new System.Drawing.Point(59, 20);
            this.group_name_comboBox.Name = "group_name_comboBox";
            this.group_name_comboBox.Size = new System.Drawing.Size(117, 20);
            this.group_name_comboBox.TabIndex = 6;
            // 
            // group_name_label
            // 
            this.group_name_label.AutoSize = true;
            this.group_name_label.Location = new System.Drawing.Point(12, 23);
            this.group_name_label.Name = "group_name_label";
            this.group_name_label.Size = new System.Drawing.Size(41, 12);
            this.group_name_label.TabIndex = 0;
            this.group_name_label.Text = "资源组";
            // 
            // key_groupBox
            // 
            this.key_groupBox.Controls.Add(this.key_review_label);
            this.key_groupBox.Controls.Add(this.key_checkin_label);
            this.key_groupBox.Controls.Add(this.key_review_textBox);
            this.key_groupBox.Controls.Add(this.key_checkin_textBox);
            this.key_groupBox.Location = new System.Drawing.Point(12, 141);
            this.key_groupBox.Name = "key_groupBox";
            this.key_groupBox.Size = new System.Drawing.Size(386, 84);
            this.key_groupBox.TabIndex = 7;
            this.key_groupBox.TabStop = false;
            this.key_groupBox.Text = "快捷键设置（单击对应输入框，按下需要设置的键）";
            // 
            // key_review_label
            // 
            this.key_review_label.AutoSize = true;
            this.key_review_label.Location = new System.Drawing.Point(11, 52);
            this.key_review_label.Name = "key_review_label";
            this.key_review_label.Size = new System.Drawing.Size(53, 12);
            this.key_review_label.TabIndex = 2;
            this.key_review_label.Text = "走查热键";
            // 
            // key_checkin_label
            // 
            this.key_checkin_label.AutoSize = true;
            this.key_checkin_label.Location = new System.Drawing.Point(11, 26);
            this.key_checkin_label.Name = "key_checkin_label";
            this.key_checkin_label.Size = new System.Drawing.Size(53, 12);
            this.key_checkin_label.TabIndex = 2;
            this.key_checkin_label.Text = "提交热键";
            // 
            // key_review_textBox
            // 
            this.key_review_textBox.Location = new System.Drawing.Point(70, 49);
            this.key_review_textBox.Name = "key_review_textBox";
            this.key_review_textBox.ReadOnly = true;
            this.key_review_textBox.Size = new System.Drawing.Size(303, 21);
            this.key_review_textBox.TabIndex = 9;
            this.key_review_textBox.Enter += new System.EventHandler(this.key_review_textBox_Enter);
            // 
            // key_checkin_textBox
            // 
            this.key_checkin_textBox.Location = new System.Drawing.Point(70, 23);
            this.key_checkin_textBox.Name = "key_checkin_textBox";
            this.key_checkin_textBox.ReadOnly = true;
            this.key_checkin_textBox.Size = new System.Drawing.Size(303, 21);
            this.key_checkin_textBox.TabIndex = 8;
            this.key_checkin_textBox.Enter += new System.EventHandler(this.key_checkin_textBox_Enter);
            // 
            // autorun_checkBox
            // 
            this.autorun_checkBox.AutoSize = true;
            this.autorun_checkBox.Location = new System.Drawing.Point(9, 279);
            this.autorun_checkBox.Name = "autorun_checkBox";
            this.autorun_checkBox.Size = new System.Drawing.Size(96, 16);
            this.autorun_checkBox.TabIndex = 11;
            this.autorun_checkBox.Text = "开机自动运行";
            this.autorun_checkBox.UseVisualStyleBackColor = true;
            this.autorun_checkBox.CheckedChanged += new System.EventHandler(this.autorun_checkBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 311);
            this.Controls.Add(this.autorun_checkBox);
            this.Controls.Add(this.key_groupBox);
            this.Controls.Add(this.group_groupBox);
            this.Controls.Add(this.record_button);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.db_groupBox);
            this.Controls.Add(this.service_groupBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TFS助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.service_groupBox.ResumeLayout(false);
            this.db_groupBox.ResumeLayout(false);
            this.db_groupBox.PerformLayout();
            this.group_groupBox.ResumeLayout(false);
            this.group_groupBox.PerformLayout();
            this.key_groupBox.ResumeLayout(false);
            this.key_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox service_groupBox;
        private System.Windows.Forms.GroupBox db_groupBox;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Label db_ip_label;
        private System.Windows.Forms.TextBox db_ip_textBox;
        private System.Windows.Forms.Button record_button;
        private System.Windows.Forms.GroupBox group_groupBox;
        private System.Windows.Forms.Label group_name_label;
        private System.Windows.Forms.ComboBox group_name_comboBox;
        private System.Windows.Forms.GroupBox key_groupBox;
        private System.Windows.Forms.TextBox key_review_textBox;
        private System.Windows.Forms.TextBox key_checkin_textBox;
        private System.Windows.Forms.Label key_checkin_label;
        private System.Windows.Forms.Label key_review_label;
        private System.Windows.Forms.CheckBox autorun_checkBox;
    }
}


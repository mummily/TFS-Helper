namespace TFS_Helper
{
    partial class ReviewHelperForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReviewHelperForm));
            this.exit_button = new System.Windows.Forms.Button();
            this.review_groupBox = new System.Windows.Forms.GroupBox();
            this.revier_del_button = new System.Windows.Forms.Button();
            this.revier_add_button = new System.Windows.Forms.Button();
            this.review_listBox = new System.Windows.Forms.ListBox();
            this.review_textBox = new System.Windows.Forms.TextBox();
            this.review_label = new System.Windows.Forms.Label();
            this.review_position_textBox = new System.Windows.Forms.TextBox();
            this.review_module_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.review_module_label = new System.Windows.Forms.Label();
            this.review_level_label = new System.Windows.Forms.Label();
            this.review_type_label = new System.Windows.Forms.Label();
            this.review_level_comboBox = new System.Windows.Forms.ComboBox();
            this.review_type_comboBox = new System.Windows.Forms.ComboBox();
            this.review_line_textBox = new System.Windows.Forms.NumericUpDown();
            this.revier_line_label = new System.Windows.Forms.Label();
            this.review_tfs_textBox = new System.Windows.Forms.TextBox();
            this.review_tfs_label = new System.Windows.Forms.Label();
            this.review_name_textBox = new System.Windows.Forms.TextBox();
            this.review_name_label = new System.Windows.Forms.Label();
            this.review_mail_groupBox = new System.Windows.Forms.GroupBox();
            this.review_tfsid_textBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.review_mail_label = new System.Windows.Forms.Label();
            this.review_mail_checkBox = new System.Windows.Forms.CheckBox();
            this.review_mail_label2 = new System.Windows.Forms.Label();
            this.review_mail_textBox = new System.Windows.Forms.TextBox();
            this.review_no_checkBox = new System.Windows.Forms.CheckBox();
            this.ok_button = new System.Windows.Forms.Button();
            this.review_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.review_line_textBox)).BeginInit();
            this.review_mail_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.review_tfsid_textBox)).BeginInit();
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(526, 551);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(80, 25);
            this.exit_button.TabIndex = 18;
            this.exit_button.Text = "取消";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // review_groupBox
            // 
            this.review_groupBox.Controls.Add(this.revier_del_button);
            this.review_groupBox.Controls.Add(this.revier_add_button);
            this.review_groupBox.Controls.Add(this.review_listBox);
            this.review_groupBox.Controls.Add(this.review_textBox);
            this.review_groupBox.Controls.Add(this.review_label);
            this.review_groupBox.Controls.Add(this.review_position_textBox);
            this.review_groupBox.Controls.Add(this.review_module_textBox);
            this.review_groupBox.Controls.Add(this.label2);
            this.review_groupBox.Controls.Add(this.review_module_label);
            this.review_groupBox.Controls.Add(this.review_level_label);
            this.review_groupBox.Controls.Add(this.review_type_label);
            this.review_groupBox.Controls.Add(this.review_level_comboBox);
            this.review_groupBox.Controls.Add(this.review_type_comboBox);
            this.review_groupBox.Location = new System.Drawing.Point(8, 42);
            this.review_groupBox.Name = "review_groupBox";
            this.review_groupBox.Size = new System.Drawing.Size(598, 248);
            this.review_groupBox.TabIndex = 3;
            this.review_groupBox.TabStop = false;
            this.review_groupBox.Text = "走查问题";
            // 
            // revier_del_button
            // 
            this.revier_del_button.Location = new System.Drawing.Point(126, 121);
            this.revier_del_button.Name = "revier_del_button";
            this.revier_del_button.Size = new System.Drawing.Size(60, 21);
            this.revier_del_button.TabIndex = 10;
            this.revier_del_button.Text = "删除";
            this.revier_del_button.UseVisualStyleBackColor = true;
            this.revier_del_button.Click += new System.EventHandler(this.revier_del_button_Click);
            // 
            // revier_add_button
            // 
            this.revier_add_button.Location = new System.Drawing.Point(60, 121);
            this.revier_add_button.Name = "revier_add_button";
            this.revier_add_button.Size = new System.Drawing.Size(60, 21);
            this.revier_add_button.TabIndex = 9;
            this.revier_add_button.Text = "添加";
            this.revier_add_button.UseVisualStyleBackColor = true;
            this.revier_add_button.Click += new System.EventHandler(this.revier_add_button_Click);
            // 
            // review_listBox
            // 
            this.review_listBox.Enabled = false;
            this.review_listBox.FormattingEnabled = true;
            this.review_listBox.HorizontalScrollbar = true;
            this.review_listBox.ItemHeight = 12;
            this.review_listBox.Location = new System.Drawing.Point(59, 147);
            this.review_listBox.Name = "review_listBox";
            this.review_listBox.ScrollAlwaysVisible = true;
            this.review_listBox.Size = new System.Drawing.Size(526, 88);
            this.review_listBox.TabIndex = 11;
            // 
            // review_textBox
            // 
            this.review_textBox.Location = new System.Drawing.Point(61, 72);
            this.review_textBox.Multiline = true;
            this.review_textBox.Name = "review_textBox";
            this.review_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.review_textBox.Size = new System.Drawing.Size(525, 45);
            this.review_textBox.TabIndex = 8;
            this.review_textBox.Enter += new System.EventHandler(this.review_textBox_Enter);
            // 
            // review_label
            // 
            this.review_label.AutoSize = true;
            this.review_label.Location = new System.Drawing.Point(30, 74);
            this.review_label.Name = "review_label";
            this.review_label.Size = new System.Drawing.Size(29, 12);
            this.review_label.TabIndex = 18;
            this.review_label.Text = "说明";
            // 
            // review_position_textBox
            // 
            this.review_position_textBox.Location = new System.Drawing.Point(289, 47);
            this.review_position_textBox.Name = "review_position_textBox";
            this.review_position_textBox.Size = new System.Drawing.Size(168, 21);
            this.review_position_textBox.TabIndex = 7;
            this.review_position_textBox.Enter += new System.EventHandler(this.review_position_textBox_Enter);
            // 
            // review_module_textBox
            // 
            this.review_module_textBox.Location = new System.Drawing.Point(61, 47);
            this.review_module_textBox.Name = "review_module_textBox";
            this.review_module_textBox.Size = new System.Drawing.Size(168, 21);
            this.review_module_textBox.TabIndex = 6;
            this.review_module_textBox.Enter += new System.EventHandler(this.review_module_textBox_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "位置";
            // 
            // review_module_label
            // 
            this.review_module_label.AutoSize = true;
            this.review_module_label.Location = new System.Drawing.Point(30, 49);
            this.review_module_label.Name = "review_module_label";
            this.review_module_label.Size = new System.Drawing.Size(29, 12);
            this.review_module_label.TabIndex = 8;
            this.review_module_label.Text = "模块";
            // 
            // review_level_label
            // 
            this.review_level_label.AutoSize = true;
            this.review_level_label.Location = new System.Drawing.Point(7, 23);
            this.review_level_label.Name = "review_level_label";
            this.review_level_label.Size = new System.Drawing.Size(53, 12);
            this.review_level_label.TabIndex = 9;
            this.review_level_label.Text = "问题级别";
            // 
            // review_type_label
            // 
            this.review_type_label.AutoSize = true;
            this.review_type_label.Location = new System.Drawing.Point(233, 21);
            this.review_type_label.Name = "review_type_label";
            this.review_type_label.Size = new System.Drawing.Size(53, 12);
            this.review_type_label.TabIndex = 12;
            this.review_type_label.Text = "问题类型";
            // 
            // review_level_comboBox
            // 
            this.review_level_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.review_level_comboBox.FormattingEnabled = true;
            this.review_level_comboBox.Location = new System.Drawing.Point(62, 21);
            this.review_level_comboBox.Name = "review_level_comboBox";
            this.review_level_comboBox.Size = new System.Drawing.Size(167, 20);
            this.review_level_comboBox.TabIndex = 4;
            this.review_level_comboBox.SelectedIndexChanged += new System.EventHandler(this.review_level_comboBox_SelectedIndexChanged);
            this.review_level_comboBox.Enter += new System.EventHandler(this.review_level_comboBox_Enter);
            // 
            // review_type_comboBox
            // 
            this.review_type_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.review_type_comboBox.FormattingEnabled = true;
            this.review_type_comboBox.Location = new System.Drawing.Point(289, 21);
            this.review_type_comboBox.Name = "review_type_comboBox";
            this.review_type_comboBox.Size = new System.Drawing.Size(167, 20);
            this.review_type_comboBox.TabIndex = 5;
            this.review_type_comboBox.Enter += new System.EventHandler(this.review_type_comboBox_Enter);
            // 
            // review_line_textBox
            // 
            this.review_line_textBox.Location = new System.Drawing.Point(298, 12);
            this.review_line_textBox.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.review_line_textBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.review_line_textBox.Name = "review_line_textBox";
            this.review_line_textBox.Size = new System.Drawing.Size(86, 21);
            this.review_line_textBox.TabIndex = 1;
            this.review_line_textBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.review_line_textBox.ValueChanged += new System.EventHandler(this.review_line_textBox_ValueChanged);
            this.review_line_textBox.Enter += new System.EventHandler(this.review_line_textBox_Enter);
            // 
            // revier_line_label
            // 
            this.revier_line_label.AutoSize = true;
            this.revier_line_label.Location = new System.Drawing.Point(244, 16);
            this.revier_line_label.Name = "revier_line_label";
            this.revier_line_label.Size = new System.Drawing.Size(53, 12);
            this.revier_line_label.TabIndex = 11;
            this.revier_line_label.Text = "代码行数";
            // 
            // review_tfs_textBox
            // 
            this.review_tfs_textBox.Location = new System.Drawing.Point(65, 387);
            this.review_tfs_textBox.Multiline = true;
            this.review_tfs_textBox.Name = "review_tfs_textBox";
            this.review_tfs_textBox.ReadOnly = true;
            this.review_tfs_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.review_tfs_textBox.Size = new System.Drawing.Size(541, 152);
            this.review_tfs_textBox.TabIndex = 16;
            this.review_tfs_textBox.TabStop = false;
            this.review_tfs_textBox.Enter += new System.EventHandler(this.review_tfs_textBox_Enter);
            // 
            // review_tfs_label
            // 
            this.review_tfs_label.AutoSize = true;
            this.review_tfs_label.Location = new System.Drawing.Point(9, 390);
            this.review_tfs_label.Name = "review_tfs_label";
            this.review_tfs_label.Size = new System.Drawing.Size(53, 12);
            this.review_tfs_label.TabIndex = 20;
            this.review_tfs_label.Text = "文本信息";
            // 
            // review_name_textBox
            // 
            this.review_name_textBox.Enabled = false;
            this.review_name_textBox.Location = new System.Drawing.Point(70, 13);
            this.review_name_textBox.Name = "review_name_textBox";
            this.review_name_textBox.Size = new System.Drawing.Size(168, 21);
            this.review_name_textBox.TabIndex = 0;
            this.review_name_textBox.TextChanged += new System.EventHandler(this.review_name_textBox_TextChanged);
            this.review_name_textBox.Enter += new System.EventHandler(this.review_name_textBox_Enter);
            // 
            // review_name_label
            // 
            this.review_name_label.AutoSize = true;
            this.review_name_label.Location = new System.Drawing.Point(26, 13);
            this.review_name_label.Name = "review_name_label";
            this.review_name_label.Size = new System.Drawing.Size(41, 12);
            this.review_name_label.TabIndex = 0;
            this.review_name_label.Text = "走查者";
            // 
            // review_mail_groupBox
            // 
            this.review_mail_groupBox.Controls.Add(this.review_tfsid_textBox);
            this.review_mail_groupBox.Controls.Add(this.label1);
            this.review_mail_groupBox.Controls.Add(this.review_mail_label);
            this.review_mail_groupBox.Controls.Add(this.review_mail_checkBox);
            this.review_mail_groupBox.Controls.Add(this.review_mail_label2);
            this.review_mail_groupBox.Controls.Add(this.review_mail_textBox);
            this.review_mail_groupBox.Location = new System.Drawing.Point(8, 296);
            this.review_mail_groupBox.Name = "review_mail_groupBox";
            this.review_mail_groupBox.Size = new System.Drawing.Size(598, 85);
            this.review_mail_groupBox.TabIndex = 12;
            this.review_mail_groupBox.TabStop = false;
            // 
            // review_tfsid_textBox
            // 
            this.review_tfsid_textBox.Location = new System.Drawing.Point(61, 24);
            this.review_tfsid_textBox.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.review_tfsid_textBox.Name = "review_tfsid_textBox";
            this.review_tfsid_textBox.Size = new System.Drawing.Size(117, 21);
            this.review_tfsid_textBox.TabIndex = 14;
            this.review_tfsid_textBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.review_tfsid_textBox.Enter += new System.EventHandler(this.review_tfsid_textBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "变更集ID";
            // 
            // review_mail_label
            // 
            this.review_mail_label.AutoSize = true;
            this.review_mail_label.Location = new System.Drawing.Point(18, 55);
            this.review_mail_label.Name = "review_mail_label";
            this.review_mail_label.Size = new System.Drawing.Size(41, 12);
            this.review_mail_label.TabIndex = 29;
            this.review_mail_label.Text = "收件人";
            // 
            // review_mail_checkBox
            // 
            this.review_mail_checkBox.AutoSize = true;
            this.review_mail_checkBox.Location = new System.Drawing.Point(10, 0);
            this.review_mail_checkBox.Name = "review_mail_checkBox";
            this.review_mail_checkBox.Size = new System.Drawing.Size(120, 16);
            this.review_mail_checkBox.TabIndex = 13;
            this.review_mail_checkBox.Text = "自动发送走查邮件";
            this.review_mail_checkBox.UseVisualStyleBackColor = true;
            this.review_mail_checkBox.CheckedChanged += new System.EventHandler(this.review_mail_checkBox_CheckedChanged);
            // 
            // review_mail_label2
            // 
            this.review_mail_label2.AutoSize = true;
            this.review_mail_label2.Location = new System.Drawing.Point(182, 55);
            this.review_mail_label2.Name = "review_mail_label2";
            this.review_mail_label2.Size = new System.Drawing.Size(83, 12);
            this.review_mail_label2.TabIndex = 27;
            this.review_mail_label2.Text = "@hollysys.net";
            // 
            // review_mail_textBox
            // 
            this.review_mail_textBox.Location = new System.Drawing.Point(59, 51);
            this.review_mail_textBox.Name = "review_mail_textBox";
            this.review_mail_textBox.Size = new System.Drawing.Size(119, 21);
            this.review_mail_textBox.TabIndex = 15;
            this.review_mail_textBox.Enter += new System.EventHandler(this.review_mail_textBox_Enter);
            // 
            // review_no_checkBox
            // 
            this.review_no_checkBox.AutoSize = true;
            this.review_no_checkBox.Location = new System.Drawing.Point(519, 18);
            this.review_no_checkBox.Name = "review_no_checkBox";
            this.review_no_checkBox.Size = new System.Drawing.Size(84, 16);
            this.review_no_checkBox.TabIndex = 2;
            this.review_no_checkBox.Text = "走查无问题";
            this.review_no_checkBox.UseVisualStyleBackColor = true;
            this.review_no_checkBox.CheckedChanged += new System.EventHandler(this.review_no_checkBox_CheckedChanged);
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(440, 551);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(80, 25);
            this.ok_button.TabIndex = 17;
            this.ok_button.Text = "确定";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // ReviewHelperForm
            // 
            this.AcceptButton = this.ok_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 583);
            this.Controls.Add(this.review_line_textBox);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.review_no_checkBox);
            this.Controls.Add(this.review_mail_groupBox);
            this.Controls.Add(this.review_groupBox);
            this.Controls.Add(this.review_tfs_textBox);
            this.Controls.Add(this.review_tfs_label);
            this.Controls.Add(this.review_name_textBox);
            this.Controls.Add(this.revier_line_label);
            this.Controls.Add(this.review_name_label);
            this.Controls.Add(this.exit_button);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReviewHelperForm";
            this.Text = "TFS变更集Review注释";
            this.TopMost = true;
            this.review_groupBox.ResumeLayout(false);
            this.review_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.review_line_textBox)).EndInit();
            this.review_mail_groupBox.ResumeLayout(false);
            this.review_mail_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.review_tfsid_textBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.GroupBox review_groupBox;
        private System.Windows.Forms.Button revier_del_button;
        private System.Windows.Forms.Button revier_add_button;
        private System.Windows.Forms.ListBox review_listBox;
        private System.Windows.Forms.TextBox review_textBox;
        private System.Windows.Forms.Label review_label;
        private System.Windows.Forms.TextBox review_position_textBox;
        private System.Windows.Forms.TextBox review_module_textBox;
        private System.Windows.Forms.Label revier_line_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label review_module_label;
        private System.Windows.Forms.Label review_level_label;
        private System.Windows.Forms.Label review_type_label;
        private System.Windows.Forms.ComboBox review_level_comboBox;
        private System.Windows.Forms.ComboBox review_type_comboBox;
        private System.Windows.Forms.TextBox review_tfs_textBox;
        private System.Windows.Forms.Label review_tfs_label;
        private System.Windows.Forms.TextBox review_name_textBox;
        private System.Windows.Forms.Label review_name_label;
        private System.Windows.Forms.GroupBox review_mail_groupBox;
        private System.Windows.Forms.CheckBox review_mail_checkBox;
        private System.Windows.Forms.Label review_mail_label2;
        private System.Windows.Forms.TextBox review_mail_textBox;
        private System.Windows.Forms.Label review_mail_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox review_no_checkBox;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.NumericUpDown review_line_textBox;
        private System.Windows.Forms.NumericUpDown review_tfsid_textBox;
    }
}
namespace TFS_Helper
{
    partial class ModifyHelperForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyHelperForm));
            this.ok_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.mod_answer_groupBox = new System.Windows.Forms.GroupBox();
            this.mod_position_textBox = new System.Windows.Forms.TextBox();
            this.mod_module_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.review_module_label = new System.Windows.Forms.Label();
            this.review_level_label = new System.Windows.Forms.Label();
            this.review_type_label = new System.Windows.Forms.Label();
            this.mod_level_comboBox = new System.Windows.Forms.ComboBox();
            this.mod_type_comboBox = new System.Windows.Forms.ComboBox();
            this.no_button = new System.Windows.Forms.Button();
            this.mod_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mod_question_Label = new System.Windows.Forms.Label();
            this.mod_answer_textBox = new System.Windows.Forms.TextBox();
            this.mod_question_textBox = new System.Windows.Forms.TextBox();
            this.mod_question_listBox = new System.Windows.Forms.ListBox();
            this.mod_question_groupBox = new System.Windows.Forms.GroupBox();
            this.mod_mail_checkBox = new System.Windows.Forms.CheckBox();
            this.mod_answer_groupBox.SuspendLayout();
            this.mod_question_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(469, 407);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(80, 25);
            this.ok_button.TabIndex = 12;
            this.ok_button.Text = "确定";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(555, 407);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(80, 25);
            this.exit_button.TabIndex = 13;
            this.exit_button.Text = "取消";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // mod_answer_groupBox
            // 
            this.mod_answer_groupBox.Controls.Add(this.mod_position_textBox);
            this.mod_answer_groupBox.Controls.Add(this.mod_module_textBox);
            this.mod_answer_groupBox.Controls.Add(this.label2);
            this.mod_answer_groupBox.Controls.Add(this.review_module_label);
            this.mod_answer_groupBox.Controls.Add(this.review_level_label);
            this.mod_answer_groupBox.Controls.Add(this.review_type_label);
            this.mod_answer_groupBox.Controls.Add(this.mod_level_comboBox);
            this.mod_answer_groupBox.Controls.Add(this.mod_type_comboBox);
            this.mod_answer_groupBox.Controls.Add(this.no_button);
            this.mod_answer_groupBox.Controls.Add(this.mod_button);
            this.mod_answer_groupBox.Controls.Add(this.label1);
            this.mod_answer_groupBox.Controls.Add(this.mod_question_Label);
            this.mod_answer_groupBox.Controls.Add(this.mod_answer_textBox);
            this.mod_answer_groupBox.Controls.Add(this.mod_question_textBox);
            this.mod_answer_groupBox.Location = new System.Drawing.Point(10, 139);
            this.mod_answer_groupBox.Name = "mod_answer_groupBox";
            this.mod_answer_groupBox.Size = new System.Drawing.Size(625, 257);
            this.mod_answer_groupBox.TabIndex = 2;
            this.mod_answer_groupBox.TabStop = false;
            this.mod_answer_groupBox.Text = "问题信息";
            // 
            // mod_position_textBox
            // 
            this.mod_position_textBox.Enabled = false;
            this.mod_position_textBox.Location = new System.Drawing.Point(295, 43);
            this.mod_position_textBox.Name = "mod_position_textBox";
            this.mod_position_textBox.Size = new System.Drawing.Size(168, 21);
            this.mod_position_textBox.TabIndex = 6;
            // 
            // mod_module_textBox
            // 
            this.mod_module_textBox.Enabled = false;
            this.mod_module_textBox.Location = new System.Drawing.Point(67, 43);
            this.mod_module_textBox.Name = "mod_module_textBox";
            this.mod_module_textBox.Size = new System.Drawing.Size(168, 21);
            this.mod_module_textBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "位置";
            // 
            // review_module_label
            // 
            this.review_module_label.AutoSize = true;
            this.review_module_label.Location = new System.Drawing.Point(36, 45);
            this.review_module_label.Name = "review_module_label";
            this.review_module_label.Size = new System.Drawing.Size(29, 12);
            this.review_module_label.TabIndex = 17;
            this.review_module_label.Text = "模块";
            // 
            // review_level_label
            // 
            this.review_level_label.AutoSize = true;
            this.review_level_label.Location = new System.Drawing.Point(241, 22);
            this.review_level_label.Name = "review_level_label";
            this.review_level_label.Size = new System.Drawing.Size(53, 12);
            this.review_level_label.TabIndex = 18;
            this.review_level_label.Text = "问题级别";
            // 
            // review_type_label
            // 
            this.review_type_label.AutoSize = true;
            this.review_type_label.Location = new System.Drawing.Point(12, 20);
            this.review_type_label.Name = "review_type_label";
            this.review_type_label.Size = new System.Drawing.Size(53, 12);
            this.review_type_label.TabIndex = 20;
            this.review_type_label.Text = "问题类型";
            // 
            // mod_level_comboBox
            // 
            this.mod_level_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mod_level_comboBox.Enabled = false;
            this.mod_level_comboBox.FormattingEnabled = true;
            this.mod_level_comboBox.Items.AddRange(new object[] {
            "严重",
            "一般",
            "优化",
            "代码规范"});
            this.mod_level_comboBox.Location = new System.Drawing.Point(296, 20);
            this.mod_level_comboBox.Name = "mod_level_comboBox";
            this.mod_level_comboBox.Size = new System.Drawing.Size(167, 20);
            this.mod_level_comboBox.TabIndex = 4;
            // 
            // mod_type_comboBox
            // 
            this.mod_type_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mod_type_comboBox.Enabled = false;
            this.mod_type_comboBox.FormattingEnabled = true;
            this.mod_type_comboBox.Items.AddRange(new object[] {
            "实现逻辑",
            "内存问题",
            "代码规范",
            "其他问题"});
            this.mod_type_comboBox.Location = new System.Drawing.Point(68, 20);
            this.mod_type_comboBox.Name = "mod_type_comboBox";
            this.mod_type_comboBox.Size = new System.Drawing.Size(167, 20);
            this.mod_type_comboBox.TabIndex = 3;
            // 
            // no_button
            // 
            this.no_button.Location = new System.Drawing.Point(153, 220);
            this.no_button.Name = "no_button";
            this.no_button.Size = new System.Drawing.Size(80, 25);
            this.no_button.TabIndex = 10;
            this.no_button.Text = "不是问题";
            this.no_button.UseVisualStyleBackColor = true;
            this.no_button.Click += new System.EventHandler(this.no_button_Click);
            // 
            // mod_button
            // 
            this.mod_button.Location = new System.Drawing.Point(67, 220);
            this.mod_button.Name = "mod_button";
            this.mod_button.Size = new System.Drawing.Size(80, 25);
            this.mod_button.TabIndex = 9;
            this.mod_button.Text = "关闭问题";
            this.mod_button.UseVisualStyleBackColor = true;
            this.mod_button.Click += new System.EventHandler(this.mod_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "确认说明";
            // 
            // mod_question_Label
            // 
            this.mod_question_Label.AutoSize = true;
            this.mod_question_Label.Location = new System.Drawing.Point(12, 70);
            this.mod_question_Label.Name = "mod_question_Label";
            this.mod_question_Label.Size = new System.Drawing.Size(53, 12);
            this.mod_question_Label.TabIndex = 7;
            this.mod_question_Label.Text = "问题描述";
            // 
            // mod_answer_textBox
            // 
            this.mod_answer_textBox.Location = new System.Drawing.Point(67, 145);
            this.mod_answer_textBox.Multiline = true;
            this.mod_answer_textBox.Name = "mod_answer_textBox";
            this.mod_answer_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mod_answer_textBox.Size = new System.Drawing.Size(552, 69);
            this.mod_answer_textBox.TabIndex = 8;
            this.mod_answer_textBox.Enter += new System.EventHandler(this.mod_answer_textBox_Enter);
            // 
            // mod_question_textBox
            // 
            this.mod_question_textBox.Enabled = false;
            this.mod_question_textBox.Location = new System.Drawing.Point(67, 70);
            this.mod_question_textBox.Multiline = true;
            this.mod_question_textBox.Name = "mod_question_textBox";
            this.mod_question_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mod_question_textBox.Size = new System.Drawing.Size(552, 69);
            this.mod_question_textBox.TabIndex = 7;
            this.mod_question_textBox.TabStop = false;
            // 
            // mod_question_listBox
            // 
            this.mod_question_listBox.FormattingEnabled = true;
            this.mod_question_listBox.HorizontalScrollbar = true;
            this.mod_question_listBox.ItemHeight = 12;
            this.mod_question_listBox.Location = new System.Drawing.Point(6, 20);
            this.mod_question_listBox.Name = "mod_question_listBox";
            this.mod_question_listBox.Size = new System.Drawing.Size(613, 88);
            this.mod_question_listBox.TabIndex = 1;
            this.mod_question_listBox.SelectedIndexChanged += new System.EventHandler(this.mod_question_listBox_SelectedIndexChanged);
            // 
            // mod_question_groupBox
            // 
            this.mod_question_groupBox.Controls.Add(this.mod_question_listBox);
            this.mod_question_groupBox.Location = new System.Drawing.Point(10, 12);
            this.mod_question_groupBox.Name = "mod_question_groupBox";
            this.mod_question_groupBox.Size = new System.Drawing.Size(625, 121);
            this.mod_question_groupBox.TabIndex = 0;
            this.mod_question_groupBox.TabStop = false;
            this.mod_question_groupBox.Text = "走查问题一览";
            // 
            // mod_mail_checkBox
            // 
            this.mod_mail_checkBox.AutoSize = true;
            this.mod_mail_checkBox.Location = new System.Drawing.Point(12, 407);
            this.mod_mail_checkBox.Name = "mod_mail_checkBox";
            this.mod_mail_checkBox.Size = new System.Drawing.Size(144, 16);
            this.mod_mail_checkBox.TabIndex = 11;
            this.mod_mail_checkBox.Text = "自动发送走查应答邮件";
            this.mod_mail_checkBox.UseVisualStyleBackColor = true;
            // 
            // ModifyHelperForm
            // 
            this.AcceptButton = this.ok_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 444);
            this.Controls.Add(this.mod_mail_checkBox);
            this.Controls.Add(this.mod_answer_groupBox);
            this.Controls.Add(this.mod_question_groupBox);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.exit_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyHelperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "走查问题对应";
            this.mod_answer_groupBox.ResumeLayout(false);
            this.mod_answer_groupBox.PerformLayout();
            this.mod_question_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.GroupBox mod_answer_groupBox;
        private System.Windows.Forms.TextBox mod_question_textBox;
        private System.Windows.Forms.TextBox mod_answer_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mod_question_Label;
        private System.Windows.Forms.Button mod_button;
        private System.Windows.Forms.ListBox mod_question_listBox;
        private System.Windows.Forms.GroupBox mod_question_groupBox;
        private System.Windows.Forms.Button no_button;
        private System.Windows.Forms.TextBox mod_position_textBox;
        private System.Windows.Forms.TextBox mod_module_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label review_module_label;
        private System.Windows.Forms.Label review_level_label;
        private System.Windows.Forms.Label review_type_label;
        private System.Windows.Forms.ComboBox mod_level_comboBox;
        private System.Windows.Forms.ComboBox mod_type_comboBox;
        private System.Windows.Forms.CheckBox mod_mail_checkBox;
    }
}
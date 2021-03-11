namespace TFS_Helper
{
    partial class CheckinHelperForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckinHelperForm));
            this.exit_button = new System.Windows.Forms.Button();
            this.code_tfs_textBox = new System.Windows.Forms.TextBox();
            this.code_textBox = new System.Windows.Forms.TextBox();
            this.code_info_textBox = new System.Windows.Forms.TextBox();
            this.code_tfs_label = new System.Windows.Forms.Label();
            this.code_label = new System.Windows.Forms.Label();
            this.code_info_label = new System.Windows.Forms.Label();
            this.code_type_label = new System.Windows.Forms.Label();
            this.code_type_comboBox = new System.Windows.Forms.ComboBox();
            this.ok_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(429, 276);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(80, 25);
            this.exit_button.TabIndex = 5;
            this.exit_button.Text = "取消";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // code_tfs_textBox
            // 
            this.code_tfs_textBox.Location = new System.Drawing.Point(61, 145);
            this.code_tfs_textBox.Multiline = true;
            this.code_tfs_textBox.Name = "code_tfs_textBox";
            this.code_tfs_textBox.ReadOnly = true;
            this.code_tfs_textBox.Size = new System.Drawing.Size(448, 122);
            this.code_tfs_textBox.TabIndex = 3;
            this.code_tfs_textBox.TabStop = false;
            // 
            // code_textBox
            // 
            this.code_textBox.Location = new System.Drawing.Point(61, 64);
            this.code_textBox.Multiline = true;
            this.code_textBox.Name = "code_textBox";
            this.code_textBox.Size = new System.Drawing.Size(448, 75);
            this.code_textBox.TabIndex = 2;
            this.code_textBox.TextChanged += new System.EventHandler(this.code_textBox_TextChanged);
            this.code_textBox.Enter += new System.EventHandler(this.code_textBox_Enter);
            // 
            // code_info_textBox
            // 
            this.code_info_textBox.Location = new System.Drawing.Point(61, 37);
            this.code_info_textBox.Name = "code_info_textBox";
            this.code_info_textBox.Size = new System.Drawing.Size(448, 21);
            this.code_info_textBox.TabIndex = 1;
            this.code_info_textBox.TextChanged += new System.EventHandler(this.code_info_textBox_TextChanged);
            this.code_info_textBox.Enter += new System.EventHandler(this.code_info_textBox_Enter);
            // 
            // code_tfs_label
            // 
            this.code_tfs_label.AutoSize = true;
            this.code_tfs_label.Location = new System.Drawing.Point(12, 147);
            this.code_tfs_label.Name = "code_tfs_label";
            this.code_tfs_label.Size = new System.Drawing.Size(47, 12);
            this.code_tfs_label.TabIndex = 23;
            this.code_tfs_label.Text = "TFS注释";
            // 
            // code_label
            // 
            this.code_label.AutoSize = true;
            this.code_label.Location = new System.Drawing.Point(6, 66);
            this.code_label.Name = "code_label";
            this.code_label.Size = new System.Drawing.Size(53, 12);
            this.code_label.TabIndex = 19;
            this.code_label.Text = "签入说明";
            // 
            // code_info_label
            // 
            this.code_info_label.AutoSize = true;
            this.code_info_label.Location = new System.Drawing.Point(6, 39);
            this.code_info_label.Name = "code_info_label";
            this.code_info_label.Size = new System.Drawing.Size(53, 12);
            this.code_info_label.TabIndex = 20;
            this.code_info_label.Text = "类型信息";
            // 
            // code_type_label
            // 
            this.code_type_label.AutoSize = true;
            this.code_type_label.Location = new System.Drawing.Point(6, 14);
            this.code_type_label.Name = "code_type_label";
            this.code_type_label.Size = new System.Drawing.Size(53, 12);
            this.code_type_label.TabIndex = 21;
            this.code_type_label.Text = "签入类型";
            // 
            // code_type_comboBox
            // 
            this.code_type_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.code_type_comboBox.FormattingEnabled = true;
            this.code_type_comboBox.Items.AddRange(new object[] {
            "需求",
            "BUG",
            "代码优化",
            "走查问题处理",
            "PC Lint",
            "文档"});
            this.code_type_comboBox.Location = new System.Drawing.Point(61, 12);
            this.code_type_comboBox.Name = "code_type_comboBox";
            this.code_type_comboBox.Size = new System.Drawing.Size(167, 20);
            this.code_type_comboBox.TabIndex = 0;
            this.code_type_comboBox.TextChanged += new System.EventHandler(this.code_type_comboBox_TextChanged);
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(343, 276);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(80, 25);
            this.ok_button.TabIndex = 4;
            this.ok_button.Text = "确定";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // CheckinHelperForm
            // 
            this.AcceptButton = this.ok_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 307);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.code_tfs_textBox);
            this.Controls.Add(this.code_textBox);
            this.Controls.Add(this.code_info_textBox);
            this.Controls.Add(this.code_tfs_label);
            this.Controls.Add(this.code_label);
            this.Controls.Add(this.code_info_label);
            this.Controls.Add(this.code_type_label);
            this.Controls.Add(this.code_type_comboBox);
            this.Controls.Add(this.exit_button);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckinHelperForm";
            this.Text = "TFS签入变更集注释";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.TextBox code_tfs_textBox;
        private System.Windows.Forms.TextBox code_textBox;
        private System.Windows.Forms.TextBox code_info_textBox;
        private System.Windows.Forms.Label code_tfs_label;
        private System.Windows.Forms.Label code_label;
        private System.Windows.Forms.Label code_info_label;
        private System.Windows.Forms.Label code_type_label;
        private System.Windows.Forms.ComboBox code_type_comboBox;
        private System.Windows.Forms.Button ok_button;
    }
}
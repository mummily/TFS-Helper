namespace TFS_Helper
{
    partial class TFSRecordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFSRecordForm));
            this.record_groupBox = new System.Windows.Forms.GroupBox();
            this.search_group_comboBox = new System.Windows.Forms.ComboBox();
            this.search_review_textBox = new System.Windows.Forms.TextBox();
            this.search_review_label = new System.Windows.Forms.Label();
            this.search_button = new System.Windows.Forms.Button();
            this.search_to_label = new System.Windows.Forms.Label();
            this.search_end_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.search_start_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.search_code_textBox = new System.Windows.Forms.TextBox();
            this.search_id_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.search_date_label = new System.Windows.Forms.Label();
            this.search_group_label = new System.Windows.Forms.Label();
            this.search_code_label = new System.Windows.Forms.Label();
            this.search_id_label = new System.Windows.Forms.Label();
            this.list_panel = new System.Windows.Forms.Panel();
            this.record_listView = new System.Windows.Forms.ListView();
            this.export_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.record_total1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.record_total2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.record_total3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.record_total4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.record_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.search_id_numericUpDown)).BeginInit();
            this.list_panel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // record_groupBox
            // 
            this.record_groupBox.Controls.Add(this.search_group_comboBox);
            this.record_groupBox.Controls.Add(this.search_review_textBox);
            this.record_groupBox.Controls.Add(this.search_review_label);
            this.record_groupBox.Controls.Add(this.search_button);
            this.record_groupBox.Controls.Add(this.search_to_label);
            this.record_groupBox.Controls.Add(this.search_end_dateTimePicker);
            this.record_groupBox.Controls.Add(this.search_start_dateTimePicker);
            this.record_groupBox.Controls.Add(this.search_code_textBox);
            this.record_groupBox.Controls.Add(this.search_id_numericUpDown);
            this.record_groupBox.Controls.Add(this.search_date_label);
            this.record_groupBox.Controls.Add(this.search_group_label);
            this.record_groupBox.Controls.Add(this.search_code_label);
            this.record_groupBox.Controls.Add(this.search_id_label);
            this.record_groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.record_groupBox.Location = new System.Drawing.Point(4, 4);
            this.record_groupBox.Name = "record_groupBox";
            this.record_groupBox.Size = new System.Drawing.Size(1201, 80);
            this.record_groupBox.TabIndex = 0;
            this.record_groupBox.TabStop = false;
            this.record_groupBox.Text = "检索条件";
            // 
            // search_group_comboBox
            // 
            this.search_group_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.search_group_comboBox.FormattingEnabled = true;
            this.search_group_comboBox.Location = new System.Drawing.Point(264, 22);
            this.search_group_comboBox.Name = "search_group_comboBox";
            this.search_group_comboBox.Size = new System.Drawing.Size(106, 20);
            this.search_group_comboBox.TabIndex = 2;
            // 
            // search_review_textBox
            // 
            this.search_review_textBox.Location = new System.Drawing.Point(78, 48);
            this.search_review_textBox.Name = "search_review_textBox";
            this.search_review_textBox.Size = new System.Drawing.Size(123, 21);
            this.search_review_textBox.TabIndex = 4;
            this.search_review_textBox.Enter += new System.EventHandler(this.search_review_textBox_Enter);
            // 
            // search_review_label
            // 
            this.search_review_label.AutoSize = true;
            this.search_review_label.Location = new System.Drawing.Point(31, 49);
            this.search_review_label.Name = "search_review_label";
            this.search_review_label.Size = new System.Drawing.Size(41, 12);
            this.search_review_label.TabIndex = 6;
            this.search_review_label.Text = "走查者";
            // 
            // search_button
            // 
            this.search_button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.search_button.Location = new System.Drawing.Point(1115, 49);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(80, 25);
            this.search_button.TabIndex = 7;
            this.search_button.Text = "检索";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // search_to_label
            // 
            this.search_to_label.AutoSize = true;
            this.search_to_label.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.search_to_label.Location = new System.Drawing.Point(394, 57);
            this.search_to_label.Name = "search_to_label";
            this.search_to_label.Size = new System.Drawing.Size(19, 19);
            this.search_to_label.TabIndex = 4;
            this.search_to_label.Text = "~";
            // 
            // search_end_dateTimePicker
            // 
            this.search_end_dateTimePicker.Location = new System.Drawing.Point(420, 48);
            this.search_end_dateTimePicker.Name = "search_end_dateTimePicker";
            this.search_end_dateTimePicker.Size = new System.Drawing.Size(120, 21);
            this.search_end_dateTimePicker.TabIndex = 6;
            this.search_end_dateTimePicker.Enter += new System.EventHandler(this.search_end_dateTimePicker_Enter);
            // 
            // search_start_dateTimePicker
            // 
            this.search_start_dateTimePicker.Location = new System.Drawing.Point(264, 48);
            this.search_start_dateTimePicker.Name = "search_start_dateTimePicker";
            this.search_start_dateTimePicker.Size = new System.Drawing.Size(120, 21);
            this.search_start_dateTimePicker.TabIndex = 5;
            this.search_start_dateTimePicker.Enter += new System.EventHandler(this.search_start_dateTimePicker_Enter);
            // 
            // search_code_textBox
            // 
            this.search_code_textBox.Location = new System.Drawing.Point(420, 23);
            this.search_code_textBox.Name = "search_code_textBox";
            this.search_code_textBox.Size = new System.Drawing.Size(120, 21);
            this.search_code_textBox.TabIndex = 3;
            this.search_code_textBox.Enter += new System.EventHandler(this.search_code_textBox_Enter);
            // 
            // search_id_numericUpDown
            // 
            this.search_id_numericUpDown.Location = new System.Drawing.Point(78, 21);
            this.search_id_numericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.search_id_numericUpDown.Name = "search_id_numericUpDown";
            this.search_id_numericUpDown.Size = new System.Drawing.Size(123, 21);
            this.search_id_numericUpDown.TabIndex = 1;
            this.search_id_numericUpDown.Enter += new System.EventHandler(this.search_id_numericUpDown_Enter);
            // 
            // search_date_label
            // 
            this.search_date_label.AutoSize = true;
            this.search_date_label.Location = new System.Drawing.Point(207, 49);
            this.search_date_label.Name = "search_date_label";
            this.search_date_label.Size = new System.Drawing.Size(53, 12);
            this.search_date_label.TabIndex = 0;
            this.search_date_label.Text = "走查时间";
            // 
            // search_group_label
            // 
            this.search_group_label.AutoSize = true;
            this.search_group_label.Location = new System.Drawing.Point(219, 26);
            this.search_group_label.Name = "search_group_label";
            this.search_group_label.Size = new System.Drawing.Size(41, 12);
            this.search_group_label.TabIndex = 0;
            this.search_group_label.Text = "资源组";
            // 
            // search_code_label
            // 
            this.search_code_label.AutoSize = true;
            this.search_code_label.Location = new System.Drawing.Point(376, 26);
            this.search_code_label.Name = "search_code_label";
            this.search_code_label.Size = new System.Drawing.Size(41, 12);
            this.search_code_label.TabIndex = 0;
            this.search_code_label.Text = "签入者";
            // 
            // search_id_label
            // 
            this.search_id_label.AutoSize = true;
            this.search_id_label.Location = new System.Drawing.Point(19, 23);
            this.search_id_label.Name = "search_id_label";
            this.search_id_label.Size = new System.Drawing.Size(53, 12);
            this.search_id_label.TabIndex = 0;
            this.search_id_label.Text = "变更集ID";
            // 
            // list_panel
            // 
            this.list_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.list_panel.Controls.Add(this.record_listView);
            this.list_panel.Location = new System.Drawing.Point(4, 84);
            this.list_panel.Name = "list_panel";
            this.list_panel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.list_panel.Size = new System.Drawing.Size(1201, 703);
            this.list_panel.TabIndex = 2;
            // 
            // record_listView
            // 
            this.record_listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.record_listView.Location = new System.Drawing.Point(0, 6);
            this.record_listView.Name = "record_listView";
            this.record_listView.Size = new System.Drawing.Size(1201, 697);
            this.record_listView.TabIndex = 8;
            this.record_listView.UseCompatibleStateImageBehavior = false;
            this.record_listView.View = System.Windows.Forms.View.Details;
            this.record_listView.DoubleClick += new System.EventHandler(this.record_listView_DoubleClick);
            // 
            // export_button
            // 
            this.export_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.export_button.Location = new System.Drawing.Point(1033, 794);
            this.export_button.Name = "export_button";
            this.export_button.Size = new System.Drawing.Size(80, 25);
            this.export_button.TabIndex = 9;
            this.export_button.Text = "导出Excel";
            this.export_button.UseVisualStyleBackColor = true;
            this.export_button.Click += new System.EventHandler(this.export_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exit_button.Location = new System.Drawing.Point(1119, 794);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(80, 25);
            this.exit_button.TabIndex = 10;
            this.exit_button.Text = "退出";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.record_total1,
            this.record_total2,
            this.record_total3,
            this.record_total4});
            this.statusStrip.Location = new System.Drawing.Point(4, 794);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(320, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 11;
            // 
            // record_total1
            // 
            this.record_total1.Name = "record_total1";
            this.record_total1.Size = new System.Drawing.Size(65, 17);
            this.record_total1.Text = "记录总条数";
            // 
            // record_total2
            // 
            this.record_total2.Name = "record_total2";
            this.record_total2.Size = new System.Drawing.Size(65, 17);
            this.record_total2.Text = "代码总行数";
            // 
            // record_total3
            // 
            this.record_total3.Name = "record_total3";
            this.record_total3.Size = new System.Drawing.Size(53, 17);
            this.record_total3.Text = "问题总数";
            // 
            // record_total4
            // 
            this.record_total4.Name = "record_total4";
            this.record_total4.Size = new System.Drawing.Size(89, 17);
            this.record_total4.Text = "未解决问题总数";
            // 
            // TFSRecordForm
            // 
            this.AcceptButton = this.search_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 826);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.export_button);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.list_panel);
            this.Controls.Add(this.record_groupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFSRecordForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "变更集走查记录信息";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TFSRecordForm_FormClosed);
            this.record_groupBox.ResumeLayout(false);
            this.record_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.search_id_numericUpDown)).EndInit();
            this.list_panel.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox record_groupBox;
        private System.Windows.Forms.Panel list_panel;
        private System.Windows.Forms.ListView record_listView;
        private System.Windows.Forms.Label search_id_label;
        private System.Windows.Forms.NumericUpDown search_id_numericUpDown;
        private System.Windows.Forms.Label search_code_label;
        private System.Windows.Forms.TextBox search_code_textBox;
        private System.Windows.Forms.Label search_date_label;
        private System.Windows.Forms.Label search_to_label;
        private System.Windows.Forms.DateTimePicker search_end_dateTimePicker;
        private System.Windows.Forms.DateTimePicker search_start_dateTimePicker;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox search_review_textBox;
        private System.Windows.Forms.Label search_review_label;
        private System.Windows.Forms.Button export_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Label search_group_label;
        private System.Windows.Forms.ComboBox search_group_comboBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel record_total1;
        private System.Windows.Forms.ToolStripStatusLabel record_total2;
        private System.Windows.Forms.ToolStripStatusLabel record_total3;
        private System.Windows.Forms.ToolStripStatusLabel record_total4;

    }
}
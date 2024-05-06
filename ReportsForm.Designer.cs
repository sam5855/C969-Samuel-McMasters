namespace C969_Samuel_McMasters
{
    partial class ReportsForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.report1 = new System.Windows.Forms.TabPage();
            this.report2 = new System.Windows.Forms.TabPage();
            this.report3 = new System.Windows.Forms.TabPage();
            this.reportTwoDGV = new System.Windows.Forms.DataGridView();
            this.reportThreeDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.aptTypeComboBox = new System.Windows.Forms.ComboBox();
            this.monthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.generateReport1Button = new System.Windows.Forms.Button();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.generateReport2Button = new System.Windows.Forms.Button();
            this.generateReport3Button = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.countLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.monthLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.report1.SuspendLayout();
            this.report2.SuspendLayout();
            this.report3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportTwoDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportThreeDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.report1);
            this.tabControl1.Controls.Add(this.report2);
            this.tabControl1.Controls.Add(this.report3);
            this.tabControl1.Location = new System.Drawing.Point(12, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(621, 243);
            this.tabControl1.TabIndex = 0;
            // 
            // report1
            // 
            this.report1.BackColor = System.Drawing.Color.Gainsboro;
            this.report1.Controls.Add(this.monthLabel);
            this.report1.Controls.Add(this.typeLabel);
            this.report1.Controls.Add(this.label7);
            this.report1.Controls.Add(this.label6);
            this.report1.Controls.Add(this.label5);
            this.report1.Controls.Add(this.countLabel);
            this.report1.Controls.Add(this.generateReport1Button);
            this.report1.Controls.Add(this.monthDateTimePicker);
            this.report1.Controls.Add(this.aptTypeComboBox);
            this.report1.Controls.Add(this.label2);
            this.report1.Controls.Add(this.label1);
            this.report1.Location = new System.Drawing.Point(4, 22);
            this.report1.Name = "report1";
            this.report1.Padding = new System.Windows.Forms.Padding(3);
            this.report1.Size = new System.Drawing.Size(613, 217);
            this.report1.TabIndex = 0;
            this.report1.Text = "Number of Appointments";
            // 
            // report2
            // 
            this.report2.BackColor = System.Drawing.Color.Gainsboro;
            this.report2.Controls.Add(this.generateReport2Button);
            this.report2.Controls.Add(this.userComboBox);
            this.report2.Controls.Add(this.label3);
            this.report2.Controls.Add(this.reportTwoDGV);
            this.report2.Location = new System.Drawing.Point(4, 22);
            this.report2.Name = "report2";
            this.report2.Padding = new System.Windows.Forms.Padding(3);
            this.report2.Size = new System.Drawing.Size(613, 217);
            this.report2.TabIndex = 1;
            this.report2.Text = "User Schedule";
            // 
            // report3
            // 
            this.report3.BackColor = System.Drawing.Color.Gainsboro;
            this.report3.Controls.Add(this.generateReport3Button);
            this.report3.Controls.Add(this.customerComboBox);
            this.report3.Controls.Add(this.label4);
            this.report3.Controls.Add(this.reportThreeDGV);
            this.report3.Location = new System.Drawing.Point(4, 22);
            this.report3.Name = "report3";
            this.report3.Size = new System.Drawing.Size(613, 217);
            this.report3.TabIndex = 2;
            this.report3.Text = "Number of Appointments by Customer";
            // 
            // reportTwoDGV
            // 
            this.reportTwoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportTwoDGV.Location = new System.Drawing.Point(284, 18);
            this.reportTwoDGV.Name = "reportTwoDGV";
            this.reportTwoDGV.Size = new System.Drawing.Size(323, 150);
            this.reportTwoDGV.TabIndex = 0;
            // 
            // reportThreeDGV
            // 
            this.reportThreeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportThreeDGV.Location = new System.Drawing.Point(284, 18);
            this.reportThreeDGV.Name = "reportThreeDGV";
            this.reportThreeDGV.Size = new System.Drawing.Size(323, 150);
            this.reportThreeDGV.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Appointment Type";
            // 
            // aptTypeComboBox
            // 
            this.aptTypeComboBox.FormattingEnabled = true;
            this.aptTypeComboBox.Items.AddRange(new object[] {
            "Presentation ",
            "Scrum",
            "Review"});
            this.aptTypeComboBox.Location = new System.Drawing.Point(138, 83);
            this.aptTypeComboBox.Name = "aptTypeComboBox";
            this.aptTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.aptTypeComboBox.TabIndex = 4;
            // 
            // monthDateTimePicker
            // 
            this.monthDateTimePicker.CustomFormat = "MM/yyyy";
            this.monthDateTimePicker.Location = new System.Drawing.Point(138, 30);
            this.monthDateTimePicker.Name = "monthDateTimePicker";
            this.monthDateTimePicker.Size = new System.Drawing.Size(121, 20);
            this.monthDateTimePicker.TabIndex = 5;
            // 
            // generateReport1Button
            // 
            this.generateReport1Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.generateReport1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateReport1Button.Location = new System.Drawing.Point(138, 133);
            this.generateReport1Button.Name = "generateReport1Button";
            this.generateReport1Button.Size = new System.Drawing.Size(121, 23);
            this.generateReport1Button.TabIndex = 6;
            this.generateReport1Button.Text = "Generate Report";
            this.generateReport1Button.UseVisualStyleBackColor = false;
            this.generateReport1Button.Click += new System.EventHandler(this.generateReport1Button_Click);
            // 
            // userComboBox
            // 
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Items.AddRange(new object[] {
            "Presentation ",
            "Scrum",
            "Review"});
            this.userComboBox.Location = new System.Drawing.Point(122, 33);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(121, 21);
            this.userComboBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "User";
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Items.AddRange(new object[] {
            "Presentation ",
            "Scrum",
            "Review"});
            this.customerComboBox.Location = new System.Drawing.Point(122, 32);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(121, 21);
            this.customerComboBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Customer";
            // 
            // generateReport2Button
            // 
            this.generateReport2Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.generateReport2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateReport2Button.Location = new System.Drawing.Point(122, 96);
            this.generateReport2Button.Name = "generateReport2Button";
            this.generateReport2Button.Size = new System.Drawing.Size(121, 23);
            this.generateReport2Button.TabIndex = 7;
            this.generateReport2Button.Text = "Generate Report";
            this.generateReport2Button.UseVisualStyleBackColor = false;
            // 
            // generateReport3Button
            // 
            this.generateReport3Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.generateReport3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateReport3Button.Location = new System.Drawing.Point(122, 96);
            this.generateReport3Button.Name = "generateReport3Button";
            this.generateReport3Button.Size = new System.Drawing.Size(121, 23);
            this.generateReport3Button.TabIndex = 9;
            this.generateReport3Button.Text = "Generate Report";
            this.generateReport3Button.UseVisualStyleBackColor = false;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Silver;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(537, 291);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(92, 36);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel.Location = new System.Drawing.Point(489, 98);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(16, 18);
            this.countLabel.TabIndex = 8;
            this.countLabel.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(295, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Number of Appointments";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(417, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Month";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(427, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "Type";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(489, 65);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(0, 18);
            this.typeLabel.TabIndex = 12;
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthLabel.Location = new System.Drawing.Point(489, 30);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(0, 18);
            this.monthLabel.TabIndex = 13;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 339);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportsForm";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.report1.ResumeLayout(false);
            this.report1.PerformLayout();
            this.report2.ResumeLayout(false);
            this.report2.PerformLayout();
            this.report3.ResumeLayout(false);
            this.report3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportTwoDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportThreeDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage report1;
        private System.Windows.Forms.TabPage report2;
        private System.Windows.Forms.TabPage report3;
        private System.Windows.Forms.DateTimePicker monthDateTimePicker;
        private System.Windows.Forms.ComboBox aptTypeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView reportTwoDGV;
        private System.Windows.Forms.DataGridView reportThreeDGV;
        private System.Windows.Forms.Button generateReport1Button;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button generateReport2Button;
        private System.Windows.Forms.Button generateReport3Button;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}
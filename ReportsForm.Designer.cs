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
            this.monthLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.generateReport1Button = new System.Windows.Forms.Button();
            this.monthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.aptTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.report2 = new System.Windows.Forms.TabPage();
            this.generateReport2Button = new System.Windows.Forms.Button();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reportTwoDGV = new System.Windows.Forms.DataGridView();
            this.report3 = new System.Windows.Forms.TabPage();
            this.appointmentCountLabel = new System.Windows.Forms.Label();
            this.customerLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.generateReport3Button = new System.Windows.Forms.Button();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.report1.SuspendLayout();
            this.report2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportTwoDGV)).BeginInit();
            this.report3.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(621, 281);
            this.tabControl1.TabIndex = 0;
            // 
            // report1
            // 
            this.report1.BackColor = System.Drawing.Color.Gainsboro;
            this.report1.Controls.Add(this.label11);
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
            this.report1.Size = new System.Drawing.Size(613, 255);
            this.report1.TabIndex = 0;
            this.report1.Text = "Number of Appointments";
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthLabel.Location = new System.Drawing.Point(496, 76);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(0, 18);
            this.monthLabel.TabIndex = 13;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(496, 111);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(0, 18);
            this.typeLabel.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(434, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(424, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Month";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(302, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Number of Appointments";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel.Location = new System.Drawing.Point(496, 144);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(16, 18);
            this.countLabel.TabIndex = 8;
            this.countLabel.Text = "0";
            // 
            // generateReport1Button
            // 
            this.generateReport1Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.generateReport1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateReport1Button.Location = new System.Drawing.Point(145, 179);
            this.generateReport1Button.Name = "generateReport1Button";
            this.generateReport1Button.Size = new System.Drawing.Size(121, 23);
            this.generateReport1Button.TabIndex = 6;
            this.generateReport1Button.Text = "Generate Report";
            this.generateReport1Button.UseVisualStyleBackColor = false;
            this.generateReport1Button.Click += new System.EventHandler(this.generateReport1Button_Click);
            // 
            // monthDateTimePicker
            // 
            this.monthDateTimePicker.CustomFormat = "MM/yyyy";
            this.monthDateTimePicker.Location = new System.Drawing.Point(145, 76);
            this.monthDateTimePicker.Name = "monthDateTimePicker";
            this.monthDateTimePicker.Size = new System.Drawing.Size(121, 20);
            this.monthDateTimePicker.TabIndex = 5;
            // 
            // aptTypeComboBox
            // 
            this.aptTypeComboBox.FormattingEnabled = true;
            this.aptTypeComboBox.Items.AddRange(new object[] {
            "Presentation ",
            "Scrum",
            "Review"});
            this.aptTypeComboBox.Location = new System.Drawing.Point(145, 129);
            this.aptTypeComboBox.Name = "aptTypeComboBox";
            this.aptTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.aptTypeComboBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Appointment Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Month";
            // 
            // report2
            // 
            this.report2.BackColor = System.Drawing.Color.Gainsboro;
            this.report2.Controls.Add(this.label10);
            this.report2.Controls.Add(this.generateReport2Button);
            this.report2.Controls.Add(this.userComboBox);
            this.report2.Controls.Add(this.label3);
            this.report2.Controls.Add(this.reportTwoDGV);
            this.report2.Location = new System.Drawing.Point(4, 22);
            this.report2.Name = "report2";
            this.report2.Padding = new System.Windows.Forms.Padding(3);
            this.report2.Size = new System.Drawing.Size(613, 255);
            this.report2.TabIndex = 1;
            this.report2.Text = "User Schedule";
            // 
            // generateReport2Button
            // 
            this.generateReport2Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.generateReport2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateReport2Button.Location = new System.Drawing.Point(109, 142);
            this.generateReport2Button.Name = "generateReport2Button";
            this.generateReport2Button.Size = new System.Drawing.Size(121, 23);
            this.generateReport2Button.TabIndex = 7;
            this.generateReport2Button.Text = "Generate Report";
            this.generateReport2Button.UseVisualStyleBackColor = false;
            this.generateReport2Button.Click += new System.EventHandler(this.generateReport2Button_Click);
            // 
            // userComboBox
            // 
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Items.AddRange(new object[] {
            "Presentation ",
            "Scrum",
            "Review"});
            this.userComboBox.Location = new System.Drawing.Point(109, 79);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(121, 21);
            this.userComboBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "User";
            // 
            // reportTwoDGV
            // 
            this.reportTwoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportTwoDGV.Location = new System.Drawing.Point(284, 55);
            this.reportTwoDGV.Name = "reportTwoDGV";
            this.reportTwoDGV.Size = new System.Drawing.Size(323, 150);
            this.reportTwoDGV.TabIndex = 0;
            // 
            // report3
            // 
            this.report3.BackColor = System.Drawing.Color.Gainsboro;
            this.report3.Controls.Add(this.label12);
            this.report3.Controls.Add(this.appointmentCountLabel);
            this.report3.Controls.Add(this.customerLabel);
            this.report3.Controls.Add(this.label9);
            this.report3.Controls.Add(this.label8);
            this.report3.Controls.Add(this.generateReport3Button);
            this.report3.Controls.Add(this.customerComboBox);
            this.report3.Controls.Add(this.label4);
            this.report3.Location = new System.Drawing.Point(4, 22);
            this.report3.Name = "report3";
            this.report3.Size = new System.Drawing.Size(613, 255);
            this.report3.TabIndex = 2;
            this.report3.Text = "Number of Appointments by Customer";
            // 
            // appointmentCountLabel
            // 
            this.appointmentCountLabel.AutoSize = true;
            this.appointmentCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentCountLabel.Location = new System.Drawing.Point(477, 144);
            this.appointmentCountLabel.Name = "appointmentCountLabel";
            this.appointmentCountLabel.Size = new System.Drawing.Size(16, 18);
            this.appointmentCountLabel.TabIndex = 13;
            this.appointmentCountLabel.Text = "0";
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerLabel.Location = new System.Drawing.Point(477, 83);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(0, 18);
            this.customerLabel.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(299, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 18);
            this.label9.TabIndex = 11;
            this.label9.Text = "Number of Appointments";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(397, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "Customer";
            // 
            // generateReport3Button
            // 
            this.generateReport3Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.generateReport3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateReport3Button.Location = new System.Drawing.Point(130, 144);
            this.generateReport3Button.Name = "generateReport3Button";
            this.generateReport3Button.Size = new System.Drawing.Size(121, 23);
            this.generateReport3Button.TabIndex = 9;
            this.generateReport3Button.Text = "Generate Report";
            this.generateReport3Button.UseVisualStyleBackColor = false;
            this.generateReport3Button.Click += new System.EventHandler(this.generateReport3Button_Click);
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Items.AddRange(new object[] {
            "Presentation ",
            "Scrum",
            "Review"});
            this.customerComboBox.Location = new System.Drawing.Point(130, 80);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(121, 21);
            this.customerComboBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Customer";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Silver;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(537, 323);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(92, 36);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(205, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Select a user to see their schedule";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(337, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Select the month and appointment type to view the report.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(345, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Select a customer to see their total number of appointments";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(645, 388);
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
            ((System.ComponentModel.ISupportInitialize)(this.reportTwoDGV)).EndInit();
            this.report3.ResumeLayout(false);
            this.report3.PerformLayout();
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
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label appointmentCountLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}
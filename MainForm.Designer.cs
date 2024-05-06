namespace C969_Samuel_McMasters
{
    partial class MainForm
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
            this.customerDGV = new System.Windows.Forms.DataGridView();
            this.customerGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.modifyCustomerButton = new System.Windows.Forms.Button();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.currentMonthRadioButton = new System.Windows.Forms.RadioButton();
            this.currentWeekRadioButton = new System.Windows.Forms.RadioButton();
            this.allAppointmentsRadioButton = new System.Windows.Forms.RadioButton();
            this.calendarFilterLabel = new System.Windows.Forms.Label();
            this.deleteAppointmentButton = new System.Windows.Forms.Button();
            this.modifyAppointmentButton = new System.Windows.Forms.Button();
            this.createAppointmentButton = new System.Windows.Forms.Button();
            this.appointmentDGV = new System.Windows.Forms.DataGridView();
            this.exitButton = new System.Windows.Forms.Button();
            this.loggedInLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.reportsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerDGV)).BeginInit();
            this.customerGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // customerDGV
            // 
            this.customerDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDGV.Location = new System.Drawing.Point(139, 19);
            this.customerDGV.Name = "customerDGV";
            this.customerDGV.Size = new System.Drawing.Size(631, 150);
            this.customerDGV.TabIndex = 0;
            // 
            // customerGroupBox
            // 
            this.customerGroupBox.Controls.Add(this.deleteCustomerButton);
            this.customerGroupBox.Controls.Add(this.modifyCustomerButton);
            this.customerGroupBox.Controls.Add(this.addCustomerButton);
            this.customerGroupBox.Controls.Add(this.customerDGV);
            this.customerGroupBox.Location = new System.Drawing.Point(12, 78);
            this.customerGroupBox.Name = "customerGroupBox";
            this.customerGroupBox.Size = new System.Drawing.Size(776, 237);
            this.customerGroupBox.TabIndex = 1;
            this.customerGroupBox.TabStop = false;
            this.customerGroupBox.Text = "Customer Info";
            this.customerGroupBox.Enter += new System.EventHandler(this.customerGroupBox_Enter);
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.BackColor = System.Drawing.Color.LightCoral;
            this.deleteCustomerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteCustomerButton.Location = new System.Drawing.Point(678, 175);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(92, 36);
            this.deleteCustomerButton.TabIndex = 3;
            this.deleteCustomerButton.Text = "Delete";
            this.deleteCustomerButton.UseVisualStyleBackColor = false;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // modifyCustomerButton
            // 
            this.modifyCustomerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.modifyCustomerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modifyCustomerButton.Location = new System.Drawing.Point(237, 175);
            this.modifyCustomerButton.Name = "modifyCustomerButton";
            this.modifyCustomerButton.Size = new System.Drawing.Size(92, 36);
            this.modifyCustomerButton.TabIndex = 2;
            this.modifyCustomerButton.Text = "Modify Customer";
            this.modifyCustomerButton.UseVisualStyleBackColor = false;
            this.modifyCustomerButton.Click += new System.EventHandler(this.modifyCustomerButton_Click);
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.addCustomerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCustomerButton.Location = new System.Drawing.Point(139, 175);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(92, 36);
            this.addCustomerButton.TabIndex = 1;
            this.addCustomerButton.Text = "Add Customer";
            this.addCustomerButton.UseVisualStyleBackColor = false;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.reportsButton);
            this.groupBox1.Controls.Add(this.currentMonthRadioButton);
            this.groupBox1.Controls.Add(this.currentWeekRadioButton);
            this.groupBox1.Controls.Add(this.allAppointmentsRadioButton);
            this.groupBox1.Controls.Add(this.calendarFilterLabel);
            this.groupBox1.Controls.Add(this.deleteAppointmentButton);
            this.groupBox1.Controls.Add(this.modifyAppointmentButton);
            this.groupBox1.Controls.Add(this.createAppointmentButton);
            this.groupBox1.Controls.Add(this.appointmentDGV);
            this.groupBox1.Location = new System.Drawing.Point(12, 321);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 237);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Appointments";
            // 
            // currentMonthRadioButton
            // 
            this.currentMonthRadioButton.AutoSize = true;
            this.currentMonthRadioButton.Location = new System.Drawing.Point(10, 100);
            this.currentMonthRadioButton.Name = "currentMonthRadioButton";
            this.currentMonthRadioButton.Size = new System.Drawing.Size(92, 17);
            this.currentMonthRadioButton.TabIndex = 8;
            this.currentMonthRadioButton.TabStop = true;
            this.currentMonthRadioButton.Text = "Current Month";
            this.currentMonthRadioButton.UseVisualStyleBackColor = true;
            this.currentMonthRadioButton.CheckedChanged += new System.EventHandler(this.currentMonthRadioButton_CheckedChanged);
            // 
            // currentWeekRadioButton
            // 
            this.currentWeekRadioButton.AutoSize = true;
            this.currentWeekRadioButton.Location = new System.Drawing.Point(11, 77);
            this.currentWeekRadioButton.Name = "currentWeekRadioButton";
            this.currentWeekRadioButton.Size = new System.Drawing.Size(91, 17);
            this.currentWeekRadioButton.TabIndex = 7;
            this.currentWeekRadioButton.TabStop = true;
            this.currentWeekRadioButton.Text = "Current Week";
            this.currentWeekRadioButton.UseVisualStyleBackColor = true;
            this.currentWeekRadioButton.CheckedChanged += new System.EventHandler(this.currentWeekRadioButton_CheckedChanged);
            // 
            // allAppointmentsRadioButton
            // 
            this.allAppointmentsRadioButton.AutoSize = true;
            this.allAppointmentsRadioButton.Location = new System.Drawing.Point(10, 54);
            this.allAppointmentsRadioButton.Name = "allAppointmentsRadioButton";
            this.allAppointmentsRadioButton.Size = new System.Drawing.Size(103, 17);
            this.allAppointmentsRadioButton.TabIndex = 6;
            this.allAppointmentsRadioButton.TabStop = true;
            this.allAppointmentsRadioButton.Text = "All Appointments";
            this.allAppointmentsRadioButton.UseVisualStyleBackColor = true;
            this.allAppointmentsRadioButton.CheckedChanged += new System.EventHandler(this.allAppointmentsRadioButton_CheckedChanged);
            // 
            // calendarFilterLabel
            // 
            this.calendarFilterLabel.AutoSize = true;
            this.calendarFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendarFilterLabel.Location = new System.Drawing.Point(24, 29);
            this.calendarFilterLabel.Name = "calendarFilterLabel";
            this.calendarFilterLabel.Size = new System.Drawing.Size(89, 13);
            this.calendarFilterLabel.TabIndex = 4;
            this.calendarFilterLabel.Text = "Calendar Filter";
            // 
            // deleteAppointmentButton
            // 
            this.deleteAppointmentButton.BackColor = System.Drawing.Color.LightCoral;
            this.deleteAppointmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAppointmentButton.Location = new System.Drawing.Point(678, 175);
            this.deleteAppointmentButton.Name = "deleteAppointmentButton";
            this.deleteAppointmentButton.Size = new System.Drawing.Size(92, 36);
            this.deleteAppointmentButton.TabIndex = 3;
            this.deleteAppointmentButton.Text = "Delete";
            this.deleteAppointmentButton.UseVisualStyleBackColor = false;
            this.deleteAppointmentButton.Click += new System.EventHandler(this.deleteAppointmentButton_Click);
            // 
            // modifyAppointmentButton
            // 
            this.modifyAppointmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.modifyAppointmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modifyAppointmentButton.Location = new System.Drawing.Point(237, 175);
            this.modifyAppointmentButton.Name = "modifyAppointmentButton";
            this.modifyAppointmentButton.Size = new System.Drawing.Size(92, 36);
            this.modifyAppointmentButton.TabIndex = 2;
            this.modifyAppointmentButton.Text = "Modify Appointment";
            this.modifyAppointmentButton.UseVisualStyleBackColor = false;
            this.modifyAppointmentButton.Click += new System.EventHandler(this.modifyAppointmentButton_Click);
            // 
            // createAppointmentButton
            // 
            this.createAppointmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.createAppointmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createAppointmentButton.Location = new System.Drawing.Point(139, 175);
            this.createAppointmentButton.Name = "createAppointmentButton";
            this.createAppointmentButton.Size = new System.Drawing.Size(92, 36);
            this.createAppointmentButton.TabIndex = 1;
            this.createAppointmentButton.Text = "Create Appointment";
            this.createAppointmentButton.UseVisualStyleBackColor = false;
            this.createAppointmentButton.Click += new System.EventHandler(this.createAppointmentButton_Click);
            // 
            // appointmentDGV
            // 
            this.appointmentDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.appointmentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDGV.Location = new System.Drawing.Point(139, 19);
            this.appointmentDGV.Name = "appointmentDGV";
            this.appointmentDGV.Size = new System.Drawing.Size(631, 150);
            this.appointmentDGV.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Silver;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(696, 604);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(92, 36);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // loggedInLabel
            // 
            this.loggedInLabel.AutoSize = true;
            this.loggedInLabel.Location = new System.Drawing.Point(5, 9);
            this.loggedInLabel.Name = "loggedInLabel";
            this.loggedInLabel.Size = new System.Drawing.Size(74, 13);
            this.loggedInLabel.TabIndex = 7;
            this.loggedInLabel.Text = "Logged in as: ";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(79, 9);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(0, 13);
            this.userLabel.TabIndex = 8;
            // 
            // reportsButton
            // 
            this.reportsButton.BackColor = System.Drawing.Color.Silver;
            this.reportsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportsButton.Location = new System.Drawing.Point(21, 175);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(92, 36);
            this.reportsButton.TabIndex = 9;
            this.reportsButton.Text = "View Reports";
            this.reportsButton.UseVisualStyleBackColor = false;
            this.reportsButton.Click += new System.EventHandler(this.reportsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 652);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.loggedInLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customerGroupBox);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduling Assistant ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerDGV)).EndInit();
            this.customerGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox customerGroupBox;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Button modifyCustomerButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button deleteAppointmentButton;
        private System.Windows.Forms.Button modifyAppointmentButton;
        private System.Windows.Forms.Button createAppointmentButton;
        private System.Windows.Forms.Label calendarFilterLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label loggedInLabel;
        private System.Windows.Forms.Label userLabel;
        public System.Windows.Forms.DataGridView customerDGV;
        private System.Windows.Forms.RadioButton allAppointmentsRadioButton;
        private System.Windows.Forms.RadioButton currentMonthRadioButton;
        private System.Windows.Forms.RadioButton currentWeekRadioButton;
        private System.Windows.Forms.DataGridView appointmentDGV;
        private System.Windows.Forms.Button reportsButton;
    }
}


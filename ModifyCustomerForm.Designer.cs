namespace C969_Samuel_McMasters
{
    partial class ModifyCustomerForm
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
            this.zipLabel = new System.Windows.Forms.Label();
            this.modCustomerPostalCodeTextBox = new System.Windows.Forms.TextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.modCustomerPhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.modCustomerCountryTextBox = new System.Windows.Forms.TextBox();
            this.modCustomerCityTextBox = new System.Windows.Forms.TextBox();
            this.modCustomerAddressTextBox = new System.Windows.Forms.TextBox();
            this.modCustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.modCustomerIdTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // zipLabel
            // 
            this.zipLabel.AutoSize = true;
            this.zipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipLabel.Location = new System.Drawing.Point(115, 235);
            this.zipLabel.Name = "zipLabel";
            this.zipLabel.Size = new System.Drawing.Size(26, 16);
            this.zipLabel.TabIndex = 42;
            this.zipLabel.Text = "Zip";
            // 
            // modCustomerPostalCodeTextBox
            // 
            this.modCustomerPostalCodeTextBox.Location = new System.Drawing.Point(173, 234);
            this.modCustomerPostalCodeTextBox.Name = "modCustomerPostalCodeTextBox";
            this.modCustomerPostalCodeTextBox.Size = new System.Drawing.Size(163, 20);
            this.modCustomerPostalCodeTextBox.TabIndex = 41;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.IndianRed;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(380, 407);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 30);
            this.exitButton.TabIndex = 40;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(261, 304);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 30);
            this.saveButton.TabIndex = 39;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // modCustomerPhoneNumberTextBox
            // 
            this.modCustomerPhoneNumberTextBox.Location = new System.Drawing.Point(173, 269);
            this.modCustomerPhoneNumberTextBox.Name = "modCustomerPhoneNumberTextBox";
            this.modCustomerPhoneNumberTextBox.Size = new System.Drawing.Size(163, 20);
            this.modCustomerPhoneNumberTextBox.TabIndex = 37;
            // 
            // modCustomerCountryTextBox
            // 
            this.modCustomerCountryTextBox.Location = new System.Drawing.Point(173, 199);
            this.modCustomerCountryTextBox.Name = "modCustomerCountryTextBox";
            this.modCustomerCountryTextBox.Size = new System.Drawing.Size(163, 20);
            this.modCustomerCountryTextBox.TabIndex = 36;
            // 
            // modCustomerCityTextBox
            // 
            this.modCustomerCityTextBox.Location = new System.Drawing.Point(173, 169);
            this.modCustomerCityTextBox.Name = "modCustomerCityTextBox";
            this.modCustomerCityTextBox.Size = new System.Drawing.Size(163, 20);
            this.modCustomerCityTextBox.TabIndex = 35;
            // 
            // modCustomerAddressTextBox
            // 
            this.modCustomerAddressTextBox.Location = new System.Drawing.Point(173, 134);
            this.modCustomerAddressTextBox.Name = "modCustomerAddressTextBox";
            this.modCustomerAddressTextBox.Size = new System.Drawing.Size(163, 20);
            this.modCustomerAddressTextBox.TabIndex = 34;
            // 
            // modCustomerNameTextBox
            // 
            this.modCustomerNameTextBox.Location = new System.Drawing.Point(173, 101);
            this.modCustomerNameTextBox.Name = "modCustomerNameTextBox";
            this.modCustomerNameTextBox.Size = new System.Drawing.Size(163, 20);
            this.modCustomerNameTextBox.TabIndex = 33;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLabel.Location = new System.Drawing.Point(44, 270);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(97, 16);
            this.phoneLabel.TabIndex = 32;
            this.phoneLabel.Text = "Phone Number";
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLabel.Location = new System.Drawing.Point(89, 200);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(52, 16);
            this.countryLabel.TabIndex = 31;
            this.countryLabel.Text = "Country";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityLabel.Location = new System.Drawing.Point(112, 170);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(29, 16);
            this.cityLabel.TabIndex = 30;
            this.cityLabel.Text = "City";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressLabel.Location = new System.Drawing.Point(83, 135);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(58, 16);
            this.addressLabel.TabIndex = 29;
            this.addressLabel.Text = "Address";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(97, 102);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(44, 16);
            this.nameLabel.TabIndex = 28;
            this.nameLabel.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Customer ID";
            // 
            // modCustomerIdTextBox
            // 
            this.modCustomerIdTextBox.Location = new System.Drawing.Point(173, 74);
            this.modCustomerIdTextBox.Name = "modCustomerIdTextBox";
            this.modCustomerIdTextBox.ReadOnly = true;
            this.modCustomerIdTextBox.Size = new System.Drawing.Size(163, 20);
            this.modCustomerIdTextBox.TabIndex = 44;
            // 
            // ModifyCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 449);
            this.Controls.Add(this.modCustomerIdTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zipLabel);
            this.Controls.Add(this.modCustomerPostalCodeTextBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.modCustomerPhoneNumberTextBox);
            this.Controls.Add(this.modCustomerCountryTextBox);
            this.Controls.Add(this.modCustomerCityTextBox);
            this.Controls.Add(this.modCustomerAddressTextBox);
            this.Controls.Add(this.modCustomerNameTextBox);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "ModifyCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modify Customer";
            this.Load += new System.EventHandler(this.ModifyCustomerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label zipLabel;
        private System.Windows.Forms.TextBox modCustomerPostalCodeTextBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox modCustomerPhoneNumberTextBox;
        private System.Windows.Forms.TextBox modCustomerCountryTextBox;
        private System.Windows.Forms.TextBox modCustomerCityTextBox;
        private System.Windows.Forms.TextBox modCustomerAddressTextBox;
        private System.Windows.Forms.TextBox modCustomerNameTextBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox modCustomerIdTextBox;
    }
}
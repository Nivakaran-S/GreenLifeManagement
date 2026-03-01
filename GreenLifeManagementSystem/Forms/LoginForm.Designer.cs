namespace GreenLifeManagementSystem.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.grpRegister = new System.Windows.Forms.GroupBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.txtRegAddress = new System.Windows.Forms.TextBox();
            this.lblRegAddress = new System.Windows.Forms.Label();
            this.txtRegPassword = new System.Windows.Forms.TextBox();
            this.lblRegPassword = new System.Windows.Forms.Label();
            this.txtRegUsername = new System.Windows.Forms.TextBox();
            this.lblRegUsername = new System.Windows.Forms.Label();
            this.txtRegFullName = new System.Windows.Forms.TextBox();
            this.lblRegFullName = new System.Windows.Forms.Label();
            this.pnlLoginHeader = new System.Windows.Forms.Panel();
            this.lblBrandTitle = new System.Windows.Forms.Label();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.grpLogin.SuspendLayout();
            this.grpRegister.SuspendLayout();
            this.pnlLoginHeader.SuspendLayout();
            this.SuspendLayout();
            this.pnlLoginHeader.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.pnlLoginHeader.Controls.Add(this.lblBrandTitle);
            this.pnlLoginHeader.Controls.Add(this.lblBrandSub);
            this.pnlLoginHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLoginHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlLoginHeader.Name = "pnlLoginHeader";
            this.pnlLoginHeader.Size = new System.Drawing.Size(760, 80);
            this.pnlLoginHeader.TabIndex = 2;
            this.lblBrandTitle.AutoSize = true;
            this.lblBrandTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBrandTitle.ForeColor = System.Drawing.Color.White;
            this.lblBrandTitle.Location = new System.Drawing.Point(15, 10);
            this.lblBrandTitle.Name = "lblBrandTitle";
            this.lblBrandTitle.Size = new System.Drawing.Size(280, 41);
            this.lblBrandTitle.TabIndex = 0;
            this.lblBrandTitle.Text = "\uD83C\uDF3F GreenLife Organic";
            this.lblBrandSub.AutoSize = true;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(200, 230, 201);
            this.lblBrandSub.Location = new System.Drawing.Point(17, 52);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(290, 23);
            this.lblBrandSub.TabIndex = 1;
            this.lblBrandSub.Text = "Fresh. Organic. Sustainable.";
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Controls.Add(this.cmbRole);
            this.grpLogin.Controls.Add(this.lblRole);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Controls.Add(this.lblPassword);
            this.grpLogin.Controls.Add(this.txtUsername);
            this.grpLogin.Controls.Add(this.lblUsername);
            this.grpLogin.Location = new System.Drawing.Point(20, 100);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(350, 250);
            this.grpLogin.TabIndex = 0;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Login";
            this.btnLogin.Location = new System.Drawing.Point(230, 190);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 30);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Customer",
            "Admin"});
            this.cmbRole.Location = new System.Drawing.Point(110, 140);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(220, 28);
            this.cmbRole.TabIndex = 5;
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(20, 145);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(43, 20);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "Role:";
            this.txtPassword.Location = new System.Drawing.Point(110, 90);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(220, 27);
            this.txtPassword.TabIndex = 3;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 95);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 20);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            this.txtUsername.Location = new System.Drawing.Point(110, 40);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(220, 27);
            this.txtUsername.TabIndex = 1;
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(20, 45);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(78, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            this.grpRegister.Controls.Add(this.btnSignUp);
            this.grpRegister.Controls.Add(this.txtRegAddress);
            this.grpRegister.Controls.Add(this.lblRegAddress);
            this.grpRegister.Controls.Add(this.txtRegPassword);
            this.grpRegister.Controls.Add(this.lblRegPassword);
            this.grpRegister.Controls.Add(this.txtRegUsername);
            this.grpRegister.Controls.Add(this.lblRegUsername);
            this.grpRegister.Controls.Add(this.txtRegFullName);
            this.grpRegister.Controls.Add(this.lblRegFullName);
            this.grpRegister.Location = new System.Drawing.Point(390, 100);
            this.grpRegister.Name = "grpRegister";
            this.grpRegister.Size = new System.Drawing.Size(350, 250);
            this.grpRegister.TabIndex = 1;
            this.grpRegister.TabStop = false;
            this.grpRegister.Text = "Register";
            this.btnSignUp.Location = new System.Drawing.Point(230, 190);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(100, 30);
            this.btnSignUp.TabIndex = 8;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            this.txtRegAddress.Location = new System.Drawing.Point(110, 150);
            this.txtRegAddress.Name = "txtRegAddress";
            this.txtRegAddress.Size = new System.Drawing.Size(220, 27);
            this.txtRegAddress.TabIndex = 7;
            this.lblRegAddress.AutoSize = true;
            this.lblRegAddress.Location = new System.Drawing.Point(20, 155);
            this.lblRegAddress.Name = "lblRegAddress";
            this.lblRegAddress.Size = new System.Drawing.Size(65, 20);
            this.lblRegAddress.TabIndex = 6;
            this.lblRegAddress.Text = "Address:";
            this.txtRegPassword.Location = new System.Drawing.Point(110, 110);
            this.txtRegPassword.Name = "txtRegPassword";
            this.txtRegPassword.PasswordChar = '*';
            this.txtRegPassword.Size = new System.Drawing.Size(220, 27);
            this.txtRegPassword.TabIndex = 5;
            this.lblRegPassword.AutoSize = true;
            this.lblRegPassword.Location = new System.Drawing.Point(20, 115);
            this.lblRegPassword.Name = "lblRegPassword";
            this.lblRegPassword.Size = new System.Drawing.Size(73, 20);
            this.lblRegPassword.TabIndex = 4;
            this.lblRegPassword.Text = "Password:";
            this.txtRegUsername.Location = new System.Drawing.Point(110, 70);
            this.txtRegUsername.Name = "txtRegUsername";
            this.txtRegUsername.Size = new System.Drawing.Size(220, 27);
            this.txtRegUsername.TabIndex = 3;
            this.lblRegUsername.AutoSize = true;
            this.lblRegUsername.Location = new System.Drawing.Point(20, 75);
            this.lblRegUsername.Name = "lblRegUsername";
            this.lblRegUsername.Size = new System.Drawing.Size(78, 20);
            this.lblRegUsername.TabIndex = 2;
            this.lblRegUsername.Text = "Username:";
            this.txtRegFullName.Location = new System.Drawing.Point(110, 30);
            this.txtRegFullName.Name = "txtRegFullName";
            this.txtRegFullName.Size = new System.Drawing.Size(220, 27);
            this.txtRegFullName.TabIndex = 1;
            this.lblRegFullName.AutoSize = true;
            this.lblRegFullName.Location = new System.Drawing.Point(20, 35);
            this.lblRegFullName.Name = "lblRegFullName";
            this.lblRegFullName.Size = new System.Drawing.Size(79, 20);
            this.lblRegFullName.TabIndex = 0;
            this.lblRegFullName.Text = "Full Name:";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 380);
            this.Controls.Add(this.grpRegister);
            this.Controls.Add(this.grpLogin);
            this.Controls.Add(this.pnlLoginHeader);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GreenLife Organic - Authentication";
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.grpRegister.ResumeLayout(false);
            this.grpRegister.PerformLayout();
            this.pnlLoginHeader.ResumeLayout(false);
            this.pnlLoginHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.GroupBox grpRegister;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.TextBox txtRegAddress;
        private System.Windows.Forms.Label lblRegAddress;
        private System.Windows.Forms.TextBox txtRegPassword;
        private System.Windows.Forms.Label lblRegPassword;
        private System.Windows.Forms.TextBox txtRegUsername;
        private System.Windows.Forms.Label lblRegUsername;
        private System.Windows.Forms.TextBox txtRegFullName;
        private System.Windows.Forms.Label lblRegFullName;
        private System.Windows.Forms.Panel pnlLoginHeader;
        private System.Windows.Forms.Label lblBrandTitle;
        private System.Windows.Forms.Label lblBrandSub;
    }
}
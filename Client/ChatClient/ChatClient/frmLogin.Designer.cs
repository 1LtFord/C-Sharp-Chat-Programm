namespace ChatClient
{
    partial class frmLogin
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
            this.lblLoggingState = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.ckbxSaveLoginData = new System.Windows.Forms.CheckBox();
            this.tbxPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLoggingState
            // 
            this.lblLoggingState.AutoSize = true;
            this.lblLoggingState.ForeColor = System.Drawing.Color.Gray;
            this.lblLoggingState.Location = new System.Drawing.Point(94, 99);
            this.lblLoggingState.Name = "lblLoggingState";
            this.lblLoggingState.Size = new System.Drawing.Size(60, 13);
            this.lblLoggingState.TabIndex = 13;
            this.lblLoggingState.Text = "Loggin In...";
            this.lblLoggingState.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(197, 50);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // ckbxSaveLoginData
            // 
            this.ckbxSaveLoginData.AutoSize = true;
            this.ckbxSaveLoginData.Checked = true;
            this.ckbxSaveLoginData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbxSaveLoginData.Location = new System.Drawing.Point(67, 79);
            this.ckbxSaveLoginData.Name = "ckbxSaveLoginData";
            this.ckbxSaveLoginData.Size = new System.Drawing.Size(128, 17);
            this.ckbxSaveLoginData.TabIndex = 11;
            this.ckbxSaveLoginData.Text = "Logindaten speichern";
            this.ckbxSaveLoginData.UseVisualStyleBackColor = true;
            // 
            // tbxPwd
            // 
            this.tbxPwd.Location = new System.Drawing.Point(67, 53);
            this.tbxPwd.Name = "tbxPwd";
            this.tbxPwd.Size = new System.Drawing.Size(124, 20);
            this.tbxPwd.TabIndex = 10;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(12, 56);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(53, 13);
            this.lblPwd.TabIndex = 9;
            this.lblPwd.Text = "Passwort:";
            // 
            // tbxUsername
            // 
            this.tbxUsername.Location = new System.Drawing.Point(67, 27);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(124, 20);
            this.tbxUsername.TabIndex = 8;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 30);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(38, 13);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "Name:";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 132);
            this.Controls.Add(this.lblLoggingState);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.ckbxSaveLoginData);
            this.Controls.Add(this.tbxPwd);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.tbxUsername);
            this.Controls.Add(this.lblUsername);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoggingState;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox ckbxSaveLoginData;
        private System.Windows.Forms.TextBox tbxPwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label lblUsername;
    }
}
namespace CSharp_Chatprojekt_Client
{
    partial class FormLogin
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
            this.lblBenutzername = new System.Windows.Forms.Label();
            this.lblPasswort = new System.Windows.Forms.Label();
            this.lplServerpasswort = new System.Windows.Forms.Label();
            this.tbxBenutzername = new System.Windows.Forms.TextBox();
            this.tbxBenutzerPW = new System.Windows.Forms.TextBox();
            this.tbxServerPW = new System.Windows.Forms.TextBox();
            this.lblTextFallsBenoetigt = new System.Windows.Forms.Label();
            this.btnVerbinden = new System.Windows.Forms.Button();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.lblTextServerName = new System.Windows.Forms.Label();
            this.lblvalueServerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBenutzername
            // 
            this.lblBenutzername.AutoSize = true;
            this.lblBenutzername.Location = new System.Drawing.Point(52, 55);
            this.lblBenutzername.Name = "lblBenutzername";
            this.lblBenutzername.Size = new System.Drawing.Size(78, 13);
            this.lblBenutzername.TabIndex = 0;
            this.lblBenutzername.Text = "Benutzername:";
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Location = new System.Drawing.Point(77, 88);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(53, 13);
            this.lblPasswort.TabIndex = 1;
            this.lblPasswort.Text = "Passwort:";
            // 
            // lplServerpasswort
            // 
            this.lplServerpasswort.AutoSize = true;
            this.lplServerpasswort.Location = new System.Drawing.Point(47, 120);
            this.lplServerpasswort.Name = "lplServerpasswort";
            this.lplServerpasswort.Size = new System.Drawing.Size(83, 13);
            this.lplServerpasswort.TabIndex = 2;
            this.lplServerpasswort.Text = "Serverpasswort:";
            // 
            // tbxBenutzername
            // 
            this.tbxBenutzername.Location = new System.Drawing.Point(136, 52);
            this.tbxBenutzername.MaxLength = 16;
            this.tbxBenutzername.Name = "tbxBenutzername";
            this.tbxBenutzername.Size = new System.Drawing.Size(100, 20);
            this.tbxBenutzername.TabIndex = 3;
            // 
            // tbxBenutzerPW
            // 
            this.tbxBenutzerPW.Location = new System.Drawing.Point(136, 85);
            this.tbxBenutzerPW.Name = "tbxBenutzerPW";
            this.tbxBenutzerPW.PasswordChar = '*';
            this.tbxBenutzerPW.Size = new System.Drawing.Size(100, 20);
            this.tbxBenutzerPW.TabIndex = 4;
            // 
            // tbxServerPW
            // 
            this.tbxServerPW.Location = new System.Drawing.Point(136, 117);
            this.tbxServerPW.Name = "tbxServerPW";
            this.tbxServerPW.PasswordChar = '*';
            this.tbxServerPW.Size = new System.Drawing.Size(100, 20);
            this.tbxServerPW.TabIndex = 5;
            // 
            // lblTextFallsBenoetigt
            // 
            this.lblTextFallsBenoetigt.AutoSize = true;
            this.lblTextFallsBenoetigt.Location = new System.Drawing.Point(148, 140);
            this.lblTextFallsBenoetigt.Name = "lblTextFallsBenoetigt";
            this.lblTextFallsBenoetigt.Size = new System.Drawing.Size(78, 13);
            this.lblTextFallsBenoetigt.TabIndex = 6;
            this.lblTextFallsBenoetigt.Text = "( falls benötigt )";
            // 
            // btnVerbinden
            // 
            this.btnVerbinden.Location = new System.Drawing.Point(44, 172);
            this.btnVerbinden.Name = "btnVerbinden";
            this.btnVerbinden.Size = new System.Drawing.Size(75, 23);
            this.btnVerbinden.TabIndex = 7;
            this.btnVerbinden.Text = "Verbinden";
            this.btnVerbinden.UseVisualStyleBackColor = true;
            this.btnVerbinden.Click += new System.EventHandler(this.btnVerbinden_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Location = new System.Drawing.Point(166, 171);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(75, 23);
            this.btnAbbrechen.TabIndex = 8;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // lblTextServerName
            // 
            this.lblTextServerName.AutoSize = true;
            this.lblTextServerName.Location = new System.Drawing.Point(86, 24);
            this.lblTextServerName.Name = "lblTextServerName";
            this.lblTextServerName.Size = new System.Drawing.Size(44, 13);
            this.lblTextServerName.TabIndex = 9;
            this.lblTextServerName.Text = "Server: ";
            // 
            // lblvalueServerName
            // 
            this.lblvalueServerName.AutoSize = true;
            this.lblvalueServerName.Location = new System.Drawing.Point(133, 24);
            this.lblvalueServerName.Name = "lblvalueServerName";
            this.lblvalueServerName.Size = new System.Drawing.Size(10, 13);
            this.lblvalueServerName.TabIndex = 10;
            this.lblvalueServerName.Text = "-";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 213);
            this.Controls.Add(this.lblvalueServerName);
            this.Controls.Add(this.lblTextServerName);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnVerbinden);
            this.Controls.Add(this.lblTextFallsBenoetigt);
            this.Controls.Add(this.tbxServerPW);
            this.Controls.Add(this.tbxBenutzerPW);
            this.Controls.Add(this.tbxBenutzername);
            this.Controls.Add(this.lplServerpasswort);
            this.Controls.Add(this.lblPasswort);
            this.Controls.Add(this.lblBenutzername);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBenutzername;
        private System.Windows.Forms.Label lblPasswort;
        private System.Windows.Forms.Label lplServerpasswort;
        private System.Windows.Forms.TextBox tbxBenutzername;
        private System.Windows.Forms.TextBox tbxBenutzerPW;
        private System.Windows.Forms.TextBox tbxServerPW;
        private System.Windows.Forms.Label lblTextFallsBenoetigt;
        private System.Windows.Forms.Button btnVerbinden;
        private System.Windows.Forms.Button btnAbbrechen;
        private System.Windows.Forms.Label lblTextServerName;
        private System.Windows.Forms.Label lblvalueServerName;
    }
}
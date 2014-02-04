namespace CSharp_Chatprojekt_Client
{
    partial class FormNeueVerbindung
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
            this.tbxIP = new System.Windows.Forms.TextBox();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.tbxBenutzername = new System.Windows.Forms.TextBox();
            this.tbxbenutzerPW = new System.Windows.Forms.TextBox();
            this.tbxServerPW = new System.Windows.Forms.TextBox();
            this.lplIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblServerPW = new System.Windows.Forms.Label();
            this.lblBenutzername = new System.Windows.Forms.Label();
            this.lblPasswort = new System.Windows.Forms.Label();
            this.btnVerbinden = new System.Windows.Forms.Button();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxIP
            // 
            this.tbxIP.Location = new System.Drawing.Point(132, 19);
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.Size = new System.Drawing.Size(100, 20);
            this.tbxIP.TabIndex = 0;
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(132, 46);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(100, 20);
            this.tbxPort.TabIndex = 1;
            // 
            // tbxBenutzername
            // 
            this.tbxBenutzername.Location = new System.Drawing.Point(132, 116);
            this.tbxBenutzername.Name = "tbxBenutzername";
            this.tbxBenutzername.Size = new System.Drawing.Size(100, 20);
            this.tbxBenutzername.TabIndex = 2;
            // 
            // tbxbenutzerPW
            // 
            this.tbxbenutzerPW.Location = new System.Drawing.Point(132, 142);
            this.tbxbenutzerPW.Name = "tbxbenutzerPW";
            this.tbxbenutzerPW.PasswordChar = '*';
            this.tbxbenutzerPW.Size = new System.Drawing.Size(100, 20);
            this.tbxbenutzerPW.TabIndex = 3;
            // 
            // tbxServerPW
            // 
            this.tbxServerPW.Location = new System.Drawing.Point(132, 72);
            this.tbxServerPW.Name = "tbxServerPW";
            this.tbxServerPW.PasswordChar = '*';
            this.tbxServerPW.Size = new System.Drawing.Size(100, 20);
            this.tbxServerPW.TabIndex = 4;
            // 
            // lplIP
            // 
            this.lplIP.AutoSize = true;
            this.lplIP.Location = new System.Drawing.Point(106, 22);
            this.lplIP.Name = "lplIP";
            this.lplIP.Size = new System.Drawing.Size(20, 13);
            this.lplIP.TabIndex = 5;
            this.lplIP.Text = "IP:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(97, 49);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port:";
            // 
            // lblServerPW
            // 
            this.lblServerPW.AutoSize = true;
            this.lblServerPW.Location = new System.Drawing.Point(39, 75);
            this.lblServerPW.Name = "lblServerPW";
            this.lblServerPW.Size = new System.Drawing.Size(87, 13);
            this.lblServerPW.TabIndex = 7;
            this.lblServerPW.Text = "Server Passwort:";
            // 
            // lblBenutzername
            // 
            this.lblBenutzername.AutoSize = true;
            this.lblBenutzername.Location = new System.Drawing.Point(51, 119);
            this.lblBenutzername.Name = "lblBenutzername";
            this.lblBenutzername.Size = new System.Drawing.Size(78, 13);
            this.lblBenutzername.TabIndex = 8;
            this.lblBenutzername.Text = "Benutzername:";
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Location = new System.Drawing.Point(73, 145);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(53, 13);
            this.lblPasswort.TabIndex = 9;
            this.lblPasswort.Text = "Passwort:";
            // 
            // btnVerbinden
            // 
            this.btnVerbinden.Location = new System.Drawing.Point(46, 216);
            this.btnVerbinden.Name = "btnVerbinden";
            this.btnVerbinden.Size = new System.Drawing.Size(75, 23);
            this.btnVerbinden.TabIndex = 10;
            this.btnVerbinden.Text = "Verbinden";
            this.btnVerbinden.UseVisualStyleBackColor = true;
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Location = new System.Drawing.Point(160, 215);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(75, 23);
            this.btnAbbrechen.TabIndex = 11;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // FormNeueVerbindung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnVerbinden);
            this.Controls.Add(this.lblPasswort);
            this.Controls.Add(this.lblBenutzername);
            this.Controls.Add(this.lblServerPW);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lplIP);
            this.Controls.Add(this.tbxServerPW);
            this.Controls.Add(this.tbxbenutzerPW);
            this.Controls.Add(this.tbxBenutzername);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.tbxIP);
            this.Name = "FormNeueVerbindung";
            this.Text = "FormNeueVerbindung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxIP;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.TextBox tbxBenutzername;
        private System.Windows.Forms.TextBox tbxbenutzerPW;
        private System.Windows.Forms.TextBox tbxServerPW;
        private System.Windows.Forms.Label lplIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblServerPW;
        private System.Windows.Forms.Label lblBenutzername;
        private System.Windows.Forms.Label lblPasswort;
        private System.Windows.Forms.Button btnVerbinden;
        private System.Windows.Forms.Button btnAbbrechen;
    }
}
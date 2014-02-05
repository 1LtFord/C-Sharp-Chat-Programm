namespace CSharp_Chatprojekt_Client
{
    partial class FormServerListe
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
            this.lbxServerliste = new System.Windows.Forms.ListBox();
            this.lblTextPing = new System.Windows.Forms.Label();
            this.lblTextMaxClients = new System.Windows.Forms.Label();
            this.lblTextAktuelleClients = new System.Windows.Forms.Label();
            this.btnVerbinden = new System.Windows.Forms.Button();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.lblAktuelleClientsValue = new System.Windows.Forms.Label();
            this.lblMaxClientsValue = new System.Windows.Forms.Label();
            this.lblPingValue = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxServerliste
            // 
            this.lbxServerliste.FormattingEnabled = true;
            this.lbxServerliste.Location = new System.Drawing.Point(12, 12);
            this.lbxServerliste.Name = "lbxServerliste";
            this.lbxServerliste.Size = new System.Drawing.Size(125, 160);
            this.lbxServerliste.TabIndex = 0;
            this.lbxServerliste.SelectedIndexChanged += new System.EventHandler(this.lbxServerliste_SelectedIndexChanged);
            // 
            // lblTextPing
            // 
            this.lblTextPing.AutoSize = true;
            this.lblTextPing.Location = new System.Drawing.Point(217, 76);
            this.lblTextPing.Name = "lblTextPing";
            this.lblTextPing.Size = new System.Drawing.Size(31, 13);
            this.lblTextPing.TabIndex = 1;
            this.lblTextPing.Text = "Ping:";
            // 
            // lblTextMaxClients
            // 
            this.lblTextMaxClients.AutoSize = true;
            this.lblTextMaxClients.Location = new System.Drawing.Point(160, 53);
            this.lblTextMaxClients.Name = "lblTextMaxClients";
            this.lblTextMaxClients.Size = new System.Drawing.Size(88, 13);
            this.lblTextMaxClients.TabIndex = 2;
            this.lblTextMaxClients.Text = "Maximale Clients:";
            // 
            // lblTextAktuelleClients
            // 
            this.lblTextAktuelleClients.AutoSize = true;
            this.lblTextAktuelleClients.Location = new System.Drawing.Point(166, 31);
            this.lblTextAktuelleClients.Name = "lblTextAktuelleClients";
            this.lblTextAktuelleClients.Size = new System.Drawing.Size(82, 13);
            this.lblTextAktuelleClients.TabIndex = 3;
            this.lblTextAktuelleClients.Text = "Aktuelle Clients:";
            // 
            // btnVerbinden
            // 
            this.btnVerbinden.Enabled = false;
            this.btnVerbinden.Location = new System.Drawing.Point(181, 137);
            this.btnVerbinden.Name = "btnVerbinden";
            this.btnVerbinden.Size = new System.Drawing.Size(75, 23);
            this.btnVerbinden.TabIndex = 4;
            this.btnVerbinden.Text = "Verbinden";
            this.btnVerbinden.UseVisualStyleBackColor = true;
            this.btnVerbinden.Click += new System.EventHandler(this.btnVerbinden_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Location = new System.Drawing.Point(262, 137);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(75, 23);
            this.btnAbbrechen.TabIndex = 5;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // lblAktuelleClientsValue
            // 
            this.lblAktuelleClientsValue.AutoSize = true;
            this.lblAktuelleClientsValue.Location = new System.Drawing.Point(254, 31);
            this.lblAktuelleClientsValue.Name = "lblAktuelleClientsValue";
            this.lblAktuelleClientsValue.Size = new System.Drawing.Size(10, 13);
            this.lblAktuelleClientsValue.TabIndex = 7;
            this.lblAktuelleClientsValue.Text = "-";
            // 
            // lblMaxClientsValue
            // 
            this.lblMaxClientsValue.AutoSize = true;
            this.lblMaxClientsValue.Location = new System.Drawing.Point(254, 53);
            this.lblMaxClientsValue.Name = "lblMaxClientsValue";
            this.lblMaxClientsValue.Size = new System.Drawing.Size(10, 13);
            this.lblMaxClientsValue.TabIndex = 8;
            this.lblMaxClientsValue.Text = "-";
            // 
            // lblPingValue
            // 
            this.lblPingValue.AutoSize = true;
            this.lblPingValue.Location = new System.Drawing.Point(254, 76);
            this.lblPingValue.Name = "lblPingValue";
            this.lblPingValue.Size = new System.Drawing.Size(10, 13);
            this.lblPingValue.TabIndex = 9;
            this.lblPingValue.Text = "-";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.ForeColor = System.Drawing.Color.Red;
            this.lblServerStatus.Location = new System.Drawing.Point(254, 98);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(35, 13);
            this.lblServerStatus.TabIndex = 10;
            this.lblServerStatus.Text = "offline";
            // 
            // FormServerListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 184);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.lblPingValue);
            this.Controls.Add(this.lblMaxClientsValue);
            this.Controls.Add(this.lblAktuelleClientsValue);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnVerbinden);
            this.Controls.Add(this.lblTextAktuelleClients);
            this.Controls.Add(this.lblTextMaxClients);
            this.Controls.Add(this.lblTextPing);
            this.Controls.Add(this.lbxServerliste);
            this.Name = "FormServerListe";
            this.Text = "Server Liste";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxServerliste;
        private System.Windows.Forms.Label lblTextPing;
        private System.Windows.Forms.Label lblTextMaxClients;
        private System.Windows.Forms.Label lblTextAktuelleClients;
        private System.Windows.Forms.Button btnVerbinden;
        private System.Windows.Forms.Button btnAbbrechen;
        private System.Windows.Forms.Label lblAktuelleClientsValue;
        private System.Windows.Forms.Label lblMaxClientsValue;
        private System.Windows.Forms.Label lblPingValue;
        private System.Windows.Forms.Label lblServerStatus;
    }
}
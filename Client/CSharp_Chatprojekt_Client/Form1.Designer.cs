namespace CSharp_Chatprojekt_Client
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxUserliste = new System.Windows.Forms.ListBox();
            this.btnSenden = new System.Windows.Forms.Button();
            this.rtbNachrichten = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmVerbindung = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVerbinden = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrennen = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxUserliste
            // 
            this.lbxUserliste.BackColor = System.Drawing.SystemColors.Menu;
            this.lbxUserliste.FormattingEnabled = true;
            this.lbxUserliste.Location = new System.Drawing.Point(379, 27);
            this.lbxUserliste.Name = "lbxUserliste";
            this.lbxUserliste.Size = new System.Drawing.Size(120, 329);
            this.lbxUserliste.TabIndex = 1;
            // 
            // btnSenden
            // 
            this.btnSenden.Location = new System.Drawing.Point(379, 365);
            this.btnSenden.Name = "btnSenden";
            this.btnSenden.Size = new System.Drawing.Size(120, 63);
            this.btnSenden.TabIndex = 3;
            this.btnSenden.Text = "Senden";
            this.btnSenden.UseVisualStyleBackColor = true;
            // 
            // rtbNachrichten
            // 
            this.rtbNachrichten.BackColor = System.Drawing.Color.White;
            this.rtbNachrichten.Location = new System.Drawing.Point(12, 27);
            this.rtbNachrichten.Name = "rtbNachrichten";
            this.rtbNachrichten.ReadOnly = true;
            this.rtbNachrichten.Size = new System.Drawing.Size(361, 329);
            this.rtbNachrichten.TabIndex = 4;
            this.rtbNachrichten.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVerbindung});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(511, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmVerbindung
            // 
            this.tsmVerbindung.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVerbinden,
            this.tsmiTrennen});
            this.tsmVerbindung.Name = "tsmVerbindung";
            this.tsmVerbindung.Size = new System.Drawing.Size(81, 20);
            this.tsmVerbindung.Text = "Verbindung";
            // 
            // tsmiVerbinden
            // 
            this.tsmiVerbinden.Name = "tsmiVerbinden";
            this.tsmiVerbinden.Size = new System.Drawing.Size(152, 22);
            this.tsmiVerbinden.Text = "Verbinden";
            // 
            // tsmiTrennen
            // 
            this.tsmiTrennen.Name = "tsmiTrennen";
            this.tsmiTrennen.Size = new System.Drawing.Size(152, 22);
            this.tsmiTrennen.Text = "Trennen";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 362);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(361, 66);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 440);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.rtbNachrichten);
            this.Controls.Add(this.btnSenden);
            this.Controls.Add(this.lbxUserliste);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxUserliste;
        private System.Windows.Forms.Button btnSenden;
        private System.Windows.Forms.RichTextBox rtbNachrichten;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmVerbindung;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerbinden;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrennen;
        private System.Windows.Forms.RichTextBox richTextBox1;

    }
}


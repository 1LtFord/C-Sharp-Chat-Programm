namespace ChatClient
{
    partial class frmMainWindow
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
            this.sc1 = new System.Windows.Forms.SplitContainer();
            this.sc2 = new System.Windows.Forms.SplitContainer();
            this.rtbMsgLog = new System.Windows.Forms.RichTextBox();
            this.lbxUserList = new System.Windows.Forms.ListBox();
            this.rtbSendMsg = new System.Windows.Forms.RichTextBox();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.stmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAction = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowServerlist = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuickConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.sblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.sblLoginStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.sc3 = new System.Windows.Forms.SplitContainer();
            this.btnSendMsg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).BeginInit();
            this.sc1.Panel1.SuspendLayout();
            this.sc1.Panel2.SuspendLayout();
            this.sc1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc2)).BeginInit();
            this.sc2.Panel1.SuspendLayout();
            this.sc2.Panel2.SuspendLayout();
            this.sc2.SuspendLayout();
            this.MenuBar.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc3)).BeginInit();
            this.sc3.Panel1.SuspendLayout();
            this.sc3.Panel2.SuspendLayout();
            this.sc3.SuspendLayout();
            this.SuspendLayout();
            // 
            // sc1
            // 
            this.sc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc1.IsSplitterFixed = true;
            this.sc1.Location = new System.Drawing.Point(0, 24);
            this.sc1.Name = "sc1";
            this.sc1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc1.Panel1
            // 
            this.sc1.Panel1.Controls.Add(this.sc2);
            // 
            // sc1.Panel2
            // 
            this.sc1.Panel2.Controls.Add(this.sc3);
            this.sc1.Size = new System.Drawing.Size(624, 418);
            this.sc1.SplitterDistance = 298;
            this.sc1.TabIndex = 0;
            // 
            // sc2
            // 
            this.sc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc2.IsSplitterFixed = true;
            this.sc2.Location = new System.Drawing.Point(0, 0);
            this.sc2.Name = "sc2";
            // 
            // sc2.Panel1
            // 
            this.sc2.Panel1.Controls.Add(this.rtbMsgLog);
            // 
            // sc2.Panel2
            // 
            this.sc2.Panel2.Controls.Add(this.lbxUserList);
            this.sc2.Size = new System.Drawing.Size(624, 298);
            this.sc2.SplitterDistance = 479;
            this.sc2.TabIndex = 0;
            // 
            // rtbMsgLog
            // 
            this.rtbMsgLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMsgLog.Location = new System.Drawing.Point(0, 0);
            this.rtbMsgLog.Name = "rtbMsgLog";
            this.rtbMsgLog.ReadOnly = true;
            this.rtbMsgLog.Size = new System.Drawing.Size(479, 298);
            this.rtbMsgLog.TabIndex = 0;
            this.rtbMsgLog.Text = "";
            // 
            // lbxUserList
            // 
            this.lbxUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxUserList.FormattingEnabled = true;
            this.lbxUserList.Location = new System.Drawing.Point(0, 0);
            this.lbxUserList.Name = "lbxUserList";
            this.lbxUserList.Size = new System.Drawing.Size(141, 298);
            this.lbxUserList.TabIndex = 0;
            // 
            // rtbSendMsg
            // 
            this.rtbSendMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSendMsg.Location = new System.Drawing.Point(0, 0);
            this.rtbSendMsg.Name = "rtbSendMsg";
            this.rtbSendMsg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbSendMsg.Size = new System.Drawing.Size(479, 116);
            this.rtbSendMsg.TabIndex = 0;
            this.rtbSendMsg.Text = "";
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stmiFile,
            this.bearbeitenToolStripMenuItem,
            this.ansichtToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.tsmiAction,
            this.hilfeToolStripMenuItem});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(624, 24);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "Menüleiste";
            // 
            // stmiFile
            // 
            this.stmiFile.Name = "stmiFile";
            this.stmiFile.Size = new System.Drawing.Size(46, 20);
            this.stmiFile.Text = "Datei";
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // tsmiAction
            // 
            this.tsmiAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowServerlist,
            this.tsmiQuickConnect,
            this.tsmiDisconnect,
            this.tsmiLogin,
            this.tsmiLogout});
            this.tsmiAction.Name = "tsmiAction";
            this.tsmiAction.Size = new System.Drawing.Size(57, 20);
            this.tsmiAction.Text = " Aktion";
            // 
            // tsmiShowServerlist
            // 
            this.tsmiShowServerlist.Name = "tsmiShowServerlist";
            this.tsmiShowServerlist.Size = new System.Drawing.Size(180, 22);
            this.tsmiShowServerlist.Text = "Serverliste anzeigen";
            this.tsmiShowServerlist.Click += new System.EventHandler(this.tsmiShowServerlist_Click);
            // 
            // tsmiQuickConnect
            // 
            this.tsmiQuickConnect.Name = "tsmiQuickConnect";
            this.tsmiQuickConnect.Size = new System.Drawing.Size(180, 22);
            this.tsmiQuickConnect.Text = "Quick Connect";
            this.tsmiQuickConnect.Click += new System.EventHandler(this.tsmiQuickConnect_Click);
            // 
            // tsmiDisconnect
            // 
            this.tsmiDisconnect.Enabled = false;
            this.tsmiDisconnect.Name = "tsmiDisconnect";
            this.tsmiDisconnect.Size = new System.Drawing.Size(180, 22);
            this.tsmiDisconnect.Text = "Verbindung trennen";
            this.tsmiDisconnect.Click += new System.EventHandler(this.tsmiDisconnect_Click);
            // 
            // tsmiLogin
            // 
            this.tsmiLogin.Enabled = false;
            this.tsmiLogin.Name = "tsmiLogin";
            this.tsmiLogin.Size = new System.Drawing.Size(180, 22);
            this.tsmiLogin.Text = "Login";
            // 
            // tsmiLogout
            // 
            this.tsmiLogout.Enabled = false;
            this.tsmiLogout.Name = "tsmiLogout";
            this.tsmiLogout.Size = new System.Drawing.Size(180, 22);
            this.tsmiLogout.Text = "Logout";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sblConnectionStatus,
            this.sblLoginStatus});
            this.StatusBar.Location = new System.Drawing.Point(0, 420);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(624, 22);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "statusStrip1";
            // 
            // sblConnectionStatus
            // 
            this.sblConnectionStatus.Name = "sblConnectionStatus";
            this.sblConnectionStatus.Size = new System.Drawing.Size(101, 17);
            this.sblConnectionStatus.Text = "ConnectionStatus";
            this.sblConnectionStatus.Visible = false;
            // 
            // sblLoginStatus
            // 
            this.sblLoginStatus.Name = "sblLoginStatus";
            this.sblLoginStatus.Size = new System.Drawing.Size(69, 17);
            this.sblLoginStatus.Text = "LoginStatus";
            this.sblLoginStatus.Visible = false;
            // 
            // sc3
            // 
            this.sc3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc3.Location = new System.Drawing.Point(0, 0);
            this.sc3.Name = "sc3";
            // 
            // sc3.Panel1
            // 
            this.sc3.Panel1.Controls.Add(this.rtbSendMsg);
            // 
            // sc3.Panel2
            // 
            this.sc3.Panel2.Controls.Add(this.btnSendMsg);
            this.sc3.Size = new System.Drawing.Size(624, 116);
            this.sc3.SplitterDistance = 479;
            this.sc3.TabIndex = 1;
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendMsg.Location = new System.Drawing.Point(0, 0);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(141, 116);
            this.btnSendMsg.TabIndex = 0;
            this.btnSendMsg.Text = "Senden";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            // 
            // frmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.sc1);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "frmMainWindow";
            this.Text = "frmMainWindow";
            this.sc1.Panel1.ResumeLayout(false);
            this.sc1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).EndInit();
            this.sc1.ResumeLayout(false);
            this.sc2.Panel1.ResumeLayout(false);
            this.sc2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc2)).EndInit();
            this.sc2.ResumeLayout(false);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.sc3.Panel1.ResumeLayout(false);
            this.sc3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc3)).EndInit();
            this.sc3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer sc1;
        private System.Windows.Forms.SplitContainer sc2;
        private System.Windows.Forms.RichTextBox rtbMsgLog;
        private System.Windows.Forms.ListBox lbxUserList;
        private System.Windows.Forms.RichTextBox rtbSendMsg;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem stmiFile;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAction;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowServerlist;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuickConnect;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisconnect;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogin;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogout;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel sblConnectionStatus;
        private System.Windows.Forms.ToolStripStatusLabel sblLoginStatus;
        private System.Windows.Forms.SplitContainer sc3;
        private System.Windows.Forms.Button btnSendMsg;
    }
}
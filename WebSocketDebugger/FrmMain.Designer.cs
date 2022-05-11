namespace WebSocketDebugger
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.txtWebSocketUri = new System.Windows.Forms.TextBox();
            this.btnWsControl = new System.Windows.Forms.Button();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colTime = new System.Windows.Forms.ColumnHeader();
            this.colDirection = new System.Windows.Forms.ColumnHeader();
            this.colContent = new System.Windows.Forms.ColumnHeader();
            this.menuHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.ss2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAll2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNot2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNone2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTemp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuUseTemp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteTemp = new System.Windows.Forms.ToolStripMenuItem();
            this.ss1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNot = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNone = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvTemplates = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colMessage = new System.Windows.Forms.ColumnHeader();
            this.chkKeepMessage = new System.Windows.Forms.CheckBox();
            this.btnJsonFormat = new System.Windows.Forms.Button();
            this.btnJsonCompress = new System.Windows.Forms.Button();
            this.btnSaveTemp = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBoxHistory = new System.Windows.Forms.GroupBox();
            this.menuHistory.SuspendLayout();
            this.menuTemp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWebSocketUri
            // 
            this.txtWebSocketUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebSocketUri.Location = new System.Drawing.Point(12, 12);
            this.txtWebSocketUri.Name = "txtWebSocketUri";
            this.txtWebSocketUri.PlaceholderText = "ws://1270.0.0.1:80/ws";
            this.txtWebSocketUri.Size = new System.Drawing.Size(438, 23);
            this.txtWebSocketUri.TabIndex = 0;
            // 
            // btnWsControl
            // 
            this.btnWsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWsControl.Location = new System.Drawing.Point(526, 12);
            this.btnWsControl.Name = "btnWsControl";
            this.btnWsControl.Size = new System.Drawing.Size(102, 23);
            this.btnWsControl.TabIndex = 9;
            this.btnWsControl.TabStop = false;
            this.btnWsControl.Text = "&C. 打开连接";
            this.btnWsControl.Click += new System.EventHandler(this.BtnWsControl_Click);
            // 
            // lvHistory
            // 
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colTime,
            this.colDirection,
            this.colContent});
            this.lvHistory.ContextMenuStrip = this.menuHistory;
            this.lvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvHistory.Location = new System.Drawing.Point(3, 19);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(613, 218);
            this.lvHistory.TabIndex = 4;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.DoubleClick += new System.EventHandler(this.MenuDetail_Click);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 40;
            // 
            // colTime
            // 
            this.colTime.Text = "时间";
            this.colTime.Width = 120;
            // 
            // colDirection
            // 
            this.colDirection.Text = "方向";
            this.colDirection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDirection.Width = 40;
            // 
            // colContent
            // 
            this.colContent.Text = "消息正文";
            this.colContent.Width = 600;
            // 
            // menuHistory
            // 
            this.menuHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDetail,
            this.menuClear,
            this.ss2,
            this.menuAll2,
            this.menuNot2,
            this.menuNone2});
            this.menuHistory.Name = "menuHistory";
            this.menuHistory.Size = new System.Drawing.Size(141, 120);
            this.menuHistory.Opening += new System.ComponentModel.CancelEventHandler(this.MenuHistory_Opening);
            // 
            // menuDetail
            // 
            this.menuDetail.Name = "menuDetail";
            this.menuDetail.Size = new System.Drawing.Size(140, 22);
            this.menuDetail.Text = "&D. 查看详情";
            this.menuDetail.Click += new System.EventHandler(this.MenuDetail_Click);
            // 
            // menuClear
            // 
            this.menuClear.Name = "menuClear";
            this.menuClear.Size = new System.Drawing.Size(140, 22);
            this.menuClear.Text = "&C. 清空记录";
            this.menuClear.Click += new System.EventHandler(this.MenuClear_Click);
            // 
            // ss2
            // 
            this.ss2.Name = "ss2";
            this.ss2.Size = new System.Drawing.Size(137, 6);
            // 
            // menuAll2
            // 
            this.menuAll2.Name = "menuAll2";
            this.menuAll2.Size = new System.Drawing.Size(140, 22);
            this.menuAll2.Text = "&A. 全选";
            this.menuAll2.Click += new System.EventHandler(this.MenuAll2_Click);
            // 
            // menuNot2
            // 
            this.menuNot2.Name = "menuNot2";
            this.menuNot2.Size = new System.Drawing.Size(140, 22);
            this.menuNot2.Text = "&F. 反选";
            this.menuNot2.Click += new System.EventHandler(this.MenuNot2_Click);
            // 
            // menuNone2
            // 
            this.menuNone2.Name = "menuNone2";
            this.menuNone2.Size = new System.Drawing.Size(140, 22);
            this.menuNone2.Text = "&N. 全不选";
            this.menuNone2.Click += new System.EventHandler(this.MenuNone2_Click);
            // 
            // menuTemp
            // 
            this.menuTemp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUseTemp,
            this.menuDeleteTemp,
            this.ss1,
            this.menuAll,
            this.menuNot,
            this.menuNone});
            this.menuTemp.Name = "menuTemp";
            this.menuTemp.Size = new System.Drawing.Size(141, 120);
            this.menuTemp.Opening += new System.ComponentModel.CancelEventHandler(this.MenuTemp_Opening);
            // 
            // menuUseTemp
            // 
            this.menuUseTemp.Name = "menuUseTemp";
            this.menuUseTemp.Size = new System.Drawing.Size(140, 22);
            this.menuUseTemp.Text = "&U. 套用模板";
            this.menuUseTemp.Click += new System.EventHandler(this.MenuUseTemp_Click);
            // 
            // menuDeleteTemp
            // 
            this.menuDeleteTemp.Name = "menuDeleteTemp";
            this.menuDeleteTemp.Size = new System.Drawing.Size(140, 22);
            this.menuDeleteTemp.Text = "&D. 删除模板";
            this.menuDeleteTemp.Click += new System.EventHandler(this.MenuDeleteTemp_Click);
            // 
            // ss1
            // 
            this.ss1.Name = "ss1";
            this.ss1.Size = new System.Drawing.Size(137, 6);
            // 
            // menuAll
            // 
            this.menuAll.Name = "menuAll";
            this.menuAll.Size = new System.Drawing.Size(140, 22);
            this.menuAll.Text = "&A. 全选";
            this.menuAll.Click += new System.EventHandler(this.MenuAll_Click);
            // 
            // menuNot
            // 
            this.menuNot.Name = "menuNot";
            this.menuNot.Size = new System.Drawing.Size(140, 22);
            this.menuNot.Text = "&F. 反选";
            this.menuNot.Click += new System.EventHandler(this.MenuNot_Click);
            // 
            // menuNone
            // 
            this.menuNone.Name = "menuNone";
            this.menuNone.Size = new System.Drawing.Size(140, 22);
            this.menuNone.Text = "&N. 全不选";
            this.menuNone.Click += new System.EventHandler(this.MenuNone_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 208);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送消息";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 19);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvTemplates);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkKeepMessage);
            this.splitContainer1.Panel2.Controls.Add(this.btnJsonFormat);
            this.splitContainer1.Panel2.Controls.Add(this.btnJsonCompress);
            this.splitContainer1.Panel2.Controls.Add(this.btnSaveTemp);
            this.splitContainer1.Panel2.Controls.Add(this.btnSend);
            this.splitContainer1.Panel2.Controls.Add(this.txtName);
            this.splitContainer1.Panel2.Controls.Add(this.txtMessage);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(613, 186);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.TabIndex = 2;
            // 
            // lvTemplates
            // 
            this.lvTemplates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colMessage});
            this.lvTemplates.ContextMenuStrip = this.menuTemp;
            this.lvTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTemplates.FullRowSelect = true;
            this.lvTemplates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTemplates.Location = new System.Drawing.Point(0, 0);
            this.lvTemplates.Name = "lvTemplates";
            this.lvTemplates.Size = new System.Drawing.Size(276, 186);
            this.lvTemplates.TabIndex = 3;
            this.lvTemplates.UseCompatibleStateImageBehavior = false;
            this.lvTemplates.View = System.Windows.Forms.View.Details;
            this.lvTemplates.DoubleClick += new System.EventHandler(this.MenuUseTemp_Click);
            // 
            // colName
            // 
            this.colName.Text = "模板名称";
            this.colName.Width = 120;
            // 
            // colMessage
            // 
            this.colMessage.Text = "消息正文";
            this.colMessage.Width = 600;
            // 
            // chkKeepMessage
            // 
            this.chkKeepMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkKeepMessage.AutoSize = true;
            this.chkKeepMessage.Location = new System.Drawing.Point(238, 110);
            this.chkKeepMessage.Name = "chkKeepMessage";
            this.chkKeepMessage.Size = new System.Drawing.Size(90, 21);
            this.chkKeepMessage.TabIndex = 10;
            this.chkKeepMessage.Text = "&K. 保留消息";
            this.chkKeepMessage.UseVisualStyleBackColor = true;
            // 
            // btnJsonFormat
            // 
            this.btnJsonFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJsonFormat.Location = new System.Drawing.Point(234, 68);
            this.btnJsonFormat.Name = "btnJsonFormat";
            this.btnJsonFormat.Size = new System.Drawing.Size(99, 28);
            this.btnJsonFormat.TabIndex = 9;
            this.btnJsonFormat.TabStop = false;
            this.btnJsonFormat.Text = "&F. JSON格式化";
            this.btnJsonFormat.UseVisualStyleBackColor = true;
            this.btnJsonFormat.Click += new System.EventHandler(this.BtnJsonFormat_Click);
            // 
            // btnJsonCompress
            // 
            this.btnJsonCompress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJsonCompress.Location = new System.Drawing.Point(234, 34);
            this.btnJsonCompress.Name = "btnJsonCompress";
            this.btnJsonCompress.Size = new System.Drawing.Size(99, 28);
            this.btnJsonCompress.TabIndex = 9;
            this.btnJsonCompress.TabStop = false;
            this.btnJsonCompress.Text = "&J. JSON压缩";
            this.btnJsonCompress.UseVisualStyleBackColor = true;
            this.btnJsonCompress.Click += new System.EventHandler(this.BtnJsonCompress_Click);
            // 
            // btnSaveTemp
            // 
            this.btnSaveTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveTemp.Location = new System.Drawing.Point(234, 0);
            this.btnSaveTemp.Name = "btnSaveTemp";
            this.btnSaveTemp.Size = new System.Drawing.Size(99, 28);
            this.btnSaveTemp.TabIndex = 9;
            this.btnSaveTemp.TabStop = false;
            this.btnSaveTemp.Text = "&T. 保存模板";
            this.btnSaveTemp.UseVisualStyleBackColor = true;
            this.btnSaveTemp.Click += new System.EventHandler(this.BtnSaveTemp_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(234, 137);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(99, 49);
            this.btnSend.TabIndex = 9;
            this.btnSend.TabStop = false;
            this.btnSend.Text = "&S. 发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(2, 0);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "模板名称";
            this.txtName.Size = new System.Drawing.Size(226, 23);
            this.txtName.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(1, 29);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PlaceholderText = "消息正文";
            this.txtMessage.Size = new System.Drawing.Size(227, 158);
            this.txtMessage.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer2.Panel1.Controls.Add(this.btnWsControl);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.txtWebSocketUri);
            this.splitContainer2.Panel1MinSize = 250;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBoxHistory);
            this.splitContainer2.Panel2MinSize = 150;
            this.splitContainer2.Size = new System.Drawing.Size(643, 500);
            this.splitContainer2.SplitterDistance = 250;
            this.splitContainer2.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(456, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 23);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "已断开";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxHistory
            // 
            this.groupBoxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxHistory.Controls.Add(this.lvHistory);
            this.groupBoxHistory.Location = new System.Drawing.Point(12, 3);
            this.groupBoxHistory.Name = "groupBoxHistory";
            this.groupBoxHistory.Size = new System.Drawing.Size(619, 240);
            this.groupBoxHistory.TabIndex = 0;
            this.groupBoxHistory.TabStop = false;
            this.groupBoxHistory.Text = "历史记录";
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 500);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebSocket 调试工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuHistory.ResumeLayout(false);
            this.menuTemp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtWebSocketUri;
        private Button btnWsControl;
        private ListView lvHistory;
        private ColumnHeader colID;
        private ColumnHeader colTime;
        private ColumnHeader colContent;
        private GroupBox groupBox1;
        private SplitContainer splitContainer1;
        private ListView lvTemplates;
        private ColumnHeader colName;
        private ColumnHeader colMessage;
        private TextBox txtName;
        private TextBox txtMessage;
        private Button btnSend;
        private SplitContainer splitContainer2;
        private GroupBox groupBoxHistory;
        private Button btnSaveTemp;
        private Button btnJsonFormat;
        private Button btnJsonCompress;
        private CheckBox chkKeepMessage;
        private Label lblStatus;
        private ContextMenuStrip menuTemp;
        private ToolStripMenuItem menuUseTemp;
        private ToolStripMenuItem menuDeleteTemp;
        private ContextMenuStrip menuHistory;
        private ToolStripMenuItem menuDetail;
        private ToolStripMenuItem menuClear;
        private ColumnHeader colDirection;
        private ToolStripSeparator ss1;
        private ToolStripMenuItem menuAll;
        private ToolStripMenuItem menuNot;
        private ToolStripMenuItem menuNone;
        private ToolStripSeparator ss2;
        private ToolStripMenuItem menuAll2;
        private ToolStripMenuItem menuNot2;
        private ToolStripMenuItem menuNone2;
    }
}

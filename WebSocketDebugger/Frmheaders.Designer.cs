namespace WebSocketDebugger
{
    partial class FrmHeaders
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
            this.components = new System.ComponentModel.Container();
            this.lvHeaders = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colValue = new System.Windows.Forms.ColumnHeader();
            this.menuHeaders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ss1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNot = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNone = new System.Windows.Forms.ToolStripMenuItem();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHeaders.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvHeaders
            // 
            this.lvHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colValue});
            this.lvHeaders.ContextMenuStrip = this.menuHeaders;
            this.lvHeaders.FullRowSelect = true;
            this.lvHeaders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvHeaders.Location = new System.Drawing.Point(12, 12);
            this.lvHeaders.Name = "lvHeaders";
            this.lvHeaders.Size = new System.Drawing.Size(370, 197);
            this.lvHeaders.TabIndex = 0;
            this.lvHeaders.UseCompatibleStateImageBehavior = false;
            this.lvHeaders.View = System.Windows.Forms.View.Details;
            this.lvHeaders.DoubleClick += new System.EventHandler(this.menuEdit_Click);
            // 
            // colName
            // 
            this.colName.Text = "名称";
            this.colName.Width = 120;
            // 
            // colValue
            // 
            this.colValue.Text = "值";
            this.colValue.Width = 240;
            // 
            // menuHeaders
            // 
            this.menuHeaders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit,
            this.menuDelete,
            this.ss1,
            this.menuAll,
            this.menuNot,
            this.menuNone});
            this.menuHeaders.Name = "menuHeaders";
            this.menuHeaders.Size = new System.Drawing.Size(141, 120);
            this.menuHeaders.Opening += new System.ComponentModel.CancelEventHandler(this.MenuHeaders_Opening);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(180, 22);
            this.menuDelete.Text = "&D. 删除选中";
            this.menuDelete.Click += new System.EventHandler(this.MenuDelete_Click);
            // 
            // ss1
            // 
            this.ss1.Name = "ss1";
            this.ss1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuAll
            // 
            this.menuAll.Name = "menuAll";
            this.menuAll.Size = new System.Drawing.Size(180, 22);
            this.menuAll.Text = "&A. 全选";
            this.menuAll.Click += new System.EventHandler(this.MenuAll_Click);
            // 
            // menuNot
            // 
            this.menuNot.Name = "menuNot";
            this.menuNot.Size = new System.Drawing.Size(180, 22);
            this.menuNot.Text = "&N. 反选";
            this.menuNot.Click += new System.EventHandler(this.MenuNot_Click);
            // 
            // menuNone
            // 
            this.menuNone.Name = "menuNone";
            this.menuNone.Size = new System.Drawing.Size(180, 22);
            this.menuNone.Text = "&F. 全不选";
            this.menuNone.Click += new System.EventHandler(this.MenuNone_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(60, 215);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(322, 23);
            this.txtName.TabIndex = 1;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(60, 244);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(252, 88);
            this.txtValue.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称 &N";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "值 &V";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(318, 244);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 88);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "&E. 修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(145, 104);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(180, 22);
            this.menuEdit.Text = "&E. 编辑选中";
            this.menuEdit.Click += new System.EventHandler(this.menuEdit_Click);
            // 
            // FrmHeaders
            // 
            this.AcceptButton = this.btnEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(394, 345);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lvHeaders);
            this.Controls.Add(this.btnClose);
            this.Name = "FrmHeaders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Headers 编辑器";
            this.Load += new System.EventHandler(this.Frmheaders_Load);
            this.menuHeaders.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lvHeaders;
        private ColumnHeader colName;
        private ColumnHeader colValue;
        private TextBox txtName;
        private TextBox txtValue;
        private Label label1;
        private Label label2;
        private Button btnEdit;
        private Button btnClose;
        private ContextMenuStrip menuHeaders;
        private ToolStripMenuItem menuDelete;
        private ToolStripSeparator ss1;
        private ToolStripMenuItem menuAll;
        private ToolStripMenuItem menuNone;
        private ToolStripMenuItem menuNot;
        private ToolStripMenuItem menuEdit;
    }
}

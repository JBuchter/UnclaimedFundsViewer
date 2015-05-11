namespace UnclaimedFundsViewer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerDetail = new System.Windows.Forms.SplitContainer();
            this.groupBoxDetail = new System.Windows.Forms.GroupBox();
            this.dataGridViewDetail = new System.Windows.Forms.DataGridView();
            this.toolStripPaging = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBackward = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFirst = new System.Windows.Forms.ToolStripButton();
            this.lblPaging = new System.Windows.Forms.ToolStripLabel();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.bnSearch = new System.Windows.Forms.Button();
            this.groupBoxMatch = new System.Windows.Forms.GroupBox();
            this.dataGridViewMatch = new System.Windows.Forms.DataGridView();
            this.menuStripMatch = new System.Windows.Forms.MenuStrip();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetail)).BeginInit();
            this.splitContainerDetail.Panel1.SuspendLayout();
            this.splitContainerDetail.Panel2.SuspendLayout();
            this.splitContainerDetail.SuspendLayout();
            this.groupBoxDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.toolStripPaging.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatch)).BeginInit();
            this.menuStripMatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStripMain.Location = new System.Drawing.Point(0, 445);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(825, 22);
            this.statusStripMain.TabIndex = 0;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerDetail);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.groupBoxMatch);
            this.splitContainerMain.Size = new System.Drawing.Size(825, 445);
            this.splitContainerMain.SplitterDistance = 238;
            this.splitContainerMain.TabIndex = 1;
            // 
            // splitContainerDetail
            // 
            this.splitContainerDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDetail.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerDetail.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDetail.Name = "splitContainerDetail";
            // 
            // splitContainerDetail.Panel1
            // 
            this.splitContainerDetail.Panel1.Controls.Add(this.groupBoxDetail);
            // 
            // splitContainerDetail.Panel2
            // 
            this.splitContainerDetail.Panel2.Controls.Add(this.groupBoxSearch);
            this.splitContainerDetail.Size = new System.Drawing.Size(825, 238);
            this.splitContainerDetail.SplitterDistance = 617;
            this.splitContainerDetail.TabIndex = 0;
            // 
            // groupBoxDetail
            // 
            this.groupBoxDetail.Controls.Add(this.dataGridViewDetail);
            this.groupBoxDetail.Controls.Add(this.toolStripPaging);
            this.groupBoxDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDetail.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDetail.Name = "groupBoxDetail";
            this.groupBoxDetail.Size = new System.Drawing.Size(617, 238);
            this.groupBoxDetail.TabIndex = 1;
            this.groupBoxDetail.TabStop = false;
            this.groupBoxDetail.Text = "Record Detail:";
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.AllowUserToAddRows = false;
            this.dataGridViewDetail.AllowUserToDeleteRows = false;
            this.dataGridViewDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetail.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewDetail.MultiSelect = false;
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            this.dataGridViewDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDetail.Size = new System.Drawing.Size(611, 194);
            this.dataGridViewDetail.TabIndex = 0;
            this.dataGridViewDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetail_CellClick);
            // 
            // toolStripPaging
            // 
            this.toolStripPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripPaging.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripPaging.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLast,
            this.toolStripButtonForward,
            this.toolStripButtonBackward,
            this.toolStripButtonFirst,
            this.lblPaging});
            this.toolStripPaging.Location = new System.Drawing.Point(3, 210);
            this.toolStripPaging.Name = "toolStripPaging";
            this.toolStripPaging.Size = new System.Drawing.Size(611, 25);
            this.toolStripPaging.TabIndex = 2;
            this.toolStripPaging.Text = "toolStrip1";
            // 
            // toolStripButtonLast
            // 
            this.toolStripButtonLast.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLast.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLast.Image")));
            this.toolStripButtonLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLast.Name = "toolStripButtonLast";
            this.toolStripButtonLast.Size = new System.Drawing.Size(27, 22);
            this.toolStripButtonLast.Text = ">>";
            this.toolStripButtonLast.ToolTipText = "Last Page";
            this.toolStripButtonLast.Click += new System.EventHandler(this.toolStripButtonLast_Click);
            // 
            // toolStripButtonForward
            // 
            this.toolStripButtonForward.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonForward.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonForward.Image")));
            this.toolStripButtonForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonForward.Name = "toolStripButtonForward";
            this.toolStripButtonForward.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonForward.Text = ">";
            this.toolStripButtonForward.ToolTipText = "Next Page";
            this.toolStripButtonForward.Click += new System.EventHandler(this.toolStripButtonForward_Click);
            // 
            // toolStripButtonBackward
            // 
            this.toolStripButtonBackward.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonBackward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonBackward.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBackward.Image")));
            this.toolStripButtonBackward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBackward.Name = "toolStripButtonBackward";
            this.toolStripButtonBackward.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBackward.Text = "<";
            this.toolStripButtonBackward.ToolTipText = "Previous Page";
            this.toolStripButtonBackward.Click += new System.EventHandler(this.toolStripButtonBackward_Click);
            // 
            // toolStripButtonFirst
            // 
            this.toolStripButtonFirst.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonFirst.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFirst.Image")));
            this.toolStripButtonFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFirst.Name = "toolStripButtonFirst";
            this.toolStripButtonFirst.Size = new System.Drawing.Size(27, 22);
            this.toolStripButtonFirst.Text = "<<";
            this.toolStripButtonFirst.ToolTipText = "First Page";
            this.toolStripButtonFirst.Click += new System.EventHandler(this.toolStripButtonFirst_Click);
            // 
            // lblPaging
            // 
            this.lblPaging.Name = "lblPaging";
            this.lblPaging.Size = new System.Drawing.Size(0, 22);
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.btnPrintPreview);
            this.groupBoxSearch.Controls.Add(this.label3);
            this.groupBoxSearch.Controls.Add(this.btnPrint);
            this.groupBoxSearch.Controls.Add(this.txtSearch);
            this.groupBoxSearch.Controls.Add(this.bnSearch);
            this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(204, 238);
            this.groupBoxSearch.TabIndex = 20;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Record Search:";
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPreview.Enabled = false;
            this.btnPrintPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPreview.Location = new System.Drawing.Point(97, 161);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(95, 30);
            this.btnPrintPreview.TabIndex = 20;
            this.btnPrintPreview.Text = "Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Name Search Text:";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(97, 197);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 30);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(9, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(186, 20);
            this.txtSearch.TabIndex = 17;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // bnSearch
            // 
            this.bnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnSearch.Location = new System.Drawing.Point(97, 58);
            this.bnSearch.Name = "bnSearch";
            this.bnSearch.Size = new System.Drawing.Size(98, 30);
            this.bnSearch.TabIndex = 18;
            this.bnSearch.Text = "Search";
            this.bnSearch.UseVisualStyleBackColor = true;
            this.bnSearch.Click += new System.EventHandler(this.bnSearch_Click);
            // 
            // groupBoxMatch
            // 
            this.groupBoxMatch.Controls.Add(this.dataGridViewMatch);
            this.groupBoxMatch.Controls.Add(this.menuStripMatch);
            this.groupBoxMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMatch.Location = new System.Drawing.Point(0, 0);
            this.groupBoxMatch.Name = "groupBoxMatch";
            this.groupBoxMatch.Size = new System.Drawing.Size(825, 203);
            this.groupBoxMatch.TabIndex = 0;
            this.groupBoxMatch.TabStop = false;
            this.groupBoxMatch.Text = "Matching Records:";
            // 
            // dataGridViewMatch
            // 
            this.dataGridViewMatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMatch.Location = new System.Drawing.Point(3, 40);
            this.dataGridViewMatch.Name = "dataGridViewMatch";
            this.dataGridViewMatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMatch.Size = new System.Drawing.Size(819, 160);
            this.dataGridViewMatch.TabIndex = 1;
            // 
            // menuStripMatch
            // 
            this.menuStripMatch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem});
            this.menuStripMatch.Location = new System.Drawing.Point(3, 16);
            this.menuStripMatch.Name = "menuStripMatch";
            this.menuStripMatch.Size = new System.Drawing.Size(819, 24);
            this.menuStripMatch.TabIndex = 2;
            this.menuStripMatch.Text = "menuStrip1";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Enabled = false;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.selectAllToolStripMenuItem.Tag = "Select";
            this.selectAllToolStripMenuItem.Text = "Select All Records";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 467);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.statusStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMatch;
            this.MinimumSize = new System.Drawing.Size(841, 425);
            this.Name = "frmMain";
            this.Text = "Ohio Finders List: Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerDetail.Panel1.ResumeLayout(false);
            this.splitContainerDetail.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetail)).EndInit();
            this.splitContainerDetail.ResumeLayout(false);
            this.groupBoxDetail.ResumeLayout(false);
            this.groupBoxDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.toolStripPaging.ResumeLayout(false);
            this.toolStripPaging.PerformLayout();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxMatch.ResumeLayout(false);
            this.groupBoxMatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatch)).EndInit();
            this.menuStripMatch.ResumeLayout(false);
            this.menuStripMatch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerDetail;
        private System.Windows.Forms.DataGridView dataGridViewDetail;
        private System.Windows.Forms.GroupBox groupBoxDetail;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button bnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxMatch;
        private System.Windows.Forms.DataGridView dataGridViewMatch;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.MenuStrip menuStripMatch;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripPaging;
        private System.Windows.Forms.ToolStripButton toolStripButtonLast;
        private System.Windows.Forms.ToolStripButton toolStripButtonForward;
        private System.Windows.Forms.ToolStripButton toolStripButtonBackward;
        private System.Windows.Forms.ToolStripButton toolStripButtonFirst;
        private System.Windows.Forms.ToolStripLabel lblPaging;

    }
}
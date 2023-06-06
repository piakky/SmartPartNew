namespace SmartPart.Forms.Code
{
    partial class frm_Creditcards_List
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
            this.gridCredit = new DevExpress.XtraGrid.GridControl();
            this.gvCredit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.r_Set = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.r_Component = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bwCode = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gridCredit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCredit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Component)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCredit
            // 
            this.gridCredit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCredit.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridCredit.Location = new System.Drawing.Point(0, 0);
            this.gridCredit.MainView = this.gvCredit;
            this.gridCredit.Name = "gridCredit";
            this.gridCredit.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.r_Set,
            this.r_Component});
            this.gridCredit.Size = new System.Drawing.Size(931, 417);
            this.gridCredit.TabIndex = 14;
            this.gridCredit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCredit});
            // 
            // gvCredit
            // 
            this.gvCredit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.col1,
            this.col2,
            this.col4,
            this.col5,
            this.col6});
            this.gvCredit.GridControl = this.gridCredit;
            this.gvCredit.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.gvCredit.IndicatorWidth = 50;
            this.gvCredit.Name = "gvCredit";
            this.gvCredit.OptionsBehavior.Editable = false;
            this.gvCredit.OptionsFind.AlwaysVisible = true;
            this.gvCredit.OptionsFind.ShowFindButton = false;
            this.gvCredit.OptionsView.EnableAppearanceEvenRow = true;
            this.gvCredit.OptionsView.ShowAutoFilterRow = true;
            this.gvCredit.OptionsView.ShowFooter = true;
            this.gvCredit.OptionsView.ShowGroupPanel = false;
            this.gvCredit.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPDT_CustomDrawRowIndicator);
            // 
            // colID
            // 
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // col1
            // 
            this.col1.Caption = "ชื่อย่อธนาคาร";
            this.col1.FieldName = "ABBREVIATE_NAME";
            this.col1.Name = "col1";
            this.col1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ABBREVIATE_NAME", "จำนวนรายการ = {0}")});
            this.col1.Visible = true;
            this.col1.VisibleIndex = 0;
            this.col1.Width = 120;
            // 
            // col2
            // 
            this.col2.Caption = "ชื่อเต็มธนาคาร";
            this.col2.FieldName = "FULL_NAME";
            this.col2.Name = "col2";
            this.col2.Visible = true;
            this.col2.VisibleIndex = 1;
            this.col2.Width = 200;
            // 
            // col4
            // 
            this.col4.Caption = "ประเภทบัตร";
            this.col4.FieldName = "CREDITCARD_TYPE";
            this.col4.Name = "col4";
            this.col4.Width = 150;
            // 
            // col5
            // 
            this.col5.Caption = "หมายเลขบัญชี";
            this.col5.FieldName = "CREDITCARD_CODE";
            this.col5.Name = "col5";
            this.col5.Visible = true;
            this.col5.VisibleIndex = 2;
            this.col5.Width = 120;
            // 
            // col6
            // 
            this.col6.Caption = "รายละเอียด";
            this.col6.FieldName = "CREDITCARD_DESCRIPTION";
            this.col6.Name = "col6";
            this.col6.Visible = true;
            this.col6.VisibleIndex = 3;
            this.col6.Width = 200;
            // 
            // r_Set
            // 
            this.r_Set.AutoHeight = false;
            this.r_Set.Name = "r_Set";
            this.r_Set.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // r_Component
            // 
            this.r_Component.AutoHeight = false;
            this.r_Component.Name = "r_Component";
            this.r_Component.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // bwCode
            // 
            this.bwCode.WorkerReportsProgress = true;
            this.bwCode.WorkerSupportsCancellation = true;
            this.bwCode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCode_DoWork);
            this.bwCode.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCode_RunWorkerCompleted);
            // 
            // frm_Creditcards_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 417);
            this.Controls.Add(this.gridCredit);
            this.Name = "frm_Creditcards_List";
            this.Tag = "1001";
            this.Text = "บัตรเครดิต";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Product_List_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Creditcards_List_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridCredit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCredit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Component)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridCredit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCredit;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private DevExpress.XtraGrid.Columns.GridColumn col4;
        private System.ComponentModel.BackgroundWorker bwCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Set;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Component;
    private DevExpress.XtraGrid.Columns.GridColumn col5;
    private DevExpress.XtraGrid.Columns.GridColumn col6;
  }
}
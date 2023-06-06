namespace SmartPart.Forms.Code
{
    partial class frm_BankAccount_List
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
      this.gridBank = new DevExpress.XtraGrid.GridControl();
      this.gvBank = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.r_Set = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.r_Component = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.bwCode = new System.ComponentModel.BackgroundWorker();
      this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.gridBank)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvBank)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Set)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Component)).BeginInit();
      this.SuspendLayout();
      // 
      // gridBank
      // 
      this.gridBank.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridBank.Font = new System.Drawing.Font("Tahoma", 12F);
      this.gridBank.Location = new System.Drawing.Point(0, 0);
      this.gridBank.MainView = this.gvBank;
      this.gridBank.Name = "gridBank";
      this.gridBank.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.r_Set,
            this.r_Component});
      this.gridBank.Size = new System.Drawing.Size(931, 417);
      this.gridBank.TabIndex = 14;
      this.gridBank.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBank});
      // 
      // gvBank
      // 
      this.gvBank.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.col1,
            this.col2,
            this.col3,
            this.col4});
      this.gvBank.GridControl = this.gridBank;
      this.gvBank.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
      this.gvBank.IndicatorWidth = 50;
      this.gvBank.Name = "gvBank";
      this.gvBank.OptionsBehavior.Editable = false;
      this.gvBank.OptionsFind.AlwaysVisible = true;
      this.gvBank.OptionsFind.ShowFindButton = false;
      this.gvBank.OptionsView.EnableAppearanceEvenRow = true;
      this.gvBank.OptionsView.ShowAutoFilterRow = true;
      this.gvBank.OptionsView.ShowFooter = true;
      this.gvBank.OptionsView.ShowGroupPanel = false;
      this.gvBank.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPDT_CustomDrawRowIndicator);
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
      this.col1.Width = 209;
      // 
      // col2
      // 
      this.col2.Caption = "ชื่อเต็มธนาคาร";
      this.col2.FieldName = "FULL_NAME";
      this.col2.Name = "col2";
      this.col2.Visible = true;
      this.col2.VisibleIndex = 1;
      this.col2.Width = 281;
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
      // col3
      // 
      this.col3.Caption = "ชื่อสาขา";
      this.col3.FieldName = "BANKS_ACCOUNT_BRANCH";
      this.col3.Name = "col3";
      this.col3.Visible = true;
      this.col3.VisibleIndex = 2;
      this.col3.Width = 247;
      // 
      // col4
      // 
      this.col4.Caption = "เลขที่บัญชี";
      this.col4.FieldName = "BANKS_ACCOUNT_CODE";
      this.col4.Name = "col4";
      this.col4.Visible = true;
      this.col4.VisibleIndex = 3;
      this.col4.Width = 251;
      // 
      // frm_BankAccount_List
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(931, 417);
      this.Controls.Add(this.gridBank);
      this.Name = "frm_BankAccount_List";
      this.Tag = "1001";
      this.Text = "บัญชีเงินฝากธนาคาร";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Product_List_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.gridBank)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvBank)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Set)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Component)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridBank;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBank;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private System.ComponentModel.BackgroundWorker bwCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Set;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Component;
    private DevExpress.XtraGrid.Columns.GridColumn col3;
    private DevExpress.XtraGrid.Columns.GridColumn col4;
  }
}
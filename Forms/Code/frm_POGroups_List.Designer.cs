namespace SmartPart.Forms.Code
{
    partial class frm_POGroups_List
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
      this.gridPOs = new DevExpress.XtraGrid.GridControl();
      this.gvPOs = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.r_Set = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.r_Component = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.bwCode = new System.ComponentModel.BackgroundWorker();
      ((System.ComponentModel.ISupportInitialize)(this.gridPOs)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvPOs)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Set)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Component)).BeginInit();
      this.SuspendLayout();
      // 
      // gridPOs
      // 
      this.gridPOs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridPOs.Font = new System.Drawing.Font("Tahoma", 12F);
      this.gridPOs.Location = new System.Drawing.Point(0, 0);
      this.gridPOs.MainView = this.gvPOs;
      this.gridPOs.Name = "gridPOs";
      this.gridPOs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.r_Set,
            this.r_Component});
      this.gridPOs.Size = new System.Drawing.Size(931, 417);
      this.gridPOs.TabIndex = 14;
      this.gridPOs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPOs});
      // 
      // gvPOs
      // 
      this.gvPOs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.col1,
            this.col2});
      this.gvPOs.GridControl = this.gridPOs;
      this.gvPOs.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
      this.gvPOs.IndicatorWidth = 50;
      this.gvPOs.Name = "gvPOs";
      this.gvPOs.OptionsBehavior.Editable = false;
      this.gvPOs.OptionsFind.AlwaysVisible = true;
      this.gvPOs.OptionsFind.ShowFindButton = false;
      this.gvPOs.OptionsView.EnableAppearanceEvenRow = true;
      this.gvPOs.OptionsView.ShowAutoFilterRow = true;
      this.gvPOs.OptionsView.ShowFooter = true;
      this.gvPOs.OptionsView.ShowGroupPanel = false;
      this.gvPOs.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPDT_CustomDrawRowIndicator);
      // 
      // colID
      // 
      this.colID.Name = "colID";
      this.colID.OptionsColumn.ShowInCustomizationForm = false;
      // 
      // col1
      // 
      this.col1.Caption = "รหัสกลุ่มสั่งซื้อสินค้า";
      this.col1.FieldName = "PO_GROUP_CODE";
      this.col1.Name = "col1";
      this.col1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CATEGORIES_CODE", "จำนวนรายการ = {0}")});
      this.col1.Visible = true;
      this.col1.VisibleIndex = 0;
      this.col1.Width = 100;
      // 
      // col2
      // 
      this.col2.Caption = "ชื่อกลุ่มสั่งซื้อสินค้า";
      this.col2.FieldName = "PO_GROUP_NAME";
      this.col2.Name = "col2";
      this.col2.Visible = true;
      this.col2.VisibleIndex = 1;
      this.col2.Width = 150;
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
      // frm_POGroups_List
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(931, 417);
      this.Controls.Add(this.gridPOs);
      this.Name = "frm_POGroups_List";
      this.Tag = "1001";
      this.Text = "กลุ่มสั่งซื้อสินค้า";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Product_List_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.gridPOs)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvPOs)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Set)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Component)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridPOs;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPOs;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private System.ComponentModel.BackgroundWorker bwCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Set;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Component;
  }
}
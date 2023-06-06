namespace SmartPart.Forms.Code
{
    partial class frm_Brands_List
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
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.categoryPic = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowPic = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.gridBrand = new DevExpress.XtraGrid.GridControl();
            this.gvBrand = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.r_Set = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.r_Component = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bwCode = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Component)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager
            // 
            this.dockManager.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight});
            this.dockManager.Form = this;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerRight.Controls.Add(this.dockPanel1);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(912, 0);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(19, 417);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("6bee46c0-bed6-4ba6-88ac-987bd903fc35");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(227, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(227, 417);
            this.dockPanel1.Text = "Detail";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.vGridControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(218, 390);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // vGridControl1
            // 
            this.vGridControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.Location = new System.Drawing.Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.categoryPic});
            this.vGridControl1.Size = new System.Drawing.Size(218, 390);
            this.vGridControl1.TabIndex = 0;
            // 
            // categoryPic
            // 
            this.categoryPic.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowPic});
            this.categoryPic.Name = "categoryPic";
            // 
            // rowPic
            // 
            this.rowPic.Name = "rowPic";
            this.rowPic.Properties.Caption = "รูปสินค้า";
            // 
            // gridBrand
            // 
            this.gridBrand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBrand.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridBrand.Location = new System.Drawing.Point(0, 0);
            this.gridBrand.MainView = this.gvBrand;
            this.gridBrand.Name = "gridBrand";
            this.gridBrand.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.r_Set,
            this.r_Component});
            this.gridBrand.Size = new System.Drawing.Size(912, 417);
            this.gridBrand.TabIndex = 14;
            this.gridBrand.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBrand});
            // 
            // gvBrand
            // 
            this.gvBrand.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.col1,
            this.col2,
            this.col3,
            this.col4});
            this.gvBrand.GridControl = this.gridBrand;
            this.gvBrand.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.gvBrand.IndicatorWidth = 50;
            this.gvBrand.Name = "gvBrand";
            this.gvBrand.OptionsBehavior.Editable = false;
            this.gvBrand.OptionsFind.AlwaysVisible = true;
            this.gvBrand.OptionsFind.ShowFindButton = false;
            this.gvBrand.OptionsView.EnableAppearanceEvenRow = true;
            this.gvBrand.OptionsView.ShowAutoFilterRow = true;
            this.gvBrand.OptionsView.ShowFooter = true;
            this.gvBrand.OptionsView.ShowGroupPanel = false;
            this.gvBrand.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPDT_CustomDrawRowIndicator);
            // 
            // colID
            // 
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // col1
            // 
            this.col1.Caption = "รหัสยี่ห้อสินค้า";
            this.col1.FieldName = "BRAND_CODE";
            this.col1.Name = "col1";
            this.col1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "BRAND_CODE", "จำนวนรายการ = {0}")});
            this.col1.Visible = true;
            this.col1.VisibleIndex = 0;
            this.col1.Width = 120;
            // 
            // col2
            // 
            this.col2.Caption = "ชื่อยี่ห้อสินค้า";
            this.col2.FieldName = "BRAND_NAME";
            this.col2.Name = "col2";
            this.col2.Visible = true;
            this.col2.VisibleIndex = 1;
            this.col2.Width = 200;
            // 
            // col3
            // 
            this.col3.Caption = "รายละเอียดสินค้า";
            this.col3.FieldName = "DESCRIPTION";
            this.col3.Name = "col3";
            this.col3.Visible = true;
            this.col3.VisibleIndex = 2;
            this.col3.Width = 250;
            // 
            // col4
            // 
            this.col4.Caption = "คำอธิบายเพิ่มเติม";
            this.col4.FieldName = "ADDITION_DESCRIPTION";
            this.col4.Name = "col4";
            this.col4.Visible = true;
            this.col4.VisibleIndex = 3;
            this.col4.Width = 290;
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
            // frm_Brands_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 417);
            this.Controls.Add(this.gridBrand);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "frm_Brands_List";
            this.Tag = "1001";
            this.Text = "ยี่ห้อสินค้า";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Product_List_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Brands_List_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Component)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraGrid.GridControl gridBrand;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBrand;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private DevExpress.XtraGrid.Columns.GridColumn col3;
        private DevExpress.XtraGrid.Columns.GridColumn col4;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categoryPic;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPic;
        private System.ComponentModel.BackgroundWorker bwCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Set;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Component;
    private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
  }
}
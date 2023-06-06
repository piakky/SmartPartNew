namespace SmartPart.Forms.Code
{
    partial class frm_Product_List
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
            this.gridPd = new DevExpress.XtraGrid.GridControl();
            this.gvPDT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.r_Set = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.r_Component = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bwCode = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPDT)).BeginInit();
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
            this.hideContainerRight.Location = new System.Drawing.Point(1163, 0);
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
            this.vGridControl1.Cursor = System.Windows.Forms.Cursors.SizeNS;
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
            // gridPd
            // 
            this.gridPd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPd.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridPd.Location = new System.Drawing.Point(0, 0);
            this.gridPd.MainView = this.gvPDT;
            this.gridPd.Name = "gridPd";
            this.gridPd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.r_Set,
            this.r_Component});
            this.gridPd.Size = new System.Drawing.Size(1163, 417);
            this.gridPd.TabIndex = 14;
            this.gridPd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPDT});
            // 
            // gvPDT
            // 
            this.gvPDT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col7,
            this.col8,
            this.col9});
            this.gvPDT.GridControl = this.gridPd;
            this.gvPDT.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.gvPDT.IndicatorWidth = 50;
            this.gvPDT.Name = "gvPDT";
            this.gvPDT.OptionsBehavior.Editable = false;
            this.gvPDT.OptionsFind.AlwaysVisible = true;
            this.gvPDT.OptionsFind.ShowFindButton = false;
            this.gvPDT.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPDT.OptionsView.ShowAutoFilterRow = true;
            this.gvPDT.OptionsView.ShowFooter = true;
            this.gvPDT.OptionsView.ShowGroupPanel = false;
            this.gvPDT.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPDT_CustomDrawRowIndicator);
            // 
            // colID
            // 
            this.colID.FieldName = "ITEM_ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // col1
            // 
            this.col1.Caption = "รหัสสินค้า";
            this.col1.FieldName = "ITEM_CODE";
            this.col1.Name = "col1";
            this.col1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ITEM_CODE", "จำนวนรายการ = {0}")});
            this.col1.Visible = true;
            this.col1.VisibleIndex = 0;
            this.col1.Width = 102;
            // 
            // col2
            // 
            this.col2.Caption = "ชื่อย่อสินค้า";
            this.col2.FieldName = "ABBREVIATE_NAME";
            this.col2.Name = "col2";
            this.col2.Visible = true;
            this.col2.VisibleIndex = 1;
            this.col2.Width = 127;
            // 
            // col3
            // 
            this.col3.Caption = "ชื่อเต็มสินค้า";
            this.col3.FieldName = "FULL_NAME";
            this.col3.Name = "col3";
            this.col3.Visible = true;
            this.col3.VisibleIndex = 2;
            this.col3.Width = 142;
            // 
            // col4
            // 
            this.col4.Caption = "รุ่น 1";
            this.col4.FieldName = "MODEL1";
            this.col4.Name = "col4";
            this.col4.Visible = true;
            this.col4.VisibleIndex = 3;
            this.col4.Width = 107;
            // 
            // col5
            // 
            this.col5.Caption = "รุ่น 2";
            this.col5.FieldName = "MODEL2";
            this.col5.Name = "col5";
            this.col5.Visible = true;
            this.col5.VisibleIndex = 4;
            this.col5.Width = 104;
            // 
            // col6
            // 
            this.col6.Caption = "รุ่น 3";
            this.col6.FieldName = "MODEL3";
            this.col6.Name = "col6";
            this.col6.Visible = true;
            this.col6.VisibleIndex = 5;
            this.col6.Width = 98;
            // 
            // col7
            // 
            this.col7.Caption = "ยี่ห้อสินค้า";
            this.col7.FieldName = "BRAND_NAME";
            this.col7.Name = "col7";
            this.col7.Visible = true;
            this.col7.VisibleIndex = 6;
            this.col7.Width = 85;
            // 
            // col8
            // 
            this.col8.Caption = "เป็น Set";
            this.col8.ColumnEdit = this.r_Set;
            this.col8.FieldName = "SET_STATUS";
            this.col8.Name = "col8";
            this.col8.Visible = true;
            this.col8.VisibleIndex = 7;
            this.col8.Width = 85;
            // 
            // r_Set
            // 
            this.r_Set.AutoHeight = false;
            this.r_Set.Name = "r_Set";
            this.r_Set.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // col9
            // 
            this.col9.Caption = "มีส่วนประกอบ";
            this.col9.ColumnEdit = this.r_Component;
            this.col9.FieldName = "COMPONENT_STATUS";
            this.col9.Name = "col9";
            this.col9.Visible = true;
            this.col9.VisibleIndex = 8;
            this.col9.Width = 138;
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
            // frm_Product_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 417);
            this.Controls.Add(this.gridPd);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "frm_Product_List";
            this.Tag = "1001";
            this.Text = "รหัสสินค้า";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Product_List_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Product_List_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Component)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraGrid.GridControl gridPd;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPDT;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private DevExpress.XtraGrid.Columns.GridColumn col3;
        private DevExpress.XtraGrid.Columns.GridColumn col4;
        private DevExpress.XtraGrid.Columns.GridColumn col7;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categoryPic;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPic;
        private System.ComponentModel.BackgroundWorker bwCode;
        private DevExpress.XtraGrid.Columns.GridColumn col8;
        private DevExpress.XtraGrid.Columns.GridColumn col9;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Set;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Component;
    private DevExpress.XtraGrid.Columns.GridColumn col5;
    private DevExpress.XtraGrid.Columns.GridColumn col6;
    private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
  }
}
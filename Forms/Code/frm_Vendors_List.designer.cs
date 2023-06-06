namespace SmartPart.Forms.Code
{
    partial class frm_Vendors_List
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
      this.bwCode = new System.ComponentModel.BackgroundWorker();
      this.gridVendors = new DevExpress.XtraGrid.GridControl();
      this.gvVendors = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col5 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col6 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
      this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.gridVendors)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvVendors)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
      this.SuspendLayout();
      // 
      // bwCode
      // 
      this.bwCode.WorkerReportsProgress = true;
      this.bwCode.WorkerSupportsCancellation = true;
      this.bwCode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCode_DoWork);
      this.bwCode.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCode_RunWorkerCompleted);
      // 
      // gridVendors
      // 
      this.gridVendors.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridVendors.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
      this.gridVendors.Location = new System.Drawing.Point(0, 0);
      this.gridVendors.MainView = this.gvVendors;
      this.gridVendors.Margin = new System.Windows.Forms.Padding(4);
      this.gridVendors.Name = "gridVendors";
      this.gridVendors.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemDateEdit1});
      this.gridVendors.Size = new System.Drawing.Size(886, 618);
      this.gridVendors.TabIndex = 16;
      this.gridVendors.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVendors});
      // 
      // gvVendors
      // 
      this.gvVendors.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6});
      this.gvVendors.GridControl = this.gridVendors;
      this.gvVendors.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
      this.gvVendors.IndicatorWidth = 50;
      this.gvVendors.Name = "gvVendors";
      this.gvVendors.OptionsBehavior.Editable = false;
      this.gvVendors.OptionsFind.AlwaysVisible = true;
      this.gvVendors.OptionsFind.ShowFindButton = false;
      this.gvVendors.OptionsView.EnableAppearanceEvenRow = true;
      this.gvVendors.OptionsView.ShowAutoFilterRow = true;
      this.gvVendors.OptionsView.ShowFooter = true;
      this.gvVendors.OptionsView.ShowGroupPanel = false;
      this.gvVendors.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvVendors_CustomDrawRowIndicator);
      // 
      // col1
      // 
      this.col1.Caption = "id";
      this.col1.FieldName = "VENDOR_ID";
      this.col1.Name = "col1";
      this.col1.OptionsColumn.ShowInCustomizationForm = false;
      // 
      // col2
      // 
      this.col2.Caption = "รหัสผู้จำหน่ายสินค้า";
      this.col2.FieldName = "VENDOR_CODE";
      this.col2.Name = "col2";
      this.col2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ITEM_CODE", "จำนวนรายการ = {0}")});
      this.col2.Visible = true;
      this.col2.VisibleIndex = 0;
      this.col2.Width = 118;
      // 
      // col3
      // 
      this.col3.Caption = "ชื่อผู้จำหน่ายสินค้า";
      this.col3.FieldName = "VENDOR_NAME";
      this.col3.Name = "col3";
      this.col3.Visible = true;
      this.col3.VisibleIndex = 1;
      this.col3.Width = 83;
      // 
      // col4
      // 
      this.col4.Caption = "รายละเอียด1";
      this.col4.FieldName = "DETAIL_1";
      this.col4.Name = "col4";
      this.col4.Visible = true;
      this.col4.VisibleIndex = 2;
      this.col4.Width = 148;
      // 
      // col5
      // 
      this.col5.Caption = "หมายเหตุ";
      this.col5.FieldName = "REMARK";
      this.col5.Name = "col5";
      this.col5.Visible = true;
      this.col5.VisibleIndex = 3;
      this.col5.Width = 74;
      // 
      // col6
      // 
      this.col6.Caption = "วันที่เริ่มติดต่อ";
      this.col6.ColumnEdit = this.repositoryItemDateEdit1;
      this.col6.FieldName = "START_CONTRACT_DATE";
      this.col6.Name = "col6";
      this.col6.Visible = true;
      this.col6.VisibleIndex = 4;
      this.col6.Width = 74;
      // 
      // repositoryItemDateEdit1
      // 
      this.repositoryItemDateEdit1.AutoHeight = false;
      this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
      // 
      // repositoryItemCheckEdit1
      // 
      this.repositoryItemCheckEdit1.AutoHeight = false;
      this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
      this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
      // 
      // repositoryItemCheckEdit2
      // 
      this.repositoryItemCheckEdit2.AutoHeight = false;
      this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
      this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
      // 
      // dockManager1
      // 
      this.dockManager1.Form = this;
      this.dockManager1.TopZIndexControls.AddRange(new string[] {
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
      // frm_Vendors_List
      // 
      this.Appearance.Options.UseFont = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(886, 618);
      this.Controls.Add(this.gridVendors);
      this.Font = new System.Drawing.Font("Tahoma", 12F);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "frm_Vendors_List";
      this.Text = "frm_Vendors_List";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Vendors_List_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.gridVendors)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvVendors)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bwCode;
        private DevExpress.XtraGrid.GridControl gridVendors;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVendors;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private DevExpress.XtraGrid.Columns.GridColumn col3;
        private DevExpress.XtraGrid.Columns.GridColumn col4;
        private DevExpress.XtraGrid.Columns.GridColumn col5;
        private DevExpress.XtraGrid.Columns.GridColumn col6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;

    }
}
namespace SmartPart.Forms.Code
{
  partial class frm_Customers_List
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
      this.gridCustomers = new DevExpress.XtraGrid.GridControl();
      this.gvCustomers = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col5 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
      this.col6 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
      this.col7 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col8 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
      this.bwCode = new System.ComponentModel.BackgroundWorker();
      ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvCustomers)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
      this.SuspendLayout();
      // 
      // gridCustomers
      // 
      this.gridCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridCustomers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
      this.gridCustomers.Location = new System.Drawing.Point(0, 0);
      this.gridCustomers.MainView = this.gvCustomers;
      this.gridCustomers.Margin = new System.Windows.Forms.Padding(4);
      this.gridCustomers.Name = "gridCustomers";
      this.gridCustomers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
      this.gridCustomers.Size = new System.Drawing.Size(1144, 675);
      this.gridCustomers.TabIndex = 17;
      this.gridCustomers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustomers});
      // 
      // gvCustomers
      // 
      this.gvCustomers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col1,
            this.col2,
            this.col3,
            this.col5,
            this.col6,
            this.col7,
            this.col8});
      this.gvCustomers.GridControl = this.gridCustomers;
      this.gvCustomers.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
      this.gvCustomers.IndicatorWidth = 50;
      this.gvCustomers.Name = "gvCustomers";
      this.gvCustomers.OptionsBehavior.Editable = false;
      this.gvCustomers.OptionsFind.AlwaysVisible = true;
      this.gvCustomers.OptionsFind.ShowFindButton = false;
      this.gvCustomers.OptionsView.EnableAppearanceEvenRow = true;
      this.gvCustomers.OptionsView.ShowAutoFilterRow = true;
      this.gvCustomers.OptionsView.ShowFooter = true;
      this.gvCustomers.OptionsView.ShowGroupPanel = false;
      this.gvCustomers.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvCustomers_CustomDrawRowIndicator);
      // 
      // col1
      // 
      this.col1.Caption = "id";
      this.col1.FieldName = "CUSTOMER_ID";
      this.col1.Name = "col1";
      this.col1.OptionsColumn.ShowInCustomizationForm = false;
      // 
      // col2
      // 
      this.col2.Caption = "รหัสลูกค้า";
      this.col2.FieldName = "CUSTOMER_CODE";
      this.col2.Name = "col2";
      this.col2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ITEM_CODE", "จำนวนรายการ = {0}")});
      this.col2.Visible = true;
      this.col2.VisibleIndex = 0;
      this.col2.Width = 118;
      // 
      // col3
      // 
      this.col3.Caption = "ชื่อลูกค้า";
      this.col3.FieldName = "CUSTOMER_NAME";
      this.col3.Name = "col3";
      this.col3.Visible = true;
      this.col3.VisibleIndex = 1;
      this.col3.Width = 83;
      // 
      // col5
      // 
      this.col5.Caption = "วันที่เริ่มติดต่อ";
      this.col5.ColumnEdit = this.repositoryItemDateEdit1;
      this.col5.FieldName = "START_CONTRACT_DATE";
      this.col5.Name = "col5";
      this.col5.Visible = true;
      this.col5.VisibleIndex = 2;
      this.col5.Width = 74;
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
      // col6
      // 
      this.col6.Caption = "ระยะเวลาชำระ (วัน)";
      this.col6.FieldName = "CUSTOMER_CREDIT_TERM";
      this.col6.Name = "col6";
      this.col6.Visible = true;
      this.col6.VisibleIndex = 4;
      this.col6.Width = 74;
      // 
      // repositoryItemDateEdit2
      // 
      this.repositoryItemDateEdit2.AutoHeight = false;
      this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
      // 
      // col7
      // 
      this.col7.Caption = "วงเงิน";
      this.col7.FieldName = "CREDIT_LIMIT";
      this.col7.Name = "col7";
      this.col7.Visible = true;
      this.col7.VisibleIndex = 5;
      // 
      // col8
      // 
      this.col8.Caption = "สถานะการขาย";
      this.col8.FieldName = "SALE_ENABLED_STATUS";
      this.col8.Name = "col8";
      this.col8.Visible = true;
      this.col8.VisibleIndex = 6;
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
      // bwCode
      // 
      this.bwCode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCode_DoWork);
      this.bwCode.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCode_RunWorkerCompleted);
      // 
      // frm_Customers_List
      // 
      this.Appearance.Options.UseFont = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1144, 675);
      this.Controls.Add(this.gridCustomers);
      this.Font = new System.Drawing.Font("Tahoma", 12F);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "frm_Customers_List";
      this.Text = "frm_Customers_list";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Customers_List_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvCustomers)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridCustomers;
    private DevExpress.XtraGrid.Views.Grid.GridView gvCustomers;
    private DevExpress.XtraGrid.Columns.GridColumn col1;
    private DevExpress.XtraGrid.Columns.GridColumn col2;
    private DevExpress.XtraGrid.Columns.GridColumn col3;
    private DevExpress.XtraGrid.Columns.GridColumn col5;
    private DevExpress.XtraGrid.Columns.GridColumn col6;
    private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
    private DevExpress.XtraBars.Docking.DockManager dockManager1;
    private DevExpress.XtraGrid.Columns.GridColumn col7;
    private DevExpress.XtraGrid.Columns.GridColumn col8;
    private System.ComponentModel.BackgroundWorker bwCode;
    private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
    private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
  }
}
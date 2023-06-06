namespace SmartPart.Forms.General
{
    partial class frm_JobList
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btShowItem = new DevExpress.XtraEditors.SimpleButton();
            this.btActive = new DevExpress.XtraEditors.SimpleButton();
            this.btDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btView = new DevExpress.XtraEditors.SimpleButton();
            this.btSearch = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.comboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateTo = new DevExpress.XtraEditors.DateEdit();
            this.txtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.dateFrom = new DevExpress.XtraEditors.DateEdit();
            this.sluOperator = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.comboTypedate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridJOB = new DevExpress.XtraGrid.GridControl();
            this.gvJOB = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobOpen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobOperation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoSearchOperator = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colListNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoSearchJobType = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colJobStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoComboJobStatus = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.bwList = new System.ComponentModel.BackgroundWorker();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluOperator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboTypedate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridJOB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJOB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSearchOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSearchJobType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoComboJobStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
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
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("2fb46f3e-474a-40f4-9998-0c616da18849");
            this.dockPanel1.Location = new System.Drawing.Point(1008, 0);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ResizeDirection = DevExpress.XtraBars.Docking.Helpers.ResizeDirection.None;
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(188, 200);
            this.dockPanel1.Size = new System.Drawing.Size(188, 526);
            this.dockPanel1.Text = "Option";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btShowItem);
            this.dockPanel1_Container.Controls.Add(this.btActive);
            this.dockPanel1_Container.Controls.Add(this.btDelete);
            this.dockPanel1_Container.Controls.Add(this.btEdit);
            this.dockPanel1_Container.Controls.Add(this.btAdd);
            this.dockPanel1_Container.Controls.Add(this.btView);
            this.dockPanel1_Container.Controls.Add(this.btSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(180, 499);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btShowItem
            // 
            this.btShowItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btShowItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btShowItem.Appearance.Options.UseFont = true;
            this.btShowItem.Appearance.Options.UseTextOptions = true;
            this.btShowItem.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btShowItem.ImageOptions.Image = global::SmartPart.Properties.Resources.Preview_16x16;
            this.btShowItem.Location = new System.Drawing.Point(21, 464);
            this.btShowItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btShowItem.Name = "btShowItem";
            this.btShowItem.Size = new System.Drawing.Size(140, 28);
            this.btShowItem.TabIndex = 6;
            this.btShowItem.Text = "Show item (F11)";
            this.btShowItem.Click += new System.EventHandler(this.btShowItem_Click);
            // 
            // btActive
            // 
            this.btActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btActive.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btActive.Appearance.Options.UseFont = true;
            this.btActive.Appearance.Options.UseTextOptions = true;
            this.btActive.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btActive.ImageOptions.Image = global::SmartPart.Properties.Resources.Settings_16x16;
            this.btActive.Location = new System.Drawing.Point(21, 428);
            this.btActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btActive.Name = "btActive";
            this.btActive.Size = new System.Drawing.Size(140, 28);
            this.btActive.TabIndex = 5;
            this.btActive.Text = "Set Active (F9)";
            this.btActive.Click += new System.EventHandler(this.btActive_Click);
            // 
            // btDelete
            // 
            this.btDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btDelete.Appearance.Options.UseFont = true;
            this.btDelete.Appearance.Options.UseTextOptions = true;
            this.btDelete.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btDelete.ImageOptions.Image = global::SmartPart.Properties.Resources.Delete_16x16;
            this.btDelete.Location = new System.Drawing.Point(21, 156);
            this.btDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(140, 28);
            this.btDelete.TabIndex = 4;
            this.btDelete.Text = "ลบ (F7)";
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btEdit
            // 
            this.btEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btEdit.Appearance.Options.UseFont = true;
            this.btEdit.Appearance.Options.UseTextOptions = true;
            this.btEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btEdit.ImageOptions.Image = global::SmartPart.Properties.Resources.Edit_16x16;
            this.btEdit.Location = new System.Drawing.Point(21, 120);
            this.btEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(140, 28);
            this.btEdit.TabIndex = 3;
            this.btEdit.Text = "แก้ไข (F6)";
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAdd
            // 
            this.btAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btAdd.Appearance.Options.UseFont = true;
            this.btAdd.Appearance.Options.UseTextOptions = true;
            this.btAdd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btAdd.ImageOptions.Image = global::SmartPart.Properties.Resources.Add_16x16;
            this.btAdd.Location = new System.Drawing.Point(21, 84);
            this.btAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(140, 28);
            this.btAdd.TabIndex = 2;
            this.btAdd.Text = "เพิ่ม (F5)";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btView
            // 
            this.btView.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btView.Appearance.Options.UseFont = true;
            this.btView.Appearance.Options.UseTextOptions = true;
            this.btView.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btView.ImageOptions.Image = global::SmartPart.Properties.Resources.Information_16x16;
            this.btView.Location = new System.Drawing.Point(21, 48);
            this.btView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(140, 28);
            this.btView.TabIndex = 1;
            this.btView.Text = "ดูข้อมูล (F12)";
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // btSearch
            // 
            this.btSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btSearch.Appearance.Options.UseFont = true;
            this.btSearch.Appearance.Options.UseTextOptions = true;
            this.btSearch.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btSearch.ImageOptions.Image = global::SmartPart.Properties.Resources.Search_16x16;
            this.btSearch.Location = new System.Drawing.Point(21, 12);
            this.btSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(140, 28);
            this.btSearch.TabIndex = 0;
            this.btSearch.Text = "ค้นหาข้อมูล (F8)";
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1008, 63);
            this.panelControl1.TabIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.Controls.Add(this.comboStatus);
            this.layoutControl1.Controls.Add(this.dateTo);
            this.layoutControl1.Controls.Add(this.txtBarcode);
            this.layoutControl1.Controls.Add(this.dateFrom);
            this.layoutControl1.Controls.Add(this.sluOperator);
            this.layoutControl1.Controls.Add(this.comboTypedate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(59, 157, 719, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1004, 59);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // comboStatus
            // 
            this.comboStatus.EditValue = "แสดงทุกสถานะ";
            this.comboStatus.EnterMoveNextControl = true;
            this.comboStatus.Location = new System.Drawing.Point(106, 33);
            this.comboStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comboStatus.Properties.Appearance.Options.UseFont = true;
            this.comboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboStatus.Size = new System.Drawing.Size(246, 22);
            this.comboStatus.StyleController = this.layoutControl1;
            this.comboStatus.TabIndex = 4;
            this.comboStatus.SelectedIndexChanged += new System.EventHandler(this.comboStatus_SelectedIndexChanged);
            // 
            // dateTo
            // 
            this.dateTo.EditValue = null;
            this.dateTo.EnterMoveNextControl = true;
            this.dateTo.Location = new System.Drawing.Point(853, 7);
            this.dateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTo.Name = "dateTo";
            this.dateTo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateTo.Properties.Appearance.Options.UseFont = true;
            this.dateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Size = new System.Drawing.Size(144, 22);
            this.dateTo.StyleController = this.layoutControl1;
            this.dateTo.TabIndex = 3;
            this.dateTo.EditValueChanged += new System.EventHandler(this.dateTo_EditValueChanged);
            // 
            // txtBarcode
            // 
            this.txtBarcode.EnterMoveNextControl = true;
            this.txtBarcode.Location = new System.Drawing.Point(451, 33);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtBarcode.Properties.Appearance.Options.UseFont = true;
            this.txtBarcode.Size = new System.Drawing.Size(546, 22);
            this.txtBarcode.StyleController = this.layoutControl1;
            this.txtBarcode.TabIndex = 5;
            // 
            // dateFrom
            // 
            this.dateFrom.EditValue = null;
            this.dateFrom.EnterMoveNextControl = true;
            this.dateFrom.Location = new System.Drawing.Point(682, 7);
            this.dateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateFrom.Properties.Appearance.Options.UseFont = true;
            this.dateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Size = new System.Drawing.Size(121, 22);
            this.dateFrom.StyleController = this.layoutControl1;
            this.dateFrom.TabIndex = 2;
            this.dateFrom.EditValueChanged += new System.EventHandler(this.dateFrom_EditValueChanged);
            // 
            // sluOperator
            // 
            this.sluOperator.EnterMoveNextControl = true;
            this.sluOperator.Location = new System.Drawing.Point(106, 7);
            this.sluOperator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sluOperator.Name = "sluOperator";
            this.sluOperator.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sluOperator.Properties.Appearance.Options.UseFont = true;
            this.sluOperator.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sluOperator.Properties.NullText = "แสดงทุกผู้ดำเนินการ";
            this.sluOperator.Properties.View = this.searchLookUpEdit1View;
            this.sluOperator.Size = new System.Drawing.Size(246, 22);
            this.sluOperator.StyleController = this.layoutControl1;
            this.sluOperator.TabIndex = 0;
            this.sluOperator.EditValueChanged += new System.EventHandler(this.sluOperator_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // comboTypedate
            // 
            this.comboTypedate.Location = new System.Drawing.Point(455, 7);
            this.comboTypedate.Name = "comboTypedate";
            this.comboTypedate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comboTypedate.Properties.Appearance.Options.UseFont = true;
            this.comboTypedate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboTypedate.Properties.Items.AddRange(new object[] {
            "เดือนนี้",
            "เดือนที่แล้ว",
            "กำหนดเอง"});
            this.comboTypedate.Size = new System.Drawing.Size(128, 22);
            this.comboTypedate.StyleController = this.layoutControl1;
            this.comboTypedate.TabIndex = 1;
            this.comboTypedate.SelectedIndexChanged += new System.EventHandler(this.comboTypedate_SelectedIndexChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1004, 62);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.sluOperator;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(349, 26);
            this.layoutControlItem1.Text = "ผู้ดำเนินการ";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(96, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.dateFrom;
            this.layoutControlItem2.Location = new System.Drawing.Point(580, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(220, 26);
            this.layoutControlItem2.Text = "จากวันที่";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(90, 20);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.dateTo;
            this.layoutControlItem3.Location = new System.Drawing.Point(800, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(194, 26);
            this.layoutControlItem3.Text = "ถึงวันที่";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(41, 17);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.comboStatus;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(349, 26);
            this.layoutControlItem4.Text = "สถานะ";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(96, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txtBarcode;
            this.layoutControlItem5.Location = new System.Drawing.Point(349, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(645, 26);
            this.layoutControlItem5.Text = "บาร์โค้ดเอกสาร";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(90, 20);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.comboTypedate;
            this.layoutControlItem6.Location = new System.Drawing.Point(349, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(231, 26);
            this.layoutControlItem6.Text = "ประเภทช่วงเวลา";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(96, 17);
            // 
            // gridJOB
            // 
            this.gridJOB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridJOB.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridJOB.Location = new System.Drawing.Point(7, 7);
            this.gridJOB.MainView = this.gvJOB;
            this.gridJOB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridJOB.Name = "gridJOB";
            this.gridJOB.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoSearchOperator,
            this.repoSearchJobType,
            this.repoComboJobStatus});
            this.gridJOB.Size = new System.Drawing.Size(994, 449);
            this.gridJOB.TabIndex = 0;
            this.gridJOB.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvJOB});
            // 
            // gvJOB
            // 
            this.gvJOB.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvJOB.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvJOB.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvJOB.Appearance.Row.Options.UseFont = true;
            this.gvJOB.ColumnPanelRowHeight = 30;
            this.gvJOB.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colDate,
            this.colJobNo,
            this.colJobOpen,
            this.colJobOperation,
            this.colListNo,
            this.colJobType,
            this.colJobStatus});
            this.gvJOB.GridControl = this.gridJOB;
            this.gvJOB.IndicatorWidth = 30;
            this.gvJOB.Name = "gvJOB";
            this.gvJOB.OptionsBehavior.Editable = false;
            this.gvJOB.OptionsView.EnableAppearanceOddRow = true;
            this.gvJOB.OptionsView.ShowGroupPanel = false;
            this.gvJOB.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvJOB_CustomDrawRowIndicator);
            this.gvJOB.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvJOB_RowCellStyle);
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colID.Caption = "Id";
            this.colID.FieldName = "JOB_ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colDate
            // 
            this.colDate.AppearanceCell.Options.UseTextOptions = true;
            this.colDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDate.Caption = "วันที่";
            this.colDate.FieldName = "JOB_DATE";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            // 
            // colJobNo
            // 
            this.colJobNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colJobNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colJobNo.Caption = "เลขที่";
            this.colJobNo.FieldName = "JOB_NO";
            this.colJobNo.Name = "colJobNo";
            this.colJobNo.Visible = true;
            this.colJobNo.VisibleIndex = 1;
            // 
            // colJobOpen
            // 
            this.colJobOpen.AppearanceCell.Options.UseTextOptions = true;
            this.colJobOpen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colJobOpen.AppearanceHeader.Options.UseTextOptions = true;
            this.colJobOpen.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colJobOpen.Caption = "ผู้เปิด";
            this.colJobOpen.FieldName = "JOB_OPEN";
            this.colJobOpen.Name = "colJobOpen";
            this.colJobOpen.Visible = true;
            this.colJobOpen.VisibleIndex = 2;
            // 
            // colJobOperation
            // 
            this.colJobOperation.AppearanceCell.Options.UseTextOptions = true;
            this.colJobOperation.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colJobOperation.AppearanceHeader.Options.UseTextOptions = true;
            this.colJobOperation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colJobOperation.Caption = "ผู้ดำเนินการ";
            this.colJobOperation.ColumnEdit = this.repoSearchOperator;
            this.colJobOperation.FieldName = "JOB_OPERATOR";
            this.colJobOperation.Name = "colJobOperation";
            this.colJobOperation.Visible = true;
            this.colJobOperation.VisibleIndex = 3;
            // 
            // repoSearchOperator
            // 
            this.repoSearchOperator.AutoHeight = false;
            this.repoSearchOperator.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoSearchOperator.Name = "repoSearchOperator";
            this.repoSearchOperator.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colListNo
            // 
            this.colListNo.AppearanceCell.Options.UseTextOptions = true;
            this.colListNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colListNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colListNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colListNo.Caption = "จำนวนรายการ";
            this.colListNo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colListNo.FieldName = "LIST_NO";
            this.colListNo.Name = "colListNo";
            this.colListNo.Visible = true;
            this.colListNo.VisibleIndex = 4;
            // 
            // colJobType
            // 
            this.colJobType.AppearanceCell.Options.UseTextOptions = true;
            this.colJobType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colJobType.AppearanceHeader.Options.UseTextOptions = true;
            this.colJobType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colJobType.Caption = "ประเภท JOB";
            this.colJobType.ColumnEdit = this.repoSearchJobType;
            this.colJobType.FieldName = "JOB_TYPE";
            this.colJobType.Name = "colJobType";
            this.colJobType.Visible = true;
            this.colJobType.VisibleIndex = 5;
            // 
            // repoSearchJobType
            // 
            this.repoSearchJobType.AutoHeight = false;
            this.repoSearchJobType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoSearchJobType.Name = "repoSearchJobType";
            this.repoSearchJobType.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colJobStatus
            // 
            this.colJobStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colJobStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colJobStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colJobStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colJobStatus.Caption = "สถานะ JOB";
            this.colJobStatus.ColumnEdit = this.repoComboJobStatus;
            this.colJobStatus.FieldName = "_JOB_STATUS";
            this.colJobStatus.Name = "colJobStatus";
            this.colJobStatus.Visible = true;
            this.colJobStatus.VisibleIndex = 6;
            // 
            // repoComboJobStatus
            // 
            this.repoComboJobStatus.AutoHeight = false;
            this.repoComboJobStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoComboJobStatus.Name = "repoComboJobStatus";
            // 
            // bwList
            // 
            this.bwList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwList_DoWork);
            this.bwList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwList_RunWorkerCompleted);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridJOB);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 63);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl2.Size = new System.Drawing.Size(1008, 463);
            this.panelControl2.TabIndex = 4;
            // 
            // frm_JobList
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 526);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.dockPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_JobList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_JobList";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_JobList_FormClosing);
            this.Load += new System.EventHandler(this.frm_JobList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_JobList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluOperator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboTypedate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridJOB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJOB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSearchOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSearchJobType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoComboJobStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl gridJOB;
        private DevExpress.XtraGrid.Views.Grid.GridView gvJOB;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboStatus;
        private DevExpress.XtraEditors.DateEdit dateTo;
        private DevExpress.XtraEditors.TextEdit txtBarcode;
        private DevExpress.XtraEditors.DateEdit dateFrom;
        private DevExpress.XtraEditors.SearchLookUpEdit sluOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btShowItem;
        private DevExpress.XtraEditors.SimpleButton btActive;
        private DevExpress.XtraEditors.SimpleButton btDelete;
        private DevExpress.XtraEditors.SimpleButton btEdit;
        private DevExpress.XtraEditors.SimpleButton btAdd;
        private DevExpress.XtraEditors.SimpleButton btView;
        private DevExpress.XtraEditors.SimpleButton btSearch;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colJobNo;
        private DevExpress.XtraGrid.Columns.GridColumn colJobOpen;
        private DevExpress.XtraGrid.Columns.GridColumn colJobOperation;
        private DevExpress.XtraGrid.Columns.GridColumn colListNo;
        private DevExpress.XtraGrid.Columns.GridColumn colJobType;
        private DevExpress.XtraGrid.Columns.GridColumn colJobStatus;
        private System.ComponentModel.BackgroundWorker bwList;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repoSearchOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repoSearchJobType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repoComboJobStatus;
    private DevExpress.XtraEditors.ComboBoxEdit comboTypedate;
    private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
  }
}
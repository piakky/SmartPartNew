namespace SmartPart.Forms.General
{
    partial class frm_ROList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ROList));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btShowItem = new DevExpress.XtraEditors.SimpleButton();
            this.btView = new DevExpress.XtraEditors.SimpleButton();
            this.btActive = new DevExpress.XtraEditors.SimpleButton();
            this.btSerch = new DevExpress.XtraEditors.SimpleButton();
            this.btDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btEdit = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.comboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateTo = new DevExpress.XtraEditors.DateEdit();
            this.txtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.dateFrom = new DevExpress.XtraEditors.DateEdit();
            this.sluCus = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.comboTypedate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridRO = new DevExpress.XtraGrid.GridControl();
            this.gvRO = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoSearchCus = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDateRO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVatStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colROStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReturnDate = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.sluCus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboTypedate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSearchCus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
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
            this.dockPanel1.ID = new System.Guid("469f05bf-364c-4df2-b2c7-bbaea7b7a30a");
            this.dockPanel1.Location = new System.Drawing.Point(1071, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.FloatOnDblClick = false;
            this.dockPanel1.Options.ResizeDirection = DevExpress.XtraBars.Docking.Helpers.ResizeDirection.None;
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(159, 200);
            this.dockPanel1.Size = new System.Drawing.Size(159, 459);
            this.dockPanel1.Text = "Option";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btShowItem);
            this.dockPanel1_Container.Controls.Add(this.btView);
            this.dockPanel1_Container.Controls.Add(this.btActive);
            this.dockPanel1_Container.Controls.Add(this.btSerch);
            this.dockPanel1_Container.Controls.Add(this.btDelete);
            this.dockPanel1_Container.Controls.Add(this.btEdit);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(151, 432);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btShowItem
            // 
            this.btShowItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btShowItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btShowItem.Appearance.Options.UseFont = true;
            this.btShowItem.Appearance.Options.UseTextOptions = true;
            this.btShowItem.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btShowItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btShowItem.ImageOptions.Image")));
            this.btShowItem.Location = new System.Drawing.Point(8, 348);
            this.btShowItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btShowItem.Name = "btShowItem";
            this.btShowItem.Size = new System.Drawing.Size(140, 28);
            this.btShowItem.TabIndex = 13;
            this.btShowItem.Text = "พิมพ์ (F9)";
            this.btShowItem.Click += new System.EventHandler(this.btPrintItem_Click);
            // 
            // btView
            // 
            this.btView.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btView.Appearance.Options.UseFont = true;
            this.btView.Appearance.Options.UseTextOptions = true;
            this.btView.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btView.ImageOptions.Image = global::SmartPart.Properties.Resources.Information_16x16;
            this.btView.Location = new System.Drawing.Point(8, 49);
            this.btView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(140, 28);
            this.btView.TabIndex = 8;
            this.btView.Text = "ดูข้อมูล (F12)";
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // btActive
            // 
            this.btActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btActive.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btActive.Appearance.Options.UseFont = true;
            this.btActive.Appearance.Options.UseTextOptions = true;
            this.btActive.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btActive.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btActive.ImageOptions.Image")));
            this.btActive.Location = new System.Drawing.Point(8, 384);
            this.btActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btActive.Name = "btActive";
            this.btActive.Size = new System.Drawing.Size(140, 28);
            this.btActive.TabIndex = 12;
            this.btActive.Text = "ปิด (F11)";
            this.btActive.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSerch
            // 
            this.btSerch.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btSerch.Appearance.Options.UseFont = true;
            this.btSerch.Appearance.Options.UseTextOptions = true;
            this.btSerch.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btSerch.ImageOptions.Image = global::SmartPart.Properties.Resources.Search_16x16;
            this.btSerch.Location = new System.Drawing.Point(8, 13);
            this.btSerch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btSerch.Name = "btSerch";
            this.btSerch.Size = new System.Drawing.Size(140, 28);
            this.btSerch.TabIndex = 7;
            this.btSerch.Text = "ค้นหาข้อมูล (F8)";
            this.btSerch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btDelete
            // 
            this.btDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btDelete.Appearance.Options.UseFont = true;
            this.btDelete.Appearance.Options.UseTextOptions = true;
            this.btDelete.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btDelete.ImageOptions.Image = global::SmartPart.Properties.Resources.Delete_16x16;
            this.btDelete.Location = new System.Drawing.Point(8, 121);
            this.btDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(140, 28);
            this.btDelete.TabIndex = 11;
            this.btDelete.Text = "ยกเลิก (F7)";
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btEdit
            // 
            this.btEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btEdit.Appearance.Options.UseFont = true;
            this.btEdit.Appearance.Options.UseTextOptions = true;
            this.btEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btEdit.ImageOptions.Image = global::SmartPart.Properties.Resources.Edit_16x16;
            this.btEdit.Location = new System.Drawing.Point(8, 85);
            this.btEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(140, 28);
            this.btEdit.TabIndex = 10;
            this.btEdit.Text = "แก้ไข (F6)";
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1071, 64);
            this.panelControl1.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.Controls.Add(this.comboStatus);
            this.layoutControl1.Controls.Add(this.dateTo);
            this.layoutControl1.Controls.Add(this.txtBarcode);
            this.layoutControl1.Controls.Add(this.dateFrom);
            this.layoutControl1.Controls.Add(this.sluCus);
            this.layoutControl1.Controls.Add(this.comboTypedate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1067, 60);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // comboStatus
            // 
            this.comboStatus.EnterMoveNextControl = true;
            this.comboStatus.Location = new System.Drawing.Point(106, 33);
            this.comboStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comboStatus.Properties.Appearance.Options.UseFont = true;
            this.comboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboStatus.Size = new System.Drawing.Size(243, 22);
            this.comboStatus.StyleController = this.layoutControl1;
            this.comboStatus.TabIndex = 3;
            this.comboStatus.SelectedIndexChanged += new System.EventHandler(this.comboStatus_SelectedIndexChanged);
            // 
            // dateTo
            // 
            this.dateTo.EditValue = null;
            this.dateTo.EnterMoveNextControl = true;
            this.dateTo.Location = new System.Drawing.Point(913, 7);
            this.dateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTo.Name = "dateTo";
            this.dateTo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateTo.Properties.Appearance.Options.UseFont = true;
            this.dateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Size = new System.Drawing.Size(147, 22);
            this.dateTo.StyleController = this.layoutControl1;
            this.dateTo.TabIndex = 2;
            this.dateTo.EditValueChanged += new System.EventHandler(this.dateTo_EditValueChanged);
            // 
            // txtBarcode
            // 
            this.txtBarcode.EnterMoveNextControl = true;
            this.txtBarcode.Location = new System.Drawing.Point(448, 33);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtBarcode.Properties.Appearance.Options.UseFont = true;
            this.txtBarcode.Size = new System.Drawing.Size(612, 22);
            this.txtBarcode.StyleController = this.layoutControl1;
            this.txtBarcode.TabIndex = 4;
            // 
            // dateFrom
            // 
            this.dateFrom.EditValue = null;
            this.dateFrom.EnterMoveNextControl = true;
            this.dateFrom.Location = new System.Drawing.Point(696, 7);
            this.dateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateFrom.Properties.Appearance.Options.UseFont = true;
            this.dateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Size = new System.Drawing.Size(167, 22);
            this.dateFrom.StyleController = this.layoutControl1;
            this.dateFrom.TabIndex = 1;
            this.dateFrom.EditValueChanged += new System.EventHandler(this.dateFrom_EditValueChanged);
            // 
            // sluCus
            // 
            this.sluCus.EnterMoveNextControl = true;
            this.sluCus.Location = new System.Drawing.Point(106, 7);
            this.sluCus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sluCus.Name = "sluCus";
            this.sluCus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sluCus.Properties.Appearance.Options.UseFont = true;
            this.sluCus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sluCus.Properties.NullText = "แสดงทุกพ่อค้า";
            this.sluCus.Properties.View = this.searchLookUpEdit1View;
            this.sluCus.Size = new System.Drawing.Size(243, 22);
            this.sluCus.StyleController = this.layoutControl1;
            this.sluCus.TabIndex = 0;
            this.sluCus.EditValueChanged += new System.EventHandler(this.sluCus_EditValueChanged);
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
            this.comboTypedate.Location = new System.Drawing.Point(452, 7);
            this.comboTypedate.Name = "comboTypedate";
            this.comboTypedate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comboTypedate.Properties.Appearance.Options.UseFont = true;
            this.comboTypedate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboTypedate.Properties.Items.AddRange(new object[] {
            "เดือนนี้",
            "เดือนที่แล้ว",
            "กำหนดเอง"});
            this.comboTypedate.Size = new System.Drawing.Size(145, 22);
            this.comboTypedate.StyleController = this.layoutControl1;
            this.comboTypedate.TabIndex = 2;
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
            this.layoutControlItem6,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1067, 62);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.sluCus;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(346, 26);
            this.layoutControlItem1.Text = "พ่อค้า";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(96, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.dateFrom;
            this.layoutControlItem2.Location = new System.Drawing.Point(594, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(266, 26);
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
            this.layoutControlItem3.Location = new System.Drawing.Point(860, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(197, 26);
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
            this.layoutControlItem4.Size = new System.Drawing.Size(346, 26);
            this.layoutControlItem4.Text = "สถานะ";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(96, 17);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.comboTypedate;
            this.layoutControlItem6.CustomizationFormText = "ประเภทช่วงเวลา";
            this.layoutControlItem6.Location = new System.Drawing.Point(346, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(248, 26);
            this.layoutControlItem6.Text = "ประเภทช่วงเวลา";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(96, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txtBarcode;
            this.layoutControlItem5.Location = new System.Drawing.Point(346, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(711, 26);
            this.layoutControlItem5.Text = "บาร์โค้ดเอกสาร";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(90, 20);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // gridRO
            // 
            this.gridRO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRO.Location = new System.Drawing.Point(7, 7);
            this.gridRO.MainView = this.gvRO;
            this.gridRO.Name = "gridRO";
            this.gridRO.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoSearchCus});
            this.gridRO.Size = new System.Drawing.Size(1057, 381);
            this.gridRO.TabIndex = 0;
            this.gridRO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRO});
            // 
            // gvRO
            // 
            this.gvRO.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvRO.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvRO.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvRO.Appearance.Row.Options.UseFont = true;
            this.gvRO.ColumnPanelRowHeight = 30;
            this.gvRO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCus,
            this.colDateRO,
            this.colRONo,
            this.colListNo,
            this.colVatStatus,
            this.colSumDoc,
            this.colSellType,
            this.colROStatus,
            this.colReturnDate});
            this.gvRO.GridControl = this.gridRO;
            this.gvRO.IndicatorWidth = 30;
            this.gvRO.Name = "gvRO";
            this.gvRO.OptionsBehavior.Editable = false;
            this.gvRO.OptionsView.EnableAppearanceOddRow = true;
            this.gvRO.OptionsView.ShowGroupPanel = false;
            this.gvRO.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvRO_RowCellStyle);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ROH_ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colCus
            // 
            this.colCus.AppearanceCell.Options.UseTextOptions = true;
            this.colCus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCus.AppearanceHeader.Options.UseTextOptions = true;
            this.colCus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCus.Caption = "พ่อค้า";
            this.colCus.ColumnEdit = this.repoSearchCus;
            this.colCus.FieldName = "CUS_ID";
            this.colCus.Name = "colCus";
            this.colCus.Visible = true;
            this.colCus.VisibleIndex = 0;
            // 
            // repoSearchCus
            // 
            this.repoSearchCus.AutoHeight = false;
            this.repoSearchCus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoSearchCus.Name = "repoSearchCus";
            this.repoSearchCus.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colDateRO
            // 
            this.colDateRO.AppearanceCell.Options.UseTextOptions = true;
            this.colDateRO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateRO.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateRO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateRO.Caption = "วันที่ิ RO";
            this.colDateRO.FieldName = "RO_DATE";
            this.colDateRO.Name = "colDateRO";
            this.colDateRO.Visible = true;
            this.colDateRO.VisibleIndex = 1;
            // 
            // colRONo
            // 
            this.colRONo.AppearanceCell.Options.UseTextOptions = true;
            this.colRONo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colRONo.AppearanceHeader.Options.UseTextOptions = true;
            this.colRONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRONo.Caption = "เลขที่ RO";
            this.colRONo.FieldName = "RO_NO";
            this.colRONo.Name = "colRONo";
            this.colRONo.Visible = true;
            this.colRONo.VisibleIndex = 2;
            // 
            // colListNo
            // 
            this.colListNo.AppearanceCell.Options.UseTextOptions = true;
            this.colListNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colListNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colListNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colListNo.Caption = "จำนวนรายการ";
            this.colListNo.FieldName = "LIST_NO";
            this.colListNo.Name = "colListNo";
            this.colListNo.Visible = true;
            this.colListNo.VisibleIndex = 3;
            // 
            // colVatStatus
            // 
            this.colVatStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colVatStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVatStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colVatStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVatStatus.Caption = "สถานะ Vat";
            this.colVatStatus.FieldName = "_VAT_STATUS";
            this.colVatStatus.Name = "colVatStatus";
            this.colVatStatus.Visible = true;
            this.colVatStatus.VisibleIndex = 4;
            // 
            // colSumDoc
            // 
            this.colSumDoc.AppearanceCell.Options.UseTextOptions = true;
            this.colSumDoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSumDoc.AppearanceHeader.Options.UseTextOptions = true;
            this.colSumDoc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSumDoc.Caption = "รวมเงินตามเอกสาร";
            this.colSumDoc.DisplayFormat.FormatString = "n2";
            this.colSumDoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumDoc.FieldName = "SUM_DOC";
            this.colSumDoc.Name = "colSumDoc";
            this.colSumDoc.Visible = true;
            this.colSumDoc.VisibleIndex = 5;
            // 
            // colSellType
            // 
            this.colSellType.AppearanceCell.Options.UseTextOptions = true;
            this.colSellType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSellType.AppearanceHeader.Options.UseTextOptions = true;
            this.colSellType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSellType.Caption = "ประเภทการซื้อ";
            this.colSellType.Name = "colSellType";
            // 
            // colROStatus
            // 
            this.colROStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colROStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colROStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colROStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colROStatus.Caption = "สถานะการคืน";
            this.colROStatus.FieldName = "_RO_STATUS";
            this.colROStatus.Name = "colROStatus";
            this.colROStatus.Visible = true;
            this.colROStatus.VisibleIndex = 6;
            // 
            // colReturnDate
            // 
            this.colReturnDate.AppearanceCell.Options.UseTextOptions = true;
            this.colReturnDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReturnDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colReturnDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReturnDate.Caption = "วันที่ส่งคืน";
            this.colReturnDate.Name = "colReturnDate";
            this.colReturnDate.Visible = true;
            this.colReturnDate.VisibleIndex = 7;
            // 
            // bwList
            // 
            this.bwList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwList_DoWork);
            this.bwList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwList_RunWorkerCompleted);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridRO);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 64);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl2.Size = new System.Drawing.Size(1071, 395);
            this.panelControl2.TabIndex = 5;
            // 
            // frm_ROList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 459);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frm_ROList";
            this.Text = "Return Outward list";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ROList_KeyDown);
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
            ((System.ComponentModel.ISupportInitialize)(this.sluCus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboTypedate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSearchCus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl gridRO;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRO;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboStatus;
        private DevExpress.XtraEditors.DateEdit dateTo;
        private DevExpress.XtraEditors.TextEdit txtBarcode;
        private DevExpress.XtraEditors.DateEdit dateFrom;
        private DevExpress.XtraEditors.SearchLookUpEdit sluCus;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCus;
        private DevExpress.XtraGrid.Columns.GridColumn colDateRO;
        private DevExpress.XtraGrid.Columns.GridColumn colRONo;
        private DevExpress.XtraGrid.Columns.GridColumn colListNo;
        private DevExpress.XtraGrid.Columns.GridColumn colVatStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colSumDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colSellType;
        private DevExpress.XtraGrid.Columns.GridColumn colROStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colReturnDate;
        private System.ComponentModel.BackgroundWorker bwList;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repoSearchCus;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.SimpleButton btShowItem;
    private DevExpress.XtraEditors.SimpleButton btView;
    private DevExpress.XtraEditors.SimpleButton btActive;
    private DevExpress.XtraEditors.SimpleButton btSerch;
    private DevExpress.XtraEditors.SimpleButton btDelete;
    private DevExpress.XtraEditors.SimpleButton btEdit;
    private DevExpress.XtraEditors.ComboBoxEdit comboTypedate;
    private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
  }
}
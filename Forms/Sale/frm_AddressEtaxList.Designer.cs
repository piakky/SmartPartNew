namespace SmartPart.Forms.Sale
{
    partial class frm_AddressEtaxList
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridAddr = new DevExpress.XtraGrid.GridControl();
            this.gvAddr = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoSearchCus = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repoSearchCusView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.btActive = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAddr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAddr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSearchCus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSearchCusView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
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
            this.dockPanel1.ID = new System.Guid("4bd4297c-7932-4cc6-a45e-b5c61ec4313c");
            this.dockPanel1.Location = new System.Drawing.Point(1227, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.FloatOnDblClick = false;
            this.dockPanel1.Options.ResizeDirection = DevExpress.XtraBars.Docking.Helpers.ResizeDirection.None;
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(188, 200);
            this.dockPanel1.Size = new System.Drawing.Size(188, 558);
            this.dockPanel1.Text = "Option";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(180, 531);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btActive);
            this.panelControl1.Controls.Add(this.btSearch);
            this.panelControl1.Controls.Add(this.btEdit);
            this.panelControl1.Controls.Add(this.btAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(180, 531);
            this.panelControl1.TabIndex = 12;
            // 
            // btSearch
            // 
            this.btSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btSearch.Appearance.Options.UseFont = true;
            this.btSearch.ImageOptions.Image = global::SmartPart.Properties.Resources.Search_16x16;
            this.btSearch.Location = new System.Drawing.Point(14, 259);
            this.btSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(155, 28);
            this.btSearch.TabIndex = 11;
            this.btSearch.Text = "ค้นหาข้อมูล (F8)";
            this.btSearch.Visible = false;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btEdit.Appearance.Options.UseFont = true;
            this.btEdit.Appearance.Options.UseTextOptions = true;
            this.btEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btEdit.ImageOptions.Image = global::SmartPart.Properties.Resources.Edit_16x16;
            this.btEdit.Location = new System.Drawing.Point(14, 42);
            this.btEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(155, 28);
            this.btEdit.TabIndex = 5;
            this.btEdit.Text = "แก้ไข (F6)";
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btAdd.Appearance.Options.UseFont = true;
            this.btAdd.Appearance.Options.UseTextOptions = true;
            this.btAdd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btAdd.ImageOptions.Image = global::SmartPart.Properties.Resources.Add_16x16;
            this.btAdd.Location = new System.Drawing.Point(14, 6);
            this.btAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(155, 28);
            this.btAdd.TabIndex = 4;
            this.btAdd.Text = "เพิ่ม (F5)";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // gridAddr
            // 
            this.gridAddr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAddr.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridAddr.Location = new System.Drawing.Point(0, 0);
            this.gridAddr.MainView = this.gvAddr;
            this.gridAddr.Name = "gridAddr";
            this.gridAddr.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoSearchCus,
            this.repositoryItemRadioGroup1});
            this.gridAddr.Size = new System.Drawing.Size(1227, 558);
            this.gridAddr.TabIndex = 1;
            this.gridAddr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAddr});
            // 
            // gvAddr
            // 
            this.gvAddr.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvAddr.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvAddr.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvAddr.Appearance.Row.Options.UseFont = true;
            this.gvAddr.ColumnPanelRowHeight = 30;
            this.gvAddr.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gvAddr.GridControl = this.gridAddr;
            this.gvAddr.IndicatorWidth = 30;
            this.gvAddr.Name = "gvAddr";
            this.gvAddr.OptionsBehavior.Editable = false;
            this.gvAddr.OptionsFind.AlwaysVisible = true;
            this.gvAddr.OptionsView.EnableAppearanceOddRow = true;
            this.gvAddr.OptionsView.ShowGroupPanel = false;
            this.gvAddr.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvAddr_CustomDrawRowIndicator);
            this.gvAddr.DoubleClick += new System.EventHandler(this.gvAddr_DoubleClick);
            // 
            // colID
            // 
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ADDRESS_ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "รหัส";
            this.gridColumn1.FieldName = "ADDRESS_CODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "ชื่อลูกค้า";
            this.gridColumn2.FieldName = "CUSTOMER_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "ที่อยู่ 1";
            this.gridColumn3.FieldName = "ADDRESS_1";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "ที่อยู่ 2";
            this.gridColumn4.FieldName = "ADDRESS_2";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "ที่อยู่ 3";
            this.gridColumn5.FieldName = "ADDRESS_3";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "ที่อยู่ 4";
            this.gridColumn6.FieldName = "ADDRESS_4";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "เลขผู้เสียภาษี";
            this.gridColumn7.FieldName = "TAX_ID";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "สาขา";
            this.gridColumn8.FieldName = "BRANCH";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "เบอร์โทร";
            this.gridColumn9.FieldName = "TEL";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "Fax";
            this.gridColumn10.FieldName = "FAX";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "Email";
            this.gridColumn11.FieldName = "E_MAIL";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.Caption = "ผู้ติดต่อ";
            this.gridColumn12.FieldName = "CONTRACT";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            // 
            // repoSearchCus
            // 
            this.repoSearchCus.AutoHeight = false;
            this.repoSearchCus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoSearchCus.Name = "repoSearchCus";
            this.repoSearchCus.View = this.repoSearchCusView;
            // 
            // repoSearchCusView
            // 
            this.repoSearchCusView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repoSearchCusView.Name = "repoSearchCusView";
            this.repoSearchCusView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repoSearchCusView.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(2)), "ปิด"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(1)), "เปิด")});
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // btActive
            // 
            this.btActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btActive.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btActive.Appearance.Options.UseFont = true;
            this.btActive.Appearance.Options.UseTextOptions = true;
            this.btActive.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btActive.ImageOptions.Image = global::SmartPart.Properties.Resources.Settings_16x16;
            this.btActive.Location = new System.Drawing.Point(14, 78);
            this.btActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btActive.Name = "btActive";
            this.btActive.Size = new System.Drawing.Size(155, 28);
            this.btActive.TabIndex = 12;
            this.btActive.Text = "เลือกข้อมูล (F9)";
            this.btActive.Click += new System.EventHandler(this.btActive_Click);
            // 
            // frm_AddressEtaxList
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 558);
            this.Controls.Add(this.gridAddr);
            this.Controls.Add(this.dockPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_AddressEtaxList";
            this.Text = "ข้อมูลที่อยู่";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_AddressEtaxList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_AddressEtaxList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAddr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAddr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSearchCus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSearchCusView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraEditors.SimpleButton btAdd;
        private DevExpress.XtraEditors.SimpleButton btEdit;
        private DevExpress.XtraGrid.GridControl gridAddr;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAddr;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repoSearchCus;
        private DevExpress.XtraGrid.Views.Grid.GridView repoSearchCusView;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.SimpleButton btSearch;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btActive;
    }
}
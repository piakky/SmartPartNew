namespace SmartPart.Forms.General
{
    partial class frm_Group_Vers
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
      this.repositoryItemSearchLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.chkShow = new DevExpress.XtraEditors.CheckEdit();
      this.bwLoad = new System.ComponentModel.BackgroundWorker();
      this.panelMain = new DevExpress.XtraEditors.PanelControl();
      this.gridItem = new DevExpress.XtraGrid.GridControl();
      this.gvItem = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colSubID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colSUbItem = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repoSearchItem = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
      this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
      this.btDeleteItem = new DevExpress.XtraEditors.SimpleButton();
      this.btAddItem = new DevExpress.XtraEditors.SimpleButton();
      this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
      this.gridSub = new DevExpress.XtraGrid.GridControl();
      this.gvSub = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.btView = new DevExpress.XtraEditors.SimpleButton();
      this.btDeleteGroup = new DevExpress.XtraEditors.SimpleButton();
      this.btEditGroup = new DevExpress.XtraEditors.SimpleButton();
      this.btAddGroup = new DevExpress.XtraEditors.SimpleButton();
      this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
      this.gridGroup = new DevExpress.XtraGrid.GridControl();
      this.gvGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colDesc = new DevExpress.XtraGrid.Columns.GridColumn();
      this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chkShow.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
      this.panelMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvItem)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repoSearchItem)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
      this.panelControl3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
      this.panelControl4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridSub)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvSub)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
      this.panelControl6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridGroup)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvGroup)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
      this.SuspendLayout();
      // 
      // repositoryItemSearchLookUpEdit1
      // 
      this.repositoryItemSearchLookUpEdit1.AutoHeight = false;
      this.repositoryItemSearchLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemSearchLookUpEdit1.Name = "repositoryItemSearchLookUpEdit1";
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.chkShow);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(1271, 49);
      this.panelControl1.TabIndex = 0;
      // 
      // chkShow
      // 
      this.chkShow.Location = new System.Drawing.Point(27, 12);
      this.chkShow.Name = "chkShow";
      this.chkShow.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.chkShow.Properties.Appearance.Options.UseFont = true;
      this.chkShow.Properties.Caption = "แสดงกลุ่มสินค้าทั้งหมด";
      this.chkShow.Size = new System.Drawing.Size(176, 21);
      this.chkShow.TabIndex = 0;
      this.chkShow.Visible = false;
      this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
      // 
      // bwLoad
      // 
      this.bwLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwLoad_DoWork);
      this.bwLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwLoad_RunWorkerCompleted);
      // 
      // panelMain
      // 
      this.panelMain.Controls.Add(this.gridItem);
      this.panelMain.Controls.Add(this.panelControl3);
      this.panelMain.Controls.Add(this.panelControl4);
      this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelMain.Location = new System.Drawing.Point(0, 49);
      this.panelMain.Name = "panelMain";
      this.panelMain.Size = new System.Drawing.Size(1271, 567);
      this.panelMain.TabIndex = 2;
      // 
      // gridItem
      // 
      this.gridItem.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridItem.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.gridItem.Location = new System.Drawing.Point(856, 2);
      this.gridItem.MainView = this.gvItem;
      this.gridItem.Name = "gridItem";
      this.gridItem.Padding = new System.Windows.Forms.Padding(5);
      this.gridItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoSearchItem});
      this.gridItem.Size = new System.Drawing.Size(413, 503);
      this.gridItem.TabIndex = 3;
      this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItem});
      // 
      // gvItem
      // 
      this.gvItem.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
      this.gvItem.Appearance.HeaderPanel.Options.UseFont = true;
      this.gvItem.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
      this.gvItem.Appearance.Row.Options.UseFont = true;
      this.gvItem.ColumnPanelRowHeight = 30;
      this.gvItem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSubID,
            this.colSUbItem,
            this.colName});
      this.gvItem.GridControl = this.gridItem;
      this.gvItem.Name = "gvItem";
      this.gvItem.OptionsBehavior.Editable = false;
      this.gvItem.OptionsView.EnableAppearanceOddRow = true;
      this.gvItem.OptionsView.ShowGroupPanel = false;
      // 
      // colSubID
      // 
      this.colSubID.Caption = "ID";
      this.colSubID.FieldName = "ITEM_ID";
      this.colSubID.Name = "colSubID";
      this.colSubID.OptionsColumn.ShowInCustomizationForm = false;
      // 
      // colSUbItem
      // 
      this.colSUbItem.AppearanceCell.Options.UseTextOptions = true;
      this.colSUbItem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      this.colSUbItem.AppearanceHeader.Options.UseTextOptions = true;
      this.colSUbItem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.colSUbItem.Caption = "รหัสสินค้า";
      this.colSUbItem.FieldName = "ITEM_CODE";
      this.colSUbItem.Name = "colSUbItem";
      this.colSUbItem.Visible = true;
      this.colSUbItem.VisibleIndex = 0;
      // 
      // colName
      // 
      this.colName.AppearanceCell.Options.UseTextOptions = true;
      this.colName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      this.colName.AppearanceHeader.Options.UseTextOptions = true;
      this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.colName.Caption = "รายละเอียดสินค้า";
      this.colName.FieldName = "FULL_NAME";
      this.colName.Name = "colName";
      this.colName.Visible = true;
      this.colName.VisibleIndex = 1;
      // 
      // repoSearchItem
      // 
      this.repoSearchItem.AutoHeight = false;
      this.repoSearchItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repoSearchItem.Name = "repoSearchItem";
      this.repoSearchItem.View = this.gridView3;
      // 
      // gridView3
      // 
      this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gridView3.Name = "gridView3";
      this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridView3.OptionsView.ShowGroupPanel = false;
      // 
      // panelControl3
      // 
      this.panelControl3.Controls.Add(this.btDeleteItem);
      this.panelControl3.Controls.Add(this.btAddItem);
      this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl3.Location = new System.Drawing.Point(856, 505);
      this.panelControl3.Name = "panelControl3";
      this.panelControl3.Size = new System.Drawing.Size(413, 60);
      this.panelControl3.TabIndex = 2;
      // 
      // btDeleteItem
      // 
      this.btDeleteItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.btDeleteItem.Appearance.Options.UseFont = true;
      this.btDeleteItem.Location = new System.Drawing.Point(97, 13);
      this.btDeleteItem.Name = "btDeleteItem";
      this.btDeleteItem.Size = new System.Drawing.Size(77, 35);
      this.btDeleteItem.TabIndex = 0;
      this.btDeleteItem.Text = "ลบสินค้า";
      this.btDeleteItem.Click += new System.EventHandler(this.btDeleteItem_Click);
      // 
      // btAddItem
      // 
      this.btAddItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.btAddItem.Appearance.Options.UseFont = true;
      this.btAddItem.Location = new System.Drawing.Point(5, 13);
      this.btAddItem.Name = "btAddItem";
      this.btAddItem.Size = new System.Drawing.Size(86, 35);
      this.btAddItem.TabIndex = 0;
      this.btAddItem.Text = "เพิ่มสินค้า";
      this.btAddItem.Click += new System.EventHandler(this.btAddItem_Click);
      // 
      // panelControl4
      // 
      this.panelControl4.Controls.Add(this.gridSub);
      this.panelControl4.Controls.Add(this.panelControl2);
      this.panelControl4.Controls.Add(this.panelControl6);
      this.panelControl4.Dock = System.Windows.Forms.DockStyle.Left;
      this.panelControl4.Location = new System.Drawing.Point(2, 2);
      this.panelControl4.Name = "panelControl4";
      this.panelControl4.Size = new System.Drawing.Size(854, 563);
      this.panelControl4.TabIndex = 0;
      // 
      // gridSub
      // 
      this.gridSub.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridSub.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.gridSub.Location = new System.Drawing.Point(421, 2);
      this.gridSub.MainView = this.gvSub;
      this.gridSub.Name = "gridSub";
      this.gridSub.Padding = new System.Windows.Forms.Padding(5);
      this.gridSub.Size = new System.Drawing.Size(431, 501);
      this.gridSub.TabIndex = 4;
      this.gridSub.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSub});
      // 
      // gvSub
      // 
      this.gvSub.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
      this.gvSub.Appearance.HeaderPanel.Options.UseFont = true;
      this.gvSub.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
      this.gvSub.Appearance.Row.Options.UseFont = true;
      this.gvSub.ColumnPanelRowHeight = 30;
      this.gvSub.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
      this.gvSub.GridControl = this.gridSub;
      this.gvSub.Name = "gvSub";
      this.gvSub.OptionsBehavior.Editable = false;
      this.gvSub.OptionsView.EnableAppearanceOddRow = true;
      this.gvSub.OptionsView.ShowGroupPanel = false;
      this.gvSub.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvSub_FocusedRowChanged);
      // 
      // gridColumn1
      // 
      this.gridColumn1.Caption = "ID";
      this.gridColumn1.FieldName = "SUB_ID";
      this.gridColumn1.Name = "gridColumn1";
      this.gridColumn1.OptionsColumn.ShowInCustomizationForm = false;
      // 
      // gridColumn2
      // 
      this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
      this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
      this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.gridColumn2.Caption = "รหัสกลุ่มย่อย";
      this.gridColumn2.FieldName = "SUB_CODE";
      this.gridColumn2.Name = "gridColumn2";
      this.gridColumn2.Visible = true;
      this.gridColumn2.VisibleIndex = 0;
      // 
      // gridColumn3
      // 
      this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
      this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
      this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.gridColumn3.Caption = "ชื่อกลุ่มย่อย";
      this.gridColumn3.FieldName = "SUB_NAME";
      this.gridColumn3.Name = "gridColumn3";
      this.gridColumn3.Visible = true;
      this.gridColumn3.VisibleIndex = 1;
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.btView);
      this.panelControl2.Controls.Add(this.btDeleteGroup);
      this.panelControl2.Controls.Add(this.btEditGroup);
      this.panelControl2.Controls.Add(this.btAddGroup);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl2.Location = new System.Drawing.Point(421, 503);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(431, 58);
      this.panelControl2.TabIndex = 1;
      // 
      // btView
      // 
      this.btView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btView.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.btView.Appearance.Options.UseFont = true;
      this.btView.Location = new System.Drawing.Point(341, 13);
      this.btView.Name = "btView";
      this.btView.Size = new System.Drawing.Size(85, 35);
      this.btView.TabIndex = 0;
      this.btView.Text = "แสดง Item";
      // 
      // btDeleteGroup
      // 
      this.btDeleteGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.btDeleteGroup.Appearance.Options.UseFont = true;
      this.btDeleteGroup.Enabled = false;
      this.btDeleteGroup.Location = new System.Drawing.Point(209, 13);
      this.btDeleteGroup.Name = "btDeleteGroup";
      this.btDeleteGroup.Size = new System.Drawing.Size(87, 35);
      this.btDeleteGroup.TabIndex = 0;
      this.btDeleteGroup.Text = "ลบกลุ่มย่อย";
      this.btDeleteGroup.Click += new System.EventHandler(this.btDeleteGroup_Click);
      // 
      // btEditGroup
      // 
      this.btEditGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.btEditGroup.Appearance.Options.UseFont = true;
      this.btEditGroup.Location = new System.Drawing.Point(106, 13);
      this.btEditGroup.Name = "btEditGroup";
      this.btEditGroup.Size = new System.Drawing.Size(97, 35);
      this.btEditGroup.TabIndex = 0;
      this.btEditGroup.Text = "แก้ไขกลุ่มย่อย";
      this.btEditGroup.Click += new System.EventHandler(this.btEditGroup_Click);
      // 
      // btAddGroup
      // 
      this.btAddGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.btAddGroup.Appearance.Options.UseFont = true;
      this.btAddGroup.Location = new System.Drawing.Point(5, 13);
      this.btAddGroup.Name = "btAddGroup";
      this.btAddGroup.Size = new System.Drawing.Size(95, 35);
      this.btAddGroup.TabIndex = 0;
      this.btAddGroup.Text = "เพิ่มกลุ่มย่อย";
      this.btAddGroup.Click += new System.EventHandler(this.btAddGroup_Click);
      // 
      // panelControl6
      // 
      this.panelControl6.Controls.Add(this.gridGroup);
      this.panelControl6.Controls.Add(this.panelControl5);
      this.panelControl6.Dock = System.Windows.Forms.DockStyle.Left;
      this.panelControl6.Location = new System.Drawing.Point(2, 2);
      this.panelControl6.Name = "panelControl6";
      this.panelControl6.Size = new System.Drawing.Size(419, 559);
      this.panelControl6.TabIndex = 0;
      // 
      // gridGroup
      // 
      this.gridGroup.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridGroup.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.gridGroup.Location = new System.Drawing.Point(2, 2);
      this.gridGroup.MainView = this.gvGroup;
      this.gridGroup.Name = "gridGroup";
      this.gridGroup.Padding = new System.Windows.Forms.Padding(5);
      this.gridGroup.Size = new System.Drawing.Size(415, 500);
      this.gridGroup.TabIndex = 4;
      this.gridGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGroup});
      // 
      // gvGroup
      // 
      this.gvGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
      this.gvGroup.Appearance.HeaderPanel.Options.UseFont = true;
      this.gvGroup.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
      this.gvGroup.Appearance.Row.Options.UseFont = true;
      this.gvGroup.ColumnPanelRowHeight = 30;
      this.gvGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colGroupCode,
            this.colDesc});
      this.gvGroup.GridControl = this.gridGroup;
      this.gvGroup.Name = "gvGroup";
      this.gvGroup.OptionsBehavior.Editable = false;
      this.gvGroup.OptionsView.EnableAppearanceOddRow = true;
      this.gvGroup.OptionsView.ShowGroupPanel = false;
      this.gvGroup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvGroup_FocusedRowChanged);
      // 
      // colID
      // 
      this.colID.Caption = "ID";
      this.colID.FieldName = "GROUP_ID";
      this.colID.Name = "colID";
      this.colID.OptionsColumn.ShowInCustomizationForm = false;
      // 
      // colGroupCode
      // 
      this.colGroupCode.AppearanceCell.Options.UseTextOptions = true;
      this.colGroupCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      this.colGroupCode.AppearanceHeader.Options.UseTextOptions = true;
      this.colGroupCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.colGroupCode.Caption = "รหัสอเนกประสงค์";
      this.colGroupCode.FieldName = "VERSATILE_CODE";
      this.colGroupCode.Name = "colGroupCode";
      this.colGroupCode.Visible = true;
      this.colGroupCode.VisibleIndex = 0;
      // 
      // colDesc
      // 
      this.colDesc.AppearanceCell.Options.UseTextOptions = true;
      this.colDesc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      this.colDesc.AppearanceHeader.Options.UseTextOptions = true;
      this.colDesc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.colDesc.Caption = "ชื่ออเนกประสงค์";
      this.colDesc.FieldName = "VERSATILE_NAME";
      this.colDesc.Name = "colDesc";
      this.colDesc.Visible = true;
      this.colDesc.VisibleIndex = 1;
      // 
      // panelControl5
      // 
      this.panelControl5.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl5.Location = new System.Drawing.Point(2, 502);
      this.panelControl5.Name = "panelControl5";
      this.panelControl5.Size = new System.Drawing.Size(415, 55);
      this.panelControl5.TabIndex = 3;
      // 
      // frm_Group_Vers
      // 
      this.Appearance.Options.UseFont = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1271, 616);
      this.Controls.Add(this.panelMain);
      this.Controls.Add(this.panelControl1);
      this.Font = new System.Drawing.Font("Tahoma", 10F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "frm_Group_Vers";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "กลุ่มอเนกประสงค์";
      this.Load += new System.EventHandler(this.frm_GroupJoin_Load);
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.chkShow.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
      this.panelMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvItem)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repoSearchItem)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
      this.panelControl3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
      this.panelControl4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridSub)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvSub)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
      this.panelControl6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridGroup)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvGroup)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkShow;
        private System.ComponentModel.BackgroundWorker bwLoad;
    private DevExpress.XtraEditors.PanelControl panelMain;
    private DevExpress.XtraGrid.GridControl gridItem;
    private DevExpress.XtraGrid.Views.Grid.GridView gvItem;
    private DevExpress.XtraGrid.Columns.GridColumn colSubID;
    private DevExpress.XtraGrid.Columns.GridColumn colSUbItem;
    private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repoSearchItem;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
    private DevExpress.XtraGrid.Columns.GridColumn colName;
    private DevExpress.XtraEditors.PanelControl panelControl3;
    private DevExpress.XtraEditors.SimpleButton btDeleteItem;
    private DevExpress.XtraEditors.SimpleButton btAddItem;
    private DevExpress.XtraEditors.PanelControl panelControl4;
    private DevExpress.XtraGrid.GridControl gridSub;
    private DevExpress.XtraGrid.Views.Grid.GridView gvSub;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.SimpleButton btView;
    private DevExpress.XtraEditors.SimpleButton btDeleteGroup;
    private DevExpress.XtraEditors.SimpleButton btEditGroup;
    private DevExpress.XtraEditors.SimpleButton btAddGroup;
    private DevExpress.XtraEditors.PanelControl panelControl6;
    private DevExpress.XtraGrid.GridControl gridGroup;
    private DevExpress.XtraGrid.Views.Grid.GridView gvGroup;
    private DevExpress.XtraGrid.Columns.GridColumn colID;
    private DevExpress.XtraGrid.Columns.GridColumn colGroupCode;
    private DevExpress.XtraGrid.Columns.GridColumn colDesc;
    private DevExpress.XtraEditors.PanelControl panelControl5;
    private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEdit1;
  }
}
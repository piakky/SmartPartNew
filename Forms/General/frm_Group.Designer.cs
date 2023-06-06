namespace SmartPart.Forms.General
{
    partial class frm_Group
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkShow = new DevExpress.XtraEditors.CheckEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridGroup = new DevExpress.XtraGrid.GridControl();
            this.gvGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btActive = new DevExpress.XtraEditors.SimpleButton();
            this.btView = new DevExpress.XtraEditors.SimpleButton();
            this.btDeleteGroup = new DevExpress.XtraEditors.SimpleButton();
            this.btEditGroup = new DevExpress.XtraEditors.SimpleButton();
            this.btAddGroup = new DevExpress.XtraEditors.SimpleButton();
            this.gridSub = new DevExpress.XtraGrid.GridControl();
            this.gvSub = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSubID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSUbItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoSearchItem = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btDeleteItem = new DevExpress.XtraEditors.SimpleButton();
            this.btAddItem = new DevExpress.XtraEditors.SimpleButton();
            this.bwLoad = new System.ComponentModel.BackgroundWorker();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSearchItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkShow);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(937, 49);
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
            this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 49);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridGroup);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridSub);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(937, 362);
            this.splitContainerControl1.SplitterPosition = 499;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridGroup
            // 
            this.gridGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGroup.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridGroup.Location = new System.Drawing.Point(0, 0);
            this.gridGroup.MainView = this.gvGroup;
            this.gridGroup.Name = "gridGroup";
            this.gridGroup.Padding = new System.Windows.Forms.Padding(5);
            this.gridGroup.Size = new System.Drawing.Size(499, 302);
            this.gridGroup.TabIndex = 1;
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
            this.colDesc,
            this.colActive});
            this.gvGroup.GridControl = this.gridGroup;
            this.gvGroup.Name = "gvGroup";
            this.gvGroup.OptionsBehavior.Editable = false;
            this.gvGroup.OptionsView.EnableAppearanceOddRow = true;
            this.gvGroup.OptionsView.ShowGroupPanel = false;
            this.gvGroup.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvGroup_RowCellStyle);
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
            this.colGroupCode.Caption = "กลุ่มสินค้า";
            this.colGroupCode.FieldName = "GROUP_CODE";
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
            this.colDesc.Caption = "รายละเอียด";
            this.colDesc.FieldName = "DESCRIPTION";
            this.colDesc.Name = "colDesc";
            this.colDesc.Visible = true;
            this.colDesc.VisibleIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btActive);
            this.panelControl2.Controls.Add(this.btView);
            this.panelControl2.Controls.Add(this.btDeleteGroup);
            this.panelControl2.Controls.Add(this.btEditGroup);
            this.panelControl2.Controls.Add(this.btAddGroup);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 302);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(499, 60);
            this.panelControl2.TabIndex = 0;
            // 
            // btActive
            // 
            this.btActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btActive.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btActive.Appearance.Options.UseFont = true;
            this.btActive.Appearance.Options.UseTextOptions = true;
            this.btActive.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btActive.Location = new System.Drawing.Point(302, 13);
            this.btActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btActive.Name = "btActive";
            this.btActive.Size = new System.Drawing.Size(101, 35);
            this.btActive.TabIndex = 6;
            this.btActive.Text = "Set Active (F9)";
            this.btActive.Click += new System.EventHandler(this.btActive_Click);
            // 
            // btView
            // 
            this.btView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btView.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btView.Appearance.Options.UseFont = true;
            this.btView.Location = new System.Drawing.Point(409, 13);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(85, 35);
            this.btView.TabIndex = 0;
            this.btView.Text = "แสดง Item";
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // btDeleteGroup
            // 
            this.btDeleteGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btDeleteGroup.Appearance.Options.UseFont = true;
            this.btDeleteGroup.Location = new System.Drawing.Point(209, 13);
            this.btDeleteGroup.Name = "btDeleteGroup";
            this.btDeleteGroup.Size = new System.Drawing.Size(87, 35);
            this.btDeleteGroup.TabIndex = 0;
            this.btDeleteGroup.Text = "ลบกลุ่มสินค้า";
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
            this.btEditGroup.Text = "แก้ไขกลุ่มสินค้า";
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
            this.btAddGroup.Text = "เพิ่มกลุ่มสินค้า";
            this.btAddGroup.Click += new System.EventHandler(this.btAddGroup_Click);
            // 
            // gridSub
            // 
            this.gridSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSub.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridSub.Location = new System.Drawing.Point(0, 0);
            this.gridSub.MainView = this.gvSub;
            this.gridSub.Name = "gridSub";
            this.gridSub.Padding = new System.Windows.Forms.Padding(5);
            this.gridSub.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoSearchItem});
            this.gridSub.Size = new System.Drawing.Size(433, 302);
            this.gridSub.TabIndex = 2;
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
            this.colSubID,
            this.colSUbItem,
            this.colName});
            this.gvSub.GridControl = this.gridSub;
            this.gvSub.Name = "gvSub";
            this.gvSub.OptionsBehavior.Editable = false;
            this.gvSub.OptionsView.EnableAppearanceOddRow = true;
            this.gvSub.OptionsView.ShowGroupPanel = false;
            this.gvSub.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvSub_RowCellStyle);
            this.gvSub.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvSub_FocusedRowChanged);
            // 
            // colSubID
            // 
            this.colSubID.Caption = "ID";
            this.colSubID.FieldName = "SUBID";
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
            this.colSUbItem.ColumnEdit = this.repoSearchItem;
            this.colSUbItem.FieldName = "ITEM_ID";
            this.colSUbItem.Name = "colSUbItem";
            this.colSUbItem.Visible = true;
            this.colSUbItem.VisibleIndex = 0;
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
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btDeleteItem);
            this.panelControl3.Controls.Add(this.btAddItem);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 302);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(433, 60);
            this.panelControl3.TabIndex = 1;
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
            // bwLoad
            // 
            this.bwLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwLoad_DoWork);
            this.bwLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwLoad_RunWorkerCompleted);
            // 
            // colActive
            // 
            this.colActive.Caption = "Active";
            this.colActive.FieldName = "GROUP_ACTIVE";
            this.colActive.Name = "colActive";
            this.colActive.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            // 
            // frm_Group
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 411);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_Group";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Group";
            this.Load += new System.EventHandler(this.frm_GroupJoin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Group_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkShow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSearchItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkShow;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDesc;
        private DevExpress.XtraGrid.GridControl gridSub;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSub;
        private DevExpress.XtraGrid.Columns.GridColumn colSubID;
        private DevExpress.XtraGrid.Columns.GridColumn colSUbItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repoSearchItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.SimpleButton btView;
        private DevExpress.XtraEditors.SimpleButton btDeleteGroup;
        private DevExpress.XtraEditors.SimpleButton btEditGroup;
        private DevExpress.XtraEditors.SimpleButton btAddGroup;
        private DevExpress.XtraEditors.SimpleButton btDeleteItem;
        private DevExpress.XtraEditors.SimpleButton btAddItem;
        private System.ComponentModel.BackgroundWorker bwLoad;
        private DevExpress.XtraEditors.SimpleButton btActive;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
    }
}
namespace SmartPart.Forms.General
{
    partial class frm_ItemEdit11
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
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.searchPOGroupsCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridPO_Group = new DevExpress.XtraGrid.GridControl();
            this.gvPO_Group = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colP_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colP_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colP_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btPartDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btPartEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btPartAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.bwItem = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchPOGroupsCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPO_Group)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPO_Group)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(545, 369);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.searchPOGroupsCode);
            this.panelControl4.Controls.Add(this.gridPO_Group);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 61);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(541, 271);
            this.panelControl4.TabIndex = 20;
            // 
            // searchPOGroupsCode
            // 
            this.searchPOGroupsCode.EditValue = "เลือกรหัสเจ้าหนี้";
            this.searchPOGroupsCode.Location = new System.Drawing.Point(22, 124);
            this.searchPOGroupsCode.Name = "searchPOGroupsCode";
            this.searchPOGroupsCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchPOGroupsCode.Properties.NullText = "เลือกกลุ่มสั่งซื้อสินค้า";
            this.searchPOGroupsCode.Properties.View = this.gridView4;
            this.searchPOGroupsCode.Size = new System.Drawing.Size(119, 20);
            this.searchPOGroupsCode.TabIndex = 21;
            this.searchPOGroupsCode.Visible = false;
            // 
            // gridView4
            // 
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gridPO_Group
            // 
            this.gridPO_Group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPO_Group.Location = new System.Drawing.Point(2, 2);
            this.gridPO_Group.MainView = this.gvPO_Group;
            this.gridPO_Group.Name = "gridPO_Group";
            this.gridPO_Group.Size = new System.Drawing.Size(537, 267);
            this.gridPO_Group.TabIndex = 20;
            this.gridPO_Group.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPO_Group});
            // 
            // gvPO_Group
            // 
            this.gvPO_Group.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvPO_Group.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPO_Group.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvPO_Group.Appearance.Row.Options.UseFont = true;
            this.gvPO_Group.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colP_id,
            this.colP_code,
            this.colP_name});
            this.gvPO_Group.GridControl = this.gridPO_Group;
            this.gvPO_Group.IndicatorWidth = 30;
            this.gvPO_Group.Name = "gvPO_Group";
            this.gvPO_Group.OptionsView.ShowFooter = true;
            this.gvPO_Group.OptionsView.ShowGroupPanel = false;
            // 
            // colP_id
            // 
            this.colP_id.Caption = "id";
            this.colP_id.Name = "colP_id";
            // 
            // colP_code
            // 
            this.colP_code.Caption = "รหัสกลุ่มสั่งซื้อสินค้า";
            this.colP_code.FieldName = "PO_GROUP_CODE";
            this.colP_code.Name = "colP_code";
            this.colP_code.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PO_GROUP_CODE", "จำนวนรายการ = {0}")});
            this.colP_code.Visible = true;
            this.colP_code.VisibleIndex = 0;
            // 
            // colP_name
            // 
            this.colP_name.Caption = "ชื่อกลุ่มสั่งซื้อสินค้า";
            this.colP_name.FieldName = "PO_GROUP_NAME";
            this.colP_name.Name = "colP_name";
            this.colP_name.Visible = true;
            this.colP_name.VisibleIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btPartDelete);
            this.panelControl3.Controls.Add(this.btPartEdit);
            this.panelControl3.Controls.Add(this.btPartAdd);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 332);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(541, 35);
            this.panelControl3.TabIndex = 19;
            // 
            // btPartDelete
            // 
            this.btPartDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btPartDelete.Appearance.Options.UseFont = true;
            this.btPartDelete.Location = new System.Drawing.Point(189, 6);
            this.btPartDelete.Name = "btPartDelete";
            this.btPartDelete.Size = new System.Drawing.Size(83, 25);
            this.btPartDelete.TabIndex = 0;
            this.btPartDelete.Text = "ลบ";
            this.btPartDelete.Click += new System.EventHandler(this.btPartDelete_Click);
            // 
            // btPartEdit
            // 
            this.btPartEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btPartEdit.Appearance.Options.UseFont = true;
            this.btPartEdit.Location = new System.Drawing.Point(100, 6);
            this.btPartEdit.Name = "btPartEdit";
            this.btPartEdit.Size = new System.Drawing.Size(83, 25);
            this.btPartEdit.TabIndex = 0;
            this.btPartEdit.Text = "แก้ไข";
            this.btPartEdit.Click += new System.EventHandler(this.btPartEdit_Click);
            // 
            // btPartAdd
            // 
            this.btPartAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btPartAdd.Appearance.Options.UseFont = true;
            this.btPartAdd.Location = new System.Drawing.Point(11, 6);
            this.btPartAdd.Name = "btPartAdd";
            this.btPartAdd.Size = new System.Drawing.Size(83, 25);
            this.btPartAdd.TabIndex = 0;
            this.btPartAdd.Text = "เพิ่ม";
            this.btPartAdd.Click += new System.EventHandler(this.btPartAdd_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btClose);
            this.panelControl2.Controls.Add(this.btSave);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(541, 59);
            this.panelControl2.TabIndex = 17;
            // 
            // btClose
            // 
            this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btClose.Appearance.Options.UseFont = true;
            this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.btClose.Location = new System.Drawing.Point(148, 9);
            this.btClose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(135, 46);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "ยกเลิก (ESC)";
            this.btClose.ToolTip = "ยกเลิก = ESC";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSave
            // 
            this.btSave.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btSave.Appearance.Options.UseFont = true;
            this.btSave.ImageOptions.Image = global::SmartPart.Properties.Resources.page_save;
            this.btSave.Location = new System.Drawing.Point(10, 9);
            this.btSave.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(135, 46);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "บันทึก (F2)";
            this.btSave.ToolTip = "บันทึก = F2";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // bwItem
            // 
            this.bwItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwItem_DoWork);
            this.bwItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwItem_RunWorkerCompleted);
            // 
            // frm_ItemEdit11
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 369);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ItemEdit11";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รหัสสินค้า-กลุ่มสั่งซื้อ [แก้ไข]";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ItemEdit11_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchPOGroupsCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPO_Group)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPO_Group)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.ComponentModel.BackgroundWorker bwItem;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btPartDelete;
        private DevExpress.XtraEditors.SimpleButton btPartEdit;
        private DevExpress.XtraEditors.SimpleButton btPartAdd;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.SimpleButton btSave;
    private DevExpress.XtraGrid.GridControl gridPO_Group;
    private DevExpress.XtraGrid.Views.Grid.GridView gvPO_Group;
    private DevExpress.XtraGrid.Columns.GridColumn colP_id;
    private DevExpress.XtraGrid.Columns.GridColumn colP_code;
    private DevExpress.XtraGrid.Columns.GridColumn colP_name;
    private DevExpress.XtraEditors.SearchLookUpEdit searchPOGroupsCode;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
  }
}
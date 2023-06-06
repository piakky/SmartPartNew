namespace SmartPart.Forms.General
{
    partial class frm_ItemEdit7
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
            this.gridAlternate = new DevExpress.XtraGrid.GridControl();
            this.gvAlternate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colA_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_band = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.r_status = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlternate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_status)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(681, 369);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.gridAlternate);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 61);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(677, 271);
            this.panelControl4.TabIndex = 20;
            // 
            // gridAlternate
            // 
            this.gridAlternate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAlternate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridAlternate.Location = new System.Drawing.Point(2, 2);
            this.gridAlternate.MainView = this.gvAlternate;
            this.gridAlternate.Name = "gridAlternate";
            this.gridAlternate.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.r_status});
            this.gridAlternate.Size = new System.Drawing.Size(673, 267);
            this.gridAlternate.TabIndex = 18;
            this.gridAlternate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAlternate});
            // 
            // gvAlternate
            // 
            this.gvAlternate.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvAlternate.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvAlternate.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvAlternate.Appearance.Row.Options.UseFont = true;
            this.gvAlternate.ColumnPanelRowHeight = 3;
            this.gvAlternate.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colA_id,
            this.colA_code,
            this.colA_band,
            this.colA_status});
            this.gvAlternate.GridControl = this.gridAlternate;
            this.gvAlternate.IndicatorWidth = 30;
            this.gvAlternate.Name = "gvAlternate";
            this.gvAlternate.OptionsBehavior.Editable = false;
            this.gvAlternate.OptionsView.RowAutoHeight = true;
            this.gvAlternate.OptionsView.ShowFooter = true;
            this.gvAlternate.OptionsView.ShowGroupPanel = false;
            this.gvAlternate.RowHeight = 10;
            // 
            // colA_id
            // 
            this.colA_id.Caption = "id";
            this.colA_id.Name = "colA_id";
            // 
            // colA_code
            // 
            this.colA_code.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colA_code.AppearanceCell.Options.UseFont = true;
            this.colA_code.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colA_code.AppearanceHeader.Options.UseFont = true;
            this.colA_code.Caption = "หมายเลขอะไหล่ทดแทน";
            this.colA_code.FieldName = "PART_ID";
            this.colA_code.Name = "colA_code";
            this.colA_code.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PART_ID", "จำนวนรายการ = {0}")});
            this.colA_code.Visible = true;
            this.colA_code.VisibleIndex = 0;
            // 
            // colA_band
            // 
            this.colA_band.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colA_band.AppearanceCell.Options.UseFont = true;
            this.colA_band.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colA_band.AppearanceHeader.Options.UseFont = true;
            this.colA_band.Caption = "ยี่ห้อ";
            this.colA_band.FieldName = "BRAND_DESCRIPTION";
            this.colA_band.Name = "colA_band";
            this.colA_band.Visible = true;
            this.colA_band.VisibleIndex = 1;
            // 
            // colA_status
            // 
            this.colA_status.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colA_status.AppearanceCell.Options.UseFont = true;
            this.colA_status.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colA_status.AppearanceHeader.Options.UseFont = true;
            this.colA_status.Caption = "สถานะ";
            this.colA_status.ColumnEdit = this.r_status;
            this.colA_status.FieldName = "STATUS";
            this.colA_status.Name = "colA_status";
            this.colA_status.Visible = true;
            this.colA_status.VisibleIndex = 2;
            // 
            // r_status
            // 
            this.r_status.AutoHeight = false;
            this.r_status.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.r_status.Name = "r_status";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btPartDelete);
            this.panelControl3.Controls.Add(this.btPartEdit);
            this.panelControl3.Controls.Add(this.btPartAdd);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 332);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(677, 35);
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
            this.panelControl2.Size = new System.Drawing.Size(677, 59);
            this.panelControl2.TabIndex = 17;
            // 
            // btClose
            // 
            this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btClose.Appearance.Options.UseFont = true;
            this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.btClose.Location = new System.Drawing.Point(148, 6);
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
            this.btSave.Location = new System.Drawing.Point(10, 6);
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
            // frm_ItemEdit7
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 369);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ItemEdit7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รหัสสินค้า-เลขอะไหล่ทดแทน [แก้ไข]";
            this.InputLanguageChanging += new System.Windows.Forms.InputLanguageChangingEventHandler(this.frm_ItemEdit7_InputLanguageChanging);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ItemEdit7_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlternate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_status)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridAlternate;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAlternate;
        private DevExpress.XtraGrid.Columns.GridColumn colA_id;
        private DevExpress.XtraGrid.Columns.GridColumn colA_code;
        private DevExpress.XtraGrid.Columns.GridColumn colA_band;
        private DevExpress.XtraGrid.Columns.GridColumn colA_status;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btPartDelete;
        private DevExpress.XtraEditors.SimpleButton btPartEdit;
        private DevExpress.XtraEditors.SimpleButton btPartAdd;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.SimpleButton btSave;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit r_status;
  }
}
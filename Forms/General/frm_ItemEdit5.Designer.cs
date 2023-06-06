namespace SmartPart.Forms.General
{
    partial class frm_ItemEdit5
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
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridLocation = new DevExpress.XtraGrid.GridControl();
            this.gvLocation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colL_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colL_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colL_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colL_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.btLocationDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btLocationEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btLocationAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.bwItem = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl6);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(545, 369);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridLocation);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 61);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(541, 272);
            this.panelControl3.TabIndex = 14;
            // 
            // gridLocation
            // 
            this.gridLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLocation.Location = new System.Drawing.Point(2, 2);
            this.gridLocation.MainView = this.gvLocation;
            this.gridLocation.Name = "gridLocation";
            this.gridLocation.Size = new System.Drawing.Size(537, 268);
            this.gridLocation.TabIndex = 6;
            this.gridLocation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLocation});
            // 
            // gvLocation
            // 
            this.gvLocation.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvLocation.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvLocation.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvLocation.Appearance.Row.Options.UseFont = true;
            this.gvLocation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colL_id,
            this.colL_code,
            this.colL_qty,
            this.colL_type});
            this.gvLocation.GridControl = this.gridLocation;
            this.gvLocation.IndicatorWidth = 30;
            this.gvLocation.Name = "gvLocation";
            this.gvLocation.OptionsBehavior.Editable = false;
            this.gvLocation.OptionsView.ShowFooter = true;
            this.gvLocation.OptionsView.ShowGroupPanel = false;
            // 
            // colL_id
            // 
            this.colL_id.Caption = "id";
            this.colL_id.Name = "colL_id";
            // 
            // colL_code
            // 
            this.colL_code.Caption = "คลังสินค้า";
            this.colL_code.FieldName = "LOCATION_NAME";
            this.colL_code.Name = "colL_code";
            this.colL_code.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "LOCATION_NAME", "จำนวนรายการ = {0}")});
            this.colL_code.Visible = true;
            this.colL_code.VisibleIndex = 0;
            // 
            // colL_qty
            // 
            this.colL_qty.Caption = "จำนวน";
            this.colL_qty.FieldName = "QTY";
            this.colL_qty.Name = "colL_qty";
            this.colL_qty.Visible = true;
            this.colL_qty.VisibleIndex = 1;
            // 
            // colL_type
            // 
            this.colL_type.Caption = "ประเภทคลังสินค้า";
            this.colL_type.FieldName = "DEFAULT_LOCATION";
            this.colL_type.Name = "colL_type";
            this.colL_type.Visible = true;
            this.colL_type.VisibleIndex = 2;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.btLocationDelete);
            this.panelControl6.Controls.Add(this.btLocationEdit);
            this.panelControl6.Controls.Add(this.btLocationAdd);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(2, 333);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(541, 34);
            this.panelControl6.TabIndex = 13;
            // 
            // btLocationDelete
            // 
            this.btLocationDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btLocationDelete.Appearance.Options.UseFont = true;
            this.btLocationDelete.Location = new System.Drawing.Point(183, 5);
            this.btLocationDelete.Name = "btLocationDelete";
            this.btLocationDelete.Size = new System.Drawing.Size(83, 25);
            this.btLocationDelete.TabIndex = 1;
            this.btLocationDelete.Text = "ลบ";
            this.btLocationDelete.Click += new System.EventHandler(this.btLocationDelete_Click);
            // 
            // btLocationEdit
            // 
            this.btLocationEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btLocationEdit.Appearance.Options.UseFont = true;
            this.btLocationEdit.Location = new System.Drawing.Point(94, 5);
            this.btLocationEdit.Name = "btLocationEdit";
            this.btLocationEdit.Size = new System.Drawing.Size(83, 25);
            this.btLocationEdit.TabIndex = 2;
            this.btLocationEdit.Text = "แก้ไข";
            this.btLocationEdit.Click += new System.EventHandler(this.btLocationEdit_Click);
            // 
            // btLocationAdd
            // 
            this.btLocationAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btLocationAdd.Appearance.Options.UseFont = true;
            this.btLocationAdd.Location = new System.Drawing.Point(5, 5);
            this.btLocationAdd.Name = "btLocationAdd";
            this.btLocationAdd.Size = new System.Drawing.Size(83, 25);
            this.btLocationAdd.TabIndex = 3;
            this.btLocationAdd.Text = "เพิ่ม";
            this.btLocationAdd.Click += new System.EventHandler(this.btLocationAdd_Click);
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
            this.panelControl2.TabIndex = 12;
            // 
            // btClose
            // 
            this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btClose.Appearance.Options.UseFont = true;
            this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.btClose.Location = new System.Drawing.Point(147, 9);
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
            // frm_ItemEdit5
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 369);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ItemEdit5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รหัสสินค้า-คลังสินค้า [แก้ไข]";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ItemEdit5_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridLocation;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colL_id;
        private DevExpress.XtraGrid.Columns.GridColumn colL_code;
        private DevExpress.XtraGrid.Columns.GridColumn colL_qty;
        private DevExpress.XtraGrid.Columns.GridColumn colL_type;
        private System.ComponentModel.BackgroundWorker bwItem;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton btLocationDelete;
        private DevExpress.XtraEditors.SimpleButton btLocationEdit;
        private DevExpress.XtraEditors.SimpleButton btLocationAdd;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.SimpleButton btSave;

    }
}
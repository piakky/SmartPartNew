namespace SmartPart.Forms.General
{
    partial class frm_ItemSetBrand
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
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.searchBrandCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtBrandName = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridSaleDis = new DevExpress.XtraGrid.GridControl();
            this.gvSaleDis = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.btSaleDiscountDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btSaleDiscountEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btSaleDiscountAdd = new DevExpress.XtraEditors.SimpleButton();
            this.bwItem = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchBrandCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrandName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSaleDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSaleDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btClose);
            this.panelControl1.Controls.Add(this.btSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(690, 59);
            this.panelControl1.TabIndex = 12;
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
            // searchBrandCode
            // 
            this.searchBrandCode.EnterMoveNextControl = true;
            this.searchBrandCode.Location = new System.Drawing.Point(87, 15);
            this.searchBrandCode.Name = "searchBrandCode";
            this.searchBrandCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.searchBrandCode.Properties.Appearance.Options.UseFont = true;
            this.searchBrandCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchBrandCode.Properties.NullText = "เลือกยี่ห้อสินค้า";
            this.searchBrandCode.Properties.View = this.gridView11;
            this.searchBrandCode.Size = new System.Drawing.Size(157, 22);
            this.searchBrandCode.TabIndex = 1;
            this.searchBrandCode.EditValueChanged += new System.EventHandler(this.searchBrandCode_EditValueChanged);
            // 
            // gridView11
            // 
            this.gridView11.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView11.Name = "gridView11";
            this.gridView11.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView11.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(22, 18);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(59, 17);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "ยี่ห้อสินค้า";
            // 
            // txtBrandName
            // 
            this.txtBrandName.EnterMoveNextControl = true;
            this.txtBrandName.Location = new System.Drawing.Point(250, 15);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBrandName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtBrandName.Properties.Appearance.Options.UseBackColor = true;
            this.txtBrandName.Properties.Appearance.Options.UseFont = true;
            this.txtBrandName.Properties.ReadOnly = true;
            this.txtBrandName.Size = new System.Drawing.Size(422, 22);
            this.txtBrandName.TabIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl9);
            this.panelControl2.Controls.Add(this.searchBrandCode);
            this.panelControl2.Controls.Add(this.txtBrandName);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 59);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(690, 51);
            this.panelControl2.TabIndex = 13;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridSaleDis);
            this.panelControl3.Controls.Add(this.panelControl6);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 110);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(690, 35);
            this.panelControl3.TabIndex = 14;
            this.panelControl3.Visible = false;
            // 
            // gridSaleDis
            // 
            this.gridSaleDis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSaleDis.Location = new System.Drawing.Point(2, 2);
            this.gridSaleDis.MainView = this.gvSaleDis;
            this.gridSaleDis.Name = "gridSaleDis";
            this.gridSaleDis.Size = new System.Drawing.Size(686, 0);
            this.gridSaleDis.TabIndex = 22;
            this.gridSaleDis.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSaleDis});
            // 
            // gvSaleDis
            // 
            this.gvSaleDis.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvSaleDis.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvSaleDis.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvSaleDis.Appearance.Row.Options.UseFont = true;
            this.gvSaleDis.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col7});
            this.gvSaleDis.GridControl = this.gridSaleDis;
            this.gvSaleDis.IndicatorWidth = 30;
            this.gvSaleDis.Name = "gvSaleDis";
            this.gvSaleDis.OptionsBehavior.Editable = false;
            this.gvSaleDis.OptionsView.ShowFooter = true;
            this.gvSaleDis.OptionsView.ShowGroupPanel = false;
            // 
            // col1
            // 
            this.col1.Caption = "id";
            this.col1.Name = "col1";
            // 
            // col2
            // 
            this.col2.Caption = "รหัสส่วนลด";
            this.col2.FieldName = "DISCOUNT_CODE";
            this.col2.Name = "col2";
            this.col2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DISCOUNT_CODE", "จำนวนรายการ = {0}")});
            this.col2.Visible = true;
            this.col2.VisibleIndex = 0;
            // 
            // col3
            // 
            this.col3.Caption = "ส่วนลดขั้นที่ 1";
            this.col3.FieldName = "DISCOUNT_RATE_STEP1";
            this.col3.Name = "col3";
            this.col3.Visible = true;
            this.col3.VisibleIndex = 1;
            // 
            // col4
            // 
            this.col4.Caption = "ส่วนลดขั้นที่ 2";
            this.col4.FieldName = "DISCOUNT_RATE_STEP2";
            this.col4.Name = "col4";
            this.col4.Visible = true;
            this.col4.VisibleIndex = 2;
            // 
            // col5
            // 
            this.col5.Caption = "ส่วนลดขั้นที่ 3";
            this.col5.FieldName = "DISCOUNT_RATE_STEP3";
            this.col5.Name = "col5";
            this.col5.Visible = true;
            this.col5.VisibleIndex = 3;
            // 
            // col6
            // 
            this.col6.Caption = "ส่วนลดขั้นที่ 4";
            this.col6.FieldName = "DISCOUNT_RATE_STEP4";
            this.col6.Name = "col6";
            this.col6.Visible = true;
            this.col6.VisibleIndex = 4;
            // 
            // col7
            // 
            this.col7.Caption = "สถานะการให้ส่วนลด";
            this.col7.FieldName = "ENABLED_STATUS";
            this.col7.Name = "col7";
            this.col7.Visible = true;
            this.col7.VisibleIndex = 5;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.btSaleDiscountDelete);
            this.panelControl6.Controls.Add(this.btSaleDiscountEdit);
            this.panelControl6.Controls.Add(this.btSaleDiscountAdd);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(2, -1);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(686, 34);
            this.panelControl6.TabIndex = 21;
            this.panelControl6.Visible = false;
            // 
            // btSaleDiscountDelete
            // 
            this.btSaleDiscountDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btSaleDiscountDelete.Appearance.Options.UseFont = true;
            this.btSaleDiscountDelete.Enabled = false;
            this.btSaleDiscountDelete.Location = new System.Drawing.Point(183, 5);
            this.btSaleDiscountDelete.Name = "btSaleDiscountDelete";
            this.btSaleDiscountDelete.Size = new System.Drawing.Size(83, 25);
            this.btSaleDiscountDelete.TabIndex = 1;
            this.btSaleDiscountDelete.Text = "ลบ";
            this.btSaleDiscountDelete.Click += new System.EventHandler(this.btSaleDiscountDelete_Click);
            // 
            // btSaleDiscountEdit
            // 
            this.btSaleDiscountEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btSaleDiscountEdit.Appearance.Options.UseFont = true;
            this.btSaleDiscountEdit.Enabled = false;
            this.btSaleDiscountEdit.Location = new System.Drawing.Point(94, 5);
            this.btSaleDiscountEdit.Name = "btSaleDiscountEdit";
            this.btSaleDiscountEdit.Size = new System.Drawing.Size(83, 25);
            this.btSaleDiscountEdit.TabIndex = 2;
            this.btSaleDiscountEdit.Text = "แก้ไข";
            this.btSaleDiscountEdit.Click += new System.EventHandler(this.btSaleDiscountEdit_Click);
            // 
            // btSaleDiscountAdd
            // 
            this.btSaleDiscountAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btSaleDiscountAdd.Appearance.Options.UseFont = true;
            this.btSaleDiscountAdd.Enabled = false;
            this.btSaleDiscountAdd.Location = new System.Drawing.Point(5, 5);
            this.btSaleDiscountAdd.Name = "btSaleDiscountAdd";
            this.btSaleDiscountAdd.Size = new System.Drawing.Size(83, 25);
            this.btSaleDiscountAdd.TabIndex = 3;
            this.btSaleDiscountAdd.Text = "เพิ่ม";
            this.btSaleDiscountAdd.Click += new System.EventHandler(this.btSaleDiscountAdd_Click);
            // 
            // bwItem
            // 
            this.bwItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwItem_DoWork);
            this.bwItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwItem_RunWorkerCompleted);
            // 
            // frm_ItemSetBrand
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 145);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ItemSetBrand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รหัสสินค้า-ยี่ห้อสินค้า [แก้ไข]";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ItemSetBrand_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchBrandCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrandName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSaleDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSaleDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.SearchLookUpEdit searchBrandCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView11;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtBrandName;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridSaleDis;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSaleDis;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private DevExpress.XtraGrid.Columns.GridColumn col3;
        private DevExpress.XtraGrid.Columns.GridColumn col4;
        private DevExpress.XtraGrid.Columns.GridColumn col5;
        private DevExpress.XtraGrid.Columns.GridColumn col6;
        private DevExpress.XtraGrid.Columns.GridColumn col7;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton btSaleDiscountDelete;
        private DevExpress.XtraEditors.SimpleButton btSaleDiscountEdit;
        private DevExpress.XtraEditors.SimpleButton btSaleDiscountAdd;
        private System.ComponentModel.BackgroundWorker bwItem;
    }
}
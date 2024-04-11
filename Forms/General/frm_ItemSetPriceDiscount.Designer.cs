namespace SmartPart.Forms.General
{
    partial class frm_ItemSetPriceDiscount
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
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.bwItem = new System.ComponentModel.BackgroundWorker();
            this.spinPrice1 = new DevExpress.XtraEditors.SpinEdit();
            this.spinPrice2 = new DevExpress.XtraEditors.SpinEdit();
            this.check1 = new DevExpress.XtraEditors.CheckEdit();
            this.check2 = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
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
            this.btSaleDiscountEdit = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.sluUnit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinPrice1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPrice2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSaleDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSaleDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sluUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btClose);
            this.panelControl1.Controls.Add(this.btSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(820, 70);
            this.panelControl1.TabIndex = 0;
            // 
            // btClose
            // 
            this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btClose.Appearance.Options.UseFont = true;
            this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.btClose.Location = new System.Drawing.Point(148, 9);
            this.btClose.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(135, 55);
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
            this.btSave.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(135, 55);
            this.btSave.TabIndex = 1;
            this.btSave.Text = "บันทึก (F2)";
            this.btSave.ToolTip = "บันทึก = F2";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(39, 76);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(47, 19);
            this.labelControl12.TabIndex = 15;
            this.labelControl12.Text = "ราคา 2";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(39, 45);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 19);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "ราคา 1";
            // 
            // bwItem
            // 
            this.bwItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwItem_DoWork);
            this.bwItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwItem_RunWorkerCompleted);
            // 
            // spinPrice1
            // 
            this.spinPrice1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinPrice1.EnterMoveNextControl = true;
            this.spinPrice1.Location = new System.Drawing.Point(105, 42);
            this.spinPrice1.Margin = new System.Windows.Forms.Padding(4);
            this.spinPrice1.Name = "spinPrice1";
            this.spinPrice1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinPrice1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.spinPrice1.Properties.Appearance.Options.UseBackColor = true;
            this.spinPrice1.Properties.Appearance.Options.UseFont = true;
            this.spinPrice1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinPrice1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinPrice1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.spinPrice1.Size = new System.Drawing.Size(215, 26);
            this.spinPrice1.TabIndex = 14;
            // 
            // spinPrice2
            // 
            this.spinPrice2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinPrice2.EnterMoveNextControl = true;
            this.spinPrice2.Location = new System.Drawing.Point(105, 73);
            this.spinPrice2.Margin = new System.Windows.Forms.Padding(4);
            this.spinPrice2.Name = "spinPrice2";
            this.spinPrice2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinPrice2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.spinPrice2.Properties.Appearance.Options.UseBackColor = true;
            this.spinPrice2.Properties.Appearance.Options.UseFont = true;
            this.spinPrice2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinPrice2.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinPrice2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.spinPrice2.Size = new System.Drawing.Size(215, 26);
            this.spinPrice2.TabIndex = 17;
            this.spinPrice2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.spinPrice2_KeyPress);
            // 
            // check1
            // 
            this.check1.EditValue = true;
            this.check1.Location = new System.Drawing.Point(38, 5);
            this.check1.Name = "check1";
            this.check1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.check1.Properties.Appearance.Options.UseFont = true;
            this.check1.Properties.Caption = "ราคาสุทธิ";
            this.check1.Size = new System.Drawing.Size(95, 23);
            this.check1.TabIndex = 24;
            this.check1.CheckedChanged += new System.EventHandler(this.check1_CheckedChanged);
            // 
            // check2
            // 
            this.check2.Location = new System.Drawing.Point(144, 5);
            this.check2.Name = "check2";
            this.check2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.check2.Properties.Appearance.Options.UseFont = true;
            this.check2.Properties.Caption = "ราคาส่วนลด";
            this.check2.Size = new System.Drawing.Size(117, 23);
            this.check2.TabIndex = 25;
            this.check2.CheckedChanged += new System.EventHandler(this.check2_CheckedChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridSaleDis);
            this.panelControl2.Controls.Add(this.panelControl6);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 210);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(820, 205);
            this.panelControl2.TabIndex = 26;
            // 
            // gridSaleDis
            // 
            this.gridSaleDis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSaleDis.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridSaleDis.Location = new System.Drawing.Point(2, 2);
            this.gridSaleDis.MainView = this.gvSaleDis;
            this.gridSaleDis.Name = "gridSaleDis";
            this.gridSaleDis.Size = new System.Drawing.Size(816, 167);
            this.gridSaleDis.TabIndex = 27;
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
            // 
            // col5
            // 
            this.col5.Caption = "ส่วนลดขั้นที่ 3";
            this.col5.FieldName = "DISCOUNT_RATE_STEP3";
            this.col5.Name = "col5";
            // 
            // col6
            // 
            this.col6.Caption = "ส่วนลดขั้นที่ 4";
            this.col6.FieldName = "DISCOUNT_RATE_STEP4";
            this.col6.Name = "col6";
            // 
            // col7
            // 
            this.col7.Caption = "สถานะการให้ส่วนลด";
            this.col7.FieldName = "ENABLED_STATUS";
            this.col7.Name = "col7";
            this.col7.Visible = true;
            this.col7.VisibleIndex = 2;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.btSaleDiscountEdit);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(2, 169);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(816, 34);
            this.panelControl6.TabIndex = 25;
            // 
            // btSaleDiscountEdit
            // 
            this.btSaleDiscountEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btSaleDiscountEdit.Appearance.Options.UseFont = true;
            this.btSaleDiscountEdit.Enabled = false;
            this.btSaleDiscountEdit.Location = new System.Drawing.Point(8, 4);
            this.btSaleDiscountEdit.Name = "btSaleDiscountEdit";
            this.btSaleDiscountEdit.Size = new System.Drawing.Size(83, 25);
            this.btSaleDiscountEdit.TabIndex = 2;
            this.btSaleDiscountEdit.Text = "แก้ไข";
            this.btSaleDiscountEdit.Visible = false;
            this.btSaleDiscountEdit.Click += new System.EventHandler(this.btSaleDiscountEdit_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.sluUnit);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.spinPrice1);
            this.panelControl3.Controls.Add(this.spinPrice2);
            this.panelControl3.Controls.Add(this.check2);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.check1);
            this.panelControl3.Controls.Add(this.labelControl12);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 70);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(820, 140);
            this.panelControl3.TabIndex = 27;
            // 
            // sluUnit
            // 
            this.sluUnit.EnterMoveNextControl = true;
            this.sluUnit.Location = new System.Drawing.Point(105, 106);
            this.sluUnit.Name = "sluUnit";
            this.sluUnit.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.sluUnit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.sluUnit.Properties.Appearance.Options.UseBackColor = true;
            this.sluUnit.Properties.Appearance.Options.UseFont = true;
            this.sluUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sluUnit.Properties.NullText = "";
            this.sluUnit.Properties.View = this.searchLookUpEdit1View;
            this.sluUnit.Size = new System.Drawing.Size(133, 26);
            this.sluUnit.TabIndex = 32;
            this.sluUnit.EditValueChanged += new System.EventHandler(this.sluUnit_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(29, 109);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 19);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "หน่วยนับ";
            // 
            // frm_ItemSetPriceDiscount
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 415);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_ItemSetPriceDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ราคาขาย";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ItemSetPriceDiscount_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinPrice1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPrice2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSaleDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSaleDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sluUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.ComponentModel.BackgroundWorker bwItem;
        private DevExpress.XtraEditors.SpinEdit spinPrice1;
        private DevExpress.XtraEditors.SpinEdit spinPrice2;
        private DevExpress.XtraEditors.CheckEdit check1;
        private DevExpress.XtraEditors.CheckEdit check2;
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
        private DevExpress.XtraEditors.SimpleButton btSaleDiscountEdit;
        internal DevExpress.XtraEditors.SearchLookUpEdit sluUnit;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
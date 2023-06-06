namespace SmartPart.Forms.Code
{
    partial class frm_PriceList_Record
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
      DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
      this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.TxtCode = new DevExpress.XtraEditors.TextEdit();
      this.searchLookUpProduct = new DevExpress.XtraEditors.SearchLookUpEdit();
      this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
      this.datePrice = new DevExpress.XtraEditors.DateEdit();
      this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
      this.spinPrice = new DevExpress.XtraEditors.SpinEdit();
      this.TxtModel = new DevExpress.XtraEditors.TextEdit();
      this.txtGenuinPart = new DevExpress.XtraEditors.TextEdit();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.txtProducerPart = new DevExpress.XtraEditors.TextEdit();
      this.TxtFullname = new DevExpress.XtraEditors.TextEdit();
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.BTcancel = new DevExpress.XtraEditors.SimpleButton();
      this.BTreset = new DevExpress.XtraEditors.SimpleButton();
      this.BTsaveclose = new DevExpress.XtraEditors.SimpleButton();
      this.BTsave = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtCode.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProduct.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.datePrice.Properties.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.datePrice.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinPrice.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtModel.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtGenuinPart.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtProducerPart.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtFullname.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.TxtCode);
      this.panelControl2.Controls.Add(this.searchLookUpProduct);
      this.panelControl2.Controls.Add(this.labelControl7);
      this.panelControl2.Controls.Add(this.labelControl6);
      this.panelControl2.Controls.Add(this.datePrice);
      this.panelControl2.Controls.Add(this.labelControl5);
      this.panelControl2.Controls.Add(this.spinPrice);
      this.panelControl2.Controls.Add(this.TxtModel);
      this.panelControl2.Controls.Add(this.txtGenuinPart);
      this.panelControl2.Controls.Add(this.labelControl3);
      this.panelControl2.Controls.Add(this.txtProducerPart);
      this.panelControl2.Controls.Add(this.TxtFullname);
      this.panelControl2.Controls.Add(this.labelControl4);
      this.panelControl2.Controls.Add(this.labelControl2);
      this.panelControl2.Controls.Add(this.labelControl1);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl2.Location = new System.Drawing.Point(0, 47);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(681, 245);
      this.panelControl2.TabIndex = 0;
      // 
      // TxtCode
      // 
      this.TxtCode.EnterMoveNextControl = true;
      this.TxtCode.Location = new System.Drawing.Point(348, 48);
      this.TxtCode.Name = "TxtCode";
      this.TxtCode.Properties.Appearance.BackColor = System.Drawing.Color.Yellow;
      this.TxtCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtCode.Properties.Appearance.Options.UseBackColor = true;
      this.TxtCode.Properties.Appearance.Options.UseFont = true;
      this.TxtCode.Properties.ReadOnly = true;
      this.TxtCode.Size = new System.Drawing.Size(321, 26);
      this.TxtCode.TabIndex = 4;
      // 
      // searchLookUpProduct
      // 
      this.searchLookUpProduct.EnterMoveNextControl = true;
      this.searchLookUpProduct.Location = new System.Drawing.Point(164, 48);
      this.searchLookUpProduct.Name = "searchLookUpProduct";
      this.searchLookUpProduct.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.searchLookUpProduct.Properties.Appearance.Options.UseFont = true;
      this.searchLookUpProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.searchLookUpProduct.Properties.NullText = "เลือกรหัสสินค้า";
      this.searchLookUpProduct.Properties.View = this.searchLookUpEdit1View;
      this.searchLookUpProduct.Size = new System.Drawing.Size(178, 26);
      this.searchLookUpProduct.TabIndex = 3;
      this.searchLookUpProduct.EditValueChanged += new System.EventHandler(this.searchLookUpProduct_EditValueChanged);
      // 
      // searchLookUpEdit1View
      // 
      this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
      this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
      // 
      // labelControl7
      // 
      this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl7.Appearance.Options.UseFont = true;
      this.labelControl7.Location = new System.Drawing.Point(93, 51);
      this.labelControl7.Name = "labelControl7";
      this.labelControl7.Size = new System.Drawing.Size(65, 19);
      this.labelControl7.TabIndex = 2;
      this.labelControl7.Text = "รหัสสินค้า";
      // 
      // labelControl6
      // 
      this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl6.Appearance.Options.UseFont = true;
      this.labelControl6.Location = new System.Drawing.Point(69, 213);
      this.labelControl6.Name = "labelControl6";
      this.labelControl6.Size = new System.Drawing.Size(89, 19);
      this.labelControl6.TabIndex = 13;
      this.labelControl6.Text = "วันที่ราคาใหม่";
      // 
      // datePrice
      // 
      this.datePrice.EditValue = null;
      this.datePrice.Location = new System.Drawing.Point(164, 210);
      this.datePrice.Name = "datePrice";
      this.datePrice.Properties.Appearance.BackColor = System.Drawing.Color.White;
      this.datePrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.datePrice.Properties.Appearance.Options.UseBackColor = true;
      this.datePrice.Properties.Appearance.Options.UseFont = true;
      this.datePrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.datePrice.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.datePrice.Size = new System.Drawing.Size(133, 26);
      this.datePrice.TabIndex = 14;
      // 
      // labelControl5
      // 
      this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl5.Appearance.Options.UseFont = true;
      this.labelControl5.Location = new System.Drawing.Point(98, 180);
      this.labelControl5.Name = "labelControl5";
      this.labelControl5.Size = new System.Drawing.Size(60, 19);
      this.labelControl5.TabIndex = 11;
      this.labelControl5.Text = "ราคาใหม่";
      // 
      // spinPrice
      // 
      this.spinPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.spinPrice.Location = new System.Drawing.Point(164, 177);
      this.spinPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.spinPrice.Name = "spinPrice";
      this.spinPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.spinPrice.Properties.Appearance.Options.UseFont = true;
      this.spinPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, editorButtonImageOptions1)});
      this.spinPrice.Properties.DisplayFormat.FormatString = "n2";
      this.spinPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      this.spinPrice.Properties.EditFormat.FormatString = "n2";
      this.spinPrice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      this.spinPrice.Properties.Mask.EditMask = "n2";
      this.spinPrice.Properties.MaxLength = 16;
      this.spinPrice.Properties.MaxValue = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
      this.spinPrice.Size = new System.Drawing.Size(133, 26);
      this.spinPrice.TabIndex = 12;
      // 
      // TxtModel
      // 
      this.TxtModel.EnterMoveNextControl = true;
      this.TxtModel.Location = new System.Drawing.Point(164, 144);
      this.TxtModel.Name = "TxtModel";
      this.TxtModel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtModel.Properties.Appearance.Options.UseFont = true;
      this.TxtModel.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.TxtModel.Properties.MaxLength = 50;
      this.TxtModel.Size = new System.Drawing.Size(340, 26);
      this.TxtModel.TabIndex = 10;
      // 
      // txtGenuinPart
      // 
      this.txtGenuinPart.EnterMoveNextControl = true;
      this.txtGenuinPart.Location = new System.Drawing.Point(164, 80);
      this.txtGenuinPart.Name = "txtGenuinPart";
      this.txtGenuinPart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.txtGenuinPart.Properties.Appearance.Options.UseFont = true;
      this.txtGenuinPart.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.txtGenuinPart.Properties.MaxLength = 50;
      this.txtGenuinPart.Size = new System.Drawing.Size(340, 26);
      this.txtGenuinPart.TabIndex = 6;
      // 
      // labelControl3
      // 
      this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl3.Appearance.Options.UseFont = true;
      this.labelControl3.Location = new System.Drawing.Point(26, 83);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(132, 19);
      this.labelControl3.TabIndex = 5;
      this.labelControl3.Text = "หมายเลขอะไหล่ร้าน";
      // 
      // txtProducerPart
      // 
      this.txtProducerPart.EnterMoveNextControl = true;
      this.txtProducerPart.Location = new System.Drawing.Point(164, 16);
      this.txtProducerPart.Name = "txtProducerPart";
      this.txtProducerPart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.txtProducerPart.Properties.Appearance.Options.UseFont = true;
      this.txtProducerPart.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.txtProducerPart.Properties.MaxLength = 50;
      this.txtProducerPart.Size = new System.Drawing.Size(340, 26);
      this.txtProducerPart.TabIndex = 1;
      // 
      // TxtFullname
      // 
      this.TxtFullname.EnterMoveNextControl = true;
      this.TxtFullname.Location = new System.Drawing.Point(164, 112);
      this.TxtFullname.Name = "TxtFullname";
      this.TxtFullname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtFullname.Properties.Appearance.Options.UseFont = true;
      this.TxtFullname.Properties.MaxLength = 100;
      this.TxtFullname.Size = new System.Drawing.Size(505, 26);
      this.TxtFullname.TabIndex = 8;
      // 
      // labelControl4
      // 
      this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl4.Appearance.Options.UseFont = true;
      this.labelControl4.Location = new System.Drawing.Point(45, 115);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(113, 19);
      this.labelControl4.TabIndex = 7;
      this.labelControl4.Text = "รายละเอียดสินค้า";
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl2.Appearance.Options.UseFont = true;
      this.labelControl2.Location = new System.Drawing.Point(141, 147);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(17, 19);
      this.labelControl2.TabIndex = 9;
      this.labelControl2.Text = "รุ่น";
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Location = new System.Drawing.Point(12, 19);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(146, 19);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "หมายเลขอะไหล่พ่อค้า";
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.BTcancel);
      this.panelControl1.Controls.Add(this.BTreset);
      this.panelControl1.Controls.Add(this.BTsaveclose);
      this.panelControl1.Controls.Add(this.BTsave);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(681, 47);
      this.panelControl1.TabIndex = 1;
      // 
      // BTcancel
      // 
      this.BTcancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.BTcancel.Appearance.Options.UseFont = true;
      this.BTcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.BTcancel.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
      this.BTcancel.Location = new System.Drawing.Point(341, 5);
      this.BTcancel.Name = "BTcancel";
      this.BTcancel.Size = new System.Drawing.Size(84, 36);
      this.BTcancel.TabIndex = 3;
      this.BTcancel.Text = "ยกเลิก";
      this.BTcancel.ToolTip = "ยกเลิก = ESC";
      this.BTcancel.Click += new System.EventHandler(this.BTcancel_Click);
      // 
      // BTreset
      // 
      this.BTreset.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.BTreset.Appearance.Options.UseFont = true;
      this.BTreset.Location = new System.Drawing.Point(238, 5);
      this.BTreset.Name = "BTreset";
      this.BTreset.Size = new System.Drawing.Size(97, 36);
      this.BTreset.TabIndex = 2;
      this.BTreset.Text = "เริ่มใหม่";
      this.BTreset.ToolTip = "เริ่มใหม่ = F3";
      this.BTreset.Click += new System.EventHandler(this.BTreset_Click);
      // 
      // BTsaveclose
      // 
      this.BTsaveclose.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.BTsaveclose.Appearance.Options.UseFont = true;
      this.BTsaveclose.ImageOptions.Image = global::SmartPart.Properties.Resources.page_save;
      this.BTsaveclose.Location = new System.Drawing.Point(103, 5);
      this.BTsaveclose.Name = "BTsaveclose";
      this.BTsaveclose.Size = new System.Drawing.Size(130, 36);
      this.BTsaveclose.TabIndex = 1;
      this.BTsaveclose.Tag = "1";
      this.BTsaveclose.Text = "บันทึก/ปิด";
      this.BTsaveclose.Click += new System.EventHandler(this.BTsave_Click);
      // 
      // BTsave
      // 
      this.BTsave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.BTsave.Appearance.Options.UseFont = true;
      this.BTsave.ImageOptions.Image = global::SmartPart.Properties.Resources.page_save;
      this.BTsave.Location = new System.Drawing.Point(5, 5);
      this.BTsave.Name = "BTsave";
      this.BTsave.Size = new System.Drawing.Size(92, 36);
      this.BTsave.TabIndex = 0;
      this.BTsave.Tag = "2";
      this.BTsave.Text = "บันทึก";
      this.BTsave.ToolTip = "บันทึก = F2";
      this.BTsave.Click += new System.EventHandler(this.BTsave_Click);
      // 
      // frm_PriceList_Record
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(681, 292);
      this.ControlBox = false;
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "frm_PriceList_Record";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmPriceList_Record";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Categories_Record_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtCode.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProduct.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.datePrice.Properties.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.datePrice.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinPrice.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtModel.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtGenuinPart.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtProducerPart.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtFullname.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton BTcancel;
        private DevExpress.XtraEditors.SimpleButton BTreset;
        private DevExpress.XtraEditors.SimpleButton BTsave;
    internal DevExpress.XtraEditors.TextEdit txtProducerPart;
    internal DevExpress.XtraEditors.TextEdit TxtFullname;
    private DevExpress.XtraEditors.SimpleButton BTsaveclose;
    internal DevExpress.XtraEditors.TextEdit TxtModel;
    internal DevExpress.XtraEditors.TextEdit txtGenuinPart;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private DevExpress.XtraEditors.LabelControl labelControl6;
    internal DevExpress.XtraEditors.SearchLookUpEdit searchLookUpProduct;
    private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    private DevExpress.XtraEditors.LabelControl labelControl7;
    internal DevExpress.XtraEditors.TextEdit TxtCode;
    internal DevExpress.XtraEditors.SpinEdit spinPrice;
    internal DevExpress.XtraEditors.DateEdit datePrice;
  }
}
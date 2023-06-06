namespace SmartPart.Forms.Code
{
    partial class frmD_UnitInput
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.TxtUnitName = new DevExpress.XtraEditors.TextEdit();
            this.spinQuantity = new DevExpress.XtraEditors.SpinEdit();
            this.searchLookUpUnit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.checkSale = new DevExpress.XtraEditors.CheckEdit();
            this.checkBuy = new DevExpress.XtraEditors.CheckEdit();
            this.checkDigit = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.btReset = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUnitName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBuy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDigit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.TxtUnitName);
            this.panelControl2.Controls.Add(this.spinQuantity);
            this.panelControl2.Controls.Add(this.searchLookUpUnit);
            this.panelControl2.Controls.Add(this.checkSale);
            this.panelControl2.Controls.Add(this.checkBuy);
            this.panelControl2.Controls.Add(this.checkDigit);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 47);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(509, 121);
            this.panelControl2.TabIndex = 0;
            // 
            // TxtUnitName
            // 
            this.TxtUnitName.Location = new System.Drawing.Point(289, 7);
            this.TxtUnitName.Name = "TxtUnitName";
            this.TxtUnitName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtUnitName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TxtUnitName.Properties.Appearance.Options.UseBackColor = true;
            this.TxtUnitName.Properties.Appearance.Options.UseFont = true;
            this.TxtUnitName.Properties.ReadOnly = true;
            this.TxtUnitName.Size = new System.Drawing.Size(209, 26);
            this.TxtUnitName.TabIndex = 2;
            // 
            // spinQuantity
            // 
            this.spinQuantity.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinQuantity.Location = new System.Drawing.Point(121, 38);
            this.spinQuantity.Name = "spinQuantity";
            this.spinQuantity.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.spinQuantity.Properties.Appearance.Options.UseFont = true;
            this.spinQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinQuantity.Size = new System.Drawing.Size(162, 26);
            this.spinQuantity.TabIndex = 4;
            // 
            // searchLookUpUnit
            // 
            this.searchLookUpUnit.Location = new System.Drawing.Point(121, 7);
            this.searchLookUpUnit.Name = "searchLookUpUnit";
            this.searchLookUpUnit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.searchLookUpUnit.Properties.Appearance.Options.UseFont = true;
            this.searchLookUpUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpUnit.Properties.NullText = "เลือกหน่วยนับสินค้า";
            //this.searchLookUpUnit.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpUnit.Size = new System.Drawing.Size(162, 26);
            this.searchLookUpUnit.TabIndex = 1;
            this.searchLookUpUnit.EditValueChanged += new System.EventHandler(this.searchLookUpUnit_EditValueChanged);
            this.searchLookUpUnit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.searchLookUpEdit1_MouseDown);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // checkSale
            // 
            this.checkSale.Location = new System.Drawing.Point(289, 86);
            this.checkSale.Name = "checkSale";
            this.checkSale.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.checkSale.Properties.Appearance.Options.UseFont = true;
            this.checkSale.Properties.Caption = "เป็นหน่วยขาย";
            this.checkSale.Size = new System.Drawing.Size(118, 23);
            this.checkSale.TabIndex = 7;
            // 
            // checkBuy
            // 
            this.checkBuy.Location = new System.Drawing.Point(121, 86);
            this.checkBuy.Name = "checkBuy";
            this.checkBuy.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.checkBuy.Properties.Appearance.Options.UseFont = true;
            this.checkBuy.Properties.Caption = "เลือกเป็นหน่วยซื้อ";
            this.checkBuy.Size = new System.Drawing.Size(140, 23);
            this.checkBuy.TabIndex = 6;
            // 
            // checkDigit
            // 
            this.checkDigit.Location = new System.Drawing.Point(289, 41);
            this.checkDigit.Name = "checkDigit";
            this.checkDigit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.checkDigit.Properties.Appearance.Options.UseFont = true;
            this.checkDigit.Properties.Caption = "ขายเป็นทศนิยมได้";
            this.checkDigit.Size = new System.Drawing.Size(150, 23);
            this.checkDigit.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(110, 19);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "จำนวนหน่วยย่อย";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(58, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "หน่วยนับ";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btClose);
            this.panelControl1.Controls.Add(this.btReset);
            this.panelControl1.Controls.Add(this.btSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(509, 47);
            this.panelControl1.TabIndex = 3;
            // 
            // btClose
            // 
            this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btClose.Appearance.Options.UseFont = true;
            this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.btClose.Location = new System.Drawing.Point(190, 6);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(83, 36);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "ยกเลิก";
            this.btClose.ToolTip = "ยกเลิก = ESC";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btReset
            // 
            this.btReset.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btReset.Appearance.Options.UseFont = true;
            this.btReset.Location = new System.Drawing.Point(101, 6);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(83, 36);
            this.btReset.TabIndex = 2;
            this.btReset.Text = "เริ่มใหม่";
            this.btReset.ToolTip = "เริ่มใหม่ = F3";
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // btSave
            // 
            this.btSave.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btSave.Appearance.Options.UseFont = true;
            this.btSave.ImageOptions.Image = global::SmartPart.Properties.Resources.page_save;
            this.btSave.Location = new System.Drawing.Point(12, 6);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(83, 36);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "บันทึก";
            this.btSave.ToolTip = "บันทึก = F2";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // frmD_UnitInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 168);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmD_UnitInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDUnitInput";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmD_UnitInput_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUnitName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBuy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDigit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btClose;
    private DevExpress.XtraEditors.SimpleButton btReset;
    private DevExpress.XtraEditors.SimpleButton btSave;
    internal DevExpress.XtraEditors.SearchLookUpEdit searchLookUpUnit;
    internal DevExpress.XtraEditors.CheckEdit checkSale;
    internal DevExpress.XtraEditors.CheckEdit checkBuy;
    internal DevExpress.XtraEditors.CheckEdit checkDigit;
    internal DevExpress.XtraEditors.SpinEdit spinQuantity;
    internal DevExpress.XtraEditors.TextEdit TxtUnitName;
  }
}
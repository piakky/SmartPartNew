namespace SmartPart.Forms.Code
{
  partial class frmD_BrandBuyDiscount_Input
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
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.radioStatus = new DevExpress.XtraEditors.RadioGroup();
      this.spinDisCount = new DevExpress.XtraEditors.SpinEdit();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.btClose = new DevExpress.XtraEditors.SimpleButton();
      this.btReset = new DevExpress.XtraEditors.SimpleButton();
      this.btSave = new DevExpress.XtraEditors.SimpleButton();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.radioVatStatus = new DevExpress.XtraEditors.RadioGroup();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radioStatus.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinDisCount.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radioVatStatus.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.labelControl1);
      this.panelControl2.Controls.Add(this.radioVatStatus);
      this.panelControl2.Controls.Add(this.labelControl4);
      this.panelControl2.Controls.Add(this.radioStatus);
      this.panelControl2.Controls.Add(this.spinDisCount);
      this.panelControl2.Controls.Add(this.labelControl2);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl2.Location = new System.Drawing.Point(0, 47);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(504, 112);
      this.panelControl2.TabIndex = 0;
      // 
      // labelControl4
      // 
      this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl4.Appearance.Options.UseFont = true;
      this.labelControl4.Location = new System.Drawing.Point(25, 80);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(129, 19);
      this.labelControl4.TabIndex = 4;
      this.labelControl4.Text = "เลือกใช้แสดงต้นทุน";
      // 
      // radioStatus
      // 
      this.radioStatus.EnterMoveNextControl = true;
      this.radioStatus.Location = new System.Drawing.Point(160, 74);
      this.radioStatus.Name = "radioStatus";
      this.radioStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.radioStatus.Properties.Appearance.Options.UseFont = true;
      this.radioStatus.Properties.Appearance.Options.UseTextOptions = true;
      this.radioStatus.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
      this.radioStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "เลือก"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "ไม่เลือก")});
      this.radioStatus.Size = new System.Drawing.Size(225, 31);
      this.radioStatus.TabIndex = 5;
      // 
      // spinDisCount
      // 
      this.spinDisCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.spinDisCount.EnterMoveNextControl = true;
      this.spinDisCount.Location = new System.Drawing.Point(160, 5);
      this.spinDisCount.Name = "spinDisCount";
      this.spinDisCount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.spinDisCount.Properties.Appearance.Options.UseFont = true;
      this.spinDisCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.spinDisCount.Properties.IsFloatValue = false;
      this.spinDisCount.Properties.Mask.EditMask = "N00";
      this.spinDisCount.Size = new System.Drawing.Size(103, 26);
      this.spinDisCount.TabIndex = 1;
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl2.Appearance.Options.UseFont = true;
      this.labelControl2.Location = new System.Drawing.Point(73, 8);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(81, 19);
      this.labelControl2.TabIndex = 0;
      this.labelControl2.Text = "ส่วนลด (%)";
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.btClose);
      this.panelControl1.Controls.Add(this.btReset);
      this.panelControl1.Controls.Add(this.btSave);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(504, 47);
      this.panelControl1.TabIndex = 6;
      // 
      // btClose
      // 
      this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btClose.Appearance.Options.UseFont = true;
      this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
      this.btClose.Location = new System.Drawing.Point(180, 5);
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
      this.btReset.Location = new System.Drawing.Point(95, 5);
      this.btReset.Name = "btReset";
      this.btReset.Size = new System.Drawing.Size(79, 36);
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
      this.btSave.Location = new System.Drawing.Point(5, 5);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(84, 36);
      this.btSave.TabIndex = 0;
      this.btSave.Text = "บันทึก";
      this.btSave.ToolTip = "บันทึก = F2";
      this.btSave.Click += new System.EventHandler(this.btSave_Click);
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Location = new System.Drawing.Point(74, 43);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(80, 19);
      this.labelControl1.TabIndex = 2;
      this.labelControl1.Text = "สถานะ VAT";
      // 
      // radioVatStatus
      // 
      this.radioVatStatus.EnterMoveNextControl = true;
      this.radioVatStatus.Location = new System.Drawing.Point(160, 37);
      this.radioVatStatus.Name = "radioVatStatus";
      this.radioVatStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.radioVatStatus.Properties.Appearance.Options.UseFont = true;
      this.radioVatStatus.Properties.Appearance.Options.UseTextOptions = true;
      this.radioVatStatus.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
      this.radioVatStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "VAT นอก"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "VAT ใน"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "ไม่มี VAT")});
      this.radioVatStatus.Size = new System.Drawing.Size(334, 31);
      this.radioVatStatus.TabIndex = 3;
      // 
      // frmD_BrandBuyDiscount_Input
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(504, 159);
      this.Controls.Add(this.panelControl1);
      this.Controls.Add(this.panelControl2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmD_BrandBuyDiscount_Input";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmD_BrandBuyDiscount_Input";
      this.Load += new System.EventHandler(this.frmD_BrandDiscount_Input_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmD_BrandBuyDiscount_Input_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radioStatus.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinDisCount.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radioVatStatus.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    internal DevExpress.XtraEditors.SpinEdit spinDisCount;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btClose;
    private DevExpress.XtraEditors.SimpleButton btReset;
    private DevExpress.XtraEditors.SimpleButton btSave;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    internal DevExpress.XtraEditors.RadioGroup radioStatus;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    internal DevExpress.XtraEditors.RadioGroup radioVatStatus;
  }
}
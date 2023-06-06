namespace SmartPart.Forms.Code
{
  partial class frmD_TypeItem_Input
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
      this.radioVatStatus = new DevExpress.XtraEditors.RadioGroup();
      this.spinCredit = new DevExpress.XtraEditors.SpinEdit();
      this.txtNote = new DevExpress.XtraEditors.TextEdit();
      this.txtType = new DevExpress.XtraEditors.TextEdit();
      this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.btClose = new DevExpress.XtraEditors.SimpleButton();
      this.btReset = new DevExpress.XtraEditors.SimpleButton();
      this.btSave = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radioVatStatus.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinCredit.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.radioVatStatus);
      this.panelControl2.Controls.Add(this.spinCredit);
      this.panelControl2.Controls.Add(this.txtNote);
      this.panelControl2.Controls.Add(this.txtType);
      this.panelControl2.Controls.Add(this.labelControl6);
      this.panelControl2.Controls.Add(this.labelControl3);
      this.panelControl2.Controls.Add(this.labelControl2);
      this.panelControl2.Controls.Add(this.labelControl1);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl2.Location = new System.Drawing.Point(0, 48);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(495, 114);
      this.panelControl2.TabIndex = 7;
      // 
      // radioVatStatus
      // 
      this.radioVatStatus.EnterMoveNextControl = true;
      this.radioVatStatus.Location = new System.Drawing.Point(95, 29);
      this.radioVatStatus.Name = "radioVatStatus";
      this.radioVatStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.radioVatStatus.Properties.Appearance.Options.UseFont = true;
      this.radioVatStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "VAT นอก"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "VAT ใน"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "ไม่มี VAT")});
      this.radioVatStatus.Size = new System.Drawing.Size(387, 24);
      this.radioVatStatus.TabIndex = 1;
      // 
      // spinCredit
      // 
      this.spinCredit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.spinCredit.EnterMoveNextControl = true;
      this.spinCredit.Location = new System.Drawing.Point(95, 54);
      this.spinCredit.Name = "spinCredit";
      this.spinCredit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.spinCredit.Properties.Appearance.Options.UseFont = true;
      this.spinCredit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.spinCredit.Size = new System.Drawing.Size(225, 22);
      this.spinCredit.TabIndex = 2;
      // 
      // txtNote
      // 
      this.txtNote.EnterMoveNextControl = true;
      this.txtNote.Location = new System.Drawing.Point(95, 78);
      this.txtNote.Name = "txtNote";
      this.txtNote.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.txtNote.Properties.Appearance.Options.UseFont = true;
      this.txtNote.Size = new System.Drawing.Size(389, 22);
      this.txtNote.TabIndex = 3;
      // 
      // txtType
      // 
      this.txtType.EnterMoveNextControl = true;
      this.txtType.Location = new System.Drawing.Point(95, 5);
      this.txtType.Name = "txtType";
      this.txtType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.txtType.Properties.Appearance.Options.UseFont = true;
      this.txtType.Size = new System.Drawing.Size(225, 22);
      this.txtType.TabIndex = 0;
      // 
      // labelControl6
      // 
      this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl6.Appearance.Options.UseFont = true;
      this.labelControl6.Location = new System.Drawing.Point(34, 81);
      this.labelControl6.Name = "labelControl6";
      this.labelControl6.Size = new System.Drawing.Size(55, 17);
      this.labelControl6.TabIndex = 0;
      this.labelControl6.Text = "หมายเหตุ";
      // 
      // labelControl3
      // 
      this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl3.Appearance.Options.UseFont = true;
      this.labelControl3.Location = new System.Drawing.Point(20, 57);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(69, 17);
      this.labelControl3.TabIndex = 0;
      this.labelControl3.Text = "เครดิตเทอม";
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl2.Appearance.Options.UseFont = true;
      this.labelControl2.Location = new System.Drawing.Point(22, 33);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(67, 17);
      this.labelControl2.TabIndex = 0;
      this.labelControl2.Text = "สถานะ VAT";
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Location = new System.Drawing.Point(10, 8);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(79, 17);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "ประเภทสินค้า";
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.btClose);
      this.panelControl1.Controls.Add(this.btReset);
      this.panelControl1.Controls.Add(this.btSave);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(495, 48);
      this.panelControl1.TabIndex = 6;
      // 
      // btClose
      // 
      this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btClose.Appearance.Options.UseFont = true;
      this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
      this.btClose.Location = new System.Drawing.Point(177, 7);
      this.btClose.Margin = new System.Windows.Forms.Padding(4);
      this.btClose.Name = "btClose";
      this.btClose.Size = new System.Drawing.Size(83, 36);
      this.btClose.TabIndex = 2;
      this.btClose.Text = "ยกเลิก";
      this.btClose.ToolTip = "ยกเลิก = ESC";
      this.btClose.Click += new System.EventHandler(this.btClose_Click);
      // 
      // btReset
      // 
      this.btReset.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btReset.Appearance.Options.UseFont = true;
      this.btReset.Location = new System.Drawing.Point(92, 7);
      this.btReset.Margin = new System.Windows.Forms.Padding(4);
      this.btReset.Name = "btReset";
      this.btReset.Size = new System.Drawing.Size(83, 36);
      this.btReset.TabIndex = 1;
      this.btReset.Text = "เริ่มใหม่";
      this.btReset.ToolTip = "เริ่มใหม่ = F3";
      this.btReset.Click += new System.EventHandler(this.btReset_Click);
      // 
      // btSave
      // 
      this.btSave.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btSave.Appearance.Options.UseFont = true;
      this.btSave.ImageOptions.Image = global::SmartPart.Properties.Resources.page_save;
      this.btSave.Location = new System.Drawing.Point(8, 7);
      this.btSave.Margin = new System.Windows.Forms.Padding(4);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(83, 36);
      this.btSave.TabIndex = 0;
      this.btSave.Text = "บันทึก";
      this.btSave.ToolTip = "บันทึก = F2";
      this.btSave.Click += new System.EventHandler(this.btSave_Click);
      // 
      // frmD_TypeItem_Input
      // 
      this.Appearance.Options.UseFont = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(495, 162);
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl1);
      this.Font = new System.Drawing.Font("Tahoma", 12F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "frmD_TypeItem_Input";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmD_TypeItem_Input";
      this.Load += new System.EventHandler(this.frmD_TypeItem_Input_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmD_TypeItem_Input_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radioVatStatus.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinCredit.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl6;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btClose;
    private DevExpress.XtraEditors.SimpleButton btReset;
    private DevExpress.XtraEditors.SimpleButton btSave;
    internal DevExpress.XtraEditors.RadioGroup radioVatStatus;
    internal DevExpress.XtraEditors.SpinEdit spinCredit;
    internal DevExpress.XtraEditors.TextEdit txtNote;
    internal DevExpress.XtraEditors.TextEdit txtType;
  }
}
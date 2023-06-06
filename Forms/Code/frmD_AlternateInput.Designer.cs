namespace SmartPart.Forms.Code
{
    partial class frmD_AlternateInput
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
      this.radioAlternateStatus = new DevExpress.XtraEditors.RadioGroup();
      this.TxtAlternateBrand = new DevExpress.XtraEditors.TextEdit();
      this.TxtAlternatePart = new DevExpress.XtraEditors.TextEdit();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.btClose = new DevExpress.XtraEditors.SimpleButton();
      this.btReset = new DevExpress.XtraEditors.SimpleButton();
      this.btSave = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radioAlternateStatus.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtAlternateBrand.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtAlternatePart.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.radioAlternateStatus);
      this.panelControl2.Controls.Add(this.TxtAlternateBrand);
      this.panelControl2.Controls.Add(this.TxtAlternatePart);
      this.panelControl2.Controls.Add(this.labelControl3);
      this.panelControl2.Controls.Add(this.labelControl2);
      this.panelControl2.Controls.Add(this.labelControl1);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl2.Location = new System.Drawing.Point(0, 47);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(703, 105);
      this.panelControl2.TabIndex = 0;
      // 
      // radioAlternateStatus
      // 
      this.radioAlternateStatus.EnterMoveNextControl = true;
      this.radioAlternateStatus.Location = new System.Drawing.Point(125, 68);
      this.radioAlternateStatus.Name = "radioAlternateStatus";
      this.radioAlternateStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.radioAlternateStatus.Properties.Appearance.Options.UseFont = true;
      this.radioAlternateStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "ไม่กำหนด"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "เบอร์เปลี่ยนใหม่"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "พอใช้แทนกันได้"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "ใช้แทนเบอร์เก่าได้")});
      this.radioAlternateStatus.Size = new System.Drawing.Size(573, 32);
      this.radioAlternateStatus.TabIndex = 5;
      // 
      // TxtAlternateBrand
      // 
      this.TxtAlternateBrand.EnterMoveNextControl = true;
      this.TxtAlternateBrand.Location = new System.Drawing.Point(125, 37);
      this.TxtAlternateBrand.Name = "TxtAlternateBrand";
      this.TxtAlternateBrand.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtAlternateBrand.Properties.Appearance.Options.UseFont = true;
      this.TxtAlternateBrand.Size = new System.Drawing.Size(235, 26);
      this.TxtAlternateBrand.TabIndex = 3;
      // 
      // TxtAlternatePart
      // 
      this.TxtAlternatePart.EnterMoveNextControl = true;
      this.TxtAlternatePart.Location = new System.Drawing.Point(125, 5);
      this.TxtAlternatePart.Name = "TxtAlternatePart";
      this.TxtAlternatePart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtAlternatePart.Properties.Appearance.Options.UseFont = true;
      this.TxtAlternatePart.Size = new System.Drawing.Size(235, 26);
      this.TxtAlternatePart.TabIndex = 1;
      // 
      // labelControl3
      // 
      this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl3.Appearance.Options.UseFont = true;
      this.labelControl3.Location = new System.Drawing.Point(75, 71);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(44, 19);
      this.labelControl3.TabIndex = 4;
      this.labelControl3.Text = "สถานะ";
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl2.Appearance.Options.UseFont = true;
      this.labelControl2.Location = new System.Drawing.Point(90, 40);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(29, 19);
      this.labelControl2.TabIndex = 2;
      this.labelControl2.Text = "ยี่ห้อ";
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Location = new System.Drawing.Point(12, 8);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(107, 19);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "หมายเลขอะไหล่";
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.btClose);
      this.panelControl1.Controls.Add(this.btReset);
      this.panelControl1.Controls.Add(this.btSave);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(703, 47);
      this.panelControl1.TabIndex = 1;
      // 
      // btClose
      // 
      this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btClose.Appearance.Options.UseFont = true;
      this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
      this.btClose.Location = new System.Drawing.Point(185, 6);
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
      this.btReset.Location = new System.Drawing.Point(96, 6);
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
      this.btSave.Location = new System.Drawing.Point(5, 6);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(85, 36);
      this.btSave.TabIndex = 0;
      this.btSave.Text = "บันทึก";
      this.btSave.ToolTip = "บันทึก = F2";
      this.btSave.Click += new System.EventHandler(this.btSave_Click);
      // 
      // frmD_AlternateInput
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(703, 152);
      this.Controls.Add(this.panelControl1);
      this.Controls.Add(this.panelControl2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "frmD_AlternateInput";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmDAlternateInput";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmD_AlternateInput_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radioAlternateStatus.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtAlternateBrand.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtAlternatePart.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btClose;
    private DevExpress.XtraEditors.SimpleButton btReset;
    private DevExpress.XtraEditors.SimpleButton btSave;
    internal DevExpress.XtraEditors.RadioGroup radioAlternateStatus;
    internal DevExpress.XtraEditors.TextEdit TxtAlternateBrand;
    internal DevExpress.XtraEditors.TextEdit TxtAlternatePart;
  }
}
namespace SmartPart.Forms.Code
{
    partial class frmD_ComponentInput
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
      this.TxtComponentName = new DevExpress.XtraEditors.TextEdit();
      this.TxtComponentCode = new DevExpress.XtraEditors.TextEdit();
      this.spinQuantity = new DevExpress.XtraEditors.SpinEdit();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.btClose = new DevExpress.XtraEditors.SimpleButton();
      this.btReset = new DevExpress.XtraEditors.SimpleButton();
      this.btSave = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtComponentName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtComponentCode.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinQuantity.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.TxtComponentName);
      this.panelControl2.Controls.Add(this.TxtComponentCode);
      this.panelControl2.Controls.Add(this.spinQuantity);
      this.panelControl2.Controls.Add(this.labelControl3);
      this.panelControl2.Controls.Add(this.labelControl2);
      this.panelControl2.Controls.Add(this.labelControl1);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl2.Location = new System.Drawing.Point(0, 47);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(458, 102);
      this.panelControl2.TabIndex = 0;
      // 
      // TxtComponentName
      // 
      this.TxtComponentName.EnterMoveNextControl = true;
      this.TxtComponentName.Location = new System.Drawing.Point(126, 36);
      this.TxtComponentName.Name = "TxtComponentName";
      this.TxtComponentName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtComponentName.Properties.Appearance.Options.UseFont = true;
      this.TxtComponentName.Size = new System.Drawing.Size(235, 26);
      this.TxtComponentName.TabIndex = 3;
      // 
      // TxtComponentCode
      // 
      this.TxtComponentCode.EnterMoveNextControl = true;
      this.TxtComponentCode.Location = new System.Drawing.Point(126, 5);
      this.TxtComponentCode.Name = "TxtComponentCode";
      this.TxtComponentCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtComponentCode.Properties.Appearance.Options.UseFont = true;
      this.TxtComponentCode.Properties.MaxLength = 3;
      this.TxtComponentCode.Size = new System.Drawing.Size(73, 26);
      this.TxtComponentCode.TabIndex = 1;
      // 
      // spinQuantity
      // 
      this.spinQuantity.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.spinQuantity.EnterMoveNextControl = true;
      this.spinQuantity.Location = new System.Drawing.Point(126, 68);
      this.spinQuantity.Name = "spinQuantity";
      this.spinQuantity.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.spinQuantity.Properties.Appearance.Options.UseFont = true;
      this.spinQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.spinQuantity.Size = new System.Drawing.Size(73, 26);
      this.spinQuantity.TabIndex = 5;
      // 
      // labelControl3
      // 
      this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl3.Appearance.Options.UseFont = true;
      this.labelControl3.Location = new System.Drawing.Point(75, 71);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(45, 19);
      this.labelControl3.TabIndex = 4;
      this.labelControl3.Text = "จำนวน";
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl2.Appearance.Options.UseFont = true;
      this.labelControl2.Location = new System.Drawing.Point(19, 39);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(101, 19);
      this.labelControl2.TabIndex = 2;
      this.labelControl2.Text = "ชื่อส่วนประกอบ";
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Location = new System.Drawing.Point(12, 8);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(108, 19);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "รหัสส่วนประกอบ";
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.btClose);
      this.panelControl1.Controls.Add(this.btReset);
      this.panelControl1.Controls.Add(this.btSave);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(458, 47);
      this.panelControl1.TabIndex = 1;
      // 
      // btClose
      // 
      this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btClose.Appearance.Options.UseFont = true;
      this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
      this.btClose.Location = new System.Drawing.Point(185, 5);
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
      this.btReset.Location = new System.Drawing.Point(96, 5);
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
      this.btSave.Location = new System.Drawing.Point(5, 5);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(85, 36);
      this.btSave.TabIndex = 0;
      this.btSave.Text = "บันทึก";
      this.btSave.ToolTip = "บันทึก = F2";
      this.btSave.Click += new System.EventHandler(this.btSave_Click);
      // 
      // frmD_ComponentInput
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(458, 149);
      this.Controls.Add(this.panelControl1);
      this.Controls.Add(this.panelControl2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "frmD_ComponentInput";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmDComponentInput";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmD_ComponentInput_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtComponentName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtComponentCode.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinQuantity.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btClose;
    private DevExpress.XtraEditors.SimpleButton btReset;
    private DevExpress.XtraEditors.SimpleButton btSave;
    internal DevExpress.XtraEditors.TextEdit TxtComponentCode;
    internal DevExpress.XtraEditors.SpinEdit spinQuantity;
    internal DevExpress.XtraEditors.LabelControl labelControl2;
    internal DevExpress.XtraEditors.LabelControl labelControl1;
    internal DevExpress.XtraEditors.TextEdit TxtComponentName;
    internal DevExpress.XtraEditors.LabelControl labelControl3;
  }
}
namespace SmartPart.Forms.Code
{
    partial class frmD_ItemVersatiles_Sub
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
      this.TxtCodeSub = new DevExpress.XtraEditors.TextEdit();
      this.TxtNameSub = new DevExpress.XtraEditors.TextEdit();
      this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.btClose = new DevExpress.XtraEditors.SimpleButton();
      this.btReset = new DevExpress.XtraEditors.SimpleButton();
      this.btSave = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtCodeSub.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtNameSub.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.TxtCodeSub);
      this.panelControl2.Controls.Add(this.TxtNameSub);
      this.panelControl2.Controls.Add(this.labelControl5);
      this.panelControl2.Controls.Add(this.labelControl6);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl2.Location = new System.Drawing.Point(0, 48);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(462, 109);
      this.panelControl2.TabIndex = 0;
      // 
      // TxtCodeSub
      // 
      this.TxtCodeSub.EnterMoveNextControl = true;
      this.TxtCodeSub.Location = new System.Drawing.Point(108, 28);
      this.TxtCodeSub.Name = "TxtCodeSub";
      this.TxtCodeSub.Properties.Appearance.BackColor = System.Drawing.Color.White;
      this.TxtCodeSub.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtCodeSub.Properties.Appearance.Options.UseBackColor = true;
      this.TxtCodeSub.Properties.Appearance.Options.UseFont = true;
      this.TxtCodeSub.Properties.MaxLength = 5;
      this.TxtCodeSub.Size = new System.Drawing.Size(153, 26);
      this.TxtCodeSub.TabIndex = 1;
      // 
      // TxtNameSub
      // 
      this.TxtNameSub.EnterMoveNextControl = true;
      this.TxtNameSub.Location = new System.Drawing.Point(108, 60);
      this.TxtNameSub.Name = "TxtNameSub";
      this.TxtNameSub.Properties.Appearance.BackColor = System.Drawing.Color.White;
      this.TxtNameSub.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtNameSub.Properties.Appearance.Options.UseBackColor = true;
      this.TxtNameSub.Properties.Appearance.Options.UseFont = true;
      this.TxtNameSub.Size = new System.Drawing.Size(319, 26);
      this.TxtNameSub.TabIndex = 3;
      // 
      // labelControl5
      // 
      this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl5.Appearance.Options.UseFont = true;
      this.labelControl5.Location = new System.Drawing.Point(25, 63);
      this.labelControl5.Name = "labelControl5";
      this.labelControl5.Size = new System.Drawing.Size(77, 19);
      this.labelControl5.TabIndex = 2;
      this.labelControl5.Text = "ชื่อกลุ่มย่อย";
      // 
      // labelControl6
      // 
      this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl6.Appearance.Options.UseFont = true;
      this.labelControl6.Location = new System.Drawing.Point(18, 31);
      this.labelControl6.Name = "labelControl6";
      this.labelControl6.Size = new System.Drawing.Size(84, 19);
      this.labelControl6.TabIndex = 0;
      this.labelControl6.Text = "รหัสกลุ่มย่อย";
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.btClose);
      this.panelControl1.Controls.Add(this.btReset);
      this.panelControl1.Controls.Add(this.btSave);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(462, 48);
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
      // frmD_ItemVersatiles_Sub
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(462, 157);
      this.Controls.Add(this.panelControl1);
      this.Controls.Add(this.panelControl2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "frmD_ItemVersatiles_Sub";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmDComplementary_Item";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmD_ItemSetInput_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtCodeSub.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtNameSub.Properties)).EndInit();
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
    internal DevExpress.XtraEditors.TextEdit TxtCodeSub;
    internal DevExpress.XtraEditors.TextEdit TxtNameSub;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private DevExpress.XtraEditors.LabelControl labelControl6;
  }
}
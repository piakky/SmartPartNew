namespace SmartPart.Forms.Code
{
    partial class frm_Transports_Record
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
      this.TxtTransportDesc = new DevExpress.XtraEditors.MemoEdit();
      this.TxtTransportCode = new DevExpress.XtraEditors.TextEdit();
      this.TxtTransportName = new DevExpress.XtraEditors.TextEdit();
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.BTcancel = new DevExpress.XtraEditors.SimpleButton();
      this.BTreset = new DevExpress.XtraEditors.SimpleButton();
      this.BTsave = new DevExpress.XtraEditors.SimpleButton();
      this.BTsaveclose = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtTransportDesc.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtTransportCode.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtTransportName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.TxtTransportDesc);
      this.panelControl2.Controls.Add(this.TxtTransportCode);
      this.panelControl2.Controls.Add(this.TxtTransportName);
      this.panelControl2.Controls.Add(this.labelControl4);
      this.panelControl2.Controls.Add(this.labelControl2);
      this.panelControl2.Controls.Add(this.labelControl1);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl2.Location = new System.Drawing.Point(0, 47);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(516, 163);
      this.panelControl2.TabIndex = 0;
      // 
      // TxtTransportDesc
      // 
      this.TxtTransportDesc.EnterMoveNextControl = true;
      this.TxtTransportDesc.Location = new System.Drawing.Point(144, 70);
      this.TxtTransportDesc.Name = "TxtTransportDesc";
      this.TxtTransportDesc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtTransportDesc.Properties.Appearance.Options.UseFont = true;
      this.TxtTransportDesc.Properties.MaxLength = 100;
      this.TxtTransportDesc.Size = new System.Drawing.Size(360, 81);
      this.TxtTransportDesc.TabIndex = 5;
      // 
      // TxtTransportCode
      // 
      this.TxtTransportCode.EnterMoveNextControl = true;
      this.TxtTransportCode.Location = new System.Drawing.Point(144, 6);
      this.TxtTransportCode.Name = "TxtTransportCode";
      this.TxtTransportCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtTransportCode.Properties.Appearance.Options.UseFont = true;
      this.TxtTransportCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.TxtTransportCode.Properties.MaxLength = 2;
      this.TxtTransportCode.Size = new System.Drawing.Size(97, 26);
      this.TxtTransportCode.TabIndex = 1;
      // 
      // TxtTransportName
      // 
      this.TxtTransportName.EnterMoveNextControl = true;
      this.TxtTransportName.Location = new System.Drawing.Point(144, 38);
      this.TxtTransportName.Name = "TxtTransportName";
      this.TxtTransportName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtTransportName.Properties.Appearance.Options.UseFont = true;
      this.TxtTransportName.Properties.MaxLength = 100;
      this.TxtTransportName.Size = new System.Drawing.Size(360, 26);
      this.TxtTransportName.TabIndex = 3;
      // 
      // labelControl4
      // 
      this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl4.Appearance.Options.UseFont = true;
      this.labelControl4.Location = new System.Drawing.Point(19, 41);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(119, 19);
      this.labelControl4.TabIndex = 2;
      this.labelControl4.Text = "ชื่อการจัดส่งสินค้า";
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl2.Appearance.Options.UseFont = true;
      this.labelControl2.Location = new System.Drawing.Point(63, 72);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(75, 19);
      this.labelControl2.TabIndex = 4;
      this.labelControl2.Text = "รายละเอียด";
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Location = new System.Drawing.Point(12, 9);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(126, 19);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "รหัสการจัดส่งสินค้า";
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
      this.panelControl1.Size = new System.Drawing.Size(516, 47);
      this.panelControl1.TabIndex = 1;
      // 
      // BTcancel
      // 
      this.BTcancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.BTcancel.Appearance.Options.UseFont = true;
      this.BTcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.BTcancel.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
      this.BTcancel.Location = new System.Drawing.Point(342, 5);
      this.BTcancel.Name = "BTcancel";
      this.BTcancel.Size = new System.Drawing.Size(84, 36);
      this.BTcancel.TabIndex = 2;
      this.BTcancel.Text = "ยกเลิก";
      this.BTcancel.ToolTip = "ยกเลิก = ESC";
      this.BTcancel.Click += new System.EventHandler(this.BTcancel_Click);
      // 
      // BTreset
      // 
      this.BTreset.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.BTreset.Appearance.Options.UseFont = true;
      this.BTreset.Location = new System.Drawing.Point(239, 5);
      this.BTreset.Name = "BTreset";
      this.BTreset.Size = new System.Drawing.Size(97, 36);
      this.BTreset.TabIndex = 1;
      this.BTreset.Text = "เริ่มใหม่";
      this.BTreset.ToolTip = "เริ่มใหม่ = F3";
      this.BTreset.Click += new System.EventHandler(this.BTreset_Click);
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
      // BTsaveclose
      // 
      this.BTsaveclose.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.BTsaveclose.Appearance.Options.UseFont = true;
      this.BTsaveclose.ImageOptions.Image = global::SmartPart.Properties.Resources.page_save;
      this.BTsaveclose.Location = new System.Drawing.Point(103, 5);
      this.BTsaveclose.Name = "BTsaveclose";
      this.BTsaveclose.Size = new System.Drawing.Size(130, 36);
      this.BTsaveclose.TabIndex = 0;
      this.BTsaveclose.Tag = "1";
      this.BTsaveclose.Text = "บันทึก/ปิด";
      this.BTsaveclose.Click += new System.EventHandler(this.BTsave_Click);
      // 
      // frm_Transports_Record
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(516, 210);
      this.ControlBox = false;
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "frm_Transports_Record";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmTransports_Record";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Categories_Record_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtTransportDesc.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtTransportCode.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtTransportName.Properties)).EndInit();
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
    internal DevExpress.XtraEditors.MemoEdit TxtTransportDesc;
    internal DevExpress.XtraEditors.TextEdit TxtTransportCode;
    internal DevExpress.XtraEditors.TextEdit TxtTransportName;
    private DevExpress.XtraEditors.SimpleButton BTsaveclose;
  }
}
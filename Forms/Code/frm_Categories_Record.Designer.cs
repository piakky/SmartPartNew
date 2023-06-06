namespace SmartPart.Forms.Code
{
    partial class frm_Categories_Record
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
      this.TxtCategoryDesc = new DevExpress.XtraEditors.MemoEdit();
      this.TxtCategoryCode = new DevExpress.XtraEditors.TextEdit();
      this.TxtCategoryName = new DevExpress.XtraEditors.TextEdit();
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
      ((System.ComponentModel.ISupportInitialize)(this.TxtCategoryDesc.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtCategoryCode.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtCategoryName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.TxtCategoryDesc);
      this.panelControl2.Controls.Add(this.TxtCategoryCode);
      this.panelControl2.Controls.Add(this.TxtCategoryName);
      this.panelControl2.Controls.Add(this.labelControl4);
      this.panelControl2.Controls.Add(this.labelControl2);
      this.panelControl2.Controls.Add(this.labelControl1);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl2.Location = new System.Drawing.Point(0, 47);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(516, 163);
      this.panelControl2.TabIndex = 0;
      // 
      // TxtCategoryDesc
      // 
      this.TxtCategoryDesc.EnterMoveNextControl = true;
      this.TxtCategoryDesc.Location = new System.Drawing.Point(103, 70);
      this.TxtCategoryDesc.Name = "TxtCategoryDesc";
      this.TxtCategoryDesc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtCategoryDesc.Properties.Appearance.Options.UseFont = true;
      this.TxtCategoryDesc.Properties.MaxLength = 100;
      this.TxtCategoryDesc.Size = new System.Drawing.Size(401, 81);
      this.TxtCategoryDesc.TabIndex = 5;
      // 
      // TxtCategoryCode
      // 
      this.TxtCategoryCode.EnterMoveNextControl = true;
      this.TxtCategoryCode.Location = new System.Drawing.Point(103, 6);
      this.TxtCategoryCode.Name = "TxtCategoryCode";
      this.TxtCategoryCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtCategoryCode.Properties.Appearance.Options.UseFont = true;
      this.TxtCategoryCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.TxtCategoryCode.Properties.MaxLength = 3;
      this.TxtCategoryCode.Size = new System.Drawing.Size(97, 26);
      this.TxtCategoryCode.TabIndex = 1;
      // 
      // TxtCategoryName
      // 
      this.TxtCategoryName.EnterMoveNextControl = true;
      this.TxtCategoryName.Location = new System.Drawing.Point(103, 38);
      this.TxtCategoryName.Name = "TxtCategoryName";
      this.TxtCategoryName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtCategoryName.Properties.Appearance.Options.UseFont = true;
      this.TxtCategoryName.Properties.MaxLength = 100;
      this.TxtCategoryName.Size = new System.Drawing.Size(401, 26);
      this.TxtCategoryName.TabIndex = 3;
      // 
      // labelControl4
      // 
      this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl4.Appearance.Options.UseFont = true;
      this.labelControl4.Location = new System.Drawing.Point(19, 41);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(78, 19);
      this.labelControl4.TabIndex = 2;
      this.labelControl4.Text = "ชื่อหมวดหมู่";
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl2.Appearance.Options.UseFont = true;
      this.labelControl2.Location = new System.Drawing.Point(22, 71);
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
      this.labelControl1.Size = new System.Drawing.Size(85, 19);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "รหัสหมวดหมู่";
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
      // frm_Categories_Record
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(516, 210);
      this.ControlBox = false;
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "frm_Categories_Record";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmCategories_Record";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Categories_Record_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtCategoryDesc.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtCategoryCode.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtCategoryName.Properties)).EndInit();
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
    internal DevExpress.XtraEditors.MemoEdit TxtCategoryDesc;
    internal DevExpress.XtraEditors.TextEdit TxtCategoryCode;
    internal DevExpress.XtraEditors.TextEdit TxtCategoryName;
    private DevExpress.XtraEditors.SimpleButton BTsaveclose;
  }
}
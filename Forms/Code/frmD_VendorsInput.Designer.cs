namespace SmartPart.Forms.Code
{
  partial class frmD_VendorsInput
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
            this.TxtVendorName = new DevExpress.XtraEditors.TextEdit();
            this.spinPiority = new DevExpress.XtraEditors.SpinEdit();
            this.searchLookUpVendor = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.btReset = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVendorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPiority.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.TxtVendorName);
            this.panelControl2.Controls.Add(this.spinPiority);
            this.panelControl2.Controls.Add(this.searchLookUpVendor);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 47);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(508, 75);
            this.panelControl2.TabIndex = 0;
            // 
            // TxtVendorName
            // 
            this.TxtVendorName.EnterMoveNextControl = true;
            this.TxtVendorName.Location = new System.Drawing.Point(272, 5);
            this.TxtVendorName.Name = "TxtVendorName";
            this.TxtVendorName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtVendorName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TxtVendorName.Properties.Appearance.Options.UseBackColor = true;
            this.TxtVendorName.Properties.Appearance.Options.UseFont = true;
            this.TxtVendorName.Properties.ReadOnly = true;
            this.TxtVendorName.Size = new System.Drawing.Size(226, 26);
            this.TxtVendorName.TabIndex = 2;
            // 
            // spinPiority
            // 
            this.spinPiority.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinPiority.EnterMoveNextControl = true;
            this.spinPiority.Location = new System.Drawing.Point(131, 37);
            this.spinPiority.Name = "spinPiority";
            this.spinPiority.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.spinPiority.Properties.Appearance.Options.UseFont = true;
            this.spinPiority.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinPiority.Size = new System.Drawing.Size(135, 26);
            this.spinPiority.TabIndex = 4;
            // 
            // searchLookUpVendor
            // 
            this.searchLookUpVendor.EnterMoveNextControl = true;
            this.searchLookUpVendor.Location = new System.Drawing.Point(131, 5);
            this.searchLookUpVendor.Name = "searchLookUpVendor";
            this.searchLookUpVendor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.searchLookUpVendor.Properties.Appearance.Options.UseFont = true;
            this.searchLookUpVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpVendor.Properties.NullText = "เลือกรหัสเจ้าหนี้";
            this.searchLookUpVendor.Size = new System.Drawing.Size(135, 26);
            this.searchLookUpVendor.TabIndex = 1;
            this.searchLookUpVendor.EditValueChanged += new System.EventHandler(this.searchLookUpVendor_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(111, 19);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "ระดับความสำคัญ";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(81, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "เจ้าหนี้";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btClose);
            this.panelControl1.Controls.Add(this.btReset);
            this.panelControl1.Controls.Add(this.btSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(508, 47);
            this.panelControl1.TabIndex = 1;
            // 
            // btClose
            // 
            this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btClose.Appearance.Options.UseFont = true;
            this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.btClose.Location = new System.Drawing.Point(183, 5);
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
            this.btReset.Location = new System.Drawing.Point(94, 5);
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
            this.btSave.Size = new System.Drawing.Size(83, 36);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "บันทึก";
            this.btSave.ToolTip = "บันทึก = F2";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // frmD_VendorsInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 122);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmD_VendorsInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDVendorsInput";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmD_VendorsInput_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVendorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPiority.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btClose;
    private DevExpress.XtraEditors.SimpleButton btReset;
    private DevExpress.XtraEditors.SimpleButton btSave;
    internal DevExpress.XtraEditors.TextEdit TxtVendorName;
    internal DevExpress.XtraEditors.SpinEdit spinPiority;
    internal DevExpress.XtraEditors.SearchLookUpEdit searchLookUpVendor;
  }
}
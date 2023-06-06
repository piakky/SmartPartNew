namespace SmartPart.Forms.Code
{
    partial class frmD_PicturesInput
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
      this.Txtfilename = new DevExpress.XtraEditors.TextEdit();
      this.pictureDisplay = new DevExpress.XtraEditors.PictureEdit();
      this.BTaddImage = new DevExpress.XtraEditors.SimpleButton();
      this.Txtpath = new DevExpress.XtraEditors.TextEdit();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.btClose = new DevExpress.XtraEditors.SimpleButton();
      this.btReset = new DevExpress.XtraEditors.SimpleButton();
      this.btSave = new DevExpress.XtraEditors.SimpleButton();
      this.TxtfilePath = new DevExpress.XtraEditors.TextEdit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Txtfilename.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureDisplay.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Txtpath.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtfilePath.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.TxtfilePath);
      this.panelControl2.Controls.Add(this.Txtfilename);
      this.panelControl2.Controls.Add(this.pictureDisplay);
      this.panelControl2.Controls.Add(this.BTaddImage);
      this.panelControl2.Controls.Add(this.Txtpath);
      this.panelControl2.Controls.Add(this.labelControl1);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl2.Location = new System.Drawing.Point(0, 48);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(545, 371);
      this.panelControl2.TabIndex = 5;
      // 
      // Txtfilename
      // 
      this.Txtfilename.Location = new System.Drawing.Point(95, 136);
      this.Txtfilename.Name = "Txtfilename";
      this.Txtfilename.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.Txtfilename.Properties.Appearance.Options.UseFont = true;
      this.Txtfilename.Size = new System.Drawing.Size(294, 26);
      this.Txtfilename.TabIndex = 7;
      this.Txtfilename.Visible = false;
      // 
      // pictureDisplay
      // 
      this.pictureDisplay.Cursor = System.Windows.Forms.Cursors.Default;
      this.pictureDisplay.Location = new System.Drawing.Point(5, 39);
      this.pictureDisplay.Name = "pictureDisplay";
      this.pictureDisplay.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
      this.pictureDisplay.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
      this.pictureDisplay.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
      this.pictureDisplay.Properties.ZoomAccelerationFactor = 1D;
      this.pictureDisplay.Size = new System.Drawing.Size(535, 327);
      this.pictureDisplay.TabIndex = 6;
      // 
      // BTaddImage
      // 
      this.BTaddImage.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.BTaddImage.Appearance.Options.UseFont = true;
      this.BTaddImage.Appearance.Options.UseTextOptions = true;
      this.BTaddImage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.BTaddImage.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
      this.BTaddImage.ImageOptions.Image = global::SmartPart.Properties.Resources.folder;
      this.BTaddImage.Location = new System.Drawing.Point(458, 3);
      this.BTaddImage.Name = "BTaddImage";
      this.BTaddImage.Size = new System.Drawing.Size(75, 32);
      this.BTaddImage.TabIndex = 5;
      this.BTaddImage.Text = "เลือก";
      this.BTaddImage.Click += new System.EventHandler(this.BTaddImage_Click);
      // 
      // Txtpath
      // 
      this.Txtpath.Location = new System.Drawing.Point(158, 7);
      this.Txtpath.Name = "Txtpath";
      this.Txtpath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.Txtpath.Properties.Appearance.Options.UseFont = true;
      this.Txtpath.Size = new System.Drawing.Size(294, 26);
      this.Txtpath.TabIndex = 4;
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Location = new System.Drawing.Point(5, 10);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(147, 19);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "กรุณาเลือกไฟล์รูปภาพ";
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.btClose);
      this.panelControl1.Controls.Add(this.btReset);
      this.panelControl1.Controls.Add(this.btSave);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(545, 48);
      this.panelControl1.TabIndex = 6;
      // 
      // btClose
      // 
      this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btClose.Appearance.Options.UseFont = true;
      this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
      this.btClose.Location = new System.Drawing.Point(180, 6);
      this.btClose.Name = "btClose";
      this.btClose.Size = new System.Drawing.Size(83, 36);
      this.btClose.TabIndex = 4;
      this.btClose.Text = "ยกเลิก";
      this.btClose.ToolTip = "ยกเลิก = ESC";
      this.btClose.Click += new System.EventHandler(this.btClose_Click);
      // 
      // btReset
      // 
      this.btReset.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btReset.Appearance.Options.UseFont = true;
      this.btReset.Location = new System.Drawing.Point(95, 6);
      this.btReset.Name = "btReset";
      this.btReset.Size = new System.Drawing.Size(79, 36);
      this.btReset.TabIndex = 5;
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
      this.btSave.Size = new System.Drawing.Size(84, 36);
      this.btSave.TabIndex = 3;
      this.btSave.Text = "บันทึก";
      this.btSave.ToolTip = "บันทึก = F2";
      this.btSave.Click += new System.EventHandler(this.btSave_Click);
      // 
      // TxtfilePath
      // 
      this.TxtfilePath.Location = new System.Drawing.Point(95, 168);
      this.TxtfilePath.Name = "TxtfilePath";
      this.TxtfilePath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtfilePath.Properties.Appearance.Options.UseFont = true;
      this.TxtfilePath.Size = new System.Drawing.Size(294, 26);
      this.TxtfilePath.TabIndex = 8;
      this.TxtfilePath.Visible = false;
      // 
      // frmD_PicturesInput
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(545, 419);
      this.Controls.Add(this.panelControl1);
      this.Controls.Add(this.panelControl2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "frmD_PicturesInput";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmDPicturesInput";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmD_PicturesInput_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Txtfilename.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureDisplay.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Txtpath.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.TxtfilePath.Properties)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton BTaddImage;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btClose;
    private DevExpress.XtraEditors.SimpleButton btReset;
    private DevExpress.XtraEditors.SimpleButton btSave;
    internal DevExpress.XtraEditors.PictureEdit pictureDisplay;
    internal DevExpress.XtraEditors.TextEdit Txtfilename;
    internal DevExpress.XtraEditors.TextEdit Txtpath;
    internal DevExpress.XtraEditors.TextEdit TxtfilePath;
  }
}
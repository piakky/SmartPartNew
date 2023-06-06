namespace SmartPart.Forms.Input
{
  partial class frm_ImportPriceList
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ImportPriceList));
      this.image32 = new DevExpress.Utils.ImageCollection(this.components);
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.txtImPath = new System.Windows.Forms.TextBox();
      this.btnGetFile = new System.Windows.Forms.Button();
      this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
      this.txtCaption = new DevExpress.XtraEditors.TextEdit();
      this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.BTnote = new DevExpress.XtraEditors.SimpleButton();
      this.BTexit = new DevExpress.XtraEditors.SimpleButton();
      this.BTprocess = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.image32)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtCaption.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      this.SuspendLayout();
      // 
      // image32
      // 
      this.image32.ImageSize = new System.Drawing.Size(32, 32);
      this.image32.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("image32.ImageStream")));
      this.image32.Images.SetKeyName(0, "Paomedia-Small-N-Flat-Notepad.ico");
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.labelControl4);
      this.panelControl1.Controls.Add(this.txtImPath);
      this.panelControl1.Controls.Add(this.btnGetFile);
      this.panelControl1.Controls.Add(this.txtDescription);
      this.panelControl1.Controls.Add(this.txtCaption);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(616, 304);
      this.panelControl1.TabIndex = 0;
      // 
      // labelControl4
      // 
      this.labelControl4.Location = new System.Drawing.Point(5, 15);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(42, 13);
      this.labelControl4.TabIndex = 27;
      this.labelControl4.Text = "Excel file";
      // 
      // txtImPath
      // 
      this.txtImPath.Location = new System.Drawing.Point(53, 12);
      this.txtImPath.Name = "txtImPath";
      this.txtImPath.Size = new System.Drawing.Size(320, 21);
      this.txtImPath.TabIndex = 25;
      // 
      // btnGetFile
      // 
      this.btnGetFile.Image = ((System.Drawing.Image)(resources.GetObject("btnGetFile.Image")));
      this.btnGetFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnGetFile.Location = new System.Drawing.Point(379, 4);
      this.btnGetFile.Name = "btnGetFile";
      this.btnGetFile.Size = new System.Drawing.Size(38, 35);
      this.btnGetFile.TabIndex = 26;
      this.btnGetFile.UseVisualStyleBackColor = true;
      this.btnGetFile.Click += new System.EventHandler(this.btnImGetCus_Click);
      // 
      // txtDescription
      // 
      this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDescription.Location = new System.Drawing.Point(5, 68);
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.Size = new System.Drawing.Size(604, 230);
      this.txtDescription.TabIndex = 3;
      // 
      // txtCaption
      // 
      this.txtCaption.Enabled = false;
      this.txtCaption.Location = new System.Drawing.Point(5, 40);
      this.txtCaption.Name = "txtCaption";
      this.txtCaption.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
      this.txtCaption.Properties.Appearance.Options.UseBackColor = true;
      this.txtCaption.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
      this.txtCaption.Size = new System.Drawing.Size(604, 22);
      this.txtCaption.TabIndex = 1;
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.BTnote);
      this.panelControl2.Controls.Add(this.BTexit);
      this.panelControl2.Controls.Add(this.BTprocess);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl2.Location = new System.Drawing.Point(0, 304);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(616, 65);
      this.panelControl2.TabIndex = 1;
      // 
      // BTnote
      // 
      this.BTnote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.BTnote.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.BTnote.Appearance.Options.UseFont = true;
      this.BTnote.ImageOptions.ImageIndex = 0;
      this.BTnote.ImageOptions.ImageList = this.image32;
      this.BTnote.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
      this.BTnote.Location = new System.Drawing.Point(370, 8);
      this.BTnote.Name = "BTnote";
      this.BTnote.Size = new System.Drawing.Size(59, 52);
      this.BTnote.TabIndex = 3;
      this.BTnote.Visible = false;
      this.BTnote.Click += new System.EventHandler(this.BTnote_Click);
      // 
      // BTexit
      // 
      this.BTexit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.BTexit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.BTexit.Appearance.Options.UseFont = true;
      this.BTexit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
      this.BTexit.Location = new System.Drawing.Point(525, 8);
      this.BTexit.Name = "BTexit";
      this.BTexit.Size = new System.Drawing.Size(84, 52);
      this.BTexit.TabIndex = 5;
      this.BTexit.Text = "Exit";
      this.BTexit.Click += new System.EventHandler(this.BTexit_Click);
      // 
      // BTprocess
      // 
      this.BTprocess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.BTprocess.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.BTprocess.Appearance.Options.UseFont = true;
      this.BTprocess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTprocess.ImageOptions.Image")));
      this.BTprocess.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
      this.BTprocess.Location = new System.Drawing.Point(435, 8);
      this.BTprocess.Name = "BTprocess";
      this.BTprocess.Size = new System.Drawing.Size(84, 52);
      this.BTprocess.TabIndex = 4;
      this.BTprocess.Text = "Process data";
      this.BTprocess.Click += new System.EventHandler(this.BTprocess_Click);
      // 
      // frm_ImportPriceList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(616, 369);
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimumSize = new System.Drawing.Size(100, 100);
      this.Name = "frm_ImportPriceList";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Import Price list...";
      ((System.ComponentModel.ISupportInitialize)(this.image32)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.panelControl1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtCaption.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.Utils.ImageCollection image32;
    private DevExpress.XtraEditors.SimpleButton BTprocess;
    private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.SimpleButton BTexit;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.TextEdit txtCaption;
    private DevExpress.XtraEditors.SimpleButton BTnote;
    private DevExpress.XtraEditors.MemoEdit txtDescription;
    internal System.Windows.Forms.TextBox txtImPath;
    internal System.Windows.Forms.Button btnGetFile;
    private DevExpress.XtraEditors.LabelControl labelControl4;
  }
}
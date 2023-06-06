namespace SmartPart.Forms
{
  partial class frm_ListCodes
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ListCodes));
      this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
      this.gridADV = new DevExpress.XtraGrid.GridControl();
      this.gvADV = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
      this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
      this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.BTok = new DevExpress.XtraEditors.SimpleButton();
      this.BTcancel = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
      this.panelControl3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridADV)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvADV)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelControl3
      // 
      this.panelControl3.Controls.Add(this.gridADV);
      this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl3.Location = new System.Drawing.Point(0, 0);
      this.panelControl3.Name = "panelControl3";
      this.panelControl3.Size = new System.Drawing.Size(608, 283);
      this.panelControl3.TabIndex = 21;
      // 
      // gridADV
      // 
      this.gridADV.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridADV.Location = new System.Drawing.Point(2, 2);
      this.gridADV.MainView = this.gvADV;
      this.gridADV.Name = "gridADV";
      this.gridADV.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2});
      this.gridADV.Size = new System.Drawing.Size(604, 279);
      this.gridADV.TabIndex = 2;
      this.gridADV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvADV});
      // 
      // gvADV
      // 
      this.gvADV.GridControl = this.gridADV;
      this.gvADV.Name = "gvADV";
      this.gvADV.OptionsView.RowAutoHeight = true;
      this.gvADV.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvADV_CustomDrawRowIndicator);
      this.gvADV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvADV_KeyPress);
      this.gvADV.DoubleClick += new System.EventHandler(this.gvADV_DoubleClick);
      // 
      // repositoryItemImageComboBox1
      // 
      this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", false, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", true, 36)});
      this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
      // 
      // repositoryItemImageComboBox2
      // 
      this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", false, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", true, 37)});
      this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.BTok);
      this.panelControl2.Controls.Add(this.BTcancel);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl2.Location = new System.Drawing.Point(0, 283);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(608, 40);
      this.panelControl2.TabIndex = 22;
      // 
      // BTok
      // 
      this.BTok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.BTok.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTok.ImageOptions.Image")));
      this.BTok.Location = new System.Drawing.Point(474, 5);
      this.BTok.Name = "BTok";
      this.BTok.Size = new System.Drawing.Size(60, 30);
      this.BTok.TabIndex = 0;
      this.BTok.Text = "&OK";
      this.BTok.Click += new System.EventHandler(this.BTok_Click);
      // 
      // BTcancel
      // 
      this.BTcancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.BTcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.BTcancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTcancel.ImageOptions.Image")));
      this.BTcancel.Location = new System.Drawing.Point(540, 5);
      this.BTcancel.Name = "BTcancel";
      this.BTcancel.Size = new System.Drawing.Size(60, 30);
      this.BTcancel.TabIndex = 1;
      this.BTcancel.Text = "&Cancel";
      this.BTcancel.Click += new System.EventHandler(this.BTcancel_Click);
      // 
      // frm_ListCodes
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(608, 323);
      this.ControlBox = false;
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl3);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "frm_ListCodes";
      this.Text = "frm_ListCodes";
      this.Shown += new System.EventHandler(this.frm_ListCodes_Shown);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ListCodes_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
      this.panelControl3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridADV)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvADV)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl3;
    internal DevExpress.XtraGrid.GridControl gridADV;
    internal DevExpress.XtraGrid.Views.Grid.GridView gvADV;
    internal DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
    internal DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
    private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.SimpleButton BTok;
    private DevExpress.XtraEditors.SimpleButton BTcancel;

  }
}
namespace Medical.Forms.Code
{
  partial class frm_CodeListCus
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
      this.gridCodeCus = new DevExpress.XtraGrid.GridControl();
      this.gvCodeCus = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.r_Hide = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
      this.r_Lock = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.gridCodeCus)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvCodeCus)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Hide)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Lock)).BeginInit();
      this.SuspendLayout();
      // 
      // gridCodeCus
      // 
      this.gridCodeCus.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridCodeCus.Location = new System.Drawing.Point(0, 0);
      this.gridCodeCus.MainView = this.gvCodeCus;
      this.gridCodeCus.Name = "gridCodeCus";
      this.gridCodeCus.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.r_Hide,
            this.r_Lock});
      this.gridCodeCus.Size = new System.Drawing.Size(960, 449);
      this.gridCodeCus.TabIndex = 1;
      this.gridCodeCus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCodeCus});
      // 
      // gvCodeCus
      // 
      this.gvCodeCus.GridControl = this.gridCodeCus;
      this.gvCodeCus.Name = "gvCodeCus";
      this.gvCodeCus.OptionsView.ColumnAutoWidth = false;
      this.gvCodeCus.OptionsView.RowAutoHeight = true;
      this.gvCodeCus.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvCodeCus_CustomDrawRowIndicator);
      this.gvCodeCus.DoubleClick += new System.EventHandler(this.gvCodeCus_DoubleClick);
      // 
      // r_Hide
      // 
      this.r_Hide.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.r_Hide.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", false, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", true, 36)});
      this.r_Hide.Name = "r_Hide";
      // 
      // r_Lock
      // 
      this.r_Lock.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.r_Lock.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", false, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", true, 37)});
      this.r_Lock.Name = "r_Lock";
      // 
      // frm_CodeListCus
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(960, 449);
      this.Controls.Add(this.gridCodeCus);
      this.Name = "frm_CodeListCus";
      this.Text = "frm_CodeListCus";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_CodeListCus_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.gridCodeCus)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvCodeCus)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Hide)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Lock)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    internal DevExpress.XtraGrid.GridControl gridCodeCus;
    internal DevExpress.XtraGrid.Views.Grid.GridView gvCodeCus;
    internal DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox r_Hide;
    internal DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox r_Lock;
  }
}
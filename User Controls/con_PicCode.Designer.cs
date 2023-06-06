namespace SmartPart.Class
{
  partial class con_PicCode
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(con_PicCode));
      this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
      this.gridControl1 = new DevExpress.XtraGrid.GridControl();
      this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
      this.lvcImage = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
      this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
      this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
      this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      this.BarManager1 = new DevExpress.XtraBars.BarManager(this.components);
      this.brMain = new DevExpress.XtraBars.Bar();
      this.bbiAdd = new DevExpress.XtraBars.BarButtonItem();
      this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
      this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
      this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
      this.gridControl2 = new DevExpress.XtraGrid.GridControl();
      this.layoutView2 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
      this.layoutViewColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
      this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
      this.layoutViewField1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
      this.layoutViewCard2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BarManager1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutView2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutViewField1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard2)).BeginInit();
      this.SuspendLayout();
      // 
      // repositoryItemPictureEdit1
      // 
      this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
      this.repositoryItemPictureEdit1.ReadOnly = true;
      this.repositoryItemPictureEdit1.ShowMenu = false;
      this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
      this.repositoryItemPictureEdit1.ZoomAccelerationFactor = 1D;
      // 
      // gridControl1
      // 
      this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl1.Location = new System.Drawing.Point(0, 31);
      this.gridControl1.MainView = this.layoutView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new System.Drawing.Size(400, 200);
      this.gridControl1.TabIndex = 0;
      this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
      // 
      // layoutView1
      // 
      this.layoutView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.layoutView1.CardMinSize = new System.Drawing.Size(208, 42);
      this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.lvcImage});
      this.layoutView1.GridControl = this.gridControl1;
      this.layoutView1.Name = "layoutView1";
      this.layoutView1.OptionsItemText.TextToControlDistance = 2;
      this.layoutView1.OptionsView.CardArrangeRule = DevExpress.XtraGrid.Views.Layout.LayoutCardArrangeRule.AllowPartialCards;
      this.layoutView1.OptionsView.ShowCardCaption = false;
      this.layoutView1.OptionsView.ShowCardLines = false;
      this.layoutView1.OptionsView.ShowFieldHints = false;
      this.layoutView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
      this.layoutView1.OptionsView.ShowHeaderPanel = false;
      this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Column;
      this.layoutView1.TemplateCard = this.layoutViewCard1;
      // 
      // lvcImage
      // 
      this.lvcImage.ColumnEdit = this.repositoryItemPictureEdit1;
      this.lvcImage.FieldName = "PICture";
      this.lvcImage.LayoutViewField = this.layoutViewField_layoutViewColumn1;
      this.lvcImage.Name = "lvcImage";
      this.lvcImage.OptionsColumn.AllowEdit = false;
      this.lvcImage.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
      this.lvcImage.OptionsColumn.ShowCaption = false;
      this.lvcImage.OptionsFilter.AllowFilter = false;
      // 
      // layoutViewField_layoutViewColumn1
      // 
      this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 200;
      this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 0);
      this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
      this.layoutViewField_layoutViewColumn1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
      this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(208, 24);
      this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(0, 0);
      this.layoutViewField_layoutViewColumn1.TextVisible = false;
      // 
      // layoutViewCard1
      // 
      this.layoutViewCard1.CustomizationFormText = "TemplateCard";
      this.layoutViewCard1.GroupBordersVisible = false;
      this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
      this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1});
      this.layoutViewCard1.Name = "layoutViewCard1";
      this.layoutViewCard1.OptionsItemText.TextToControlDistance = 2;
      this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
      this.layoutViewCard1.Text = "TemplateCard";
      // 
      // barDockControlRight
      // 
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.barDockControlRight.Location = new System.Drawing.Point(324, 31);
      this.barDockControlRight.Manager = null;
      this.barDockControlRight.Size = new System.Drawing.Size(0, 427);
      // 
      // BarManager1
      // 
      this.BarManager1.AllowCustomization = false;
      this.BarManager1.AllowQuickCustomization = false;
      this.BarManager1.AllowShowToolbarsPopup = false;
      this.BarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.brMain});
      this.BarManager1.DockControls.Add(this.barDockControlTop);
      this.BarManager1.DockControls.Add(this.barDockControlBottom);
      this.BarManager1.DockControls.Add(this.barDockControlLeft);
      this.BarManager1.DockControls.Add(this.barDockControl1);
      this.BarManager1.Form = this;
      this.BarManager1.Images = this.imageCollection;
      this.BarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiAdd,
            this.bbiDelete});
      this.BarManager1.MaxItemId = 2;
      // 
      // brMain
      // 
      this.brMain.BarName = "Status bar";
      this.brMain.DockCol = 0;
      this.brMain.DockRow = 0;
      this.brMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      this.brMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDelete)});
      this.brMain.OptionsBar.AllowQuickCustomization = false;
      this.brMain.OptionsBar.DrawDragBorder = false;
      this.brMain.OptionsBar.UseWholeRow = true;
      this.brMain.Text = "Status bar";
      // 
      // bbiAdd
      // 
      this.bbiAdd.Caption = "Add image";
      this.bbiAdd.Hint = "Add new image";
      this.bbiAdd.Id = 0;
      this.bbiAdd.ImageOptions.ImageIndex = 0;
      this.bbiAdd.Name = "bbiAdd";
      this.bbiAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      this.bbiAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAdd_ItemClick);
      // 
      // bbiDelete
      // 
      this.bbiDelete.Caption = "Remove";
      this.bbiDelete.Hint = "Delete current image";
      this.bbiDelete.Id = 1;
      this.bbiDelete.ImageOptions.ImageIndex = 1;
      this.bbiDelete.Name = "bbiDelete";
      this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
      // 
      // barDockControlTop
      // 
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
      this.barDockControlTop.Manager = this.BarManager1;
      this.barDockControlTop.Size = new System.Drawing.Size(324, 31);
      // 
      // barDockControlBottom
      // 
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.barDockControlBottom.Location = new System.Drawing.Point(0, 458);
      this.barDockControlBottom.Manager = this.BarManager1;
      this.barDockControlBottom.Size = new System.Drawing.Size(324, 0);
      // 
      // barDockControlLeft
      // 
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
      this.barDockControlLeft.Manager = this.BarManager1;
      this.barDockControlLeft.Size = new System.Drawing.Size(0, 427);
      // 
      // barDockControl1
      // 
      this.barDockControl1.CausesValidation = false;
      this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
      this.barDockControl1.Location = new System.Drawing.Point(324, 31);
      this.barDockControl1.Manager = this.BarManager1;
      this.barDockControl1.Size = new System.Drawing.Size(0, 427);
      // 
      // imageCollection
      // 
      this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
      this.imageCollection.Images.SetKeyName(0, "1290163520_page_add.png");
      this.imageCollection.Images.SetKeyName(1, "1290162453_button_cancel.png");
      // 
      // gridControl2
      // 
      this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl2.Location = new System.Drawing.Point(0, 31);
      this.gridControl2.MainView = this.layoutView2;
      this.gridControl2.MenuManager = this.BarManager1;
      this.gridControl2.Name = "gridControl2";
      this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit2});
      this.gridControl2.Size = new System.Drawing.Size(324, 427);
      this.gridControl2.TabIndex = 6;
      this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView2});
      // 
      // layoutView2
      // 
      this.layoutView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.layoutView2.CardMinSize = new System.Drawing.Size(208, 42);
      this.layoutView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.layoutViewColumn1});
      this.layoutView2.GridControl = this.gridControl2;
      this.layoutView2.Name = "layoutView2";
      this.layoutView2.OptionsItemText.TextToControlDistance = 2;
      this.layoutView2.OptionsView.CardArrangeRule = DevExpress.XtraGrid.Views.Layout.LayoutCardArrangeRule.AllowPartialCards;
      this.layoutView2.OptionsView.ShowCardCaption = false;
      this.layoutView2.OptionsView.ShowCardLines = false;
      this.layoutView2.OptionsView.ShowFieldHints = false;
      this.layoutView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
      this.layoutView2.OptionsView.ShowHeaderPanel = false;
      this.layoutView2.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Column;
      this.layoutView2.TemplateCard = this.layoutViewCard2;
      // 
      // layoutViewColumn1
      // 
      this.layoutViewColumn1.ColumnEdit = this.repositoryItemPictureEdit2;
      this.layoutViewColumn1.FieldName = "PICture";
      this.layoutViewColumn1.LayoutViewField = this.layoutViewField1;
      this.layoutViewColumn1.Name = "layoutViewColumn1";
      this.layoutViewColumn1.OptionsColumn.AllowEdit = false;
      this.layoutViewColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
      this.layoutViewColumn1.OptionsColumn.ShowCaption = false;
      this.layoutViewColumn1.OptionsFilter.AllowFilter = false;
      // 
      // repositoryItemPictureEdit2
      // 
      this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
      this.repositoryItemPictureEdit2.ReadOnly = true;
      this.repositoryItemPictureEdit2.ShowMenu = false;
      this.repositoryItemPictureEdit2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
      this.repositoryItemPictureEdit2.ZoomAccelerationFactor = 1D;
      // 
      // layoutViewField1
      // 
      this.layoutViewField1.EditorPreferredWidth = 200;
      this.layoutViewField1.Location = new System.Drawing.Point(0, 0);
      this.layoutViewField1.Name = "layoutViewField1";
      this.layoutViewField1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
      this.layoutViewField1.Size = new System.Drawing.Size(208, 24);
      this.layoutViewField1.TextSize = new System.Drawing.Size(0, 0);
      this.layoutViewField1.TextVisible = false;
      // 
      // layoutViewCard2
      // 
      this.layoutViewCard2.CustomizationFormText = "TemplateCard";
      this.layoutViewCard2.GroupBordersVisible = false;
      this.layoutViewCard2.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
      this.layoutViewCard2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField1});
      this.layoutViewCard2.Name = "layoutViewCard1";
      this.layoutViewCard2.OptionsItemText.TextToControlDistance = 2;
      this.layoutViewCard2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
      this.layoutViewCard2.Text = "TemplateCard";
      // 
      // con_PicCode
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.gridControl2);
      this.Controls.Add(this.barDockControlRight);
      this.Controls.Add(this.barDockControlLeft);
      this.Controls.Add(this.barDockControl1);
      this.Controls.Add(this.barDockControlBottom);
      this.Controls.Add(this.barDockControlTop);
      this.Name = "con_PicCode";
      this.Size = new System.Drawing.Size(324, 458);
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BarManager1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutView2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutViewField1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard2)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
    private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcImage;
    private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
    private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
    internal DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
    internal DevExpress.XtraBars.BarManager BarManager1;
    internal DevExpress.XtraBars.Bar brMain;
    internal DevExpress.XtraBars.BarButtonItem bbiAdd;
    internal DevExpress.XtraBars.BarButtonItem bbiDelete;
    internal DevExpress.XtraBars.BarDockControl barDockControlTop;
    internal DevExpress.XtraBars.BarDockControl barDockControlBottom;
    internal DevExpress.XtraBars.BarDockControl barDockControlLeft;
    internal DevExpress.XtraBars.BarDockControl barDockControl1;
    private DevExpress.XtraGrid.GridControl gridControl2;
    private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView2;
    private DevExpress.XtraGrid.Columns.LayoutViewColumn layoutViewColumn1;
    private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
    private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField1;
    private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard2;
    private DevExpress.Utils.ImageCollection imageCollection;
  }
}

namespace Medical
{
  partial class frm_ReportBalanceSpare
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ReportBalanceSpare));
      this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ConExpandAll = new System.Windows.Forms.ToolStripMenuItem();
      this.ConCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
      this.barManager = new DevExpress.XtraBars.BarManager(this.components);
      this.barBottom = new DevExpress.XtraBars.Bar();
      this.barProgress = new DevExpress.XtraBars.BarEditItem();
      this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
      this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      this.reportCondition = new DevExpress.XtraBars.Docking.DockPanel();
      this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
      this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
      this.comboCus = new DevExpress.XtraEditors.ComboBoxEdit();
      this.txtCspare = new DevExpress.XtraEditors.TextEdit();
      this.slookupSpare = new DevExpress.XtraEditors.SearchLookUpEdit();
      this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.BTreport = new DevExpress.XtraEditors.SimpleButton();
      this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
      this.exportExcleold = new DevExpress.XtraEditors.SimpleButton();
      this.image32 = new DevExpress.Utils.ImageCollection(this.components);
      this.exportText = new DevExpress.XtraEditors.SimpleButton();
      this.exportPDF = new DevExpress.XtraEditors.SimpleButton();
      this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.Grid = new DevExpress.XtraGrid.GridControl();
      this.gvHead = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.ContextMenuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
      this.reportCondition.SuspendLayout();
      this.dockPanel1_Container.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
      this.groupControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.comboCus.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtCspare.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.slookupSpare.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
      this.groupControl4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.image32)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvHead)).BeginInit();
      this.SuspendLayout();
      // 
      // ContextMenuStrip1
      // 
      this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConExpandAll,
            this.ConCollapseAll,
            this.ToolStripMenuItem1});
      this.ContextMenuStrip1.Name = "ContextMenuStrip1";
      this.ContextMenuStrip1.Size = new System.Drawing.Size(137, 54);
      // 
      // ConExpandAll
      // 
      this.ConExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("ConExpandAll.Image")));
      this.ConExpandAll.Name = "ConExpandAll";
      this.ConExpandAll.Size = new System.Drawing.Size(136, 22);
      this.ConExpandAll.Text = "Expand All";
      this.ConExpandAll.Click += new System.EventHandler(this.ConExpandAll_Click);
      // 
      // ConCollapseAll
      // 
      this.ConCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("ConCollapseAll.Image")));
      this.ConCollapseAll.Name = "ConCollapseAll";
      this.ConCollapseAll.Size = new System.Drawing.Size(136, 22);
      this.ConCollapseAll.Text = "Collapse All";
      this.ConCollapseAll.Click += new System.EventHandler(this.ConCollapseAll_Click);
      // 
      // ToolStripMenuItem1
      // 
      this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
      this.ToolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
      // 
      // dockManager
      // 
      this.dockManager.Form = this;
      this.dockManager.MenuManager = this.barManager;
      this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.reportCondition});
      this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
      // 
      // barManager
      // 
      this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barBottom});
      this.barManager.DockControls.Add(this.barDockControlTop);
      this.barManager.DockControls.Add(this.barDockControlBottom);
      this.barManager.DockControls.Add(this.barDockControlLeft);
      this.barManager.DockControls.Add(this.barDockControlRight);
      this.barManager.DockManager = this.dockManager;
      this.barManager.Form = this;
      this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barProgress});
      this.barManager.MaxItemId = 1;
      this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMarqueeProgressBar1});
      this.barManager.StatusBar = this.barBottom;
      // 
      // barBottom
      // 
      this.barBottom.BarName = "Status bar";
      this.barBottom.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
      this.barBottom.DockCol = 0;
      this.barBottom.DockRow = 0;
      this.barBottom.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
      this.barBottom.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barProgress)});
      this.barBottom.OptionsBar.AllowQuickCustomization = false;
      this.barBottom.OptionsBar.DrawDragBorder = false;
      this.barBottom.OptionsBar.UseWholeRow = true;
      this.barBottom.Text = "Status bar";
      // 
      // barProgress
      // 
      this.barProgress.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.barProgress.Caption = "ระบบกำลังทำงาน";
      this.barProgress.Edit = this.repositoryItemMarqueeProgressBar1;
      this.barProgress.Id = 0;
      this.barProgress.Name = "barProgress";
      this.barProgress.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
      this.barProgress.Width = 100;
      // 
      // repositoryItemMarqueeProgressBar1
      // 
      this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
      // 
      // barDockControlTop
      // 
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
      this.barDockControlTop.Size = new System.Drawing.Size(920, 0);
      // 
      // barDockControlBottom
      // 
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.barDockControlBottom.Location = new System.Drawing.Point(0, 615);
      this.barDockControlBottom.Size = new System.Drawing.Size(920, 25);
      // 
      // barDockControlLeft
      // 
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
      this.barDockControlLeft.Size = new System.Drawing.Size(0, 615);
      // 
      // barDockControlRight
      // 
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.barDockControlRight.Location = new System.Drawing.Point(920, 0);
      this.barDockControlRight.Size = new System.Drawing.Size(0, 615);
      // 
      // reportCondition
      // 
      this.reportCondition.Controls.Add(this.dockPanel1_Container);
      this.reportCondition.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
      this.reportCondition.ID = new System.Guid("6e8063e8-86a3-4a0b-bfd7-ae4384b09843");
      this.reportCondition.Location = new System.Drawing.Point(0, 0);
      this.reportCondition.Name = "reportCondition";
      this.reportCondition.Options.ShowCloseButton = false;
      this.reportCondition.OriginalSize = new System.Drawing.Size(281, 200);
      this.reportCondition.Size = new System.Drawing.Size(281, 615);
      this.reportCondition.Text = "ข้อกำหนดรายงาน";
      // 
      // dockPanel1_Container
      // 
      this.dockPanel1_Container.Controls.Add(this.groupControl1);
      this.dockPanel1_Container.Controls.Add(this.groupControl4);
      this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
      this.dockPanel1_Container.Name = "dockPanel1_Container";
      this.dockPanel1_Container.Size = new System.Drawing.Size(273, 588);
      this.dockPanel1_Container.TabIndex = 0;
      // 
      // groupControl1
      // 
      this.groupControl1.Controls.Add(this.comboCus);
      this.groupControl1.Controls.Add(this.txtCspare);
      this.groupControl1.Controls.Add(this.slookupSpare);
      this.groupControl1.Controls.Add(this.BTreport);
      this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupControl1.Location = new System.Drawing.Point(0, 0);
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new System.Drawing.Size(273, 109);
      this.groupControl1.TabIndex = 0;
      this.groupControl1.Text = "การกรอง";
      // 
      // comboCus
      // 
      this.comboCus.EditValue = "ทุกรหัส spare";
      this.comboCus.Location = new System.Drawing.Point(2, 25);
      this.comboCus.Name = "comboCus";
      this.comboCus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.comboCus.Properties.Items.AddRange(new object[] {
            "ทุกรหัส spare",
            "หนึ่งรหัส spare"});
      this.comboCus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
      this.comboCus.Size = new System.Drawing.Size(100, 20);
      this.comboCus.TabIndex = 17;
      this.comboCus.SelectedIndexChanged += new System.EventHandler(this.comboCus_SelectedIndexChanged);
      // 
      // txtCspare
      // 
      this.txtCspare.Location = new System.Drawing.Point(108, 25);
      this.txtCspare.Name = "txtCspare";
      this.txtCspare.Size = new System.Drawing.Size(100, 20);
      this.txtCspare.TabIndex = 18;
      // 
      // slookupSpare
      // 
      this.slookupSpare.Location = new System.Drawing.Point(164, 25);
      this.slookupSpare.Name = "slookupSpare";
      this.slookupSpare.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.slookupSpare.Properties.View = this.gridView2;
      this.slookupSpare.Size = new System.Drawing.Size(100, 20);
      this.slookupSpare.TabIndex = 19;
      // 
      // gridView2
      // 
      this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gridView2.Name = "gridView2";
      this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridView2.OptionsView.ShowGroupPanel = false;
      // 
      // BTreport
      // 
      this.BTreport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.BTreport.Image = ((System.Drawing.Image)(resources.GetObject("BTreport.Image")));
      this.BTreport.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
      this.BTreport.Location = new System.Drawing.Point(194, 54);
      this.BTreport.Name = "BTreport";
      this.BTreport.Size = new System.Drawing.Size(70, 50);
      this.BTreport.TabIndex = 6;
      this.BTreport.Text = "เรียกรายงาน";
      this.BTreport.Click += new System.EventHandler(this.BTreport_Click);
      // 
      // groupControl4
      // 
      this.groupControl4.Controls.Add(this.exportExcleold);
      this.groupControl4.Controls.Add(this.exportText);
      this.groupControl4.Controls.Add(this.exportPDF);
      this.groupControl4.Location = new System.Drawing.Point(2, 115);
      this.groupControl4.Name = "groupControl4";
      this.groupControl4.Size = new System.Drawing.Size(273, 156);
      this.groupControl4.TabIndex = 7;
      this.groupControl4.Text = "โอนออกข้อมูล";
      // 
      // exportExcleold
      // 
      this.exportExcleold.ImageIndex = 1;
      this.exportExcleold.ImageList = this.image32;
      this.exportExcleold.Location = new System.Drawing.Point(5, 25);
      this.exportExcleold.Name = "exportExcleold";
      this.exportExcleold.Size = new System.Drawing.Size(257, 39);
      this.exportExcleold.TabIndex = 4;
      this.exportExcleold.Text = "โอนออก Excel ";
      this.exportExcleold.Click += new System.EventHandler(this.exportExcleold_Click);
      // 
      // image32
      // 
      this.image32.ImageSize = new System.Drawing.Size(32, 32);
      this.image32.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("image32.ImageStream")));
      this.image32.Images.SetKeyName(0, "export_data.png");
      this.image32.Images.SetKeyName(1, "export_excel.png");
      this.image32.Images.SetKeyName(2, "export_pdf.png");
      this.image32.Images.SetKeyName(3, "export_text.png");
      // 
      // exportText
      // 
      this.exportText.ImageIndex = 3;
      this.exportText.ImageList = this.image32;
      this.exportText.Location = new System.Drawing.Point(5, 70);
      this.exportText.Name = "exportText";
      this.exportText.Size = new System.Drawing.Size(122, 39);
      this.exportText.TabIndex = 3;
      this.exportText.Text = "โอนออก Text";
      this.exportText.Click += new System.EventHandler(this.exportText_Click_1);
      // 
      // exportPDF
      // 
      this.exportPDF.ImageIndex = 2;
      this.exportPDF.ImageList = this.image32;
      this.exportPDF.Location = new System.Drawing.Point(140, 70);
      this.exportPDF.Name = "exportPDF";
      this.exportPDF.Size = new System.Drawing.Size(122, 39);
      this.exportPDF.TabIndex = 1;
      this.exportPDF.Text = "โอนออก PDF";
      this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click_1);
      // 
      // gvList
      // 
      this.gvList.GridControl = this.Grid;
      this.gvList.Name = "gvList";
      // 
      // Grid
      // 
      this.Grid.ContextMenuStrip = this.ContextMenuStrip1;
      this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Grid.Location = new System.Drawing.Point(281, 0);
      this.Grid.MainView = this.gvHead;
      this.Grid.Name = "Grid";
      this.Grid.Size = new System.Drawing.Size(639, 615);
      this.Grid.TabIndex = 8;
      this.Grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHead,
            this.gvList});
      // 
      // gvHead
      // 
      this.gvHead.GridControl = this.Grid;
      this.gvHead.Name = "gvHead";
      // 
      // frm_ReportBalanceSpare
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(920, 640);
      this.Controls.Add(this.Grid);
      this.Controls.Add(this.reportCondition);
      this.Controls.Add(this.barDockControlLeft);
      this.Controls.Add(this.barDockControlRight);
      this.Controls.Add(this.barDockControlBottom);
      this.Controls.Add(this.barDockControlTop);
      this.Name = "frm_ReportBalanceSpare";
      this.Text = "รายงานสินค้าคงเหลือ Spare part";
      this.ContextMenuStrip1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
      this.reportCondition.ResumeLayout(false);
      this.dockPanel1_Container.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
      this.groupControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.comboCus.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtCspare.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.slookupSpare.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
      this.groupControl4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.image32)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvHead)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraBars.Docking.DockManager dockManager;
    private DevExpress.XtraBars.Docking.DockPanel reportCondition;
    private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
    private DevExpress.XtraEditors.GroupControl groupControl1;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarManager barManager;
    private DevExpress.XtraBars.Bar barBottom;
    private DevExpress.XtraBars.BarEditItem barProgress;
    private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
    private DevExpress.XtraEditors.SimpleButton BTreport;
    private DevExpress.Utils.ImageCollection image32;
    private DevExpress.XtraEditors.ComboBoxEdit comboCus;
    private DevExpress.XtraEditors.TextEdit txtCspare;
    private DevExpress.XtraEditors.SearchLookUpEdit slookupSpare;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
    internal System.Windows.Forms.ToolStripMenuItem ConExpandAll;
    internal System.Windows.Forms.ToolStripMenuItem ConCollapseAll;
    internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
    private DevExpress.XtraEditors.GroupControl groupControl4;
    private DevExpress.XtraEditors.SimpleButton exportExcleold;
    private DevExpress.XtraEditors.SimpleButton exportText;
    private DevExpress.XtraEditors.SimpleButton exportPDF;
    private DevExpress.XtraGrid.GridControl Grid;
    private DevExpress.XtraGrid.Views.Grid.GridView gvHead;
    private DevExpress.XtraGrid.Views.Grid.GridView gvList;

  }
}
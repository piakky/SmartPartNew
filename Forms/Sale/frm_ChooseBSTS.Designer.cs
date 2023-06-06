namespace SmartPart.Forms.Sale
{
  partial class frm_ChooseBSTS
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChooseBSTS));
            this.gvBS_L = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Lcol00 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lcol01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lcol1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lcol2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lcol3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lcol4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoBrand = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Lcol5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lcol6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoUnit = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Lcol7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lcol8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridBS = new DevExpress.XtraGrid.GridControl();
            this.gvBS_H = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Hcol1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Hcol2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Hcol3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Hcol4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Hcol5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
            this.cmdClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvBS_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBS_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvBS_L
            // 
            this.gvBS_L.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvBS_L.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvBS_L.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvBS_L.Appearance.Row.Options.UseFont = true;
            this.gvBS_L.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Lcol00,
            this.Lcol01,
            this.Lcol1,
            this.Lcol2,
            this.Lcol3,
            this.Lcol4,
            this.Lcol5,
            this.Lcol6,
            this.Lcol7,
            this.Lcol8});
            this.gvBS_L.GridControl = this.gridBS;
            this.gvBS_L.Name = "gvBS_L";
            this.gvBS_L.OptionsBehavior.Editable = false;
            this.gvBS_L.OptionsView.EnableAppearanceEvenRow = true;
            this.gvBS_L.OptionsView.ShowGroupPanel = false;
            this.gvBS_L.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvBS_L_FocusedRowChanged);
            // 
            // Lcol00
            // 
            this.Lcol00.FieldName = "BSD_PID";
            this.Lcol00.Name = "Lcol00";
            // 
            // Lcol01
            // 
            this.Lcol01.FieldName = "BSD_ID";
            this.Lcol01.Name = "Lcol01";
            // 
            // Lcol1
            // 
            this.Lcol1.AppearanceHeader.Options.UseTextOptions = true;
            this.Lcol1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Lcol1.Caption = "รหัสชื่อสินค้า";
            this.Lcol1.FieldName = "ITEM_CODE";
            this.Lcol1.Name = "Lcol1";
            this.Lcol1.Visible = true;
            this.Lcol1.VisibleIndex = 0;
            // 
            // Lcol2
            // 
            this.Lcol2.AppearanceHeader.Options.UseTextOptions = true;
            this.Lcol2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Lcol2.Caption = "ชื่อสินค้า";
            this.Lcol2.FieldName = "FULL_NAME";
            this.Lcol2.Name = "Lcol2";
            this.Lcol2.Visible = true;
            this.Lcol2.VisibleIndex = 1;
            // 
            // Lcol3
            // 
            this.Lcol3.AppearanceHeader.Options.UseTextOptions = true;
            this.Lcol3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Lcol3.Caption = "รุ่น 1";
            this.Lcol3.FieldName = "MODEL1";
            this.Lcol3.Name = "Lcol3";
            this.Lcol3.Visible = true;
            this.Lcol3.VisibleIndex = 2;
            // 
            // Lcol4
            // 
            this.Lcol4.AppearanceHeader.Options.UseTextOptions = true;
            this.Lcol4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Lcol4.Caption = "ยี่ห้อ";
            this.Lcol4.ColumnEdit = this.repoBrand;
            this.Lcol4.FieldName = "BRAND_ID";
            this.Lcol4.Name = "Lcol4";
            this.Lcol4.Visible = true;
            this.Lcol4.VisibleIndex = 3;
            // 
            // repoBrand
            // 
            this.repoBrand.AutoHeight = false;
            this.repoBrand.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoBrand.Name = "repoBrand";
            this.repoBrand.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Lcol5
            // 
            this.Lcol5.AppearanceHeader.Options.UseTextOptions = true;
            this.Lcol5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Lcol5.Caption = "ปริมาณ";
            this.Lcol5.FieldName = "QTY";
            this.Lcol5.Name = "Lcol5";
            this.Lcol5.Visible = true;
            this.Lcol5.VisibleIndex = 4;
            // 
            // Lcol6
            // 
            this.Lcol6.AppearanceHeader.Options.UseTextOptions = true;
            this.Lcol6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Lcol6.Caption = "หน่วยนับ";
            this.Lcol6.ColumnEdit = this.repoUnit;
            this.Lcol6.FieldName = "UNIT_ID";
            this.Lcol6.Name = "Lcol6";
            this.Lcol6.Visible = true;
            this.Lcol6.VisibleIndex = 5;
            // 
            // repoUnit
            // 
            this.repoUnit.AutoHeight = false;
            this.repoUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoUnit.Name = "repoUnit";
            this.repoUnit.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // Lcol7
            // 
            this.Lcol7.AppearanceHeader.Options.UseTextOptions = true;
            this.Lcol7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Lcol7.Caption = "ราคาต่อหน่วย";
            this.Lcol7.DisplayFormat.FormatString = "N2";
            this.Lcol7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Lcol7.FieldName = "UPRICE";
            this.Lcol7.Name = "Lcol7";
            this.Lcol7.Visible = true;
            this.Lcol7.VisibleIndex = 6;
            // 
            // Lcol8
            // 
            this.Lcol8.AppearanceHeader.Options.UseTextOptions = true;
            this.Lcol8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Lcol8.Caption = "รวมเงิน";
            this.Lcol8.DisplayFormat.FormatString = "N2";
            this.Lcol8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Lcol8.FieldName = "COG";
            this.Lcol8.Name = "Lcol8";
            this.Lcol8.Visible = true;
            this.Lcol8.VisibleIndex = 7;
            // 
            // gridBS
            // 
            this.gridBS.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gvBS_L;
            gridLevelNode1.RelationName = "Level1";
            this.gridBS.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridBS.Location = new System.Drawing.Point(0, 47);
            this.gridBS.MainView = this.gvBS_H;
            this.gridBS.Name = "gridBS";
            this.gridBS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoUnit,
            this.repoBrand});
            this.gridBS.Size = new System.Drawing.Size(796, 377);
            this.gridBS.TabIndex = 43;
            this.gridBS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBS_H,
            this.gvBS_L});
            // 
            // gvBS_H
            // 
            this.gvBS_H.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvBS_H.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvBS_H.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvBS_H.Appearance.Row.Options.UseFont = true;
            this.gvBS_H.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col0,
            this.Hcol1,
            this.Hcol2,
            this.Hcol3,
            this.Hcol4,
            this.Hcol5});
            this.gvBS_H.GridControl = this.gridBS;
            this.gvBS_H.IndicatorWidth = 30;
            this.gvBS_H.Name = "gvBS_H";
            this.gvBS_H.OptionsBehavior.Editable = false;
            this.gvBS_H.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvBS_H.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvBS_H.OptionsView.EnableAppearanceEvenRow = true;
            this.gvBS_H.OptionsView.ShowGroupPanel = false;
            this.gvBS_H.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvBS_CustomDrawRowIndicator);
            // 
            // col0
            // 
            this.col0.Caption = "gridColumn1";
            this.col0.Name = "col0";
            // 
            // Hcol1
            // 
            this.Hcol1.AppearanceHeader.Options.UseTextOptions = true;
            this.Hcol1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Hcol1.Caption = "เลขที่บิลขาย";
            this.Hcol1.FieldName = "BSH_NO";
            this.Hcol1.Name = "Hcol1";
            this.Hcol1.Visible = true;
            this.Hcol1.VisibleIndex = 0;
            // 
            // Hcol2
            // 
            this.Hcol2.AppearanceCell.Options.UseTextOptions = true;
            this.Hcol2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Hcol2.AppearanceHeader.Options.UseTextOptions = true;
            this.Hcol2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Hcol2.Caption = "วันที่เอกสาร";
            this.Hcol2.FieldName = "BSH_DATE";
            this.Hcol2.Name = "Hcol2";
            this.Hcol2.Visible = true;
            this.Hcol2.VisibleIndex = 1;
            // 
            // Hcol3
            // 
            this.Hcol3.AppearanceCell.Options.UseTextOptions = true;
            this.Hcol3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Hcol3.AppearanceHeader.Options.UseTextOptions = true;
            this.Hcol3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Hcol3.Caption = "ยอดเงิน";
            this.Hcol3.DisplayFormat.FormatString = "N2";
            this.Hcol3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Hcol3.FieldName = "SUMCOG";
            this.Hcol3.Name = "Hcol3";
            this.Hcol3.Visible = true;
            this.Hcol3.VisibleIndex = 2;
            // 
            // Hcol4
            // 
            this.Hcol4.AppearanceCell.Options.UseTextOptions = true;
            this.Hcol4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Hcol4.AppearanceHeader.Options.UseTextOptions = true;
            this.Hcol4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Hcol4.Caption = "ภาษี";
            this.Hcol4.DisplayFormat.FormatString = "N2";
            this.Hcol4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Hcol4.FieldName = "VATSUM";
            this.Hcol4.Name = "Hcol4";
            this.Hcol4.Visible = true;
            this.Hcol4.VisibleIndex = 3;
            // 
            // Hcol5
            // 
            this.Hcol5.AppearanceCell.Options.UseTextOptions = true;
            this.Hcol5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Hcol5.AppearanceHeader.Options.UseTextOptions = true;
            this.Hcol5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Hcol5.Caption = "ยอดรวม";
            this.Hcol5.DisplayFormat.FormatString = "N2";
            this.Hcol5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Hcol5.FieldName = "NETSUM";
            this.Hcol5.Name = "Hcol5";
            this.Hcol5.Visible = true;
            this.Hcol5.VisibleIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmdOK);
            this.panelControl1.Controls.Add(this.cmdClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(796, 47);
            this.panelControl1.TabIndex = 42;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmdOK.Appearance.Options.UseFont = true;
            this.cmdOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cmdOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.ImageOptions.Image")));
            this.cmdOK.Location = new System.Drawing.Point(581, 5);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(122, 36);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "Select (F2)";
            this.cmdOK.ToolTip = "Select = F2";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmdClose.Appearance.Options.UseFont = true;
            this.cmdClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cmdClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.ImageOptions.Image")));
            this.cmdClose.Location = new System.Drawing.Point(711, 5);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(80, 36);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "Close";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frm_ChooseBSTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 424);
            this.Controls.Add(this.gridBS);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChooseBSTS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "รายการบิลขาย";
            this.Load += new System.EventHandler(this.frm_ChooseBSTS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ChooseBSTS_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvBS_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBS_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton cmdOK;
    private DevExpress.XtraEditors.SimpleButton cmdClose;
    private DevExpress.XtraGrid.GridControl gridBS;
    private DevExpress.XtraGrid.Views.Grid.GridView gvBS_H;
    private DevExpress.XtraGrid.Columns.GridColumn col0;
    private DevExpress.XtraGrid.Columns.GridColumn Hcol1;
    private DevExpress.XtraGrid.Columns.GridColumn Hcol2;
    private DevExpress.XtraGrid.Columns.GridColumn Hcol3;
    private DevExpress.XtraGrid.Columns.GridColumn Hcol4;
    private DevExpress.XtraGrid.Columns.GridColumn Hcol5;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBS_L;
        private DevExpress.XtraGrid.Columns.GridColumn Lcol1;
        private DevExpress.XtraGrid.Columns.GridColumn Lcol2;
        private DevExpress.XtraGrid.Columns.GridColumn Lcol3;
        private DevExpress.XtraGrid.Columns.GridColumn Lcol4;
        private DevExpress.XtraGrid.Columns.GridColumn Lcol5;
        private DevExpress.XtraGrid.Columns.GridColumn Lcol6;
        private DevExpress.XtraGrid.Columns.GridColumn Lcol7;
        private DevExpress.XtraGrid.Columns.GridColumn Lcol8;
        private DevExpress.XtraGrid.Columns.GridColumn Lcol01;
        private DevExpress.XtraGrid.Columns.GridColumn Lcol00;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repoUnit;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repoBrand;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
namespace SmartPart.Forms.Code
{
    partial class frm_PriceList_List
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
            this.gridPriceList = new DevExpress.XtraGrid.GridControl();
            this.gvPriceList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.r_Set = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.r_Component = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bwCode = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gridPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Component)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPriceList
            // 
            this.gridPriceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPriceList.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridPriceList.Location = new System.Drawing.Point(0, 0);
            this.gridPriceList.MainView = this.gvPriceList;
            this.gridPriceList.Name = "gridPriceList";
            this.gridPriceList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.r_Set,
            this.r_Component});
            this.gridPriceList.Size = new System.Drawing.Size(1370, 417);
            this.gridPriceList.TabIndex = 14;
            this.gridPriceList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPriceList});
            // 
            // gvPriceList
            // 
            this.gvPriceList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col7,
            this.col8,
            this.col9,
            this.col10,
            this.col11,
            this.col12});
            this.gvPriceList.GridControl = this.gridPriceList;
            this.gvPriceList.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.gvPriceList.IndicatorWidth = 50;
            this.gvPriceList.Name = "gvPriceList";
            this.gvPriceList.OptionsBehavior.Editable = false;
            this.gvPriceList.OptionsFind.AlwaysVisible = true;
            this.gvPriceList.OptionsFind.ShowFindButton = false;
            this.gvPriceList.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPriceList.OptionsView.ShowAutoFilterRow = true;
            this.gvPriceList.OptionsView.ShowFooter = true;
            this.gvPriceList.OptionsView.ShowGroupPanel = false;
            this.gvPriceList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPriceList_CustomDrawRowIndicator);
            // 
            // colID
            // 
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // col1
            // 
            this.col1.Caption = "หมายอะไหล่พ่อค้า";
            this.col1.FieldName = "BRAND_PART_ID";
            this.col1.Name = "col1";
            this.col1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ABBREVIATE_NAME", "จำนวนรายการ = {0}")});
            this.col1.Visible = true;
            this.col1.VisibleIndex = 0;
            this.col1.Width = 120;
            // 
            // col2
            // 
            this.col2.Caption = "หมายเลขอะไหล่ร้าน";
            this.col2.FieldName = "GENUIN_PART_ID";
            this.col2.Name = "col2";
            this.col2.Visible = true;
            this.col2.VisibleIndex = 1;
            this.col2.Width = 120;
            // 
            // col3
            // 
            this.col3.Caption = "รายละเอียด";
            this.col3.FieldName = "FULL_NAME";
            this.col3.Name = "col3";
            this.col3.Visible = true;
            this.col3.VisibleIndex = 2;
            this.col3.Width = 200;
            // 
            // col4
            // 
            this.col4.Caption = "รุ่น";
            this.col4.FieldName = "MODEL";
            this.col4.Name = "col4";
            this.col4.Visible = true;
            this.col4.VisibleIndex = 3;
            this.col4.Width = 114;
            // 
            // col5
            // 
            this.col5.Caption = "ราคาใหม่";
            this.col5.FieldName = "NEW_PRICE";
            this.col5.Name = "col5";
            this.col5.Visible = true;
            this.col5.VisibleIndex = 4;
            this.col5.Width = 114;
            // 
            // col6
            // 
            this.col6.Caption = "วันที่ราคาใหม่";
            this.col6.FieldName = "NEW_DATE";
            this.col6.Name = "col6";
            this.col6.Visible = true;
            this.col6.VisibleIndex = 5;
            this.col6.Width = 114;
            // 
            // col7
            // 
            this.col7.Caption = "ราคาครั้งที่ 1";
            this.col7.FieldName = "PRICE1";
            this.col7.Name = "col7";
            this.col7.Visible = true;
            this.col7.VisibleIndex = 6;
            this.col7.Width = 114;
            // 
            // col8
            // 
            this.col8.Caption = "วันที่ราคามีผลครั้งที่ 1";
            this.col8.FieldName = "DATE1";
            this.col8.Name = "col8";
            this.col8.Visible = true;
            this.col8.VisibleIndex = 7;
            this.col8.Width = 130;
            // 
            // col9
            // 
            this.col9.Caption = "ราคาครั้งที่ 2";
            this.col9.FieldName = "PRICE2";
            this.col9.Name = "col9";
            this.col9.Visible = true;
            this.col9.VisibleIndex = 8;
            this.col9.Width = 109;
            // 
            // col10
            // 
            this.col10.Caption = "วันที่ราคามีผลครั้งที่ 2";
            this.col10.FieldName = "DATE2";
            this.col10.Name = "col10";
            this.col10.Visible = true;
            this.col10.VisibleIndex = 9;
            this.col10.Width = 130;
            // 
            // col11
            // 
            this.col11.Caption = "ราคาครั้งที่ 3";
            this.col11.FieldName = "PRICE3";
            this.col11.Name = "col11";
            this.col11.Visible = true;
            this.col11.VisibleIndex = 10;
            this.col11.Width = 99;
            // 
            // col12
            // 
            this.col12.Caption = "วันที่ราคามีผลครั้งที่ 3";
            this.col12.FieldName = "DATE3";
            this.col12.Name = "col12";
            this.col12.Visible = true;
            this.col12.VisibleIndex = 11;
            this.col12.Width = 146;
            // 
            // r_Set
            // 
            this.r_Set.AutoHeight = false;
            this.r_Set.Name = "r_Set";
            this.r_Set.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // r_Component
            // 
            this.r_Component.AutoHeight = false;
            this.r_Component.Name = "r_Component";
            this.r_Component.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // bwCode
            // 
            this.bwCode.WorkerReportsProgress = true;
            this.bwCode.WorkerSupportsCancellation = true;
            this.bwCode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCode_DoWork);
            this.bwCode.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCode_RunWorkerCompleted);
            // 
            // frm_PriceList_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 417);
            this.Controls.Add(this.gridPriceList);
            this.Name = "frm_PriceList_List";
            this.Tag = "1001";
            this.Text = "Price List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Product_List_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_Component)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridPriceList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPriceList;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private System.ComponentModel.BackgroundWorker bwCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Set;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Component;
    private DevExpress.XtraGrid.Columns.GridColumn col3;
    private DevExpress.XtraGrid.Columns.GridColumn col4;
    private DevExpress.XtraGrid.Columns.GridColumn col5;
    private DevExpress.XtraGrid.Columns.GridColumn col6;
    private DevExpress.XtraGrid.Columns.GridColumn col7;
    private DevExpress.XtraGrid.Columns.GridColumn col8;
    private DevExpress.XtraGrid.Columns.GridColumn col9;
    private DevExpress.XtraGrid.Columns.GridColumn col10;
    private DevExpress.XtraGrid.Columns.GridColumn col11;
    private DevExpress.XtraGrid.Columns.GridColumn col12;
  }
}
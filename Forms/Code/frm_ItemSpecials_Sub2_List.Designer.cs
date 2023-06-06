namespace SmartPart.Forms.Code
{
    partial class frm_ItemSpecials_Sub2_List
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
      this.gridSub1 = new DevExpress.XtraGrid.GridControl();
      this.gvSub1 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.r_Set = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.r_Component = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.bwCode = new System.ComponentModel.BackgroundWorker();
      this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col5 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col6 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col7 = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.gridSub1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvSub1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Set)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Component)).BeginInit();
      this.SuspendLayout();
      // 
      // gridSub1
      // 
      this.gridSub1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridSub1.Font = new System.Drawing.Font("Tahoma", 10F);
      this.gridSub1.Location = new System.Drawing.Point(0, 0);
      this.gridSub1.MainView = this.gvSub1;
      this.gridSub1.Name = "gridSub1";
      this.gridSub1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.r_Set,
            this.r_Component});
      this.gridSub1.Size = new System.Drawing.Size(931, 417);
      this.gridSub1.TabIndex = 14;
      this.gridSub1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSub1});
      // 
      // gvSub1
      // 
      this.gvSub1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col7});
      this.gvSub1.GridControl = this.gridSub1;
      this.gvSub1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
      this.gvSub1.IndicatorWidth = 50;
      this.gvSub1.Name = "gvSub1";
      this.gvSub1.OptionsBehavior.Editable = false;
      this.gvSub1.OptionsFind.AlwaysVisible = true;
      this.gvSub1.OptionsFind.ShowFindButton = false;
      this.gvSub1.OptionsView.EnableAppearanceEvenRow = true;
      this.gvSub1.OptionsView.ShowAutoFilterRow = true;
      this.gvSub1.OptionsView.ShowFooter = true;
      this.gvSub1.OptionsView.ShowGroupPanel = false;
      this.gvSub1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPDT_CustomDrawRowIndicator);
      // 
      // colID
      // 
      this.colID.Name = "colID";
      this.colID.OptionsColumn.ShowInCustomizationForm = false;
      // 
      // col1
      // 
      this.col1.Caption = "รหัสกลุ่มย่อยระดับที่ 2";
      this.col1.FieldName = "SUB_CODE";
      this.col1.Name = "col1";
      this.col1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "SUB_CODE", "จำนวนรายการ = {0}")});
      this.col1.Visible = true;
      this.col1.VisibleIndex = 0;
      this.col1.Width = 130;
      // 
      // col2
      // 
      this.col2.Caption = "ชื่อกลุ่มย่อยระดับที่ 2";
      this.col2.FieldName = "SUB_NAME";
      this.col2.Name = "col2";
      this.col2.Visible = true;
      this.col2.VisibleIndex = 1;
      this.col2.Width = 141;
      // 
      // col3
      // 
      this.col3.Caption = "รายละเอียดข้อมูลชุดที่ 1";
      this.col3.FieldName = "SUB_DESCRIPTION1";
      this.col3.Name = "col3";
      this.col3.Visible = true;
      this.col3.VisibleIndex = 2;
      this.col3.Width = 151;
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
      // col4
      // 
      this.col4.Caption = "รายละเอียดข้อมูลชุดที่ 2";
      this.col4.FieldName = "SUB_DESCRIPTION2";
      this.col4.Name = "col4";
      this.col4.Visible = true;
      this.col4.VisibleIndex = 3;
      this.col4.Width = 145;
      // 
      // col5
      // 
      this.col5.Caption = "รายละเอียดข้อมูลชุดที่ 3";
      this.col5.FieldName = "SUB_DESCRIPTION3";
      this.col5.Name = "col5";
      this.col5.Visible = true;
      this.col5.VisibleIndex = 4;
      this.col5.Width = 140;
      // 
      // col6
      // 
      this.col6.Caption = "รหัสกลุ่มย่อยระดับ ที่ 1 ";
      this.col6.FieldName = "SUB1_CODE";
      this.col6.Name = "col6";
      this.col6.Visible = true;
      this.col6.VisibleIndex = 5;
      this.col6.Width = 130;
      // 
      // col7
      // 
      this.col7.Caption = "ชื่อกลุ่มย่อยระดับ ที่ 1 ";
      this.col7.FieldName = "SUB1_NAME";
      this.col7.Name = "col7";
      this.col7.Visible = true;
      this.col7.VisibleIndex = 6;
      this.col7.Width = 151;
      // 
      // frm_ItemSpecials_Sub2_List
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(931, 417);
      this.Controls.Add(this.gridSub1);
      this.Name = "frm_ItemSpecials_Sub2_List";
      this.Tag = "1001";
      this.Text = "สินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 2";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Product_List_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.gridSub1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvSub1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Set)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Component)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridSub1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSub1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private DevExpress.XtraGrid.Columns.GridColumn col3;
        private System.ComponentModel.BackgroundWorker bwCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Set;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Component;
    private DevExpress.XtraGrid.Columns.GridColumn col4;
    private DevExpress.XtraGrid.Columns.GridColumn col5;
    private DevExpress.XtraGrid.Columns.GridColumn col6;
    private DevExpress.XtraGrid.Columns.GridColumn col7;
  }
}
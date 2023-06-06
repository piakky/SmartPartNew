namespace SmartPart.Forms.Code
{
    partial class frm_Complementarys_Sub1_List
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
            this.col3});
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
      this.col1.Caption = "รหัสกลุ่มสินค้าเฉพาะใช้ด้วยกัน 1";
      this.col1.FieldName = "SUB_CODE";
      this.col1.Name = "col1";
      this.col1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "SUB_CODE", "จำนวนรายการ = {0}")});
      this.col1.Visible = true;
      this.col1.VisibleIndex = 0;
      this.col1.Width = 100;
      // 
      // col2
      // 
      this.col2.Caption = "ชื่อกลุ่มสินค้าหลัก";
      this.col2.FieldName = "SUB_NAME";
      this.col2.Name = "col2";
      this.col2.Visible = true;
      this.col2.VisibleIndex = 1;
      this.col2.Width = 150;
      // 
      // col3
      // 
      this.col3.Caption = "รายละเอียด";
      this.col3.FieldName = "SUB_DESCRIPTION";
      this.col3.Name = "col3";
      this.col3.Visible = true;
      this.col3.VisibleIndex = 2;
      this.col3.Width = 150;
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
      // frm_Complementarys_Sub1_List
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(931, 417);
      this.Controls.Add(this.gridSub1);
      this.Name = "frm_Complementarys_Sub1_List";
      this.Tag = "1001";
      this.Text = "กลุ่มสินค้าเฉพาะใช้ด้วยกัน 1";
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
  }
}
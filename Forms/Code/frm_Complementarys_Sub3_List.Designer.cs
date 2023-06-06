namespace SmartPart.Forms.Code
{
    partial class frm_Complementarys_Sub3_List
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
      this.gridSub3 = new DevExpress.XtraGrid.GridControl();
      this.gvSub3 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.r_Set = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.r_Component = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.bwCode = new System.ComponentModel.BackgroundWorker();
      ((System.ComponentModel.ISupportInitialize)(this.gridSub3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvSub3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Set)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Component)).BeginInit();
      this.SuspendLayout();
      // 
      // gridSub3
      // 
      this.gridSub3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridSub3.Font = new System.Drawing.Font("Tahoma", 10F);
      this.gridSub3.Location = new System.Drawing.Point(0, 0);
      this.gridSub3.MainView = this.gvSub3;
      this.gridSub3.Name = "gridSub3";
      this.gridSub3.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.r_Set,
            this.r_Component});
      this.gridSub3.Size = new System.Drawing.Size(931, 417);
      this.gridSub3.TabIndex = 14;
      this.gridSub3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSub3});
      // 
      // gvSub3
      // 
      this.gvSub3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.col1,
            this.col2,
            this.col3});
      this.gvSub3.GridControl = this.gridSub3;
      this.gvSub3.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
      this.gvSub3.IndicatorWidth = 50;
      this.gvSub3.Name = "gvSub3";
      this.gvSub3.OptionsBehavior.Editable = false;
      this.gvSub3.OptionsFind.AlwaysVisible = true;
      this.gvSub3.OptionsFind.ShowFindButton = false;
      this.gvSub3.OptionsView.EnableAppearanceEvenRow = true;
      this.gvSub3.OptionsView.ShowAutoFilterRow = true;
      this.gvSub3.OptionsView.ShowFooter = true;
      this.gvSub3.OptionsView.ShowGroupPanel = false;
      this.gvSub3.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPDT_CustomDrawRowIndicator);
      // 
      // colID
      // 
      this.colID.Name = "colID";
      this.colID.OptionsColumn.ShowInCustomizationForm = false;
      // 
      // col1
      // 
      this.col1.Caption = "รหัสกลุ่มสินค้าเฉพาะใช้ด้วยกัน 3";
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
      this.col2.Caption = "ขนาด/รุ่น";
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
      // frm_Complementarys_Sub3_List
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(931, 417);
      this.Controls.Add(this.gridSub3);
      this.Name = "frm_Complementarys_Sub3_List";
      this.Tag = "1001";
      this.Text = "กลุ่มสินค้าเฉพาะใช้ด้วยกัน 3";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Product_List_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.gridSub3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvSub3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Set)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Component)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridSub3;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSub3;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private DevExpress.XtraGrid.Columns.GridColumn col3;
        private System.ComponentModel.BackgroundWorker bwCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Set;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Component;
  }
}
namespace SmartPart.Forms.Code
{
    partial class frm_Personals_List
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
      this.gridEmployee = new DevExpress.XtraGrid.GridControl();
      this.gvEmployee = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col5 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col6 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.r_Set = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.r_Component = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.bwCode = new System.ComponentModel.BackgroundWorker();
      ((System.ComponentModel.ISupportInitialize)(this.gridEmployee)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvEmployee)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Set)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Component)).BeginInit();
      this.SuspendLayout();
      // 
      // gridEmployee
      // 
      this.gridEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridEmployee.Font = new System.Drawing.Font("Tahoma", 10F);
      this.gridEmployee.Location = new System.Drawing.Point(0, 0);
      this.gridEmployee.MainView = this.gvEmployee;
      this.gridEmployee.Name = "gridEmployee";
      this.gridEmployee.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.r_Set,
            this.r_Component});
      this.gridEmployee.Size = new System.Drawing.Size(931, 417);
      this.gridEmployee.TabIndex = 14;
      this.gridEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEmployee});
      // 
      // gvEmployee
      // 
      this.gvEmployee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6});
      this.gvEmployee.GridControl = this.gridEmployee;
      this.gvEmployee.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
      this.gvEmployee.IndicatorWidth = 50;
      this.gvEmployee.Name = "gvEmployee";
      this.gvEmployee.OptionsBehavior.Editable = false;
      this.gvEmployee.OptionsFind.AlwaysVisible = true;
      this.gvEmployee.OptionsFind.ShowFindButton = false;
      this.gvEmployee.OptionsView.EnableAppearanceEvenRow = true;
      this.gvEmployee.OptionsView.ShowAutoFilterRow = true;
      this.gvEmployee.OptionsView.ShowFooter = true;
      this.gvEmployee.OptionsView.ShowGroupPanel = false;
      this.gvEmployee.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPDT_CustomDrawRowIndicator);
      // 
      // colID
      // 
      this.colID.Name = "colID";
      this.colID.OptionsColumn.ShowInCustomizationForm = false;
      // 
      // col1
      // 
      this.col1.Caption = "รหัส";
      this.col1.FieldName = "PERSONAL_CODE";
      this.col1.Name = "col1";
      this.col1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PERSONAL_CODE", "จำนวนรายการ = {0}")});
      this.col1.Visible = true;
      this.col1.VisibleIndex = 0;
      this.col1.Width = 118;
      // 
      // col2
      // 
      this.col2.Caption = "ชื่อ";
      this.col2.FieldName = "PERSONAL_NAME";
      this.col2.Name = "col2";
      this.col2.Visible = true;
      this.col2.VisibleIndex = 1;
      this.col2.Width = 148;
      // 
      // col3
      // 
      this.col3.Caption = "รายละเอียด 1";
      this.col3.FieldName = "PERSONAL_DESCRIPTION1";
      this.col3.Name = "col3";
      this.col3.Visible = true;
      this.col3.VisibleIndex = 2;
      this.col3.Width = 197;
      // 
      // col4
      // 
      this.col4.Caption = "รายละเอียด 2";
      this.col4.FieldName = "PERSONAL_DESCRIPTION2";
      this.col4.Name = "col4";
      this.col4.Visible = true;
      this.col4.VisibleIndex = 3;
      this.col4.Width = 197;
      // 
      // col5
      // 
      this.col5.Caption = "รายละเอียด 3";
      this.col5.FieldName = "PERSONAL_DESCRIPTION3";
      this.col5.Name = "col5";
      this.col5.Visible = true;
      this.col5.VisibleIndex = 4;
      this.col5.Width = 197;
      // 
      // col6
      // 
      this.col6.Caption = "หมายเหตุ";
      this.col6.FieldName = "PERSONAL_NOTE";
      this.col6.Name = "col6";
      this.col6.Visible = true;
      this.col6.VisibleIndex = 5;
      this.col6.Width = 200;
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
      // frm_Personals_List
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(931, 417);
      this.Controls.Add(this.gridEmployee);
      this.Name = "frm_Personals_List";
      this.Tag = "1001";
      this.Text = "พนักงาน";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Product_List_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.gridEmployee)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvEmployee)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Set)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Component)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEmployee;
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
  }
}
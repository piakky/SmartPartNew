namespace SmartPart.Forms.Code
{
    partial class frm_Contacts_List
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
      this.gridContact = new DevExpress.XtraGrid.GridControl();
      this.gvContact = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.r_Set = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.r_Component = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.bwCode = new System.ComponentModel.BackgroundWorker();
      ((System.ComponentModel.ISupportInitialize)(this.gridContact)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvContact)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Set)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Component)).BeginInit();
      this.SuspendLayout();
      // 
      // gridContact
      // 
      this.gridContact.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridContact.Font = new System.Drawing.Font("Tahoma", 10F);
      this.gridContact.Location = new System.Drawing.Point(0, 0);
      this.gridContact.MainView = this.gvContact;
      this.gridContact.Name = "gridContact";
      this.gridContact.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.r_Set,
            this.r_Component});
      this.gridContact.Size = new System.Drawing.Size(931, 417);
      this.gridContact.TabIndex = 14;
      this.gridContact.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvContact});
      // 
      // gvContact
      // 
      this.gvContact.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.col1,
            this.col2,
            this.col3});
      this.gvContact.GridControl = this.gridContact;
      this.gvContact.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
      this.gvContact.IndicatorWidth = 50;
      this.gvContact.Name = "gvContact";
      this.gvContact.OptionsBehavior.Editable = false;
      this.gvContact.OptionsFind.AlwaysVisible = true;
      this.gvContact.OptionsFind.ShowFindButton = false;
      this.gvContact.OptionsView.EnableAppearanceEvenRow = true;
      this.gvContact.OptionsView.ShowAutoFilterRow = true;
      this.gvContact.OptionsView.ShowFooter = true;
      this.gvContact.OptionsView.ShowGroupPanel = false;
      this.gvContact.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPDT_CustomDrawRowIndicator);
      // 
      // colID
      // 
      this.colID.Name = "colID";
      this.colID.OptionsColumn.ShowInCustomizationForm = false;
      // 
      // col1
      // 
      this.col1.Caption = "รหัสวิธีการติดต่อ";
      this.col1.FieldName = "CONTACT_CODE";
      this.col1.Name = "col1";
      this.col1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CONTACT_CODE", "จำนวนรายการ = {0}")});
      this.col1.Visible = true;
      this.col1.VisibleIndex = 0;
      this.col1.Width = 100;
      // 
      // col2
      // 
      this.col2.Caption = "ชื่อวิธีการติดต่อ";
      this.col2.FieldName = "CONTACT_NAME";
      this.col2.Name = "col2";
      this.col2.Visible = true;
      this.col2.VisibleIndex = 1;
      this.col2.Width = 150;
      // 
      // col3
      // 
      this.col3.Caption = "รายละเอียด";
      this.col3.FieldName = "CONTACT_DESCRIPTION";
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
      // frm_Contacts_List
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(931, 417);
      this.Controls.Add(this.gridContact);
      this.Name = "frm_Contacts_List";
      this.Tag = "1001";
      this.Text = "วิธีการติดต่อ";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Product_List_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.gridContact)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvContact)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Set)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.r_Component)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridContact;
        private DevExpress.XtraGrid.Views.Grid.GridView gvContact;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private DevExpress.XtraGrid.Columns.GridColumn col3;
        private System.ComponentModel.BackgroundWorker bwCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Set;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit r_Component;
  }
}
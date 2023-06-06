namespace SmartPart.Forms.Sale
{
  partial class frm_ChequeRecord
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.BTcancel = new DevExpress.XtraEditors.SimpleButton();
            this.BTsave = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.BTitemDelete = new DevExpress.XtraEditors.SimpleButton();
            this.BTitemEdit = new DevExpress.XtraEditors.SimpleButton();
            this.BTitemAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridCheque = new DevExpress.XtraGrid.GridControl();
            this.gvCheque = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoMaster = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repoMasterView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChequeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChequeDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChequeName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoMasterView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.BTcancel);
            this.panelControl1.Controls.Add(this.BTsave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(863, 47);
            this.panelControl1.TabIndex = 3;
            // 
            // BTcancel
            // 
            this.BTcancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTcancel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.BTcancel.Appearance.Options.UseFont = true;
            this.BTcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTcancel.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.BTcancel.Location = new System.Drawing.Point(761, 5);
            this.BTcancel.Name = "BTcancel";
            this.BTcancel.Size = new System.Drawing.Size(97, 36);
            this.BTcancel.TabIndex = 1;
            this.BTcancel.Text = "ยกเลิก";
            this.BTcancel.ToolTip = "ยกเลิก = ESC";
            this.BTcancel.Click += new System.EventHandler(this.BTcancel_Click);
            // 
            // BTsave
            // 
            this.BTsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTsave.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.BTsave.Appearance.Options.UseFont = true;
            this.BTsave.ImageOptions.Image = global::SmartPart.Properties.Resources.page_save;
            this.BTsave.Location = new System.Drawing.Point(625, 5);
            this.BTsave.Name = "BTsave";
            this.BTsave.Size = new System.Drawing.Size(130, 36);
            this.BTsave.TabIndex = 0;
            this.BTsave.Tag = "2";
            this.BTsave.Text = "บันทึก (F2)";
            this.BTsave.ToolTip = "บันทึก = F2";
            this.BTsave.Click += new System.EventHandler(this.BTsave_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.BTitemDelete);
            this.panelControl2.Controls.Add(this.BTitemEdit);
            this.panelControl2.Controls.Add(this.BTitemAdd);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(774, 47);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(89, 278);
            this.panelControl2.TabIndex = 41;
            // 
            // BTitemDelete
            // 
            this.BTitemDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTitemDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.BTitemDelete.Appearance.Options.UseFont = true;
            this.BTitemDelete.ImageOptions.Image = global::SmartPart.Properties.Resources.Delete_16x16;
            this.BTitemDelete.Location = new System.Drawing.Point(11, 67);
            this.BTitemDelete.Name = "BTitemDelete";
            this.BTitemDelete.Size = new System.Drawing.Size(68, 25);
            this.BTitemDelete.TabIndex = 2;
            this.BTitemDelete.Text = "ลบ";
            this.BTitemDelete.Click += new System.EventHandler(this.BTitemDelete_Click);
            // 
            // BTitemEdit
            // 
            this.BTitemEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTitemEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.BTitemEdit.Appearance.Options.UseFont = true;
            this.BTitemEdit.ImageOptions.Image = global::SmartPart.Properties.Resources.Edit_16x16;
            this.BTitemEdit.Location = new System.Drawing.Point(11, 36);
            this.BTitemEdit.Name = "BTitemEdit";
            this.BTitemEdit.Size = new System.Drawing.Size(68, 25);
            this.BTitemEdit.TabIndex = 1;
            this.BTitemEdit.Text = "แก้ไข";
            this.BTitemEdit.Click += new System.EventHandler(this.BTitemEdit_Click);
            // 
            // BTitemAdd
            // 
            this.BTitemAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTitemAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.BTitemAdd.Appearance.Options.UseFont = true;
            this.BTitemAdd.ImageOptions.Image = global::SmartPart.Properties.Resources.Add_16x16;
            this.BTitemAdd.Location = new System.Drawing.Point(11, 5);
            this.BTitemAdd.Name = "BTitemAdd";
            this.BTitemAdd.ShowToolTips = false;
            this.BTitemAdd.Size = new System.Drawing.Size(68, 25);
            this.BTitemAdd.TabIndex = 0;
            this.BTitemAdd.Text = "เพิ่ม";
            this.BTitemAdd.Click += new System.EventHandler(this.BTitemAdd_Click);
            // 
            // gridCheque
            // 
            this.gridCheque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCheque.Location = new System.Drawing.Point(0, 47);
            this.gridCheque.MainView = this.gvCheque;
            this.gridCheque.Name = "gridCheque";
            this.gridCheque.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoMaster});
            this.gridCheque.Size = new System.Drawing.Size(774, 278);
            this.gridCheque.TabIndex = 42;
            this.gridCheque.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCheque});
            // 
            // gvCheque
            // 
            this.gvCheque.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvCheque.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvCheque.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvCheque.Appearance.Row.Options.UseFont = true;
            this.gvCheque.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colBank,
            this.colChequeNo,
            this.colChequeDate,
            this.colAmount,
            this.colChequeName});
            this.gvCheque.GridControl = this.gridCheque;
            this.gvCheque.IndicatorWidth = 30;
            this.gvCheque.Name = "gvCheque";
            this.gvCheque.OptionsBehavior.Editable = false;
            this.gvCheque.OptionsView.EnableAppearanceEvenRow = true;
            this.gvCheque.OptionsView.ShowGroupPanel = false;
            this.gvCheque.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPay_CustomDrawRowIndicator);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "CREDITCARD_ID";
            this.colID.Name = "colID";
            // 
            // colBank
            // 
            this.colBank.AppearanceHeader.Options.UseTextOptions = true;
            this.colBank.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBank.Caption = "ธนาคาร";
            this.colBank.ColumnEdit = this.repoMaster;
            this.colBank.FieldName = "BANK_ID";
            this.colBank.Name = "colBank";
            this.colBank.Visible = true;
            this.colBank.VisibleIndex = 0;
            this.colBank.Width = 131;
            // 
            // repoMaster
            // 
            this.repoMaster.AutoHeight = false;
            this.repoMaster.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoMaster.Name = "repoMaster";
            this.repoMaster.NullText = "";
            this.repoMaster.View = this.repoMasterView;
            // 
            // repoMasterView
            // 
            this.repoMasterView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repoMasterView.Name = "repoMasterView";
            this.repoMasterView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repoMasterView.OptionsView.ShowGroupPanel = false;
            // 
            // colChequeNo
            // 
            this.colChequeNo.AppearanceCell.Options.UseTextOptions = true;
            this.colChequeNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChequeNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colChequeNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChequeNo.Caption = "เลขที่เช็ค";
            this.colChequeNo.FieldName = "CHEQUE_NO";
            this.colChequeNo.Name = "colChequeNo";
            this.colChequeNo.Visible = true;
            this.colChequeNo.VisibleIndex = 1;
            this.colChequeNo.Width = 140;
            // 
            // colChequeDate
            // 
            this.colChequeDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colChequeDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChequeDate.Caption = "วันที่เช็ค";
            this.colChequeDate.FieldName = "CHEQUE_DATE";
            this.colChequeDate.Name = "colChequeDate";
            this.colChequeDate.Visible = true;
            this.colChequeDate.VisibleIndex = 2;
            this.colChequeDate.Width = 130;
            // 
            // colAmount
            // 
            this.colAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.colAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAmount.Caption = "จำนวนเงิน";
            this.colAmount.DisplayFormat.FormatString = "N2";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "AMOUNT";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 3;
            this.colAmount.Width = 132;
            // 
            // colChequeName
            // 
            this.colChequeName.Caption = "ชื่อหน้าเช็ค";
            this.colChequeName.FieldName = "CHEQUE_NAME";
            this.colChequeName.Name = "colChequeName";
            this.colChequeName.Visible = true;
            this.colChequeName.VisibleIndex = 4;
            this.colChequeName.Width = 209;
            // 
            // frm_ChequeRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 325);
            this.Controls.Add(this.gridCheque);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChequeRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "รายการเช็ค";
            this.Load += new System.EventHandler(this.frm_InputCard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_CardRecord_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoMasterView)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton BTcancel;
    private DevExpress.XtraEditors.SimpleButton BTsave;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton BTitemDelete;
        private DevExpress.XtraEditors.SimpleButton BTitemEdit;
        private DevExpress.XtraEditors.SimpleButton BTitemAdd;
        private DevExpress.XtraGrid.GridControl gridCheque;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCheque;
        private DevExpress.XtraGrid.Columns.GridColumn colBank;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repoMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView repoMasterView;
        private DevExpress.XtraGrid.Columns.GridColumn colChequeDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colChequeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colChequeName;
    }
}
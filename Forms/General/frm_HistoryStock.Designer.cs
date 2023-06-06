namespace SmartPart.Forms.General
{
  partial class frm_HistoryStock
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
      this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.lstStockOnHand = new System.Windows.Forms.ListView();
      this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colDocNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.txtItemName = new DevExpress.XtraEditors.TextEdit();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.bwItem = new System.ComponentModel.BackgroundWorker();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.lstStockOnHand);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl2.Location = new System.Drawing.Point(0, 50);
      this.panelControl2.Margin = new System.Windows.Forms.Padding(5);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(541, 238);
      this.panelControl2.TabIndex = 4;
      // 
      // lstStockOnHand
      // 
      this.lstStockOnHand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colDocNo,
            this.colUser,
            this.colQty});
      this.lstStockOnHand.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstStockOnHand.FullRowSelect = true;
      this.lstStockOnHand.Location = new System.Drawing.Point(2, 2);
      this.lstStockOnHand.Name = "lstStockOnHand";
      this.lstStockOnHand.Size = new System.Drawing.Size(537, 234);
      this.lstStockOnHand.TabIndex = 1;
      this.lstStockOnHand.UseCompatibleStateImageBehavior = false;
      this.lstStockOnHand.View = System.Windows.Forms.View.Details;
      // 
      // colDate
      // 
      this.colDate.Text = "วันที่";
      this.colDate.Width = 116;
      // 
      // colDocNo
      // 
      this.colDocNo.Text = "หมายเลขเอกสาร";
      this.colDocNo.Width = 158;
      // 
      // colUser
      // 
      this.colUser.Text = "รหัสพนักงาน";
      this.colUser.Width = 140;
      // 
      // colQty
      // 
      this.colQty.Text = "จำนวนที่ปรับปรุง";
      this.colQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.colQty.Width = 119;
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.txtItemName);
      this.panelControl1.Controls.Add(this.labelControl1);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(541, 50);
      this.panelControl1.TabIndex = 3;
      // 
      // txtItemName
      // 
      this.txtItemName.EnterMoveNextControl = true;
      this.txtItemName.Location = new System.Drawing.Point(76, 14);
      this.txtItemName.Name = "txtItemName";
      this.txtItemName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.txtItemName.Properties.Appearance.Options.UseFont = true;
      this.txtItemName.Properties.ReadOnly = true;
      this.txtItemName.Size = new System.Drawing.Size(182, 22);
      this.txtItemName.TabIndex = 3;
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Location = new System.Drawing.Point(12, 17);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(58, 17);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "รหัสสินค้า";
      // 
      // bwItem
      // 
      this.bwItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwItem_DoWork);
      this.bwItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwItem_RunWorkerCompleted);
      // 
      // frm_HistoryStock
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(541, 288);
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "frm_HistoryStock";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ประวัติการปรับปรุงสต๊อค";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_HistoryStock_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.panelControl1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl2;
    private System.Windows.Forms.ListView lstStockOnHand;
    private System.Windows.Forms.ColumnHeader colDate;
    private System.Windows.Forms.ColumnHeader colQty;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.TextEdit txtItemName;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private System.Windows.Forms.ColumnHeader colDocNo;
    private System.Windows.Forms.ColumnHeader colUser;
    private System.ComponentModel.BackgroundWorker bwItem;
  }
}
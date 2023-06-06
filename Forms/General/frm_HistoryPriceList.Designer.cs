namespace SmartPart.Forms.General
{
    partial class frm_HistoryPriceList
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
      this.txtItemName = new DevExpress.XtraEditors.TextEdit();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.lstPriceList = new System.Windows.Forms.ListView();
      this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.bwItem = new System.ComponentModel.BackgroundWorker();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.txtItemName);
      this.panelControl1.Controls.Add(this.labelControl1);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(422, 50);
      this.panelControl1.TabIndex = 0;
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
      // lstPriceList
      // 
      this.lstPriceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colPrice,
            this.colDate});
      this.lstPriceList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstPriceList.FullRowSelect = true;
      this.lstPriceList.Location = new System.Drawing.Point(2, 2);
      this.lstPriceList.Name = "lstPriceList";
      this.lstPriceList.Size = new System.Drawing.Size(418, 178);
      this.lstPriceList.TabIndex = 1;
      this.lstPriceList.UseCompatibleStateImageBehavior = false;
      this.lstPriceList.View = System.Windows.Forms.View.Details;
      // 
      // colNo
      // 
      this.colNo.Text = "ครั้งที่";
      // 
      // colPrice
      // 
      this.colPrice.Text = "ราคา";
      this.colPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.colPrice.Width = 180;
      // 
      // colDate
      // 
      this.colDate.Text = "วันที่ราคามีผล";
      this.colDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.colDate.Width = 172;
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.lstPriceList);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl2.Location = new System.Drawing.Point(0, 50);
      this.panelControl2.Margin = new System.Windows.Forms.Padding(5);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(422, 182);
      this.panelControl2.TabIndex = 2;
      // 
      // bwItem
      // 
      this.bwItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwItem_DoWork);
      this.bwItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwItem_RunWorkerCompleted);
      // 
      // frm_HistoryPriceList
      // 
      this.Appearance.Options.UseFont = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(422, 232);
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl1);
      this.Font = new System.Drawing.Font("Tahoma", 10F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.KeyPreview = true;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "frm_HistoryPriceList";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "frm_HistoryPriceList";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_HistoryPriceList_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.panelControl1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private System.Windows.Forms.ListView lstPriceList;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.ColumnHeader colDate;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.ComponentModel.BackgroundWorker bwItem;
    }
}
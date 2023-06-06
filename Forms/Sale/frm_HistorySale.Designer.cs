namespace SmartPart.Forms.Sale
{
    partial class frm_HistorySale
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
            this.gridHis = new DevExpress.XtraGrid.GridControl();
            this.gvHis = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridHis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHis)).BeginInit();
            this.SuspendLayout();
            // 
            // gridHis
            // 
            this.gridHis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHis.Location = new System.Drawing.Point(0, 0);
            this.gridHis.MainView = this.gvHis;
            this.gridHis.Name = "gridHis";
            this.gridHis.Size = new System.Drawing.Size(894, 290);
            this.gridHis.TabIndex = 38;
            this.gridHis.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHis});
            // 
            // gvHis
            // 
            this.gvHis.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvHis.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvHis.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvHis.Appearance.Row.Options.UseFont = true;
            this.gvHis.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col1,
            this.col2,
            this.col3});
            this.gvHis.GridControl = this.gridHis;
            this.gvHis.IndicatorWidth = 30;
            this.gvHis.Name = "gvHis";
            this.gvHis.OptionsBehavior.Editable = false;
            this.gvHis.OptionsView.EnableAppearanceEvenRow = true;
            this.gvHis.OptionsView.ShowGroupPanel = false;
            // 
            // col1
            // 
            this.col1.AppearanceHeader.Options.UseTextOptions = true;
            this.col1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col1.Caption = "วันที่";
            this.col1.FieldName = "BSH_DATE";
            this.col1.Name = "col1";
            this.col1.Visible = true;
            this.col1.VisibleIndex = 0;
            this.col1.Width = 120;
            // 
            // col2
            // 
            this.col2.AppearanceHeader.Options.UseTextOptions = true;
            this.col2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col2.Caption = "จำนวนที่ขาย";
            this.col2.FieldName = "QTY";
            this.col2.Name = "col2";
            this.col2.Visible = true;
            this.col2.VisibleIndex = 1;
            this.col2.Width = 195;
            // 
            // col3
            // 
            this.col3.AppearanceHeader.Options.UseTextOptions = true;
            this.col3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col3.Caption = "ราคาต่อหน่วย";
            this.col3.DisplayFormat.FormatString = "n2";
            this.col3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col3.FieldName = "UPRICE";
            this.col3.Name = "col3";
            this.col3.Visible = true;
            this.col3.VisibleIndex = 2;
            this.col3.Width = 253;
            // 
            // frm_HistorySale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 290);
            this.Controls.Add(this.gridHis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_HistorySale";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ประวัติการขาย";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_HistorySale_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridHis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridHis;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHis;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private DevExpress.XtraGrid.Columns.GridColumn col3;
    }
}
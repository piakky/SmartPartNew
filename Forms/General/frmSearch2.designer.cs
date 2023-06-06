namespace SmartPart.Forms.General
{
    partial class frmSearch2
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
      this.BTreset = new DevExpress.XtraEditors.SimpleButton();
      this.BTsearch = new DevExpress.XtraEditors.SimpleButton();
      this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
      this.TxtVendorName = new DevExpress.XtraEditors.TextEdit();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.searchVendorsCode = new DevExpress.XtraEditors.SearchLookUpEdit();
      this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
      this.groupControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtVendorName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchVendorsCode.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
      this.SuspendLayout();
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.BTreset);
      this.panelControl1.Controls.Add(this.BTsearch);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl1.Location = new System.Drawing.Point(0, 73);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(626, 58);
      this.panelControl1.TabIndex = 4;
      // 
      // BTreset
      // 
      this.BTreset.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.BTreset.Appearance.Options.UseFont = true;
      this.BTreset.Location = new System.Drawing.Point(525, 4);
      this.BTreset.Name = "BTreset";
      this.BTreset.Size = new System.Drawing.Size(96, 47);
      this.BTreset.TabIndex = 0;
      this.BTreset.Text = "ลบหน้าจอ";
      this.BTreset.Click += new System.EventHandler(this.BTreset_Click);
      // 
      // BTsearch
      // 
      this.BTsearch.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.BTsearch.Appearance.Options.UseFont = true;
      this.BTsearch.Location = new System.Drawing.Point(423, 4);
      this.BTsearch.Name = "BTsearch";
      this.BTsearch.Size = new System.Drawing.Size(96, 47);
      this.BTsearch.TabIndex = 0;
      this.BTsearch.Text = "ค้นหา";
      this.BTsearch.Click += new System.EventHandler(this.BTsearch_Click);
      // 
      // groupControl1
      // 
      this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.groupControl1.Appearance.Options.UseFont = true;
      this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
      this.groupControl1.AppearanceCaption.Options.UseFont = true;
      this.groupControl1.Controls.Add(this.TxtVendorName);
      this.groupControl1.Controls.Add(this.labelControl1);
      this.groupControl1.Controls.Add(this.searchVendorsCode);
      this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupControl1.Location = new System.Drawing.Point(0, 0);
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new System.Drawing.Size(626, 73);
      this.groupControl1.TabIndex = 5;
      this.groupControl1.Text = "ข้อมูลสินค้า";
      // 
      // TxtVendorName
      // 
      this.TxtVendorName.EnterMoveNextControl = true;
      this.TxtVendorName.Location = new System.Drawing.Point(300, 32);
      this.TxtVendorName.Name = "TxtVendorName";
      this.TxtVendorName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.TxtVendorName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.TxtVendorName.Properties.Appearance.Options.UseBackColor = true;
      this.TxtVendorName.Properties.Appearance.Options.UseFont = true;
      this.TxtVendorName.Properties.ReadOnly = true;
      this.TxtVendorName.Size = new System.Drawing.Size(321, 22);
      this.TxtVendorName.TabIndex = 6;
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Location = new System.Drawing.Point(12, 35);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(64, 17);
      this.labelControl1.TabIndex = 1;
      this.labelControl1.Text = "เลือกพ่อค้า";
      // 
      // searchVendorsCode
      // 
      this.searchVendorsCode.EnterMoveNextControl = true;
      this.searchVendorsCode.Location = new System.Drawing.Point(82, 32);
      this.searchVendorsCode.Name = "searchVendorsCode";
      this.searchVendorsCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.searchVendorsCode.Properties.Appearance.Options.UseFont = true;
      this.searchVendorsCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.searchVendorsCode.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F1));
      this.searchVendorsCode.Properties.NullText = "เลือกรหัสพ่อค้า";
      this.searchVendorsCode.Properties.View = this.searchLookUpEdit1View;
      this.searchVendorsCode.Size = new System.Drawing.Size(212, 22);
      this.searchVendorsCode.TabIndex = 0;
      this.searchVendorsCode.EditValueChanged += new System.EventHandler(this.searchVendorsCode_EditValueChanged);
      // 
      // searchLookUpEdit1View
      // 
      this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
      this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
      // 
      // frmSearch2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(626, 131);
      this.Controls.Add(this.groupControl1);
      this.Controls.Add(this.panelControl1);
      this.Name = "frmSearch2";
      this.Text = "ค้นหาแบบที่ 2";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearch2_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
      this.groupControl1.ResumeLayout(false);
      this.groupControl1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtVendorName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchVendorsCode.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton BTreset;
        private DevExpress.XtraEditors.SimpleButton BTsearch;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        internal DevExpress.XtraEditors.TextEdit TxtVendorName;
        internal DevExpress.XtraEditors.SearchLookUpEdit searchVendorsCode;
    }
}
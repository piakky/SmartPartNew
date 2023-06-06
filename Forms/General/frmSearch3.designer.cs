namespace SmartPart.Forms.General
{
    partial class frmSearch3
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
      this.txtTypesName = new DevExpress.XtraEditors.TextEdit();
      this.txtBrandName = new DevExpress.XtraEditors.TextEdit();
      this.TxtVendorName = new DevExpress.XtraEditors.TextEdit();
      this.TxtPOGroupName = new DevExpress.XtraEditors.TextEdit();
      this.searchTypesCode = new DevExpress.XtraEditors.SearchLookUpEdit();
      this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.searchBrandCode = new DevExpress.XtraEditors.SearchLookUpEdit();
      this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.searchVendorsCode = new DevExpress.XtraEditors.SearchLookUpEdit();
      this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.searchPOGroupsCode = new DevExpress.XtraEditors.SearchLookUpEdit();
      this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.radioGroupType = new DevExpress.XtraEditors.RadioGroup();
      this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
      this.groupControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtTypesName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtBrandName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtVendorName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtPOGroupName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchTypesCode.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchBrandCode.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchVendorsCode.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchPOGroupsCode.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radioGroupType.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.BTreset);
      this.panelControl1.Controls.Add(this.BTsearch);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl1.Location = new System.Drawing.Point(0, 239);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(613, 58);
      this.panelControl1.TabIndex = 3;
      // 
      // BTreset
      // 
      this.BTreset.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.BTreset.Appearance.Options.UseFont = true;
      this.BTreset.Location = new System.Drawing.Point(510, 5);
      this.BTreset.Name = "BTreset";
      this.BTreset.Size = new System.Drawing.Size(96, 47);
      this.BTreset.TabIndex = 1;
      this.BTreset.Text = "ลบหน้าจอ";
      this.BTreset.ToolTip = "ลบหน้าจอ = F3";
      this.BTreset.Click += new System.EventHandler(this.BTreset_Click);
      // 
      // BTsearch
      // 
      this.BTsearch.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.BTsearch.Appearance.Options.UseFont = true;
      this.BTsearch.ImageOptions.Image = global::SmartPart.Properties.Resources.Search_16x16;
      this.BTsearch.Location = new System.Drawing.Point(394, 5);
      this.BTsearch.Name = "BTsearch";
      this.BTsearch.Size = new System.Drawing.Size(110, 47);
      this.BTsearch.TabIndex = 0;
      this.BTsearch.Text = "ค้นหา (F8)";
      this.BTsearch.ToolTip = "ค้นหา = F6";
      this.BTsearch.Click += new System.EventHandler(this.BTsearch_Click);
      // 
      // groupControl1
      // 
      this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
      this.groupControl1.AppearanceCaption.Options.UseFont = true;
      this.groupControl1.Controls.Add(this.txtTypesName);
      this.groupControl1.Controls.Add(this.txtBrandName);
      this.groupControl1.Controls.Add(this.TxtVendorName);
      this.groupControl1.Controls.Add(this.TxtPOGroupName);
      this.groupControl1.Controls.Add(this.searchTypesCode);
      this.groupControl1.Controls.Add(this.searchBrandCode);
      this.groupControl1.Controls.Add(this.searchVendorsCode);
      this.groupControl1.Controls.Add(this.searchPOGroupsCode);
      this.groupControl1.Controls.Add(this.radioGroupType);
      this.groupControl1.Controls.Add(this.labelControl5);
      this.groupControl1.Controls.Add(this.labelControl4);
      this.groupControl1.Controls.Add(this.labelControl3);
      this.groupControl1.Controls.Add(this.labelControl2);
      this.groupControl1.Controls.Add(this.labelControl1);
      this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupControl1.Location = new System.Drawing.Point(0, 0);
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new System.Drawing.Size(613, 239);
      this.groupControl1.TabIndex = 0;
      this.groupControl1.Text = "ข้อมูลสินค้า";
      // 
      // txtTypesName
      // 
      this.txtTypesName.EnterMoveNextControl = true;
      this.txtTypesName.Location = new System.Drawing.Point(325, 110);
      this.txtTypesName.Name = "txtTypesName";
      this.txtTypesName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.txtTypesName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.txtTypesName.Properties.Appearance.Options.UseBackColor = true;
      this.txtTypesName.Properties.Appearance.Options.UseFont = true;
      this.txtTypesName.Properties.ReadOnly = true;
      this.txtTypesName.Size = new System.Drawing.Size(280, 22);
      this.txtTypesName.TabIndex = 11;
      // 
      // txtBrandName
      // 
      this.txtBrandName.EnterMoveNextControl = true;
      this.txtBrandName.Location = new System.Drawing.Point(325, 82);
      this.txtBrandName.Name = "txtBrandName";
      this.txtBrandName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.txtBrandName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.txtBrandName.Properties.Appearance.Options.UseBackColor = true;
      this.txtBrandName.Properties.Appearance.Options.UseFont = true;
      this.txtBrandName.Properties.ReadOnly = true;
      this.txtBrandName.Size = new System.Drawing.Size(280, 22);
      this.txtBrandName.TabIndex = 8;
      // 
      // TxtVendorName
      // 
      this.TxtVendorName.EnterMoveNextControl = true;
      this.TxtVendorName.Location = new System.Drawing.Point(325, 54);
      this.TxtVendorName.Name = "TxtVendorName";
      this.TxtVendorName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.TxtVendorName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.TxtVendorName.Properties.Appearance.Options.UseBackColor = true;
      this.TxtVendorName.Properties.Appearance.Options.UseFont = true;
      this.TxtVendorName.Properties.ReadOnly = true;
      this.TxtVendorName.Size = new System.Drawing.Size(280, 22);
      this.TxtVendorName.TabIndex = 5;
      // 
      // TxtPOGroupName
      // 
      this.TxtPOGroupName.EnterMoveNextControl = true;
      this.TxtPOGroupName.Location = new System.Drawing.Point(325, 26);
      this.TxtPOGroupName.Name = "TxtPOGroupName";
      this.TxtPOGroupName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.TxtPOGroupName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.TxtPOGroupName.Properties.Appearance.Options.UseBackColor = true;
      this.TxtPOGroupName.Properties.Appearance.Options.UseFont = true;
      this.TxtPOGroupName.Properties.ReadOnly = true;
      this.TxtPOGroupName.Size = new System.Drawing.Size(280, 22);
      this.TxtPOGroupName.TabIndex = 2;
      // 
      // searchTypesCode
      // 
      this.searchTypesCode.EnterMoveNextControl = true;
      this.searchTypesCode.Location = new System.Drawing.Point(103, 110);
      this.searchTypesCode.Name = "searchTypesCode";
      this.searchTypesCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.searchTypesCode.Properties.Appearance.Options.UseFont = true;
      this.searchTypesCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.searchTypesCode.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F1));
      this.searchTypesCode.Properties.NullText = "";
      this.searchTypesCode.Properties.View = this.gridView3;
      this.searchTypesCode.Size = new System.Drawing.Size(216, 22);
      this.searchTypesCode.TabIndex = 10;
      this.searchTypesCode.EditValueChanged += new System.EventHandler(this.searchTypesCode_EditValueChanged);
      // 
      // gridView3
      // 
      this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gridView3.Name = "gridView3";
      this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridView3.OptionsView.ShowGroupPanel = false;
      // 
      // searchBrandCode
      // 
      this.searchBrandCode.EnterMoveNextControl = true;
      this.searchBrandCode.Location = new System.Drawing.Point(103, 82);
      this.searchBrandCode.Name = "searchBrandCode";
      this.searchBrandCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.searchBrandCode.Properties.Appearance.Options.UseFont = true;
      this.searchBrandCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.searchBrandCode.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F1));
      this.searchBrandCode.Properties.NullText = "";
      this.searchBrandCode.Properties.View = this.gridView2;
      this.searchBrandCode.Size = new System.Drawing.Size(216, 22);
      this.searchBrandCode.TabIndex = 7;
      this.searchBrandCode.EditValueChanged += new System.EventHandler(this.searchBrandCode_EditValueChanged);
      // 
      // gridView2
      // 
      this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gridView2.Name = "gridView2";
      this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridView2.OptionsView.ShowGroupPanel = false;
      // 
      // searchVendorsCode
      // 
      this.searchVendorsCode.EnterMoveNextControl = true;
      this.searchVendorsCode.Location = new System.Drawing.Point(103, 54);
      this.searchVendorsCode.Name = "searchVendorsCode";
      this.searchVendorsCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.searchVendorsCode.Properties.Appearance.Options.UseFont = true;
      this.searchVendorsCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.searchVendorsCode.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F1));
      this.searchVendorsCode.Properties.NullText = "";
      this.searchVendorsCode.Properties.View = this.gridView1;
      this.searchVendorsCode.Size = new System.Drawing.Size(216, 22);
      this.searchVendorsCode.TabIndex = 4;
      this.searchVendorsCode.EditValueChanged += new System.EventHandler(this.searchVendorsCode_EditValueChanged);
      // 
      // gridView1
      // 
      this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      // 
      // searchPOGroupsCode
      // 
      this.searchPOGroupsCode.EditValue = "";
      this.searchPOGroupsCode.EnterMoveNextControl = true;
      this.searchPOGroupsCode.Location = new System.Drawing.Point(103, 26);
      this.searchPOGroupsCode.Name = "searchPOGroupsCode";
      this.searchPOGroupsCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.searchPOGroupsCode.Properties.Appearance.Options.UseFont = true;
      this.searchPOGroupsCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.searchPOGroupsCode.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F1));
      this.searchPOGroupsCode.Properties.NullText = "";
      this.searchPOGroupsCode.Properties.View = this.searchLookUpEdit1View;
      this.searchPOGroupsCode.Size = new System.Drawing.Size(216, 22);
      this.searchPOGroupsCode.TabIndex = 1;
      this.searchPOGroupsCode.EditValueChanged += new System.EventHandler(this.searchPOGroupsCode_EditValueChanged);
      // 
      // searchLookUpEdit1View
      // 
      this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
      this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
      // 
      // radioGroupType
      // 
      this.radioGroupType.Location = new System.Drawing.Point(103, 183);
      this.radioGroupType.Name = "radioGroupType";
      this.radioGroupType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.radioGroupType.Properties.Appearance.Options.UseFont = true;
      this.radioGroupType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "น้อยกว่าปริมาณต่ำสุด"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "มากกว่าปริมาณสูงสุด")});
      this.radioGroupType.Size = new System.Drawing.Size(502, 34);
      this.radioGroupType.TabIndex = 0;
      // 
      // labelControl5
      // 
      this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl5.Appearance.Options.UseFont = true;
      this.labelControl5.Location = new System.Drawing.Point(18, 150);
      this.labelControl5.Name = "labelControl5";
      this.labelControl5.Size = new System.Drawing.Size(205, 17);
      this.labelControl5.TabIndex = 12;
      this.labelControl5.Text = "แสดงสินค้าตามจำนวนสินค้าในคลัง";
      // 
      // labelControl4
      // 
      this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl4.Appearance.Options.UseFont = true;
      this.labelControl4.Location = new System.Drawing.Point(18, 113);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(79, 17);
      this.labelControl4.TabIndex = 9;
      this.labelControl4.Text = "ประเภทสินค้า";
      // 
      // labelControl3
      // 
      this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl3.Appearance.Options.UseFont = true;
      this.labelControl3.Location = new System.Drawing.Point(38, 85);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(59, 17);
      this.labelControl3.TabIndex = 6;
      this.labelControl3.Text = "ยี่ห้อสืนค้า";
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl2.Appearance.Options.UseFont = true;
      this.labelControl2.Location = new System.Drawing.Point(29, 57);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(68, 17);
      this.labelControl2.TabIndex = 3;
      this.labelControl2.Text = "พ่อค้าสั่งซื้อ";
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Location = new System.Drawing.Point(38, 29);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(59, 17);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "กลุ่มสั่งซื้อ";
      // 
      // frmSearch3
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(613, 297);
      this.Controls.Add(this.groupControl1);
      this.Controls.Add(this.panelControl1);
      this.Name = "frmSearch3";
      this.Text = "ค้นหาแบบที่ 3";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearch3_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
      this.groupControl1.ResumeLayout(false);
      this.groupControl1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtTypesName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtBrandName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtVendorName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtPOGroupName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchTypesCode.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchBrandCode.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchVendorsCode.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchPOGroupsCode.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radioGroupType.Properties)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton BTreset;
        private DevExpress.XtraEditors.SimpleButton BTsearch;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        internal DevExpress.XtraEditors.RadioGroup radioGroupType;
        internal DevExpress.XtraEditors.TextEdit txtTypesName;
        internal DevExpress.XtraEditors.TextEdit txtBrandName;
        internal DevExpress.XtraEditors.TextEdit TxtVendorName;
        internal DevExpress.XtraEditors.TextEdit TxtPOGroupName;
        internal DevExpress.XtraEditors.SearchLookUpEdit searchTypesCode;
        internal DevExpress.XtraEditors.SearchLookUpEdit searchBrandCode;
        internal DevExpress.XtraEditors.SearchLookUpEdit searchVendorsCode;
        internal DevExpress.XtraEditors.SearchLookUpEdit searchPOGroupsCode;
    }
}
namespace SmartPart.Forms.General
{
    partial class frm_ItemEdit4
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
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.searchTypesCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtTypesName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.searchCategoriesCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtCategoriesName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.bwItem = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchTypesCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypesName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchCategoriesCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoriesName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btClose);
            this.panelControl1.Controls.Add(this.btSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(551, 59);
            this.panelControl1.TabIndex = 11;
            // 
            // btClose
            // 
            this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btClose.Appearance.Options.UseFont = true;
            this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.btClose.Location = new System.Drawing.Point(148, 9);
            this.btClose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(135, 46);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "ยกเลิก (ESC)";
            this.btClose.ToolTip = "ยกเลิก = ESC";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSave
            // 
            this.btSave.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btSave.Appearance.Options.UseFont = true;
            this.btSave.ImageOptions.Image = global::SmartPart.Properties.Resources.page_save;
            this.btSave.Location = new System.Drawing.Point(10, 9);
            this.btSave.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(135, 46);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "บันทึก (F2)";
            this.btSave.ToolTip = "บันทึก = F2";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // searchTypesCode
            // 
            this.searchTypesCode.EnterMoveNextControl = true;
            this.searchTypesCode.Location = new System.Drawing.Point(126, 94);
            this.searchTypesCode.Name = "searchTypesCode";
            this.searchTypesCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.searchTypesCode.Properties.Appearance.Options.UseFont = true;
            this.searchTypesCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchTypesCode.Properties.NullText = "เลือกประเภทสินค้า";
            this.searchTypesCode.Properties.View = this.gridView1;
            this.searchTypesCode.Size = new System.Drawing.Size(157, 22);
            this.searchTypesCode.TabIndex = 16;
            this.searchTypesCode.EditValueChanged += new System.EventHandler(this.searchTypesCode_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // txtTypesName
            // 
            this.txtTypesName.EnterMoveNextControl = true;
            this.txtTypesName.Location = new System.Drawing.Point(289, 94);
            this.txtTypesName.Name = "txtTypesName";
            this.txtTypesName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTypesName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTypesName.Properties.Appearance.Options.UseBackColor = true;
            this.txtTypesName.Properties.Appearance.Options.UseFont = true;
            this.txtTypesName.Properties.ReadOnly = true;
            this.txtTypesName.Size = new System.Drawing.Size(241, 22);
            this.txtTypesName.TabIndex = 17;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(41, 97);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(79, 17);
            this.labelControl12.TabIndex = 15;
            this.labelControl12.Text = "ประเภทสินค้า";
            // 
            // searchCategoriesCode
            // 
            this.searchCategoriesCode.EnterMoveNextControl = true;
            this.searchCategoriesCode.Location = new System.Drawing.Point(126, 71);
            this.searchCategoriesCode.Name = "searchCategoriesCode";
            this.searchCategoriesCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.searchCategoriesCode.Properties.Appearance.Options.UseFont = true;
            this.searchCategoriesCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchCategoriesCode.Properties.NullText = "เลือกหมวดหมู่สินค้า";
            this.searchCategoriesCode.Properties.View = this.gridView10;
            this.searchCategoriesCode.Size = new System.Drawing.Size(157, 22);
            this.searchCategoriesCode.TabIndex = 13;
            this.searchCategoriesCode.EditValueChanged += new System.EventHandler(this.searchCategoriesCode_EditValueChanged);
            // 
            // gridView10
            // 
            this.gridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView10.Name = "gridView10";
            this.gridView10.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView10.OptionsView.ShowGroupPanel = false;
            // 
            // txtCategoriesName
            // 
            this.txtCategoriesName.EnterMoveNextControl = true;
            this.txtCategoriesName.Location = new System.Drawing.Point(289, 71);
            this.txtCategoriesName.Name = "txtCategoriesName";
            this.txtCategoriesName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCategoriesName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCategoriesName.Properties.Appearance.Options.UseBackColor = true;
            this.txtCategoriesName.Properties.Appearance.Options.UseFont = true;
            this.txtCategoriesName.Properties.ReadOnly = true;
            this.txtCategoriesName.Size = new System.Drawing.Size(241, 22);
            this.txtCategoriesName.TabIndex = 14;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 74);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(108, 17);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "รหัสหมวดหมู่สินค้า";
            // 
            // bwItem
            // 
            this.bwItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwItem_DoWork);
            this.bwItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwItem_RunWorkerCompleted);
            // 
            // frm_ItemEdit4
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 130);
            this.Controls.Add(this.searchTypesCode);
            this.Controls.Add(this.txtTypesName);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.searchCategoriesCode);
            this.Controls.Add(this.txtCategoriesName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ItemEdit4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รหัสสินค้า-หมวดหมู่สินค้า [แก้ไข]";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ItemEdit4_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchTypesCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypesName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchCategoriesCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoriesName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.SearchLookUpEdit searchTypesCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtTypesName;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SearchLookUpEdit searchCategoriesCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private DevExpress.XtraEditors.TextEdit txtCategoriesName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.ComponentModel.BackgroundWorker bwItem;
    }
}
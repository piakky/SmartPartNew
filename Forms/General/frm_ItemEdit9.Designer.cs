namespace SmartPart.Forms.General
{
    partial class frm_ItemEdit9
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
            this.searchSizesCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSizesName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.txtSizeInner = new DevExpress.XtraEditors.TextEdit();
            this.txtSizeOutside = new DevExpress.XtraEditors.TextEdit();
            this.txtSizeThick = new DevExpress.XtraEditors.TextEdit();
            this.bwItem = new System.ComponentModel.BackgroundWorker();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.searchSizesCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizesName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizeInner.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizeOutside.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizeThick.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchSizesCode
            // 
            this.searchSizesCode.EnterMoveNextControl = true;
            this.searchSizesCode.Location = new System.Drawing.Point(141, 76);
            this.searchSizesCode.Name = "searchSizesCode";
            this.searchSizesCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.searchSizesCode.Properties.Appearance.Options.UseFont = true;
            this.searchSizesCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchSizesCode.Properties.NullText = "เลือกประเภทสินค้า+ขนาด";
            this.searchSizesCode.Properties.View = this.gridView7;
            this.searchSizesCode.Size = new System.Drawing.Size(180, 22);
            this.searchSizesCode.TabIndex = 1;
            this.searchSizesCode.EditValueChanged += new System.EventHandler(this.searchSizesCode_EditValueChanged);
            // 
            // gridView7
            // 
            this.gridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView7.OptionsView.ShowGroupPanel = false;
            // 
            // txtSizesName
            // 
            this.txtSizesName.EnterMoveNextControl = true;
            this.txtSizesName.Location = new System.Drawing.Point(327, 76);
            this.txtSizesName.Name = "txtSizesName";
            this.txtSizesName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSizesName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSizesName.Properties.Appearance.Options.UseBackColor = true;
            this.txtSizesName.Properties.Appearance.Options.UseFont = true;
            this.txtSizesName.Properties.ReadOnly = true;
            this.txtSizesName.Size = new System.Drawing.Size(244, 22);
            this.txtSizesName.TabIndex = 2;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(12, 79);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(123, 17);
            this.labelControl14.TabIndex = 0;
            this.labelControl14.Text = "ประเภทสินค้า+ขนาด";
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.Controls.Add(this.labelControl17);
            this.groupControl4.Controls.Add(this.labelControl16);
            this.groupControl4.Controls.Add(this.labelControl15);
            this.groupControl4.Controls.Add(this.txtSizeInner);
            this.groupControl4.Controls.Add(this.txtSizeOutside);
            this.groupControl4.Controls.Add(this.txtSizeThick);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl4.Location = new System.Drawing.Point(0, 105);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(577, 105);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "ขนาด";
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl17.Appearance.Options.UseFont = true;
            this.labelControl17.Location = new System.Drawing.Point(39, 80);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(56, 17);
            this.labelControl17.TabIndex = 4;
            this.labelControl17.Text = "ความหนา";
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl16.Appearance.Options.UseFont = true;
            this.labelControl16.Location = new System.Drawing.Point(45, 54);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(50, 17);
            this.labelControl16.TabIndex = 2;
            this.labelControl16.Text = "ด้านนอก";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(55, 29);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(40, 17);
            this.labelControl15.TabIndex = 0;
            this.labelControl15.Text = "ด้านใน";
            // 
            // txtSizeInner
            // 
            this.txtSizeInner.EnterMoveNextControl = true;
            this.txtSizeInner.Location = new System.Drawing.Point(100, 26);
            this.txtSizeInner.Name = "txtSizeInner";
            this.txtSizeInner.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSizeInner.Properties.Appearance.Options.UseFont = true;
            this.txtSizeInner.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSizeInner.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtSizeInner.Size = new System.Drawing.Size(133, 22);
            this.txtSizeInner.TabIndex = 1;
            // 
            // txtSizeOutside
            // 
            this.txtSizeOutside.EnterMoveNextControl = true;
            this.txtSizeOutside.Location = new System.Drawing.Point(100, 51);
            this.txtSizeOutside.Name = "txtSizeOutside";
            this.txtSizeOutside.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSizeOutside.Properties.Appearance.Options.UseFont = true;
            this.txtSizeOutside.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSizeOutside.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtSizeOutside.Size = new System.Drawing.Size(133, 22);
            this.txtSizeOutside.TabIndex = 3;
            // 
            // txtSizeThick
            // 
            this.txtSizeThick.EnterMoveNextControl = true;
            this.txtSizeThick.Location = new System.Drawing.Point(100, 77);
            this.txtSizeThick.Name = "txtSizeThick";
            this.txtSizeThick.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSizeThick.Properties.Appearance.Options.UseFont = true;
            this.txtSizeThick.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSizeThick.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtSizeThick.Size = new System.Drawing.Size(133, 22);
            this.txtSizeThick.TabIndex = 5;
            // 
            // bwItem
            // 
            this.bwItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwItem_DoWork);
            this.bwItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwItem_RunWorkerCompleted);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btClose);
            this.panelControl1.Controls.Add(this.btSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(577, 59);
            this.panelControl1.TabIndex = 4;
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
            // frm_ItemEdit9
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 210);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.searchSizesCode);
            this.Controls.Add(this.txtSizesName);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ItemEdit9";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รหัสสินค้า-ขนาด/หน่วยนับ [แก้ไข]";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ItemEdit9_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.searchSizesCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizesName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizeInner.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizeOutside.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizeThick.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SearchLookUpEdit searchSizesCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraEditors.TextEdit txtSizesName;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit txtSizeInner;
        private DevExpress.XtraEditors.TextEdit txtSizeOutside;
        private DevExpress.XtraEditors.TextEdit txtSizeThick;
        private System.ComponentModel.BackgroundWorker bwItem;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btClose;
    private DevExpress.XtraEditors.SimpleButton btSave;
  }
}
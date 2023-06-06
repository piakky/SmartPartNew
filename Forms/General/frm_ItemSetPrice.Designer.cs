namespace SmartPart.Forms.General
{
    partial class frm_ItemSetPrice
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
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.bwItem = new System.ComponentModel.BackgroundWorker();
            this.spinPrice1 = new DevExpress.XtraEditors.SpinEdit();
            this.spinPrice2 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sluUnit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinPrice1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPrice2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btClose);
            this.panelControl1.Controls.Add(this.btSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(453, 70);
            this.panelControl1.TabIndex = 0;
            // 
            // btClose
            // 
            this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btClose.Appearance.Options.UseFont = true;
            this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.btClose.Location = new System.Drawing.Point(148, 9);
            this.btClose.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(135, 55);
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
            this.btSave.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(135, 55);
            this.btSave.TabIndex = 1;
            this.btSave.Text = "บันทึก (F2)";
            this.btSave.ToolTip = "บันทึก = F2";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(53, 118);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(47, 19);
            this.labelControl12.TabIndex = 15;
            this.labelControl12.Text = "ราคา 2";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(53, 87);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 19);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "ราคา 1";
            // 
            // bwItem
            // 
            this.bwItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwItem_DoWork);
            this.bwItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwItem_RunWorkerCompleted);
            // 
            // spinPrice1
            // 
            this.spinPrice1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinPrice1.EnterMoveNextControl = true;
            this.spinPrice1.Location = new System.Drawing.Point(119, 84);
            this.spinPrice1.Margin = new System.Windows.Forms.Padding(4);
            this.spinPrice1.Name = "spinPrice1";
            this.spinPrice1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinPrice1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.spinPrice1.Properties.Appearance.Options.UseBackColor = true;
            this.spinPrice1.Properties.Appearance.Options.UseFont = true;
            this.spinPrice1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinPrice1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinPrice1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.spinPrice1.Size = new System.Drawing.Size(310, 26);
            this.spinPrice1.TabIndex = 14;
            // 
            // spinPrice2
            // 
            this.spinPrice2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinPrice2.EnterMoveNextControl = true;
            this.spinPrice2.Location = new System.Drawing.Point(119, 115);
            this.spinPrice2.Margin = new System.Windows.Forms.Padding(4);
            this.spinPrice2.Name = "spinPrice2";
            this.spinPrice2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinPrice2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.spinPrice2.Properties.Appearance.Options.UseBackColor = true;
            this.spinPrice2.Properties.Appearance.Options.UseFont = true;
            this.spinPrice2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinPrice2.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinPrice2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.spinPrice2.Size = new System.Drawing.Size(310, 26);
            this.spinPrice2.TabIndex = 17;
            this.spinPrice2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.spinPrice2_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(43, 151);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 19);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "หน่วยนับ";
            // 
            // sluUnit
            // 
            this.sluUnit.EnterMoveNextControl = true;
            this.sluUnit.Location = new System.Drawing.Point(119, 148);
            this.sluUnit.Name = "sluUnit";
            this.sluUnit.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.sluUnit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.sluUnit.Properties.Appearance.Options.UseBackColor = true;
            this.sluUnit.Properties.Appearance.Options.UseFont = true;
            this.sluUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sluUnit.Properties.NullText = "";
            this.sluUnit.Properties.View = this.searchLookUpEdit1View;
            this.sluUnit.Size = new System.Drawing.Size(133, 26);
            this.sluUnit.TabIndex = 30;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // frm_ItemSetPrice
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 186);
            this.Controls.Add(this.sluUnit);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.spinPrice1);
            this.Controls.Add(this.spinPrice2);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_ItemSetPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ราคาขาย";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ItemEdit4_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinPrice1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPrice2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.ComponentModel.BackgroundWorker bwItem;
        private DevExpress.XtraEditors.SpinEdit spinPrice1;
        private DevExpress.XtraEditors.SpinEdit spinPrice2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        internal DevExpress.XtraEditors.SearchLookUpEdit sluUnit;
    }
}
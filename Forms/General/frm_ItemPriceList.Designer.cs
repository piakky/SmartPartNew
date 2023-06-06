namespace SmartPart.Forms.General
{
    partial class frm_ItemPriceList
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.bwItem = new System.ComponentModel.BackgroundWorker();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.datePrice = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.spinPrice = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datePrice.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPrice.Properties)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(334, 59);
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
            // bwItem
            // 
            this.bwItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwItem_DoWork);
            this.bwItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwItem_RunWorkerCompleted);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(27, 104);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(89, 19);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "วันที่ราคาใหม่";
            // 
            // datePrice
            // 
            this.datePrice.EditValue = null;
            this.datePrice.EnterMoveNextControl = true;
            this.datePrice.Location = new System.Drawing.Point(122, 101);
            this.datePrice.Name = "datePrice";
            this.datePrice.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.datePrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.datePrice.Properties.Appearance.Options.UseBackColor = true;
            this.datePrice.Properties.Appearance.Options.UseFont = true;
            this.datePrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePrice.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePrice.Size = new System.Drawing.Size(133, 26);
            this.datePrice.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(56, 71);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 19);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "ราคาใหม่";
            // 
            // spinPrice
            // 
            this.spinPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinPrice.EnterMoveNextControl = true;
            this.spinPrice.Location = new System.Drawing.Point(122, 68);
            this.spinPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinPrice.Name = "spinPrice";
            this.spinPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinPrice.Properties.Appearance.Options.UseFont = true;
            this.spinPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, editorButtonImageOptions1)});
            this.spinPrice.Properties.DisplayFormat.FormatString = "n2";
            this.spinPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinPrice.Properties.EditFormat.FormatString = "n2";
            this.spinPrice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinPrice.Properties.Mask.EditMask = "n2";
            this.spinPrice.Properties.MaxLength = 16;
            this.spinPrice.Properties.MaxValue = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.spinPrice.Size = new System.Drawing.Size(133, 26);
            this.spinPrice.TabIndex = 1;
            // 
            // frm_ItemPriceList
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 142);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.datePrice);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.spinPrice);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ItemPriceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รหัสสินค้า-Price list [แก้ไข]";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ItemPriceList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datePrice.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPrice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private System.ComponentModel.BackgroundWorker bwItem;
    private DevExpress.XtraEditors.LabelControl labelControl6;
    internal DevExpress.XtraEditors.DateEdit datePrice;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    internal DevExpress.XtraEditors.SpinEdit spinPrice;
  }
}
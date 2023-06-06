namespace SmartPart.Forms.General
{
    partial class frm_ItemEdit3
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
            this.spinQtyMax = new DevExpress.XtraEditors.SpinEdit();
            this.spinQtymin = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.spinQtyMinSale = new DevExpress.XtraEditors.SpinEdit();
            this.spinQtyMinOrder = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.spCountCar = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.bwItem = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinQtyMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQtymin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQtyMinSale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQtyMinOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCountCar.Properties)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(464, 59);
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
            // spinQtyMax
            // 
            this.spinQtyMax.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinQtyMax.EnterMoveNextControl = true;
            this.spinQtyMax.Location = new System.Drawing.Point(94, 100);
            this.spinQtyMax.Name = "spinQtyMax";
            this.spinQtyMax.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.spinQtyMax.Properties.Appearance.Options.UseFont = true;
            this.spinQtyMax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinQtyMax.Size = new System.Drawing.Size(100, 22);
            this.spinQtyMax.TabIndex = 15;
            // 
            // spinQtymin
            // 
            this.spinQtymin.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinQtymin.EnterMoveNextControl = true;
            this.spinQtymin.Location = new System.Drawing.Point(94, 75);
            this.spinQtymin.Name = "spinQtymin";
            this.spinQtymin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.spinQtymin.Properties.Appearance.Options.UseFont = true;
            this.spinQtymin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinQtymin.Size = new System.Drawing.Size(100, 22);
            this.spinQtymin.TabIndex = 13;
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl19.Appearance.Options.UseFont = true;
            this.labelControl19.Location = new System.Drawing.Point(12, 103);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(76, 17);
            this.labelControl19.TabIndex = 14;
            this.labelControl19.Text = "ปริมาณสูงสุด";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.Location = new System.Drawing.Point(12, 78);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(76, 17);
            this.labelControl18.TabIndex = 12;
            this.labelControl18.Text = "ปริมาณต่ำสุด";
            // 
            // spinQtyMinSale
            // 
            this.spinQtyMinSale.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinQtyMinSale.EnterMoveNextControl = true;
            this.spinQtyMinSale.Location = new System.Drawing.Point(352, 100);
            this.spinQtyMinSale.Name = "spinQtyMinSale";
            this.spinQtyMinSale.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.spinQtyMinSale.Properties.Appearance.Options.UseFont = true;
            this.spinQtyMinSale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinQtyMinSale.Size = new System.Drawing.Size(100, 22);
            this.spinQtyMinSale.TabIndex = 19;
            // 
            // spinQtyMinOrder
            // 
            this.spinQtyMinOrder.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinQtyMinOrder.EnterMoveNextControl = true;
            this.spinQtyMinOrder.Location = new System.Drawing.Point(352, 75);
            this.spinQtyMinOrder.Name = "spinQtyMinOrder";
            this.spinQtyMinOrder.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.spinQtyMinOrder.Properties.Appearance.Options.UseFont = true;
            this.spinQtyMinOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinQtyMinOrder.Size = new System.Drawing.Size(100, 22);
            this.spinQtyMinOrder.TabIndex = 17;
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl22.Appearance.Options.UseFont = true;
            this.labelControl22.Location = new System.Drawing.Point(210, 104);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(136, 17);
            this.labelControl22.TabIndex = 18;
            this.labelControl22.Text = "ปริมาณขั้นต่ำในการขาย";
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl20.Appearance.Options.UseFont = true;
            this.labelControl20.Location = new System.Drawing.Point(200, 78);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(146, 17);
            this.labelControl20.TabIndex = 16;
            this.labelControl20.Text = "ปริมาณขั้นต่ำในการสั่งซื้อ";
            // 
            // spCountCar
            // 
            this.spCountCar.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spCountCar.EnterMoveNextControl = true;
            this.spCountCar.Location = new System.Drawing.Point(352, 125);
            this.spCountCar.Name = "spCountCar";
            this.spCountCar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.spCountCar.Properties.Appearance.Options.UseFont = true;
            this.spCountCar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spCountCar.Size = new System.Drawing.Size(100, 22);
            this.spCountCar.TabIndex = 21;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(216, 128);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(130, 17);
            this.labelControl8.TabIndex = 20;
            this.labelControl8.Text = "จำนวนที่ใช้ต่อรถ 1 คัน";
            // 
            // bwItem
            // 
            this.bwItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwItem_DoWork);
            this.bwItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwItem_RunWorkerCompleted);
            // 
            // frm_ItemEdit3
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 158);
            this.Controls.Add(this.spCountCar);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.spinQtyMinSale);
            this.Controls.Add(this.spinQtyMinOrder);
            this.Controls.Add(this.labelControl22);
            this.Controls.Add(this.labelControl20);
            this.Controls.Add(this.spinQtyMax);
            this.Controls.Add(this.spinQtymin);
            this.Controls.Add(this.labelControl19);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ItemEdit3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รหัสสินค้า-ปริมาณต่ำสุด/สูงสุด [แก้ไข]";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ItemEdit3_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinQtyMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQtymin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQtyMinSale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQtyMinOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCountCar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.SpinEdit spinQtyMax;
        private DevExpress.XtraEditors.SpinEdit spinQtymin;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.SpinEdit spinQtyMinSale;
        private DevExpress.XtraEditors.SpinEdit spinQtyMinOrder;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.SpinEdit spCountCar;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.ComponentModel.BackgroundWorker bwItem;
    }
}
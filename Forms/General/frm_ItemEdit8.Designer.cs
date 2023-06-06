namespace SmartPart.Forms.General
{
    partial class frm_ItemEdit8
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
            this.spinQtyCurrent = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spinQtyNew = new DevExpress.XtraEditors.SpinEdit();
            this.bwItem = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinQtyCurrent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQtyNew.Properties)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(403, 59);
            this.panelControl1.TabIndex = 13;
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
            this.btClose.TabIndex = 4;
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
            this.btSave.TabIndex = 3;
            this.btSave.Text = "บันทึก (F2)";
            this.btSave.ToolTip = "บันทึก = F2";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // spinQtyCurrent
            // 
            this.spinQtyCurrent.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinQtyCurrent.EnterMoveNextControl = true;
            this.spinQtyCurrent.Location = new System.Drawing.Point(176, 73);
            this.spinQtyCurrent.Name = "spinQtyCurrent";
            this.spinQtyCurrent.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spinQtyCurrent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.spinQtyCurrent.Properties.Appearance.Options.UseBackColor = true;
            this.spinQtyCurrent.Properties.Appearance.Options.UseFont = true;
            this.spinQtyCurrent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinQtyCurrent.Properties.ReadOnly = true;
            this.spinQtyCurrent.Size = new System.Drawing.Size(100, 28);
            this.spinQtyCurrent.TabIndex = 1;
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl21.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelControl21.Appearance.Options.UseFont = true;
            this.labelControl21.Appearance.Options.UseImageAlign = true;
            this.labelControl21.Location = new System.Drawing.Point(35, 76);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(129, 21);
            this.labelControl21.TabIndex = 14;
            this.labelControl21.Text = "จำนวนสินค้าในคลัง";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseImageAlign = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 102);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(158, 21);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "จำนวนสินค้าในคลังใหม่";
            // 
            // spinQtyNew
            // 
            this.spinQtyNew.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinQtyNew.EnterMoveNextControl = true;
            this.spinQtyNew.Location = new System.Drawing.Point(176, 99);
            this.spinQtyNew.Name = "spinQtyNew";
            this.spinQtyNew.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinQtyNew.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.spinQtyNew.Properties.Appearance.Options.UseBackColor = true;
            this.spinQtyNew.Properties.Appearance.Options.UseFont = true;
            this.spinQtyNew.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinQtyNew.Size = new System.Drawing.Size(100, 28);
            this.spinQtyNew.TabIndex = 0;
            // 
            // bwItem
            // 
            this.bwItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwItem_DoWork);
            this.bwItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwItem_RunWorkerCompleted);
            // 
            // frm_ItemEdit8
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 132);
            this.Controls.Add(this.spinQtyNew);
            this.Controls.Add(this.spinQtyCurrent);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl21);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ItemEdit8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รหัสสินค้า-Stock on hand [แก้ไข]";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ItemEdit8_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinQtyCurrent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQtyNew.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.SpinEdit spinQtyCurrent;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.ComponentModel.BackgroundWorker bwItem;
        internal DevExpress.XtraEditors.SpinEdit spinQtyNew;
    }
}
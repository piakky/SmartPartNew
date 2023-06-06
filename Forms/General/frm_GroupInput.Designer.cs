namespace SmartPart.Forms.General
{
    partial class frm_GroupInput
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
            this.BTcancel = new DevExpress.XtraEditors.SimpleButton();
            this.BTsave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl34 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl33 = new DevExpress.XtraEditors.LabelControl();
            this.txtGroupCode = new DevExpress.XtraEditors.TextEdit();
            this.txtDesc = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.BTcancel);
            this.panelControl1.Controls.Add(this.BTsave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(316, 47);
            this.panelControl1.TabIndex = 2;
            // 
            // BTcancel
            // 
            this.BTcancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.BTcancel.Appearance.Options.UseFont = true;
            this.BTcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTcancel.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.BTcancel.Location = new System.Drawing.Point(103, 6);
            this.BTcancel.Name = "BTcancel";
            this.BTcancel.Size = new System.Drawing.Size(84, 36);
            this.BTcancel.TabIndex = 2;
            this.BTcancel.Text = "ยกเลิก";
            this.BTcancel.ToolTip = "ยกเลิก = ESC";
            this.BTcancel.Click += new System.EventHandler(this.BTcancel_Click);
            // 
            // BTsave
            // 
            this.BTsave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.BTsave.Appearance.Options.UseFont = true;
            this.BTsave.ImageOptions.Image = global::SmartPart.Properties.Resources.page_save;
            this.BTsave.Location = new System.Drawing.Point(5, 5);
            this.BTsave.Name = "BTsave";
            this.BTsave.Size = new System.Drawing.Size(92, 36);
            this.BTsave.TabIndex = 0;
            this.BTsave.Tag = "2";
            this.BTsave.Text = "บันทึก";
            this.BTsave.ToolTip = "บันทึก = F2";
            this.BTsave.Click += new System.EventHandler(this.BTsave_Click);
            // 
            // labelControl34
            // 
            this.labelControl34.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl34.Appearance.Options.UseFont = true;
            this.labelControl34.Location = new System.Drawing.Point(21, 89);
            this.labelControl34.Name = "labelControl34";
            this.labelControl34.Size = new System.Drawing.Size(66, 17);
            this.labelControl34.TabIndex = 8;
            this.labelControl34.Text = "รายละเอียด";
            // 
            // labelControl33
            // 
            this.labelControl33.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl33.Appearance.Options.UseFont = true;
            this.labelControl33.Location = new System.Drawing.Point(28, 61);
            this.labelControl33.Name = "labelControl33";
            this.labelControl33.Size = new System.Drawing.Size(59, 17);
            this.labelControl33.TabIndex = 6;
            this.labelControl33.Text = "กลุ่มสินค้า";
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.EnterMoveNextControl = true;
            this.txtGroupCode.Location = new System.Drawing.Point(93, 58);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtGroupCode.Properties.Appearance.Options.UseFont = true;
            this.txtGroupCode.Size = new System.Drawing.Size(214, 22);
            this.txtGroupCode.TabIndex = 7;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(93, 86);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(214, 76);
            this.txtDesc.TabIndex = 9;
            // 
            // frm_GroupInput
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 174);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.labelControl34);
            this.Controls.Add(this.labelControl33);
            this.Controls.Add(this.txtGroupCode);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_GroupInput";
            this.Text = "frm_GroupInput";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton BTcancel;
        private DevExpress.XtraEditors.SimpleButton BTsave;
        private DevExpress.XtraEditors.LabelControl labelControl34;
        private DevExpress.XtraEditors.LabelControl labelControl33;
        internal DevExpress.XtraEditors.TextEdit txtGroupCode;
        internal DevExpress.XtraEditors.MemoEdit txtDesc;
    }
}
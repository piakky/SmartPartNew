namespace SmartPart.Forms.Code
{
    partial class frmD_Substitute_Sub1
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
      this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.TxtCode = new DevExpress.XtraEditors.TextEdit();
      this.TxtDesc = new DevExpress.XtraEditors.TextEdit();
      this.TxtName = new DevExpress.XtraEditors.TextEdit();
      this.searchLookUpProduct = new DevExpress.XtraEditors.SearchLookUpEdit();
      this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.btClose = new DevExpress.XtraEditors.SimpleButton();
      this.btReset = new DevExpress.XtraEditors.SimpleButton();
      this.btSave = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtCode.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtDesc.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProduct.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.TxtCode);
      this.panelControl2.Controls.Add(this.TxtDesc);
      this.panelControl2.Controls.Add(this.TxtName);
      this.panelControl2.Controls.Add(this.searchLookUpProduct);
      this.panelControl2.Controls.Add(this.labelControl4);
      this.panelControl2.Controls.Add(this.labelControl3);
      this.panelControl2.Controls.Add(this.labelControl2);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl2.Location = new System.Drawing.Point(0, 48);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(584, 106);
      this.panelControl2.TabIndex = 0;
      // 
      // TxtCode
      // 
      this.TxtCode.EnterMoveNextControl = true;
      this.TxtCode.Location = new System.Drawing.Point(451, 6);
      this.TxtCode.Name = "TxtCode";
      this.TxtCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.TxtCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtCode.Properties.Appearance.Options.UseBackColor = true;
      this.TxtCode.Properties.Appearance.Options.UseFont = true;
      this.TxtCode.Properties.ReadOnly = true;
      this.TxtCode.Size = new System.Drawing.Size(121, 26);
      this.TxtCode.TabIndex = 8;
      this.TxtCode.Visible = false;
      // 
      // TxtDesc
      // 
      this.TxtDesc.EnterMoveNextControl = true;
      this.TxtDesc.Location = new System.Drawing.Point(234, 70);
      this.TxtDesc.Name = "TxtDesc";
      this.TxtDesc.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.TxtDesc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtDesc.Properties.Appearance.Options.UseBackColor = true;
      this.TxtDesc.Properties.Appearance.Options.UseFont = true;
      this.TxtDesc.Properties.ReadOnly = true;
      this.TxtDesc.Size = new System.Drawing.Size(338, 26);
      this.TxtDesc.TabIndex = 7;
      // 
      // TxtName
      // 
      this.TxtName.EnterMoveNextControl = true;
      this.TxtName.Location = new System.Drawing.Point(234, 38);
      this.TxtName.Name = "TxtName";
      this.TxtName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.TxtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.TxtName.Properties.Appearance.Options.UseBackColor = true;
      this.TxtName.Properties.Appearance.Options.UseFont = true;
      this.TxtName.Properties.ReadOnly = true;
      this.TxtName.Size = new System.Drawing.Size(211, 26);
      this.TxtName.TabIndex = 5;
      // 
      // searchLookUpProduct
      // 
      this.searchLookUpProduct.EnterMoveNextControl = true;
      this.searchLookUpProduct.Location = new System.Drawing.Point(234, 6);
      this.searchLookUpProduct.Name = "searchLookUpProduct";
      this.searchLookUpProduct.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.searchLookUpProduct.Properties.Appearance.Options.UseFont = true;
      this.searchLookUpProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.searchLookUpProduct.Properties.NullText = "เลือกรหัสกลุ่มสินค้าเฉพาะ 1";
      this.searchLookUpProduct.Properties.View = this.searchLookUpEdit1View;
      this.searchLookUpProduct.Size = new System.Drawing.Size(211, 26);
      this.searchLookUpProduct.TabIndex = 3;
      this.searchLookUpProduct.EditValueChanged += new System.EventHandler(this.searchLookUpProduct_EditValueChanged);
      // 
      // searchLookUpEdit1View
      // 
      this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
      this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
      // 
      // labelControl4
      // 
      this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl4.Appearance.Options.UseFont = true;
      this.labelControl4.Location = new System.Drawing.Point(153, 73);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(75, 19);
      this.labelControl4.TabIndex = 6;
      this.labelControl4.Text = "รายละเอียด";
      // 
      // labelControl3
      // 
      this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl3.Appearance.Options.UseFont = true;
      this.labelControl3.Location = new System.Drawing.Point(23, 41);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(208, 19);
      this.labelControl3.TabIndex = 4;
      this.labelControl3.Text = "ชื่อกลุ่มสินค้าเฉพาะใช้แทนกัน 1";
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.labelControl2.Appearance.Options.UseFont = true;
      this.labelControl2.Location = new System.Drawing.Point(16, 9);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(215, 19);
      this.labelControl2.TabIndex = 2;
      this.labelControl2.Text = "รหัสกลุ่มสินค้าเฉพาะใช้แทนกัน 1";
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.btClose);
      this.panelControl1.Controls.Add(this.btReset);
      this.panelControl1.Controls.Add(this.btSave);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(584, 48);
      this.panelControl1.TabIndex = 1;
      // 
      // btClose
      // 
      this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btClose.Appearance.Options.UseFont = true;
      this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
      this.btClose.Location = new System.Drawing.Point(185, 6);
      this.btClose.Name = "btClose";
      this.btClose.Size = new System.Drawing.Size(83, 36);
      this.btClose.TabIndex = 1;
      this.btClose.Text = "ยกเลิก";
      this.btClose.ToolTip = "ยกเลิก = ESC";
      this.btClose.Click += new System.EventHandler(this.btClose_Click);
      // 
      // btReset
      // 
      this.btReset.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btReset.Appearance.Options.UseFont = true;
      this.btReset.Location = new System.Drawing.Point(96, 6);
      this.btReset.Name = "btReset";
      this.btReset.Size = new System.Drawing.Size(83, 36);
      this.btReset.TabIndex = 2;
      this.btReset.Text = "เริ่มใหม่";
      this.btReset.ToolTip = "เริ่มใหม่ = F3";
      this.btReset.Click += new System.EventHandler(this.btReset_Click);
      // 
      // btSave
      // 
      this.btSave.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btSave.Appearance.Options.UseFont = true;
      this.btSave.ImageOptions.Image = global::SmartPart.Properties.Resources.page_save;
      this.btSave.Location = new System.Drawing.Point(5, 6);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(85, 36);
      this.btSave.TabIndex = 0;
      this.btSave.Text = "บันทึก";
      this.btSave.ToolTip = "บันทึก = F2";
      this.btSave.Click += new System.EventHandler(this.btSave_Click);
      // 
      // frmD_Substitute_Sub1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(584, 154);
      this.Controls.Add(this.panelControl1);
      this.Controls.Add(this.panelControl2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "frmD_Substitute_Sub1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmDSubstitute_Sub1";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmD_ItemSetInput_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtCode.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtDesc.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProduct.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btClose;
    private DevExpress.XtraEditors.SimpleButton btReset;
    private DevExpress.XtraEditors.SimpleButton btSave;
    internal DevExpress.XtraEditors.TextEdit TxtDesc;
    internal DevExpress.XtraEditors.TextEdit TxtName;
    internal DevExpress.XtraEditors.SearchLookUpEdit searchLookUpProduct;
    internal DevExpress.XtraEditors.TextEdit TxtCode;
  }
}
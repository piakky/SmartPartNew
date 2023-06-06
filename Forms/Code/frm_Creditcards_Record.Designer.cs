namespace SmartPart.Forms.Code
{
    partial class frm_Creditcards_Record
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
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TxtBankName = new DevExpress.XtraEditors.TextEdit();
            this.searchLookUpCreditBank = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TxtCreditDesc = new DevExpress.XtraEditors.MemoEdit();
            this.TxtCreditCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.BTcancel = new DevExpress.XtraEditors.SimpleButton();
            this.BTreset = new DevExpress.XtraEditors.SimpleButton();
            this.BTsaveclose = new DevExpress.XtraEditors.SimpleButton();
            this.BTsave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreditBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCreditDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCreditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.TxtBankName);
            this.panelControl2.Controls.Add(this.searchLookUpCreditBank);
            this.panelControl2.Controls.Add(this.TxtCreditDesc);
            this.panelControl2.Controls.Add(this.TxtCreditCode);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 47);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(516, 198);
            this.panelControl2.TabIndex = 0;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(38, 43);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(97, 19);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "ชื่อเต็มธนาคาร";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(40, 75);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(95, 19);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "หมายเลขบัญชี";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(44, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(91, 19);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "ชื่อย่อธนาคาร";
            // 
            // TxtBankName
            // 
            this.TxtBankName.EnterMoveNextControl = true;
            this.TxtBankName.Location = new System.Drawing.Point(141, 40);
            this.TxtBankName.Name = "TxtBankName";
            this.TxtBankName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtBankName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TxtBankName.Properties.Appearance.Options.UseBackColor = true;
            this.TxtBankName.Properties.Appearance.Options.UseFont = true;
            this.TxtBankName.Properties.ReadOnly = true;
            this.TxtBankName.Size = new System.Drawing.Size(363, 26);
            this.TxtBankName.TabIndex = 3;
            // 
            // searchLookUpCreditBank
            // 
            this.searchLookUpCreditBank.EnterMoveNextControl = true;
            this.searchLookUpCreditBank.Location = new System.Drawing.Point(141, 6);
            this.searchLookUpCreditBank.Name = "searchLookUpCreditBank";
            this.searchLookUpCreditBank.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.searchLookUpCreditBank.Properties.Appearance.Options.UseFont = true;
            this.searchLookUpCreditBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpCreditBank.Properties.NullText = "เลือกรหัสธนาคาร";
            this.searchLookUpCreditBank.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpCreditBank.Size = new System.Drawing.Size(149, 26);
            this.searchLookUpCreditBank.TabIndex = 1;
            this.searchLookUpCreditBank.EditValueChanged += new System.EventHandler(this.searchLookUpCreditBank_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // TxtCreditDesc
            // 
            this.TxtCreditDesc.EnterMoveNextControl = true;
            this.TxtCreditDesc.Location = new System.Drawing.Point(141, 104);
            this.TxtCreditDesc.Name = "TxtCreditDesc";
            this.TxtCreditDesc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TxtCreditDesc.Properties.Appearance.Options.UseFont = true;
            this.TxtCreditDesc.Properties.MaxLength = 100;
            this.TxtCreditDesc.Size = new System.Drawing.Size(363, 81);
            this.TxtCreditDesc.TabIndex = 9;
            // 
            // TxtCreditCode
            // 
            this.TxtCreditCode.EnterMoveNextControl = true;
            this.TxtCreditCode.Location = new System.Drawing.Point(141, 72);
            this.TxtCreditCode.Name = "TxtCreditCode";
            this.TxtCreditCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TxtCreditCode.Properties.Appearance.Options.UseFont = true;
            this.TxtCreditCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCreditCode.Properties.MaxLength = 20;
            this.TxtCreditCode.Size = new System.Drawing.Size(363, 26);
            this.TxtCreditCode.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(60, 106);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 19);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "รายละเอียด";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.BTcancel);
            this.panelControl1.Controls.Add(this.BTreset);
            this.panelControl1.Controls.Add(this.BTsaveclose);
            this.panelControl1.Controls.Add(this.BTsave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(516, 47);
            this.panelControl1.TabIndex = 1;
            // 
            // BTcancel
            // 
            this.BTcancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.BTcancel.Appearance.Options.UseFont = true;
            this.BTcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTcancel.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.BTcancel.Location = new System.Drawing.Point(341, 5);
            this.BTcancel.Name = "BTcancel";
            this.BTcancel.Size = new System.Drawing.Size(84, 36);
            this.BTcancel.TabIndex = 2;
            this.BTcancel.Text = "ยกเลิก";
            this.BTcancel.ToolTip = "ยกเลิก = ESC";
            this.BTcancel.Click += new System.EventHandler(this.BTcancel_Click);
            // 
            // BTreset
            // 
            this.BTreset.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.BTreset.Appearance.Options.UseFont = true;
            this.BTreset.Location = new System.Drawing.Point(238, 5);
            this.BTreset.Name = "BTreset";
            this.BTreset.Size = new System.Drawing.Size(97, 36);
            this.BTreset.TabIndex = 1;
            this.BTreset.Text = "เริ่มใหม่";
            this.BTreset.ToolTip = "เริ่มใหม่ = F4";
            this.BTreset.Click += new System.EventHandler(this.BTreset_Click);
            // 
            // BTsaveclose
            // 
            this.BTsaveclose.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.BTsaveclose.Appearance.Options.UseFont = true;
            this.BTsaveclose.ImageOptions.Image = global::SmartPart.Properties.Resources.page_save;
            this.BTsaveclose.Location = new System.Drawing.Point(103, 5);
            this.BTsaveclose.Name = "BTsaveclose";
            this.BTsaveclose.Size = new System.Drawing.Size(130, 36);
            this.BTsaveclose.TabIndex = 0;
            this.BTsaveclose.Tag = "1";
            this.BTsaveclose.Text = "บันทึก/ปิด";
            this.BTsaveclose.ToolTip = "บันทึก/ปิด = F3";
            this.BTsaveclose.Click += new System.EventHandler(this.BTsaveclose_Click);
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
            // frm_Creditcards_Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 245);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_Creditcards_Record";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCategories_Record";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frM_CREDITCARDS_Record_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreditBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCreditDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCreditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton BTcancel;
        private DevExpress.XtraEditors.SimpleButton BTreset;
        private DevExpress.XtraEditors.SimpleButton BTsave;
    internal DevExpress.XtraEditors.MemoEdit TxtCreditDesc;
    internal DevExpress.XtraEditors.TextEdit TxtCreditCode;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    internal DevExpress.XtraEditors.TextEdit TxtBankName;
    internal DevExpress.XtraEditors.SearchLookUpEdit searchLookUpCreditBank;
    private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    private DevExpress.XtraEditors.SimpleButton BTsaveclose;
  }
}
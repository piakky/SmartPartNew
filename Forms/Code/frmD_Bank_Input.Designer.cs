namespace SmartPart.Forms.Code
{
  partial class frmD_Bank_Input
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
      this.btReset = new DevExpress.XtraEditors.SimpleButton();
      this.btSave = new DevExpress.XtraEditors.SimpleButton();
      this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.radioType = new DevExpress.XtraEditors.RadioGroup();
      this.txtAccountName = new DevExpress.XtraEditors.TextEdit();
      this.txtBranchName = new DevExpress.XtraEditors.TextEdit();
      this.txtBankName = new DevExpress.XtraEditors.TextEdit();
      this.txtAccountNo = new DevExpress.XtraEditors.TextEdit();
      this.txtNote = new DevExpress.XtraEditors.TextEdit();
      this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.sluBank = new DevExpress.XtraEditors.SearchLookUpEdit();
      this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtBranchName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAccountNo.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sluBank.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
      this.SuspendLayout();
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.btClose);
      this.panelControl1.Controls.Add(this.btReset);
      this.panelControl1.Controls.Add(this.btSave);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(628, 48);
      this.panelControl1.TabIndex = 1;
      // 
      // btClose
      // 
      this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btClose.Appearance.Options.UseFont = true;
      this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
      this.btClose.Location = new System.Drawing.Point(179, 7);
      this.btClose.Margin = new System.Windows.Forms.Padding(4);
      this.btClose.Name = "btClose";
      this.btClose.Size = new System.Drawing.Size(83, 36);
      this.btClose.TabIndex = 2;
      this.btClose.Text = "ยกเลิก";
      this.btClose.ToolTip = "ยกเลิก = ESC";
      this.btClose.Click += new System.EventHandler(this.btClose_Click);
      // 
      // btReset
      // 
      this.btReset.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btReset.Appearance.Options.UseFont = true;
      this.btReset.Location = new System.Drawing.Point(93, 7);
      this.btReset.Margin = new System.Windows.Forms.Padding(4);
      this.btReset.Name = "btReset";
      this.btReset.Size = new System.Drawing.Size(83, 36);
      this.btReset.TabIndex = 1;
      this.btReset.Text = "เริ่มใหม่";
      this.btReset.ToolTip = "เริ่มใหม่ = F3";
      this.btReset.Click += new System.EventHandler(this.btReset_Click);
      // 
      // btSave
      // 
      this.btSave.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btSave.Appearance.Options.UseFont = true;
      this.btSave.ImageOptions.Image = global::SmartPart.Properties.Resources.page_save;
      this.btSave.Location = new System.Drawing.Point(8, 7);
      this.btSave.Margin = new System.Windows.Forms.Padding(4);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(83, 36);
      this.btSave.TabIndex = 0;
      this.btSave.Text = "บันทึก";
      this.btSave.ToolTip = "บันทึก = F2";
      this.btSave.Click += new System.EventHandler(this.btSave_Click);
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.sluBank);
      this.panelControl2.Controls.Add(this.radioType);
      this.panelControl2.Controls.Add(this.txtAccountName);
      this.panelControl2.Controls.Add(this.txtBranchName);
      this.panelControl2.Controls.Add(this.txtBankName);
      this.panelControl2.Controls.Add(this.txtAccountNo);
      this.panelControl2.Controls.Add(this.txtNote);
      this.panelControl2.Controls.Add(this.labelControl5);
      this.panelControl2.Controls.Add(this.labelControl4);
      this.panelControl2.Controls.Add(this.labelControl3);
      this.panelControl2.Controls.Add(this.labelControl2);
      this.panelControl2.Controls.Add(this.labelControl7);
      this.panelControl2.Controls.Add(this.labelControl1);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl2.Location = new System.Drawing.Point(0, 48);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(628, 137);
      this.panelControl2.TabIndex = 0;
      // 
      // radioType
      // 
      this.radioType.EnterMoveNextControl = true;
      this.radioType.Location = new System.Drawing.Point(104, 77);
      this.radioType.Name = "radioType";
      this.radioType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.radioType.Properties.Appearance.Options.UseFont = true;
      this.radioType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "ออมทรัพย์"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "กระแสรายวัน")});
      this.radioType.Size = new System.Drawing.Size(234, 26);
      this.radioType.TabIndex = 10;
      // 
      // txtAccountName
      // 
      this.txtAccountName.EnterMoveNextControl = true;
      this.txtAccountName.Location = new System.Drawing.Point(403, 53);
      this.txtAccountName.Name = "txtAccountName";
      this.txtAccountName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.txtAccountName.Properties.Appearance.Options.UseFont = true;
      this.txtAccountName.Size = new System.Drawing.Size(215, 22);
      this.txtAccountName.TabIndex = 8;
      // 
      // txtBranchName
      // 
      this.txtBranchName.EnterMoveNextControl = true;
      this.txtBranchName.Location = new System.Drawing.Point(104, 29);
      this.txtBranchName.Name = "txtBranchName";
      this.txtBranchName.Properties.Appearance.BackColor = System.Drawing.Color.White;
      this.txtBranchName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.txtBranchName.Properties.Appearance.Options.UseBackColor = true;
      this.txtBranchName.Properties.Appearance.Options.UseFont = true;
      this.txtBranchName.Size = new System.Drawing.Size(234, 22);
      this.txtBranchName.TabIndex = 4;
      // 
      // txtBankName
      // 
      this.txtBankName.EnterMoveNextControl = true;
      this.txtBankName.Location = new System.Drawing.Point(344, 5);
      this.txtBankName.Name = "txtBankName";
      this.txtBankName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.txtBankName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.txtBankName.Properties.Appearance.Options.UseBackColor = true;
      this.txtBankName.Properties.Appearance.Options.UseFont = true;
      this.txtBankName.Properties.ReadOnly = true;
      this.txtBankName.Size = new System.Drawing.Size(274, 22);
      this.txtBankName.TabIndex = 2;
      // 
      // txtAccountNo
      // 
      this.txtAccountNo.EnterMoveNextControl = true;
      this.txtAccountNo.Location = new System.Drawing.Point(104, 53);
      this.txtAccountNo.Name = "txtAccountNo";
      this.txtAccountNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.txtAccountNo.Properties.Appearance.Options.UseFont = true;
      this.txtAccountNo.Size = new System.Drawing.Size(234, 22);
      this.txtAccountNo.TabIndex = 6;
      // 
      // txtNote
      // 
      this.txtNote.EnterMoveNextControl = true;
      this.txtNote.Location = new System.Drawing.Point(104, 105);
      this.txtNote.Name = "txtNote";
      this.txtNote.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.txtNote.Properties.Appearance.Options.UseFont = true;
      this.txtNote.Size = new System.Drawing.Size(514, 22);
      this.txtNote.TabIndex = 12;
      // 
      // labelControl5
      // 
      this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl5.Appearance.Options.UseFont = true;
      this.labelControl5.Location = new System.Drawing.Point(350, 56);
      this.labelControl5.Name = "labelControl5";
      this.labelControl5.Size = new System.Drawing.Size(47, 17);
      this.labelControl5.TabIndex = 7;
      this.labelControl5.Text = "ชื่อบัญชี";
      // 
      // labelControl4
      // 
      this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl4.Appearance.Options.UseFont = true;
      this.labelControl4.Location = new System.Drawing.Point(43, 108);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(55, 17);
      this.labelControl4.TabIndex = 11;
      this.labelControl4.Text = "หมายเหตุ";
      // 
      // labelControl3
      // 
      this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl3.Appearance.Options.UseFont = true;
      this.labelControl3.Location = new System.Drawing.Point(23, 82);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(75, 17);
      this.labelControl3.TabIndex = 9;
      this.labelControl3.Text = "ประเภทบัญชี";
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl2.Appearance.Options.UseFont = true;
      this.labelControl2.Location = new System.Drawing.Point(35, 56);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(63, 17);
      this.labelControl2.TabIndex = 5;
      this.labelControl2.Text = "เลขที่บัญชี";
      // 
      // labelControl7
      // 
      this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl7.Appearance.Options.UseFont = true;
      this.labelControl7.Location = new System.Drawing.Point(66, 32);
      this.labelControl7.Name = "labelControl7";
      this.labelControl7.Size = new System.Drawing.Size(32, 17);
      this.labelControl7.TabIndex = 3;
      this.labelControl7.Text = "สาขา";
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Location = new System.Drawing.Point(52, 8);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(46, 17);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "ธนาคาร";
      // 
      // sluBank
      // 
      this.sluBank.EditValue = "เลือกรหัสสินค้า";
      this.sluBank.EnterMoveNextControl = true;
      this.sluBank.Location = new System.Drawing.Point(104, 5);
      this.sluBank.Name = "sluBank";
      this.sluBank.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.sluBank.Properties.Appearance.Options.UseFont = true;
      this.sluBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.sluBank.Properties.NullText = "เลือกรหัสธนาคาร";
      this.sluBank.Properties.View = this.gridView2;
      this.sluBank.Size = new System.Drawing.Size(234, 22);
      this.sluBank.TabIndex = 1;
      this.sluBank.EditValueChanged += new System.EventHandler(this.sluBank_EditValueChanged);
      // 
      // gridView2
      // 
      this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gridView2.Name = "gridView2";
      this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridView2.OptionsView.ShowGroupPanel = false;
      // 
      // frmD_Bank_Input
      // 
      this.Appearance.Options.UseFont = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(628, 185);
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl1);
      this.Font = new System.Drawing.Font("Tahoma", 12F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "frmD_Bank_Input";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmD_Bank_Input";
      this.Load += new System.EventHandler(this.frmD_Bank_Input_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmD_Bank_Input_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtBranchName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAccountNo.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sluBank.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btClose;
    private DevExpress.XtraEditors.SimpleButton btReset;
    private DevExpress.XtraEditors.SimpleButton btSave;
    private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    internal DevExpress.XtraEditors.TextEdit txtAccountNo;
    internal DevExpress.XtraEditors.TextEdit txtNote;
    internal DevExpress.XtraEditors.TextEdit txtAccountName;
    internal DevExpress.XtraEditors.TextEdit txtBranchName;
    internal DevExpress.XtraEditors.TextEdit txtBankName;
    internal DevExpress.XtraEditors.RadioGroup radioType;
    private DevExpress.XtraEditors.LabelControl labelControl7;
    internal DevExpress.XtraEditors.SearchLookUpEdit sluBank;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
  }
}
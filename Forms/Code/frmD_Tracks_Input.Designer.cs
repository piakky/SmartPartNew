namespace SmartPart.Forms.Code
{
  partial class frmD_Tracks_Input
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
      this.dateTrack = new DevExpress.XtraEditors.DateEdit();
      this.sluUser = new DevExpress.XtraEditors.SearchLookUpEdit();
      this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.txtNote = new DevExpress.XtraEditors.TextEdit();
      this.txtName = new DevExpress.XtraEditors.TextEdit();
      this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.btClose = new DevExpress.XtraEditors.SimpleButton();
      this.btReset = new DevExpress.XtraEditors.SimpleButton();
      this.btSave = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dateTrack.Properties.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dateTrack.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sluUser.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.dateTrack);
      this.panelControl2.Controls.Add(this.sluUser);
      this.panelControl2.Controls.Add(this.txtNote);
      this.panelControl2.Controls.Add(this.txtName);
      this.panelControl2.Controls.Add(this.labelControl6);
      this.panelControl2.Controls.Add(this.labelControl2);
      this.panelControl2.Controls.Add(this.labelControl1);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl2.Location = new System.Drawing.Point(0, 48);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(619, 85);
      this.panelControl2.TabIndex = 7;
      // 
      // dateTrack
      // 
      this.dateTrack.EditValue = null;
      this.dateTrack.Location = new System.Drawing.Point(105, 5);
      this.dateTrack.Name = "dateTrack";
      this.dateTrack.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.dateTrack.Properties.Appearance.Options.UseFont = true;
      this.dateTrack.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.dateTrack.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.dateTrack.Size = new System.Drawing.Size(212, 22);
      this.dateTrack.TabIndex = 3;
      // 
      // sluUser
      // 
      this.sluUser.Location = new System.Drawing.Point(105, 29);
      this.sluUser.Name = "sluUser";
      this.sluUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.sluUser.Properties.Appearance.Options.UseFont = true;
      this.sluUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.sluUser.Properties.NullText = "เลือกรหัสผู้ติดตาม";
      this.sluUser.Properties.View = this.searchLookUpEdit1View;
      this.sluUser.Size = new System.Drawing.Size(212, 22);
      this.sluUser.TabIndex = 2;
      this.sluUser.EditValueChanged += new System.EventHandler(this.sluUser_EditValueChanged);
      // 
      // searchLookUpEdit1View
      // 
      this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
      this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
      // 
      // txtNote
      // 
      this.txtNote.Location = new System.Drawing.Point(105, 53);
      this.txtNote.Name = "txtNote";
      this.txtNote.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.txtNote.Properties.Appearance.Options.UseFont = true;
      this.txtNote.Size = new System.Drawing.Size(499, 22);
      this.txtNote.TabIndex = 1;
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(323, 29);
      this.txtName.Name = "txtName";
      this.txtName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.txtName.Properties.Appearance.Options.UseBackColor = true;
      this.txtName.Properties.Appearance.Options.UseFont = true;
      this.txtName.Properties.ReadOnly = true;
      this.txtName.Size = new System.Drawing.Size(281, 22);
      this.txtName.TabIndex = 1;
      // 
      // labelControl6
      // 
      this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl6.Appearance.Options.UseFont = true;
      this.labelControl6.Location = new System.Drawing.Point(15, 56);
      this.labelControl6.Name = "labelControl6";
      this.labelControl6.Size = new System.Drawing.Size(84, 17);
      this.labelControl6.TabIndex = 0;
      this.labelControl6.Text = "รายการติดตาม";
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl2.Appearance.Options.UseFont = true;
      this.labelControl2.Location = new System.Drawing.Point(48, 32);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(51, 17);
      this.labelControl2.TabIndex = 0;
      this.labelControl2.Text = "ผู้ติดตาม";
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Location = new System.Drawing.Point(73, 8);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(26, 17);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "วันที่";
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
      this.panelControl1.Size = new System.Drawing.Size(619, 48);
      this.panelControl1.TabIndex = 6;
      // 
      // btClose
      // 
      this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.btClose.Appearance.Options.UseFont = true;
      this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
      this.btClose.Location = new System.Drawing.Point(177, 7);
      this.btClose.Margin = new System.Windows.Forms.Padding(4);
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
      this.btReset.Location = new System.Drawing.Point(92, 7);
      this.btReset.Margin = new System.Windows.Forms.Padding(4);
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
      this.btSave.Location = new System.Drawing.Point(8, 7);
      this.btSave.Margin = new System.Windows.Forms.Padding(4);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(83, 36);
      this.btSave.TabIndex = 0;
      this.btSave.Text = "บันทึก";
      this.btSave.ToolTip = "บันทึก = F2";
      this.btSave.Click += new System.EventHandler(this.btSave_Click);
      // 
      // frmD_Tracks_Input
      // 
      this.Appearance.Options.UseFont = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(619, 133);
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl1);
      this.Font = new System.Drawing.Font("Tahoma", 12F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "frmD_Tracks_Input";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmD_Tracks_Input";
      this.Load += new System.EventHandler(this.frmD_Tracks_Input_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmD_Tracks_Input_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dateTrack.Properties.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dateTrack.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sluUser.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl6;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btClose;
    private DevExpress.XtraEditors.SimpleButton btReset;
    private DevExpress.XtraEditors.SimpleButton btSave;
    private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    internal DevExpress.XtraEditors.TextEdit txtNote;
    internal DevExpress.XtraEditors.TextEdit txtName;
    internal DevExpress.XtraEditors.DateEdit dateTrack;
    internal DevExpress.XtraEditors.SearchLookUpEdit sluUser;
  }
}
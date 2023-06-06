namespace SmartPart.Forms.Sale
{
  partial class frm_PayInput
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.radioType = new DevExpress.XtraEditors.RadioGroup();
            this.spinAmount = new DevExpress.XtraEditors.SpinEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.sluCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutType = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(499, 59);
            this.panelControl1.TabIndex = 51;
            // 
            // btClose
            // 
            this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btClose.Appearance.Options.UseFont = true;
            this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.btClose.Location = new System.Drawing.Point(129, 9);
            this.btClose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(110, 46);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "ยกเลิก";
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
            this.btSave.Size = new System.Drawing.Size(115, 46);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "บันทึก (F2)";
            this.btSave.ToolTip = "บันทึก = F2";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.radioType);
            this.layoutControl1.Controls.Add(this.spinAmount);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.sluCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 59);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(499, 150);
            this.layoutControl1.TabIndex = 52;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // radioType
            // 
            this.radioType.EditValue = true;
            this.radioType.Location = new System.Drawing.Point(94, 42);
            this.radioType.Name = "radioType";
            this.radioType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.radioType.Properties.Appearance.Options.UseFont = true;
            this.radioType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "บัตรเครดิต"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "บัตรเดบิต"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "อื่น")});
            this.radioType.Size = new System.Drawing.Size(376, 29);
            this.radioType.StyleController = this.layoutControl1;
            this.radioType.TabIndex = 4;
            // 
            // spinAmount
            // 
            this.spinAmount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinAmount.Location = new System.Drawing.Point(94, 105);
            this.spinAmount.Name = "spinAmount";
            this.spinAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.spinAmount.Properties.Appearance.Options.UseFont = true;
            this.spinAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinAmount.Properties.DisplayFormat.FormatString = "N2";
            this.spinAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinAmount.Properties.EditFormat.FormatString = "N2";
            this.spinAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinAmount.Size = new System.Drawing.Size(376, 26);
            this.spinAmount.StyleController = this.layoutControl1;
            this.spinAmount.TabIndex = 2;
            this.spinAmount.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spinAmount_MouseUp);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(94, 75);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Size = new System.Drawing.Size(376, 26);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 2;
            // 
            // sluCode
            // 
            this.sluCode.Location = new System.Drawing.Point(94, 12);
            this.sluCode.Name = "sluCode";
            this.sluCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.sluCode.Properties.Appearance.Options.UseFont = true;
            this.sluCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sluCode.Properties.NullText = "";
            this.sluCode.Size = new System.Drawing.Size(376, 26);
            this.sluCode.StyleController = this.layoutControl1;
            this.sluCode.TabIndex = 2;
            this.sluCode.EditValueChanged += new System.EventHandler(this.sluCode_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutCode,
            this.emptySpaceItem1,
            this.layoutName,
            this.layoutPrice,
            this.layoutType});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(482, 153);
            this.Root.TextVisible = false;
            // 
            // layoutCode
            // 
            this.layoutCode.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutCode.AppearanceItemCaption.Options.UseFont = true;
            this.layoutCode.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutCode.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutCode.Control = this.sluCode;
            this.layoutCode.Location = new System.Drawing.Point(0, 0);
            this.layoutCode.Name = "layoutCode";
            this.layoutCode.Size = new System.Drawing.Size(462, 30);
            this.layoutCode.TextSize = new System.Drawing.Size(79, 19);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 123);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(462, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutName
            // 
            this.layoutName.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutName.AppearanceItemCaption.Options.UseFont = true;
            this.layoutName.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutName.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutName.Control = this.txtName;
            this.layoutName.Location = new System.Drawing.Point(0, 63);
            this.layoutName.Name = "layoutName";
            this.layoutName.Size = new System.Drawing.Size(462, 30);
            this.layoutName.Text = "ชื่อ";
            this.layoutName.TextSize = new System.Drawing.Size(79, 19);
            // 
            // layoutPrice
            // 
            this.layoutPrice.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutPrice.AppearanceItemCaption.Options.UseFont = true;
            this.layoutPrice.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutPrice.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutPrice.Control = this.spinAmount;
            this.layoutPrice.Location = new System.Drawing.Point(0, 93);
            this.layoutPrice.Name = "layoutPrice";
            this.layoutPrice.Size = new System.Drawing.Size(462, 30);
            this.layoutPrice.Text = "จำนวนเงิน";
            this.layoutPrice.TextSize = new System.Drawing.Size(79, 19);
            // 
            // layoutType
            // 
            this.layoutType.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutType.AppearanceItemCaption.Options.UseFont = true;
            this.layoutType.Control = this.radioType;
            this.layoutType.Location = new System.Drawing.Point(0, 30);
            this.layoutType.Name = "layoutType";
            this.layoutType.Size = new System.Drawing.Size(462, 33);
            this.layoutType.TextSize = new System.Drawing.Size(79, 19);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // frm_PayInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 209);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_PayInput";
            this.Text = "frm_PayInput";
            this.Load += new System.EventHandler(this.frm_PayInput_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_PayInput_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btClose;
    private DevExpress.XtraEditors.SimpleButton btSave;
    private DevExpress.XtraLayout.LayoutControl layoutControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    private DevExpress.XtraLayout.LayoutControlGroup Root;
    private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    internal DevExpress.XtraEditors.SpinEdit spinAmount;
    internal DevExpress.XtraEditors.TextEdit txtName;
    internal DevExpress.XtraEditors.SearchLookUpEdit sluCode;
    internal DevExpress.XtraLayout.LayoutControlItem layoutCode;
    internal DevExpress.XtraLayout.LayoutControlItem layoutName;
    internal DevExpress.XtraLayout.LayoutControlItem layoutPrice;
        internal DevExpress.XtraEditors.RadioGroup radioType;
        internal DevExpress.XtraLayout.LayoutControlItem layoutType;
    }
}
namespace SmartPart.Forms.General
{
    partial class frm_JOBDetailInput
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
            this.sluLocation = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sluUnit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sluBrand = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sluItem = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtBrandPartId = new DevExpress.XtraEditors.TextEdit();
            this.txtGenuinPartId = new DevExpress.XtraEditors.TextEdit();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.spinQTY = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtModel1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sluLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluBrand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrandPartId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenuinPartId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQTY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel1.Properties)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(527, 59);
            this.panelControl1.TabIndex = 0;
            // 
            // btClose
            // 
            this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btClose.Appearance.Options.UseFont = true;
            this.btClose.ImageOptions.Image = global::SmartPart.Properties.Resources.cancel;
            this.btClose.Location = new System.Drawing.Point(128, 9);
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
            // sluLocation
            // 
            this.sluLocation.EnterMoveNextControl = true;
            this.sluLocation.Location = new System.Drawing.Point(153, 212);
            this.sluLocation.Name = "sluLocation";
            this.sluLocation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sluLocation.Properties.Appearance.Options.UseFont = true;
            this.sluLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sluLocation.Properties.NullText = "";
            //this.sluLocation.Properties.PopupView = this.gridView4;
            this.sluLocation.Size = new System.Drawing.Size(156, 22);
            this.sluLocation.TabIndex = 6;
            // 
            // gridView4
            // 
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // sluUnit
            // 
            this.sluUnit.EnterMoveNextControl = true;
            this.sluUnit.Location = new System.Drawing.Point(153, 296);
            this.sluUnit.Name = "sluUnit";
            this.sluUnit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sluUnit.Properties.Appearance.Options.UseFont = true;
            this.sluUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sluUnit.Properties.NullText = "";
            //this.sluUnit.Properties.PopupView = this.gridView3;
            this.sluUnit.Size = new System.Drawing.Size(156, 22);
            this.sluUnit.TabIndex = 9;
            this.sluUnit.EditValueChanged += new System.EventHandler(this.sluUnit_EditValueChanged);
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // sluBrand
            // 
            this.sluBrand.EnterMoveNextControl = true;
            this.sluBrand.Location = new System.Drawing.Point(153, 240);
            this.sluBrand.Name = "sluBrand";
            this.sluBrand.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sluBrand.Properties.Appearance.Options.UseFont = true;
            this.sluBrand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sluBrand.Properties.NullText = "";
            //this.sluBrand.Properties.PopupView = this.gridView2;
            this.sluBrand.Size = new System.Drawing.Size(156, 22);
            this.sluBrand.TabIndex = 7;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // sluItem
            // 
            this.sluItem.EnterMoveNextControl = true;
            this.sluItem.Location = new System.Drawing.Point(153, 72);
            this.sluItem.Name = "sluItem";
            this.sluItem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sluItem.Properties.Appearance.Options.UseFont = true;
            this.sluItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sluItem.Properties.NullText = "";
            //this.sluItem.Properties.PopupView = this.searchLookUpEdit1View;
            this.sluItem.Size = new System.Drawing.Size(156, 22);
            this.sluItem.TabIndex = 1;
            this.sluItem.EditValueChanged += new System.EventHandler(this.sluItem_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtBrandPartId
            // 
            this.txtBrandPartId.EnterMoveNextControl = true;
            this.txtBrandPartId.Location = new System.Drawing.Point(153, 156);
            this.txtBrandPartId.Name = "txtBrandPartId";
            this.txtBrandPartId.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBrandPartId.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtBrandPartId.Properties.Appearance.Options.UseBackColor = true;
            this.txtBrandPartId.Properties.Appearance.Options.UseFont = true;
            this.txtBrandPartId.Properties.ReadOnly = true;
            this.txtBrandPartId.Size = new System.Drawing.Size(358, 22);
            this.txtBrandPartId.TabIndex = 4;
            this.txtBrandPartId.TabStop = false;
            // 
            // txtGenuinPartId
            // 
            this.txtGenuinPartId.EnterMoveNextControl = true;
            this.txtGenuinPartId.Location = new System.Drawing.Point(153, 128);
            this.txtGenuinPartId.Name = "txtGenuinPartId";
            this.txtGenuinPartId.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtGenuinPartId.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtGenuinPartId.Properties.Appearance.Options.UseBackColor = true;
            this.txtGenuinPartId.Properties.Appearance.Options.UseFont = true;
            this.txtGenuinPartId.Properties.ReadOnly = true;
            this.txtGenuinPartId.Size = new System.Drawing.Size(358, 22);
            this.txtGenuinPartId.TabIndex = 3;
            this.txtGenuinPartId.TabStop = false;
            // 
            // txtFullName
            // 
            this.txtFullName.EnterMoveNextControl = true;
            this.txtFullName.Location = new System.Drawing.Point(153, 100);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFullName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFullName.Properties.Appearance.Options.UseBackColor = true;
            this.txtFullName.Properties.Appearance.Options.UseFont = true;
            this.txtFullName.Properties.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(358, 22);
            this.txtFullName.TabIndex = 2;
            this.txtFullName.TabStop = false;
            // 
            // spinQTY
            // 
            this.spinQTY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinQTY.EnterMoveNextControl = true;
            this.spinQTY.Location = new System.Drawing.Point(153, 268);
            this.spinQTY.Name = "spinQTY";
            this.spinQTY.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.spinQTY.Properties.Appearance.Options.UseFont = true;
            this.spinQTY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinQTY.Properties.MaxValue = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.spinQTY.Size = new System.Drawing.Size(76, 22);
            this.spinQTY.TabIndex = 8;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(107, 271);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(40, 17);
            this.labelControl9.TabIndex = 44;
            this.labelControl9.Text = "จำนวน";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(88, 215);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(59, 17);
            this.labelControl15.TabIndex = 42;
            this.labelControl15.Text = "คลังสินค้า";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(96, 299);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(51, 17);
            this.labelControl7.TabIndex = 40;
            this.labelControl7.Text = "หน่วยนับ";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(17, 159);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(130, 17);
            this.labelControl6.TabIndex = 39;
            this.labelControl6.Text = "หมายเลขอะไหล่ผู้ผลิต";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(35, 131);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(112, 17);
            this.labelControl5.TabIndex = 38;
            this.labelControl5.Text = "หมายเลขอะไหล่แท้";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(122, 243);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(25, 17);
            this.labelControl4.TabIndex = 37;
            this.labelControl4.Text = "ยี่ห้อ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(132, 187);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(15, 17);
            this.labelControl3.TabIndex = 36;
            this.labelControl3.Text = "รุ่น";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(89, 75);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(58, 17);
            this.labelControl12.TabIndex = 48;
            this.labelControl12.Text = "รหัสสินค้า";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(108, 100);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 17);
            this.labelControl2.TabIndex = 49;
            this.labelControl2.Text = "ชื่อเต็ม";
            // 
            // txtModel1
            // 
            this.txtModel1.EnterMoveNextControl = true;
            this.txtModel1.Location = new System.Drawing.Point(153, 184);
            this.txtModel1.Name = "txtModel1";
            this.txtModel1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtModel1.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtModel1.Properties.Appearance.Options.UseBackColor = true;
            this.txtModel1.Properties.Appearance.Options.UseFont = true;
            this.txtModel1.Properties.ReadOnly = true;
            this.txtModel1.Size = new System.Drawing.Size(358, 22);
            this.txtModel1.TabIndex = 5;
            this.txtModel1.TabStop = false;
            // 
            // frm_JOBDetailInput
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 331);
            this.Controls.Add(this.sluLocation);
            this.Controls.Add(this.sluUnit);
            this.Controls.Add(this.sluBrand);
            this.Controls.Add(this.sluItem);
            this.Controls.Add(this.txtModel1);
            this.Controls.Add(this.txtBrandPartId);
            this.Controls.Add(this.txtGenuinPartId);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.spinQTY);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_JOBDetailInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_JOBDetailInput";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_JOBDetailInput_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sluLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluBrand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrandPartId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenuinPartId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQTY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.SearchLookUpEdit sluLocation;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.SearchLookUpEdit sluUnit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.SearchLookUpEdit sluBrand;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SearchLookUpEdit sluItem;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.TextEdit txtBrandPartId;
        private DevExpress.XtraEditors.TextEdit txtGenuinPartId;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.SpinEdit spinQTY;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtModel1;
    }
}
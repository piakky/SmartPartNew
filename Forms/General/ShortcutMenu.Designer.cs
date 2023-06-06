namespace SmartPart.Forms.General
{
    partial class ShortcutMenu
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
      this.BTmenu1 = new DevExpress.XtraEditors.SimpleButton();
      this.BTmenu2 = new DevExpress.XtraEditors.SimpleButton();
      this.BTmenu3 = new DevExpress.XtraEditors.SimpleButton();
      this.BTmenu4 = new DevExpress.XtraEditors.SimpleButton();
      this.SuspendLayout();
      // 
      // BTmenu1
      // 
      this.BTmenu1.Appearance.BackColor = System.Drawing.Color.Aqua;
      this.BTmenu1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.BTmenu1.Appearance.Options.UseBackColor = true;
      this.BTmenu1.Appearance.Options.UseFont = true;
      this.BTmenu1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
      this.BTmenu1.Dock = System.Windows.Forms.DockStyle.Top;
      this.BTmenu1.Location = new System.Drawing.Point(0, 0);
      this.BTmenu1.Name = "BTmenu1";
      this.BTmenu1.Size = new System.Drawing.Size(502, 55);
      this.BTmenu1.TabIndex = 0;
      this.BTmenu1.Text = "F1 Menu 1 (List, Insert, History)";
      this.BTmenu1.Click += new System.EventHandler(this.BTmenu1_Click);
      // 
      // BTmenu2
      // 
      this.BTmenu2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
      this.BTmenu2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.BTmenu2.Appearance.Options.UseBackColor = true;
      this.BTmenu2.Appearance.Options.UseFont = true;
      this.BTmenu2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
      this.BTmenu2.Dock = System.Windows.Forms.DockStyle.Top;
      this.BTmenu2.Location = new System.Drawing.Point(0, 55);
      this.BTmenu2.Name = "BTmenu2";
      this.BTmenu2.Size = new System.Drawing.Size(502, 55);
      this.BTmenu2.TabIndex = 1;
      this.BTmenu2.Text = "F2 Menu 2 (Product Group 1)";
      this.BTmenu2.Click += new System.EventHandler(this.BTmenu2_Click);
      // 
      // BTmenu3
      // 
      this.BTmenu3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
      this.BTmenu3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.BTmenu3.Appearance.Options.UseBackColor = true;
      this.BTmenu3.Appearance.Options.UseFont = true;
      this.BTmenu3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
      this.BTmenu3.Dock = System.Windows.Forms.DockStyle.Top;
      this.BTmenu3.Location = new System.Drawing.Point(0, 110);
      this.BTmenu3.Name = "BTmenu3";
      this.BTmenu3.Size = new System.Drawing.Size(502, 55);
      this.BTmenu3.TabIndex = 2;
      this.BTmenu3.Text = "F3 Menu 3 (Product Group 2)";
      this.BTmenu3.Click += new System.EventHandler(this.BTmenu3_Click);
      // 
      // BTmenu4
      // 
      this.BTmenu4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      this.BTmenu4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
      this.BTmenu4.Appearance.Options.UseBackColor = true;
      this.BTmenu4.Appearance.Options.UseFont = true;
      this.BTmenu4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
      this.BTmenu4.Dock = System.Windows.Forms.DockStyle.Top;
      this.BTmenu4.Location = new System.Drawing.Point(0, 165);
      this.BTmenu4.Name = "BTmenu4";
      this.BTmenu4.Size = new System.Drawing.Size(502, 55);
      this.BTmenu4.TabIndex = 3;
      this.BTmenu4.Text = "F4 Menu 4";
      // 
      // ShortcutMenu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(502, 220);
      this.ControlBox = false;
      this.Controls.Add(this.BTmenu4);
      this.Controls.Add(this.BTmenu3);
      this.Controls.Add(this.BTmenu2);
      this.Controls.Add(this.BTmenu1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ShortcutMenu";
      this.Text = "Main menu";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShortcutMenu_KeyDown);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ShortcutMenu_KeyUp);
      this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.SimpleButton BTmenu1;
        internal DevExpress.XtraEditors.SimpleButton BTmenu2;
        internal DevExpress.XtraEditors.SimpleButton BTmenu3;
    internal DevExpress.XtraEditors.SimpleButton BTmenu4;
  }
}
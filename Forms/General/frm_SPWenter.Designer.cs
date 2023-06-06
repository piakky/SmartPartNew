namespace SmartPart.Forms.General
{
  partial class frm_SPWenter
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
      this.txtUsername = new DevExpress.XtraEditors.TextEdit();
      this.txtPassword = new DevExpress.XtraEditors.TextEdit();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btOK = new DevExpress.XtraEditors.SimpleButton();
      this.btCancel = new DevExpress.XtraEditors.SimpleButton();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // panelControl1
      // 
      this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
      this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
      this.panelControl1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.panelControl1.Appearance.Options.UseBackColor = true;
      this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.panelControl1.Controls.Add(this.label2);
      this.panelControl1.Controls.Add(this.label1);
      this.panelControl1.Controls.Add(this.txtUsername);
      this.panelControl1.Controls.Add(this.txtPassword);
      this.panelControl1.Location = new System.Drawing.Point(133, 12);
      this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
      this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.panelControl1.LookAndFeel.UseWindowsXPTheme = true;
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(199, 57);
      this.panelControl1.TabIndex = 30;
      // 
      // txtUsername
      // 
      this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtUsername.EditValue = "";
      this.txtUsername.Location = new System.Drawing.Point(81, 3);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Properties.Appearance.ForeColor = System.Drawing.Color.Gray;
      this.txtUsername.Properties.Appearance.Options.UseForeColor = true;
      this.txtUsername.Properties.NullText = "User name";
      this.txtUsername.Size = new System.Drawing.Size(115, 20);
      this.txtUsername.TabIndex = 0;
      this.txtUsername.Tag = "1";
      this.txtUsername.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
      // 
      // txtPassword
      // 
      this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPassword.Location = new System.Drawing.Point(81, 29);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Properties.Appearance.ForeColor = System.Drawing.Color.Gray;
      this.txtPassword.Properties.Appearance.Options.UseForeColor = true;
      this.txtPassword.Properties.NullText = "Password";
      this.txtPassword.Properties.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(115, 20);
      this.txtPassword.TabIndex = 1;
      this.txtPassword.Tag = "2";
      this.txtPassword.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(31, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(36, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "User :";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(60, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Password :";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btOK
      // 
      this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOK.Location = new System.Drawing.Point(133, 83);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(101, 23);
      this.btOK.TabIndex = 0;
      this.btOK.Text = "OK";
      this.btOK.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
      // 
      // btCancel
      // 
      this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancel.Location = new System.Drawing.Point(240, 83);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(92, 23);
      this.btCancel.TabIndex = 1;
      this.btCancel.Text = "Cancel";
      this.btCancel.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::SmartPart.Properties.Resources._1_27_512;
      this.pictureBox1.Location = new System.Drawing.Point(8, 10);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(110, 97);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 33;
      this.pictureBox1.TabStop = false;
      // 
      // frm_SPWenter
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(344, 119);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.btOK);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.panelControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frm_SPWenter";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Enter Password";
      this.TopMost = true;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_SPWenter_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_SPWenter_FormClosed);
      this.Load += new System.EventHandler(this.frm_SPWenter_Load);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.panelControl1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    internal DevExpress.XtraEditors.TextEdit txtUsername;
    internal DevExpress.XtraEditors.TextEdit txtPassword;
    private DevExpress.XtraEditors.SimpleButton btOK;
    private DevExpress.XtraEditors.SimpleButton btCancel;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SmartPart.Forms.General
{
  public partial class ShortcutSortOrder : DevExpress.XtraEditors.XtraForm
  {
    #region "  Properties declaration  "
    int _MainSearch = 0;
    public int MainSearch
    {
        get
        {
            return _MainSearch;
        }
        set { _MainSearch = value; }
    }

    #endregion
    public ShortcutSortOrder()
    {
      InitializeComponent();
      this.KeyPreview = true;
      BTmenu1.GotFocus += new EventHandler(BTmenu1_GotFocus);
      BTmenu2.GotFocus += new EventHandler(BTmenu2_GotFocus);
      BTmenu3.GotFocus += new EventHandler(BTmenu3_GotFocus);
      BTmenu4.GotFocus += new EventHandler(BTmenu4_GotFocus);
      BTmenu5.GotFocus += new EventHandler(BTmenu5_GotFocus);
      BTmenu6.GotFocus += new EventHandler(BTmenu6_GotFocus);
      BTmenu7.GotFocus += new EventHandler(BTmenu7_GotFocus);
      BTmenu8.GotFocus += new EventHandler(BTmenu8_GotFocus);

      BTmenu1.LostFocus += new EventHandler(BTmenu1_LostFocus);
      BTmenu2.LostFocus += new EventHandler(BTmenu2_LostFocus);
      BTmenu3.LostFocus += new EventHandler(BTmenu3_LostFocus);
      BTmenu4.LostFocus += new EventHandler(BTmenu4_LostFocus);
      BTmenu5.LostFocus += new EventHandler(BTmenu5_LostFocus);
      BTmenu6.LostFocus += new EventHandler(BTmenu6_LostFocus);
      BTmenu7.LostFocus += new EventHandler(BTmenu7_LostFocus);
      BTmenu8.LostFocus += new EventHandler(BTmenu8_LostFocus);
    }

    private void BTmenu1_GotFocus(object sender, EventArgs e)
    {
        BTmenu1.Appearance.BackColor = Color.Red;
    }

    private void BTmenu2_GotFocus(object sender, EventArgs e)
    {
        BTmenu2.Appearance.BackColor = Color.Red;
    }

    private void BTmenu3_GotFocus(object sender, EventArgs e)
    {
        BTmenu3.Appearance.BackColor = Color.Red;
    }

    private void BTmenu4_GotFocus(object sender, EventArgs e)
    {
      BTmenu4.Appearance.BackColor = Color.Red;
    }

    private void BTmenu5_GotFocus(object sender, EventArgs e)
    {
      BTmenu5.Appearance.BackColor = Color.Red;
    }

    private void BTmenu6_GotFocus(object sender, EventArgs e)
    {
      BTmenu6.Appearance.BackColor = Color.Red;
    }

    private void BTmenu7_GotFocus(object sender, EventArgs e)
    {
      BTmenu7.Appearance.BackColor = Color.Red;
    }

    private void BTmenu8_GotFocus(object sender, EventArgs e)
    {
      BTmenu8.Appearance.BackColor = Color.Red;
    }

    private void BTmenu1_LostFocus(object sender, EventArgs e)
    {
        BTmenu1.Appearance.BackColor = Color.Aqua;
    }

    private void BTmenu2_LostFocus(object sender, EventArgs e)
    {
        BTmenu2.Appearance.BackColor = Color.Yellow;
    }

    private void BTmenu3_LostFocus(object sender, EventArgs e)
    {
        BTmenu3.Appearance.BackColor = Color.FromArgb(255, 192, 128);
    }

    private void BTmenu4_LostFocus(object sender, EventArgs e)
    {
      BTmenu4.Appearance.BackColor = Color.FromArgb(255, 192, 255);
    }

    private void BTmenu5_LostFocus(object sender, EventArgs e)
    {
      BTmenu5.Appearance.BackColor = Color.FromArgb(192, 192, 255);
    }

    private void BTmenu6_LostFocus(object sender, EventArgs e)
    {
      BTmenu6.Appearance.BackColor = Color.FromArgb(0, 192, 192);
    }

    private void BTmenu7_LostFocus(object sender, EventArgs e)
    {
      BTmenu7.Appearance.BackColor = Color.FromArgb(192, 192, 0);
    }

    private void BTmenu8_LostFocus(object sender, EventArgs e)
    {
      BTmenu8.Appearance.BackColor = Color.FromArgb(128, 255, 128);
    }

    private void ShortcutMenu_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Home:
          _MainSearch = 0;
          break;
        case Keys.Escape:
          _MainSearch = 0;
          this.DialogResult = DialogResult.Cancel;
          this.Close();
          break;
        case Keys.F1:
          _MainSearch = 1;
          this.DialogResult = DialogResult.OK;
          this.Close();
          break;
        case Keys.F2:
          _MainSearch = 2;
          this.DialogResult = DialogResult.OK;
          this.Close();
          break;
        case Keys.F3:
          _MainSearch = 3;
          this.DialogResult = DialogResult.OK;
          this.Close();
          break;
        case Keys.F4:
          _MainSearch = 4;
          this.DialogResult = DialogResult.OK;
          this.Close();
          break;
        case Keys.F5:
          _MainSearch = 5;
          this.DialogResult = DialogResult.OK;
          this.Close();
          break;
        case Keys.F6:
          _MainSearch = 6;
          this.DialogResult = DialogResult.OK;
          this.Close();
          break;
        case Keys.F7:
          _MainSearch = 7;
          this.DialogResult = DialogResult.OK;
          this.Close();
          break;
        case Keys.F8:
          _MainSearch = 8;
          this.DialogResult = DialogResult.OK;
          this.Close();
          break;
      }         
    }

    private void ShortcutMenu_KeyUp(object sender, KeyEventArgs e)
    {
            
    }

    private void BTmenu1_Click(object sender, EventArgs e)
    {
        _MainSearch = 1;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void BTmenu2_Click(object sender, EventArgs e)
    {
        _MainSearch = 2;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void BTmenu3_Click(object sender, EventArgs e)
    {
        _MainSearch = 3;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void BTmenu4_Click(object sender, EventArgs e)
    {
        _MainSearch = 4;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void BTmenu5_Click(object sender, EventArgs e)
    {
        _MainSearch = 5;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void BTmenu6_Click(object sender, EventArgs e)
    {
      _MainSearch = 6;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void BTmenu7_Click(object sender, EventArgs e)
    {
      _MainSearch = 7;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void BTmenu8_Click(object sender, EventArgs e)
    {
      _MainSearch = 8;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}
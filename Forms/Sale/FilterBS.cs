using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SmartPart.Class;

namespace SmartPart.Forms.Sale
{
    public partial class FilterBS : DevExpress.XtraEditors.XtraForm
    {
        #region "  Properties declaration  "
        int _MainCondition = 0;
        public int MainCondition
        {
            get
            {
                return _MainCondition;
            }
            set { _MainCondition = value; }
        }

        #endregion
        public FilterBS()
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
            BTmenu9.GotFocus += new EventHandler(BTmenu9_GotFocus);
            BTmenu10.GotFocus += new EventHandler(BTmenu10_GotFocus);
            BTmenu11.GotFocus += new EventHandler(BTmenu11_GotFocus);
            BTmenu12.GotFocus += new EventHandler(BTmenu12_GotFocus);
            //BTmenu13.GotFocus += new EventHandler(BTmenu13_GotFocus);
            //BTmenu14.GotFocus += new EventHandler(BTmenu14_GotFocus);
            BTmenu15.GotFocus += new EventHandler(BTmenu15_GotFocus);
            BTmenu16.GotFocus += new EventHandler(BTmenu16_GotFocus);
            BTmenu17.GotFocus += new EventHandler(BTmenu17_GotFocus);



            BTmenu1.LostFocus += new EventHandler(BTmenu1_LostFocus);
            BTmenu2.LostFocus += new EventHandler(BTmenu2_LostFocus);
            BTmenu3.LostFocus += new EventHandler(BTmenu3_LostFocus);
            BTmenu4.LostFocus += new EventHandler(BTmenu4_LostFocus);
            BTmenu5.LostFocus += new EventHandler(BTmenu5_LostFocus);
            BTmenu6.LostFocus += new EventHandler(BTmenu6_LostFocus);
            BTmenu7.LostFocus += new EventHandler(BTmenu7_LostFocus);
            BTmenu8.LostFocus += new EventHandler(BTmenu8_LostFocus);
            BTmenu9.LostFocus += new EventHandler(BTmenu9_LostFocus);
            BTmenu10.LostFocus += new EventHandler(BTmenu10_LostFocus);
            BTmenu11.LostFocus += new EventHandler(BTmenu11_LostFocus);
            BTmenu12.LostFocus += new EventHandler(BTmenu12_LostFocus);
            //BTmenu13.LostFocus += new EventHandler(BTmenu13_LostFocus);
            //BTmenu14.LostFocus += new EventHandler(BTmenu14_LostFocus);
            BTmenu15.LostFocus += new EventHandler(BTmenu15_LostFocus);
            BTmenu16.LostFocus += new EventHandler(BTmenu16_LostFocus);
            BTmenu17.LostFocus += new EventHandler(BTmenu17_LostFocus);
        }

        private void BTmenu1_GotFocus(object sender, EventArgs e)
        {
            BTmenu1.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu2_GotFocus(object sender, EventArgs e)
        {
            BTmenu2.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu3_GotFocus(object sender, EventArgs e)
        {
            BTmenu3.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu4_GotFocus(object sender, EventArgs e)
        {
            BTmenu4.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu5_GotFocus(object sender, EventArgs e)
        {
            BTmenu5.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu6_GotFocus(object sender, EventArgs e)
        {
            BTmenu6.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu7_GotFocus(object sender, EventArgs e)
        {
            BTmenu7.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu8_GotFocus(object sender, EventArgs e)
        {
            BTmenu8.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu9_GotFocus(object sender, EventArgs e)
        {
            BTmenu9.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu10_GotFocus(object sender, EventArgs e)
        {
            BTmenu10.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu11_GotFocus(object sender, EventArgs e)
        {
            BTmenu11.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu12_GotFocus(object sender, EventArgs e)
        {
            BTmenu12.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu13_GotFocus(object sender, EventArgs e)
        {
            //BTmenu13.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu14_GotFocus(object sender, EventArgs e)
        {
            //BTmenu14.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu15_GotFocus(object sender, EventArgs e)
        {
            BTmenu15.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu16_GotFocus(object sender, EventArgs e)
        {
            BTmenu16.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu17_GotFocus(object sender, EventArgs e)
        {
            BTmenu17.Appearance.BackColor = Color.Blue;
        }

        private void BTmenu1_LostFocus(object sender, EventArgs e)
        {
            BTmenu1.Appearance.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void BTmenu2_LostFocus(object sender, EventArgs e)
        {
            BTmenu2.Appearance.BackColor = Color.FromArgb(192, 255, 255);
        }

        private void BTmenu3_LostFocus(object sender, EventArgs e)
        {
            BTmenu3.Appearance.BackColor = Color.Aqua;
        }

        private void BTmenu4_LostFocus(object sender, EventArgs e)
        {
            BTmenu4.Appearance.BackColor = Color.Lime;
        }

        private void BTmenu5_LostFocus(object sender, EventArgs e)
        {
            BTmenu5.Appearance.BackColor = Color.Yellow;
        }

        private void BTmenu6_LostFocus(object sender, EventArgs e)
        {
            BTmenu6.Appearance.BackColor = Color.FromArgb(255, 192, 128);
        }

        private void BTmenu7_LostFocus(object sender, EventArgs e)
        {
            BTmenu7.Appearance.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void BTmenu8_LostFocus(object sender, EventArgs e)
        {
            BTmenu8.Appearance.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void BTmenu9_LostFocus(object sender, EventArgs e)
        {
            BTmenu9.Appearance.BackColor = Color.FromArgb(192, 255, 255);
        }

        private void BTmenu10_LostFocus(object sender, EventArgs e)
        {
            BTmenu10.Appearance.BackColor = Color.FromArgb(255, 192, 128);
        }

        private void BTmenu11_LostFocus(object sender, EventArgs e)
        {
            BTmenu11.Appearance.BackColor = Color.FromArgb(255, 192, 128);
        }

        private void BTmenu12_LostFocus(object sender, EventArgs e)
        {
            BTmenu12.Appearance.BackColor = Color.FromArgb(255, 192, 128);
        }

        private void BTmenu13_LostFocus(object sender, EventArgs e)
        {
            //BTmenu13.Appearance.BackColor = Color.FromArgb(255, 192, 128);
        }

        private void BTmenu14_LostFocus(object sender, EventArgs e)
        {
            //BTmenu14.Appearance.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void BTmenu15_LostFocus(object sender, EventArgs e)
        {
            BTmenu15.Appearance.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void BTmenu16_LostFocus(object sender, EventArgs e)
        {
            BTmenu16.Appearance.BackColor = Color.FromArgb(192, 255, 255);
        }

        private void BTmenu17_LostFocus(object sender, EventArgs e)
        {
            BTmenu17.Appearance.BackColor = Color.FromArgb(255, 192, 128);
        }

        private void ShortcutMenu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Home:
                    _MainCondition = 0;
                    break;
                case Keys.Escape:
                    _MainCondition = 0;
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
                        //case Keys.F1:
                        //  _MainCondition = 1;
                        //  this.DialogResult = DialogResult.OK;
                        //  this.Close();
                        //  break;
                        //case Keys.F2:
                        //  _MainCondition = 2;
                        //  this.DialogResult = DialogResult.OK;
                        //  this.Close();
                        //  break;
                        //case Keys.F3:
                        //  _MainCondition = 3;
                        //  this.DialogResult = DialogResult.OK;
                        //  this.Close();
                        //  break;
                        //case Keys.F4:
                        //  _MainCondition = 4;
                        //  this.DialogResult = DialogResult.OK;
                        //  this.Close();
                        //  break;
                        //case Keys.F5:
                        //  _MainCondition = 5;
                        //  this.DialogResult = DialogResult.OK;
                        //  this.Close();
                        //  break;
                        //case Keys.F6:
                        //  _MainCondition = 6;
                        //  this.DialogResult = DialogResult.OK;
                        //  this.Close();
                        //  break;
                        //case Keys.F7:
                        //  _MainCondition = 7;
                        //  this.DialogResult = DialogResult.OK;
                        //  this.Close();
                        //  break;
                        //case Keys.F8:
                        //  _MainCondition = 8;
                        //  this.DialogResult = DialogResult.OK;
                        //  this.Close();
                        //  break;
            }         
        }

        private void ShortcutMenu_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void BTmenu1_Click(object sender, EventArgs e)
        {
            _MainCondition = 1;
            cls_Sales.FilterOption = 1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu2_Click(object sender, EventArgs e)
        {
            _MainCondition = 2;
            cls_Sales.FilterOption = 2;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu3_Click(object sender, EventArgs e)
        {
            _MainCondition = 3;
            cls_Sales.FilterOption = 3;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu4_Click(object sender, EventArgs e)
        {
            _MainCondition = 4;
            cls_Sales.FilterOption = 4;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu5_Click(object sender, EventArgs e)
        {
            _MainCondition = 5;
            cls_Sales.FilterOption = 5;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu6_Click(object sender, EventArgs e)
        {
            _MainCondition = 6;
            cls_Sales.FilterOption = 6;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu7_Click(object sender, EventArgs e)
        {
            _MainCondition = 7;
            cls_Sales.FilterOption = 7;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu8_Click(object sender, EventArgs e)
        {
            _MainCondition = 8;
            cls_Sales.FilterOption = 8;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu9_Click(object sender, EventArgs e)
        {
            _MainCondition = 9;
            cls_Sales.FilterOption = 9;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu10_Click(object sender, EventArgs e)
        {
            _MainCondition = 10;
            cls_Sales.FilterOption = 10;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu11_Click(object sender, EventArgs e)
        {
            _MainCondition = 11;
            cls_Sales.FilterOption = 11;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu12_Click(object sender, EventArgs e)
        {
            _MainCondition = 12;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu13_Click(object sender, EventArgs e)
        {
            _MainCondition = 13;
            cls_Sales.FilterOption = 13;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu14_Click(object sender, EventArgs e)
        {
            _MainCondition = 14;
            cls_Sales.FilterOption = 14;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu15_Click(object sender, EventArgs e)
        {
            _MainCondition = 15;
            cls_Sales.FilterOption = 15;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu16_Click(object sender, EventArgs e)
        {
            _MainCondition = 16;
            cls_Sales.FilterOption = 16;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTmenu17_Click(object sender, EventArgs e)
        {
            _MainCondition = 17;
            cls_Sales.FilterOption = 17;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
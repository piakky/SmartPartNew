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
    public partial class frm_GroupItem : DevExpress.XtraEditors.XtraForm
    {
        private int GroupType;

        public frm_GroupItem(int Gtype)
        {
            InitializeComponent();
            GroupType = Gtype;
            switch (GroupType)
            {
                case 1://กลุ่มสินค้าใช้ด้วยกัน

                    break;
                case 2://กลุ่มสินค้าใช้แทนกัน
                    break;
                case 3://กลุ่มสินค้าเอนกประสงค์
                    break;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
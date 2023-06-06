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

namespace SmartPart.Forms.Code
{
    public partial class frmD_UnitInput : DevExpress.XtraEditors.XtraForm
    {
        #region "  Variables declaration  "

        private DataTable _dtUit = null;
        private int _iRow = 0;
        private int _Mode = 0;

        #endregion

        #region "  Properties declaration  "

        public DataTable dtUit
        {
            get
            {
            return _dtUit;
            }
            set { _dtUit = value; }
        }

        public int iRow
        {
            get
            {
            return _iRow;
            }
            set { _iRow = value; }
        }

        public int Mode
        {
            get
            {
            return _Mode;
            }
            set { _Mode = value; }
        }

        #endregion

        public frmD_UnitInput()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void searchLookUpEdit1_MouseDown(object sender, MouseEventArgs e)
            {
                //frm_UnitC_List frm = new frm_UnitC_List();
                //frm.ShowDialog();
            }

        private void btSave_Click(object sender, EventArgs e)
        {
            bool err = false;

            if ((searchLookUpUnit.EditValue == null) || (searchLookUpUnit.Text == "เลือกหน่วยนับสินค้า"))
            {
                XtraMessageBox.Show("กรุณาระบุหน่วยนับสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                searchLookUpUnit.ErrorText = "กรุณาระบุหน่วยนับสินค้า";
                searchLookUpUnit.Focus();
                err = true;
                return;
            }

            if (cls_Library.DBDouble(spinQuantity.EditValue) <= 0)
            {
                XtraMessageBox.Show("จำนวนหน่วยย่อยต้องมากกว่า 0", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                spinQuantity.ErrorText = "จำนวนหน่วยย่อยต้องมากกว่า 0";
                spinQuantity.Focus();
                err = true;
                return;
            }

            //ตรวจสอบเงื่อนไข
            //string Xcode = "";
            //double Xquan = 0;
            //bool Xbuy = false;
            //bool Xsale = false;
            //bool UnitOK = false;

            //if (_Mode == 0)
            //{
            //    //ตรวจสอบรหัส
            //    for (int i = 0; i < _dtUit.Rows.Count; i++)
            //    {
            //        Xcode = cls_Library.DBString(_dtUit.Rows[i]["UNIT_NAME"]);
            //        if (Xcode.ToUpper() == TxtUnitName.Text.ToUpper())
            //        {
            //        XtraMessageBox.Show("หน่วยนับสินค้าซ้ำกับที่กำหนดไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        err = true;
            //        return;
            //        }
            //    }

            //    //ตรวจสอบจำนวน
            //    for (int i = 0; i < _dtUit.Rows.Count; i++)
            //    {
            //        Xquan = cls_Library.DBDouble(_dtUit.Rows[i]["MULTIPLY_QTY"]);
            //        if (Xquan == cls_Library.DBInt(spinQuantity.EditValue))
            //        {
            //        XtraMessageBox.Show("จำนวนหน่วยซ้ำกับที่กำหนดไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        err = true;
            //        return;
            //        }
            //    }

            //    //หน่วยซื้อ
            //    if (checkBuy.Checked == true)
            //    {
            //        for (int i = 0; i < _dtUit.Rows.Count; i++)
            //        {
            //            Xbuy = cls_Library.DBbool(_dtUit.Rows[i]["BUY_STATUS"]);
            //            if (Xbuy)
            //            {
            //                XtraMessageBox.Show("มีการกำหนดหน่วยซื้อไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                err = true;
            //                return;
            //            }
            //        }
            //    }

            //    //หน่วยขาย
            //    if (checkSale.Checked == true)
            //    {
            //        for (int i = 0; i < _dtUit.Rows.Count; i++)
            //        {
            //            Xsale = cls_Library.DBbool(_dtUit.Rows[i]["SALE_STATUS"]);
            //            if (Xsale)
            //            {
            //                XtraMessageBox.Show("มีการกำหนดหน่วยขายไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                err = true;
            //                return;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    //ตรวจสอบรหัส
            //    for (int i = 0; i < _dtUit.Rows.Count; i++)
            //    {
            //        Xcode = cls_Library.DBString(_dtUit.Rows[i]["UNIT_NAME"]);
            //        if ((Xcode.ToUpper() == TxtUnitName.Text.ToUpper()) && (i+1 !=_iRow))
            //        {
            //            XtraMessageBox.Show("หน่วยนับสินค้าซ้ำกับที่กำหนดไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            err = true;
            //            return;
            //        }
            //    }

            //    //ตรวจสอบจำนวน
            //    for (int i = 0; i < _dtUit.Rows.Count; i++)
            //    {
            //        Xquan = cls_Library.DBDouble(_dtUit.Rows[i]["MULTIPLY_QTY"]);
            //        if ((Xquan == cls_Library.DBInt(spinQuantity.EditValue)) && (i + 1 != _iRow))
            //        {
            //        XtraMessageBox.Show("จำนวนหน่วยซ้ำกับที่กำหนดไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        err = true;
            //        return;
            //        }
            //    }

            //    //หน่วยซื้อ
            //    if (checkBuy.Checked == true)
            //    {
            //        for (int i = 0; i < _dtUit.Rows.Count; i++)
            //        {
            //        Xbuy = cls_Library.DBbool(_dtUit.Rows[i]["BUY_STATUS"]);
            //        if ((Xbuy) && (i + 1 != _iRow))
            //        {
            //            XtraMessageBox.Show("มีการกำหนดหน่วยซื้อไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            err = true;
            //            return;
            //        }
            //        }
            //    }

            //    //หน่วยขาย
            //    if (checkSale.Checked == true)
            //    {
            //        for (int i = 0; i < _dtUit.Rows.Count; i++)
            //        {
            //            Xsale = cls_Library.DBbool(_dtUit.Rows[i]["SALE_STATUS"]);
            //            if ((Xsale) && (i + 1 != _iRow))
            //            {
            //                XtraMessageBox.Show("มีการกำหนดหน่วยขายไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                err = true;
            //                return;
            //            }
            //        }
            //    }
            //}

            ////ตรวจสอบหน่วยซื้อ/ขาย
            //bool xSale = false;
            //bool xBuy = false;

            //bool SB = false;

            ////หน่วยซื้อ
            //for (int i = 0; i < _dtUit.Rows.Count; i++)
            //{
            //    xBuy = cls_Library.DBbool(_dtUit.Rows[i]["BUY_STATUS"]);
            //    if ((xBuy) && (i + 1 != _iRow))
            //    {
            //        SB = true;
            //    }
            //}
            //if (!SB)
            //{
            //    if (checkBuy.CheckState == CheckState.Unchecked)
            //    {
            //        XtraMessageBox.Show("ไม่มีการกำหนดหน่วยซื้อ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        err = true;
            //        return;
            //    }
            //}

            ////หน่วยขาย
            //SB = false;
            //for (int i = 0; i < _dtUit.Rows.Count; i++)
            //{
            //    xSale = cls_Library.DBbool(_dtUit.Rows[i]["SALE_STATUS"]);
            //    if ((xSale) && (i + 1 != _iRow))
            //    {
            //        SB = true;
            //    }
            //}
            //if (!SB)
            //{
            //    if (checkSale.CheckState == CheckState.Unchecked)
            //    {
            //        XtraMessageBox.Show("ไม่มีการกำหนดหน่วยขาย", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        err = true;
            //        return;
            //    }
            //}

            ////ตรวจสอบจำนวนหน่อยย่อย
            //UnitOK = false;
            //for (int i = 0; i < _dtUit.Rows.Count; i++)
            //{
            //    Xquan = cls_Library.DBDouble(_dtUit.Rows[i]["MULTIPLY_QTY"]);
            //    if ((Xquan == 1) && (i + 1 != _iRow))
            //    {
            //        UnitOK = true;
            //    }
            //}
            //if (!UnitOK)
            //{
            //    if (cls_Library.DBDouble(spinQuantity.EditValue) != 1)
            //    {
            //        XtraMessageBox.Show("ไม่มีการกำหนดหน่วยย่อยเท่ากับ 1", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        err = true;
            //        return;
            //    }              
            //}



            if (err)
            {
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            searchLookUpUnit.EditValue = null;
            TxtUnitName.Text = "";
            spinQuantity.EditValue = 0;
            checkDigit.Checked = false;
            checkBuy.Checked = false;
            checkSale.Checked = false;
        }

        private void searchLookUpUnit_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
            TxtUnitName.Text = cls_Data.GetNameFromTBname(id, "UNITS", "UNIT_NAME");
            }
        }

        private void frmD_UnitInput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
            case Keys.F2:
                btSave_Click(sender, e);
                break;
            case Keys.F3:
                btReset_Click(sender, e);
                break;
            case Keys.Escape:
                btClose_Click(sender, e);
                break;
            }
        }
    } 
}
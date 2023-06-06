﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SmartPart.Class;
using SmartPart.Forms.General;

namespace SmartPart.Forms.Sale
{
    public partial class frm_AddQuantity : DevExpress.XtraEditors.XtraForm
    {
        private delegate void SetDisplayDelegate();

        #region Variable
        private DataTable dtCus = new DataTable();
        private DataTable dtPer = new DataTable();
        private int IdCus = 0;
        private int IdPer = 0;
        bool UserOK = false;
        double quantity;

        #endregion

        #region Properties
        public int CUS_ID
        {
            get { return IdCus; }
            set { IdCus = value; }
        }

        public double Qquantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        #endregion

        #region Function

        private void LoadData()
        {
            //dtCus = cls_Data.GetDataTable("M_CUSTOMERS");
            //dtPer = cls_Data.GetDataTable("M_PERSONALS");
        }

        #endregion

        public frm_AddQuantity()
        {
            InitializeComponent();
            KeyPreview = true;
            spintQuantity.Select();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            quantity = cls_Library.DBDouble(spintQuantity.EditValue);
            if (quantity <= 0) quantity = 1;
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void spintQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmdOK.PerformClick();
            }
        }

        private void frm_AddQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    cmdOK.PerformClick();
                    break;
                case Keys.Escape:
                    cmdClose.PerformClick();
                    break;
            }
        }
    }
}
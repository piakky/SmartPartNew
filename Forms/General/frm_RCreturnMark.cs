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

namespace SmartPart.Forms.General
{
    public partial class frm_RCreturnMark : DevExpress.XtraEditors.XtraForm
    {

      #region variable
      DataTable dtRC = new DataTable();
      private bool IsSaveOK = false;
      int RCD_ID = 0;
      double QtyReturn = 0;
      double Zquan = 0, Zconv = 1;
      #endregion

      #region Property

      public double QTYReturrn
      {
          get { return QtyReturn; }
      }
      #endregion

      #region function

      private void LoadData()
      {
          try
          {
              dtRC = cls_Data.GetMarkDetailRC(RCD_ID);
          }
          catch (Exception ex)
          {
              MessageBox.Show("LoadData: " + ex.Message);
          }
      }

      private void LoadDefaultData()
      {
          try
          {

              comboSelltype.Properties.Items.Add("ปกติ");
              comboSelltype.Properties.Items.Add("เบิกห้าง");
              comboSelltype.Properties.Items.Add("ชดเชย");
              comboSelltype.Properties.Items.Add("Back Order");
              comboSelltype.Properties.Items.Add("สินค้าตัวอย่าง");

              comboVatStatus.Properties.Items.Add("Vat นอก");
              comboVatStatus.Properties.Items.Add("Vat ใน");
              comboVatStatus.Properties.Items.Add("ไม่มี Vat");

              if (!cls_Global_DB.DataInitial.Tables.Contains("M_RETURN_REASONS"))
                  cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_RETURN_REASONS"));

              cls_Library.AssignSearchLookUp(sluItem, "M_ITEMS", "รหัสสินค้า", "ชื่อสินค้า");
              cls_Library.AssignSearchLookUp(sluBrand, "M_BRANDS", "รหัสยี่ห้อ", "ชื่อยี่ห้อ", cls_Global_class.TypeShow.codename);
              cls_Library.AssignSearchLookUp(sluUnit, "M_UNITS", "รหัสหน่วยนับ", "ชื่อหน่วยนับ");
              cls_Library.AssignSearchLookUp(sluReason, "M_RETURN_REASONS", "รหัสเหตุผลการคืน", "เหตุผลการคืน");
          }
          catch (Exception ex)
          {
              XtraMessageBox.Show("LoadDefaultData :" + ex.Message);
          }
      }

      private bool VerifyData()
      {
          bool ret = true;
          StringBuilder msg = new StringBuilder();
          try
          {
              if (sluReason.EditValue == null)
              {
                  ret = false;
                  msg.AppendLine("รหัสเหตุผลไม่ถูกต้อง");
              }

              if (cls_Library.CDouble(spinQTY.EditValue) <= 0)
              {
                  ret = false;
                  msg.AppendLine("ปริมาณต้องมากกว่า 0");
              }

              if (!ret)
              {
                  MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน" + Environment.NewLine + msg, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
          }
          catch (Exception ex)
          {
              XtraMessageBox.Show("VerifyData :" + ex.Message);
          }
          return ret;
      }

      private void SaveData()
      {
        try 
	      {	        
		      IsSaveOK = cls_Data.SaveReturnMark(RCD_ID, Zquan, cls_Library.CInt(sluReason.EditValue));
          if (IsSaveOK)
          {
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            QtyReturn = Zquan; //cls_Library.CDouble(spinQTY.EditValue);
          }
	      }
	      catch (Exception ex)
	      {
          MessageBox.Show("SaveDagta: " + ex.Message);
	      }
        finally
        {
          if(IsSaveOK) btClose_Click(null, null);
        }
      }

      private void SetData()
      {
          try
          {
              if (dtRC.Rows.Count <= 0) return;
                
              DataRow dr = dtRC.Rows[0];
              txtCus.Text = dr["VENDOR_CODE"].ToString();
              txtCategory.Text = dr["ITEM_TYPE"].ToString();
              comboSelltype.SelectedIndex = cls_Library.DBByte(dr["SELL_TYPE"]) - 1;
              txtInvNo.Text = dr["INV_NO"].ToString();
              dateInvNo.EditValue = cls_Library.DBDateTime(dr["INV_DATE"]);
              txtCredit.Text = cls_Library.DBInt(dr["CREDIT_TERM"]).ToString();
              comboVatStatus.SelectedIndex = cls_Library.DBByte(dr["VAT_STATUS"]) - 1;
              sluItem.EditValue = cls_Library.DBInt(dr["ITEM_ID"]);
              sluUnit.EditValue = cls_Library.DBInt(dr["UNIT_ID"]);
              txtFullName.Text = dr["FULL_NAME"].ToString();
              txtGenuinPartId.Text = dr["GENUIN_PART_ID"].ToString();
              txtBrandPartId.Text = dr["BRAND_PART_ID"].ToString();
              txtModel1.Text = dr["MODEL1"].ToString();
              sluBrand.EditValue = cls_Library.DBInt(dr["BRAND_ID"]).ToString();
              Zquan = cls_Library.DBInt(dr["QTY"]) - cls_Library.DBInt(dr["QTY_RETURN"]);
              Zconv = cls_Library.DBDouble(dr["CONV"]);
              spinQTY.Value = cls_Library.CDecimal(Zquan / Zconv);
              sluReason.EditValue = cls_Library.DBInt(dr["RETURN_REASON"]);

              spinQTY.Properties.MaxValue = cls_Library.CDecimal(cls_Library.DBDouble(dr["QTY"]) / Zconv) - cls_Library.CDecimal(cls_Library.DBDouble(dr["QTY_RETURN"]) / Zconv);
            
                if (spinQTY.Properties.MaxValue == 0)
                {
                    spinQTY.Properties.ReadOnly = true;
                    spinQTY.Enabled = false;
                }
                else
                {
                    spinQTY.Properties.ReadOnly = false;
                    spinQTY.Enabled = true;
                }
              spinQTY.Select();
          }
          catch (Exception ex)
          {
              MessageBox.Show("SetData: " + ex.Message);
          }
      }

      private void ThreadStart()
      {
          if (!bwLoad.IsBusy) bwLoad.RunWorkerAsync();
      }
      #endregion

      public frm_RCreturnMark(int Id)
      {
          RCD_ID = Id;
          InitializeComponent();
          KeyPreview = true;
          LoadDefaultData();
          ThreadStart();            
      }

      private void frm_RCreturnMark_Load(object sender, EventArgs e)
      {

      }

      private void btClose_Click(object sender, EventArgs e)
      {
          if (IsSaveOK)
              DialogResult = DialogResult.OK;
          else
              DialogResult = DialogResult.Cancel;
          this.Close();
      }

      private void btSave_Click(object sender, EventArgs e)
      {
          if (VerifyData()) SaveData();
      }

      private void bwLoad_DoWork(object sender, DoWorkEventArgs e)
      {
          LoadData();
      }

      private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
          SetData();
      }

      private void frm_RCreturnMark_KeyDown(object sender, KeyEventArgs e)
      {
          switch (e.KeyCode)
          {
              case Keys.F2:
                  btSave.PerformClick();
                  break;
              case Keys.Escape:
                  btClose.PerformClick();
                  break;
          }
      }

      private void spinQTY_EditValueChanged(object sender, EventArgs e)
      {
          try
          {
              if (spinQTY.Value <= 0)
              {
                  spinQTY.Value = 0;
              }

              if ((Zquan / Zconv) != cls_Library.CDouble(spinQTY.Value))
              {
                  Zquan = cls_Library.CDouble(spinQTY.Value) * Zconv;                    
              }
          }
          catch { }
      }
    }
}
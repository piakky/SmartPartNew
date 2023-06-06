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
  public partial class frm_HistoryStock : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private DataTable dtData = new DataTable();
    private int ItemID = 0;
    #endregion

    #region Property
    public string ItemName
    {
      set { txtItemName.Text = value; }
    }
    #endregion

    #region Function

    private void SetDataToControl()
    {
      try
      {
        lstStockOnHand.Items.Clear();
        if (dtData.Rows.Count > 0)
        {          
          int ItemKey;
          double Qty = 0;
          foreach (DataRow dr in dtData.Rows)
          {
            lstStockOnHand.Items.Add(cls_Library.DBDateTime(dr["CREATE_DATE"]).ToString("dd/MM/yyyy"));
            ItemKey = lstStockOnHand.Items.Count - 1;
            lstStockOnHand.Items[ItemKey].SubItems.Add(cls_Library.DBString(dr["DOCNO"]));
            lstStockOnHand.Items[ItemKey].SubItems.Add(cls_Library.DBString(dr["USER_CODE"]));
            Qty = cls_Library.DBDouble(dr["QTY"]) - cls_Library.DBInt(dr["QTY_ORIGINAL"]);
            if (Qty > 0)
            {
              lstStockOnHand.Items[ItemKey].SubItems.Add("+" + Qty.ToString("#,##0.00"));
            }
            else
            {
              lstStockOnHand.Items[ItemKey].SubItems.Add(Qty.ToString("#,##0.00"));
            }            
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("SetDataToControl: " + ex.Message);
      }
    }

    private void ThreadStart()
    {
      if (!bwItem.IsBusy) bwItem.RunWorkerAsync();
    }
    #endregion

    public frm_HistoryStock(int Id)
    {
      ItemID = Id;
      InitializeComponent();
      this.KeyPreview = true;
      ThreadStart();
    }

    private void bwItem_DoWork(object sender, DoWorkEventArgs e)
    {
      dtData = cls_Data.GetListStockOnHandByItemID(ItemID, 1);
    }

    private void bwItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      SetDataToControl();
    }

    private void frm_HistoryStock_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Escape:
          this.Close();
          break;
      }
    }
  }
}
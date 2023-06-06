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
    public partial class frm_HistoryPriceList : DevExpress.XtraEditors.XtraForm
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
                lstPriceList.Items.Clear();
                if (dtData.Rows.Count > 0)
                {
                    decimal _price = 0;
                    int ItemKey;

                    int row = -1;
                    DataTable dt = dtData.Clone();
                    DataTable dtsorted = new DataTable();

                    foreach (DataRow dr in dtData.Rows)
                    {
                        //Price 1
                        _price = cls_Library.DBDecimal(dr["PRICE1"]);
                        if (_price > 0)
                        {
                            row++;
                            dt.Rows.Add();

                            dt.Rows[row]["PRICE1"] = _price;
                            dt.Rows[row]["DATE1"] = cls_Library.DBDateTime(dr["DATEACTIVE1"]);
                        }

                        //Price 2
                        _price = cls_Library.DBDecimal(dr["PRICE2"]);
                        if (_price > 0)
                        {
                            row++;
                            dt.Rows.Add();

                            dt.Rows[row]["PRICE1"] = _price;
                            dt.Rows[row]["DATE1"] = cls_Library.DBDateTime(dr["DATEACTIVE2"]);

                            
                        }
                        //Price 3
                        _price = cls_Library.DBDecimal(dr["PRICE3"]);
                        if (_price > 0)
                        {
                            row++;
                            dt.Rows.Add();

                            dt.Rows[row]["PRICE1"] = _price;
                            dt.Rows[row]["DATE1"] = cls_Library.DBDateTime(dr["DATEACTIVE3"]);
                        }
                    }

                    if (dt.Rows.Count > 0)
                    {
                        DataView dtview = new DataView(dt);
                        dtview.Sort = "[DATE1] DESC";
                        dtsorted = dtview.ToTable();
                    }

                    row = 0;

                    foreach (DataRow dr in dtsorted.Rows)
                    {
                        row++;
                        lstPriceList.Items.Add(row.ToString());
                        ItemKey = lstPriceList.Items.Count - 1;
                        lstPriceList.Items[ItemKey].SubItems.Add(cls_Library.DBDecimal(dr["PRICE1"]).ToString());
                        lstPriceList.Items[ItemKey].SubItems.Add(cls_Library.DBDateTime(dr["DATE1"]).ToString("dd/MM/yyyy"));

                        ////Price 1
                        //_price = cls_Library.DBDecimal(dr["PRICE1"]);
                        //if (_price > 0)
                        //{
                            
                        //}

                        ////Price 2
                        //_price = cls_Library.DBDecimal(dr["PRICE2"]);
                        //if (_price > 0)
                        //{
                        //    lstPriceList.Items.Add("2");
                        //    ItemKey = lstPriceList.Items.Count - 1;
                        //    lstPriceList.Items[ItemKey].SubItems.Add(_price.ToString());
                        //    lstPriceList.Items[ItemKey].SubItems.Add(cls_Library.DBDateTime(dr["DATEACTIVE2"]).ToString("dd/MM/yyyy"));
                        //}
                        ////Price 3
                        //_price = cls_Library.DBDecimal(dr["PRICE3"]);
                        //if (_price > 0)
                        //{
                        //    lstPriceList.Items.Add("3");
                        //    ItemKey = lstPriceList.Items.Count - 1;
                        //    lstPriceList.Items[ItemKey].SubItems.Add(_price.ToString());
                        //    lstPriceList.Items[ItemKey].SubItems.Add(cls_Library.DBDateTime(dr["DATEACTIVE3"]).ToString("dd/MM/yyyy"));
                        //}
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

        public frm_HistoryPriceList(int Id)
        {
            ItemID = Id;
            InitializeComponent();
            this.KeyPreview = true;
            ThreadStart();
        }

        private void bwItem_DoWork(object sender, DoWorkEventArgs e)
        {
            dtData = cls_Data.GetListPriceListByItemID(ItemID);
        }

        private void bwItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetDataToControl();
        }

        private void frm_HistoryPriceList_KeyDown(object sender, KeyEventArgs e)
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
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
using System.Data.SqlClient;

namespace SmartPart.Forms.General
{
    public partial class frm_JOBDetailInput : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private bool IsSaveOK = false;

        DataTable dtUnit = new DataTable();

        cls_Struct.ActionMode DataMode;
        DataSet dsEdit = new DataSet();
        DataRow EditData = null;
        int IdNo = 0, ListNo;
        double Zconv = 1;
        double Zquan = 0.00;
        #endregion

        #region Property

        public DataSet SetDatasetEdit
        {
            set { dsEdit = value; }
            get { return dsEdit; }
        }

        public DataRow SetEditData
        {
            set { EditData = value; }
        }

        public int SetListNo
        {
            set { ListNo = value; }
        }

        public int DataID
        {
            set { IdNo = value; }
        }

        #endregion

        #region Function

        private int AssigNo()
        {
            int no = 1;
            List<DataRow> ListNo = new List<DataRow>();
            try
            {
                if (DataMode != cls_Struct.ActionMode.Add)
                {
                    ListNo = dsEdit.Tables["JOBDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
                }
                else
                {
                    ListNo = dsEdit.Tables["JOBDETAIL"].AsEnumerable().ToList();
                }
                
                if (ListNo.Count() > 0)
                    no = ListNo.Count() + 1;
            }
            catch (Exception ex)
            { MessageBox.Show("AssigNo :" + ex.Message); }
            return no;
        }

        private void ClearData()
        {
            DataMode = cls_Struct.ActionMode.Add;
            //spinListNo.EditValue
            sluItem.EditValue = 0;
            txtFullName.Text = "";
            txtGenuinPartId.Text = "";
            txtBrandPartId.Text = "";
            txtModel1.Text = "";
            sluBrand.EditValue = 0;
            sluLocation.EditValue = 0;
            spinQTY.EditValue = 0;
            sluUnit.EditValue = 0;

            Zquan = 0;
            Zconv = 1;

            ListNo = AssigNo();
        }

        private void EditRowData()
        {
            int idx = 0;
            try
            {
                var array1 = EditData.ItemArray;
                foreach (DataRow drRows in dsEdit.Tables["JOBDETAIL"].Rows)
                {
                    var array2 = drRows.ItemArray;
                    if (array1.SequenceEqual(array2))
                        break;

                    idx++;
                }
                DataRow row = dsEdit.Tables["JOBDETAIL"].Rows[idx];

                row["ITEM_ID"] = cls_Library.DBInt(sluItem.EditValue);
                row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
                row["BRAND_PART_ID"] = txtBrandPartId.Text;
                row["FULL_NAME"] = txtFullName.Text;
                row["MODEL1"] = txtModel1.Text;
                row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
                row["STOCK"] = sluLocation.EditValue.ToString();
                row["QTY"] = Zquan;//cls_Library.DBInt(spinQTY.EditValue);
                row["CONV"] = Zconv;
                row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);

                row["mode"] = DataMode;
                //row["Change"] = 1;

                dsEdit.Tables["JOBDETAIL"].AcceptChanges();
                EditData.ItemArray = row.ItemArray;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("EditRowData :" + ex.Message);
                IsSaveOK = false;
            }
        }

        public void InitialDialog(cls_Struct.ActionMode mode)
        {
            try
            {
            DataMode = mode;
            if (DataMode == cls_Struct.ActionMode.Copy) DataMode = cls_Struct.ActionMode.Add;
            LoadDefaultData();
            switch (DataMode)
            {
                case cls_Struct.ActionMode.Add:
                sluItem.EditValue = cls_Library.DBInt(EditData["ITEM_ID"]);
                SetUnit(cls_Library.CInt(sluItem.EditValue));
                txtFullName.Text = EditData["FULL_NAME"].ToString();
                txtGenuinPartId.Text = EditData["GENUIN_PART_ID"].ToString();
                txtBrandPartId.Text = EditData["BRAND_PART_ID"].ToString();
                txtModel1.Text = EditData["MODEL1"].ToString();
                sluBrand.EditValue = cls_Library.DBInt(EditData["BRAND_ID"]).ToString();
                sluLocation.EditValue = //EditData["STOCK"].ToString();
                //spinQTY.EditValue = cls_Library.DBInt(EditData["QTY"]);                        
                Zquan = cls_Library.DBDouble(EditData["QTY"]);
                        if (Zquan == 0) Zquan = 1;
                if (Zconv == 0) Zconv = 1;
                spinQTY.Value = cls_Library.CDecimal(Zquan / Zconv);

                break;
                case cls_Struct.ActionMode.Edit:
                if (EditData == null) return;
                //spinListNo.EditValue = ;      //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXsssss
                IdNo = cls_Library.DBInt(EditData["JOBD_ID"]);
                sluItem.EditValue = cls_Library.DBInt(EditData["ITEM_ID"]);
                SetUnit(cls_Library.CInt(sluItem.EditValue));
                txtFullName.Text = EditData["FULL_NAME"].ToString();
                txtGenuinPartId.Text = EditData["GENUIN_PART_ID"].ToString();
                txtBrandPartId.Text = EditData["BRAND_PART_ID"].ToString();
                txtModel1.Text = EditData["MODEL1"].ToString();
                sluBrand.EditValue = cls_Library.DBInt(EditData["BRAND_ID"]).ToString();
                sluLocation.EditValue = EditData["STOCK"].ToString();
                Zquan = cls_Library.DBDouble(EditData["QTY"]);
                Zconv = cls_Library.DBDouble(EditData["CONV"]);
                spinQTY.Value = cls_Library.CDecimal(Zquan / (double)Zconv);
                sluUnit.EditValue = cls_Library.DBInt(EditData["UNIT_ID"]);
                break;
            }
            spinQTY.Select();
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show("InitialDialog :" + ex.Message);
            }
        }

        private void LoadDefaultData()
        {
            try
            {
                cls_Library.AssignSearchLookUp(sluItem, "M_ITEMS", "รหัสสินค้า", "ชื่อสินค้า");
                cls_Library.AssignSearchLookUp(sluBrand, "M_BRANDS", "รหัสยี่ห้อ", "ชื่อยี่ห้อ", cls_Global_class.TypeShow.codename);
                //cls_Library.AssignSearchLookUp(sluUnit, "M_UNITS", "รหัสหน่วยนับ", "ชื่อหน่วยนับ");                

                SetControl();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("LoadDefaultData :" + ex.Message);
            }
        }

        private void SaveData()
        {
            try
            {
                if (DataMode == cls_Struct.ActionMode.View) return;

                IsSaveOK = true;
                if (DataMode != cls_Struct.ActionMode.Add)
                {
                    EditRowData();
                }
                else
                {
                    DataTable dt = dsEdit.Tables["JOBDETAIL"].Clone();
                    DataColumn colMode = new DataColumn("mode", typeof(int));
                    dt.Columns.Add(colMode);
                    ListNo = AssigNo();
                    if (Zconv == 0) Zconv = 1;
                    Zquan = cls_Library.DBDouble(spinQTY.EditValue);
                    DataRow row = dt.NewRow();
                    row["JOBD_ID"] = -1;
                    row["JOBD_PID"] = IdNo;
                    row["LIST_NO"] = ListNo;
                    row["ITEM_ID"] = cls_Library.DBInt(sluItem.EditValue);
                    row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
                    row["BRAND_PART_ID"] = txtBrandPartId.Text;
                    row["FULL_NAME"] = txtFullName.Text;
                    row["MODEL1"] = txtModel1.Text;
                    row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
                    row["STOCK"] = sluLocation.EditValue.ToString();
                    row["QTY"] = Zquan/Zconv; //cls_Library.DBInt(spinQTY.EditValue);
                    row["CONV"] = Zconv;
                    row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);

                    row["mode"] = DataMode;

                    dt.Rows.Add(row);
                    dsEdit.Tables["JOBDETAIL"].ImportRow(row);

                    SaveNewDetail(dt);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SaveData :" + ex.Message);
                IsSaveOK = false;
            }
            finally
            {
                if (IsSaveOK) btClose_Click(null, null);                
            }
        }

        private void SaveNewDetail(DataTable dt)
        {
            SqlConnection conn = new SqlConnection();
            SqlTransaction tran = null;
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            StringBuilder sb = new StringBuilder();
            try
            {
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    tran = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    if (cls_Data.SaveJOBDetail(IdNo, dt, ref conn, ref tran))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            sb.Clear();
                            sb.AppendLine("UPDATE JOBHEAD WITH (UPDLOCK) SET");
                            sb.AppendLine("LIST_NO = @LIST_NO,");
                            sb.AppendLine("UPDATE_BY = @UPDATE_BY,");
                            sb.AppendLine("UPDATE_DATE = @UPDATE_DATE");
                            sb.AppendLine("WHERE JOB_ID = @JOB_ID");

                            cmd.CommandText = sb.ToString();
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Clear();
                            cmd.Transaction = tran;

                            cmd.Parameters.Add("@LIST_NO", SqlDbType.Int).Value = dsEdit.Tables["JOBDETAIL"].AsEnumerable().Count();
                            cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
                            cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DateTime.Now;
                            cmd.Parameters.Add("@JOB_ID", SqlDbType.Int).Value = IdNo;

                            cmd.ExecuteNonQuery();
                            tran.Commit();
                            XtraMessageBox.Show("บันทึกรายการ JOB เรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        tran.Rollback();
                        //Remove List
                        DataRow[] dr = dsEdit.Tables["JOBDETAIL"].Select("LIST_NO =" + ListNo);
                        if (dr.Count() > 0)
                            dsEdit.Tables["JOBDETAIL"].Rows.Remove(dr[0]);
                    }

                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                //Remove List
                DataRow[] dr = dsEdit.Tables["JOBDETAIL"].Select("LIST_NO =" + ListNo);
                if (dr.Count() > 0)
                    dsEdit.Tables["JOBDETAIL"].Rows.Remove(dr[0]);
                XtraMessageBox.Show("SaveNewDetail :" + ex.Message);
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn); conn.Dispose();
            }
        }

        private void SetControl()
        {
            try
            {
                sluItem.ReadOnly = true;
                switch (DataMode)
                {
                    case cls_Struct.ActionMode.Add:
                        break;
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.View:
                        btSave.Visible = DataMode == cls_Struct.ActionMode.Edit;
                        txtFullName.ReadOnly = true;
                        txtGenuinPartId.ReadOnly = true;
                        txtBrandPartId.ReadOnly = true;
                        txtModel1.ReadOnly = true;
                        sluBrand.ReadOnly = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetControl :" + ex.Message);
            }
        }

        private void SetLocation()
        {
            try
            {
                DataTable dtLocation = cls_Data.GetDataTable("D_ITEM_LOCATIONS", cls_Library.DBInt(sluItem.EditValue));
                sluLocation.Properties.DataSource = dtLocation;
                sluLocation.Properties.PopulateViewColumns();
                sluLocation.Properties.ValueMember = "name";
                sluLocation.Properties.DisplayMember = "name";
                sluLocation.Properties.View.Columns["_id"].Visible = false;
                sluLocation.Properties.View.Columns["name"].Caption = "ชื่อคลังสินค้าา";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetLocation :" + ex.Message);
            }
        }

        private void SetUnit(int ItemId)
        {
            try
            {
                //2022-06-06
                //dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", ItemId,"",false,1);
                dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", ItemId, "", false);
                
                string[] selectedColumns = new[] { "_id", "code", "name", "MULTIPLY_QTY", "codename" };
                DataTable dt = new DataView(dtUnit).ToTable(false, selectedColumns);
                sluUnit.Properties.DataSource = dt;
                sluUnit.Properties.PopulateViewColumns();
                sluUnit.Properties.View.Columns["_id"].Visible = false;
                sluUnit.Properties.View.Columns["codename"].Visible = false;
                sluUnit.Properties.View.Columns["code"].Caption = "รหัสหน่วยนับ";
                sluUnit.Properties.View.Columns["name"].Caption = "ชื่อหน่วยนับ";
                sluUnit.Properties.View.Columns["MULTIPLY_QTY"].Caption = "จำนวนหน่วยย่อย";

                sluUnit.Properties.ValueMember = "_id";
                sluUnit.Properties.DisplayMember = "codename";

                //Default SALE_STATUS 2022-09-19
                if (dtUnit.Rows.Count > 0)
                {
                    List<DataRow> lst = dtUnit.AsEnumerable().Where(r => r.Field<Boolean>("SALE_STATUS") == true).ToList();
                    if (lst.Count > 0)
                    {
                        sluUnit.EditValue = cls_Library.DBInt(lst[0]["UNIT_ID"]);
                        Zconv = cls_Library.DBDouble(lst[0]["MULTIPLY_QTY"]);
                    }
                    //sluUnit.EditValue = cls_Library.DBInt(dtUnit.Rows[0]["UNIT_ID"]);
                    //Zconv = cls_Library.DBDouble(dtUnit.Rows[0]["MULTIPLY_QTY"]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetLocation :" + ex.Message);
            }
        }

        private void SetDetailItem(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = cls_Data.GetDetailItem(id);
                if (dt.Rows.Count > 0)
                {
                    //Set Detail Item
                    DataRow dr = dt.Rows[0];
                    txtFullName.Text = dr["FULL_NAME"].ToString();
                    txtGenuinPartId.Text = dr["GENUIN_PART_ID"].ToString();
                    txtBrandPartId.Text = dr["BRAND_PART_ID"].ToString();
                }
                else
                {
                    //Clear Detail Item
                    txtFullName.Text = "";
                    txtGenuinPartId.Text = "";
                    txtBrandPartId.Text = "";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetDetailItem :" + ex.Message);
            }
        }

        private bool VerifyData()
        {
            bool ret = true;
            StringBuilder msg = new StringBuilder();
            try
            {
                if (sluItem.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสสินค้าไม่ถูกต้อง");
                }
                if (sluUnit.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสหน่วยนับไม่ถูกต้อง");
                }
                if (cls_Library.DBDouble(spinQTY.EditValue) <= 0)
                {
                    ret = false;
                    msg.AppendLine("จำนวนไม่ถูกต้อง");
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

        #endregion

        public frm_JOBDetailInput()
        {
            InitializeComponent();
                this.KeyPreview = true;
            KeyPreview = true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(VerifyData()) SaveData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (IsSaveOK)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void sluItem_EditValueChanged(object sender, EventArgs e)
        {
            //SetLocation();        //XXXXXXXXXXXXXXXx
            if (sluItem.IsEditorActive) SetDetailItem(cls_Library.CInt(sluItem.EditValue));
        }

        private void frm_JOBDetailInput_KeyDown(object sender, KeyEventArgs e)
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

        private void sluUnit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit _sender = (SearchLookUpEdit)sender;

                if (_sender.EditValue != null)
                {
                    DataRow[] xrow = dtUnit.Select("UNIT_ID = " + _sender.EditValue + "");
                    if (xrow.Length > 0)
                        Zconv = cls_Library.DBDouble(xrow[0]["MULTIPLY_QTY"]);
                    else
                        Zconv = 1;                    
                }
            }
            catch (Exception)
            {
                Zconv = 1;
            }
            finally
            {
                Zquan = cls_Library.CDouble(spinQTY.EditValue) * Zconv;
                if (Zquan == 0) Zquan = 1;
                spinQTY.Value = cls_Library.CDecimal(Zquan / Zconv);
            }
        }
    }
}
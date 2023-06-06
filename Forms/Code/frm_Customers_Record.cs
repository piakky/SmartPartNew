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
using System.IO;
using System.Data.SqlClient;

namespace SmartPart.Forms.Code
{
  public partial class frm_Customers_Record : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private cls_Struct.StructCUSTOMERS CUS = new cls_Struct.StructCUSTOMERS();
    private int itemID = 0;
    private cls_Struct.ActionMode DataMode;
    private DataSet dsMainData = new DataSet();
    private DataSet dsEdit = new DataSet();
    private string CusCode = "";
    private string strBasePath = "";

    private bool IsSaveOK = false;
    private int ContractID = 0;
    private int ChequeID = 0;
    private int BankID = 0;
    private int CarID = 0;
    private int TrackID = 0;
    private int BrandDID = 0;
    #endregion

    #region Property
    
    #endregion 

    #region User define function

    private void AssignDataFromComponent()
    {
      CUS.CUSTOMER_ID = itemID;
      CUS.CUSTOMER_CODE = txtCode.Text.Trim();
      CUS.CUSTOMER_NAME = txtName.Text.Trim();
      CUS.DETAIL_1 = txtDetail1.Text.Trim();
      CUS.DETAIL_2 = txtDetail2.Text.Trim();
      CUS.DETAIL_3 = txtDetail3.Text.Trim();
      CUS.REMARK = txtRemark.Text.Trim();
      CUS.E_MAIL = txtEmail.Text.Trim();
      CUS.ADDRESS_1 = txtAddr1.Text.Trim();
      CUS.ADDRESS_2 = txtAddr2.Text.Trim();
      CUS.ADDRESS_3 = txtAddr3.Text.Trim();
      CUS.ADDRESS_4 = txtAddr4.Text.Trim();
      CUS.LOCATION = txtLocation.Text.Trim();
      CUS.TAX_ID = txtTaxID.Text.Trim();
      CUS.START_CONTRACT_DATE = cls_Library.DBDateTime(dateStart.EditValue);
      CUS.LAST_CONTRACT_DATE = cls_Library.DBDateTime(dateEnd.EditValue);
      CUS.SALE_ENABLED_STATUS = cls_Library.DBbool(radioStatus.SelectedIndex);
      CUS.PRICE_STEP = cls_Library.DBString(spinPriceStep.EditValue);
      CUS.CREDIT_LIMIT = cls_Library.DBDouble(spinLimit.EditValue);
      CUS.CUSTOMER_CREDIT_TERM = cls_Library.DBInt16(spinTerm.EditValue);
      
      switch (radioTypePrint.SelectedIndex)
      {
        case 0:
          CUS.BILL_TYPE_CODE = "A";
          break;
        case 1:
          CUS.BILL_TYPE_CODE = "B";
          break;
        case 2:
          CUS.BILL_TYPE_CODE = "C";
          break;        
      }      
    }

    private void AddDataSourceToGrid(byte gType)
    {
      DataTable dt = new DataTable();
      List<DataRow> _listdt;
      try
      {
        switch (gType)
        {
          case 1: //ผู้ติดต่อ
            _listdt = dsEdit.Tables["D_CUSTOMER_CONTRACTORS"].AsEnumerable().AsParallel().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).OrderBy(r => r.Field<Int16>("LIST_NO")).ToList();
            if (_listdt.Count > 0)
              dt = _listdt.CopyToDataTable();
            else
              dt = dsEdit.Tables["D_CUSTOMER_CONTRACTORS"].Clone();
            gridContract.DataSource = dt;
            gridContract.RefreshDataSource();
            break;
          //case 2: //ที่อยู่
          //  dt = dsEdit.Tables["D_CUSTOMER_ADDRESSES"].AsEnumerable().AsParallel().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).CopyToDataTable();
          //  gridAddress.DataSource = dt;
          //  gridAddress.RefreshDataSource();
          //  break;
          case 3: //ชื่อจ่ายเช็ค
            _listdt = dsEdit.Tables["D_CUSTOMER_CHEQUES"].AsEnumerable().AsParallel().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).OrderBy(r => r.Field<Int16>("LIST_NO")).ToList();
            if (_listdt.Count > 0)
              dt = _listdt.CopyToDataTable();
            else
              dt = dsEdit.Tables["D_CUSTOMER_CHEQUES"].Clone();
            gridCheques.DataSource = dt;
            gridCheques.RefreshDataSource();
            break;
          case 4: //บัญชีธนาคาร
            _listdt = dsEdit.Tables["D_CUSTOMER_BANKS"].AsEnumerable().AsParallel().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).OrderBy(r => r.Field<Int16>("LIST_NO")).ToList();
            if (_listdt.Count > 0)
              dt = _listdt.CopyToDataTable();
            else
              dt = dsEdit.Tables["D_CUSTOMER_BANKS"].Clone();
            gridBank.DataSource = dt;
            gridBank.RefreshDataSource();
            break;
          case 5: //ทะเบียนรถยนต์
            _listdt = dsEdit.Tables["D_CUSTOMER_CARS"].AsEnumerable().AsParallel().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).OrderBy(r => r.Field<Int16>("LIST_NO")).ToList();
            if (_listdt.Count > 0)
              dt = _listdt.CopyToDataTable();
            else
              dt = dsEdit.Tables["D_CUSTOMER_CARS"].Clone();
            gridCar.DataSource = dt;
            gridCar.RefreshDataSource();
            break;
          case 6: //ประวัติการติดตามหนี้
            _listdt = dsEdit.Tables["D_CUSTOMER_TRACKS"].AsEnumerable().AsParallel().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).OrderBy(r => r.Field<Int16>("LIST_NO")).ToList();
            if (_listdt.Count > 0)
              dt = _listdt.CopyToDataTable();
            else
              dt = dsEdit.Tables["D_CUSTOMER_TRACKS"].Clone();
            gridHistory.DataSource = dt;
            gridHistory.RefreshDataSource();
            break;
          case 7: //ยี่ห้อสินค้าที่ได้รับส่วนลด
            _listdt = dsEdit.Tables["D_CUSTOMER_BRAND_DISCOUNT_STEPS"].AsEnumerable().AsParallel().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).OrderBy(r => r.Field<Int16>("LIST_NO")).ToList();
            if (_listdt.Count > 0)
              dt = _listdt.CopyToDataTable();
            else
              dt = dsEdit.Tables["D_CUSTOMER_BRAND_DISCOUNT_STEPS"].Clone();
            gridBrandDiscount.DataSource = dt;
            gridBrandDiscount.RefreshDataSource();
            break;
        }
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("AddDataSourceToGrid : " + ex.Message);
      }
    }

    private bool CheckCodeExist(string Xcode)
    {
      bool err = false;
      SqlConnection conn = new SqlConnection();
      SqlCommand cmd = conn.CreateCommand();
      SqlDataReader rd = null;
      int id = 0;

      cls_Global_DB.ConnectDatabase(ref conn);

      err = false;
      cmd = new SqlCommand();
      cmd.CommandText = "SELECT CUSTOMER_ID,CUSTOMER_CODE FROM M_CUSTOMERS WHERE CUSTOMER_CODE='" + Xcode + "' And DELETED=0";
      cmd.Connection = conn;
      cmd.CommandTimeout = 30;
      cmd.CommandType = CommandType.Text;
      rd = cmd.ExecuteReader();
      if (rd.HasRows)
      {
        if ((DataMode == cls_Struct.ActionMode.Edit) || (DataMode == cls_Struct.ActionMode.Copy))
        {
          rd.Read();
          id = cls_Library.DBInt(rd["CUSTOMER_ID"]);
          if (id != itemID)
          {
            err = true;
          }
          else
          {
            err = true;
          }
        }
      }
      if (!rd.IsClosed) rd.Close();

      return err;
    }

    private void InitialDialog()
    {
      if (!bwCode.IsBusy)
        bwCode.RunWorkerAsync();
    }

    private void LoadDefaultData()
    {
      
    }

    private bool SaveData()
    {
      bool ret = false;

      try
      {
        AssignDataFromComponent();

        //--- Save ข้อมูลลงฐานข้อมูล 
        cls_Global_DB.GB_ItemID = 0;
        ret = cls_Data.SaveCustomerCode(DataMode, CUS, dsEdit);
        itemID = cls_Global_DB.GB_ItemID;
        DataMode = cls_Struct.ActionMode.Edit;
        if (!bwCode.IsBusy)
        {
          this.UseWaitCursor = true;
          bwCode.RunWorkerAsync();
          this.UseWaitCursor = false;
        }
      }
      catch (Exception ex)
      {
        Application.DoEvents();
        if (ex.Message.IndexOf("Cannot insert duplicate key") > -1)
        {
          txtCode.ErrorText = "";
          txtCode.Focus();
        }
        else
        {
          XtraMessageBox.Show("ไม่สามารถบันทึกรหัสลูกค้าได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        ret = false;
      }

      return ret;
    }

    private void SetDataToControl()
    {
      DataRow row = null;
      try
      {
        dsEdit = dsMainData.Copy();
        strBasePath = Application.StartupPath + "\\Photos";
        if (!Directory.Exists(strBasePath)) Directory.CreateDirectory(strBasePath);
        switch (DataMode)
        {
          case cls_Struct.ActionMode.Add:
            SetDefaultData();
            break;
          case cls_Struct.ActionMode.Edit:
          case cls_Struct.ActionMode.Copy:
          case cls_Struct.ActionMode.View:
            if (dsEdit.Tables["M_CUSTOMERS"].Rows.Count <= 0) return;
            row = dsEdit.Tables["M_CUSTOMERS"].Rows[0];
            CusCode = row["CUSTOMER_CODE"].ToString();
            txtCode.Text = row["CUSTOMER_CODE"].ToString();
            txtName.Text = row["CUSTOMER_NAME"].ToString();
            txtDetail1.Text = row["DETAIL_1"].ToString();
            txtDetail2.Text = row["DETAIL_2"].ToString();
            txtDetail3.Text = row["DETAIL_3"].ToString();
            txtRemark.Text = row["REMARK"].ToString();
            txtEmail.Text = row["E_MAIL"].ToString();
            txtAddr1.Text = row["ADDRESS_1"].ToString();
            txtAddr2.Text = row["ADDRESS_2"].ToString();
            txtAddr3.Text = row["ADDRESS_3"].ToString();
            txtAddr4.Text = row["ADDRESS_4"].ToString();
            txtLocation.Text = row["LOCATION"].ToString();
            txtTaxID.Text = row["TAX_ID"].ToString();
            if (cls_Library.DBDateTime(row["START_CONTRACT_DATE"]) == DateTime.MinValue)
              dateStart.EditValue = null;
            else
              dateStart.EditValue = cls_Library.DBDateTime(row["START_CONTRACT_DATE"]);

            if (cls_Library.DBDateTime(row["LAST_CONTRACT_DATE"]) == DateTime.MinValue)
              dateEnd.EditValue = null;
            else
              dateEnd.EditValue = cls_Library.DBDateTime(row["LAST_CONTRACT_DATE"]);
            spinLimit.EditValue = cls_Library.DBDouble(row["CREDIT_LIMIT"]);
            spinTerm.EditValue = cls_Library.DBInt(row["CUSTOMER_CREDIT_TERM"]);
            spinPriceStep.EditValue = cls_Library.DBInt(row["PRICE_STEP"]);

            radioStatus.SelectedIndex = 0;
            if (cls_Library.DBbool(row["SALE_ENABLED_STATUS"]))
            {
              radioStatus.SelectedIndex = 1;
            }
            switch (cls_Library.DBString(row["BILL_TYPE_CODE"]))
	          {
              case "A":
                radioTypePrint.SelectedIndex = 0;
                break;
              case "B":
                radioTypePrint.SelectedIndex = 1;
                break;
              case "C":
                radioTypePrint.SelectedIndex = 2;
                break;              
	          }
            break;
        }
        SetGrid();
        txtCode.Focus();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("SetDataToControl : " + ex.Message);
      }
    }

    private void SetDefaultData()
    {
      //SetGrid();
    }

    private void SetGrid()
    {
      for (byte i = 1; i <= 7; i++)      
        AddDataSourceToGrid(i);
      
      //ผู้ติดต่อ
      cls_Library.BestFitColumns(gvContract);
      ////ที่อยู่
      //cls_Library.BestFitColumns(gvAddress);
      //ชื่อจ่ายเช็ค
      cls_Library.BestFitColumns(gvCheques);
      //บัญชีธนาคาร
      cls_Library.BestFitColumns(gvBank);
      //ทะเบียนรถยนต์
      cls_Library.BestFitColumns(gvCar);
      //ประวัติการติดตามหนี้
      cls_Library.BestFitColumns(gvHistory);
      //ยี่ห้อสินค้าที่ได้รับส่วนลด
      cls_Library.BestFitColumns(gvBrandDiscount);
    }

    private bool VerifyData()
    {
      bool err = false;
      try
      {
        if (txtCode.EditValue == null || txtCode.Text == "")
        {
          XtraMessageBox.Show("กรุณาระบุรหัสลูกค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          txtCode.ErrorText = "กรุณาระบุรหัสลูกค้า";
          txtCode.Focus();
          err = true;
        }
        else
        {
          if (txtCode.Text.Trim() != CusCode && CheckCodeExist(txtCode.Text.Trim()))
          {
            XtraMessageBox.Show("มีรหัสลูกค้านี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtCode.ErrorText = "มีรหัสลูกค้านี้ในฐานข้อมูลแล้ว";
            txtCode.Focus();
            err = true;
          }
        }
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("VerifyData : " + ex.Message);
      }
      return err;
    }

    #region ผู้ติดต่อ
    private void InitialDialogContract(cls_Struct.ActionMode mode)
    {
      DataRow row = null;
      string strMode = "";
      int _no = 0;
      try
      {
        switch (mode)
        {
          case cls_Struct.ActionMode.Add:
            strMode = " [เพิ่ม]";
            break;
          case cls_Struct.ActionMode.Edit:
            row = gvContract.GetFocusedDataRow();
            if (row == null) return;
            strMode = " [แก้ไข]";
            break;
          case cls_Struct.ActionMode.Delete:
            row = gvContract.GetFocusedDataRow();
            if (row == null) return;
            if (XtraMessageBox.Show("ต้องการลบรายการที่ " + (gvContract.FocusedRowHandle + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            int no = cls_Library.DBInt(row["SEQUENSE_NO"]);
            if (no <= 0)
            {
              dsEdit.Tables["D_CUSTOMER_CONTRACTORS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r => dsEdit.Tables["D_CUSTOMER_CONTRACTORS"].Rows.Remove(r));
              dsEdit.Tables["D_CUSTOMER_CONTRACTORS"].AcceptChanges();
            }
            else
            {
              dsEdit.Tables["D_CUSTOMER_CONTRACTORS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r =>
              {
                //r["change"] = 1;
                r["mode"] = cls_Struct.ActionMode.Delete;
                r.AcceptChanges();
              });
            }
            AddDataSourceToGrid(1);
            return;
        }

        frmD_Contract_Input frmInput = new frmD_Contract_Input(1);
        frmInput.Text = "ผู้ติดต่อ" + strMode;

        #region Set Control
        if (mode == cls_Struct.ActionMode.Edit) //ยังไม่มี Copy นะ
        {
          frmInput.txtName.Text = cls_Library.DBString(row["CONTRACTOR_NAME"]);
          frmInput.txtDep.Text = cls_Library.DBString(row["DEPARTMENT"]);
          frmInput.txtTel.Text = cls_Library.DBString(row["TEL_NO"]);
          frmInput.txtTelExt.Text = cls_Library.DBString(row["TEL_NO_EXT"]);
          frmInput.txtNote.Text = cls_Library.DBString(row["REMARK"]);
          if (cls_Library.DBDateTime(row["HIRE_DATE"]) == DateTime.MinValue)
            frmInput.dateStart.EditValue = null;
          else
            frmInput.dateStart.EditValue = cls_Library.DBDateTime(row["HIRE_DATE"]);

          if (string.IsNullOrEmpty(row["PICTURE_FILE_NAME"].ToString()))
          {
            frmInput.picDisplay.Image = null;
            frmInput.txtPic.Text = "";
          }
          else
          {
            var picbyte = (Byte[])(row["PICTURE_IMAGE"]);
            //var stream = new MemoryStream(picbyte);
            MemoryStream MemoryStreamData = new MemoryStream(picbyte);
            Image image = System.Drawing.Image.FromStream(MemoryStreamData);
            image.Save(strBasePath + "\\" + cls_Library.DBString(row["PICTURE_FILE_NAME"]));
            frmInput.picDisplay.Image = image;
            frmInput.txtPic.Text = strBasePath + "\\" + cls_Library.DBString(row["PICTURE_FILE_NAME"]);
          }
          frmInput.Txtfilename.Text = cls_Library.DBString(row["PICTURE_FILE_NAME"]);          

          frmInput.txtType.Text = cls_Library.DBString(row["MEDIA_TYPE"]);
        }
        else
        {
          frmInput.txtName.Text = "";
          frmInput.txtDep.Text = "";
          frmInput.txtTel.Text = "";
          frmInput.txtTelExt.Text = "";
          frmInput.txtNote.Text = "";
          frmInput.dateStart.EditValue = DateTime.Now;
          frmInput.txtPic.Text = "";
          frmInput.picDisplay.Image = null;
          frmInput.txtType.Text = "";
        }
        #endregion

        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;

        Class_ImageResize img = new Class_ImageResize();
        dsEdit.Tables["D_CUSTOMER_CONTRACTORS"].BeginInit();
        if (mode == cls_Struct.ActionMode.Add)
        {          
          row = dsEdit.Tables["D_CUSTOMER_CONTRACTORS"].NewRow();
          row["CUSTOMER_ID"] = itemID;
          row["SEQUENSE_NO"] = ContractID--;
          row["LIST_NO"] = dsEdit.Tables["D_CUSTOMER_CONTRACTORS"].Rows.Count + 1;
          row["CONTRACTOR_NAME"] = cls_Library.DBString(frmInput.txtName.Text);
          row["DEPARTMENT"] = cls_Library.DBString(frmInput.txtDep.Text);
          row["TEL_NO"] = cls_Library.DBString(frmInput.txtTel.Text);
          row["TEL_NO_EXT"] = cls_Library.DBString(frmInput.txtTelExt.Text);
          row["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);
          row["HIRE_DATE"] = cls_Library.DBDateTime(frmInput.dateStart.EditValue);
          row["PICTURE_FILE_NAME"] = cls_Library.DBString(frmInput.Txtfilename.Text);
          if (string.IsNullOrEmpty(frmInput.Txtfilename.Text))          
            row["PICTURE_IMAGE"] = null;
          else
            row["PICTURE_IMAGE"] = img.imageToByteArray(frmInput.picDisplay.Image);
          row["MEDIA_TYPE"] = cls_Library.DBString(frmInput.txtType.Text);


          row["mode"] = cls_Struct.ActionMode.Add;
          //row["change"] = 1;

          dsEdit.Tables["D_CUSTOMER_CONTRACTORS"].Rows.Add(row);
        }
        else
        {
          _no = cls_Library.DBInt(row["SEQUENSE_NO"]);
          DataRow[] dr= dsEdit.Tables["D_CUSTOMER_CONTRACTORS"].Select("SEQUENSE_NO = " + _no);
          if (dr.Count() > 0)
          {
            dr[0]["CONTRACTOR_NAME"] = cls_Library.DBString(frmInput.txtName.Text);
            dr[0]["DEPARTMENT"] = cls_Library.DBString(frmInput.txtDep.Text);
            dr[0]["TEL_NO"] = cls_Library.DBString(frmInput.txtTel.Text);
            dr[0]["TEL_NO_EXT"] = cls_Library.DBString(frmInput.txtTelExt.Text);
            dr[0]["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);
            dr[0]["HIRE_DATE"] = cls_Library.DBDateTime(frmInput.dateStart.EditValue);
            dr[0]["PICTURE_FILE_NAME"] = cls_Library.DBString(frmInput.Txtfilename.Text);
            if (string.IsNullOrEmpty(frmInput.Txtfilename.Text))
              dr[0]["PICTURE_IMAGE"] = null;
            else
              dr[0]["PICTURE_IMAGE"] = img.imageToByteArray(frmInput.picDisplay.Image);
            dr[0]["MEDIA_TYPE"] = cls_Library.DBString(frmInput.txtType.Text);

            if (_no > 0) dr[0]["mode"] = cls_Struct.ActionMode.Edit;
          }
        }

        dsEdit.Tables["D_CUSTOMER_CONTRACTORS"].EndInit();
        AddDataSourceToGrid(1);

      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("InitialDialogContract : " + ex.Message);
      }
    }
    #endregion

    #region ที่อยู่
    //private void InitialDialogAddress(cls_Struct.ActionMode mode)
    //{
    //  DataRow row = null;
    //  string strMode = "";
    //  try
    //  {
    //    switch (mode)
    //    {
    //      case cls_Struct.ActionMode.Add:
    //        strMode = " [เพิ่ม]";
    //        break;
    //      case cls_Struct.ActionMode.Edit:
    //        row = gvAddress.GetFocusedDataRow();
    //        if (row == null) return;
    //        strMode = " [แก้ไข]";
    //        break;
    //      case cls_Struct.ActionMode.Delete:
    //        row = gvAddress.GetFocusedDataRow();
    //        if (row == null) return;
    //        if (XtraMessageBox.Show("ต้องการลบรายการที่ " + (gvAddress.FocusedRowHandle + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
    //        int no = cls_Library.DBInt(row["SEQUENSE_NO"]);
    //        if (no <= 0)
    //        {
    //          dsEdit.Tables["D_CUSTOMER_ADDRESSES"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r => dsEdit.Tables["D_CUSTOMER_ADDRESSES"].Rows.Remove(r));
    //          dsEdit.Tables["D_CUSTOMER_ADDRESSES"].AcceptChanges();
    //        }
    //        else
    //        {
    //          dsEdit.Tables["D_CUSTOMER_ADDRESSES"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r =>
    //          {
    //            //r["change"] = 1;
    //            r["mode"] = cls_Struct.ActionMode.Delete;
    //            r.AcceptChanges();
    //          });
    //        }
    //        SetGrid();
    //        return;
    //    }

    //    frmD_Address_Input frmInput = new frmD_Address_Input(1);
    //    frmInput.Text = "ที่อยู่" + strMode;

    //    #region Set Control
    //    if (mode == cls_Struct.ActionMode.Edit)
    //    {
    //      frmInput.txtLocation.Text = cls_Library.DBString(row["ADDRESS_TYPE"]);
    //      frmInput.txtAddr1.Text = cls_Library.DBString(row["ADDRESS_1"]);
    //      frmInput.txtAddr2.Text = cls_Library.DBString(row["ADDRESS_2"]);
    //      frmInput.txtAddr3.Text = cls_Library.DBString(row["ADDRESS_3"]);
    //      frmInput.txtAddr4.Text = cls_Library.DBString(row["ADDRESS_4"]);
    //    }
    //    else
    //    {
    //      frmInput.txtLocation.Text = "";
    //      frmInput.txtAddr1.Text = "";
    //      frmInput.txtAddr2.Text = "";
    //      frmInput.txtAddr3.Text = "";
    //      frmInput.txtAddr4.Text = "";
    //    }
    //    #endregion

    //    frmInput.MinimizeBox = false;
    //    frmInput.ShowInTaskbar = false;
    //    if (frmInput.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;
    //    dsEdit.Tables["D_CUSTOMER_ADDRESSES"].BeginInit();
    //    if (mode == cls_Struct.ActionMode.Add)
    //    {
    //      //SEQUENSE_NO ติดลบเรื่อยๆ???  //XXXX
    //      row = dsEdit.Tables["D_CUSTOMER_ADDRESSES"].NewRow();
    //      row["CUSTOMER_ID"] = itemID;
    //      row["SEQUENSE_NO"] = 0;
    //      row["ADDRESS_TYPE"] = cls_Library.DBString(frmInput.txtLocation.Text);
    //      row["ADDRESS_1"] = cls_Library.DBString(frmInput.txtAddr1.Text);
    //      row["ADDRESS_2"] = cls_Library.DBString(frmInput.txtAddr2.Text);
    //      row["ADDRESS_3"] = cls_Library.DBString(frmInput.txtAddr3.Text);
    //      row["ADDRESS_4"] = cls_Library.DBString(frmInput.txtAddr4.Text);

    //      row["mode"] = cls_Struct.ActionMode.Add;
    //      //row["change"] = 1;

    //      dsEdit.Tables["D_CUSTOMER_ADDRESSES"].Rows.Add(row);
    //    }
    //    else
    //    {          
    //      row["ADDRESS_TYPE"] = cls_Library.DBString(frmInput.txtLocation.Text);
    //      row["ADDRESS_1"] = cls_Library.DBString(frmInput.txtAddr1.Text);
    //      row["ADDRESS_2"] = cls_Library.DBString(frmInput.txtAddr2.Text);
    //      row["ADDRESS_3"] = cls_Library.DBString(frmInput.txtAddr3.Text);
    //      row["ADDRESS_4"] = cls_Library.DBString(frmInput.txtAddr4.Text);

    //      row["mode"] = cls_Struct.ActionMode.Edit;
    //      //row["change"] = 1;
    //    }

    //    dsEdit.Tables["D_CUSTOMER_ADDRESSES"].EndInit();
    //    SetGrid();
    //  }
    //  catch (Exception ex)
    //  {
    //    XtraMessageBox.Show("InitialDialogAddress : " + ex.Message);
    //  }
    //}
    #endregion

    #region ชื่อจ่ายเช็ค
    private void InitialDialogCheque(cls_Struct.ActionMode mode)
    {
      DataRow row = null;
      string strMode = "";
      int _no = 0;
      try
      {
        switch (mode)
        {
          case cls_Struct.ActionMode.Add:
            strMode = " [เพิ่ม]";
            break;
          case cls_Struct.ActionMode.Edit:
            row = gvCheques.GetFocusedDataRow();
            if (row == null) return;
            strMode = " [แก้ไข]";
            break;
          case cls_Struct.ActionMode.Delete:
            row = gvCheques.GetFocusedDataRow();
            if (row == null) return;
            if (XtraMessageBox.Show("ต้องการลบรายการที่ " + (gvCheques.FocusedRowHandle + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            int no = cls_Library.DBInt(row["SEQUENSE_NO"]);
            if (no <= 0)
            {
              dsEdit.Tables["D_CUSTOMER_CHEQUES"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r => dsEdit.Tables["D_CUSTOMER_CHEQUES"].Rows.Remove(r));
              dsEdit.Tables["D_CUSTOMER_CHEQUES"].AcceptChanges();
            }
            else
            {
              dsEdit.Tables["D_CUSTOMER_CHEQUES"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r =>
              {
                //r["change"] = 1;
                r["mode"] = cls_Struct.ActionMode.Delete;
                r.AcceptChanges();
              });
            }
            AddDataSourceToGrid(3);
            return;
        }

        frmD_Cheque_Input frmInput = new frmD_Cheque_Input(1);
        frmInput.Text = "ชื่อจ่ายเช็ค" + strMode;

        #region Set Control

        if (mode == cls_Struct.ActionMode.Edit)
        {
          frmInput.txtName.Text = cls_Library.DBString(row["CHEQUE_NAME"]);
          frmInput.chkUse.EditValue = cls_Library.DBbool(row["CHEQUE_STATUS"]);
          frmInput.txtNote.Text = cls_Library.DBString(row["REMARK"]);
        }
        else
        {
          frmInput.txtName.Text = "";
          frmInput.chkUse.EditValue = false;
          frmInput.txtNote.Text = "";
        }
        #endregion

        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;
        dsEdit.Tables["D_CUSTOMER_CHEQUES"].BeginInit();
        if (mode == cls_Struct.ActionMode.Add)
        {
          row = dsEdit.Tables["D_CUSTOMER_CHEQUES"].NewRow();
          row["CUSTOMER_ID"] = itemID;
          row["SEQUENSE_NO"] = ChequeID--;
          row["LIST_NO"] = dsEdit.Tables["D_CUSTOMER_CHEQUES"].Rows.Count + 1;
          row["CHEQUE_NAME"] = cls_Library.DBString(frmInput.txtName.Text);
          row["CHEQUE_STATUS"] = cls_Library.DBInt(frmInput.chkUse.EditValue);
          row["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);

          row["mode"] = cls_Struct.ActionMode.Add;
          //row["change"] = 1;

          dsEdit.Tables["D_CUSTOMER_CHEQUES"].Rows.Add(row);
        }
        else
        {
          _no = cls_Library.DBInt(row["SEQUENSE_NO"]);
          DataRow[] dr= dsEdit.Tables["D_CUSTOMER_CHEQUES"].Select("SEQUENSE_NO = " + _no);
          if (dr.Count() > 0)
          {
            dr[0]["CHEQUE_NAME"] = cls_Library.DBString(frmInput.txtName.Text);
            dr[0]["CHEQUE_STATUS"] = cls_Library.DBInt(frmInput.chkUse.EditValue);
            dr[0]["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);

            if (_no > 0) dr[0]["mode"] = cls_Struct.ActionMode.Edit;
          }
        }

        dsEdit.Tables["D_CUSTOMER_CHEQUES"].EndInit();
        AddDataSourceToGrid(3);
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("InitialDialogCheque : " + ex.Message);
      }
    }
    #endregion

    #region บัญชีธนาคาร
    private void InitialDialogBank(cls_Struct.ActionMode mode)
    {
      DataRow row = null;
      string strMode = "";
      int _no = 0;
      try
      {
        switch (mode)
        {
          case cls_Struct.ActionMode.Add:
            strMode = " [เพิ่ม]";
            break;
          case cls_Struct.ActionMode.Edit:
            row = gvBank.GetFocusedDataRow();
            if (row == null) return;
            strMode = " [แก้ไข]";
            break;
          case cls_Struct.ActionMode.Delete:
            row = gvBank.GetFocusedDataRow();
            if (row == null) return;
            if (XtraMessageBox.Show("ต้องการลบรายการที่ " + (gvBank.FocusedRowHandle + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            int no = cls_Library.DBInt(row["SEQUENSE_NO"]);
            if (no <= 0)
            {
              dsEdit.Tables["D_CUSTOMER_BANKS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r => dsEdit.Tables["D_CUSTOMER_BANKS"].Rows.Remove(r));
              dsEdit.Tables["D_CUSTOMER_BANKS"].AcceptChanges();
            }
            else
            {
              dsEdit.Tables["D_CUSTOMER_BANKS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r =>
              {
                //r["change"] = 1;
                r["mode"] = cls_Struct.ActionMode.Delete;
                r.AcceptChanges();
              });
            }
            AddDataSourceToGrid(4);
            return;
        }

        frmD_Bank_Input frmInput = new frmD_Bank_Input(1);
        frmInput.Text = "บัญชีธนาคาร" + strMode;

        #region Set Control

        cls_Library.AssignSearchLookUp(frmInput.sluBank, "M_BANKS", "รหัสธนาคาร", "ชื่อธนาคาร");
        //cls_Library.AssignSearchLookUp(frmInput.sluBranch, "D_BANK_BRANCHS", "รหัสสาขา", "ชื่อสาขา");
        frmInput.sluBank.Properties.DataSource = cls_Global_DB.DataInitial.Tables["M_BANKS"];
        frmInput.sluBank.Properties.PopulateViewColumns();
        frmInput.sluBank.Properties.ValueMember = "_id";
        frmInput.sluBank.Properties.DisplayMember = "code";
        frmInput.sluBank.Properties.View.Columns["_id"].Visible = false;
        frmInput.sluBank.Properties.View.Columns["code"].Caption = "ชื่อย่อธนาคาร";
        frmInput.sluBank.Properties.View.Columns["name"].Caption = "ชื่อธนาคาร";
        frmInput.sluBank.EditValue = 0;

        if (mode == cls_Struct.ActionMode.Edit)
        {
          frmInput.sluBank.EditValue = cls_Library.DBInt(row["BANK_ID"]);
          
          frmInput.txtBankName.Text = cls_Library.DBString(row["FULL_NAME"]);
          frmInput.txtBranchName.Text = cls_Library.DBString(row["BRANCH_NAME"]);
          frmInput.txtAccountNo.Text = cls_Library.DBString(row["ACCOUNT_NO"]);
          frmInput.txtAccountName.Text = cls_Library.DBString(row["ACCOUNT_NAME"]);
          switch (cls_Library.DBString(row["ACCOUNT_NAME"]))
	        {
            case "S":
              frmInput.radioType.SelectedIndex = 0;
              break;
		        case "C":
              frmInput.radioType.SelectedIndex = 1;
              break;
	        }

          frmInput.txtNote.Text = cls_Library.DBString(row["REMARK"]);
        }
        else
        {
          frmInput.sluBank.EditValue = 0;
          frmInput.txtBankName.Text = "";
          frmInput.txtBranchName.Text = "";
          frmInput.txtAccountNo.Text = "";
          frmInput.txtAccountName.Text = "";
          frmInput.radioType.SelectedIndex = 0;
          frmInput.txtNote.Text = "";
        }
        #endregion

        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;
        dsEdit.Tables["D_CUSTOMER_BANKS"].BeginInit();
        if (mode == cls_Struct.ActionMode.Add)
        {
          row = dsEdit.Tables["D_CUSTOMER_BANKS"].NewRow();
          row["CUSTOMER_ID"] = itemID;
          row["SEQUENSE_NO"] = BankID--;
          row["LIST_NO"] = dsEdit.Tables["D_CUSTOMER_BANKS"].Rows.Count + 1;
          row["BANK_ID"] = cls_Library.DBInt(frmInput.sluBank.EditValue);
          row["ABBREVIATE_NAME"] = cls_Library.DBString(frmInput.sluBank.Text.Trim());
          row["FULL_NAME"] = cls_Library.DBString(frmInput.txtBankName.Text);
          row["BRANCH_NAME"] = cls_Library.DBString(frmInput.txtBranchName.Text);
          row["ACCOUNT_NO"] = cls_Library.DBString(frmInput.txtAccountNo.Text.Trim());
          row["ACCOUNT_NAME"] = cls_Library.DBString(frmInput.txtAccountName.Text);
          row["ACCOUNT_STATUS"] = frmInput.radioType.SelectedIndex == 0 ? "S" : "C";
          row["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);

          row["mode"] = cls_Struct.ActionMode.Add;
          //row["change"] = 1;

          dsEdit.Tables["D_CUSTOMER_BANKS"].Rows.Add(row);
        }
        else
        {
          _no = cls_Library.DBInt(row["SEQUENSE_NO"]);
          DataRow[] dr = dsEdit.Tables["D_CUSTOMER_BANKS"].Select("SEQUENSE_NO = " + _no);
          if (dr.Count() > 0)
          {
            dr[0]["BANK_ID"] = cls_Library.DBInt(frmInput.sluBank.EditValue);
            dr[0]["ABBREVIATE_NAME"] = cls_Library.DBString(frmInput.sluBank.Text.Trim());
            dr[0]["FULL_NAME"] = cls_Library.DBString(frmInput.txtBankName.Text);
            dr[0]["BRANCH_NAME"] = cls_Library.DBString(frmInput.txtBranchName.Text);
            dr[0]["ACCOUNT_NO"] = cls_Library.DBString(frmInput.txtAccountNo.Text.Trim());
            dr[0]["ACCOUNT_NAME"] = cls_Library.DBString(frmInput.txtAccountName.Text);
            dr[0]["ACCOUNT_STATUS"] = frmInput.radioType.SelectedIndex == 0 ? "S" : "C";
            dr[0]["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);

            if (_no > 0) dr[0]["mode"] = cls_Struct.ActionMode.Edit;
          }
        }

        dsEdit.Tables["D_CUSTOMER_BANKS"].EndInit();
        AddDataSourceToGrid(4);

      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("InitialDialogBank : " + ex.Message);
      }
    }
    #endregion

    #region ทะเบียนรถยนต์
    private void InitialDialogCar(cls_Struct.ActionMode mode)
    {
      DataRow row = null;
      string strMode = "";
      int _no = 0;
      try
      {
        switch (mode)
        {
          case cls_Struct.ActionMode.Add:
            strMode = " [เพิ่ม]";
            break;
          case cls_Struct.ActionMode.Edit:
            row = gvCar.GetFocusedDataRow();
            if (row == null) return;
            strMode = " [แก้ไข]";
            break;
          case cls_Struct.ActionMode.Delete:
            row = gvCar.GetFocusedDataRow();
            if (row == null) return;
            if (XtraMessageBox.Show("ต้องการลบรายการที่ " + (gvCar.FocusedRowHandle + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            int no = cls_Library.DBInt(row["SEQUENSE_NO"]);
            if (no <= 0)
            {
              dsEdit.Tables["D_CUSTOMER_CARS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r => dsEdit.Tables["D_CUSTOMER_CARS"].Rows.Remove(r));
              dsEdit.Tables["D_CUSTOMER_CARS"].AcceptChanges();
            }
            else
            {
              dsEdit.Tables["D_CUSTOMER_CARS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r =>
              {
                //r["change"] = 1;
                r["mode"] = cls_Struct.ActionMode.Delete;
                r.AcceptChanges();
              });
            }
            AddDataSourceToGrid(5);
            return;
        }

        frmD_Car_Input frmInput = new frmD_Car_Input();
        frmInput.Text = "ทะเบียนรถยนต์" + strMode;

        #region Set Control
        if (mode == cls_Struct.ActionMode.Edit)
        {
          frmInput.txtlicense.Text = cls_Library.DBString(row["CAR_LICENSE_PLATE"]);
          frmInput.txtBrand.Text = cls_Library.DBString(row["CAR_BRAND_NAME"]);
          frmInput.txtModel.Text = cls_Library.DBString(row["CAR_MODEL"]);
          frmInput.txtYear.Text = cls_Library.DBString(row["CAR_YEAR"]);
          frmInput.txtNote.Text = cls_Library.DBString(row["REMARK"]);
        }
        else
        {
          frmInput.txtlicense.Text = "";
          frmInput.txtBrand.Text = "";
          frmInput.txtModel.Text = "";
          frmInput.txtYear.Text = "";
          frmInput.txtNote.Text = "";
        }
        #endregion

        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;
        dsEdit.Tables["D_CUSTOMER_CARS"].BeginInit();
        if (mode == cls_Struct.ActionMode.Add)
        {
          row = dsEdit.Tables["D_CUSTOMER_CARS"].NewRow();
          row["CUSTOMER_ID"] = itemID;
          row["SEQUENSE_NO"] = CarID--;
          row["LIST_NO"] = dsEdit.Tables["D_CUSTOMER_CARS"].Rows.Count + 1;
          row["CAR_LICENSE_PLATE"] = cls_Library.DBString(frmInput.txtlicense .Text);
          row["CAR_BRAND_NAME"] = cls_Library.DBString(frmInput.txtBrand.Text);
          row["CAR_MODEL"] = cls_Library.DBString(frmInput.txtModel.Text);
          row["CAR_YEAR"] = cls_Library.DBString(frmInput.txtYear.Text);
          row["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);

          row["mode"] = cls_Struct.ActionMode.Add;
          //row["change"] = 1;

          dsEdit.Tables["D_CUSTOMER_CARS"].Rows.Add(row);
        }
        else
        {
          _no = cls_Library.DBInt(row["SEQUENSE_NO"]);
          DataRow[] dr= dsEdit.Tables["D_CUSTOMER_CARS"].Select("SEQUENSE_NO = " + _no);
          if (dr.Count() > 0)
          {
            dr[0]["CAR_LICENSE_PLATE"] = cls_Library.DBString(frmInput.txtlicense.Text);
            dr[0]["CAR_BRAND_NAME"] = cls_Library.DBString(frmInput.txtBrand.Text);
            dr[0]["CAR_MODEL"] = cls_Library.DBString(frmInput.txtModel.Text);
            dr[0]["CAR_YEAR"] = cls_Library.DBString(frmInput.txtYear.Text);
            dr[0]["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);

            if (_no > 0) dr[0]["mode"] = cls_Struct.ActionMode.Edit;
          }
        }

        dsEdit.Tables["D_CUSTOMER_CARS"].EndInit();
        AddDataSourceToGrid(5);

      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("InitialDialogCar : " + ex.Message);
      }
    }
    #endregion

    #region ประวัติการติดตามหนี้
    private void InitialDialogTracks(cls_Struct.ActionMode mode)
    {
      DataRow row = null;
      string strMode = "";
      int _no = 0;
      try
      {
        switch (mode)
        {
          case cls_Struct.ActionMode.Add:
            strMode = " [เพิ่ม]";
            break;
          case cls_Struct.ActionMode.Edit:
            row = gvHistory.GetFocusedDataRow();
            if (row == null) return;
            strMode = " [แก้ไข]";
            break;
          case cls_Struct.ActionMode.Delete:
            row = gvHistory.GetFocusedDataRow();
            if (row == null) return;
            if (XtraMessageBox.Show("ต้องการลบรายการที่ " + (gvHistory.FocusedRowHandle + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            int no = cls_Library.DBInt(row["SEQUENSE_NO"]);
            if (no <= 0)
            {
              dsEdit.Tables["D_CUSTOMER_TRACKS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r => dsEdit.Tables["D_CUSTOMER_TRACKS"].Rows.Remove(r));
              dsEdit.Tables["D_CUSTOMER_TRACKS"].AcceptChanges();
            }
            else
            {
              dsEdit.Tables["D_CUSTOMER_TRACKS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r =>
              {
                //r["change"] = 1;
                r["mode"] = cls_Struct.ActionMode.Delete;
                r.AcceptChanges();
              });
            }
            AddDataSourceToGrid(6);
            return;
        }

        frmD_Tracks_Input frmInput = new frmD_Tracks_Input();
        frmInput.Text = "ประวัติการติดตามหนี้" + strMode;

        #region Set Control
        //XXXXXXXXXXXXX
        cls_Library.AssignSearchLookUp(frmInput.sluUser, "M_USERS", "รหัสผู้ใช้", "ชื่อผู้ใช้");

        if (mode == cls_Struct.ActionMode.Edit)
        {
          frmInput.dateTrack.EditValue = cls_Library.DBDateTime(row["TRACK_DATE"]);
          frmInput.sluUser.EditValue = cls_Library.DBInt(row["USER_ID"]);
          frmInput.txtName.Text = cls_Library.DBString(row["USER_NAME"]);
          frmInput.txtNote.Text = cls_Library.DBString(row["REMARK"]);
        }
        else
        {
          frmInput.dateTrack.EditValue = DateTime.Now;
          frmInput.sluUser.EditValue = 0;
          frmInput.txtName.Text = "";
          frmInput.txtNote.Text = "";
        }

        #endregion

        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;

        dsEdit.Tables["D_CUSTOMER_TRACKS"].BeginInit();
        if (mode == cls_Struct.ActionMode.Add)
        {
          row = dsEdit.Tables["D_CUSTOMER_TRACKS"].NewRow();
          row["CUSTOMER_ID"] = itemID;
          row["SEQUENSE_NO"] = TrackID--;
          row["LIST_NO"] = dsEdit.Tables["D_CUSTOMER_TRACKS"].Rows.Count + 1;
          row["TRACK_DATE"] = cls_Library.DBDateTime(frmInput.dateTrack.EditValue);
          row["USER_ID"] = cls_Library.DBInt(frmInput.sluUser.EditValue);
          row["USER_NAME"] = cls_Library.DBString(frmInput.sluUser.Text);
          row["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);

          row["mode"] = cls_Struct.ActionMode.Add;
          //row["change"] = 1;

          dsEdit.Tables["D_CUSTOMER_TRACKS"].Rows.Add(row);
        }
        else
        {
          _no = cls_Library.DBInt(row["SEQUENSE_NO"]);
          DataRow[] dr= dsEdit.Tables["D_CUSTOMER_TRACKS"].Select("SEQUENSE_NO = " + _no);
          if (dr.Count() > 0)
          {

            dr[0]["TRACK_DATE"] = cls_Library.DBDateTime(frmInput.dateTrack.EditValue);
            dr[0]["USER_ID"] = cls_Library.DBInt(frmInput.sluUser.EditValue);
            dr[0]["USER_NAME"] = cls_Library.DBString(frmInput.sluUser.Text);
            dr[0]["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);

            if (_no > 0) dr[0]["mode"] = cls_Struct.ActionMode.Edit;
          }
        }

        dsEdit.Tables["D_CUSTOMER_TRACKS"].EndInit();
        AddDataSourceToGrid(6);
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("InitialDialogTracks : " + ex.Message);
      }
    }
    #endregion

    #region ยี่ห้อสินค้าที่ได้รับส่วนลด
    private void InitialDialogBrandDiscount(cls_Struct.ActionMode mode)
    {
      DataRow row = null;
      string strMode = "";
      int _no = 0;
      try
      {
        switch (mode)
        {
          case cls_Struct.ActionMode.Add:
            strMode = " [เพิ่ม]";
            break;
          case cls_Struct.ActionMode.Edit:
            row = gvBrandDiscount.GetFocusedDataRow();
            if (row == null) return;
            strMode = " [แก้ไข]";
            break;
          case cls_Struct.ActionMode.Delete:
            row = gvBrandDiscount.GetFocusedDataRow();
            if (row == null) return;
            if (XtraMessageBox.Show("ต้องการลบรายการที่ " + (gvBrandDiscount.FocusedRowHandle + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            int no = cls_Library.DBInt(row["SEQUENSE_NO"]);
            if (no <= 0)
            {
              dsEdit.Tables["D_CUSTOMER_BRAND_DISCOUNT_STEPS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r => dsEdit.Tables["D_CUSTOMER_BRAND_DISCOUNT_STEPS"].Rows.Remove(r));
              dsEdit.Tables["D_CUSTOMER_BRAND_DISCOUNT_STEPS"].AcceptChanges();
            }
            else
            {
              dsEdit.Tables["D_CUSTOMER_BRAND_DISCOUNT_STEPS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r =>
              {
                //r["change"] = 1;
                r["mode"] = cls_Struct.ActionMode.Delete;
                r.AcceptChanges();
              });
            }
            AddDataSourceToGrid(7);
            return;
        }

        frmD_BrandDiscount_Input frmInput = new frmD_BrandDiscount_Input();
        frmInput.Text = "ยี่ห้อสินค้าที่ได้รับส่วนลด" + strMode;

        #region Set Control
        //XXXXXXXXXXXXX
        cls_Library.AssignSearchLookUp(frmInput.sluBrand, "M_BRANDS", "รหัสยี่ห้อสินค้า", "ชื่อยี่ห้อสินค้า");

        if (mode == cls_Struct.ActionMode.Edit)
        {
          frmInput.sluBrand.EditValue = cls_Library.DBInt(row["BRAND_ID"]);
          frmInput.txtBrandName.Text = cls_Library.DBString(row["BRAND_NAME"]);
          frmInput.spinDisC1.EditValue = cls_Library.DBDouble(row["DISCOUNT_RATE_STEP1"]);
          frmInput.spinDisC2.EditValue = cls_Library.DBDouble(row["DISCOUNT_RATE_STEP2"]);
          frmInput.spinDisC3.EditValue = cls_Library.DBDouble(row["DISCOUNT_RATE_STEP3"]);
          frmInput.spinDisC4.EditValue = cls_Library.DBDouble(row["DISCOUNT_RATE_STEP4"]);
        }
        else
        {
          frmInput.sluBrand.EditValue = 0;
          frmInput.txtBrandName.Text = "";
          frmInput.spinDisC1.EditValue = 0;
          frmInput.spinDisC2.EditValue = 0;
          frmInput.spinDisC3.EditValue = 0;
          frmInput.spinDisC4.EditValue = 0;
        }
        #endregion

        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;
        dsEdit.Tables["D_CUSTOMER_BRAND_DISCOUNT_STEPS"].BeginInit();
        if (mode == cls_Struct.ActionMode.Add)
        {
          row = dsEdit.Tables["D_CUSTOMER_BRAND_DISCOUNT_STEPS"].NewRow();
          row["CUSTOMER_ID"] = itemID;
          row["SEQUENSE_NO"] = BrandDID--;
          row["LIST_NO"] = dsEdit.Tables["D_CUSTOMER_BRAND_DISCOUNT_STEPS"].Rows.Count + 1;
          row["BRAND_ID"] = cls_Library.DBInt(frmInput.sluBrand.EditValue);
          row["BRAND_CODE"] = cls_Library.DBString(frmInput.sluBrand.Text);
          row["BRAND_NAME"] = cls_Library.DBString(frmInput.txtBrandName.Text);
          row["DESCRIPTION"] = frmInput.BrandDesc;
          row["DISCOUNT_RATE_STEP1"] = cls_Library.DBDouble(frmInput.spinDisC1.EditValue);
          row["DISCOUNT_RATE_STEP2"] = cls_Library.DBDouble(frmInput.spinDisC2.EditValue);
          row["DISCOUNT_RATE_STEP3"] = cls_Library.DBDouble(frmInput.spinDisC3.EditValue);
          row["DISCOUNT_RATE_STEP4"] = cls_Library.DBDouble(frmInput.spinDisC4.EditValue);


          row["mode"] = cls_Struct.ActionMode.Add;
          //row["change"] = 1;

          dsEdit.Tables["D_CUSTOMER_BRAND_DISCOUNT_STEPS"].Rows.Add(row);
        }
        else
        {
          _no = cls_Library.DBInt(row["SEQUENSE_NO"]);
          DataRow[] dr = dsEdit.Tables["D_CUSTOMER_BRAND_DISCOUNT_STEPS"].Select("SEQUENSE_NO = " + _no);
          if (dr.Count() > 0)
          {
            dr[0]["BRAND_ID"] = cls_Library.DBInt(frmInput.sluBrand.EditValue);
            dr[0]["BRAND_CODE"] = cls_Library.DBString(frmInput.sluBrand.Text);
            dr[0]["BRAND_NAME"] = cls_Library.DBString(frmInput.txtBrandName.Text);
            dr[0]["DESCRIPTION"] = frmInput.BrandDesc;
            dr[0]["DISCOUNT_RATE_STEP1"] = cls_Library.DBDouble(frmInput.spinDisC1.EditValue);
            dr[0]["DISCOUNT_RATE_STEP2"] = cls_Library.DBDouble(frmInput.spinDisC2.EditValue);
            dr[0]["DISCOUNT_RATE_STEP3"] = cls_Library.DBDouble(frmInput.spinDisC3.EditValue);
            dr[0]["DISCOUNT_RATE_STEP4"] = cls_Library.DBDouble(frmInput.spinDisC4.EditValue);

            if (_no > 0) dr[0]["mode"] = cls_Struct.ActionMode.Edit;
          }
        }

        dsEdit.Tables["D_CUSTOMER_BRAND_DISCOUNT_STEPS"].EndInit();
        AddDataSourceToGrid(7);

      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("InitialDialogBrandDiscount : " + ex.Message);
      }
    }
    #endregion

    #endregion

    public frm_Customers_Record(cls_Struct.ActionMode mode, int id)
    {
      InitializeComponent();
      KeyPreview = true;
      DataMode = mode;
      itemID = id;
      InitialDialog();
      switch (DataMode)
      {
        case cls_Struct.ActionMode.View:
          BTsave.Visible = false;
          BTsaveclose.Visible = false;
          break;
      }
      txtCode.Focus();
    }

    private void bwCode_DoWork(object sender, DoWorkEventArgs e)
    {
      //Cursor = Cursors.WaitCursor;
      dsMainData = cls_Data.GetCustomerById(itemID);
    }

    private void bwCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      try
      {
        SetDataToControl();
      }
      catch (Exception)
      {
      }
      finally { Cursor = Cursors.Default; }
    }

    private void gvContract_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void gvAddress_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void gvCheques_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void gvBank_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void gvCar_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void gvHistory_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void gvBrandDiscount_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void btT1Add_Click(object sender, EventArgs e)
    {
      InitialDialogContract(cls_Struct.ActionMode.Add);
    }

    private void btT1Edit_Click(object sender, EventArgs e)
    {
      InitialDialogContract(cls_Struct.ActionMode.Edit);
    }

    private void btT1Delete_Click(object sender, EventArgs e)
    {
      InitialDialogContract(cls_Struct.ActionMode.Delete);
    }

    //private void btT2Add_Click(object sender, EventArgs e)
    //{
    //  InitialDialogAddress(cls_Struct.ActionMode.Add);
    //}

    //private void btT2Edit_Click(object sender, EventArgs e)
    //{
    //  InitialDialogAddress(cls_Struct.ActionMode.Edit);
    //}

    //private void btT2Delete_Click(object sender, EventArgs e)
    //{
    //  InitialDialogAddress(cls_Struct.ActionMode.Delete);
    //}

    private void btT3Add_Click(object sender, EventArgs e)
    {
      InitialDialogCheque(cls_Struct.ActionMode.Add);
    }

    private void btT3Edit_Click(object sender, EventArgs e)
    {
      InitialDialogCheque(cls_Struct.ActionMode.Edit);
    }

    private void btT3Delete_Click(object sender, EventArgs e)
    {
      InitialDialogCheque(cls_Struct.ActionMode.Delete);
    }

    private void btT4Add_Click(object sender, EventArgs e)
    {
      InitialDialogBank(cls_Struct.ActionMode.Add);
    }

    private void btT4Edit_Click(object sender, EventArgs e)
    {
      InitialDialogBank(cls_Struct.ActionMode.Edit);
    }

    private void btT4Delete_Click(object sender, EventArgs e)
    {
      InitialDialogBank(cls_Struct.ActionMode.Delete);
    }

    private void btT5Add_Click(object sender, EventArgs e)
    {
      InitialDialogCar(cls_Struct.ActionMode.Add);
    }

    private void btT5Edit_Click(object sender, EventArgs e)
    {
      InitialDialogCar(cls_Struct.ActionMode.Edit);
    }

    private void btT5Delete_Click(object sender, EventArgs e)
    {
      InitialDialogCar(cls_Struct.ActionMode.Delete);
    }

    private void btT6Add_Click(object sender, EventArgs e)
    {
      InitialDialogTracks(cls_Struct.ActionMode.Add);
    }

    private void btT6Edit_Click(object sender, EventArgs e)
    {
      InitialDialogTracks(cls_Struct.ActionMode.Edit);
    }

    private void btT6Delete_Click(object sender, EventArgs e)
    {
      InitialDialogTracks(cls_Struct.ActionMode.Delete);
    }

    private void btT7Add_Click(object sender, EventArgs e)
    {
      InitialDialogBrandDiscount(cls_Struct.ActionMode.Add);
    }

    private void btT7Edit_Click(object sender, EventArgs e)
    {
      InitialDialogBrandDiscount(cls_Struct.ActionMode.Edit);
    }

    private void btT7Delete_Click(object sender, EventArgs e)
    {
      InitialDialogBrandDiscount(cls_Struct.ActionMode.Delete);
    }

    private void frm_Customers_Record_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F2:
          if (DataMode == cls_Struct.ActionMode.View) return;
          BTsave_Click(sender, e);
          break;
        case Keys.Escape:
          BTcancel_Click(sender, e);
          break;
      }
    }

    private void BTsave_Click(object sender, EventArgs e)
    {
      if (!VerifyData())
      {
        if (XtraMessageBox.Show("ต้องการบันทึกรหัสลูกค้า : " + txtCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
        if (SaveData())
        {
          XtraMessageBox.Show("บันทึกรหัสลูกค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
          IsSaveOK = true;
          if (((SimpleButton)sender).Tag.ToString() == "1")
          {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
          }
        }
        else
        {
          IsSaveOK = false;
          XtraMessageBox.Show("บันทึกรหัสลูกค้าไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }
      
    }

    private void BTcancel_Click(object sender, EventArgs e)
    {
      if (IsSaveOK)
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
      else
        DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }
  }
}
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
  public partial class frm_Vendors_Record : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private cls_Struct.StructVENDORS VEN = new cls_Struct.StructVENDORS();
    private cls_Struct.ActionMode DataMode;
    private int itemID = 0;
    private DataSet dsMainData = new DataSet();
    private DataSet dsEdit = new DataSet();
    private string Vencode = "";
    private string strBasePath = "";

    private bool IsSaveOK = false;
    private int ContractID = 0;
    private int ChequeID = 0;
    private int BankID = 0;
    private int ItemTypeID = 0;
    #endregion

    #region Property
    
    #endregion

    #region User define function

    private void AssignDataFromComponent()
    {
      
      VEN.VENDOR_ID = itemID;
      VEN.VENDOR_CODE = txtCode.Text.Trim();
      VEN.VENDOR_NAME = txtName.Text.Trim();
      VEN.DETAIL_1 = txtDetail1.Text.Trim();
      VEN.DETAIL_2 = txtDetail2.Text.Trim();
      VEN.DETAIL_3 = txtDetail3.Text.Trim();
      VEN.REMARK = txtNote.Text.Trim();
      VEN.E_MAIL = txtEmail.Text.Trim();
      VEN.ADDRESS_1 = txtAddr1.Text.Trim();
      VEN.ADDRESS_2 = txtAddr2.Text.Trim();
      VEN.ADDRESS_3 = txtAddr3.Text.Trim();
      VEN.ADDRESS_4 = txtAddr4.Text.Trim();
      VEN.LOCATION = txtLocation.Text.Trim();
      VEN.TAX_ID = txtTaxID.Text.Trim();
      VEN.START_CONTRACT_DATE = cls_Library.DBDateTime(dateStart.EditValue);
      VEN.LAST_CONTRACT_DATE = cls_Library.DBDateTime(dateEnd.EditValue);
      VEN.MAP_FILE_NAME = txtfilename.Text.Trim();
      //MemoryStream ms = new MemoryStream();
      //imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
      //return ms.ToArray();
      //VEN.MAP_IMAGE = img.imageToByteArray(picDisplay.Image);
      //Class_ImageResize img = new Class_ImageResize();
      if (!string.IsNullOrEmpty(VEN.MAP_FILE_NAME))
      {
        Image imageIn = picDisplay.Image;
        MemoryStream ms = new MemoryStream();
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        VEN.MAP_IMAGE = ms.ToArray();
      }
      else
      {
        VEN.MAP_IMAGE =null;
      }
      
      VEN.MDETAIL_1  = memoDetail1.Text.Trim();
      VEN.MDETAIL_2 = memoDetail2.Text.Trim();
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
            _listdt = dsEdit.Tables["D_VENDOR_CONTRACTORS"].AsEnumerable().AsParallel().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).OrderBy(r => r.Field<Int16>("LIST_NO")).ToList();
            if (_listdt.Count > 0)
              dt = _listdt.CopyToDataTable();
            else
              dt = dsEdit.Tables["D_VENDOR_CONTRACTORS"].Clone();
            gridContract.DataSource = dt;
            gridContract.RefreshDataSource();
            break;
          case 2: //ชื่อจ่ายเช็ค
            _listdt = dsEdit.Tables["D_VENDOR_CHEQUES"].AsEnumerable().AsParallel().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).OrderBy(r => r.Field<Int16>("LIST_NO")).ToList();
            if (_listdt.Count > 0)
              dt = _listdt.CopyToDataTable();
            else
              dt = dsEdit.Tables["D_VENDOR_CHEQUES"].Clone();

            //dt = dsEdit.Tables["D_VENDOR_CHEQUES"].Clone();
            //dsEdit.Tables["D_VENDOR_CHEQUES"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList<DataRow>().ForEach(r => dt.ImportRow(r));
            

            gridCheques.DataSource = dt;
            gridCheques.RefreshDataSource();
            break;
          case 3: //บัญชีธนาคาร
            _listdt = dsEdit.Tables["D_VENDOR_BANKS"].AsEnumerable().AsParallel().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).OrderBy(r => r.Field<Int16>("LIST_NO")).ToList();
            if (_listdt.Count > 0)
              dt = _listdt.CopyToDataTable();
            else
              dt = dsEdit.Tables["D_VENDOR_BANKS"].Clone();
            gridBank.DataSource = dt;
            gridBank.RefreshDataSource();
            break;
          case 4: //ประเภทสินค้า
            _listdt = dsEdit.Tables["D_VENDOR_CREDIT_TERMS"].AsEnumerable().AsParallel().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).OrderBy(r => r.Field<Int16>("LIST_NO")).ToList();
            if (_listdt.Count > 0)
              dt = _listdt.CopyToDataTable();
            else
              dt = dsEdit.Tables["D_VENDOR_CREDIT_TERMS"].Clone();
            
            gridItemType.DataSource = dt;
            gridItemType.RefreshDataSource();
            break;
          //case 5: //ที่อยู่
          //  dt = dsEdit.Tables["D_CUSTOMER_ADDRESSES"].AsEnumerable().AsParallel().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).CopyToDataTable();
          //  gridAddress.DataSource = dt;
          //  gridAddress.RefreshDataSource();
          //  break;
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
      cmd.CommandText = "SELECT VENDOR_ID,VENDOR_CODE FROM M_VENDORS WHERE VENDOR_CODE='" + Xcode + "' And DELETED=0";
      cmd.Connection = conn;
      cmd.CommandTimeout = 30;
      cmd.CommandType = CommandType.Text;
      rd = cmd.ExecuteReader();
      if (rd.HasRows)
      {
        if ((DataMode == cls_Struct.ActionMode.Edit) || (DataMode == cls_Struct.ActionMode.Copy))
        {
          rd.Read();
          id =  cls_Library.DBInt(rd["VENDOR_ID"]);
          if (id != itemID)
          {
            err = true;
          }
        }
        else
        {
          err = true;
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

    private bool SaveData()
    {
      bool ret = false;
      try
      {        
        
        AssignDataFromComponent();

        //--- Save ข้อมูลลงฐานข้อมูล 
        cls_Global_DB.GB_ItemID = 0;
        ret = cls_Data.SaveVendorCode(DataMode, VEN, dsEdit);
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
          XtraMessageBox.Show("ไม่สามารถบันทึกรหัสพ่อค้าได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dsEdit.Tables["M_VENDORS"].Rows.Count <= 0) return;
            row = dsEdit.Tables["M_VENDORS"].Rows[0];

            Vencode = row["VENDOR_CODE"].ToString();
            txtCode.Text = row["VENDOR_CODE"].ToString();
            txtName.Text = row["VENDOR_NAME"].ToString();
            txtDetail1.Text = row["DETAIL_1"].ToString();
            txtDetail2.Text = row["DETAIL_2"].ToString();
            txtDetail3.Text = row["DETAIL_3"].ToString();
            txtNote.Text = row["REMARK"].ToString();
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

            if (string.IsNullOrEmpty(row["MAP_FILE_NAME"].ToString()))
            {
              picDisplay.Image = null;
            }
            else
            {
              var picbyte = (Byte[])(row["MAP_IMAGE"]);
              MemoryStream MemoryStreamData = new MemoryStream(picbyte);
              Image image = System.Drawing.Image.FromStream(MemoryStreamData);
              image.Save(strBasePath + "\\" + cls_Library.DBString(row["MAP_FILE_NAME"]));
              picDisplay.Image = image;
            }
            
            txtfilename.Text = row["MAP_FILE_NAME"].ToString();
            txtMapPath.Text = strBasePath + "\\" + cls_Library.DBString(row["MAP_FILE_NAME"]);

            memoDetail1.Text = row["MDETAIL_1"].ToString();
            memoDetail2.Text = row["MDETAIL_2"].ToString();
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
    { }

    private void SetGrid()
    {
      for (byte i = 1; i <= 5; i++)      
        AddDataSourceToGrid(i);

      //ผู้ติดต่อ
      cls_Library.BestFitColumns(gvContract);
      ////ที่อยู่
      //cls_Library.BestFitColumns(gvAddress);
      //ชื่อจ่ายเช็ค
      cls_Library.BestFitColumns(gvCheques);
      //บัญชีธนาคาร
      cls_Library.BestFitColumns(gvBank);
      //ประเภทสินค้า
      cls_Library.BestFitColumns(gvItemType);
    }

    private bool VerifyData()
    {
      bool err = false;
      try
      {
        if (txtCode.EditValue == null || txtCode.Text == "")
        {
          XtraMessageBox.Show("กรุณาระบุรหัสพ่อค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          txtCode.ErrorText = "กรุณาระบุรหัสพ่อค้า";
          txtCode.Focus();
          err = true;
        }
        else
        {
          if (txtCode.Text.Trim() != Vencode && CheckCodeExist(txtCode.Text.Trim()))
          {
            XtraMessageBox.Show("มีรหัสพ่อค้านี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtCode.ErrorText = "มีรหัสพ่อค้านี้ในฐานข้อมูลแล้ว";
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
              dsEdit.Tables["D_VENDOR_CONTRACTORS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r => dsEdit.Tables["D_VENDOR_CONTRACTORS"].Rows.Remove(r));
              dsEdit.Tables["D_VENDOR_CONTRACTORS"].AcceptChanges();
            }
            else
            {
              dsEdit.Tables["D_VENDOR_CONTRACTORS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r =>
              {
                //r["change"] = 1;
                r["mode"] = cls_Struct.ActionMode.Delete;
                r.AcceptChanges();
              });
            }
            AddDataSourceToGrid(1);
            return;
        }

        frmD_Contract_Input frmInput = new frmD_Contract_Input(2);
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
        dsEdit.Tables["D_VENDOR_CONTRACTORS"].BeginInit();
        if (mode == cls_Struct.ActionMode.Add)
        {
          row = dsEdit.Tables["D_VENDOR_CONTRACTORS"].NewRow();
          row["VENDOR_ID"] = itemID;
          row["SEQUENSE_NO"] = ContractID--;
          row["LIST_NO"] = dsEdit.Tables["D_VENDOR_CONTRACTORS"].Rows.Count + 1;
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

          dsEdit.Tables["D_VENDOR_CONTRACTORS"].Rows.Add(row);
        }
        else
        {
          _no = cls_Library.DBInt(row["SEQUENSE_NO"]);
          DataRow[] dr = dsEdit.Tables["D_VENDOR_CONTRACTORS"].Select("SEQUENSE_NO = " + _no);
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
          //row["change"] = 1;
        }

        dsEdit.Tables["D_VENDOR_CONTRACTORS"].EndInit();
        AddDataSourceToGrid(1);

      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("InitialDialogContract : " + ex.Message);
      }
    }
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
              dsEdit.Tables["D_VENDOR_CHEQUES"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r => dsEdit.Tables["D_VENDOR_CHEQUES"].Rows.Remove(r));
              dsEdit.Tables["D_VENDOR_CHEQUES"].AcceptChanges();
            }
            else
            {
              dsEdit.Tables["D_VENDOR_CHEQUES"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r =>
              {
                //r["change"] = 1;
                r["mode"] = cls_Struct.ActionMode.Delete;
                r.AcceptChanges();
              });
            }
            AddDataSourceToGrid(2);
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
        dsEdit.Tables["D_VENDOR_CHEQUES"].BeginInit();
        if (mode == cls_Struct.ActionMode.Add)
        {
          row = dsEdit.Tables["D_VENDOR_CHEQUES"].NewRow();
          row["VENDOR_ID"] = itemID;
          row["SEQUENSE_NO"] = ChequeID--;
          row["LIST_NO"] = dsEdit.Tables["D_VENDOR_CHEQUES"].Rows.Count + 1;
          row["CHEQUE_NAME"] = cls_Library.DBString(frmInput.txtName.Text);
          row["CHEQUE_STATUS"] = cls_Library.DBInt(frmInput.chkUse.EditValue);
          row["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);

          row["mode"] = cls_Struct.ActionMode.Add;
          //row["change"] = 1;

          dsEdit.Tables["D_VENDOR_CHEQUES"].Rows.Add(row);
        }
        else
        {
          _no = cls_Library.DBInt(row["SEQUENSE_NO"]);
          DataRow[] dr= dsEdit.Tables["D_VENDOR_CHEQUES"].Select("SEQUENSE_NO = " + _no);
          if (dr.Count() > 0)
          {
            dr[0]["CHEQUE_NAME"] = cls_Library.DBString(frmInput.txtName.Text);
            dr[0]["CHEQUE_STATUS"] = cls_Library.DBInt(frmInput.chkUse.EditValue);
            dr[0]["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);

            if (_no > 0) dr[0]["mode"] = cls_Struct.ActionMode.Edit;
          }
          
        }
        dsEdit.Tables["D_VENDOR_CHEQUES"].EndInit();
        AddDataSourceToGrid(2);
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
              dsEdit.Tables["D_VENDOR_BANKS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r => dsEdit.Tables["D_VENDOR_BANKS"].Rows.Remove(r));
              dsEdit.Tables["D_VENDOR_BANKS"].AcceptChanges();
            }
            else
            {
              dsEdit.Tables["D_VENDOR_BANKS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r =>
              {
                //r["change"] = 1;
                r["mode"] = cls_Struct.ActionMode.Delete;
                r.AcceptChanges();
              });
            }
            AddDataSourceToGrid(3);
            return;
        }

        frmD_Bank_Input frmInput = new frmD_Bank_Input(2);
        frmInput.Text = "บัญชีธนาคาร" + strMode;

        #region Set Control
        cls_Library.AssignSearchLookUp(frmInput.sluBank, "M_BANKS", "รหัสธนาคาร", "ชื่อธนาคาร");
        //cls_Library.AssignSearchLookUp(frmInput.sluBranch, "D_BANK_BRANCHS", "รหัสสาขา", "ชื่อสาขา");

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
        dsEdit.Tables["D_VENDOR_BANKS"].BeginInit();
        if (mode == cls_Struct.ActionMode.Add)
        {
          row = dsEdit.Tables["D_VENDOR_BANKS"].NewRow();
          row["VENDOR_ID"] = itemID;
          row["SEQUENSE_NO"] = BankID--;
          row["LIST_NO"] = dsEdit.Tables["D_VENDOR_BANKS"].Rows.Count + 1;
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

          dsEdit.Tables["D_VENDOR_BANKS"].Rows.Add(row);
        }
        else
        {
          _no = cls_Library.DBInt(row["SEQUENSE_NO"]);
          DataRow[] dr= dsEdit.Tables["D_VENDOR_BANKS"].Select("SEQUENSE_NO = " + _no);
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

        dsEdit.Tables["D_VENDOR_BANKS"].EndInit();
        AddDataSourceToGrid(3);

      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("InitialDialogBank : " + ex.Message);
      }
    }
    #endregion

    #region ประเภทสินค้า
    private void InitialDialogItemType(cls_Struct.ActionMode mode)
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
            row = gvItemType.GetFocusedDataRow();
            if (row == null) return;
            strMode = " [แก้ไข]";
            break;
          case cls_Struct.ActionMode.Delete:
            row = gvItemType.GetFocusedDataRow();
            if (row == null) return;
            if (XtraMessageBox.Show("ต้องการลบรายการที่ " + (gvItemType.FocusedRowHandle + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            int no = cls_Library.DBInt(row["SEQUENSE_NO"]);
            if (no <= 0)
            {
              dsEdit.Tables["D_VENDOR_CREDIT_TERMS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r => dsEdit.Tables["D_VENDOR_CREDIT_TERMS"].Rows.Remove(r));
              dsEdit.Tables["D_VENDOR_CREDIT_TERMS"].AcceptChanges();
            }
            else
            {
              dsEdit.Tables["D_VENDOR_CREDIT_TERMS"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r =>
              {
                //r["change"] = 1;
                r["mode"] = cls_Struct.ActionMode.Delete;
                r.AcceptChanges();
              });
            }
            AddDataSourceToGrid(4);
            return;
        }

        frmD_TypeItem_Input frmInput = new frmD_TypeItem_Input();
        frmInput.Text = "ประเภทสินค้า" + strMode;

        #region Set Control
        if (mode == cls_Struct.ActionMode.Edit)
        {
          frmInput.txtType.Text = cls_Library.DBString(row["ITEM_TYPE"]);
          switch (cls_Library.DBString(row["VAT_STATUS"]))
          {
            case "E":
              frmInput.radioVatStatus.SelectedIndex = 0;
              break;
            case "I":
              frmInput.radioVatStatus.SelectedIndex = 1;
              break;
            case "N":
              frmInput.radioVatStatus.SelectedIndex = 2;
              break;
          }
          frmInput.spinCredit.EditValue = cls_Library.DBInt(row["CREDIT_TERM"]);
          frmInput.txtNote.Text = cls_Library.DBString(row["REMARK"]);
        }
        else
        {
          frmInput.txtType.Text = "";
          frmInput.radioVatStatus.SelectedIndex = 0;
          frmInput.spinCredit.EditValue = 0;
          frmInput.txtNote.Text = "";
        }

        #endregion

        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;
        dsEdit.Tables["D_VENDOR_CREDIT_TERMS"].BeginInit();
        if (mode == cls_Struct.ActionMode.Add)
        {
          row = dsEdit.Tables["D_VENDOR_CREDIT_TERMS"].NewRow();
          row["VENDOR_ID"] = itemID;
          row["SEQUENSE_NO"] = ItemTypeID--;
          row["LIST_NO"] = dsEdit.Tables["D_VENDOR_CREDIT_TERMS"].Rows.Count + 1;
          row["ITEM_TYPE"] = cls_Library.DBString(frmInput.txtType.Text);
          switch (cls_Library.DBInt(frmInput.radioVatStatus.SelectedIndex))
          {
            case 0:
              row["VAT_STATUS"] = "E";
              row["_VAT_STATUS"] = "Vat นอก";
              break;
            case 1:
              row["VAT_STATUS"] = "I";
              row["_VAT_STATUS"] = "Vat ใน";
              break;
            case 2:
              row["VAT_STATUS"] = "N";
              row["_VAT_STATUS"] = "ไม่มี Vat";
              break;
          }
          row["CREDIT_TERM"] = cls_Library.DBInt(frmInput.spinCredit.EditValue);
          row["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);

          row["mode"] = cls_Struct.ActionMode.Add;
          //row["change"] = 1;

          dsEdit.Tables["D_VENDOR_CREDIT_TERMS"].Rows.Add(row);
        }
        else
        {
          _no = cls_Library.DBInt(row["SEQUENSE_NO"]);
          DataRow[] dr = dsEdit.Tables["D_VENDOR_CREDIT_TERMS"].Select("SEQUENSE_NO = " + _no);
          if (dr.Count() > 0)
          {
            dr[0]["ITEM_TYPE"] = cls_Library.DBString(frmInput.txtType.Text);
            switch (cls_Library.DBInt(frmInput.radioVatStatus.SelectedIndex))
            {
              case 0:
                dr[0]["VAT_STATUS"] = "E";
                dr[0]["_VAT_STATUS"] = "Vat นอก";
                break;
              case 1:
                dr[0]["VAT_STATUS"] = "I";
                dr[0]["_VAT_STATUS"] = "Vat ใน";
                break;
              case 2:
                dr[0]["VAT_STATUS"] = "N";
                dr[0]["_VAT_STATUS"] = "ไม่มี Vat";
                break;
            }
            dr[0]["CREDIT_TERM"] = cls_Library.DBInt(frmInput.spinCredit.EditValue);
            dr[0]["REMARK"] = cls_Library.DBString(frmInput.txtNote.Text);

            if (_no > 0) dr[0]["mode"] = cls_Struct.ActionMode.Edit;
          }
        }

        dsEdit.Tables["D_VENDOR_CREDIT_TERMS"].EndInit();
        AddDataSourceToGrid(4);


      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("InitialDialogItemType : " + ex.Message);
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
    //          dsEdit.Tables["D_VENDOR_ADDRESSES"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r => dsEdit.Tables["D_VENDOR_ADDRESSES"].Rows.Remove(r));
    //          dsEdit.Tables["D_VENDOR_ADDRESSES"].AcceptChanges();
    //        }
    //        else
    //        {
    //          dsEdit.Tables["D_VENDOR_ADDRESSES"].AsEnumerable().Where(r => r.Field<int>("SEQUENSE_NO") == no).ToList<DataRow>().ForEach(r =>
    //          {
    //            //r["change"] = 1;
    //            r["mode"] = cls_Struct.ActionMode.Delete;
    //            r.AcceptChanges();
    //          });
    //        }
    //        SetGrid();
    //        return;
    //    }

    //    frmD_Address_Input frmInput = new frmD_Address_Input(2);
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
    //    dsEdit.Tables["D_VENDOR_ADDRESSES"].BeginInit();
    //    if (mode == cls_Struct.ActionMode.Add)
    //    {
    //      //SEQUENSE_NO ติดลบเรื่อยๆ???  //XXXX
    //      row = dsEdit.Tables["D_VENDOR_ADDRESSES"].NewRow();
    //      row["CUSTOMER_ID"] = itemID;
    //      row["SEQUENSE_NO"] = 0;
    //      row["ADDRESS_TYPE"] = cls_Library.DBString(frmInput.txtLocation.Text);
    //      row["ADDRESS_1"] = cls_Library.DBString(frmInput.txtAddr1.Text);
    //      row["ADDRESS_2"] = cls_Library.DBString(frmInput.txtAddr2.Text);
    //      row["ADDRESS_3"] = cls_Library.DBString(frmInput.txtAddr3.Text);
    //      row["ADDRESS_4"] = cls_Library.DBString(frmInput.txtAddr4.Text);

    //      row["mode"] = cls_Struct.ActionMode.Add;
    //      //row["change"] = 1;

    //      dsEdit.Tables["D_VENDOR_ADDRESSES"].Rows.Add(row);
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

    //    dsEdit.Tables["D_VENDOR_ADDRESSES"].EndInit();
    //    SetGrid();
    //  }
    //  catch (Exception ex)
    //  {
    //    XtraMessageBox.Show("InitialDialogAddress : " + ex.Message);
    //  }
    //}
    #endregion

    #endregion

    public frm_Vendors_Record(cls_Struct.ActionMode mode, int id)
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
      dsMainData = cls_Data.GetVendorById(itemID);
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

    private void gvCheques_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void gvBank_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void gvItemType_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void gvAddress_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

    private void btT2Add_Click(object sender, EventArgs e)
    {
      InitialDialogCheque(cls_Struct.ActionMode.Add);
    }

    private void btT2Edit_Click(object sender, EventArgs e)
    {
      InitialDialogCheque(cls_Struct.ActionMode.Edit);
    }

    private void btT2Delete_Click(object sender, EventArgs e)
    {
      InitialDialogCheque(cls_Struct.ActionMode.Delete);
    }

    private void btT3Add_Click(object sender, EventArgs e)
    {
      InitialDialogBank(cls_Struct.ActionMode.Add);
    }

    private void btT3Edit_Click(object sender, EventArgs e)
    {
      InitialDialogBank(cls_Struct.ActionMode.Edit);
    }

    private void btT3Delete_Click(object sender, EventArgs e)
    {
      InitialDialogBank(cls_Struct.ActionMode.Delete);
    }

    private void btT5Add_Click(object sender, EventArgs e)
    {
      InitialDialogItemType(cls_Struct.ActionMode.Add);
    }

    private void btT5Edit_Click(object sender, EventArgs e)
    {
      InitialDialogItemType(cls_Struct.ActionMode.Edit);
    }

    private void btT5Delete_Click(object sender, EventArgs e)
    {
      InitialDialogItemType(cls_Struct.ActionMode.Delete);
    }

    //private void btT6Add_Click(object sender, EventArgs e)
    //{
    //  InitialDialogAddress(cls_Struct.ActionMode.Add);
    //}

    //private void btT6Edit_Click(object sender, EventArgs e)
    //{
    //  InitialDialogAddress(cls_Struct.ActionMode.Edit);
    //}

    //private void btT6Delete_Click(object sender, EventArgs e)
    //{
    //  InitialDialogAddress(cls_Struct.ActionMode.Delete);
    //}

    private void frm_Vendors_Record_KeyDown(object sender, KeyEventArgs e)
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
        if (XtraMessageBox.Show("ต้องการบันทึกรหัสพ่อค้า : " + txtCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
        if (SaveData())
        {
          XtraMessageBox.Show("บันทึกรหัสพ่อค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
          IsSaveOK = true;
          if (((SimpleButton)sender).Tag == "1")
          {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
          }
        }
        else
        {
          IsSaveOK = false;
          XtraMessageBox.Show("บันทึกรหัสพ่อค้าไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private void txtMapPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
      string strBasePath = Application.StartupPath + "\\Photos";
      string Xs = "";
      byte[] Data;

      try
      {
        // >> Check if Folder Exists 
        if (!Directory.Exists(strBasePath))
        {
          Directory.CreateDirectory(strBasePath);
        }

        OpenFileDialog OPdg = new OpenFileDialog();
        Xs = "Picture Files (*.bmp;*.gif;*.jpg)|*.bmp;*.gif;*.jpg";
        OPdg.InitialDirectory = Xs;
        OPdg.Filter = Xs;
        OPdg.FilterIndex = 0;
        OPdg.Multiselect = true;
        if (OPdg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        Cursor = Cursors.WaitCursor;
        string StrName = OPdg.FileName;

        txtMapPath.Text = OPdg.FileName;

        Class_ImageResize img = new Class_ImageResize();
        Data = img.ResizeImage(StrName);
        MemoryStream MemoryStreamData = new MemoryStream(Data);
        Image image = System.Drawing.Image.FromStream(MemoryStreamData);
        string filename = Path.GetFileName(StrName).ToString();
        txtfilename.Text = filename;
        // >> Save Picture 
        image.Save(strBasePath + "\\" + filename);
        picDisplay.Image = image;
        Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("txtMapPath_ButtonClick : " + ex.Message);
      }
    }

  }
}
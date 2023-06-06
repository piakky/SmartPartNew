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
  public partial class frm_Personals_List : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
      private DataSet dsProduct = new DataSet();

    #endregion

    #region function

    public void DeleteData()
    {
      if (dsProduct.Tables["M_PERSONALS"].Rows.Count == 0)
      {
        return;
      }
      DataRow Drow = gvEmployee.GetFocusedDataRow();
      int Id = cls_Library.DBInt(Drow["PERSONAL_ID"]);
      string CGcode = System.Convert.ToString(Drow["PERSONAL_CODE"]);
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรหัสผู้ติดต่อ : " + CGcode + " ใช่หรือไม่?", "ลบข้อมูล", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        bool OK = cls_Data.DeletePersonal(Id);

        try
        {
          if (OK)
          {
            MessageBox.Show("ลบรหัสผู้ติดต่อ :  " + CGcode + " เรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!bwCode.IsBusy)
            {
              bwCode.RunWorkerAsync();
            }
            else
            {
              XtraMessageBox.Show("System is running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }
        }
        catch (Exception ex)
        {
          XtraMessageBox.Show(ex.Message);
        }
      }
    }

    private void LoadData()
    {
      dsProduct = cls_Data.GetListPersonals();
    }

    public void InitialDialogForm(cls_Struct.ActionMode mode)
    {
      frm_Personals_Record frmInput;
      DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      string strMode = String.Empty;

      frmInput = new frm_Personals_Record(mode);
      frmInput.StartPosition = FormStartPosition.CenterParent;

      switch (mode)
      {
        case cls_Struct.ActionMode.Add:
          strMode = " [เพิ่ม]";
          break;
        case cls_Struct.ActionMode.Edit:
          strMode = " [แก้ไข]";
          break;
        case cls_Struct.ActionMode.Copy:
          strMode = " [คัดลอก]";
          break;
      }

      try
      {
        DataTable dtGroup = new DataTable();
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvEmployee;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != cls_Struct.ActionMode.Add)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "บุคคลทั่วไป" + strMode;
        #region "XXX"
        if (dr != null)
        {
          if ((mode == cls_Struct.ActionMode.Edit) || (mode == cls_Struct.ActionMode.Copy))
          {
            if (mode == cls_Struct.ActionMode.Edit)
            {
              frmInput.Prop_Codeid = cls_Library.DBInt(dr["PERSONAL_ID"]);          
            }
            else
            {
              frmInput.Prop_Codeid = 0;
            }
            frmInput.Prop_RowData = dr;
            frmInput.TxtPersonalCode.Text = cls_Library.DBString(dr["PERSONAL_CODE"]);
            frmInput.TxtPersonalName.Text = cls_Library.DBString(dr["PERSONAL_NAME"]);
            frmInput.TxtEPersonalDesc1.Text = cls_Library.DBString(dr["PERSONAL_DESCRIPTION1"]);
            frmInput.TxtEPersonalDesc2.Text = cls_Library.DBString(dr["PERSONAL_DESCRIPTION2"]);
            frmInput.TxtEPersonalDesc3.Text = cls_Library.DBString(dr["PERSONAL_DESCRIPTION3"]);
            frmInput.TxtEPersonalNote.Text = cls_Library.DBString(dr["PERSONAL_NOTE"]);
            frmInput.TxtEPersonalEmail.Text = cls_Library.DBString(dr["PERSONAL_EMAIL"]);
            if ((cls_Library.DBDateTime(dr["PERSONAL_FIRSTDATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(dr["PERSONAL_FIRSTDATE"]) == DateTime.MaxValue))
            {
              frmInput.dateFirstDate.Text = "";
            }
            else
            {
              frmInput.dateFirstDate.DateTime = cls_Library.DBDateTime(dr["PERSONAL_FIRSTDATE"]);
            }
            if ((cls_Library.DBDateTime(dr["PERSONAL_LASTDATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(dr["PERSONAL_LASTDATE"]) == DateTime.MaxValue))
            {
              frmInput.dateLastDate.Text = "";
            }
            else
            {
              frmInput.dateLastDate.DateTime = cls_Library.DBDateTime(dr["PERSONAL_LASTDATE"]);
            }
            frmInput.TxtEPersonalAddress1.Text = cls_Library.DBString(dr["PERSONAL_ADDRESS1"]);
            frmInput.TxtEPersonalAddress2.Text = cls_Library.DBString(dr["PERSONAL_ADDRESS2"]);
            frmInput.TxtEPersonalAddress3.Text = cls_Library.DBString(dr["PERSONAL_ADDRESS3"]);
            frmInput.TxtEPersonalAddress4.Text = cls_Library.DBString(dr["PERSONAL_ADDRESS4"]);
            frmInput.TxtEPersonalPlace.Text = cls_Library.DBString(dr["PERSONAL_PLACE"]);
            frmInput.TxtEPersonalTax.Text = cls_Library.DBString(dr["PERSONAL_TAX"]);
          }
          else
          {
            DataTable dt = (DataTable)gridEmployee.DataSource;
            frmInput.Prop_RowData = dt.NewRow();
          }
        }
        else
        {
          DataTable dt = (DataTable)gridEmployee.DataSource;
          frmInput.Prop_RowData = dt.NewRow();
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        dsProduct.Tables["M_PERSONALS"].BeginInit();

        if (mode == cls_Struct.ActionMode.Add)
        {
          if ((frmInput.getLastdata != null) && (frmInput.getLastdata.Tables["M_PERSONALS"].Rows.Count == 1))
          {
            dsProduct.Tables["M_PERSONALS"].ImportRow(frmInput.getLastdata.Tables["M_PERSONALS"].Rows[0]);
          }
        }
        dsProduct.Tables["M_PERSONALS"].EndInit();
        gridEmployee.DataSource = dsProduct.Tables["M_PERSONALS"];
        gridEmployee.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
    }
    #endregion

    public frm_Personals_List()
    {
        InitializeComponent();
        if (!bwCode.IsBusy)
        {
            bwCode.RunWorkerAsync();
        }
    }

    private void bwCode_DoWork(object sender, DoWorkEventArgs e)
    {
        LoadData();
    }

    private void bwCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      gridEmployee.DataSource = dsProduct.Tables["M_PERSONALS"];
      gridEmployee.RefreshDataSource();
    }

    private void frm_Product_List_FormClosing(object sender, FormClosingEventArgs e)
    {
      Class_Library mc = new Class_Library();
      Class_Library.m_ClearInstance ClearInstance = new Class_Library.m_ClearInstance(mc.ClearInstance);
      ClearInstance(System.Convert.ToInt32(this.AccessibleDescription), ref cls_Form.GB_Instance);
    }

    private void gvPDT_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }
  }
}
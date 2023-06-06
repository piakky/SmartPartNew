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
  public partial class frmD_Tracks_Input : DevExpress.XtraEditors.XtraForm
  {
    #region Variable

    #endregion

    public frmD_Tracks_Input()
    {
      InitializeComponent();
      this.KeyPreview = true;
    }

    private void frmD_Tracks_Input_KeyDown(object sender, KeyEventArgs e)
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

    private void btSave_Click(object sender, EventArgs e)
    {
      bool err = false;

      if ((dateTrack.EditValue == null) || (dateTrack.Text == ""))
      {
        XtraMessageBox.Show("กรุณาระบุวันที่", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        dateTrack.ErrorText = "กรุณาระบุวันที่";
        dateTrack.Focus();
        err = true;
      }
      if (!err)
      {
        if ((sluUser.EditValue == null) || (sluUser.Text == "เลือกรหัสผู้ติดตาม"))
        {
          XtraMessageBox.Show("กรุณาระบุผู้ติดตาม", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          sluUser.ErrorText = "กรุณาระบุผู้ติดตาม";
          sluUser.Focus();
          err = true;
        }
      }
      if (err) return;

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void btReset_Click(object sender, EventArgs e)
    {
      dateTrack.EditValue = DateTime.Now;
      sluUser.EditValue = null;
      txtName.Text= "";
      txtNote.Text = "";      
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void sluUser_EditValueChanged(object sender, EventArgs e)
    {
      DataRow[] dr = cls_Global_DB.DataInitial.Tables["M_USERS"].Select("_id = " + sluUser.EditValue);
      if (dr.Length == 0)
        return;
      txtName.Text = dr[0]["name"].ToString();  
    }

    private void frmD_Tracks_Input_Load(object sender, EventArgs e)
    {
      dateTrack.Focus();
    }
  }
}
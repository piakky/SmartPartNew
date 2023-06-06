using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using SmartPart.Class;

namespace SmartPart.Forms.Code
{
  public partial class frmD_Contract_Input : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    int Datatype = 0;

    #endregion
    public frmD_Contract_Input(int _type)
    {
      // _type 1: customer
      // _type 2: Vendor
      InitializeComponent();
      this.KeyPreview = true;
      Datatype = _type;
    }

    private void btSave_Click(object sender, EventArgs e)
    {
      bool err = false;
      if (txtName.EditValue == null || txtName.Text == "")
      {
        XtraMessageBox.Show("กรุณาระบุชื่อผู้ติดต่อ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtName.ErrorText = "กรุณาระบุชื่อผู้ติดต่อ";
        txtName.Focus();
        err = true;
      }
      if (!err)
      {
        if (txtDep.EditValue == null || txtDep.Text == "")
        {
          XtraMessageBox.Show("กรุณาระบุแผนก", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          txtDep.ErrorText = "กรุณาระบุแผนก";
          txtDep.Focus();
          err = true;
        }
      }
      if (err) return;
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void btReset_Click(object sender, EventArgs e)
    {
      txtName.Text = "";
      txtDep.Text = "";
      txtTel.Text = "";
      txtTelExt.Text = "";
      txtNote.Text = "";
      dateStart.EditValue = DateTime.Now;
      txtPic.Text = "";
      txtType.Text = "";
      picDisplay.Image = null;
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmD_Contract_Input_KeyDown(object sender, KeyEventArgs e)
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

    private void txtPic_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

        txtPic.Text = OPdg.FileName;

        Class_ImageResize img = new Class_ImageResize();
        Data = img.ResizeImage(StrName);
        MemoryStream MemoryStreamData = new MemoryStream(Data);
        Image image = System.Drawing.Image.FromStream(MemoryStreamData);
        string filename = Path.GetFileName(StrName).ToString();
        Txtfilename.Text = filename;
        // >> Save Picture 
        image.Save(strBasePath + "\\" + filename);
        picDisplay.Image = image;
        Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("txtPic_ButtonClick : " + ex.Message);
      }
    }
  }
}
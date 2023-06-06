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
  public partial class frmD_PicturesInput : DevExpress.XtraEditors.XtraForm
  {
    public frmD_PicturesInput()
    {
      InitializeComponent();
      this.KeyPreview = true;
    }
    private void btClose_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void BTaddImage_Click(object sender, EventArgs e)
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
        Txtpath.Text = OPdg.FileName;

        Class_ImageResize img = new Class_ImageResize();
        Data = img.ResizeImage(StrName);
        MemoryStream MemoryStreamData = new MemoryStream(Data);
        Image image = System.Drawing.Image.FromStream(MemoryStreamData);
        string filename = Path.GetFileName(StrName).ToString();
        Txtfilename.Text = filename;
        // >> Save Picture 
        image.Save(strBasePath + "\\" + filename);
        Txtpath.Text = strBasePath + "\\" + filename;
        TxtfilePath.Text = strBasePath + "\\" + filename;
        pictureDisplay.Image = image;
        Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        Application.DoEvents();
      }
    }

    private void frmD_PicturesInput_KeyDown(object sender, KeyEventArgs e)
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
    private void btReset_Click(object sender, EventArgs e)
    {
      Txtpath.Text = "";
      Txtfilename.Text = "";
      pictureDisplay.Image = null;
    }

    private void btSave_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }
  }
}
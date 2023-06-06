using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace SmartPart.Class
{
  public partial class con_PicCode : UserControl
  {
#region " Variables declaration "
  private  BackgroundWorker BKWloadImage; 
  DataTable _TBfilename  = new DataTable("filename");
  DataTable _TBimage  = new DataTable("image");
  
  string _Code = "";
  int _CodeType  = 0;
  int[] _PICdeleteID = new int[] {};
#endregion

  public con_PicCode()
    {
      InitializeComponent();
      AddColumnsForFilename();
      LoadImage();
    }

  private void AddColumnsForFilename()
    {
      if (_TBfilename.Columns.Count <= 0 )
      {
        _TBfilename.Columns.Add("filename", typeof(string));
        _TBfilename.PrimaryKey = new DataColumn[] {_TBfilename.Columns["filename"]};
      }
    }

  private void LoadImage()
    {
      BKWloadImage = new BackgroundWorker();
      BKWloadImage.WorkerReportsProgress = true;
      BKWloadImage.WorkerSupportsCancellation = true;
      BKWloadImage.DoWork +=new DoWorkEventHandler(BKWloadImage_DoWork);
      BKWloadImage.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BKWloadImage_RunWorkerCompleted);
      BKWloadImage.RunWorkerAsync();
    }

  void BKWloadImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      refreshData();
    }

  void BKWloadImage_DoWork(object sender, DoWorkEventArgs e)
    {
      _TBimage = GetCodeImage(Code, CodeType);
    }


  public DataTable GetCodeImage(string code, int type)
  {
    //if (code.Length <= 0 || type < 0) return null;
    SqlConnection cn = new SqlConnection();
    SqlDataAdapter _dataAdapter = new SqlDataAdapter();
    DataTable table = new DataTable("image");
    string Sql = "";

    cls_Global_DB.ConnectDatabase(ref cn);

    try
    {
      Sql = "SELECT PICid,PICcode,PICture FROM PIC WHERE PICcode='" + code + "' AND PICtype=" + type;
      _dataAdapter.SelectCommand = new SqlCommand(Sql, cn);
      _dataAdapter.SelectCommand.Parameters.Clear();
      _dataAdapter.Fill(table);
    }
    catch
    { table = null; }
    finally
    {
      cls_Global_DB.CloseDB(ref cn);
      cn.Dispose();
    }
    return table;
  }

  public void refreshData()
    {
    _TBimage.Columns.Add("filename", typeof(string));
    gridControl1.DataSource = _TBimage;
    gridControl1.RefreshDataSource();
    }

#region "Property"
  public DataTable TBfilename
    {
      get{return _TBfilename;}
      set{_TBfilename = value;}
    }

  public DataTable TBimage
  {
    get{return _TBimage;}
    set{_TBimage = value;}
  }

  public string Code 
  {
    get{return _Code;}
    set{_Code = value;}
  }

  public int[] PICdeleteID
  {
    get{return _PICdeleteID;}
  }

  public int CodeType
  {
    get { return _CodeType; }
    set { _CodeType = value; }
  }
#endregion

  private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
  {
    if (layoutView1.RowCount <= 0) return;
    string Xs  = "";
    int id  = 0;
    Cursor = Cursors.WaitCursor;
    try
    {
      id =System.Convert.ToInt32(layoutView1.GetFocusedRowCellValue("PICid"));
      Array.Resize(ref _PICdeleteID, PICdeleteID.Length);
      PICdeleteID[PICdeleteID.Length - 1] = id;
    }
    catch (Exception ex)
    {
      id = 0;
    }

    if (id == 0)
    {
      try
      {
        Xs = System.Convert.ToString(layoutView1.GetFocusedRowCellValue("filename"));
      }
      catch (Exception ex)
      {
        Xs = "";
      }
      if (Xs.Length > 0) _TBfilename.Rows.Remove(_TBfilename.Rows.Find(Xs));
    }
    layoutView1.DeleteSelectedRows();
    Cursor = Cursors.Default;
  }

  private void bbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
  {
    string strBasePath = Application.StartupPath + "\\Photos";
    string Xs  = "";
    byte[] Data ;

    try
    {
      // >> Check if Folder Exists 
      if (!Directory.Exists(strBasePath))
      {
        Directory.CreateDirectory(strBasePath);
      }

      OpenFileDialog OPdg  = new OpenFileDialog();
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
      foreach (string StrName in OPdg.FileNames)
      {
        DataRow row   = _TBfilename.NewRow();
        row["filename"] = StrName;
        _TBfilename.Rows.Add(row);

        Class_ImageResize img = new Class_ImageResize();
        Data = img.ResizeImage(StrName);
        MemoryStream MemoryStreamData  = new MemoryStream(Data);
        Image image = System.Drawing.Image.FromStream(MemoryStreamData);
        string filename = Path.GetFileName(StrName).ToString();
        // >> Save Picture 
        image.Save(strBasePath + "\\" + filename);
        DataRow r  = _TBimage.NewRow();
        r["PICcode"] = Code;
        r["PICture"] = Data;
        r["filename"] = StrName;
        _TBimage.Rows.Add(r);
      }
      gridControl1.DataSource = _TBimage;
      gridControl1.RefreshDataSource();
      Cursor = Cursors.Default;
    }
    catch (Exception ex)
    {
      Application.DoEvents();
    }
  }
  }
}

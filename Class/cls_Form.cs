using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace SmartPart.Class
{
  class cls_Form
  {
    public static Class_Library.InstanceObject[] GB_Instance = new Class_Library.InstanceObject[50];
    public static DevExpress.XtraTabbedMdi.XtraTabbedMdiManager gb_MdiManager = new XtraTabbedMdiManager();

    public static void FocusForm(XtraTabbedMdiManager Xtab, string Fname)
    {
      gb_MdiManager = Xtab;
      for (int i = 0; i < Xtab.Pages.Count; i++)
      {
        if (Xtab.Pages[i].Text.ToString() == Fname.ToString())
        {
          Xtab.Pages[i].MdiChild.Focus();
          break;
        }
      }
    }

    public static int CheckForm(XtraTabbedMdiManager Xtab, string Fname)
    {
      int k = 0;
      gb_MdiManager = Xtab;
      for (int i = 0; i < Xtab.Pages.Count; i++)
      {
        if (Xtab.Pages[i].Text.ToString() == Fname.ToString())
        {
          k += 1;
          return k;
        }
      }
      return k;
    }

    public static string Get_CaptionForm(int Type)
    {
      string Cap = "";

      switch (Type)
      {
        case 201:
          Cap = "Installation";
          break;
        case 202:
          Cap = "Validation";
          break;
        case 203:
          Cap = "PQ";
          break;
        case 204:
          Cap = "Services";
          break;
        case 205:
          Cap = "ASC";
          break;
        case 206:
          Cap = "Visit";
          break;
        case 207:
          Cap = "Problem";
          break;
        case 301:
          Cap = "รับเข้า";
          break;
        case 302:
          Cap = "เบิกออก";
          break;
        case 303:
          Cap = "Change Parts";
          break;
        case 401:
          Cap = "Quotation [ASC]";
          break;
        case 402:
          Cap = "Quotation [Validation]";
          break;
        case 403:
        case 509:
          Cap = "ใบแจ้งเตือนเพื่อสอบเทียบ";
          break;
        case 404:
          Cap = "Quotation [Spare Part]";
          break;
      }
      return Cap;
    }

    public static string Get_CaptionDate(int Type)
    {
      string Cap = "";

      switch (Type)
      {
        case 201:
          Cap = "Installation date";
          break;
        case 202:
        case 403:
          Cap = "Validation date";
          break;
        case 203:
        case 204:
        case 205:
          Cap = "Service date";
          break;
        case 206:
          Cap = "Visit date";
          break;
      }
      return Cap;
    }

    public static GridColumn AddGridColumn(string Name, string Caption, string FieldName, bool Visible, int VisibleIndex, int Width)
    {
      GridColumn GridCol = new GridColumn();
      GridCol.Name = Name;
      GridCol.Caption = Caption;
      GridCol.FieldName = FieldName;
      GridCol.Visible = Visible;
      GridCol.VisibleIndex = VisibleIndex;
      GridCol.Width = Width;
      return GridCol;
    }

    public static void GridViewCustomDrawRowIndicator(Object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      int i;
      if (e.Info.IsRowIndicator)
      {
        e.Info.HeaderPosition = DevExpress.Utils.Drawing.HeaderPositionKind.Center;
        e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
        i = int.Parse(e.Info.DisplayText);
        if (i <= 0)
        {
          e.Info.DisplayText = "";
        }
      }
    }

    public static void CloseFormAll(XtraTabbedMdiManager Xtab)
    {
      while (Xtab.Pages.Count > 0)
      {
        Xtab.SelectedPage.MdiChild.Close();
      }
    }

    public static string ShowopenDialogFile(string Title, string Filter)
    {
      OpenFileDialog Dlg = new OpenFileDialog();
      Dlg.Title = "XML";
      Dlg.Filter = "XML Files|*.xml";
      Dlg.Multiselect = false;
      if (Dlg.ShowDialog() == DialogResult.OK)
      {
        return Dlg.FileName;
      }
      return "";
    }

    public static string ShowsaveDialogFile(string Title, string Filter, string Filename)
    {
      SaveFileDialog Dlg = new SaveFileDialog();
      string Name = Filename;
      Dlg.Title = "Export To " + " " + Title;
      Dlg.FileName = Name;
      Dlg.Filter = Filter;
      if (Dlg.ShowDialog() == DialogResult.OK) return Dlg.FileName;
      return "";
    }

    public static void OpenFile(string fileName)
    {
      if (XtraMessageBox.Show("คุณต้องการเปิดไฟล์", "สอบถาม", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        try
        {
          System.Diagnostics.Process process = new System.Diagnostics.Process();
          process.StartInfo.FileName = fileName;
          process.StartInfo.Verb = "Open";
          process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
          process.Start();
        }
        catch
        {
          XtraMessageBox.Show("ไม่สามารถเปิดไฟล์ได้", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }
  }
}

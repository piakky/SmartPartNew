using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using RTLComponents;
using System.Data;
using DevExpress.XtraGrid.Columns;
using System.Collections.Generic;
using LiramUtilsLib;
using System.Windows.Forms;
using DevExpress.XtraGrid;

namespace RamPlusSQL
{
    public partial class repViewDynamic : DevExpress.XtraReports.UI.XtraReport
    {
        private int sumWidth = 0;
        private bool IsFirstRow = true;
        List<string> colFields = null;
        List<int> colWidth = null;

        public repViewDynamic()
        {
            InitializeComponent();
        }

        public void InitTitle(string title, string OrgName, string TaxYear, string OrgId)
        {
            lblTitle.Text = title;
            lblTaxYear.Text = TaxYear;
            lblCompanyName.Text = OrgName;
            lblCompanyID.Text = OrgId;
        }

        public void InitTitleExtraTitle(string extraTitle)
        {
            lblExtraTitle.Visible = true;
            lblExtraTitle.Text = extraTitle;
        }

        public void InitReport(GridView view, ProgressBar pb)
        {
            colFields = new List<string>();
            colWidth = new List<int>();
            int index = 0;

            GridColumnReadOnlyCollection columns = view.VisibleColumns;
            int count = columns.Count;
            int viewWidth = 0;
            int XRWidth = (int)XRtblRoot2.WidthF;

            #region set report size
            //set size for details
            Detail.HeightF += (float)0.5 * view.DataRowCount;
            XRtblRoot2.HeightF += (float)0.5 * view.DataRowCount;
            #endregion

            #region Collection all Column
            for (int i = count; i > 0; i--)
            {
                viewWidth += columns[i - 1].VisibleWidth;

                //add fields that we use to the list
                colFields.Add(columns[i - 1].FieldName);
            }
            #endregion

            #region Import Columns
            //import columns
            for (int i = count; i > 0; i--)
            {
                // create title
                XRTableCell lblTitle = new XRTableCell();
                lblTitle.Text = columns[i - 1].Caption;
                lblTitle.BorderWidth = 1;
                lblTitle.Borders = DevExpress.XtraPrinting.BorderSide.All;
                lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
                lblTitle.Font = new Font(this.Font, FontStyle.Bold);

                //import sigle column to column row
                XRtblRow1.InsertCell(lblTitle, index);

                //culculate width for column
                int colPercent = columns[i - 1].VisibleWidth * 100 / viewWidth;
                colWidth.Add(colPercent * XRWidth / 100);


                XRtblRow1.Cells[index].WidthF = colWidth[index];
                index++;

            }
            XRtblRow1.Cells.RemoveAt(XRtblRow1.Cells.Count - 1);
            #endregion

            #region Import Data

            //check if this is a grid with group and handle different
            if (view.GroupCount > 0)
            {
                InitReportWithGroup(view, pb,XRWidth);
                return;
            }

            count = view.DataRowCount;
            if (pb != null)
            {
                pb.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
                pb.Value = 0;
                pb.Maximum = count;
                pb.Visible = true;
            }

            for (int i = 0; i < count; i++)
            {
                index = 0;
                DataRow dr = view.GetDataRow(i);
                XRTableRow XRTblRow = new XRTableRow();
                XRTblRow.WidthF = XRWidth;
                if (dr != null)
                {
                    foreach (string str in colFields)
                    {
                        //Preparing Option For Boolean Fields
                        XRCheckBox cb = null;

                        // create field
                        XRTableCell lblField = new XRTableCell();
                        lblField.HeightF = 15;

                        //lblField.Multiline = true;
                        lblField.BorderWidth = 1;
                        lblField.Borders = DevExpress.XtraPrinting.BorderSide.All;
                        string editorName = "";

                        if (view.Columns[str].ColumnEdit != null)
                            editorName = view.Columns[str].ColumnEdit.Name;

                        if ((view.Columns[str].ColumnType.Name == "Boolean" && editorName != "" && view.GridControl.RepositoryItems[editorName].EditorTypeName == "CheckEdit")
                            || (view.Columns[str].ColumnType.Name == "Boolean" && editorName == ""))
                        {
                            lblField.Text = "";
                            cb = new XRCheckBox();

                            switch (view.GetRowCellDisplayText(i, str).ToString())
                            {
                                case "Checked":
                                    cb.CheckState = CheckState.Checked;
                                 break;

                                case "Unchecked":
                                 cb.CheckState = CheckState.Unchecked ;
                                 break;

                                case "Indeterminate":
                                 cb.CheckState = CheckState.Indeterminate;
                               break;

                            }
                        }
                        else
                        {
                            lblField.Text = view.GetRowCellDisplayText(i, str);
                        }

                        if (cb != null)
                        {
                            lblField.Controls.Add(cb);
                            lblField.Controls[lblField.Controls.Count - 1].Borders = DevExpress.XtraPrinting.BorderSide.None;

                        }

                        XRTblRow.Cells.Add(lblField);

                        //set width for controls
                        XRTblRow.Cells[index].WidthF = colWidth[index];
                        if (cb != null)
                        {
                            XRTblRow.Cells[index].Controls[lblField.Controls.Count - 1].LeftF = colWidth[index] / 2;
                        }

                        index++;
                    }
                }

                XRtblRoot2.Rows.AddRange(new XRTableRow[] { XRTblRow });
                if (pb != null)
                    pb.Value++;
            }

            //remove first row that handle for as the control
            XRtblRoot2.Rows.RemoveAt(0);

            #endregion

            #region Import Summery Line
            count = columns.Count;
            index = 0;
            for (int i = count; i > 0; i--)
            {
                // create summery
                XRTableCell lblSummery = new XRTableCell();
                if (columns[i - 1].SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                    lblSummery.Text = columns[i - 1].SummaryText;
                else
                    lblSummery.Text = "";
                lblSummery.BorderWidth = 2;
                lblSummery.Borders = DevExpress.XtraPrinting.BorderSide.All;
                lblSummery.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
                //import sigle summery to summery row
                XRtblRow3.InsertCell(lblSummery, index);
                XRtblRow3.Cells[index].WidthF = colWidth[index];
                index++;
            }

            XRtblRow3.Cells.RemoveAt(XRtblRow3.Cells.Count - 1);
            #endregion

            if (pb != null)
                pb.Visible = false;

        }

        private void InitReportWithGroup(GridView view, ProgressBar pb, int XRWidth)
        {
            int index;
            GridColumnReadOnlyCollection columns = view.VisibleColumns;
            int count = columns.Count;

            if (pb != null)
            {
                pb.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
                pb.Value = 0;
                pb.Maximum = view.DataRowCount;
                pb.Visible = true;
            }

            for (int i = -1; view.IsValidRowHandle(i); i--)
            {
                #region Add Group Tilte

                XRTableRow XRGroupRow = new XRTableRow();
                XRGroupRow.WidthF = XRWidth;

                XRTableCell lblGroupName = new XRTableCell();
                lblGroupName.HeightF = 15;
                lblGroupName.Font = new Font(lblGroupName.Font, FontStyle.Bold);
                lblGroupName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                lblGroupName.BorderWidth = 1;
                lblGroupName.Borders = DevExpress.XtraPrinting.BorderSide.All;
                lblGroupName.Text = view.GetGroupRowPrintValue(i).ToString();
                XRGroupRow.Cells.Add(lblGroupName);
                XRtblRoot2.Rows.AddRange(new XRTableRow[] { XRGroupRow });

                #endregion

                #region Import Rows

                if (view.GetChildRowHandle(i, 0) > -1) // a data row
                {
                    for (int j = 0; j < view.GetChildRowCount(i); j++)
                    {
                        index = 0;
                        int iRow = view.GetChildRowHandle(i, j);
                        DataRow dr = view.GetDataRow(iRow);

                        XRTableRow XRTblRow = new XRTableRow();
                        XRTblRow.WidthF = XRWidth;
                        if (dr != null)
                        {
                            foreach (string str in colFields)
                            {
                                //Preparing Option For Boolean Fields
                                XRCheckBox cb = null;

                                // create field
                                XRTableCell lblField = new XRTableCell();
                                lblField.HeightF = 15;

                                //lblField.Multiline = true;
                                lblField.BorderWidth = 1;
                                lblField.Borders = DevExpress.XtraPrinting.BorderSide.All;
                                string editorName = "";

                                if (view.Columns[str].ColumnEdit != null)
                                    editorName = view.Columns[str].ColumnEdit.Name;

                                if ((view.Columns[str].ColumnType.Name == "Boolean" && editorName != "" && view.GridControl.RepositoryItems[editorName].EditorTypeName == "CheckEdit")
                                    || (view.Columns[str].ColumnType.Name == "Boolean" && editorName == ""))
                                {
                                    lblField.Text = "";
                                    cb = new XRCheckBox();

                                    switch (view.GetRowCellDisplayText(iRow, str).ToString())
                                    {
                                        case "Checked":
                                            cb.CheckState = CheckState.Checked;
                                            break;

                                        case "Unchecked":
                                            cb.CheckState = CheckState.Unchecked;
                                            break;

                                        case "Indeterminate":
                                            cb.CheckState = CheckState.Indeterminate;
                                            break;

                                    }
                                }
                                else
                                {
                                    lblField.Text = view.GetRowCellDisplayText(iRow, str);
                                }

                                if (cb != null)
                                {
                                    lblField.Controls.Add(cb);
                                    lblField.Controls[lblField.Controls.Count - 1].Borders = DevExpress.XtraPrinting.BorderSide.None;

                                }

                                XRTblRow.Cells.Add(lblField);

                                //set width for controls
                                XRTblRow.Cells[index].WidthF = colWidth[index];
                                if (cb != null)
                                {
                                    XRTblRow.Cells[index].Controls[lblField.Controls.Count - 1].LeftF = colWidth[index] / 2;
                                }

                                index++;
                            }
                        }

                        XRtblRoot2.Rows.AddRange(new XRTableRow[] { XRTblRow });
                        if (pb != null)
                            pb.Value++;
                    }
                }
                #endregion

                #region Add Summery Group
                if (view.GroupSummary.Count > 0)
                {
                    XRTableRow XRTblRowSummery = new XRTableRow();

                    if (i != GridControl.InvalidRowHandle)
                    {
                        count = columns.Count;
                        index = 0;
                        for (int j = count; j > 0; j--)
                        {
                            XRTableCell lblGroupSummery = new XRTableCell();
                            if (columns[j - 1].SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                            {
                                lblGroupSummery.Text = view.GetGroupSummaryDisplayText(i , (GridGroupSummaryItem)view.GroupSummary[columns[j - 1].FieldName]);
                            }
                            else
                            {
                                lblGroupSummery.Text = "";
                            }

                            lblGroupSummery.BorderWidth = 2;

                            lblGroupSummery.Borders = DevExpress.XtraPrinting.BorderSide.All;
                            lblGroupSummery.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
                            XRTblRowSummery.Cells.Add(lblGroupSummery);
                            //set width for controls
                            XRTblRowSummery.Cells[index].WidthF = colWidth[index];
                            index++;
                        }
                    }

                    XRtblRoot2.Rows.AddRange(new XRTableRow[] { XRTblRowSummery });
                }
                #endregion
            }

            //remove first row that handle for as the control
            XRtblRoot2.Rows.RemoveAt(0);

            #region Import Summery Line
            index = 0;
            for (int i = count; i > 0; i--)
            {
                // create summery
                XRTableCell lblSummery = new XRTableCell();
                if (columns[i - 1].SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                    lblSummery.Text = columns[i - 1].SummaryText;
                else
                    lblSummery.Text = "";
                lblSummery.BorderWidth = 2;
                
                lblSummery.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));

                lblSummery.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
                //import sigle summery to summery row
                XRtblRow3.InsertCell(lblSummery, index);
                XRtblRow3.Cells[index].WidthF = colWidth[index];
                index++;
            }

            XRtblRow3.Cells.RemoveAt(XRtblRow3.Cells.Count - 1);
            #endregion

            if (pb != null)
                pb.Visible = false;
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Data.OleDb;
using KRApp;
using KR.Business;
using KR.DataAccess;
using System.Collections.Generic;

namespace KRApplication
{
    public partial class FrmMain : Form
    {
        private SubForm subForm = null;
        public FrmMain()
        {
            InitializeComponent();
        }

        #region NgoanHH

        private void ToolKanjiOrVoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ToolKanjiOrVoc.SelectedIndex == 0)
            {
                ToolGroupExport.Items.Clear();
                ToolGroupExport.Items.Add("My List");
                ToolGroupExport.Items.Add("N5");
                ToolGroupExport.Items.Add("N4");
                ToolGroupExport.Items.Add("N3");
                ToolGroupExport.Items.Add("N2");
                ToolGroupExport.Items.Add("N1");
            }
            else
            {
                ToolGroupExport.Items.Clear();
                List<string> list = LesssonService.GetAllLessonName();
                for (int i = 0; i < list.Count; i++)
                {
                    ToolGroupExport.Items.Add(list[i]);
                }
            }
        }

        private void ToolGroupExport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ToolKanjiOrVoc.SelectedIndex == 0)
            {
                if (ToolGroupExport.SelectedIndex == 0)
                {
                    dgvExport.DataSource = KanjiDAO.GetKanjisByLike();
                }
                else
                {
                    string level = (string)ToolGroupExport.SelectedItem;
                    dgvExport.DataSource = KanjiDAO.GetKanjisByLevel(level);
                }
            }
            else
            {
                string lesson = (string)ToolGroupExport.SelectedItem;
                Lesson les = LesssonService.GetLessonByName(lesson);
                dgvExport.DataSource = VocabularyService.GetVocabularyByLessonID(les.ID);
            }
        }

        private void ToolExportOK_Click(object sender, EventArgs e)
        {
            fileDialogExport.InitialDirectory = "C:";
            fileDialogExport.Title = "Save as excel file";
            fileDialogExport.FileName = "SAD_";
            fileDialogExport.Filter = "Excel file 2003|*.xls|Excel file 2007|*.xlsx";

            if (fileDialogExport.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns.ColumnWidth = 20;

                // storing header part in Excel
                for (int i = 1; i < dgvExport.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dgvExport.Columns[i - 1].HeaderText;
                }

                // storing each row and column value to excel sheet
                for (int i = 0; i < dgvExport.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvExport.Columns.Count; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dgvExport.Rows[i].Cells[j].Value.ToString();
                    }
                }

                ExcelApp.ActiveWorkbook.SaveCopyAs(fileDialogExport.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                //ExcelApp.Quit;
            }
        }

        #endregion

        #region MinhTQ
        private void TabKaiwa_Enter(object sender, EventArgs e)
        {
            int lession = 3;
            String videoUrl = "D:\\Data\\Study\\FPT\\Semester 7 - Summer 2014 course\\Software Architecture & Design\\Assignment2\\SHINKISO-VCD\\Shin I - Lesson "+lession+".mpg";
            axWMP.URL = videoUrl;
            axWMP.Ctlcontrols.play();
            subForm = new SubForm();
        }

        private void ToolJPN_Click(object sender, EventArgs e)
        {
            subForm.Close();
            subForm = new SubForm(3,"j");
            subForm.Show();
        }

        private void ToolVN_Click(object sender, EventArgs e)
        {
            subForm.Close();
            subForm = new SubForm(3,"v");
            subForm.Show();
        }
        #endregion

    }
}

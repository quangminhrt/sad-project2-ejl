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
        public FrmMain()
        {
            InitializeComponent();
        }

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
            string groupExport = (string)ToolGroupExport.SelectedItem;
            if (ToolKanjiOrVoc.SelectedIndex == 0)
            {

            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

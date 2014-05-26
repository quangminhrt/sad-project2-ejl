using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KRApp
{
    public partial class SubForm : Form
    {
        private bool isJpn = true;
        private  int lession;
        public SubForm()
        {
        }
        public SubForm(int lession, String language)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = "D:\\Data\\Study\\FPT\\Semester 7 - Summer 2014 course\\Software Architecture & Design\\Assignment2\\Kaiwa pic\\1--25\\"+lession + language + ".jpg";
            this.lession = lession;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            String language;
            if (isJpn)
            {
                language = "v";
                isJpn = false;
            }
            else {
                language = "j";
                isJpn = true;
            }
            pictureBox1.ImageLocation = "D:\\Data\\Study\\FPT\\Semester 7 - Summer 2014 course\\Software Architecture & Design\\Assignment2\\Kaiwa pic\\1--25\\" + this.lession + language + ".jpg";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchItV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            MDIParent1 m = new MDIParent1();
            m.ShowDialog();
            this.Close();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

            this.Close();

        }
    }
}

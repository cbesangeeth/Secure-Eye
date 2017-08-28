using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchItV
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        static void Main()
        {
            Application.Run(new Login());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void kryptonGroupBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
           

            
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.timer1.Stop();
           t. btnReset.Enabled = true;
           t. btnStop.Enabled = false;
           this.Close();
        }

      
    
    }
}

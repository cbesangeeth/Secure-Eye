using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace CatchItV
{
    public partial class Timer : ComponentFactory.Krypton.Toolkit.KryptonForm
    {

        Boolean flag=true;
        int timeLeft ;
        public Timer()
        {
            InitializeComponent();
        }
        

        private void btnButton_Click(object sender, EventArgs e)
        {

            if (txtBox.Text != null)
            {
                int timeLeft = int.Parse(txtBox.Text);
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000;
                timer1.Start();
                lblCounter.Text = timeLeft.ToString();
                btnStop.Enabled = true;
                btnStart.Enabled = false;
                txtBox.Enabled = false;
                btnClose.Enabled = false;
            }
            else
                MessageBox.Show("Enter time in seconds");
           
        }
        

        private void kryptonPanel_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private int getTimerValue()
        {
            return int.Parse(txtBox.Text);

        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
         //   int timeLeft=0;
            if (flag)
            {
               timeLeft= getTimerValue();
                flag = false;
            }
            timeLeft--;
            if (timeLeft == 0)
            {
                MainForm m = new MainForm();
                m.ShowDialog();
                timer1.Stop();
                this.Close();
            }
                lblCounter.Text = timeLeft.ToString();
           
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
           /*
            Login login = new Login();
            login.ShowDialog();
            
            */

            timer1.Stop();
            btnReset.Enabled = true;
            btnStop.Enabled = false;

            

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timeLeft = 0;
            btnStop.Enabled = false;
            lblCounter.Text = null;
            txtBox.Text = null;
            btnStart.Enabled = true;
            flag = true;
            txtBox.Enabled = true;



        }
    }
}
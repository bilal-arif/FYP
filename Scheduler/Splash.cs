using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            pb.ForeColor = Color.Red;

            timeLeft = 20;
            timer1.Start();
        }

        public int timeLeft { get; set; }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            pb.Value = timeLeft;
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                lbl.Text = timeLeft.ToString();
            }
            else
            {
                timer1.Stop();
                frm_main_new main = new frm_main_new();
                main.Show();
                this.Hide();
            }
        }


    }
}

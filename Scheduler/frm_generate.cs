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
    public partial class frm_generate : Form
    {
        List<string> Exam_Sch;

        public frm_generate()
        {
            InitializeComponent();
        }

        public frm_generate(List<String> Temp)
        {
            Exam_Sch = new List<string>();
            Exam_Sch = Temp;
            InitializeComponent();
        }

        private void frm_generate_Load(object sender, EventArgs e)
        {

        }

        private void cmd_gennew_Click(object sender, EventArgs e)
        {
            frm_Schedule frm_sch = new frm_Schedule(Exam_Sch,false);
            frm_sch.Show();
        }

        private void cmd_useold_Click(object sender, EventArgs e)
        {
            frm_Schedule frm_sch = new frm_Schedule(true);
            frm_sch.Show();
        }




    }
}

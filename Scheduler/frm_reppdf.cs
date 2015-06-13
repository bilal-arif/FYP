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
    public partial class frm_reppdf : Form
    {
        public frm_reppdf()
        {
            InitializeComponent();
        }

        private void frm_reppdf_Load(object sender, EventArgs e)
        {

            
            Exam_Schedule2 rep = new Exam_Schedule2();
            rep.Database.Tables.Reset();

            ScheduleDSTableAdapters.Exam_ScheduleTableAdapter ta = new ScheduleDSTableAdapters.Exam_ScheduleTableAdapter();
            ScheduleDS.Exam_ScheduleDataTable table = ta.GetData();
           // ScheduleDSTableAdapters.DataTable1TableAdapter ta2 = new ScheduleDSTableAdapters.DataTable1TableAdapter();
            //ScheduleDS.DataTable1DataTable table2 = ta2.GetData();
            rep.SetDataSource(table.DefaultView);
            //rep.SetDataSource(table2.DefaultView);
            rep.Refresh();
            crystalReportViewer1.ReportSource = rep;
        }
    }
}

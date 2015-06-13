using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Scheduler
{
    public partial class frm_view : Form
    {
        String directory;
        public frm_view()
        {
            InitializeComponent();
        }

        public frm_view(String dir)
        {
            InitializeComponent();
            directory = dir;
            //MessageBox.Show(directory.ToString());

        }

        private void frm_view_Load(object sender, EventArgs e)
        {
            if (File.Exists(directory))
            {
                string[] data = File.ReadAllLines(directory);

                DataTable dt = new DataTable();

                string[] col = data[0].Split(',');

                foreach (string s in col)
                {
                    lstv.Columns.Add(s, 50);
                    //dt.Columns.Add(s, typeof(string));
                }

                for (int i = 1; i < data.Length; i++)
                {
                    var item = new ListViewItem();

                    //item.Text = reader["EXAM_DATE"].ToString();


                    //lst_schedule.Items.Add(item);

                    string[] row = data[i].Split(',');

                    for (int j = 1; j < row.Length; j++)
                    {
                        item.Text = row[0].ToString();
                        item.SubItems.Add(row[j].ToString());
                        //MessageBox.Show(row[j].ToString());

                    }
                    lstv.Items.Add(item);
                    
                    //lstv.Items.Add(row[i].ToString());
                    //dt.Rows.Add(row);
                }
                MessageBox.Show(data.Length.ToString());
                //lstv.Data
                //GridView1.DataSource = dt;
                //GridView1.DataBind()
            }
        }
    }
}

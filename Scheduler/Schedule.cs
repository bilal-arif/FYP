using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using btl.generic;

namespace Scheduler
{
    public partial class frm_Schedule : Form
    {   
        OleDbConnection con;
        String sql;
        String sql2;
        List<String> Courses;
        ArrayList timings;
        Random randomGen = new Random();
        object fitness;
        int index = 0;
        List<string> Exam_Sch;
        Boolean Exist;

        public frm_Schedule()
        {   
            InitializeComponent();
        }
        public frm_Schedule(ArrayList temp)
        {
            timings = new ArrayList();
            timings = temp;
            InitializeComponent();
        }

        public frm_Schedule(List<string> temp, Boolean existing)
        {
            Exist = existing;
            Exam_Sch = new List<string>();
            Exam_Sch = temp;
            InitializeComponent();
        }

        public frm_Schedule(List<string> temp)
        {
           
            Exam_Sch = new List<string>();
            Exam_Sch = temp;
            InitializeComponent();
        }

        public frm_Schedule(Boolean existing)
        {
            Exist = existing;
            InitializeComponent();
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=OraOLEDB.Oracle;Password=bilal;User ID=system;Data Source=xe;Persist Security Info=True");
            con.Open();
            
            /*if (Exist == false)
            {
                sql = "delete from ADMIN.exam_schedule";
                OleDbCommand Cmd = new OleDbCommand(sql, con);
                Cmd.ExecuteNonQuery();

                //schedule();

                populate(Exam_Sch);
            }
            */
            populate(Exam_Sch);
            sql = "select ES.Timings, ES.EXAM_Date ,ES.Room,S.ID,S.Course_Code,S.Teacher,C.Course_Name from ADMIN.Section S, ADMIN.Course C, ADMIN.Exam_Schedule ES where S.Course_code = C.Course_Code AND ES.Course = S.ID";

            OleDbCommand command = new OleDbCommand(sql, con);

            OleDbDataReader reader = command.ExecuteReader();

            try
            {

                while (reader.Read())
                {
                    var item = new ListViewItem();

                    item.Text = reader["EXAM_DATE"].ToString();
                    item.SubItems.Add(reader["TIMINGS"].ToString());
                    item.SubItems.Add(reader["Course_Name"].ToString());
                    item.SubItems.Add(reader["Course_Code"].ToString());
                    item.SubItems.Add(reader["Room"].ToString());
                    item.SubItems.Add(reader["ID"].ToString());
                    item.SubItems.Add(reader["Teacher"].ToString());

                    lst_schedule.Items.Add(item);

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            finally
            {
            }


        }


        private void cmd_edit_Click(object sender, EventArgs e)
        {
            //runner(Courses);
            MessageBox.Show("Im not yet implemented");
        }

        private void cmd_regen_Click(object sender, EventArgs e)
        {/*
            con = new OleDbConnection("Provider=OraOLEDB.Oracle;Password=bilal;User ID=system;Data Source=xe;Persist Security Info=True");
            con.Open();
            sql = "delete from exam_schedule";
            OleDbCommand Cmd = new OleDbCommand(sql, con);
            Cmd.ExecuteNonQuery();
            lst_schedule.Clear();
            schedule();
          */
            MessageBox.Show("Im not yet Implemented");
        }

        private void FitnessChk(ArrayList slots)
        {

            fitness = 0;
            for (int i = 0; i < slots.Count; i++)
            {
                string[] splited = slots[i].ToString().Split('\t');

                sql = "Select SUM(count (*)) from ADMIN.Enrollment E , ADMIN.Exam_Schedule S where E.Section_Code = S.Course AND S.Timings = '" + splited[1] + "' AND S.Exam_DATE = '" + splited[0] + "' group by E.erp_id having COUNT(E.erp_id)>1";

                using (var cmd = new OleDbCommand(sql, con))
                {
                    fitness = 0;
                    
                    fitness = cmd.ExecuteScalar();             
                }
                if (fitness.Equals("") == true)
                {
                    //MessageBox.Show("0");
                }
                else
                {
                   // MessageBox.Show(splited[0] +"\t"+ splited[1] + "\tfitness = " + fitness.ToString());
                }
            }
            lbl_fitness.Text = fitness.ToString();
            
            
        }



        private double FitnessChk(double[] pop)
        {
            con.Open();
            sql = "Select SUM(count (*)) from ADMIN.Enrollment E , ADMIN.Exam_Schedule S where E.Section_Code = S.Course AND S.Timings = '0930-1100' AND S.Exam_DATE = '07-12-2014' group by E.Section_Code having COUNT(E.Section_Code)>1";

            using (var cmd = new OleDbCommand(sql, con))
            {
                fitness = cmd.ExecuteScalar();
                //MessageBox.Show("fitness = "+ fitness.ToString(), "HELLO");
            }
            con.Close();
            return Convert.ToDouble(fitness);
        }

        private void runner(List<int> pop)
        {
            double[] values;
            int fit = 0;
            ArrayList population = new ArrayList();


                population.AddRange(Courses);
            
            GA ga = new GA(population);
            ga.FitnessFunction = new GAFunction(FitnessChk);
            //ga.Elitism = true;
            ga.Go();
            ga.GetBest(out values,out fit);
            for (int i = 0; i < values.Length; i++)
                lbl_status.Text = lbl_status.Text + " " + values[i];
        }

        private void populate(List <String> exams)
        {
            Random randomGen = new Random();
            int index=0;
            for (int i = 0; i < exams.Count; i++)
            {
                index = (int)randomGen.Next(1,23);

                String[] Split = exams[i].ToString().Split('\t');
               // MessageBox.Show(exams[i].ToString());

                //sql = "INSERT INTO EXAM_SCHEDULE VALUES (0,"+Split[2]+",'"+Split[0]+"','"+Split[1]+"',2)";
                //OleDbCommand command = new OleDbCommand(sql, con);
                //command.ExecuteNonQuery();

                try
                {
                    OleDbCommand Cmd = new OleDbCommand("ADMIN.add_exam", con);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.Add("PRETURN", OleDbType.VarChar, 30).Direction = ParameterDirection.ReturnValue;

                    Cmd.Parameters.Add("Vsection", OleDbType.VarChar, 30).Direction = ParameterDirection.Input;
                    Cmd.Parameters["Vsection"].Value = Split[2];

                    Cmd.Parameters.Add("Vtime", OleDbType.VarChar, 30).Direction = ParameterDirection.Input;
                    Cmd.Parameters["Vtime"].Value = Split[1];

                    Cmd.Parameters.Add("Vdate", OleDbType.VarChar, 30).Direction = ParameterDirection.Input;
                    Cmd.Parameters["Vdate"].Value = Split[0];

                    Cmd.Parameters.Add("Vroom", OleDbType.VarChar, 30).Direction = ParameterDirection.Input;
                    Cmd.Parameters["Vroom"].Value = Convert.ToInt32(index);

                    Cmd.ExecuteNonQuery();
                    String Str = Convert.ToString(Cmd.Parameters["PRETURN"].Value);
                }
                catch(Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }

                

                //MessageBox.Show(Str + "\t"+Split[0] + "\t"+Split[1]+"\t"+Split[2]);
               // MessageBox.Show(Str);

            }

        }

        private void schedule()
        {

            Int32 Strength = 0;
            Object result;
            //con = new OleDbConnection("Provider=OraOLEDB.Oracle;Password=bilal;User ID=system;Data Source=xe;Persist Security Info=True");

            //con.Open();
            // sql="Select SUM(count (*)) from Enrollment E , Exam_Schedule S where E.Section_Code = S.Course AND S.Timings = '0930-1100' AND S.Exam_DATE = '07-12-2014' group by E.Section_Code having COUNT(E.Section_Code)>1";

            int slots = timings.Count;

            using (var cmd = new OleDbCommand(sql, con))
            {
                //fitness = cmd.ExecuteScalar();
                //MessageBox.Show(fitness.ToString(),"HELLO");
            }
              
            sql = "Select SUM(Capacity) from ADMIN.Rooms";

            using (var cmd = new OleDbCommand(sql, con))
            {
                result = cmd.ExecuteScalar();


                //////////////
                //MessageBox.Show(result.ToString(),"Strength");
                ///////////////
            }
            Strength = Convert.ToInt32(result);
            


            sql = "Select Course_Code from ADMIN.Course";
            OleDbCommand command = new OleDbCommand(sql, con);

            OleDbDataReader reader = command.ExecuteReader();
            Courses = new List<String>();
            List<String> Exam_Sch = new List<string>();
            try
            {

                while (reader.Read())
                {

                    var item = new ListViewItem();
                    item.Text = reader["Course_Code"].ToString();
                    Courses.Add(item.Text.ToString());
                    //lst_schedule.Items.Add(item);
                }

                foreach (var item in Courses)
                {
                    sql = "SELECT Count(E.ERP_ID) " +
                        "FROM ADMIN.Enrollment E LEFT JOIN ADMIN.Section S ON S.ID = E.Section_Code " +
                        "Where S.Course_Code = '" + item.ToString() + "'" +
                        "GROUP BY S.Course_Code";

                    Int32 Strength_course = 0;
                    using (var cmd = new OleDbCommand(sql, con))
                    {
                        result = cmd.ExecuteScalar();
                        // MessageBox.Show(result.ToString(), "Course Strength");
                        Strength_course = Convert.ToInt32(result);

                        /*if (Strength >= Strength_course)
                        {
                            Strength -= Strength_course;
                            Exam_Sch.Add(item.ToString());
                        }
                        else
                        {

                        }
                        */
                    }
                }
                for (int i = 0; i < Courses.Count; i++)
                {
                    index = (int)randomGen.Next(slots);
                    sql = "Select ID from ADMIN.Section where Course_Code='" + Courses[i] + "'";
                    command = new OleDbCommand(sql, con);

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new ListViewItem();
                        item.Text = reader["ID"].ToString();


                        /////////////////
                        //MessageBox.Show(item.Text.ToString());
                        ///////////////


                        Exam_Sch.Add(timings[index] + "\t" + item.Text.ToString());
                        //lst_schedule.Items.Add(item);
                    }
                }



                // MessageBox.Show(Strength.ToString(), "Strength");


                //MessageBox.Show(item.ToString());


                for (int i = 0; i < Exam_Sch.Count; i++)
                {
                    //////////
                    //MessageBox.Show(Exam_Sch[i]);
                    ///////////
                }
                populate(Exam_Sch);
                FitnessChk(timings);

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Error");
            }
            finally
            {

            }

            sql = "select ES.Timings, ES.EXAM_Date ,ES.Room,S.ID,S.Course_Code,S.Teacher,C.Course_Name from ADMIN.Section S, ADMIN.Course C, ADMIN.Exam_Schedule ES where S.Course_code = C.Course_Code AND ES.Course = S.ID";

            command = new OleDbCommand(sql, con);

            reader = command.ExecuteReader();

            try
            {

                while (reader.Read())
                {
                    var item = new ListViewItem();

                    item.Text = reader["EXAM_DATE"].ToString();
                    item.SubItems.Add(reader["TIMINGS"].ToString());
                    item.SubItems.Add(reader["Course_Name"].ToString());
                    item.SubItems.Add(reader["Course_Code"].ToString());
                    item.SubItems.Add(reader["Room"].ToString());
                    item.SubItems.Add(reader["ID"].ToString());
                    item.SubItems.Add(reader["Teacher"].ToString());

                    lst_schedule.Items.Add(item);

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            finally
            {
            }

            //cmd = new OleDbCommand(sql, con);

            //reader = cmd.ExecuteReader();
            
      
 
        }

        private void cmd_genpdf_Click(object sender, EventArgs e)
        {
            frm_reppdf report = new frm_reppdf();
            report.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Scheduler
{

    public partial class frm_main_new : Form
    {
        #region
        List<String> timings = new List<String>();
        String dir_course;
        String dir_student;
        String dir_enrollment;
        String dir_folder;
        String dir_rooms;
        String dir_tt;
        OleDbCommand command;
        OleDbConnection con;
        String sql;
        List<String> Course = new List<String>();
        List<String> sections = new List<String>();
        List<String> StudentERP = new List<String>();
        List<String> Enrollments = new List<String>();
        List<List<string>> Genpopulation = new List<List<string>>();
        List<List<string>> list = new List<List<string>>();
        List<int> fitnesslist = new List<int>();
        List<List<string>> minimum;
        List<String> timetable = new List<string>();
        List<List<String>> rooms = new List<List<String>>();
        List<String> totcourse;

        Stopwatch watch = new Stopwatch();
        Stopwatch watch_delete = new Stopwatch();

        Thread import_course;
        Thread import_student;
        Thread import_enroll;

        BackgroundWorker bw;
        BackgroundWorker bw_sch;
        BackgroundWorker bw_cross;
        BackgroundWorker bw_mutate;
        #endregion

        public frm_main_new()
        {
            InitializeComponent();
        }


        private void cmd_import_Click(object sender, EventArgs e)
        {
            frm_view view = new frm_view();
            view.Show();
        }

        int maxSchProgress = 0;
        private void cmd_schedule_Click(object sender, EventArgs e)
        {
            if (txt_slots.Text.Equals(""))
            {
                MessageBox.Show("Please enter the no. of Slot");
                grp_input.Visible = false;
                grp_settings.Visible = false;
                grp_time.Visible = true;
            }
            else
            {

                bw_sch = new BackgroundWorker();
                bw_sch.DoWork += new DoWorkEventHandler(schedule);
                bw_sch.WorkerReportsProgress = true;

                bw_sch.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged_sch);
                bw_sch.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcessCompl_sch);
                bw_sch.RunWorkerAsync();
            }

            //DialogResult result;
            //int resultcount;
            //sql = "Select COUNT(*) from ADMIN.Exam_Schedule";
            //command = new OleDbCommand(sql, con);
            //resultcount = Convert.ToInt32(command.ExecuteScalar());
            //MessageBox.Show("Total records Found: " + resultcount.ToString());

            //if (resultcount > 0)
            //{
            //    result = MessageBox.Show("Exams scheduled already found, Do you wish to Schedule Again?", "Exams Found", MessageBoxButtons.YesNoCancel);

            //    if (result == DialogResult.Yes)
            //    {
            //        sql = "Delete from ADMIN.Exam_Schedule";
            //        command = new OleDbCommand(sql, con);
            //        command.ExecuteNonQuery();
            //    }
            //    else
            //    {
            //        MessageBox.Show("No Changes Made");
            //    }
            //}


            //result = MessageBox.Show("Do you wish to Schedule?", "Prompt", MessageBoxButtons.YesNo);

            //if (result == DialogResult.Yes)
            //{


            //    if (time_generate() == true)
            //    {
            //        /*
            //        frm_Schedule frm_sch = new frm_Schedule(timings);
            //        frm_sch.Show();
            //        //for (int i = 0; i < timings.Count; i++)
            //        //{
            //        //    MessageBox.Show(timings[i].ToString());

            //        //}
            //         */
            //        if (txt_slots.Text.Equals(""))
            //        {
            //            MessageBox.Show("Please enter the no. of Slot");
            //        }
            //        else
            //        {
            //            for (int i = 0; i < Convert.ToInt32(txt_iterations.Value); i++)
            //            {
            //                population(timings, sections);
            //                //bw_sch.ReportProgress(i*maxsections);
            //            }
            //            /*
            //            for (int i = 0; i < Genpopulation.Count; i++)
            //            {
            //                lbl_test.Text = lbl_test.Text + "Population No." + i.ToString() + "\n";

            //                for (int j = 0; j < Genpopulation[0].Count; j++)
            //                {
            //                    lbl_test.Text = lbl_test.Text + Genpopulation[i][j].ToString() + "\n";
            //                }

            //            }
            //            */
            //            fitnessChk();
            //            //frm_generate frm_gen = new frm_generate(Genpopulation[fitnesslist.IndexOf(fitnesslist.Min())]);
            //            //frm_gen.Show();


            //            List<List <string>> minimum = new List<List<string>>();
            //            List<List<string>> temp = new List<List<string>>();

            //            temp.AddRange(Genpopulation);

            //            for (int i = 0; i < 2; i++)
            //            {
            //                minimum.Add(temp[fitnesslist.IndexOf(fitnesslist.Min())]);
            //                temp.RemoveAt(fitnesslist.IndexOf(fitnesslist.Min()));
            //            }
            //            crossover(minimum);

            //            //frm_Schedule frm_sch = new frm_Schedule(Genpopulation[fitnesslist.IndexOf(fitnesslist.Min())], false);
            //            //frm_sch.Show();

            //            /*
            //            MessageBox.Show("LEAST  "+fitnesslist.Min());


            //            if (fitnesslist.Min() < 2)
            //            {
            //                frm_Schedule frm_sch = new frm_Schedule(Genpopulation[fitnesslist.IndexOf(fitnesslist.Min())]);
            //                frm_sch.Show();
            //            }
            //            else
            //            {
            //                for (int i = 0; i < 5; i++)
            //                {
            //                    mutate(Genpopulation[fitnesslist.IndexOf(fitnesslist.Min())]);
            //                }
            //            }
            //            */

            //        }


            //    }
            //    else
            //    {

            //    }
            //}
            //else if (result == DialogResult.No)
            //{
            //    frm_Schedule frm_sch = new frm_Schedule(true);
            //    frm_sch.Show();
            //}
            //else
            //{

            //}

        }

        private void ProcessCompl_sch(object sender, RunWorkerCompletedEventArgs e)
        {
            pb_course.Value = 0;
            txt_Console.Text = txt_Console.Text + "Population generation completed" + Environment.NewLine;
            /*
            MessageBox.Show((fitnesslist.IndexOf(fitnesslist.Min())).ToString());
            frm_Schedule frm_sch = new frm_Schedule(Genpopulation[fitnesslist.IndexOf(fitnesslist.Min())], false);
            frm_sch.Show();
             */
            //bw_sch.Dispose();
        }

        private void schedule(object sender, DoWorkEventArgs e)
        {

            DialogResult result;
            int resultcount;
            sql = "Select COUNT(*) from ADMIN.Exam_Schedule";
            command = new OleDbCommand(sql, con);
            resultcount = Convert.ToInt32(command.ExecuteScalar());
            MessageBox.Show("Total records Found: " + resultcount.ToString());

            if (resultcount > 0)
            {
                result = MessageBox.Show("Exams scheduled already found, Do you wish to Schedule Again?", "Exams Found", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    watch_delete.Start();
                    sql = "Delete from ADMIN.Exam_Schedule";
                    command = new OleDbCommand(sql, con);
                    command.ExecuteNonQuery();
                    watch_delete.Stop();
                }
                else
                {
                    MessageBox.Show("No Changes Made");
                }
            }


            result = MessageBox.Show("Do you wish to Schedule?", "Prompt", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                watch.Restart();
                watch.Start();
                if (time_generate() == true)
                {
                    /*
                    frm_Schedule frm_sch = new frm_Schedule(timings);
                    frm_sch.Show();
                    //for (int i = 0; i < timings.Count; i++)
                    //{
                    //    MessageBox.Show(timings[i].ToString());

                    //}
                     */
                    if (txt_slots.Text.Equals(""))
                    {
                        MessageBox.Show("Please enter the no. of Slot");
                    }
                    else
                    {
                        for (int i = 0; i < Convert.ToInt32(txt_iterations.Value); i++)
                        {
                            population(timings, sections);
                            //bw_sch.ReportProgress(i);
                        }
                        /*
                        for (int i = 0; i < Genpopulation.Count; i++)
                        {
                            lbl_test.Text = lbl_test.Text + "Population No." + i.ToString() + "\n";

                            for (int j = 0; j < Genpopulation[0].Count; j++)
                            {
                                lbl_test.Text = lbl_test.Text + Genpopulation[i][j].ToString() + "\n";
                            }

                        }
                        */
                        fitnessChk();
                        //frm_generate frm_gen = new frm_generate(Genpopulation[fitnesslist.IndexOf(fitnesslist.Min())]);
                        //frm_gen.Show();
                        watch.Stop();




                        bw_cross = new BackgroundWorker();
                        bw_cross.DoWork += new DoWorkEventHandler(crossing);
                        bw_cross.WorkerReportsProgress = true;

                        bw_cross.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged_cross);
                        bw_cross.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcessCompl_cross);
                        bw_cross.RunWorkerAsync();

                        // crossover(minimum);

                        //frm_Schedule frm_sch = new frm_Schedule(Genpopulation[fitnesslist.IndexOf(fitnesslist.Min())], false);
                        //frm_sch.Show();

                        /*
                        MessageBox.Show("LEAST  "+fitnesslist.Min());


                        if (fitnesslist.Min() < 2)
                        {
                            frm_Schedule frm_sch = new frm_Schedule(Genpopulation[fitnesslist.IndexOf(fitnesslist.Min())]);
                            frm_sch.Show();
                        }
                        else
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                mutate(Genpopulation[fitnesslist.IndexOf(fitnesslist.Min())]);
                            }
                        }
                        */

                    }


                }
                else
                {

                }
            }
            else if (result == DialogResult.No)
            {
                frm_Schedule frm_sch = new frm_Schedule(true);
                frm_sch.Show();
            }
            else
            {

            }

        }
        int maxcross = 0;

        private void ProcessCompl_cross(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show((fitnesslist.IndexOf(fitnesslist.Min())).ToString());
            this.Invoke(new MethodInvoker(delegate
            {
                txt_Console.Text = txt_Console.Text + "Crossover Completed" + fitnesslist.Min().ToString() + "   " + fitnesslist.IndexOf(fitnesslist.Min()) + Environment.NewLine;
                pb_course.Value = 0;
            }));
            bw_cross.Dispose();
            bw_mutate = new BackgroundWorker();
            bw_mutate.DoWork += new DoWorkEventHandler(mutation);
            bw_mutate.WorkerReportsProgress = true;

            bw_mutate.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged_mutate);
            bw_mutate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcessCompl_mutate);
            bw_mutate.RunWorkerAsync();

        }

        private void ProgressChanged_cross(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    pb_course.Maximum = Convert.ToInt32(Course.Count * Convert.ToInt32(txt_iterations.Value)) + (Convert.ToInt32(Course.Count * Convert.ToDouble(txt_crossoverrate.Value))) * Convert.ToInt32(txt_cross_times.Value);
                    txt_Console.Text = txt_Console.Text + "Crossover - " + pb_course.Value + Environment.NewLine;
                    pb_course.Value += 1;
                }));
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void crossing(object sender, DoWorkEventArgs e)
        {
            watch.Start();
            minimum = new List<List<string>>();
            List<List<string>> temp = new List<List<string>>();
            List<int> tempfit = new List<int>();
            int index = 0;
            for (int j = 0; j < Convert.ToInt32(txt_cross_times.Value); j++)
            {
                temp.Clear();
                minimum.Clear();
                tempfit.Clear();
                
                temp.AddRange(Genpopulation);
                tempfit.AddRange(fitnesslist);

                // BELOW is for Selecting the best of the best Parents always - Greedy Approach
                /*
                for (int i = 0; i < 2; i++)
                {
                    minimum.Add(temp[tempfit.IndexOf(tempfit.Min())]);

                    temp.RemoveAt(tempfit.IndexOf(tempfit.Min()));
                    tempfit.RemoveAt(tempfit.IndexOf(tempfit.Min()));
                }
                */

                for (int i = 0; i < 2; i++)
                {
                    index = randomGen.Next(temp.Count());
                    minimum.Add(temp[index]);
                    temp.RemoveAt(index);
                }
                crossover(minimum);
            }
            watch.Stop();
            /*
             * 
             * Random Selection of parents, Equal chance given to parents
             * mutation is somewhat succesfull to reduce the Clash... from 1789 - 1701
             * Run the loop until the fitness is 1000 - For now
             * While(fitness.Min()>=1000)
             * this loop will be placed the location where crossover is called...
             * 
             */ 
           
        }

        private void ProcessCompl_mutate(object sender, RunWorkerCompletedEventArgs e)
        {
            //watch.Stop();
            this.Invoke(new MethodInvoker(delegate
            {
                txt_Console.Text = txt_Console.Text + "Mutation Completed" + fitnesslist.Min().ToString() + "   " + fitnesslist.IndexOf(fitnesslist.Min()) + Environment.NewLine;
                txt_Console.Text = txt_Console.Text + watch.Elapsed.TotalSeconds.ToString() + Environment.NewLine + watch_delete.Elapsed.TotalSeconds.ToString()+ Environment.NewLine;
                txt_finalresult.Text = txt_finalresult.Text + "Final Fitness = " + fitnesslist.Min().ToString() + "   " + Environment.NewLine;
                txt_finalresult.Text = txt_finalresult.Text + watch.Elapsed.TotalSeconds.ToString() + Environment.NewLine + watch_delete.Elapsed.TotalSeconds.ToString() + Environment.NewLine;
                frm_Schedule frm_sch = new frm_Schedule(Genpopulation[fitnesslist.IndexOf(fitnesslist.Min())], false);
                frm_sch.Show();
            }));
            bw_mutate.Dispose();
        }

        private void ProgressChanged_mutate(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    pb_course.Maximum = Convert.ToInt32(txt_Mutation.Value * Convert.ToInt32(Course.Count * txt_mutrate.Value));
                    txt_Console.Text = txt_Console.Text + "Mutation - " + pb_course.Value + Environment.NewLine;
                    pb_course.Value += 1;
                }));
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void mutation(object sender, DoWorkEventArgs e)
        {
            watch.Start();
            minimum = new List<List<string>>();
            List<List<string>> temp = new List<List<string>>();
            List<int> tempfit = new List<int>();
            int index = 0;
            for (int j = 0; j < txt_Mutation.Value; j++)
            {
                
                temp.Clear();
                minimum.Clear();
                tempfit.Clear();

                temp.AddRange(Genpopulation);
                tempfit.AddRange(fitnesslist);
                index = (int)randomGen.Next(temp.Count());

                //minimum.Add(temp[tempfit.IndexOf(tempfit.Min())]); //SELECT BEST of the BEST Parent for mutation - GREEDY
                minimum.Add(temp[index]);
                mutate(minimum);
            }
            watch.Stop();
        }

        private void ProgressChanged_sch(object sender, ProgressChangedEventArgs e)
        {

            //MessageBox.Show("Population Generation   " + pb_course.Value.ToString() + "max" + pb_course.Maximum.ToString());
            pb_course.Maximum = (Convert.ToInt32(Course.Count * Convert.ToInt32(txt_iterations.Value))) + (Convert.ToInt32(Course.Count * Convert.ToDouble(txt_crossoverrate.Value)))+(StudentERP.Count*timings.Count*Genpopulation.Count);
            //txt_Console.Text = txt_Console.Text + "Population Generation   " + pb_course.Value.ToString() + "max" + pb_course.Maximum.ToString() + Environment.NewLine;

            pb_course.Value += 1;

        }

        private void population(object sender, DoWorkEventArgs e)
        {
            population(timings, sections);
        }


        private void cmd_check_Click(object sender, EventArgs e)
        {

            DateTime testing;

            DateTime time1 = Convert.ToDateTime(start_time.Text);
            DateTime time2 = Convert.ToDateTime(exam_dur.Text);
            DateTime time3 = Convert.ToDateTime(break_dur.Text);
            DateTime endtime;

            DateTime StartDate = Convert.ToDateTime(dtp_start.Text);
            DateTime EndDate = Convert.ToDateTime(dtp_end.Text);
            TimeSpan t = EndDate - StartDate;
            int Days = (int)t.TotalDays + 1;
            //MessageBox.Show("DAYS = " + Days);
            ArrayList slots = new ArrayList();


            /*
            endtime = Convert.ToDateTime(time1.AddHours(time2.Hour).AddMinutes(time2.Minute));
            
            lbl_test.Text = time1.ToShortTimeString() +" - " + endtime.ToShortTimeString();

            time1 = endtime.AddHours(1 * time3.Hour).AddMinutes(1 * time3.Minute);
            endtime = time1;
            endtime = Convert.ToDateTime(time1.AddHours(time2.Hour).AddMinutes(time2.Minute));

            lbl_test.Text = lbl_test.Text +"\n" +time1.ToShortTimeString() + " - " + endtime.ToShortTimeString();
            */
            lbl_test.Text = "";
            timings.Clear();
            if (txt_slots.Text.Equals(""))
            {
                MessageBox.Show("Please enter no. of slots to proceed");
            }
            else
            {
                for (int j = 0; j < Days; j++)
                {
                    time1 = Convert.ToDateTime(start_time.Text);
                    StartDate = StartDate.AddDays(1);
                    for (int i = 1; i <= int.Parse(txt_slots.Text); i++)
                    {

                        MessageBox.Show(j.ToString() + "\t" + StartDate.ToShortDateString());
                        endtime = Convert.ToDateTime(time1.AddHours(time2.Hour).AddMinutes(time2.Minute));
                        //lbl_test.Text = lbl_test.Text + "\n" + time1.ToShortTimeString() + " - " + endtime.ToShortTimeString();
                        timings.Add(StartDate.ToShortDateString() + "\t" + time1.ToShortTimeString() + "-" + endtime.ToShortTimeString());
                        time1 = endtime.AddHours(time3.Hour).AddMinutes(time3.Minute);
                        endtime = time1;
                        endtime = Convert.ToDateTime(time1.AddHours(time2.Hour).AddMinutes(time2.Minute));

                    }
                }
                for (int i = 0; i < timings.Count; i++)
                {
                    MessageBox.Show(timings[i].ToString());

                }

            }

        }

        private Boolean time_generate()
        {
            /// To calculate the Time slots///
            DateTime time1 = Convert.ToDateTime(start_time.Text);
            DateTime time2 = Convert.ToDateTime(exam_dur.Text);
            DateTime time3 = Convert.ToDateTime(break_dur.Text);
            DateTime endtime;
            //////////////////////////////////////

            /// To calculate the Date intervals///
            DateTime StartDate = Convert.ToDateTime(dtp_start.Text);
            DateTime EndDate = Convert.ToDateTime(dtp_end.Text);
            TimeSpan t = EndDate - StartDate;
            //////////////////////////////////////


            int Days = (int)t.TotalDays;

            ArrayList slots = new ArrayList();// To hold the slots

            lbl_test.Text = "";
            timings.Clear();
            if (txt_slots.Text.Equals(""))
            {
                MessageBox.Show("Please enter no. of slots to proceed");
                return false;
            }
            else
            {
                for (int j = 0; j <= Days; j++)
                {
                    time1 = Convert.ToDateTime(start_time.Text);
                    if (j == 0)
                    {
                        StartDate = StartDate.AddDays(0);
                    }
                    else
                    {
                        StartDate = StartDate.AddDays(1);
                    }

                    for (int i = 1; i <= int.Parse(txt_slots.Text); i++)
                    {

                        endtime = Convert.ToDateTime(time1.AddHours(time2.Hour).AddMinutes(time2.Minute));

                        timings.Add(StartDate.ToShortDateString() + "\t" + time1.ToShortTimeString() + "-" + endtime.ToShortTimeString());
                        time1 = endtime.AddHours(time3.Hour).AddMinutes(time3.Minute);
                        endtime = time1;
                        endtime = Convert.ToDateTime(time1.AddHours(time2.Hour).AddMinutes(time2.Minute));

                    }
                }
                return true;

            }


        }

        private void cmd_select_Click(object sender, EventArgs e)
        {
            //COURSE//
            open_file.ShowDialog();
            dir_course = open_file.FileName.Replace("\\", "\\\\");
            txt_dircourse.Text = open_file.FileName.ToString();
            //MessageBox.Show(dir_course.ToString());

        }


        int progress = 0;

        private void import_corse()
        {


            if (txt_dircourse.Text.ToString().Length < 1)
            {
                MessageBox.Show("Please select a valid CSV file", "Error");
            }
            else
            {

                if (File.Exists(dir_course))
                {
                    string[] data = File.ReadAllLines(dir_course);


                    ProgressBar pb = new ProgressBar();
                    pb.Maximum = data.Length;


                    Int32 resultcount = 0;

                    sql = "Select COUNT(*) from ADMIN.Section";
                    command = new OleDbCommand(sql, con);
                    resultcount = Convert.ToInt32(command.ExecuteScalar());
                    MessageBox.Show("Total records Found: " + resultcount.ToString());
                    DialogResult result;

                    if (resultcount > 1)
                    {
                        result = MessageBox.Show("Data Already Populated, Do you wish to delete all previous data?", "Data Found", MessageBoxButtons.YesNoCancel);
                    }
                    else
                    {
                        result = MessageBox.Show("Are you sure you want to import?", "Process", MessageBoxButtons.YesNo);
                    }
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            sql = "Delete from ADMIN.Exam_Schedule";
                            command = new OleDbCommand(sql, con);
                            command.ExecuteNonQuery();

                            sql = "Delete from ADMIN.Enrollment";
                            command = new OleDbCommand(sql, con);
                            command.ExecuteNonQuery();

                            sql = "Delete from ADMIN.Section";
                            command = new OleDbCommand(sql, con);
                            command.ExecuteNonQuery();

                            sql = "Delete from ADMIN.Course";
                            command = new OleDbCommand(sql, con);
                            command.ExecuteNonQuery();
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("Error Clearing Records", "Error Found");
                        }

                        DataTable dt = new DataTable();
                        string[] col = data[0].Split(',');

                        foreach (string s in col)
                        {
                            //lstv.Columns.Add(s, 50);   
                        }

                        for (int i = 1; i < data.Length; i++)
                        {

                            var item = new ListViewItem();

                            string[] row = data[i].Split(',');

                            for (int j = 1; j < row.Length; j++)
                            {
                                item.Text = row[0].ToString();
                                item.SubItems.Add(row[j].ToString());
                            }
                            try
                            {
                                //INSERT INTO COURSE VALUES (0,'MIS-204','DATAWAREHOUSING');
                                //INSERT INTO SECTION VALUES (40593,'MM-1','MIS-204','SIR IMRAN KHAN');
                                // MessageBox.Show("Course To be Inserted  " + row[1].ToString());

                                if (Course.Contains(row[1].ToString()) == false)
                                {
                                    sql = "INSERT INTO ADMIN.COURSE VALUES ((SELECT MAX(ID) FROM ADMIN.COURSE)+1,'" + row[1].ToString() + "','" + row[2].ToString() + "')";
                                    command = new OleDbCommand(sql, con);
                                    command.ExecuteNonQuery();

                                    Course.Add(row[1].ToString());
                                    //MessageBox.Show("Course Inserted" + row[1].ToString());
                                    //INSERT INTO SECTION VALUES (40593,'MM-1','MIS-204','SIR IMRAN KHAN','MAIN');
                                }
                                // MessageBox.Show("SECTION TO be Inserted  " + row[0].ToString());
                                sql = "INSERT INTO ADMIN.SECTION VALUES (" + row[0].ToString() + ",'" + row[4].ToString() + "','" + row[1].ToString() + "','" + row[3].ToString() + "','" + row[6].ToString() + "')";
                                command = new OleDbCommand(sql, con);
                                command.ExecuteNonQuery();
                                sections.Add(row[0].ToString() + "\t" + row[1].ToString());
                                //MessageBox.Show("SECTION Inserted" + row[0].ToString());

                                progress += 1;


                                //lstv.Items.Add(item);
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show("THE COURSE OR SECTION WITH NAME" + row[0].ToString() + row[1].ToString() + row[2].ToString() + row[3].ToString());
                                MessageBox.Show(exp.ToString());
                            }

                        }

                        MessageBox.Show("Courses and Sections added successfully");

                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show("No Changes made");
                    }
                    else { }
                }
                else
                {
                    MessageBox.Show("CSV File Does not Exist", "Error");
                }
            }
        }

        private void ProcessCompl(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("Importing Successful\nTotal Records imported: "+maxprogress.ToString());
            pb_course.Value = 0;
            txt_Console.Text = txt_Console.Text + "Importing Successful - Total Records imported: " + maxprogress.ToString() + "\r\n";
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pb_course.Maximum = maxprogress - 1;
            pb_course.Value += 1;
        }


        private void cmd_impcourse_Click(object sender, EventArgs e)
        {
            txt_Console.Text = txt_Console.Text + "Importing Course and Section Data\r\n";
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(DoWork);
            bw.WorkerReportsProgress = true;

            bw.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcessCompl);
            bw.RunWorkerAsync();

            /*iomport_course = new Thread(import_corse);
            import_course.IsBackground = true;
            import_course.Start();*/

        }
        int maxprogress = 0;
        int maxsections = 0;

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            if (txt_dircourse.Text.ToString().Length < 1)
            {
                MessageBox.Show("Please select a valid CSV file", "Error");
            }
            else
            {

                if (File.Exists(dir_course))
                {

                    string[] data = File.ReadAllLines(dir_course);

                    maxprogress = data.Length;
                    maxsections = data.Length - 1;


                    Int32 resultcount = 0;

                    sql = "Select COUNT(*) from ADMIN.Section";
                    command = new OleDbCommand(sql, con);
                    resultcount = Convert.ToInt32(command.ExecuteScalar());
                    MessageBox.Show("Total records Found: " + resultcount.ToString());
                    DialogResult result;

                    if (resultcount > 1)
                    {
                        result = MessageBox.Show("Data Already Populated, Do you wish to delete all previous data?", "Data Found", MessageBoxButtons.YesNoCancel);
                    }
                    else
                    {
                        result = MessageBox.Show("Are you sure you want to import?", "Process", MessageBoxButtons.YesNo);
                    }
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            sql = "Delete from ADMIN.Exam_Schedule";
                            command = new OleDbCommand(sql, con);
                            command.ExecuteNonQuery();
                            //txt_Console.Text = txt_Console.Text + "Deleting Exam Schedule" + "\n";

                            sql = "Delete from ADMIN.Enrollment";
                            command = new OleDbCommand(sql, con);
                            command.ExecuteNonQuery();

                            sql = "Delete from ADMIN.Section";
                            command = new OleDbCommand(sql, con);
                            command.ExecuteNonQuery();

                            sql = "Delete from ADMIN.Course";
                            command = new OleDbCommand(sql, con);
                            command.ExecuteNonQuery();
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("Error Clearing Records", "Error Found");
                        }

                        DataTable dt = new DataTable();
                        string[] col = data[0].Split(',');

                        foreach (string s in col)
                        {
                            //lstv.Columns.Add(s, 50);   
                        }

                        for (int i = 1; i < data.Length; i++)
                        {

                            var item = new ListViewItem();

                            string[] row = data[i].Split(',');

                            for (int j = 1; j < row.Length; j++)
                            {
                                item.Text = row[0].ToString();
                                item.SubItems.Add(row[j].ToString());
                            }
                            try
                            {
                                //INSERT INTO COURSE VALUES (0,'MIS-204','DATAWAREHOUSING');
                                //INSERT INTO SECTION VALUES (40593,'MM-1','MIS-204','SIR IMRAN KHAN');
                                // MessageBox.Show("Course To be Inserted  " + row[1].ToString());

                                if (Course.Contains(row[1].ToString() + "\t" + row[7].ToString() + "\t" + row[9].ToString()) == false)
                                {
                                    sql = "INSERT INTO ADMIN.COURSE VALUES ((SELECT MAX(ID) FROM ADMIN.COURSE)+1,'" + row[1].ToString() + "','" + row[2].ToString() + "')";
                                    command = new OleDbCommand(sql, con);
                                    command.ExecuteNonQuery();

                                    Course.Add(row[1].ToString()+"\t"+row[7].ToString()+"\t"+row[9].ToString());
                                    //MessageBox.Show("Course Inserted" + row[1].ToString());
                                    //INSERT INTO SECTION VALUES (40593,'MM-1','MIS-204','SIR IMRAN KHAN','MAIN');
                                }
                                // MessageBox.Show("SECTION TO be Inserted  " + row[0].ToString());

                                sql = "INSERT INTO ADMIN.SECTION VALUES (" + row[0].ToString() + ",'" + row[4].ToString() + "','" + row[1].ToString() + "','" + row[3].ToString() + "','" + row[6].ToString() + "')";
                                command = new OleDbCommand(sql, con);
                                command.ExecuteNonQuery();
                                sections.Add(row[0].ToString() + "\t" + row[1].ToString());
                                //MessageBox.Show("SECTION Inserted" + row[0].ToString());

                                bw.ReportProgress(i);
                                //progress += 1;



                                //lstv.Items.Add(item);
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show("THE COURSE OR SECTION WITH NAME" + row[0].ToString() + row[1].ToString() + row[2].ToString() + row[3].ToString());
                                MessageBox.Show(exp.ToString());
                            }

                        }

                        //MessageBox.Show("Courses and Sections added successfully");

                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show("No Changes made");
                    }
                    else { }
                }
                else
                {
                    MessageBox.Show("CSV File Does not Exist", "Error");
                }
            }
        }

        private void cmd_view_Click(object sender, EventArgs e)
        {
            frm_view view = new frm_view(dir_course);
            view.Show();

        }
        private void cmd_student_Click(object sender, EventArgs e)
        {
            //STUDENT//
            open_file.ShowDialog();
            dir_student = open_file.FileName.Replace("\\", "\\\\");
            txt_dirstudent.Text = open_file.FileName.ToString();
            // MessageBox.Show(dir_student.ToString());
        }

        private void cmd_rooms_Click(object sender, EventArgs e)
        {
            //ROOMS//
            open_file.ShowDialog();
            dir_rooms = open_file.FileName.Replace("\\", "\\\\");
            txt_dirrooms.Text = open_file.FileName.ToString();
            //MessageBox.Show(dir_rooms.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //STUDENT//
            frm_view view = new frm_view(dir_student);
            view.Show();
        }

        private void cmd_viewroom_Click(object sender, EventArgs e)
        {
            //ROOMS//
            frm_view view = new frm_view(dir_rooms);
            view.Show();
        }

        private void import_Student()
        {
            if (txt_dirstudent.Text.ToString().Length < 1)
            {
                MessageBox.Show("Please select a valid CSV file", "Error");
            }
            else
            {
                if (File.Exists(dir_course))
                {
                    Int32 resultcount = 0;

                    sql = "Select COUNT(*) from ADMIN.Student";
                    command = new OleDbCommand(sql, con);
                    resultcount = Convert.ToInt32(command.ExecuteScalar());
                    MessageBox.Show("Total records Found: " + resultcount.ToString());
                    DialogResult result;

                    if (resultcount > 0)
                    {
                        result = MessageBox.Show("Student Data already exist, Do you wish to overwrite?", "Data Found", MessageBoxButtons.YesNoCancel);
                    }
                    else
                    {
                        result = MessageBox.Show("Are you sure you want to import?", "Process", MessageBoxButtons.YesNo);
                    }
                    if (result == DialogResult.Yes)
                    {
                        sql = "Delete from ADMIN.Student";
                        command = new OleDbCommand(sql, con);
                        command.ExecuteNonQuery();

                        if (File.Exists(dir_student))
                        {
                            string[] data = File.ReadAllLines(dir_student);
                            DataTable dt = new DataTable();
                            string[] col = data[0].Split(',');

                            foreach (string s in col)
                            {
                                //lstv.Columns.Add(s, 50);   
                            }

                            for (int i = 1; i < data.Length; i++)
                            {

                                var item = new ListViewItem();

                                string[] row = data[i].Split(',');

                                for (int j = 1; j < row.Length; j++)
                                {
                                    item.Text = row[0].ToString();
                                    item.SubItems.Add(row[j].ToString());
                                }
                                try
                                {

                                    //INSERT INTO STUDENT VALUES (04421,'BILAL ARIF',03232008405,'');
                                    sql = "INSERT INTO ADMIN.STUDENT VALUES (" + row[0].ToString() + ",'" + row[1].ToString() + "',NULL,'')";
                                    command = new OleDbCommand(sql, con);
                                    command.ExecuteNonQuery();
                                    //MessageBox.Show("Record Inserted");
                                    //lstv.Items.Add(item);
                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show("INSERT INTO ADMIN.STUDENT VALUES (" + row[0].ToString() + ",'" + row[1].ToString() + "',NULL,'')");
                                    MessageBox.Show(exp.ToString());
                                }
                            }
                            MessageBox.Show("Students added successfully");
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show("No Changes made");
                    }
                    else { }
                }
                else
                {
                    MessageBox.Show("CSV File Does not Exist", "Error");
                }
            }
        }
        BackgroundWorker bw_student;
        private void cmd_impStudent_Click(object sender, EventArgs e)
        {
            /*
            import_student = new Thread(import_Student);
            import_student.IsBackground = true;
            import_student.Start();
             */
            txt_Console.Text = txt_Console.Text + "Importing Student's Data\r\n";
            bw_student = new BackgroundWorker();
            bw_student.DoWork += new DoWorkEventHandler(imp_student);
            bw_student.WorkerReportsProgress = true;

            bw_student.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            bw_student.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcessCompl);
            bw_student.RunWorkerAsync();



        }

        private void imp_student(object sender, DoWorkEventArgs e)
        {
            if (txt_dirstudent.Text.ToString().Length < 1)
            {
                MessageBox.Show("Please select a valid CSV file", "Error");
            }
            else
            {
                if (File.Exists(dir_course))
                {
                    Int32 resultcount = 0;


                    sql = "Select COUNT(*) from ADMIN.Student";
                    command = new OleDbCommand(sql, con);
                    resultcount = Convert.ToInt32(command.ExecuteScalar());
                    MessageBox.Show("Total records Found: " + resultcount.ToString());
                    DialogResult result;

                    if (resultcount > 0)
                    {
                        result = MessageBox.Show("Student Data already exist, Do you wish to overwrite?", "Data Found", MessageBoxButtons.YesNoCancel);
                    }
                    else
                    {
                        result = MessageBox.Show("Are you sure you want to import?", "Process", MessageBoxButtons.YesNo);
                    }
                    if (result == DialogResult.Yes)
                    {
                        sql = "Delete from ADMIN.Student";
                        command = new OleDbCommand(sql, con);
                        command.ExecuteNonQuery();

                        string[] data = File.ReadAllLines(dir_student);
                        DataTable dt = new DataTable();
                        string[] col = data[0].Split(',');

                        maxprogress = data.Length;
                        foreach (string s in col)
                        {
                            //lstv.Columns.Add(s, 50);   
                        }

                        for (int i = 1; i < data.Length; i++)
                        {

                            var item = new ListViewItem();

                            string[] row = data[i].Split(',');

                            for (int j = 1; j < row.Length; j++)
                            {
                                item.Text = row[0].ToString();
                                item.SubItems.Add(row[j].ToString());
                            }
                            try
                            {

                                //INSERT INTO STUDENT VALUES (04421,'BILAL ARIF',03232008405,'');
                                sql = "INSERT INTO ADMIN.STUDENT VALUES (" + row[0].ToString() + ",'" + row[1].ToString() + "',NULL,'')";
                                command = new OleDbCommand(sql, con);
                                command.ExecuteNonQuery();


                                StudentERP.Add(row[0].ToString());


                                bw_student.ReportProgress(i);

                                //MessageBox.Show("Record Inserted");
                                //lstv.Items.Add(item);
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show("INSERT INTO ADMIN.STUDENT VALUES (" + row[0].ToString() + ",'" + row[1].ToString() + "',NULL,'')");
                                MessageBox.Show(exp.ToString());
                            }
                        }
                        //MessageBox.Show("Students added successfully");
                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show("No Changes made");
                    }
                    else { }
                }
                else
                {
                    MessageBox.Show("CSV File Does not Exist", "Error");
                }
            }
        }

        private void import_tb_Click(object sender, EventArgs e)
        {

        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=OraOLEDB.Oracle;Password=bilal;User ID=system;Data Source=xe;Persist Security Info=True");
            con.Open();
        }

        private void cmd_viewenrollment_Click(object sender, EventArgs e)
        {
            //ENROLLMENT//
            frm_view view = new frm_view(dir_enrollment);
            view.Show();
        }

        private void import_enrollment()
        {
            //DialogResult result = MessageBox.Show("Enrollment Data already exist, Do you wish to overwrite?","Data Found",MessageBoxButtons.YesNoCancel);


            //if (result == DialogResult.Yes)
            //{
            /*  sql = "Delete from ADMIN.Enrollment";
              command = new OleDbCommand(sql, con);
              command.ExecuteNonQuery();
         */
            if (txt_direnrollment.Text.ToString().Length < 1)
            {
                MessageBox.Show("Please select a valid CSV file", "Error");
            }
            else
            {
                if (File.Exists(dir_enrollment))
                {
                    string[] data = File.ReadAllLines(dir_enrollment);
                    DataTable dt = new DataTable();
                    string[] col = data[0].Split(',');

                    foreach (string s in col)
                    {
                        //lstv.Columns.Add(s, 50);   
                    }

                    for (int i = 1; i < data.Length; i++)
                    {

                        var item = new ListViewItem();

                        string[] row = data[i].Split(',');

                        for (int j = 1; j < row.Length; j++)
                        {
                            item.Text = row[0].ToString();
                            item.SubItems.Add(row[j].ToString());
                        }
                        try
                        {
                            //INSERT INTO ENROLLMENT VALUES ((SELECT MAX(ENROLL_ID) FROM ENROLLMENT)+1,04542,40594);
                            //MessageBox.Show("TO BE INSERTED  " + row[0].ToString() + row[1].ToString() + row[2].ToString());
                            sql = "INSERT INTO ADMIN.ENROLLMENT VALUES (" + row[0].ToString() + "," + row[2].ToString() + "," + row[1].ToString() + ")";
                            command = new OleDbCommand(sql, con);
                            Enrollments.Add(row[1] + "\t" + row[2]);
                            command.ExecuteNonQuery();

                            //MessageBox.Show("INSERTED  " + row[0].ToString() + row[1].ToString() + row[2].ToString());
                            //lstv.Items.Add(item);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("INSERT INTO ADMIN.ENROLLMENT VALUES (" + row[0].ToString() + "," + row[2].ToString() + "," + row[1].ToString() + ")");
                            MessageBox.Show(exp.ToString());
                        }
                    }
                    MessageBox.Show("Enrollments added successfully");

                }
                else
                {
                    MessageBox.Show("CSV File Does not Exist", "Error");
                }
            }
            /*}
            else if (result == DialogResult.No)
            {
                MessageBox.Show("No Changes made");
            }
            else { }*/
        }
        BackgroundWorker bw_enroll;
        private void cmd_impenrollment_Click(object sender, EventArgs e)
        {
            /*
            import_enroll = new Thread(import_enrollment);
            import_enroll.IsBackground = true;
            import_enroll.Start(); 
           */
            txt_Console.Text = txt_Console.Text + "Importing Enrollment's Data\r\n";
            pb_course.Value = 0;
            bw_enroll = new BackgroundWorker();
            bw_enroll.DoWork += new DoWorkEventHandler(DoWork_enrollment);
            bw_enroll.WorkerReportsProgress = true;

            bw_enroll.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            bw_enroll.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcessCompl);
            bw_enroll.RunWorkerAsync();




        }

        private void DoWork_enrollment(object sender, DoWorkEventArgs e)
        {
            //DialogResult result = MessageBox.Show("Enrollment Data already exist, Do you wish to overwrite?","Data Found",MessageBoxButtons.YesNoCancel);


            //if (result == DialogResult.Yes)
            //{
            /*  sql = "Delete from ADMIN.Enrollment";
              command = new OleDbCommand(sql, con);
              command.ExecuteNonQuery();
         */
            if (txt_direnrollment.Text.ToString().Length < 1)
            {
                MessageBox.Show("Please select a valid CSV file", "Error");
            }
            else
            {
                if (File.Exists(dir_enrollment))
                {
                    string[] data = File.ReadAllLines(dir_enrollment);
                    DataTable dt = new DataTable();
                    string[] col = data[0].Split(',');
                    maxprogress = data.Length;

                    foreach (string s in col)
                    {
                        //lstv.Columns.Add(s, 50);   
                    }

                    for (int i = 1; i < data.Length; i++)
                    {

                        var item = new ListViewItem();

                        string[] row = data[i].Split(',');

                        for (int j = 1; j < row.Length; j++)
                        {
                            item.Text = row[0].ToString();
                            item.SubItems.Add(row[j].ToString());
                        }
                        try
                        {
                            //INSERT INTO ENROLLMENT VALUES ((SELECT MAX(ENROLL_ID) FROM ENROLLMENT)+1,04542,40594);
                            //MessageBox.Show("TO BE INSERTED  " + row[0].ToString() + row[1].ToString() + row[2].ToString());
                            sql = "INSERT INTO ADMIN.ENROLLMENT VALUES (" + row[0].ToString() + "," + row[2].ToString() + "," + row[1].ToString() + ")";
                            command = new OleDbCommand(sql, con);
                            // SECTION \t Student ERP
                            Enrollments.Add(row[1] + "\t" + row[2]);
                            command.ExecuteNonQuery();
                            bw_enroll.ReportProgress(i);
                            //MessageBox.Show("INSERTED  " + row[0].ToString() + row[1].ToString() + row[2].ToString());
                            //lstv.Items.Add(item);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("INSERT INTO ADMIN.ENROLLMENT VALUES (" + row[0].ToString() + "," + row[2].ToString() + "," + row[1].ToString() + ")");
                            MessageBox.Show(exp.ToString());
                        }
                    }
                    //MessageBox.Show("Enrollments added successfully");

                }
                else
                {
                    MessageBox.Show("CSV File Does not Exist", "Error");
                }
            }
            /*}
            else if (result == DialogResult.No)
            {
                MessageBox.Show("No Changes made");
            }
            else { }*/
        }

        private void cmd_enrollment_Click(object sender, EventArgs e)
        {
            //ENROLLMENT//
            open_file.ShowDialog();
            dir_enrollment = open_file.FileName.Replace("\\", "\\\\");
            txt_direnrollment.Text = open_file.FileName.ToString();
            // MessageBox.Show(dir_enrollment.ToString());
        }

        BackgroundWorker bw_rooms;

        private void cmd_improoms_Click(object sender, EventArgs e)
        {
            txt_Console.Text = txt_Console.Text + "Importing Room's Data\r\n";
            bw_rooms = new BackgroundWorker();
            bw_rooms.DoWork += new DoWorkEventHandler(import_rooms);
            bw_rooms.WorkerReportsProgress = true;

            bw_rooms.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            bw_rooms.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcessCompl);
            bw_rooms.RunWorkerAsync();


        }

        private void import_rooms(object sender, DoWorkEventArgs e)
        {

            Int32 resultcount = 0;
            if (txt_dirrooms.Text.ToString().Length < 1)
            {
                MessageBox.Show("Please select a valid CSV file", "Error");
            }
            else
            {
                if (File.Exists(dir_rooms))
                {
                    sql = "Select COUNT(*) from ADMIN.Rooms";
                    command = new OleDbCommand(sql, con);
                    resultcount = Convert.ToInt32(command.ExecuteScalar());
                    MessageBox.Show("Total records Found: " + resultcount.ToString());
                    DialogResult result;

                    if (resultcount > 0)
                    {
                        result = MessageBox.Show("Room Data already exist, Do you wish to overwrite?", "Data Found", MessageBoxButtons.YesNoCancel);
                    }
                    else
                    {
                        result = MessageBox.Show("Are you sure you want to import?", "Process", MessageBoxButtons.YesNo);
                    }
                    if (result == DialogResult.Yes)
                    {
                        sql = "Delete from ADMIN.Rooms";
                        command = new OleDbCommand(sql, con);
                        command.ExecuteNonQuery();


                        string[] data = File.ReadAllLines(dir_rooms);
                        DataTable dt = new DataTable();
                        string[] col = data[0].Split(',');

                        maxprogress = data.Length;

                        foreach (string s in col)
                        {
                            //lstv.Columns.Add(s, 50);   
                        }

                        for (int i = 1; i < data.Length; i++)
                        {

                            var item = new ListViewItem();

                            string[] row = data[i].Split(',');

                            for (int j = 1; j < row.Length; j++)
                            {
                                item.Text = row[0].ToString();
                                item.SubItems.Add(row[j].ToString());
                            }
                            //INSERT INTO ROOMS VALUES (1,'MAC-1','ADAMJEE BLOCK',45,'CLASS');
                            sql = "INSERT INTO ADMIN.ROOMS VALUES (" + row[0].ToString() + ",'" + row[2].ToString() + "','" + row[1].ToString() + "'," + row[3].ToString() + ",'" + row[4].ToString() + "')";
                            command = new OleDbCommand(sql, con);
                            command.ExecuteNonQuery();
                            bw_rooms.ReportProgress(i);


                            //lstv.Items.Add(item);

                        }
                        //MessageBox.Show("ROOMS added successfully");
                    }

                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show("No Changes made");
                    }
                    else { }
                }
                else
                {
                    MessageBox.Show("CSV File Does not Exist", "Error");
                }
            }
        }

        private void cmd_pdf_Click(object sender, EventArgs e)
        {
            frm_reppdf pdf = new frm_reppdf();
            pdf.Show();
        }

        Random randomGen = new Random();

        private void population(List<String> timings, List<String> Section)
        {
            //MessageBox.Show("Population");
            Object result;
            List<string> Exam_Sch = new List<string>();
            int index=0;
            int slots = timings.Count;
            int totstrength = 0;
            int slot=0;

            List<String> timingsroom = new List<string>();
            timingsroom.AddRange(timings);

            totcourse = new List<String>();
            //totcourse.AddRange(Course);
            totcourse.Clear();
            int ans = 0;

            List<String> totsection = new List<String>();
           // totsection.AddRange(Section);

            ArrayList totRooms = new ArrayList();
            totRooms.AddRange(timings);

            sql = "select C.COURSE_CODE As Course,COUNT(S.Section_CODE) As Strength from ADMIN.enrollment E, ADMIN.Section S,ADMIN.Course C where E.SECTION_CODE = S.ID AND S.COURSE_CODE = C.COURSE_CODE group by C.COURSE_CODE";
            command = new OleDbCommand(sql, con);
            OleDbDataReader reader = command.ExecuteReader();

            try
            {

                while (reader.Read())
                {

                    totcourse.Add(reader["Course"].ToString() + "\t" + reader["Strength"].ToString());
                    //MessageBox.Show(totcourse[index].ToString());

                    this.Invoke(new MethodInvoker(delegate
                    {
                        txt_Console.Text = txt_Console.Text +"TESTING STRENGTH" +reader["Strength"].ToString() + Environment.NewLine;
                    }));


                    index += 1;
                    //MessageBox.Show(Course[index - 1].ToString());
                }
                index = 0;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }

            /*
            sql = "select C.Course_Code As Code, COUNT(S.ID) As Count from ADMIN.Section S, ADMIN.Course C where S.Course_CODE = C.Course_CODE Group by C.Course_Code;";
            command = new OleDbCommand(sql, con);
            reader = command.ExecuteReader();

            try
            {

                while (reader.Read())
                {
                    totsection.Add(reader["Code"].ToString() + "\t" + reader["Count"].ToString());
                    
                }
                
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            */
            sql = "select SUM(Capacity) from ADMIN.rooms";
            command = new OleDbCommand(sql, con);
            result = command.ExecuteScalar();
            totstrength = Convert.ToInt32(result)-300;
            int exams=10;

            for (int c = 0; c < timings.Count; c++)
            {
                timingsroom[c] = timingsroom[c] + "\t" + totstrength.ToString()+"\t"+exams.ToString();
            }

            /*
            sql = "select Room_ID,Capacity from ADMIN.ROOMS";
            command = new OleDbCommand(sql, con);
            reader = command.ExecuteReader();
            ArrayList dwrstrength = new ArrayList();
            ArrayList rooms = new ArrayList();
            try
            {

                while (reader.Read())
                {
                    rooms.Add(reader["Room_ID"].ToString() + "\t" + reader["Capacity"].ToString());
                    index += 1;
                }
                index = 0;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            

            for (int i = 0; i < timings.Count; i++)
            {
                for (int j = 0; j < rooms.Count; j++)
                {
                    dwrstrength.Add(timings[i].ToString()+"\t"+rooms[j].ToString());
                }
            }
            */
            //MessageBox.Show(timingsroom[2].ToString());
            int assigner = 0;
            String pre = "";
            for (int i = 0; i < totcourse.Count; i++)
            {
                //index = (int)randomGen.Next(slots);
                // sql = "Select ID from ADMIN.Section where Course_Code='" + Courses[i] + "'";
                // MessageBox.Show("Im in For Loop");
                /*
                 in population function
                --get total rooms strength slot wise...
                --subtract it if the course strength fits in
                --then when it comes to sections... 
                get sepertae rooms strength day wise... and allocate it like wise
                
                */
                if ((assigner) == (Convert.ToInt32(slots) / Convert.ToInt32(txt_slots.Text)))
                {
                    assigner = 0;
                }

                String[] CourseSpl = Course[i].ToString().Split('\t');
                String[] csplit = "\t\t".Split('\t');
                IEnumerable<string> coursequery = totcourse.Where(course => course.Contains(CourseSpl[0].ToString()));
                foreach (string course in coursequery)
                {

                     csplit = course.ToString().Split('\t');
                }

                index = randomGen.Next(1, 3);
                
                /*
                this.Invoke(new MethodInvoker(delegate
                {
                    txt_Console.Text = txt_Console.Text + totcourse[i]+Environment.NewLine;
                }));
                 */
                /*
                IEnumerable<string> queryTT = timetable.Where(courseinfo => courseinfo.Contains(totcourse[0].ToString()));
                foreach (string courseinfo in queryTT)
                {
                    String[] Split = courseinfo.ToString().Split('\t');
                    //proindex += 1;

                    if (Convert.ToInt32(Split[0]) == 4 || Convert.ToInt32(Split[0]) == 5)
                    {
                        slot = ((Convert.ToInt32(Split[index]) - 1) * Convert.ToInt32(txt_slots.Text)) + 4;
                        //slot = ((DAY in Timetable-1)*No. of defined slots for Exams) +slot in Timetable
                    }
                    else
                    {
                        slot = ((Convert.ToInt32(Split[index]) - 1) * Convert.ToInt32(txt_slots.Text)) + Convert.ToInt32(Split[0]);
                    }
                    break;

                }
                */
                String[] CourseCode = CourseSpl[0].Split(' ');

                if (CourseSpl[1].Equals("Elective")==true)
                {
                    slots = randomGen.Next(slots);
                }
                else
                if (Convert.ToInt32(CourseSpl[1]) > 0 && Convert.ToInt32(CourseSpl[1]) < 3)
                {
                    if (pre.Equals(CourseSpl[2]) == true)
                    {
                        if ((slot + 1) == slots)
                        {
                            slot -= 1;
                        }
                        else
                        {
                            slot += 1;
                        }
                    }
                    else
                    {
                        slot = Convert.ToInt32(txt_slots.Text) * assigner;
                        assigner += 1;
                        pre = CourseSpl[2].ToString();
                    }
                }
                else if (Convert.ToInt32(CourseSpl[1]) > 2 && Convert.ToInt32(CourseSpl[1]) < 5)
                {
                    if (pre.Equals(CourseSpl[2]) == true)
                    {
                        if ((slot + 1) == slots)
                        {
                            slot -= 1;
                        }
                        else
                        {
                            slot += 1;
                        }
                    }
                    else
                    {
                        slot = Convert.ToInt32(txt_slots.Text) * assigner;
                        assigner += 1;
                        pre = CourseSpl[2].ToString();
                    }
                }
                else if ((CourseCode[0].Equals("SSC") == true) && (Convert.ToInt32(CourseCode[1].Substring(0, 2)) == 20))
                {
                    slot = 18;
                }
                else
                {
                    slots = randomGen.Next(slots);
                    pre = CourseSpl[2].ToString();
                }
                



                //try
                //{
                    //MessageBox.Show("Im in Try");
                    int proindex = 0;
                    int left = 0;                  
                    while (ans >= 0)
                    {
                        //MessageBox.Show("Im in While");
                        String[] tsplit = timingsroom[slot].ToString().Split('\t');

                        ans = Convert.ToInt32(tsplit[2]) - Convert.ToInt32(csplit[1]);
                        //MessageBox.Show(tsplit[2].ToString() +" - " +csplit[1].ToString() + " = " + ans.ToString());
                        //MessageBox.Show("Below");
                        //MessageBox.Show(sec + "\t" + Course[i].ToString());
                        
                        if (ans < 0)
                        {
                            /*
                            if (index == 1)
                            {
                                index = 2;
                                proindex += 1;
                            }
                            else
                            {
                                index = 1;
                                proindex += 1;
                            }
                            */
                            //if (proindex > 1)
                            //{
                                for (int j = 0; j < timings.Count; j++)
                                {
                                    String[] Splitiming = timingsroom[j].ToString().Split('\t');
                                    if (Convert.ToInt32(csplit[1]) <= Convert.ToInt32(Splitiming[2]))
                                    {
                                        slot = j;
                                        ans = 0;
                                        break;
                                    }
                                }
                            //}

                                //index = (int)randomGen.Next(1, 2);
                            /*
                            for (int j = 0; j < timings.Count; j++)
                            {
                                String[] Splitiming = timingsroom[j].ToString().Split('\t');
                                if (Convert.ToInt32(csplit[1]) <= Convert.ToInt32(Splitiming[2]))
                                {
                                    slot = j;
                                    ans = 0;
                                    break;
                                }
                            }
                             */ 

                           // index = (int)randomGen.Next(1,2);
                            //proindex += 1;
                            //MessageBox.Show(ans.ToString() + "Change the slot " + csplit[0].ToString());
                            
                        }
                        else
                        {
                            int sch = 0;
                            //int left=0;
                            IEnumerable<string> query = Section.Where(sec => sec.Contains(csplit[0].ToString()));
                            foreach (string sec in query)
                            {
                                String[] Split = sec.ToString().Split('\t');
                                //proindex += 1;
                                
                                Exam_Sch.Add(timings[slot] + "\t" + Split[0]);
                                //MessageBox.Show(timings[index].ToString() + "\t" + Split[0].ToString());
                                sch += 1;
                                //left = Convert.ToInt32(tsplit[3]) - sch;
                                timingsroom[slot] = tsplit[0].ToString() + "\t" + tsplit[1].ToString() + "\t" + ans.ToString();
                                //MessageBox.Show(tsplit[0].ToString() + "\t" + tsplit[1].ToString() + "\t" + ans.ToString());
                                /*
                                this.Invoke(new MethodInvoker(delegate
                                {
                                    txt_Console.Text = txt_Console.Text +Split[0]+ " " +tsplit[0].ToString() + " " + tsplit[1].ToString() + " " + ans.ToString() +Environment.NewLine;
                                }));
                                */
                            }
                            ans = 0;
                            break;
                        }
                        ans = 0;
                    }
                    //bw_sch.ReportProgress(i);
                /*}
                catch (Exception exp)
                {
                    MessageBox.Show("Population\t" + exp.ToString());
                }*/
                /////////////////
                //MessageBox.Show(item.Text.ToString());
                ///////////////


                //Exam_Sch.Add(timings[index] + "\t" + item.Text.ToString());
                //lst_schedule.Items.Add(item);
                bw_sch.ReportProgress(i);
            }
            Exam_Sch.Sort();
            Genpopulation.Add(Exam_Sch);
            rooms.Add(timingsroom);
        }
        private void cmd_pop_Click(object sender, EventArgs e)
        {
            time_generate();
            for (int i = 0; i < 5; i++)
            {
                population(timings, sections);
            }

            for (int i = 0; i < Genpopulation.Count; i++)
            {
                lbl_test.Text = lbl_test.Text + "Population No." + i.ToString() + "\n";

                for (int j = 0; j < Genpopulation[0].Count; j++)
                {
                    lbl_test.Text = lbl_test.Text + Genpopulation[i][j].ToString() + "\n";
                }

            }
            fitnessChk();



        }

        private void fitnessChk()
        {
            int fitness = 0;
            List<int> fitnesstemp = new List<int>();
            List<string> students = new List<string>();
            List<string> temp = new List<string>();
            List<string> sec = new List<string>();
            fitnesslist.Clear();
            int count = 0;
            for (int i = 0; i < Genpopulation.Count; i++)
            {

                fitnesstemp.Clear();
                fitness = 0;
                for (int j = 0; j < timings.Count; j++)
                {
                    IEnumerable<string> query = Genpopulation[i].Where(pop => pop.Contains(timings[j].ToString()));
                    //students.Clear();
                    //sec.Clear();
                    foreach (string pop in query)
                    {

                        //MessageBox.Show(pop + "\t" + Course[i].ToString());
                        String[] Split = pop.ToString().Split('\t');
                        sec.Add(Split[2].ToString());


                        //MessageBox.Show(Split[2].ToString());
                        
                        IEnumerable<string> query2 = Enrollments.Where(enroll => enroll.Contains(Split[2].ToString()));
                        foreach (string enroll in query2)
                        {
                            String[] StudentSplt = enroll.ToString().Split('\t');

                            students.Add(StudentSplt[1].ToString());

                        }

                        
                        //sec.Clear();
                        /*
                        students.GroupBy(erp => erp)
                            .Where(common => common.Count() > 2)
                            .ToList()
                            //.ForEach(groupitem => MessageBox.Show(groupitem.Key + "\t" + groupitem.Count()));
                            .ForEach(groupItem => fitness += groupItem.Count());
                        */

                    }
                    List<String> duplicates = students.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Count().ToString()).ToList();

                    duplicates.ForEach(sum => fitness += Convert.ToInt32(sum));

                    if (fitness > 0)
                    {
                        fitness = fitness;
                    }
                        
                    students.Clear();
                    sec.Clear();
                    
                    //for (int s = 0; s < StudentERP.Count; s++)
                    //{
                    //    for (int SC = 0; SC < sec.Count; SC++)
                    //    {

                    //        if (Enrollments.Contains(sec[SC].ToString() + "\t" + StudentERP[s].ToString()) == true)
                    //        {
                    //            count += 1;
                    //        }
                    //        /*
                    //        IEnumerable<string> query2 = Enrollments.Where(enroll => enroll.Contains(sec[SC].tpStudentERP[s].ToString()));
                    //        foreach (string enroll in query2)
                    //        {
                    //            count += 1;
                    //        }
                    //         */ 
                          
                    //    }
                    //    if (count <= 1)
                    //    {
                    //        count = 0;
                    //    }
                    //    else
                    //    {
                    //        fitness += count;
                    //        count = 0;
                    //    }
                    //    bw_sch.ReportProgress(s);
                    //}
                    //////////////////////////
                    ////////// CODE HERE
                }
                fitnesslist.Add(fitness);
                //MessageBox.Show(fitness.ToString());
            }
            /*
            for (int i = 0; i < fitnesslist.Count(); i++)
            {
                MessageBox.Show(fitnesslist[i].ToString());
            }
            */
        }

        private void fitnessChk(List<string> patient)
        {
            int fitness = 0;
            fitnesslist = new List<int>();
            List<int> fitnesstemp = new List<int>();
            List<string> students = new List<string>();
            List<string> temp = new List<string>();
            fitnesstemp.Clear();
            fitness = 0;

            for (int j = 0; j < timings.Count; j++)
            {


                IEnumerable<string> query = patient.Where(pop => pop.Contains(timings[j].ToString()));
                students.Clear();
                foreach (string pop in query)
                {

                    //MessageBox.Show(pop + "\t" + Course[i].ToString());
                    String[] Split = pop.ToString().Split('\t');
                    //MessageBox.Show(Split[2].ToString());

                    IEnumerable<string> query2 = Enrollments.Where(enroll => enroll.Contains(Split[2].ToString()));
                    foreach (string enroll in query2)
                    {
                        String[] StudentSplt = enroll.ToString().Split('\t');

                        students.Add(StudentSplt[0].ToString());
                    }
                    List<String> duplicates = students.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Count().ToString()).ToList();
                    /*
                    students.GroupBy(erp => erp)
                        .Where(common => common.Count() > 1)
                        .ToList()
                        //.ForEach(groupitem => MessageBox.Show(groupitem.Key + "\t" + groupitem.Count()));
                        .ForEach(groupItem => fitness += groupItem.Count());*/
                }


            }
            fitnesslist.Add(fitness);
            //MessageBox.Show(fitness.ToString());

            for (int i = 0; i < fitnesslist.Count(); i++)
            {
                MessageBox.Show("Mutation kay BAAD    " + fitnesslist[i].ToString());
            }
        }

        private void crossover(List<List<string>> parents)
        {
            int maxcrossover;
            maxcrossover = Convert.ToInt32(Course.Count * Convert.ToDouble(txt_crossoverrate.Value));
            int index = 0;
            List<string> parent1 = new List<string>();
            List<string> parent2 = new List<string>();
            parent1.AddRange(parents[0]);
            parent2.AddRange(parents[1]);
            int index1 = 0, index2 = 0;
            String temp = "";

            for (int i = 0; i < maxcrossover; i++)
            {
                //MessageBox.Show("Crossovering");
                index = randomGen.Next(Course.Count);
                //String[] examsplit = parent1[index].ToString().Split('\t');

                /// Finding the respective Section ID
                IEnumerable<string> query = sections.Where(sectionslist => sectionslist.Contains(Course.ToString()));
                foreach (string sectionslist in query)
                {
                    String[] Splitted = sectionslist.Split('\t');
                    IEnumerable<string> queryp1 = parent1.Where(swaping => swaping.Contains(Splitted[0].ToString()));
                    foreach (string swapping in queryp1)
                    {
                        index1 = parent1.IndexOf(swapping);
                    }

                    IEnumerable<string> queryp2 = parent2.Where(swaping => swaping.Contains(Splitted[0].ToString()));
                    foreach (string swapping in queryp2)
                    {
                        index2 = parent2.IndexOf(swapping);
                    }


                    temp = parent1[index1].ToString();
                    parent1[index1] = parent2[index2];
                    parent2[index2] = temp;
                    //MessageBox.Show(parent1[index2].ToString() +"\t" +parent2[index2].ToString());

                }
                bw_cross.ReportProgress(i);

            }
 


            /*
            //// FINDING the Respective Course ID
            IEnumerable<string> query = sections.Where(course => course.Contains(parent1[2].ToString()));
            foreach (string course in query)
            {
                String[] coursesplit = course.Split('\t');

                /// Finding the respective Section ID
                IEnumerable<string> query1 = sections.Where(sectionslist => sectionslist.Contains(coursesplit[1].ToString()));
                foreach (string sectionslist in query1)
                {
                    String[] Splitted = sectionslist.Split('\t');
                    IEnumerable<string> queryp1 = parent1.Where(swaping => swaping.Contains(Splitted[0].ToString()));
                    foreach (string swapping in queryp1)
                    {
                        index1 = parent1.IndexOf(swapping);
                    }

                    IEnumerable<string> queryp2 = parent2.Where(swaping => swaping.Contains(Splitted[0].ToString()));
                    foreach (string swapping in queryp2)
                    {
                        index2 = parent2.IndexOf(swapping);
                    }


                    temp = parent1[index1].ToString();
                    parent1[index1] = parent2[index2];
                    parent2[index2] = temp;
                    //MessageBox.Show(parent1[index2].ToString() +"\t" +parent2[index2].ToString());
                        
                }
                bw_cross.ReportProgress(i);
            }
            */
            Genpopulation.Add(parent1);
            Genpopulation.Add(parent2);
            index1 = Genpopulation.IndexOf(parents[0]);
            rooms.Add(rooms[index1]);
            rooms.Add(rooms[index1]);
            fitnessChk();
        }

        private void mutate(List<List<string>> parent)
        {
            int index;
            int timeindex;
            int popindex = 0;
            popindex = Genpopulation.IndexOf(parent[0]);
            List<string> mutated = new List<string>();
            List<String> timingsroom = new List<string>();
            timingsroom.AddRange(rooms[popindex]);
            int ans = 0, oldans = 0 ;
            int oldTindex = 0;
            mutated.AddRange(parent[0]);
            List<int> leftlist = new List<int>();
            int max_mutation = Convert.ToInt32(Course.Count * (txt_mutrate.Value));
            for (int i = 0; i < max_mutation; i++)
            {
                index = randomGen.Next(Course.Count);
                /////////////////////// Have to fetch the Course with its strenght --- DONE
                /////////////////////// Then split it--- DONE
                /////// Then calculate the ans ---- DONE
                ///// Subtract the course strenght from the current slot-- DONE
                /////////// Then chk... in While (ans >=0)--DONE
                /////////// if the course fits in the new slot then place it--- DONE
                ////// OR other wise--- DONE
                ////////// find the next suitable slot--- DONE
                /*
                for (int j = 0; j < timings.Count; j++)
                {
                    String[] Splitiming = timingsroom[j].ToString().Split('\t');
                    leftlist.Add(Convert.ToInt32(Splitiming[2]));
                }

                timeindex = leftlist.IndexOf(leftlist.Max());
                leftlist.Clear();
                */
                timeindex = randomGen.Next(timings.Count);
                String[] TSplit = "".Split('\t');
                String[] csplit = "\t\t".Split('\t');
                String[] CourseSpl = Course[index].ToString().Split('\t');
                
                
                IEnumerable<string> coursequery = totcourse.Where(course => course.Contains(CourseSpl[0].ToString()));
                foreach (string course in coursequery)
                {
                    csplit = course.ToString().Split('\t');
                    break;
                }

                IEnumerable<string> querysecs = sections.Where(sectionlist => sectionlist.Contains(CourseSpl[0].ToString()));
                foreach (string sectionlist in querysecs)
                {
                    String[] tempSplit = sectionlist.Split('\t');
                    IEnumerable<string> queryfind = mutated.Where(findtime => findtime.Contains(tempSplit[0].ToString()));
                    foreach (string findtime in queryfind)
                    {
                        TSplit = findtime.Split('\t');
                    }
                }

                oldTindex = timings.IndexOf(TSplit[0].ToString()+"\t"+TSplit[1].ToString());//Get index of OLD Timing

                TSplit = timingsroom[oldTindex].Split('\t');//Split the OLD TIME
                oldans = Convert.ToInt32(TSplit[2]) + Convert.ToInt32(csplit[1]);//Refill the course strength
                //oldTindex = timingsroom.IndexOf(TSplit[0].ToString() + "\t" + TSplit[1].ToString() + "\t" + csplit[2].ToString());//Find the index of the old timings room
                timingsroom[oldTindex] = TSplit[0].ToString() + "\t" + TSplit[1].ToString() + "\t" + oldans.ToString();//Update the new strength in the timings room

               
                while (ans >= 0)
                {
                    String[] tsplit = timingsroom[timeindex].ToString().Split('\t');//Break the new timing
                    ans = Convert.ToInt32(tsplit[2]) - Convert.ToInt32(csplit[1]);//Subtract the course strength in the timings
                    // FInding respective Section using Course

                    if (ans < 0)
                    {
                        
                        for (int j = 0; j < timings.Count; j++)
                        {
                            String[] Splitiming = timingsroom[j].ToString().Split('\t');
                            leftlist.Add(Convert.ToInt32(Splitiming[2]));
                        }

                        timeindex = leftlist.IndexOf(leftlist.Max());
                        leftlist.Clear();
                    }
                    else
                    {
                        IEnumerable<string> querysec = sections.Where(sectionlist => sectionlist.Contains(CourseSpl[0].ToString()));
                        foreach (string sectionlist in querysec)
                        {
                            String[] Splitted = sectionlist.Split('\t');
                            //Finding section in parent
                            IEnumerable<string> query = parent[0].Where(child => child.Contains(Splitted[0].ToString()));
                            foreach (string child in query)
                            {
                                String[] SplitParent = child.Split('\t');
                                mutated.Remove(child.ToString());
                                /*this.Invoke(new MethodInvoker(delegate
                                {
                                    txt_Console.Text = txt_Console.Text +"After removing " +child.ToString()+"\t"+mutated.Count+Environment.NewLine;
                                }));*/
                                mutated.Add(timings[timeindex] + "\t" + SplitParent[2]);
                                /*this.Invoke(new MethodInvoker(delegate
                                {
                                    txt_Console.Text = txt_Console.Text +"After Adding " +mutated.Count + Environment.NewLine;
                                }));*/
                            }
                            parent[0].Clear();
                            parent[0].AddRange(mutated);
                        }
                        break;
                    }
                }
                bw_mutate.ReportProgress(i);
            }
            Genpopulation.Add(mutated);
            rooms.Add(timingsroom);
            fitnessChk();


            /*
            int c1index, c2index;
            c1index = randomGen.Next(parent.Count);
            c2index = randomGen.Next(parent.Count());
            List<string> section1=new List<string>();
            List<string> section2=new List<string>();

            while (c1index == c2index)
            {
                c2index = randomGen.Next(parent.Count());
            }
            String[] c1 = parent[c1index].ToString().Split('\t');
            String[] c2 = parent[c2index].ToString().Split('\t');

            IEnumerable<string> query11 = sections.Where(course1 => course1.Contains(c1[2].ToString()));
            foreach (string course1 in query11)
            {
                String[] courselist1 = course1.Split('\t');
                IEnumerable<string> query12 = sections.Where(sections1 => sections1.Contains(courselist1[1].ToString()));
                foreach (string sections1 in query12)
                {
                    String[] Splitted = sections1.Split('\t');

                    section1.Add(Splitted[0].ToString());
                }
            }

            IEnumerable<string> query21 = sections.Where(course2 => course2.Contains(c2[2].ToString()));
            foreach (string course2 in query21)
            {
                String[] courselist2 = course2.Split('\t');
                IEnumerable<string> query22 = sections.Where(sections2 => sections2.Contains(courselist2[1].ToString()));
                foreach (string sections2 in query22)
                {
                    
                    String[] Splitted = sections2.Split('\t');
            03266l        MessageBox.Show(Splitted[0].ToString());
                    section2.Add(Splitted[0].ToString());
                }
            }
///////////////////////////////////////////////////////////////////////////////////////////////////
            String slot1 = c1[0].ToString() + "\t" + c1[1].ToString();
            String slot2 = c2[0].ToString() + "\t" + c2[1].ToString();
            List<string> templist = new List<string>();
            templist = parent;
            try
            {
                ///// FOR First Child/////////////
                for (int i = 0; i < section1.Count(); i++)
                {
                    String temp;
                    int swapindex = 0;

                    IEnumerable<string> querychild1 = parent.Where(slot => slot.Contains(section1[i].ToString()));
                    MessageBox.Show(section1[i].ToString());

                    foreach (string slot in querychild1)
                    {
                        
                        String[] swapsplit = slot.Split('\t');
                        swapindex = templist.IndexOf(slot);
                        MessageBox.Show("BEFORE    " + parent[swapindex].ToString());
                        templist[swapindex] = slot2.ToString() + ("\t") + swapsplit[2].ToString();
                        MessageBox.Show("AFTER     "+parent[swapindex].ToString());
                    }
                }
            }
            catch (Exception exp)
            {
                
            }
                /////////////////////////////////
            try
            {
                ///// FOR Second Child//////////////
                for (int i = 0; i < section2.Count(); i++)
                {
                    String temp;
                    int swapindex = 0;
                    IEnumerable<string> querychild2 = parent.Where(slot => slot.Contains(section2[i].ToString()));
                    foreach (string slot in querychild2)
                    {
                        String[] swapsplit = slot.Split('\t');
                        swapindex = templist.IndexOf(slot);
                        templist[swapindex] = slot1.ToString() + ("\t") + swapsplit[2].ToString();
                    }
                }
            }
            catch (Exception exp)
            {

            }
                parent = templist;

        
            fitnessChk(parent);
            ///////////////////////////////////
            */
        }

        private void Sch_tab_Click(object sender, EventArgs e)
        {

        }

        private void cmd_report_Click(object sender, EventArgs e)
        {
            frm_reppdf report = new frm_reppdf();
            report.Show();
        }

        private void cmd_tt_Click(object sender, EventArgs e)
        {
            open_file.ShowDialog();
            dir_tt = open_file.FileName.Replace("\\", "\\\\");
            txt_tt.Text = open_file.FileName.ToString();
        }

        private void cmd_viewTT_Click(object sender, EventArgs e)
        {
            frm_view view = new frm_view(dir_tt);
            view.Show();
        }

        private void cmd_impTT_Click(object sender, EventArgs e)
        {
            txt_Console.Text = txt_Console.Text + "Importing Room's Data\r\n";
            bw_rooms = new BackgroundWorker();
            bw_rooms.DoWork += new DoWorkEventHandler(import_TT);
            bw_rooms.WorkerReportsProgress = true;

            bw_rooms.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            bw_rooms.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcessCompl);
            bw_rooms.RunWorkerAsync();
        }

        private void import_TT(object sender, DoWorkEventArgs e)
        {

            if (txt_tt.Text.ToString().Length < 1)
            {
                MessageBox.Show("Please select a valid CSV file", "Error");
            }
            else
            {
                if (File.Exists(dir_tt))
                {
                    string[] data = File.ReadAllLines(dir_tt);
                    string[] col = data[0].Split(',');

                    maxprogress = data.Length;

                    for (int i = 1; i < data.Length; i++)
                    {

                        var item = new ListViewItem();

                        string[] row = data[i].Split(',');
                        for (int j = 1; j < row.Length; j++)
                        {
                            item.Text = row[0].ToString();
                            item.SubItems.Add(row[j].ToString());
                        }
                        timetable.Add(row[0] + "\t"+row[1] +"\t" +row[2] +"\t" +row[4]);
                    }
                }
                else
                {
                    MessageBox.Show("CSV File Doesnt Exist");
                }
            }
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grp_student.Visible = false;
            grp_enrollment.Visible = false;
            grp_rooms.Visible = false;
            grp_timetable.Visible = false;
            grp_time.Visible = false;
            grp_settings.Visible = false;
            grp_advance.Visible = false;
            tbl_status.Visible = false;
            lbl_input.Visible = false;

            lbl_title.Visible = true;
            grp_course.Visible = true;
            grp_input.Visible = true;
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grp_course.Visible = false;
            grp_enrollment.Visible = false;
            grp_rooms.Visible = false;
            grp_timetable.Visible = false;
            grp_time.Visible = false;
            grp_settings.Visible = false;
            grp_advance.Visible = false;
            tbl_status.Visible = false;
            lbl_input.Visible = false;

            lbl_title.Visible = true;
            grp_student.Visible = true;
            grp_input.Visible = true;
        }

        private void enrollmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grp_course.Visible = false;
            grp_student.Visible = false;
            grp_rooms.Visible = false;
            grp_timetable.Visible = false;
            grp_time.Visible = false;
            grp_settings.Visible = false;
            grp_advance.Visible = false;
            tbl_status.Visible = false;
            lbl_input.Visible = false;

            lbl_title.Visible = true;
            grp_enrollment.Visible = true;
            grp_input.Visible = true;
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grp_course.Visible = false;
            grp_student.Visible = false;
            grp_enrollment.Visible = false;
            grp_timetable.Visible = false;
            grp_time.Visible = false;
            grp_settings.Visible = false;
            grp_advance.Visible = false;
            tbl_status.Visible = false;
            lbl_input.Visible = false;

            lbl_title.Visible = true;
            grp_rooms.Visible = true;
            grp_input.Visible = true;
        }

        private void timeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grp_course.Visible = false;
            grp_student.Visible = false;
            grp_enrollment.Visible = false;
            grp_rooms.Visible = false;
            grp_time.Visible = false;
            grp_settings.Visible = false;
            grp_advance.Visible = false;
            lbl_input.Visible = false;

            lbl_title.Visible = true;
            grp_timetable.Visible = true;
            grp_input.Visible = true;

        }

        private void timeParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_title.Visible = true;
            grp_settings.Visible = false;
            grp_input.Visible = false;
            grp_time.Visible = true;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grp_input.Visible = false;
            grp_time.Visible = false;
            grp_settings.Visible = true;
        }

        private void cmd_folder_Click(object sender, EventArgs e)
        {
            //FOLDER//
            folder_browse.ShowDialog();

            dir_folder = folder_browse.SelectedPath.Replace("\\", "\\\\");
            txt_folder.Text = folder_browse.SelectedPath.ToString();
            dir_course = folder_browse.SelectedPath.Replace("\\", "\\\\")  +"\\" + "Course.csv";
            txt_dircourse.Text = folder_browse.SelectedPath.ToString() + "\\" + "Course.csv";

            dir_student = folder_browse.SelectedPath.Replace("\\", "\\\\") + "\\" + "Student.csv";
            txt_dirstudent.Text = folder_browse.SelectedPath.ToString() + "\\" + "Student.csv";

            dir_enrollment = folder_browse.SelectedPath.Replace("\\", "\\\\") + "\\" + "Enrollment.csv";
            txt_direnrollment.Text = folder_browse.SelectedPath.ToString() + "\\" + "Enrollment.csv";

            dir_rooms = folder_browse.SelectedPath.Replace("\\", "\\\\") + "\\" + "Rooms.csv";
            txt_dirrooms.Text = folder_browse.SelectedPath.ToString() + "\\" + "Rooms.csv";

            dir_tt = folder_browse.SelectedPath.Replace("\\", "\\\\") + "\\" + "Timetable.csv";
            txt_tt.Text = folder_browse.SelectedPath.ToString() + "\\" + "Timetable.csv";


            // MessageBox.Show(dir_enrollment.ToString());
        }

        private void cmd_import_all_Click(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(importall);
            bw.WorkerReportsProgress = true;

            bw.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcessCompl);
            bw.RunWorkerAsync();
        }

        private void importall(object sender, DoWorkEventArgs e)
        {
            maxprogress = 0;
            string[] data_course={""};
            string[] data_student={""};
            string[] data_enroll={""};
            string[] data_rooms={""};
            string[] data_tt={""};
            try
            {
                sql = "Delete from ADMIN.Exam_Schedule";
                command = new OleDbCommand(sql, con);
                command.ExecuteNonQuery();
                //txt_Console.Text = txt_Console.Text + "Deleting Exam Schedule" + "\n";

                sql = "Delete from ADMIN.Enrollment";
                command = new OleDbCommand(sql, con);
                command.ExecuteNonQuery();

                sql = "Delete from ADMIN.Section";
                command = new OleDbCommand(sql, con);
                command.ExecuteNonQuery();

                sql = "Delete from ADMIN.Course";
                command = new OleDbCommand(sql, con);
                command.ExecuteNonQuery();

                sql = "Delete from ADMIN.Student";
                command = new OleDbCommand(sql, con);
                command.ExecuteNonQuery();

                sql = "Delete from ADMIN.Rooms";
                command = new OleDbCommand(sql, con);
                command.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error Clearing Records", "Error Found");
            }
            //////////////////////////////////////////////////////////////////////////////
            /////////////////////CHECKING ONLY////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////
            if (File.Exists(dir_course))
            {

                data_course = File.ReadAllLines(dir_course);
                maxprogress = maxprogress + data_course.Length;

            }
            else
            {
                MessageBox.Show("'Course.csv' does not exist");
            }
            ///////////////////////////////////////////////////////////////////
            if (File.Exists(dir_student))
            {

                data_student = File.ReadAllLines(dir_student);

                maxprogress = maxprogress + data_student.Length;
            }
            else
            {
                MessageBox.Show("'Student.csv' does not exist");
            }
            ///////////////////////////////////////////////////////////////////
            if (File.Exists(dir_enrollment))
            {

                data_enroll = File.ReadAllLines(dir_enrollment);

                maxprogress = maxprogress + data_enroll.Length;
            }
            else
            {
                MessageBox.Show("'Enrollment.csv' does not exist");
            }
            ////////////////////////////////////////////////////////////////
            if (File.Exists(dir_rooms))
            {

                data_rooms = File.ReadAllLines(dir_rooms);

                maxprogress = maxprogress + data_rooms.Length;
            }
            else
            {
                MessageBox.Show("'Rooms.csv' does not exist");
            }
            /////////////////////////////////////////////////////////////
            if (File.Exists(dir_tt))
            {

                data_tt = File.ReadAllLines(dir_tt);

                maxprogress = maxprogress + data_tt.Length;
            }
            else
            {
                MessageBox.Show("'Timetable.csv' does not exist");
            }
/////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////
            /////////////////COURSE
            ////////////////////////////////

            DataTable dt = new DataTable();
            string[] col = data_course[0].Split(',');

            for (int i = 1; i < data_course.Length; i++)
            {

                var item = new ListViewItem();

                string[] row = data_course[i].Split(',');

                for (int j = 1; j < row.Length; j++)
                {
                    item.Text = row[0].ToString();
                    item.SubItems.Add(row[j].ToString());
                }
                try
                {
                    //INSERT INTO COURSE VALUES (0,'MIS-204','DATAWAREHOUSING');
                    //INSERT INTO SECTION VALUES (40593,'MM-1','MIS-204','SIR IMRAN KHAN');
                    // MessageBox.Show("Course To be Inserted  " + row[1].ToString());

                    if (Course.Contains(row[1].ToString() + "\t" + row[7].ToString() + "\t" + row[9].ToString()) == false)
                    {
                        sql = "INSERT INTO ADMIN.COURSE VALUES ((SELECT MAX(ID) FROM ADMIN.COURSE)+1,'" + row[1].ToString() + "','" + row[2].ToString() + "')";
                        command = new OleDbCommand(sql, con);
                        command.ExecuteNonQuery();

                        Course.Add(row[1].ToString() + "\t" + row[7].ToString() + "\t" + row[9].ToString());
                        //MessageBox.Show("Course Inserted" + row[1].ToString());
                        //INSERT INTO SECTION VALUES (40593,'MM-1','MIS-204','SIR IMRAN KHAN','MAIN');
                    }
                    // MessageBox.Show("SECTION TO be Inserted  " + row[0].ToString());

                    sql = "INSERT INTO ADMIN.SECTION VALUES (" + row[0].ToString() + ",'" + row[4].ToString() + "','" + row[1].ToString() + "','" + row[3].ToString() + "','" + row[6].ToString() + "')";
                    command = new OleDbCommand(sql, con);
                    command.ExecuteNonQuery();
                    sections.Add(row[0].ToString() + "\t" + row[1].ToString());
                    //MessageBox.Show("SECTION Inserted" + row[0].ToString());

                    bw.ReportProgress(i);
                    //progress += 1;



                    //lstv.Items.Add(item);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("THE COURSE OR SECTION WITH NAME" + row[0].ToString() + row[1].ToString() + row[2].ToString() + row[3].ToString());
                    MessageBox.Show(exp.ToString());
                }

            }

            this.Invoke(new MethodInvoker(delegate
            {
                lbl_course_done.Visible = true;
            }));

            /////////////////////////////////////////END COURSE///////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////STUDENT/////////////////////////////////////////////////////////////
            DataTable dt_student = new DataTable();
            string[] col_student = data_student[0].Split(',');

            for (int i = 1; i < data_student.Length; i++)
            {

                var item = new ListViewItem();

                string[] row = data_student[i].Split(',');

                for (int j = 1; j < row.Length; j++)
                {
                    item.Text = row[0].ToString();
                    item.SubItems.Add(row[j].ToString());
                }
                try
                {

                    //INSERT INTO STUDENT VALUES (04421,'BILAL ARIF',03232008405,'');
                    sql = "INSERT INTO ADMIN.STUDENT VALUES (" + row[0].ToString() + ",'" + row[1].ToString() + "',NULL,'')";
                    command = new OleDbCommand(sql, con);
                    command.ExecuteNonQuery();
                    //MessageBox.Show("Record Inserted");
                    //lstv.Items.Add(item);
                    bw.ReportProgress(i);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("INSERT INTO ADMIN.STUDENT VALUES (" + row[0].ToString() + ",'" + row[1].ToString() + "',NULL,'')");
                    MessageBox.Show(exp.ToString());
                }
            }
            this.Invoke(new MethodInvoker(delegate
            {
                lbl_student_done.Visible = true;
            }));
            ///////////////////////////END Student/////////////////////////////////////////
            /////////////////////////ENROLLMENT//////////////////////////////////////////
            DataTable dt_enroll = new DataTable();
            string[] col_enroll = data_enroll[0].Split(',');            

            for (int i = 1; i < data_enroll.Length; i++)
            {

                var item = new ListViewItem();

                string[] row = data_enroll[i].Split(',');

                for (int j = 1; j < row.Length; j++)
                {
                    item.Text = row[0].ToString();
                    item.SubItems.Add(row[j].ToString());
                }
                try
                {
                    //INSERT INTO ENROLLMENT VALUES ((SELECT MAX(ENROLL_ID) FROM ENROLLMENT)+1,04542,40594);
                    //MessageBox.Show("TO BE INSERTED  " + row[0].ToString() + row[1].ToString() + row[2].ToString());
                    sql = "INSERT INTO ADMIN.ENROLLMENT VALUES (" + row[0].ToString() + "," + row[2].ToString() + "," + row[1].ToString() + ")";
                    command = new OleDbCommand(sql, con);
                    // SECTION \t Student ERP
                    Enrollments.Add(row[1] + "\t" + row[2]);
                    command.ExecuteNonQuery();
                    bw.ReportProgress(i);
                    //MessageBox.Show("INSERTED  " + row[0].ToString() + row[1].ToString() + row[2].ToString());
                    //lstv.Items.Add(item);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("INSERT INTO ADMIN.ENROLLMENT VALUES (" + row[0].ToString() + "," + row[2].ToString() + "," + row[1].ToString() + ")");
                    MessageBox.Show(exp.ToString());
                }
            }

            this.Invoke(new MethodInvoker(delegate
            {
                lbl_enroll_done.Visible = true;
            }));

            ///////////////////////END ENROLLMENT/////////////////////////////////////////
            ///////////////////////ROOMS/////////////////////////////////////////////////

            DataTable dt_rooms = new DataTable();
            string[] col_rooms = data_rooms[0].Split(',');



            for (int i = 1; i < data_rooms.Length; i++)
            {

                var item = new ListViewItem();

                string[] row = data_rooms[i].Split(',');

                for (int j = 1; j < row.Length; j++)
                {
                    item.Text = row[0].ToString();
                    item.SubItems.Add(row[j].ToString());
                }
                //INSERT INTO ROOMS VALUES (1,'MAC-1','ADAMJEE BLOCK',45,'CLASS');
                sql = "INSERT INTO ADMIN.ROOMS VALUES (" + row[0].ToString() + ",'" + row[2].ToString() + "','" + row[1].ToString() + "'," + row[3].ToString() + ",'" + row[4].ToString() + "')";
                command = new OleDbCommand(sql, con);
                command.ExecuteNonQuery();
                bw.ReportProgress(i);

            }

            this.Invoke(new MethodInvoker(delegate
            {
                lbl_rooms_done.Visible = true;
            }));

            ///////////////////////END ROOMS////////////////////////////////////////////////
            //////////////////////TIMETABLE/////////////////////////////////////////////////
            //string[] data_timetable = File.ReadAllLines(dir_tt);
            string[] col_tt = data_tt[0].Split(',');

            for (int i = 1; i < data_tt.Length; i++)
            {

                var item = new ListViewItem();

                string[] row = data_tt[i].Split(',');
                for (int j = 1; j < row.Length; j++)
                {
                    item.Text = row[0].ToString();
                    item.SubItems.Add(row[j].ToString());
                }
                timetable.Add(row[0] + "\t" + row[1] + "\t" + row[2] + "\t" + row[4]);
                bw.ReportProgress(i);
            }
            this.Invoke(new MethodInvoker(delegate
            {
                lbl_tt_done.Visible = true;
            }));
            ///////////////////////END TIMETABLE///////////////////////////////////////////




        }

        private void advanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            grp_course.Visible = false;
            grp_student.Visible = false;
            grp_enrollment.Visible = false;
            grp_rooms.Visible = false;
            grp_time.Visible = false;
            grp_settings.Visible = false;
            grp_timetable.Visible = false;

            lbl_title.Visible = true;
            grp_advance.Visible = true;
            tbl_status.Visible = true;
            grp_input.Visible = true;
            lbl_input.Visible = true;
        }

        private void cmd_exit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

    }
}
namespace Scheduler
{
    partial class frm_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.import_tb = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmd_viewTT = new System.Windows.Forms.Button();
            this.txt_tt = new System.Windows.Forms.TextBox();
            this.cmd_impTT = new System.Windows.Forms.Button();
            this.cmd_tt = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmd_viewenrollment = new System.Windows.Forms.Button();
            this.txt_direnrollment = new System.Windows.Forms.TextBox();
            this.cmd_impenrollment = new System.Windows.Forms.Button();
            this.cmd_enrollment = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmd_viewroom = new System.Windows.Forms.Button();
            this.txt_dirrooms = new System.Windows.Forms.TextBox();
            this.cmd_improoms = new System.Windows.Forms.Button();
            this.cmd_rooms = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmd_viewstudent = new System.Windows.Forms.Button();
            this.txt_dirstudent = new System.Windows.Forms.TextBox();
            this.cmd_impStudent = new System.Windows.Forms.Button();
            this.cmd_student = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_dircourse = new System.Windows.Forms.TextBox();
            this.cmd_viewcourse = new System.Windows.Forms.Button();
            this.cmd_impcourse = new System.Windows.Forms.Button();
            this.cmd_course = new System.Windows.Forms.Button();
            this.Sch_tab = new System.Windows.Forms.TabPage();
            this.cmd_report = new System.Windows.Forms.Button();
            this.cmd_pop = new System.Windows.Forms.Button();
            this.cmd_pdf = new System.Windows.Forms.Button();
            this.cmd_check = new System.Windows.Forms.Button();
            this.break_dur = new System.Windows.Forms.DateTimePicker();
            this.exam_dur = new System.Windows.Forms.DateTimePicker();
            this.start_time = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.cmd_schedule = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_slots = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_setting = new System.Windows.Forms.TabPage();
            this.txt_Mutation = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_mutrate = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_cross_times = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_crossoverrate = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_iterations = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_conString = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pb_course = new System.Windows.Forms.ProgressBar();
            this.lbl_test = new System.Windows.Forms.Label();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.txt_Console = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.import_tb.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Sch_tab.SuspendLayout();
            this.tb_setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mutrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cross_times)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_crossoverrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_iterations)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.import_tb);
            this.tabControl1.Controls.Add(this.Sch_tab);
            this.tabControl1.Controls.Add(this.tb_setting);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(599, 553);
            this.tabControl1.TabIndex = 0;
            // 
            // import_tb
            // 
            this.import_tb.Controls.Add(this.groupBox5);
            this.import_tb.Controls.Add(this.groupBox4);
            this.import_tb.Controls.Add(this.groupBox3);
            this.import_tb.Controls.Add(this.groupBox2);
            this.import_tb.Controls.Add(this.groupBox1);
            this.import_tb.Location = new System.Drawing.Point(4, 27);
            this.import_tb.Name = "import_tb";
            this.import_tb.Padding = new System.Windows.Forms.Padding(3);
            this.import_tb.Size = new System.Drawing.Size(591, 522);
            this.import_tb.TabIndex = 0;
            this.import_tb.Text = "Import Data";
            this.import_tb.UseVisualStyleBackColor = true;
            this.import_tb.Click += new System.EventHandler(this.import_tb_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.cmd_viewTT);
            this.groupBox5.Controls.Add(this.txt_tt);
            this.groupBox5.Controls.Add(this.cmd_impTT);
            this.groupBox5.Controls.Add(this.cmd_tt);
            this.groupBox5.Location = new System.Drawing.Point(37, 425);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(509, 94);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "TimeTable";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 18);
            this.label17.TabIndex = 13;
            this.label17.Text = "File Name:";
            // 
            // cmd_viewTT
            // 
            this.cmd_viewTT.Location = new System.Drawing.Point(154, 58);
            this.cmd_viewTT.Name = "cmd_viewTT";
            this.cmd_viewTT.Size = new System.Drawing.Size(113, 29);
            this.cmd_viewTT.TabIndex = 12;
            this.cmd_viewTT.Text = "View";
            this.cmd_viewTT.UseVisualStyleBackColor = true;
            this.cmd_viewTT.Click += new System.EventHandler(this.cmd_viewTT_Click);
            // 
            // txt_tt
            // 
            this.txt_tt.Location = new System.Drawing.Point(95, 23);
            this.txt_tt.Name = "txt_tt";
            this.txt_tt.Size = new System.Drawing.Size(289, 24);
            this.txt_tt.TabIndex = 12;
            // 
            // cmd_impTT
            // 
            this.cmd_impTT.Location = new System.Drawing.Point(6, 58);
            this.cmd_impTT.Name = "cmd_impTT";
            this.cmd_impTT.Size = new System.Drawing.Size(113, 29);
            this.cmd_impTT.TabIndex = 8;
            this.cmd_impTT.Text = "Import";
            this.cmd_impTT.UseVisualStyleBackColor = true;
            this.cmd_impTT.Click += new System.EventHandler(this.cmd_impTT_Click);
            // 
            // cmd_tt
            // 
            this.cmd_tt.Location = new System.Drawing.Point(390, 21);
            this.cmd_tt.Name = "cmd_tt";
            this.cmd_tt.Size = new System.Drawing.Size(113, 29);
            this.cmd_tt.TabIndex = 7;
            this.cmd_tt.Text = "Select";
            this.cmd_tt.UseVisualStyleBackColor = true;
            this.cmd_tt.Click += new System.EventHandler(this.cmd_tt_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.cmd_viewenrollment);
            this.groupBox4.Controls.Add(this.txt_direnrollment);
            this.groupBox4.Controls.Add(this.cmd_impenrollment);
            this.groupBox4.Controls.Add(this.cmd_enrollment);
            this.groupBox4.Location = new System.Drawing.Point(38, 226);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(509, 94);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Enrollment";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 18);
            this.label9.TabIndex = 13;
            this.label9.Text = "File Name:";
            // 
            // cmd_viewenrollment
            // 
            this.cmd_viewenrollment.Location = new System.Drawing.Point(154, 58);
            this.cmd_viewenrollment.Name = "cmd_viewenrollment";
            this.cmd_viewenrollment.Size = new System.Drawing.Size(113, 29);
            this.cmd_viewenrollment.TabIndex = 12;
            this.cmd_viewenrollment.Text = "View";
            this.cmd_viewenrollment.UseVisualStyleBackColor = true;
            this.cmd_viewenrollment.Click += new System.EventHandler(this.cmd_viewenrollment_Click);
            // 
            // txt_direnrollment
            // 
            this.txt_direnrollment.Location = new System.Drawing.Point(95, 23);
            this.txt_direnrollment.Name = "txt_direnrollment";
            this.txt_direnrollment.Size = new System.Drawing.Size(289, 24);
            this.txt_direnrollment.TabIndex = 12;
            // 
            // cmd_impenrollment
            // 
            this.cmd_impenrollment.Location = new System.Drawing.Point(6, 58);
            this.cmd_impenrollment.Name = "cmd_impenrollment";
            this.cmd_impenrollment.Size = new System.Drawing.Size(113, 29);
            this.cmd_impenrollment.TabIndex = 8;
            this.cmd_impenrollment.Text = "Import";
            this.cmd_impenrollment.UseVisualStyleBackColor = true;
            this.cmd_impenrollment.Click += new System.EventHandler(this.cmd_impenrollment_Click);
            // 
            // cmd_enrollment
            // 
            this.cmd_enrollment.Location = new System.Drawing.Point(390, 21);
            this.cmd_enrollment.Name = "cmd_enrollment";
            this.cmd_enrollment.Size = new System.Drawing.Size(113, 29);
            this.cmd_enrollment.TabIndex = 7;
            this.cmd_enrollment.Text = "Select";
            this.cmd_enrollment.UseVisualStyleBackColor = true;
            this.cmd_enrollment.Click += new System.EventHandler(this.cmd_enrollment_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cmd_viewroom);
            this.groupBox3.Controls.Add(this.txt_dirrooms);
            this.groupBox3.Controls.Add(this.cmd_improoms);
            this.groupBox3.Controls.Add(this.cmd_rooms);
            this.groupBox3.Location = new System.Drawing.Point(37, 326);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(509, 94);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rooms";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "File Name:";
            // 
            // cmd_viewroom
            // 
            this.cmd_viewroom.Location = new System.Drawing.Point(154, 58);
            this.cmd_viewroom.Name = "cmd_viewroom";
            this.cmd_viewroom.Size = new System.Drawing.Size(113, 29);
            this.cmd_viewroom.TabIndex = 12;
            this.cmd_viewroom.Text = "View";
            this.cmd_viewroom.UseVisualStyleBackColor = true;
            this.cmd_viewroom.Click += new System.EventHandler(this.cmd_viewroom_Click);
            // 
            // txt_dirrooms
            // 
            this.txt_dirrooms.Location = new System.Drawing.Point(95, 23);
            this.txt_dirrooms.Name = "txt_dirrooms";
            this.txt_dirrooms.Size = new System.Drawing.Size(289, 24);
            this.txt_dirrooms.TabIndex = 12;
            // 
            // cmd_improoms
            // 
            this.cmd_improoms.Location = new System.Drawing.Point(6, 58);
            this.cmd_improoms.Name = "cmd_improoms";
            this.cmd_improoms.Size = new System.Drawing.Size(113, 29);
            this.cmd_improoms.TabIndex = 8;
            this.cmd_improoms.Text = "Import";
            this.cmd_improoms.UseVisualStyleBackColor = true;
            this.cmd_improoms.Click += new System.EventHandler(this.cmd_improoms_Click);
            // 
            // cmd_rooms
            // 
            this.cmd_rooms.Location = new System.Drawing.Point(390, 21);
            this.cmd_rooms.Name = "cmd_rooms";
            this.cmd_rooms.Size = new System.Drawing.Size(113, 29);
            this.cmd_rooms.TabIndex = 7;
            this.cmd_rooms.Text = "Select";
            this.cmd_rooms.UseVisualStyleBackColor = true;
            this.cmd_rooms.Click += new System.EventHandler(this.cmd_rooms_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmd_viewstudent);
            this.groupBox2.Controls.Add(this.txt_dirstudent);
            this.groupBox2.Controls.Add(this.cmd_impStudent);
            this.groupBox2.Controls.Add(this.cmd_student);
            this.groupBox2.Location = new System.Drawing.Point(37, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 96);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Student";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "File Name:";
            // 
            // cmd_viewstudent
            // 
            this.cmd_viewstudent.Location = new System.Drawing.Point(154, 58);
            this.cmd_viewstudent.Name = "cmd_viewstudent";
            this.cmd_viewstudent.Size = new System.Drawing.Size(113, 29);
            this.cmd_viewstudent.TabIndex = 11;
            this.cmd_viewstudent.Text = "View";
            this.cmd_viewstudent.UseVisualStyleBackColor = true;
            this.cmd_viewstudent.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_dirstudent
            // 
            this.txt_dirstudent.Location = new System.Drawing.Point(96, 25);
            this.txt_dirstudent.Name = "txt_dirstudent";
            this.txt_dirstudent.Size = new System.Drawing.Size(289, 24);
            this.txt_dirstudent.TabIndex = 11;
            // 
            // cmd_impStudent
            // 
            this.cmd_impStudent.Location = new System.Drawing.Point(6, 58);
            this.cmd_impStudent.Name = "cmd_impStudent";
            this.cmd_impStudent.Size = new System.Drawing.Size(113, 29);
            this.cmd_impStudent.TabIndex = 8;
            this.cmd_impStudent.Text = "Import";
            this.cmd_impStudent.UseVisualStyleBackColor = true;
            this.cmd_impStudent.Click += new System.EventHandler(this.cmd_impStudent_Click);
            // 
            // cmd_student
            // 
            this.cmd_student.Location = new System.Drawing.Point(391, 23);
            this.cmd_student.Name = "cmd_student";
            this.cmd_student.Size = new System.Drawing.Size(113, 29);
            this.cmd_student.TabIndex = 7;
            this.cmd_student.Text = "Select";
            this.cmd_student.UseVisualStyleBackColor = true;
            this.cmd_student.Click += new System.EventHandler(this.cmd_student_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_dircourse);
            this.groupBox1.Controls.Add(this.cmd_viewcourse);
            this.groupBox1.Controls.Add(this.cmd_impcourse);
            this.groupBox1.Controls.Add(this.cmd_course);
            this.groupBox1.Location = new System.Drawing.Point(37, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 94);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Course";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "File Name:";
            // 
            // txt_dircourse
            // 
            this.txt_dircourse.Location = new System.Drawing.Point(96, 20);
            this.txt_dircourse.Name = "txt_dircourse";
            this.txt_dircourse.Size = new System.Drawing.Size(289, 24);
            this.txt_dircourse.TabIndex = 10;
            // 
            // cmd_viewcourse
            // 
            this.cmd_viewcourse.Location = new System.Drawing.Point(149, 58);
            this.cmd_viewcourse.Name = "cmd_viewcourse";
            this.cmd_viewcourse.Size = new System.Drawing.Size(113, 29);
            this.cmd_viewcourse.TabIndex = 9;
            this.cmd_viewcourse.Text = "View";
            this.cmd_viewcourse.UseVisualStyleBackColor = true;
            this.cmd_viewcourse.Click += new System.EventHandler(this.cmd_view_Click);
            // 
            // cmd_impcourse
            // 
            this.cmd_impcourse.Location = new System.Drawing.Point(6, 58);
            this.cmd_impcourse.Name = "cmd_impcourse";
            this.cmd_impcourse.Size = new System.Drawing.Size(113, 29);
            this.cmd_impcourse.TabIndex = 8;
            this.cmd_impcourse.Text = "Import";
            this.cmd_impcourse.UseVisualStyleBackColor = true;
            this.cmd_impcourse.Click += new System.EventHandler(this.cmd_impcourse_Click);
            // 
            // cmd_course
            // 
            this.cmd_course.Location = new System.Drawing.Point(391, 20);
            this.cmd_course.Name = "cmd_course";
            this.cmd_course.Size = new System.Drawing.Size(113, 29);
            this.cmd_course.TabIndex = 7;
            this.cmd_course.Text = "Select";
            this.cmd_course.UseVisualStyleBackColor = true;
            this.cmd_course.Click += new System.EventHandler(this.cmd_select_Click);
            // 
            // Sch_tab
            // 
            this.Sch_tab.Controls.Add(this.cmd_report);
            this.Sch_tab.Controls.Add(this.cmd_pop);
            this.Sch_tab.Controls.Add(this.cmd_pdf);
            this.Sch_tab.Controls.Add(this.cmd_check);
            this.Sch_tab.Controls.Add(this.break_dur);
            this.Sch_tab.Controls.Add(this.exam_dur);
            this.Sch_tab.Controls.Add(this.start_time);
            this.Sch_tab.Controls.Add(this.label10);
            this.Sch_tab.Controls.Add(this.label8);
            this.Sch_tab.Controls.Add(this.dtp_end);
            this.Sch_tab.Controls.Add(this.label5);
            this.Sch_tab.Controls.Add(this.dtp_start);
            this.Sch_tab.Controls.Add(this.cmd_schedule);
            this.Sch_tab.Controls.Add(this.label4);
            this.Sch_tab.Controls.Add(this.txt_slots);
            this.Sch_tab.Controls.Add(this.label2);
            this.Sch_tab.Controls.Add(this.label3);
            this.Sch_tab.Location = new System.Drawing.Point(4, 27);
            this.Sch_tab.Name = "Sch_tab";
            this.Sch_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Sch_tab.Size = new System.Drawing.Size(591, 522);
            this.Sch_tab.TabIndex = 1;
            this.Sch_tab.Text = "Scheduler";
            this.Sch_tab.UseVisualStyleBackColor = true;
            this.Sch_tab.Click += new System.EventHandler(this.Sch_tab_Click);
            // 
            // cmd_report
            // 
            this.cmd_report.Location = new System.Drawing.Point(138, 274);
            this.cmd_report.Name = "cmd_report";
            this.cmd_report.Size = new System.Drawing.Size(98, 47);
            this.cmd_report.TabIndex = 28;
            this.cmd_report.Text = "Generate Report";
            this.cmd_report.UseVisualStyleBackColor = true;
            this.cmd_report.Click += new System.EventHandler(this.cmd_report_Click);
            // 
            // cmd_pop
            // 
            this.cmd_pop.Location = new System.Drawing.Point(351, 90);
            this.cmd_pop.Name = "cmd_pop";
            this.cmd_pop.Size = new System.Drawing.Size(95, 23);
            this.cmd_pop.TabIndex = 27;
            this.cmd_pop.Text = "Population";
            this.cmd_pop.UseVisualStyleBackColor = true;
            this.cmd_pop.Visible = false;
            this.cmd_pop.Click += new System.EventHandler(this.cmd_pop_Click);
            // 
            // cmd_pdf
            // 
            this.cmd_pdf.Location = new System.Drawing.Point(336, 182);
            this.cmd_pdf.Name = "cmd_pdf";
            this.cmd_pdf.Size = new System.Drawing.Size(75, 23);
            this.cmd_pdf.TabIndex = 26;
            this.cmd_pdf.Text = "PDF";
            this.cmd_pdf.UseVisualStyleBackColor = true;
            this.cmd_pdf.Visible = false;
            this.cmd_pdf.Click += new System.EventHandler(this.cmd_pdf_Click);
            // 
            // cmd_check
            // 
            this.cmd_check.Location = new System.Drawing.Point(336, 152);
            this.cmd_check.Name = "cmd_check";
            this.cmd_check.Size = new System.Drawing.Size(75, 23);
            this.cmd_check.TabIndex = 25;
            this.cmd_check.Text = "button1";
            this.cmd_check.UseVisualStyleBackColor = true;
            this.cmd_check.Visible = false;
            this.cmd_check.Click += new System.EventHandler(this.cmd_check_Click);
            // 
            // break_dur
            // 
            this.break_dur.CustomFormat = "H:mm";
            this.break_dur.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.break_dur.Location = new System.Drawing.Point(136, 135);
            this.break_dur.Name = "break_dur";
            this.break_dur.ShowUpDown = true;
            this.break_dur.Size = new System.Drawing.Size(100, 24);
            this.break_dur.TabIndex = 23;
            this.break_dur.Value = new System.DateTime(2014, 12, 22, 0, 45, 0, 0);
            // 
            // exam_dur
            // 
            this.exam_dur.CustomFormat = "H:mm";
            this.exam_dur.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.exam_dur.Location = new System.Drawing.Point(136, 105);
            this.exam_dur.Name = "exam_dur";
            this.exam_dur.ShowUpDown = true;
            this.exam_dur.Size = new System.Drawing.Size(100, 24);
            this.exam_dur.TabIndex = 22;
            this.exam_dur.Value = new System.DateTime(2014, 12, 22, 1, 30, 0, 0);
            // 
            // start_time
            // 
            this.start_time.CustomFormat = "H:mm";
            this.start_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.start_time.Location = new System.Drawing.Point(136, 74);
            this.start_time.Name = "start_time";
            this.start_time.ShowUpDown = true;
            this.start_time.Size = new System.Drawing.Size(100, 24);
            this.start_time.TabIndex = 21;
            this.start_time.Value = new System.DateTime(2014, 12, 30, 9, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 18);
            this.label10.TabIndex = 20;
            this.label10.Text = "Exam Start";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "Break Duration";
            // 
            // dtp_end
            // 
            this.dtp_end.CustomFormat = "dd/MM/yyyy";
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_end.Location = new System.Drawing.Point(136, 227);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(100, 24);
            this.dtp_end.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "End Date";
            // 
            // dtp_start
            // 
            this.dtp_start.CustomFormat = "dd/MM/yyyy";
            this.dtp_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_start.Location = new System.Drawing.Point(136, 197);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(100, 24);
            this.dtp_start.TabIndex = 14;
            // 
            // cmd_schedule
            // 
            this.cmd_schedule.Location = new System.Drawing.Point(39, 274);
            this.cmd_schedule.Name = "cmd_schedule";
            this.cmd_schedule.Size = new System.Drawing.Size(92, 35);
            this.cmd_schedule.TabIndex = 12;
            this.cmd_schedule.Text = "Schedule";
            this.cmd_schedule.UseVisualStyleBackColor = true;
            this.cmd_schedule.Click += new System.EventHandler(this.cmd_schedule_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Start Date";
            // 
            // txt_slots
            // 
            this.txt_slots.Location = new System.Drawing.Point(136, 167);
            this.txt_slots.Name = "txt_slots";
            this.txt_slots.Size = new System.Drawing.Size(100, 24);
            this.txt_slots.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Slots";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Exam Duration";
            // 
            // tb_setting
            // 
            this.tb_setting.Controls.Add(this.txt_Mutation);
            this.tb_setting.Controls.Add(this.label15);
            this.tb_setting.Controls.Add(this.txt_mutrate);
            this.tb_setting.Controls.Add(this.label16);
            this.tb_setting.Controls.Add(this.txt_cross_times);
            this.tb_setting.Controls.Add(this.label14);
            this.tb_setting.Controls.Add(this.txt_crossoverrate);
            this.tb_setting.Controls.Add(this.label13);
            this.tb_setting.Controls.Add(this.txt_iterations);
            this.tb_setting.Controls.Add(this.label12);
            this.tb_setting.Controls.Add(this.txt_conString);
            this.tb_setting.Controls.Add(this.label11);
            this.tb_setting.Location = new System.Drawing.Point(4, 27);
            this.tb_setting.Name = "tb_setting";
            this.tb_setting.Size = new System.Drawing.Size(591, 522);
            this.tb_setting.TabIndex = 2;
            this.tb_setting.Text = "Settings";
            this.tb_setting.UseVisualStyleBackColor = true;
            // 
            // txt_Mutation
            // 
            this.txt_Mutation.Location = new System.Drawing.Point(158, 189);
            this.txt_Mutation.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txt_Mutation.Name = "txt_Mutation";
            this.txt_Mutation.Size = new System.Drawing.Size(62, 24);
            this.txt_Mutation.TabIndex = 12;
            this.txt_Mutation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(36, 191);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 18);
            this.label15.TabIndex = 11;
            this.label15.Text = "No. of Mutations";
            // 
            // txt_mutrate
            // 
            this.txt_mutrate.DecimalPlaces = 2;
            this.txt_mutrate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txt_mutrate.Location = new System.Drawing.Point(158, 161);
            this.txt_mutrate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_mutrate.Name = "txt_mutrate";
            this.txt_mutrate.Size = new System.Drawing.Size(62, 24);
            this.txt_mutrate.TabIndex = 10;
            this.txt_mutrate.Value = new decimal(new int[] {
            20,
            0,
            0,
            131072});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(54, 163);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 18);
            this.label16.TabIndex = 9;
            this.label16.Text = "Mutation Rate";
            // 
            // txt_cross_times
            // 
            this.txt_cross_times.Location = new System.Drawing.Point(158, 133);
            this.txt_cross_times.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txt_cross_times.Name = "txt_cross_times";
            this.txt_cross_times.Size = new System.Drawing.Size(62, 24);
            this.txt_cross_times.TabIndex = 8;
            this.txt_cross_times.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 18);
            this.label14.TabIndex = 7;
            this.label14.Text = "No. of Crossovers";
            // 
            // txt_crossoverrate
            // 
            this.txt_crossoverrate.DecimalPlaces = 2;
            this.txt_crossoverrate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txt_crossoverrate.Location = new System.Drawing.Point(158, 105);
            this.txt_crossoverrate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_crossoverrate.Name = "txt_crossoverrate";
            this.txt_crossoverrate.Size = new System.Drawing.Size(62, 24);
            this.txt_crossoverrate.TabIndex = 6;
            this.txt_crossoverrate.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 107);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 18);
            this.label13.TabIndex = 5;
            this.label13.Text = "CrossOver Rate";
            // 
            // txt_iterations
            // 
            this.txt_iterations.Location = new System.Drawing.Point(158, 75);
            this.txt_iterations.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txt_iterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_iterations.Name = "txt_iterations";
            this.txt_iterations.Size = new System.Drawing.Size(62, 24);
            this.txt_iterations.TabIndex = 4;
            this.txt_iterations.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(74, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 18);
            this.label12.TabIndex = 2;
            this.label12.Text = "Population";
            // 
            // txt_conString
            // 
            this.txt_conString.Enabled = false;
            this.txt_conString.Location = new System.Drawing.Point(158, 36);
            this.txt_conString.Name = "txt_conString";
            this.txt_conString.Size = new System.Drawing.Size(352, 24);
            this.txt_conString.TabIndex = 1;
            this.txt_conString.Text = "Provider=OraOLEDB.Oracle;Password=bilal;User ID=system;Data Source=xe;Persist Sec" +
    "urity Info=True";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Connection String";
            // 
            // pb_course
            // 
            this.pb_course.BackColor = System.Drawing.SystemColors.Control;
            this.pb_course.Location = new System.Drawing.Point(2, 561);
            this.pb_course.Name = "pb_course";
            this.pb_course.Size = new System.Drawing.Size(595, 18);
            this.pb_course.TabIndex = 12;
            // 
            // lbl_test
            // 
            this.lbl_test.AutoSize = true;
            this.lbl_test.Location = new System.Drawing.Point(607, 9);
            this.lbl_test.Name = "lbl_test";
            this.lbl_test.Size = new System.Drawing.Size(0, 13);
            this.lbl_test.TabIndex = 24;
            this.lbl_test.Visible = false;
            // 
            // open_file
            // 
            this.open_file.Filter = "DATA FILE (*.CSV, *.csv)|*.CSV;*.csv";
            // 
            // txt_Console
            // 
            this.txt_Console.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Console.Location = new System.Drawing.Point(610, 26);
            this.txt_Console.Multiline = true;
            this.txt_Console.Name = "txt_Console";
            this.txt_Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Console.Size = new System.Drawing.Size(303, 440);
            this.txt_Console.TabIndex = 25;
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 591);
            this.Controls.Add(this.txt_Console);
            this.Controls.Add(this.pb_course);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbl_test);
            this.Name = "frm_main";
            this.Text = "Smart Exam Scheculer";
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.tabControl1.ResumeLayout(false);
            this.import_tb.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Sch_tab.ResumeLayout(false);
            this.Sch_tab.PerformLayout();
            this.tb_setting.ResumeLayout(false);
            this.tb_setting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mutrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cross_times)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_crossoverrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_iterations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage import_tb;
        private System.Windows.Forms.TabPage Sch_tab;
        private System.Windows.Forms.OpenFileDialog open_file;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmd_schedule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_slots;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.DateTimePicker start_time;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmd_check;
        private System.Windows.Forms.Label lbl_test;
        private System.Windows.Forms.DateTimePicker break_dur;
        private System.Windows.Forms.DateTimePicker exam_dur;
        private System.Windows.Forms.Button cmd_course;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmd_rooms;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmd_student;
        private System.Windows.Forms.Button cmd_improoms;
        private System.Windows.Forms.Button cmd_impStudent;
        private System.Windows.Forms.Button cmd_impcourse;
        private System.Windows.Forms.Button cmd_viewcourse;
        private System.Windows.Forms.Button cmd_viewroom;
        private System.Windows.Forms.TextBox txt_dirrooms;
        private System.Windows.Forms.Button cmd_viewstudent;
        private System.Windows.Forms.TextBox txt_dirstudent;
        private System.Windows.Forms.TextBox txt_dircourse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmd_viewenrollment;
        private System.Windows.Forms.TextBox txt_direnrollment;
        private System.Windows.Forms.Button cmd_impenrollment;
        private System.Windows.Forms.Button cmd_enrollment;
        private System.Windows.Forms.Button cmd_pdf;
        private System.Windows.Forms.Button cmd_pop;
        private System.Windows.Forms.Button cmd_report;
        private System.Windows.Forms.TabPage tb_setting;
        private System.Windows.Forms.TextBox txt_conString;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown txt_iterations;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar pb_course;
        private System.Windows.Forms.NumericUpDown txt_crossoverrate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Console;
        private System.Windows.Forms.NumericUpDown txt_cross_times;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown txt_Mutation;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown txt_mutrate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button cmd_viewTT;
        private System.Windows.Forms.TextBox txt_tt;
        private System.Windows.Forms.Button cmd_impTT;
        private System.Windows.Forms.Button cmd_tt;
    }
}


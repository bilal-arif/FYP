namespace Scheduler
{
    partial class frm_Schedule
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.schedulerDataSet2 = new Scheduler.SchedulerDataSet();
            this.schedule_tableTableAdapter1 = new Scheduler.SchedulerDataSetTableAdapters.Schedule_tableTableAdapter();
            this.cmd_GenXL = new System.Windows.Forms.Button();
            this.cmd_edit = new System.Windows.Forms.Button();
            this.cmd_regen = new System.Windows.Forms.Button();
            this.cmd_genpdf = new System.Windows.Forms.Button();
            this.lst_schedule = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_status = new System.Windows.Forms.Label();
            this.lbl_fitness = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Schedule_table";
            this.bindingSource1.DataSource = this.schedulerDataSet2;
            // 
            // schedulerDataSet2
            // 
            this.schedulerDataSet2.DataSetName = "SchedulerDataSet";
            this.schedulerDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // schedule_tableTableAdapter1
            // 
            this.schedule_tableTableAdapter1.ClearBeforeFill = true;
            // 
            // cmd_GenXL
            // 
            this.cmd_GenXL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cmd_GenXL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_GenXL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_GenXL.Location = new System.Drawing.Point(169, 472);
            this.cmd_GenXL.Name = "cmd_GenXL";
            this.cmd_GenXL.Size = new System.Drawing.Size(151, 41);
            this.cmd_GenXL.TabIndex = 1;
            this.cmd_GenXL.Text = "Generate Excel Sheet";
            this.cmd_GenXL.UseVisualStyleBackColor = false;
            this.cmd_GenXL.Visible = false;
            // 
            // cmd_edit
            // 
            this.cmd_edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cmd_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_edit.Location = new System.Drawing.Point(327, 544);
            this.cmd_edit.Name = "cmd_edit";
            this.cmd_edit.Size = new System.Drawing.Size(151, 41);
            this.cmd_edit.TabIndex = 2;
            this.cmd_edit.Text = "Make Changes";
            this.cmd_edit.UseVisualStyleBackColor = false;
            this.cmd_edit.Visible = false;
            this.cmd_edit.Click += new System.EventHandler(this.cmd_edit_Click);
            // 
            // cmd_regen
            // 
            this.cmd_regen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cmd_regen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_regen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_regen.Location = new System.Drawing.Point(170, 544);
            this.cmd_regen.Name = "cmd_regen";
            this.cmd_regen.Size = new System.Drawing.Size(151, 41);
            this.cmd_regen.TabIndex = 3;
            this.cmd_regen.Text = "ReGenerate";
            this.cmd_regen.UseVisualStyleBackColor = false;
            this.cmd_regen.Visible = false;
            this.cmd_regen.Click += new System.EventHandler(this.cmd_regen_Click);
            // 
            // cmd_genpdf
            // 
            this.cmd_genpdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cmd_genpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_genpdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_genpdf.Location = new System.Drawing.Point(751, 370);
            this.cmd_genpdf.Name = "cmd_genpdf";
            this.cmd_genpdf.Size = new System.Drawing.Size(151, 57);
            this.cmd_genpdf.TabIndex = 4;
            this.cmd_genpdf.Text = "Generate Report";
            this.cmd_genpdf.UseVisualStyleBackColor = false;
            this.cmd_genpdf.Click += new System.EventHandler(this.cmd_genpdf_Click);
            // 
            // lst_schedule
            // 
            this.lst_schedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lst_schedule.GridLines = true;
            this.lst_schedule.Location = new System.Drawing.Point(13, 13);
            this.lst_schedule.Name = "lst_schedule";
            this.lst_schedule.Size = new System.Drawing.Size(889, 351);
            this.lst_schedule.TabIndex = 5;
            this.lst_schedule.UseCompatibleStateImageBehavior = false;
            this.lst_schedule.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Timings";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Course Name";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Course Code";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Room";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Section Code";
            this.columnHeader6.Width = 82;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Teacher";
            this.columnHeader7.Width = 200;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(27, 378);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(0, 13);
            this.lbl_status.TabIndex = 6;
            // 
            // lbl_fitness
            // 
            this.lbl_fitness.AutoSize = true;
            this.lbl_fitness.Location = new System.Drawing.Point(46, 390);
            this.lbl_fitness.Name = "lbl_fitness";
            this.lbl_fitness.Size = new System.Drawing.Size(52, 13);
            this.lbl_fitness.TabIndex = 7;
            this.lbl_fitness.Text = "FITNESS";
            this.lbl_fitness.Visible = false;
            // 
            // frm_Schedule
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(934, 448);
            this.Controls.Add(this.lbl_fitness);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.lst_schedule);
            this.Controls.Add(this.cmd_genpdf);
            this.Controls.Add(this.cmd_regen);
            this.Controls.Add(this.cmd_edit);
            this.Controls.Add(this.cmd_GenXL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_Schedule";
            this.Text = "Schedule";
            this.Load += new System.EventHandler(this.Schedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource schedulerDataSetBindingSource;
        private SchedulerDataSet schedulerDataSet;
        private System.Windows.Forms.BindingSource courseBindingSource;
        private SchedulerDataSetTableAdapters.CourseTableAdapter courseTableAdapter;
        private System.Windows.Forms.BindingSource scheduleBindingSource;
        private SchedulerDataSetTableAdapters.ScheduleTableAdapter scheduleTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource scheduletableBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timingsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectioncodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomDataGridViewTextBoxColumn;
        private SchedulerDataSet schedulerDataSet2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private SchedulerDataSetTableAdapters.Schedule_tableTableAdapter schedule_tableTableAdapter1;
        private System.Windows.Forms.Button cmd_GenXL;
        private System.Windows.Forms.Button cmd_edit;
        private System.Windows.Forms.Button cmd_regen;
        private System.Windows.Forms.Button cmd_genpdf;
        private System.Windows.Forms.ListView lst_schedule;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label lbl_fitness;

    }
}
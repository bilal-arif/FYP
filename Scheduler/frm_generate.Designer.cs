namespace Scheduler
{
    partial class frm_generate
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmd_gennew = new System.Windows.Forms.Button();
            this.cmd_useold = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scheduled Exams Found !";
            // 
            // cmd_gennew
            // 
            this.cmd_gennew.Location = new System.Drawing.Point(17, 105);
            this.cmd_gennew.Name = "cmd_gennew";
            this.cmd_gennew.Size = new System.Drawing.Size(259, 23);
            this.cmd_gennew.TabIndex = 1;
            this.cmd_gennew.Text = "Generate New";
            this.cmd_gennew.UseVisualStyleBackColor = true;
            this.cmd_gennew.Click += new System.EventHandler(this.cmd_gennew_Click);
            // 
            // cmd_useold
            // 
            this.cmd_useold.Location = new System.Drawing.Point(17, 135);
            this.cmd_useold.Name = "cmd_useold";
            this.cmd_useold.Size = new System.Drawing.Size(259, 23);
            this.cmd_useold.TabIndex = 2;
            this.cmd_useold.Text = "View Existing";
            this.cmd_useold.UseVisualStyleBackColor = true;
            this.cmd_useold.Click += new System.EventHandler(this.cmd_useold_Click);
            // 
            // frm_generate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 327);
            this.Controls.Add(this.cmd_useold);
            this.Controls.Add(this.cmd_gennew);
            this.Controls.Add(this.label1);
            this.Name = "frm_generate";
            this.Text = "frm_generate";
            this.Load += new System.EventHandler(this.frm_generate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmd_gennew;
        private System.Windows.Forms.Button cmd_useold;
    }
}
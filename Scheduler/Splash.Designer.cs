namespace Scheduler
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.BackColor = System.Drawing.Color.Transparent;
            this.lbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl.Location = new System.Drawing.Point(99, 149);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(52, 13);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "dsadsfsdf";
            this.lbl.UseWaitCursor = true;
            this.lbl.Visible = false;
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pb.ForeColor = System.Drawing.Color.Red;
            this.pb.Location = new System.Drawing.Point(0, 329);
            this.pb.MarqueeAnimationSpeed = 1;
            this.pb.Maximum = 20;
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(608, 10);
            this.pb.Step = 500;
            this.pb.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb.TabIndex = 2;
            this.pb.UseWaitCursor = true;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(608, 339);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.lbl);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.TopMost = true;
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Splash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl;
        public System.Windows.Forms.ProgressBar pb;
    }
}
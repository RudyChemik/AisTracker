namespace WinFormsApp2
{
    partial class ShipNavigation
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
            this.CloseApp = new System.Windows.Forms.Label();
            this.minimalizeApp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.circularCourseSelector1 = new WinFormsApp2.CircularCourseSelector();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseApp
            // 
            this.CloseApp.AutoSize = true;
            this.CloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseApp.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloseApp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CloseApp.Location = new System.Drawing.Point(423, 9);
            this.CloseApp.Name = "CloseApp";
            this.CloseApp.Size = new System.Drawing.Size(27, 25);
            this.CloseApp.TabIndex = 4;
            this.CloseApp.Text = "X";
            this.CloseApp.Click += new System.EventHandler(this.CloseApp_Click);
            // 
            // minimalizeApp
            // 
            this.minimalizeApp.AutoSize = true;
            this.minimalizeApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimalizeApp.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minimalizeApp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.minimalizeApp.Location = new System.Drawing.Point(402, 9);
            this.minimalizeApp.Name = "minimalizeApp";
            this.minimalizeApp.Size = new System.Drawing.Size(24, 25);
            this.minimalizeApp.TabIndex = 5;
            this.minimalizeApp.Text = "_";
            this.minimalizeApp.Click += new System.EventHandler(this.minimalizeApp_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(367, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "SPEED:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "COURSE:";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(381, 101);
            this.trackBar1.Maximum = 25;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 315);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Value = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(370, 419);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "1 / 25";
            // 
            // circularCourseSelector1
            // 
            this.circularCourseSelector1.BackColor = System.Drawing.Color.Black;
            this.circularCourseSelector1.Course = 0;
            this.circularCourseSelector1.ForeColor = System.Drawing.Color.White;
            this.circularCourseSelector1.Location = new System.Drawing.Point(12, 101);
            this.circularCourseSelector1.Name = "circularCourseSelector1";
            this.circularCourseSelector1.Size = new System.Drawing.Size(327, 325);
            this.circularCourseSelector1.TabIndex = 9;
            this.circularCourseSelector1.Text = "circularCourseSelector1";
            this.circularCourseSelector1.CourseChanged += new System.EventHandler(this.circularCourseSelector1_CourseChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(147, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "0 *";
            // 
            // ShipNavigation
            // 



            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(462, 460);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.circularCourseSelector1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minimalizeApp);
            this.Controls.Add(this.CloseApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShipNavigation";
            this.Text = "ShipNavigation";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label CloseApp;
        private Label minimalizeApp;
        private Label label1;
        private Label label2;
        private TrackBar trackBar1;
        private Label label3;
        private CircularCourseSelector circularCourseSelector1;
        private Label label4;
    }
}
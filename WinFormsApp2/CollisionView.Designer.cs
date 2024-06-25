namespace WinFormsApp2
{
    partial class CollisionView
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
            this.CloseApp = new System.Windows.Forms.Label();
            this.minimalizeApp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.courseChangerManuall = new System.Windows.Forms.Button();
            this.courseChanger = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Helvetica", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(73, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(648, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "WYKRYTO KOLIZJE";
            // 
            // CloseApp
            // 
            this.CloseApp.AutoSize = true;
            this.CloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseApp.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloseApp.ForeColor = System.Drawing.Color.Black;
            this.CloseApp.Location = new System.Drawing.Point(774, 9);
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
            this.minimalizeApp.ForeColor = System.Drawing.Color.Black;
            this.minimalizeApp.Location = new System.Drawing.Point(744, 9);
            this.minimalizeApp.Name = "minimalizeApp";
            this.minimalizeApp.Size = new System.Drawing.Size(24, 25);
            this.minimalizeApp.TabIndex = 5;
            this.minimalizeApp.Text = "_";
            this.minimalizeApp.Click += new System.EventHandler(this.minimalizeApp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 50);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kurs kolizyjny z:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 50);
            this.label3.TabIndex = 7;
            this.label3.Text = "Czas do kolizji:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 50);
            this.label4.TabIndex = 8;
            this.label4.Text = "Miejsce kolizji:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Helvetica", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(311, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 42);
            this.label5.TabIndex = 9;
            this.label5.Text = "{data bind}";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Helvetica", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(311, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 42);
            this.label6.TabIndex = 10;
            this.label6.Text = "{data bind}";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Helvetica", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(311, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 42);
            this.label7.TabIndex = 11;
            this.label7.Text = "{data bind}";
            // 
            // courseChangerManuall
            // 
            this.courseChangerManuall.BackColor = System.Drawing.Color.Black;
            this.courseChangerManuall.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.courseChangerManuall.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.courseChangerManuall.Location = new System.Drawing.Point(73, 348);
            this.courseChangerManuall.Name = "courseChangerManuall";
            this.courseChangerManuall.Size = new System.Drawing.Size(220, 68);
            this.courseChangerManuall.TabIndex = 12;
            this.courseChangerManuall.Text = "Change course manually";
            this.courseChangerManuall.UseVisualStyleBackColor = false;
            this.courseChangerManuall.Click += new System.EventHandler(this.courseChangerManuall_Click);
            // 
            // courseChanger
            // 
            this.courseChanger.BackColor = System.Drawing.Color.Black;
            this.courseChanger.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.courseChanger.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.courseChanger.Location = new System.Drawing.Point(501, 348);
            this.courseChanger.Name = "courseChanger";
            this.courseChanger.Size = new System.Drawing.Size(220, 68);
            this.courseChanger.TabIndex = 13;
            this.courseChanger.Text = "Change course";
            this.courseChanger.UseVisualStyleBackColor = false;
            this.courseChanger.Click += new System.EventHandler(this.courseChanger_Click);
            // 
            // CollisionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(813, 450);
            this.Controls.Add(this.courseChanger);
            this.Controls.Add(this.courseChangerManuall);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.minimalizeApp);
            this.Controls.Add(this.CloseApp);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CollisionView";
            this.Text = "CollisionView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label CloseApp;
        private Label minimalizeApp;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button courseChangerManuall;
        private Button courseChanger;
    }
}
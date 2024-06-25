namespace WinFormsApp2
{
    partial class History
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
            this.SuspendLayout();
            // 
            // CloseApp
            // 
            this.CloseApp.AutoSize = true;
            this.CloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseApp.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloseApp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CloseApp.Location = new System.Drawing.Point(1233, 9);
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
            this.minimalizeApp.Location = new System.Drawing.Point(1203, 9);
            this.minimalizeApp.Name = "minimalizeApp";
            this.minimalizeApp.Size = new System.Drawing.Size(24, 25);
            this.minimalizeApp.TabIndex = 5;
            this.minimalizeApp.Text = "_";
            this.minimalizeApp.Click += new System.EventHandler(this.minimalizeApp_Click);
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1272, 568);
            this.Controls.Add(this.minimalizeApp);
            this.Controls.Add(this.CloseApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "History";
            this.Text = "History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label CloseApp;
        private Label minimalizeApp;
    }
}
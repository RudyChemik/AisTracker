namespace WinFormsApp2
{
    partial class MainScreen
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
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.courseChange = new System.Windows.Forms.Button();
            this.historyPage = new System.Windows.Forms.Button();
            this.zoomOutMap = new System.Windows.Forms.Button();
            this.zoomInMap = new System.Windows.Forms.Button();
            this.mapCenter = new System.Windows.Forms.Button();
            this.CloseApp = new System.Windows.Forms.Label();
            this.minimalizeApp = new System.Windows.Forms.Label();
            this.mmsilabel = new System.Windows.Forms.Label();
            this.latlabel = new System.Windows.Forms.Label();
            this.longlabel = new System.Windows.Forms.Label();
            this.speedlabel = new System.Windows.Forms.Label();
            this.speedlabel2 = new System.Windows.Forms.Label();
            this.courselabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(251, 27);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(1029, 427);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.courseChange);
            this.panel1.Controls.Add(this.historyPage);
            this.panel1.Controls.Add(this.zoomOutMap);
            this.panel1.Controls.Add(this.zoomInMap);
            this.panel1.Controls.Add(this.mapCenter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 460);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1292, 121);
            this.panel1.TabIndex = 1;
            // 
            // courseChange
            // 
            this.courseChange.BackColor = System.Drawing.Color.Black;
            this.courseChange.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.courseChange.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.courseChange.Location = new System.Drawing.Point(249, 16);
            this.courseChange.Name = "courseChange";
            this.courseChange.Size = new System.Drawing.Size(220, 68);
            this.courseChange.TabIndex = 4;
            this.courseChange.Text = "Change Course";
            this.courseChange.UseVisualStyleBackColor = false;
            this.courseChange.Click += new System.EventHandler(this.courseChange_Click);
            // 
            // historyPage
            // 
            this.historyPage.BackColor = System.Drawing.Color.Black;
            this.historyPage.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.historyPage.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.historyPage.Location = new System.Drawing.Point(10, 16);
            this.historyPage.Name = "historyPage";
            this.historyPage.Size = new System.Drawing.Size(220, 68);
            this.historyPage.TabIndex = 3;
            this.historyPage.Text = "History";
            this.historyPage.UseVisualStyleBackColor = false;
            this.historyPage.Click += new System.EventHandler(this.historyPage_Click);
            // 
            // zoomOutMap
            // 
            this.zoomOutMap.BackColor = System.Drawing.Color.Black;
            this.zoomOutMap.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.zoomOutMap.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.zoomOutMap.Location = new System.Drawing.Point(596, 16);
            this.zoomOutMap.Name = "zoomOutMap";
            this.zoomOutMap.Size = new System.Drawing.Size(220, 68);
            this.zoomOutMap.TabIndex = 2;
            this.zoomOutMap.Text = "Zoom out";
            this.zoomOutMap.UseVisualStyleBackColor = false;
            this.zoomOutMap.Click += new System.EventHandler(this.zoomOutMap_Click);
            // 
            // zoomInMap
            // 
            this.zoomInMap.BackColor = System.Drawing.Color.Black;
            this.zoomInMap.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.zoomInMap.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.zoomInMap.Location = new System.Drawing.Point(822, 16);
            this.zoomInMap.Name = "zoomInMap";
            this.zoomInMap.Size = new System.Drawing.Size(220, 68);
            this.zoomInMap.TabIndex = 1;
            this.zoomInMap.Text = "Zoom in";
            this.zoomInMap.UseVisualStyleBackColor = false;
            this.zoomInMap.Click += new System.EventHandler(this.zoomInMap_Click);
            // 
            // mapCenter
            // 
            this.mapCenter.BackColor = System.Drawing.Color.Black;
            this.mapCenter.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mapCenter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mapCenter.Location = new System.Drawing.Point(1048, 16);
            this.mapCenter.Name = "mapCenter";
            this.mapCenter.Size = new System.Drawing.Size(220, 68);
            this.mapCenter.TabIndex = 0;
            this.mapCenter.Text = "Center Map";
            this.mapCenter.UseVisualStyleBackColor = false;
            this.mapCenter.Click += new System.EventHandler(this.mapCenter_Click);
            // 
            // CloseApp
            // 
            this.CloseApp.AutoSize = true;
            this.CloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseApp.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloseApp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CloseApp.Location = new System.Drawing.Point(1265, -1);
            this.CloseApp.Name = "CloseApp";
            this.CloseApp.Size = new System.Drawing.Size(27, 25);
            this.CloseApp.TabIndex = 3;
            this.CloseApp.Text = "X";
            this.CloseApp.Click += new System.EventHandler(this.CloseApp_Click);
            // 
            // minimalizeApp
            // 
            this.minimalizeApp.AutoSize = true;
            this.minimalizeApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimalizeApp.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minimalizeApp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.minimalizeApp.Location = new System.Drawing.Point(1246, -1);
            this.minimalizeApp.Name = "minimalizeApp";
            this.minimalizeApp.Size = new System.Drawing.Size(24, 25);
            this.minimalizeApp.TabIndex = 4;
            this.minimalizeApp.Text = "_";
            this.minimalizeApp.Click += new System.EventHandler(this.minimalizeApp_Click);
            // 
            // mmsilabel
            // 
            this.mmsilabel.AutoSize = true;
            this.mmsilabel.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mmsilabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mmsilabel.Location = new System.Drawing.Point(12, 65);
            this.mmsilabel.Name = "mmsilabel";
            this.mmsilabel.Size = new System.Drawing.Size(0, 22);
            this.mmsilabel.TabIndex = 5;
            // 
            // latlabel
            // 
            this.latlabel.AutoSize = true;
            this.latlabel.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.latlabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.latlabel.Location = new System.Drawing.Point(12, 99);
            this.latlabel.Name = "latlabel";
            this.latlabel.Size = new System.Drawing.Size(0, 22);
            this.latlabel.TabIndex = 6;
            // 
            // longlabel
            // 
            this.longlabel.AutoSize = true;
            this.longlabel.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.longlabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.longlabel.Location = new System.Drawing.Point(12, 137);
            this.longlabel.Name = "longlabel";
            this.longlabel.Size = new System.Drawing.Size(0, 22);
            this.longlabel.TabIndex = 7;
            // 
            // speedlabel
            // 
            this.speedlabel.AutoSize = true;
            this.speedlabel.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.speedlabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.speedlabel.Location = new System.Drawing.Point(12, 173);
            this.speedlabel.Name = "speedlabel";
            this.speedlabel.Size = new System.Drawing.Size(0, 22);
            this.speedlabel.TabIndex = 8;
            // 
            // speedlabel2
            // 
            this.speedlabel2.AutoSize = true;
            this.speedlabel2.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.speedlabel2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.speedlabel2.Location = new System.Drawing.Point(12, 207);
            this.speedlabel2.Name = "speedlabel2";
            this.speedlabel2.Size = new System.Drawing.Size(0, 22);
            this.speedlabel2.TabIndex = 9;
            // 
            // courselabel
            // 
            this.courselabel.AutoSize = true;
            this.courselabel.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.courselabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.courselabel.Location = new System.Drawing.Point(12, 240);
            this.courselabel.Name = "courselabel";
            this.courselabel.Size = new System.Drawing.Size(0, 22);
            this.courselabel.TabIndex = 10;
            // 
            // MainScreen
            // 
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1292, 581);
            this.Controls.Add(this.courselabel);
            this.Controls.Add(this.speedlabel2);
            this.Controls.Add(this.speedlabel);
            this.Controls.Add(this.longlabel);
            this.Controls.Add(this.latlabel);
            this.Controls.Add(this.mmsilabel);
            this.Controls.Add(this.minimalizeApp);
            this.Controls.Add(this.CloseApp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gMapControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainScreen";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private Panel panel1;
        private Label CloseApp;
        private Label minimalizeApp;
        private Button mapCenter;
        private Button courseChange;
        private Button historyPage;
        private Button zoomOutMap;
        private Button zoomInMap;
        private Label mmsilabel;
        private Label latlabel;
        private Label longlabel;
        private Label speedlabel;
        private Label speedlabel2;
        private Label courselabel;
    }
}
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp2.Models.History;

namespace WinFormsApp2
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            GetHistoryData();
        }

        private void GetHistoryData()
        {
            List<Models.History.ShipTrip> shipTripList = new List<Models.History.ShipTrip>();

            ShipTrip shipTrip = new ShipTrip()
            {
                Name = "LODOŁAMACZ",
                Desc = "lamanie lodow",
                StartingLat = 53.936159837443874,
                StartingLong = 14.286524602076607,
                Id = 1,
            };

            ShipTrip shipTrip1 = new ShipTrip()
            {
                Name = "ex2",
                Desc = "aaa",
                StartingLat = 53.936159837443874,
                StartingLong = 14.286524602076607,
                Id = 2,
            };

            ShipTrip shipTrip2 = new ShipTrip()
            {
                Name = "ex3",
                Desc = "vvvv",
                StartingLat = 53.936159837443874,
                StartingLong = 14.286524602076607,
                Id = 3,
            };

            shipTripList.Add(shipTrip);
            shipTripList.Add(shipTrip1);
            shipTripList.Add(shipTrip2);

            int yPosition = 30;

            foreach (var trip in shipTripList)
            {
                Panel tripPanel = new Panel();
                tripPanel.Location = new Point(10, yPosition);
                tripPanel.Size = new Size(1200, 120);
                tripPanel.BorderStyle = BorderStyle.FixedSingle;
                tripPanel.BackColor = Color.Black;
                tripPanel.Tag = trip.Id;
                tripPanel.Click += TripPanel_Click;

                Label nameLabel = new Label();
                nameLabel.Text = "NAZWA: " + trip.Name;
                nameLabel.Location = new Point(5, 5);
                nameLabel.AutoSize = true;
                nameLabel.ForeColor = Color.White;
                nameLabel.Font = new Font("Helvetica", 12, FontStyle.Regular);
                nameLabel.Click += Label_Click;

                Label descLabel = new Label();
                descLabel.Text = "DESC: " + trip.Desc;
                descLabel.Location = new Point(5, 25);
                descLabel.AutoSize = true;
                descLabel.ForeColor = Color.White;
                descLabel.Font = new Font("Helvetica", 12, FontStyle.Regular);
                descLabel.Click += Label_Click;

                GMapControl mapControl = new GMapControl();
                mapControl.Size = new Size(280, 110);
                mapControl.Location = new Point(tripPanel.Width - mapControl.Width - 10, 5);
                mapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                mapControl.Position = new PointLatLng(trip.StartingLat, trip.StartingLong);
                mapControl.MinZoom = 2;
                mapControl.MaxZoom = 18;
                mapControl.Zoom = 10;
                mapControl.Manager.Mode = AccessMode.ServerOnly;
                mapControl.MarkersEnabled = true;

                GMapOverlay markersOverlay = new GMapOverlay("markers");
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(trip.StartingLat, trip.StartingLong), GMarkerGoogleType.red_dot);
                markersOverlay.Markers.Add(marker);
                mapControl.Overlays.Add(markersOverlay);

                tripPanel.Controls.Add(nameLabel);
                tripPanel.Controls.Add(descLabel);
                tripPanel.Controls.Add(mapControl);

                this.Controls.Add(tripPanel);

                yPosition += 150;
            }
        }

        private void TripPanel_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            int id = (int)clickedPanel.Tag;

            HistoryView historyView = new HistoryView(id);
            historyView.ShowDialog();
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            Panel parentPanel = clickedLabel.Parent as Panel;
            int id = (int)parentPanel.Tag;

            HistoryView historyView = new HistoryView(id);
            historyView.ShowDialog();
        }

        private void CloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimalizeApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

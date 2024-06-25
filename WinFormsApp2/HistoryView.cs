using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp2.Models.History;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Microsoft.VisualBasic.Devices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class HistoryView : Form
    {
        private ShipTrip shipTrip;
        private List<Models.History.History> histories = new List<Models.History.History>();
        private GMapOverlay routesOverlay;

        public HistoryView(int id)
        {
            InitializeComponent();
            InitializeMap();
            GetHistoryViewById(id);
            GeneratePosition();
        }

        private void InitializeMap()
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(53.936159837443874, 14.286524602076607);
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 10;
            gMapControl1.Dock = DockStyle.Fill;
            routesOverlay = new GMapOverlay("routes");
            gMapControl1.Overlays.Add(routesOverlay);
        }

        private void GetHistoryViewById(int id)
        {
            shipTrip = new ShipTrip()
            {
                Name = "LODOŁAMACZ",
                Desc = "lamanie lodow",
                StartingLat = 53.936159837443874,
                StartingLong = 14.286524602076607,
                Id = 1,
            };

            Models.History.History history = new Models.History.History()
            {
                Id = 1,
                Course = 0,
                shipTripId = 1,
                Speed = 25,
                MMSI = 200,
                Time = DateTime.Parse("2002-12-23T12:12:12")
            };

            Models.History.History history2 = new Models.History.History()
            {
                Id = 2,
                Course = 120,
                shipTripId = 1,
                Speed = 5,
                MMSI = 200,
                Time = DateTime.Parse("2002-12-23T13:12:12")
            };

            Models.History.History history3 = new Models.History.History()
            {
                Id = 3,
                Course = 240,
                shipTripId = 1,
                Speed = 25,
                MMSI = 200,
                Time = DateTime.Parse("2002-12-23T14:12:12")
            };

            Models.History.History history4 = new Models.History.History()
            {
                Id = 4,
                Course = 100,
                shipTripId = 1,
                Speed = 25,
                MMSI = 200,
                Time = DateTime.Parse("2002-12-23T15:12:12")
            };

            Models.History.History history5 = new Models.History.History()
            {
                Id = 4,
                Course = 100,
                shipTripId = 1,
                Speed = 10,
                MMSI = 200,
                Time = DateTime.Parse("2002-12-23T19:12:12")
            };

            histories.Add(history);
            histories.Add(history2);
            histories.Add(history3);
            histories.Add(history4);
            histories.Add(history5);
        }

        private void GeneratePosition()
        {
            PointLatLng startPoint = new PointLatLng(shipTrip.StartingLat, shipTrip.StartingLong);
            PointLatLng previousPoint = startPoint;

            foreach (var history in histories)
            {
                double distance = history.Speed * 1.852 / 60;
                double course = history.Course;

                double radCourse = (Math.PI / 180) * course;
                double newLat = previousPoint.Lat + (distance * Math.Cos(radCourse) / 110.574);
                double newLng = previousPoint.Lng + (distance * Math.Sin(radCourse) / (111.320 * Math.Cos(previousPoint.Lat * Math.PI / 180)));

                PointLatLng newPoint = new PointLatLng(newLat, newLng);

                List<PointLatLng> points = new List<PointLatLng> { previousPoint, newPoint };
                GMapRoute route = new GMapRoute(points, "route");
                route.Stroke = new Pen(Color.Black, 3);
                routesOverlay.Routes.Add(route);

                previousPoint = newPoint;
            }

            gMapControl1.Refresh();
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

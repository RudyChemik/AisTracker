using GMap.NET.WindowsForms.Markers;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2.Generator;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using WinFormsApp2.Decoder;
using WinFormsApp2.Models.AisCommunicates;
using Timer = System.Windows.Forms.Timer;
using WinFormsApp2.Models.Navigation;
using WinFormsApp2.Detector;
using System.Globalization;
using System.Text.RegularExpressions;
using WinFormsApp2.Models.History;
using Newtonsoft.Json;
using WinFormsApp2.Helpers;
using System.Text;
using WinFormsApp2.Models.Errors;

namespace WinFormsApp2
{
    public partial class MainScreen : Form
    {
        private GMapOverlay markersOverlay;
        private GMapOverlay linesOverlay;
        private Dictionary<int, GMarkerGoogle> markersByMMSI;
        private Dictionary<int, GMapRoute> predictionLinesByMMSI;

        private Bitmap ownShipImage;
        private Bitmap otherShipImage;

        private AisDecoder aisDecoder;
        private RandomShipGenerator randomGenerator;
        private OwnShipGenerator ownShipGenerator;
        private AisEncoder aisEncoder;
        private SimulateMovement simulateMovement;
        private List<string> aisMessages;

        //navs
        private List<CourseChange> courseChanges;
        private List<CourseChange> courseChangeHistory;
        private (double lat, double longg, DateTime startingTime) ownShipStartingPos;

        //pred
        private CollisionDetector colisionDetector;
        private Timer collisionTimer;

        private Helpers.Helpers helpers;

        public MainScreen()
        {
            InitializeComponent();
            InitializeMap();

            aisDecoder = new AisDecoder();
            aisEncoder = new AisEncoder();

            randomGenerator = new RandomShipGenerator();
            ownShipGenerator = new OwnShipGenerator();

            aisMessages = new List<string>();
            markersByMMSI = new Dictionary<int, GMarkerGoogle>();
            predictionLinesByMMSI = new Dictionary<int, GMapRoute>();

            //navs
            courseChanges = new List<CourseChange>();
            courseChangeHistory = new List<CourseChange>();

            colisionDetector = new CollisionDetector();

            helpers = new Helpers.Helpers();

            LoadMarkerImages();

            GenerateShips();
            StartSimulation();
            StartCollisionPrediction();
        }

        private void LoadMarkerImages()
        {
            try
            {
                ownShipImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ComponentsStyles", "Images", "gmapIcon2.png"));
                otherShipImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ComponentsStyles", "Images", "gmapIcon.png"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeMap()
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(54.558501920640374, 14.656045264635651);
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 7;
            gMapControl1.ShowCenter = false;
            gMapControl1.CanDragMap = true;

            markersOverlay = new GMapOverlay("markers");
            linesOverlay = new GMapOverlay("lines");
            gMapControl1.Overlays.Add(markersOverlay);
            gMapControl1.Overlays.Add(linesOverlay);
        }

        private void StartCollisionPrediction()
        {
            collisionTimer = new Timer();
            collisionTimer.Interval = 10000;
            collisionTimer.Tick += (sender, e) => PredictCollisions();
            collisionTimer.Start();
        }

        private void PredictCollisions()
        {
            if (aisMessages != null && aisMessages.Count() > 0)
            {
                var collision = colisionDetector.PredictCollision(aisMessages, 300, 10);
                if (collision != null)
                {
                    //SHOW COLLISION ON MAP AS BUFFOR FIELD! //todo

                    CollisionView collisionView = new CollisionView(collision);
                    collisionView.FormClosing += new FormClosingEventHandler(collisionView_FormClosing);
                    collisionView.ShowDialog();

                }
            }
        }

        private void collisionView_FormClosing(object sender, FormClosingEventArgs e)
        {
            CollisionView collisionView = sender as CollisionView;
            if (collisionView != null)
            {
                if (collisionView.Manual)
                {
                    courseChange_Click(this, EventArgs.Empty);
                }
                else if (collisionView.Automatic)
                {
                    //course changer automatic algo refff
                }
            }
        }



        private void GenerateShips()
        {
            var generated = randomGenerator.GenerateRandomShips(12);
            var ownShip = ownShipGenerator.GenerateOwnShip(200000000);

            if (!ownShip.error.Success)
            {
                MessageBox.Show(ownShip.error.ErrorMessage);
                return;
            }

            generated.res.Add(ownShip.res);

            var res = aisEncoder.EncodeAisData(generated.res);
            if (!res.error.Success)
            {
                MessageBox.Show(res.error.ErrorMessage);
                return;
            }

            if (res.res != null)
            {
                aisMessages = res.res.ToList();
                foreach (var msg in aisMessages)
                {
                    var decoded = aisDecoder.DecodeAisMessage(msg);
                    AddOrUpdateMarker(decoded);
                    AddOrUpdatePredictionLine(decoded);
                }
            }

            simulateMovement = new SimulateMovement(aisMessages, aisDecoder, aisEncoder, courseChanges);
        }

        private void StartSimulation()
        {
            if (simulateMovement == null)
            {
                simulateMovement = new SimulateMovement(aisMessages, aisDecoder, aisEncoder, courseChanges);
            }

            Timer simulationTimer = new Timer();
            simulationTimer.Interval = 5000;
            simulationTimer.Tick += (sender, e) =>
            {
                var res = simulateMovement.Simulate();
                List<string> updatedMessages = res.res;

                if (updatedMessages != null && updatedMessages.Any())
                {
                    aisMessages = updatedMessages;

                    if (res.changed)
                    {
                        courseChangeHistory.AddRange(courseChanges);
                        courseChanges.Clear();
                    }

                    UpdateMapMarkersAndPredictionLines(updatedMessages);
                }
                else
                {
                    Console.WriteLine("error");
                }
            };
            simulationTimer.Start();
        }

        private void UpdateMapMarkersAndPredictionLines(List<string> updatedMessages)
        {
            foreach (var msg in updatedMessages)
            {
                var decoded = aisDecoder.DecodeAisMessage(msg);
                AddOrUpdateMarker(decoded);
                AddOrUpdatePredictionLine(decoded);
                ChangeDisplayedData(decoded);
            }
            gMapControl1.Refresh();
        }

        public void AddOrUpdateMarker(AisDecoded shipData)
        {
            int mmsi = shipData.mmsi;
            double latitude = shipData.lat;
            double longitude = shipData.longg;

            if (markersByMMSI.ContainsKey(mmsi))
            {

                var marker = markersByMMSI[mmsi];
                marker.Position = new PointLatLng(latitude, longitude);
                marker.ToolTipText = $"MMSI: {mmsi}\nSpeed: {shipData.sog} knots\nStatus: {shipData.stat}\nLONG: {shipData.longg}\nLAT: {shipData.lat}";
            }
            else
            {
                GMarkerGoogle marker;
                if (shipData.mmsi == 200000000) //OWN SHIP ID FIXED
                {
                    var ownPoint = new PointLatLng(latitude, longitude);
                    marker = new GMarkerGoogle(ownPoint, ownShipImage)
                    {
                        ToolTipText = $"MMSI: {mmsi}\nSpeed: {shipData.sog} knots\nStatus: {shipData.stat}\nLONG: {shipData.longg}\nLAT: {shipData.lat}"
                    };
                }
                else
                {
                    var point = new PointLatLng(latitude, longitude);
                    marker = new GMarkerGoogle(point, otherShipImage)
                    {
                        ToolTipText = $"MMSI: {mmsi}\nSpeed: {shipData.sog} knots\nStatus: {shipData.stat}\nLONG: {shipData.longg}\nLAT: {shipData.lat}"
                    };

                }

                markersOverlay.Markers.Add(marker);
                markersByMMSI[mmsi] = marker;
            }
        }

        private void AddOrUpdatePredictionLine(AisDecoded shipData)
        {
            if (simulateMovement == null)
            {
                return;
            }

            int mmsi = shipData.mmsi;

            var futurePositions = simulateMovement.PredictFuturePositions(shipData, 10000); 

            if (predictionLinesByMMSI.ContainsKey(mmsi))
            {
                var route = predictionLinesByMMSI[mmsi];
                route.Points.Clear();
                route.Points.AddRange(futurePositions);
            }
            else
            {
                var route = new GMapRoute(futurePositions, $"Prediction_{mmsi}")
                {
                    Stroke = new Pen(Color.DarkRed, 1)
                };
                linesOverlay.Routes.Add(route);
                predictionLinesByMMSI[mmsi] = route;
            }
        }

        private async void CloseApp_Click(object sender, EventArgs e)
        {
            string res = GenerateShipDataJson(courseChangeHistory, ownShipStartingPos);

            bool connection = await helpers.IsInternetAvailable();
            if (!connection)
            {
                DialogResult result = MessageBox.Show(
                    "Brak połączenia z internetem.\nJeśli zamkniesz aplikację kurs nie zostanie zapisany.\nCzy chcesz zamknąć aplikację bez zapisywania?",
                    "Brak połączenia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {                    
                    return;
                }
                else
                {
                    Application.Exit();
                    return;
                }
            }

            if (res != null)
            {
                var postRes = await PostShipData(res);            
                if(!postRes.Success)
                {
                    MessageBox.Show(postRes.ErrorMessage);
                    return;
                }
            }

            Application.Exit();
        }

        private void minimalizeApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void mapCenter_Click(object sender, EventArgs e)
        {
            try
            {
                var convertableLat = latlabel.Text.Split(':');
                var convertableLong = longlabel.Text.Split(":");

                double lattt = double.Parse(convertableLat[1]);
                double longg = double.Parse(convertableLong[1]);

                gMapControl1.Position = new GMap.NET.PointLatLng(lattt, longg);
                gMapControl1.Zoom = 12;

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void zoomInMap_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom += 1;
        }

        private void zoomOutMap_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom -= 1;
        }

        private void historyPage_Click(object sender, EventArgs e)
        {
            History hisPage = new History();
            hisPage.ShowDialog();
        }

        private void courseChange_Click(object sender, EventArgs e)
        {
            ShipNavigation shipNavigation = new ShipNavigation();
            shipNavigation.FormClosing += new FormClosingEventHandler(shipNavigation_FormClosing);
            shipNavigation.ShowDialog();
        }

        private void shipNavigation_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShipNavigation shipNavigation = sender as ShipNavigation;
            if (shipNavigation != null)
            {
                int course = shipNavigation.Course;
                int speed = shipNavigation.Speed;

                CourseChange courseChange = new CourseChange()
                {
                    Course = course,
                    Speed = speed,
                    timeChanged = DateTime.Now
                };

                courseChanges.Add(courseChange);
            }
        }

        private void ChangeDisplayedData(AisDecoded shipData)
        {
            if(shipData != null)
            {
                mmsilabel.Text = "MMSI: " + shipData.mmsi.ToString();
                latlabel.Text = "Lat: " + shipData.lat.ToString();
                longlabel.Text = "Long: " + shipData.longg.ToString();
                speedlabel.Text = "Speed: " + shipData.sog.ToString() + " knots ";
                speedlabel2.Text = "Speed: " + (shipData.sog * 1.852).ToString("F2") + " km/h ";
                courselabel.Text = "Course: " + shipData.cog.ToString() + " * ";
            }
        }

        private string? GenerateShipDataJson(List<CourseChange> courseChangeHistory, (double lat, double longg, DateTime startingTime) ownShipStartingPos)
        {
            try
            {
                if (ownShipStartingPos.lat != 0 && ownShipStartingPos.longg != 0)
                {
                    List<Models.History.History> historyChange = new List<Models.History.History>();
                    ShipTrip shipTrip = new ShipTrip()
                    {
                        StartingLat = ownShipStartingPos.lat,
                        StartingLong = ownShipStartingPos.longg,
                        StartingTime = ownShipStartingPos.startingTime,
                        Desc = "symulowana wyvieczka",
                        Name = "name",
                    };

                    foreach(var change in courseChangeHistory)
                    {
                        Models.History.History historyEntity = new Models.History.History()
                        {
                            Course= change.Course,
                            Speed= change.Speed,
                            MMSI = change.MMSI,
                            Time = change.timeChanged
                        };
                        historyChange.Add(historyEntity);
                    }
                    shipTrip.histories = historyChange;

                    string json = JsonConvert.SerializeObject(shipTrip);
                    return json;
                }
                return null;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
        }

        private static async Task<BasicErrorResponse> PostShipData(string json)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://your-api-endpoint.com/api/Trips/saveCurrentTrip", content);

                if (response.IsSuccessStatusCode)
                {
                    return new BasicErrorResponse() { Success = true };
                }
                else
                {
                    return new BasicErrorResponse() { Success = false, ErrorMessage = response.RequestMessage.ToString()??"error saving" };
                }
            }
        }

    }
}

using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using Newtonsoft.Json;
using System.Text;
using WinFormsApp2.JSON.User;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //this is only an example of how would login httpost look like
        //there is no point of creating ext. api for this application since it would only have 2 endpoints :)
        private async void button1_Click_httpostExample(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            var loginData = new Login
            {
                Username = username,
                Password = password
            };

            string json = JsonConvert.SerializeObject(loginData);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = "https://EXXXX.com/api/account/login";

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MainScreen mainScreen = new MainScreen();
                        mainScreen.Show();
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        MessageBox.Show(responseContent??"Faileddd");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
        }


    }
}
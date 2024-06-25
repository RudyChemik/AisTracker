using System;
using System.Windows.Forms;
using WinFormsApp2.Detector;

namespace WinFormsApp2
{
    public partial class CollisionView : Form
    {
        public bool Manual { get; private set; }
        public bool Automatic { get; private set; }

        private CollisionVMO collisionData;
        private System.Windows.Forms.Timer countdownTimer;
        private TimeSpan timeRemaining;

        public CollisionView(CollisionVMO collision)
        {
            InitializeComponent();
            collisionData = collision;
            timeRemaining = collisionData.TimeToCollision - DateTime.Now;
            InitializeTimer();
            UpdateComponent();
        }

        private void InitializeTimer()
        {
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            timeRemaining = collisionData.TimeToCollision - DateTime.Now;
            if (timeRemaining.TotalSeconds <= 0)
            {
                label6.Text = "ship sunk ;c !";
                countdownTimer.Stop();
            }
            else
            {
                label6.Text = timeRemaining.ToString(@"hh\:mm\:ss");
            }
        }

        private void UpdateComponent()
        {
            if (collisionData != null)
            {
                label5.Text = collisionData.CollisionShipMMSI.ToString();
                label7.Text = $"{collisionData.CollisionPointLat}, {collisionData.CollisionPointLong}";
                label6.Text = timeRemaining.ToString(@"hh\:mm\:ss");
            }
        }

        private void CloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimalizeApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void courseChangerManuall_Click(object sender, EventArgs e)
        {
            Manual = true;
            this.Close();
        }

        private void courseChanger_Click(object sender, EventArgs e)
        {
            Automatic = true;
            this.Close();
        }
    }
}

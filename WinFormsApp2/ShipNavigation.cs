using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class ShipNavigation : Form
    {
        public int Course { get; private set; }
        public int Speed { get; private set; }
        public ShipNavigation()
        {
            InitializeComponent();
        }

        private void CloseApp_Click(object sender, EventArgs e)
        {
            Course = circularCourseSelector1.Course;
            Speed = trackBar1.Value;

            this.Close();
        }

        private void minimalizeApp_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString() + " / 25";
        }

        private void circularCourseSelector1_CourseChanged(object sender, EventArgs e)
        {
            label4.Text = circularCourseSelector1.Course.ToString() + " ° ";
        }
    }
}

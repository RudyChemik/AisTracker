using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp2
{
    internal class CircularCourseSelector : Control
    {
        public event EventHandler CourseChanged;
        private int course;
        private const int radius = 100;
        private const int centerX = 150;
        private const int centerY = 150;

        public int Course
        {
            get { return course; }
            set
            {
                course = value;
                Invalidate();
                CourseChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public CircularCourseSelector()
        {
            this.Size = new Size(300, 300);
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawEllipse(Pens.White, centerX - radius, centerY - radius, 2 * radius, 2 * radius);

            double angle = Math.PI * course / 180.0;
            int x = centerX + (int)(radius * Math.Cos(angle - Math.PI / 2));
            int y = centerY + (int)(radius * Math.Sin(angle - Math.PI / 2));
            g.DrawLine(new Pen(Color.Red, 2), centerX, centerY, x, y);

            string courseText = course.ToString() + "°";
            SizeF textSize = g.MeasureString(courseText, this.Font);
            g.DrawString(courseText, this.Font, Brushes.White, centerX - textSize.Width / 2, centerY - textSize.Height / 2);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            SetCourseFromMouse(e.Location);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                SetCourseFromMouse(e.Location);
            }
        }

        private void SetCourseFromMouse(Point mouseLocation)
        {
            int dx = mouseLocation.X - centerX;
            int dy = mouseLocation.Y - centerY;
            double angle = Math.Atan2(dy, dx);
            int newCourse = (int)((angle * 180.0 / Math.PI) + 90);
            if (newCourse < 0) newCourse += 360;
            Course = newCourse;
        }
    }
}

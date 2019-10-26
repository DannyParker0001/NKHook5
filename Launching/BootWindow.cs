using NKHook5.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NKHook5
{
    public partial class BootWindow : Form
    {
        int prog = 0;
        Bitmap image = new Bitmap(Resources.Rainbow);
        public BootWindow()
        {
            InitializeComponent();
        }

        public void doClose()
        {
            this.Close();
        }

        public void setTopmost(bool topMost)
        {
            this.TopMost = topMost;
            if (topMost == true)
            {
                Focus();
            }
        }

        private void splash_load(object sender, EventArgs e)
        {
            Focus();
            Timer panRainbowTimer = new Timer();
            panRainbowTimer.Tick += (object s, EventArgs a) =>
            {
                pictureBox3.Refresh();
                prog-=10;
                if (prog < -image.Width+108)
                {
                    prog = 0;
                }
            };
            panRainbowTimer.Interval = 1;
            panRainbowTimer.Start();
            versionTag.Text = Version.tag;
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.preGameLoad();
        }

        public static Color Rainbow(float progress)
        {
            float div = (Math.Abs(progress % 1) * 6);
            int ascending = (int)((div % 1) * 255);
            int descending = 255 - ascending;

            switch ((int)div)
            {
                case 0:
                    return Color.FromArgb(255, 255, ascending, 0);
                case 1:
                    return Color.FromArgb(255, descending, 255, 0);
                case 2:
                    return Color.FromArgb(255, 0, 255, ascending);
                case 3:
                    return Color.FromArgb(255, 0, descending, 255);
                case 4:
                    return Color.FromArgb(255, ascending, 0, 255);
                default: // case 5:
                    return Color.FromArgb(255, 255, 0, descending);
            }
        }

        private void picturePaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
            g.DrawImage(image,prog,0, image.Width, image.Height);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

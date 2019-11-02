using Newtonsoft.Json;
using NKHook5.Properties;
using NKHook5.Settings;
using NKHook5.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NKHook5
{
    public partial class BootWindow : Form
    {
        int prog = 0;
        Bitmap image = new Bitmap(Resources.Rainbow);
        Font gameFont;
        Font gameFontSmall;
        private PrivateFontCollection fonts = new PrivateFontCollection();
        internal SettingsWindow settingsWindow;

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        public BootWindow()
        {
            InitializeComponent();
            /*
             * Get game font
             */
            byte[] fontData = Properties.Resources.Oetztype;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.Oetztype.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.Oetztype.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            gameFont = new Font(fonts.Families[0], 120.0F);
            gameFontSmall = new Font(fonts.Families[0], 20.0F);

            //Check for settings
            if (!new FileInfo(Environment.CurrentDirectory + "\\settings.json").Exists)
            {
                FileInfo settingsFile = new FileInfo(Environment.CurrentDirectory + "\\settings.json");
                settingsFile.Create().Close();
                File.WriteAllText(settingsFile.FullName, JsonConvert.SerializeObject(new HookSettings()));
            }

            //read settings
            string settings = File.ReadAllText(Environment.CurrentDirectory + "/settings.json");
            string themeName = JsonConvert.DeserializeObject<HookSettings>(settings).theme;
            string json = File.ReadAllText(Environment.CurrentDirectory + "/Themes/" + themeName + ".json");
            Theme theme=JsonConvert.DeserializeObject<Theme>(json);
            this.BackColor = theme.mainColor;
            this.nkhLabel.BackColor = theme.mainColor;
            this.statusLabel.BackColor = theme.mainColor;
            this.nkhLabel.ForeColor = theme.textColor;
            this.statusLabel.ForeColor = theme.textColor;
            this.closeButton.BackColor = theme.mainColor;
            this.settingsButton.ForeColor = theme.textColor;
            this.settingsButton.BackColor = theme.mainColor;
            this.launchButton.ForeColor = theme.textColor;
            this.launchButton.BackColor = theme.mainColor;
            this.discordButton.ForeColor = theme.textColor;
            this.discordButton.BackColor = theme.mainColor;
            this.versionTag.ForeColor = theme.textColor;
            this.versionTag.BackColor = theme.mainColor;
        }

        private void splash_load(object sender, EventArgs e)
        {
            Focus();
            Timer panRainbowTimer = new Timer();
            panRainbowTimer.Tick += (object s, EventArgs a) =>
            {
                pictureBox4.Refresh();
                pictureBox3.Refresh();
                pictureBox2.Refresh();
                prog -=20;
                if (prog < -image.Width+108)
                {
                    prog = 0;
                }
            };
            panRainbowTimer.Interval = 1;
            panRainbowTimer.Start();
            versionTag.Text = Version.tag;

            nkhLabel.Font = gameFont;
            statusLabel.Font = gameFontSmall;
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Launching...";
            if(settingsWindow!=null)
            {
                settingsWindow.Dispose();
            }
            statusLabel.Refresh();
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

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Opening settings...";
            if (settingsWindow == null || settingsWindow.IsDisposed)
            {
                settingsWindow = new SettingsWindow();
            }
            settingsWindow.Show();
        }

        private void DiscordButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/VADMF2M");
        }



        //Drag anywhere
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void doDrag(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

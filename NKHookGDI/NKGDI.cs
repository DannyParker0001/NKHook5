using Memory;
using NKHook5.API;
using NKHook5.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NKHook5.NKHookGDI
{
    internal partial class NKGDI : Form
    {
        public enum GWL
        {
            ExStyle = -20
        }
        public enum LWA
        {
            ColorKey = 0x1,
            Alpha = 0x2
        }
        public enum WS_EX
        {
            Transparent = 0x20,
            Layered = 0x80000
        }
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);
        [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);
        [DllImport("user32.dll", EntryPoint = "GetActiveWindow")]
        public static extern IntPtr GetActiveWindow();


        internal static NKGDI instance = null;
        Mem memlib;
        public NKGDI(Mem memlib)
        {
            InitializeComponent();
            this.memlib = memlib;
            this.TopMost = true;
            instance = this;
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font gameFont;

        private void NKGDI_Load(object sender, EventArgs e)
        {
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
            gameFont = new Font(fonts.Families[0], 24.0F);

            gdiTag.Font = gameFont;
            gdiTag.BackColor = Color.Transparent;

            //Other shit
            int wl = GetWindowLong(this.Handle, GWL.ExStyle);
            wl = wl | 0x80000 | 0x20;
            SetWindowLong(this.Handle, GWL.ExStyle, wl);
            System.Windows.Forms.Timer sizeTimer = new System.Windows.Forms.Timer();
            sizeTimer.Tick += (object sen, EventArgs arg) =>
            {
                this.Location = new Point(memlib.readInt("BTD5-Win.exe+80EC1C")+8, memlib.readInt("BTD5-Win.exe+80EC20")+31);
                this.Size = new Size(memlib.readInt("BTD5-Win.exe+80EC14"), memlib.readInt("BTD5-Win.exe+80EC18"));
            };
            sizeTimer.Interval = 1;
            sizeTimer.Start();

            System.Windows.Forms.Timer remBrand = new System.Windows.Forms.Timer();
            remBrand.Interval = 5000;
            remBrand.Tick += (object sen, EventArgs arg) =>
            {
                this.gdiTag.Hide();
                remBrand.Stop();
                remBrand.Dispose();
            };
            remBrand.Start();

            //Create an API instance!
            new GDI();

            notify("test");
        }

        internal void notify(string text)
        {
            System.Windows.Forms.Timer notifier = new System.Windows.Forms.Timer();
            int tickCount = 0;
            notifier.Tick += (object sen, EventArgs arg) =>
            {
                if (tickCount < 50)
                {
                    notifBox.Show();
                    notifText.Parent = notifBox;
                    notifText.Text = text;
                    notifText.Font = gameFont;
                    notifText.Location = notifBox.Location;
                    notifText.Size = notifBox.Size;
                    notifText.BringToFront();
                    notifText.Show();
                    tickCount++;
                }
                else
                {
                    notifText.Hide();
                    notifBox.Hide();
                    notifier.Stop();
                    notifier.Dispose();
                }
                
            };
            notifier.Start();
        }
        /*
        internal void addFormLayer(System.Windows.Forms.Control.ControlCollection controls)
        {
            foreach(Control con in controls)
            {
                con.Parent = this;
                addFormLayer(con.Controls);
                con.Visible = true;
                this.Controls.Add(con);
            }
        }
        */
    }
}

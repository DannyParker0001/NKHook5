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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NKHook5.NKHookGDI
{
    internal partial class NKGDI : Form
    {
        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = -20;

        private const int WS_BORDER = 0x00800000;
        private const int WS_EX_CLIENTEDGE = 0x00000200;

        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_NOREDRAW = 0x0008;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_FRAMECHANGED = 0x0020;
        private const uint SWP_SHOWWINDOW = 0x0040;
        private const uint SWP_HIDEWINDOW = 0x0080;
        private const uint SWP_NOCOPYBITS = 0x0100;
        private const uint SWP_NOOWNERZORDER = 0x0200;
        private const uint SWP_NOSENDCHANGING = 0x0400;

        // Win32 Functions
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowLong(IntPtr hWnd, int Index);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowLong(IntPtr hWnd, int Index, int Value);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
            int X, int Y, int cx, int cy, uint uFlags);
        private const int SB_HORZ = 0;
        private const int SB_VERT = 1;
        private const int SB_CTL = 2;
        private const int SB_BOTH = 3;
        [DllImport("user32.dll")]
        private static extern int ShowScrollBar(IntPtr hWnd, int wBar, int bShow);
        private const int WM_NCCALCSIZE = 0x83;

        protected override void WndProc(ref Message m)
        {
            if (client != null)
            {
                ShowScrollBar(client.Handle, SB_BOTH, 0 /*Hide the ScrollBars*/);
            }
            base.WndProc(ref m);
        }


        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        //Shit for making the overlay topmost only when the game is focused
        WinEventDelegate winChangeDel = null;
        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;
        public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            IntPtr handle = GetForegroundWindow();
            if(handle == this.Handle || handle == Game.gameProc.MainWindowHandle)
            {
                this.TopMost = true;
            }
            if(handle != client.Handle || handle != Game.gameProc.MainWindowHandle)
            {
                this.TopMost = false;
            }
        }


        MdiClient client = null;
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
            TransparencyKey = Color.FromArgb(255, 171, 171, 171);
            BackColor = TransparencyKey;
            byte[] fontData = Properties.Resources.Oetztype;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.Oetztype.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.Oetztype.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            gameFont = new Font(fonts.Families[0], 20.0F);

            gdiTag.Font = gameFont;
            gdiTag.BackColor = Color.Transparent;

            //Start MDI
            client = new MdiClient();
            Controls.Add(client);
            // Get styles using Win32 calls
            int style = GetWindowLong(client.Handle, GWL_STYLE);
            int exStyle = GetWindowLong(client.Handle, GWL_EXSTYLE);

            style &= ~WS_BORDER;
            exStyle &= ~WS_EX_CLIENTEDGE;

            //Hook window change event
            winChangeDel = new WinEventDelegate(WinEventProc);
            IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, winChangeDel, 0, 0, WINEVENT_OUTOFCONTEXT);

            //Set the form size equal to the game
            System.Windows.Forms.Timer sizeTimer = new System.Windows.Forms.Timer();
            sizeTimer.Tick += (object sen, EventArgs arg) =>
            {
                this.Location = new Point(memlib.readInt("BTD5-Win.exe+80EC1C")+8, memlib.readInt("BTD5-Win.exe+80EC20")+31);
                this.Size = new Size(memlib.readInt("BTD5-Win.exe+80EC14"), memlib.readInt("BTD5-Win.exe+80EC18"));
            };
            sizeTimer.Interval = 1;
            sizeTimer.Start();

            //Remove branding notif
            System.Windows.Forms.Timer remBrand = new System.Windows.Forms.Timer();
            remBrand.Interval = 5000;
            remBrand.Tick += (object sen, EventArgs arg) =>
            {
                this.gdiTag.Hide();
                remBrand.Stop();
                remBrand.Dispose();
            };
            remBrand.Start();

            // Set the styles using Win32 calls
            SetWindowLong(client.Handle, GWL_STYLE, style);
            SetWindowLong(client.Handle, GWL_EXSTYLE, exStyle);

            // Update the non-client area.
            SetWindowPos(client.Handle, IntPtr.Zero, 0, 0, 0, 0,
                SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER |
                SWP_NOOWNERZORDER | SWP_FRAMECHANGED);

            //Create an API instance!
            new GDI();

            notify("NKHook-GDI: overlay ready!");
            Focus();
            TopMost = true;
        }

        internal void showForm(Form child)
        {
            Focus();
            TopMost = true;
            child.MdiParent = this;
            child.Show();
        }

        internal void notify(string text)
        {
            Focus();
            TopMost = true;
            System.Windows.Forms.Timer notifier = new System.Windows.Forms.Timer();
            int tickCount = 0;
            notifier.Tick += (object sen, EventArgs arg) =>
            {
                if (tickCount < 50)
                {
                    notifBox.Show();
                    notifText.Parent = notifBox;
                    scalePanel(notifBox, text);
                    notifText.Text = spacify(text, (notifBox.Width/21));
                    notifText.Font = gameFont;
                    notifText.TextAlign = ContentAlignment.MiddleCenter;
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
        public void scalePanel(Panel scalable, string toFit)
        {
            int len = toFit.Length;
            int rightSide = scalable.Location.X + scalable.Width;
            double calc = (len * len) - (len * (len/2));
            if (calc < 420)
            {
                scalable.Width = 420;
            }
            else
            {
                scalable.Width = (int)calc;
            }
            scalable.Location = new Point(scalable.Location.X - (rightSide-this.Width), scalable.Location.Y);
        }
        public string spacify(string text, int limit)
        {
            string totalString = "";
            List<String> words = text.Split(' ').ToList();
            int currentLen = 0;
            foreach(string word in words)
            {
                int newLen = word.Length + currentLen;
                if (newLen > limit)
                {
                    totalString += Environment.NewLine+word;
                    currentLen = word.Length;
                }
                else
                {
                    totalString += " " + word;
                    currentLen = newLen;
                }
            }
            return totalString;
        }
    }
}

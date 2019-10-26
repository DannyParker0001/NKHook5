using Newtonsoft.Json;
using NKHook5.Settings;
using NKHook5.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NKHook5
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
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

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            string settings = File.ReadAllText(Environment.CurrentDirectory + "/settings.json");
            string themeName = JsonConvert.DeserializeObject<HookSettings>(settings).theme;
            string json = File.ReadAllText(Environment.CurrentDirectory + "/Themes/" + themeName + ".json");
            Theme theme = JsonConvert.DeserializeObject<Theme>(json);
            this.BackColor = theme.mainColor;
            this.selectThemeLabel.ForeColor = theme.textColor;
            this.selectThemeLabel.BackColor = theme.mainColor;
            this.themeListBox.BackColor = theme.mainColor;
            this.themeListBox.ForeColor = theme.textColor;

            foreach(FileInfo finfo in new DirectoryInfo(Environment.CurrentDirectory + "\\Themes").GetFiles())
            {
                this.themeListBox.Items.Add(finfo.Name.Replace(".json",""));
            }
        }

        private void ThemeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string settings = File.ReadAllText(Environment.CurrentDirectory + "/settings.json");
            HookSettings hookSettings = JsonConvert.DeserializeObject<HookSettings>(settings);
            hookSettings.theme = themeListBox.SelectedItem.ToString();
            File.WriteAllText(Environment.CurrentDirectory + "/settings.json", JsonConvert.SerializeObject(hookSettings));
            Program.resetForms();
        }
    }
}

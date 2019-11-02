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
            this.pluginLabel.ForeColor = theme.textColor;
            this.pluginLabel.BackColor = theme.mainColor;
            this.pluginList.BackColor = theme.mainColor;
            this.pluginList.ForeColor = theme.textColor;
            this.closeButton.BackColor = theme.mainColor;

            HookSettings hookSettings = JsonConvert.DeserializeObject<HookSettings>(settings);

            foreach (FileInfo finfo in new DirectoryInfo(Environment.CurrentDirectory + "\\Themes").GetFiles())
            {
                this.themeListBox.Items.Add(finfo.Name.Replace(".json",""));
            }
            foreach (FileInfo finfo in new DirectoryInfo(Environment.CurrentDirectory + "\\Plugins").GetFiles())
            {
                this.pluginList.Items.Add(finfo.Name);
            }
            foreach (ListViewItem chkd in pluginList.Items)
            {
                if (hookSettings.enabledPlugins.Contains(chkd.Text))
                {
                    chkd.Checked = true;
                }
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

        private void PluginList_ItemCheck(object sender, ItemCheckedEventArgs e)
        {
            string settings = File.ReadAllText(Environment.CurrentDirectory + "/settings.json");
            HookSettings hookSettings = JsonConvert.DeserializeObject<HookSettings>(settings);
            List<string> checks = new List<string>();
            foreach(ListViewItem chkd in pluginList.CheckedItems)
            {
                checks.Add(chkd.Text);
            }
            hookSettings.enabledPlugins = checks;
            File.WriteAllText(Environment.CurrentDirectory + "/settings.json", JsonConvert.SerializeObject(hookSettings));
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void themeSelectionChanged(object sender, EventArgs e)
        {
            string settings = File.ReadAllText(Environment.CurrentDirectory + "/settings.json");
            HookSettings hookSettings = JsonConvert.DeserializeObject<HookSettings>(settings);
            hookSettings.theme = themeListBox.SelectedItem.ToString();
            string newSettings = JsonConvert.SerializeObject(hookSettings);
            File.WriteAllText(Environment.CurrentDirectory + "/settings.json", newSettings);
            Program.resetForms();
        }
    }
}

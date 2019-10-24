using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NKHook5.BootGraphics
{
    public partial class BootWindow : Form
    {
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
        }
    }
}

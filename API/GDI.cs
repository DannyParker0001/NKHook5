using NKHook5.NKHookGDI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace NKHook5.API
{
    public class GDI
    {
        internal delegate void addFormLayerPassthrough(ControlCollection toAdd);
        internal static GDI instance = null;
        internal GDI()
        {
            GDI.instance = this;
        }
        public static GDI getApi()
        {
            return instance;
        }
    }
}

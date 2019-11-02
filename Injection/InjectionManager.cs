using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKHook5.Injection
{
    internal class InjectionManager
    {
        internal static InjectionManager manager = null;
        internal InjectionManager()
        {
            InjectionManager.manager = this;
        }
        internal void injectAll()
        {
            new UpgradeInjection().Inject();
        }
    }
}

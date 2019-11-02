using Memory;
using NKHook5.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKHook5.Injection
{
    internal class UpgradeInjection
    {
        Mem memlib = Program.memlib;
        internal UpgradeInjection(){}
        internal void Inject()
        {
            memlib.writeMemory("003352C0", "bytes", "55 8B EC 83 E4 F8 51 53 56 57 FF 05 00 71 9D 00 8B 7D 08 8B F1 8D 04 BD 00 00 00 00 89 BE 40 01 00 00 83 F8 08 73 07 FF 84 BE 38 01 00 00 0F B6 86 38 01 00 00 33 DB 8D 0C 80 0F B6 86 3C 01 00 00 03 C8 C7 86 40 01 00 00 00 00 00 00 B8 01 00 00 00 D3 E0 89 86 D8 00 00 00 8B 86 E4 00 00 00 2B 86 E0 00 00 00 C1 F8 02 85 C0 74 48 66 0F 1F 84 00 00 00 00 00 8B 8E E0 00 00 00 57 8B 0C 99 E8 7B FF FF FF 8B 86 E0 00 00 00 8B 8E BC 00 00 00 6A 00 FF 34 98 8B 89 A0 00 00 00 E8 1F CC F5 FF 8B 86 E4 00 00 00 43 2B 86 E0 00 00 00 C1 F8 02 3B D8 72 C1 5F 5E 5B 8B E5 5D C2 04 00 CC CC");
            Logger.Log("UpgradeInjection complete");
        }
    }
}

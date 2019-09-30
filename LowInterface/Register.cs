using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKHook5.LowInterface
{
    internal class Register
    {
        public int data = 0;
        public bool flag = false;
        internal Register(int data, bool flag)
        {
            this.data = data;
            this.flag = flag;
        }
        internal Register()
        {
        }
    }
}

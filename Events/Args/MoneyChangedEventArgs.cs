using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKHook5.Events.Args
{
    public class MoneyChangedEventArgs : EventArgs
    {
        private double oldMoney;
        private double newMoney;
        public MoneyChangedEventArgs(double oldMoney, double newMoney)
        {
            this.oldMoney = oldMoney;
            this.newMoney = newMoney;
        }
        public double getOldAmount()
        {
            return oldMoney;
        }
        public double getNewAmount()
        {
            return newMoney;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace М13_Task1
{
   
   

    public class DepositAccount : Account
    {
        public DepositAccount(string aFindex) : base(aFindex) { }


        /// <summary>
        /// положить сумму на счет
        /// </summary>
        /// <param name="amount">сумма</param>
        public override bool PutMoney(IClient other, float amount)
        {
            //Console.WriteLine("DepositAccount:" + this.GetType().ToString());
            if (this.Client == other)
            { return base.PutMoney(other, amount); }
            return false;

        }

        /// <summary>
        /// снять сумму со счета
        /// </summary>
        /// <param name="amount">сумма</param>
        public override bool GetMoney(IClient other, float amount)
        {
            if (this.Client == other) { return base.GetMoney(other, amount); }
            return false;

        }

        public override string ToString()
        {
            return $"Депозит: {AccountNumber} ({TimeCreate}, {TimeClose}): {Balance}";
        }
    }
}

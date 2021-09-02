using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBankPro
{
    internal class Current : Account
    {
        private string accountType;

        internal string AccountType
        {
            get { return this.accountType; }
            set { this.accountType = value; }
        }

        internal Current(int id, string name, OurDate openingDate, OurAddress address, double balance, string accountType) : base(id, name, openingDate, address, balance)
        {
            this.AccountType = accountType;
        }

        internal override bool Withdraw(double amount)
        {
            if (this.Balance - amount >= 500)
            {
                this.Balance -= amount;
                Console.WriteLine("Withdraw of {0} taka complete", amount);
                return true;
            }
            else
                Console.WriteLine("{0} is not enough. Insufficient Balance", amount);
            return false;
            //this.ShowInfo();
        }

        internal override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Current Account Type: {0}\n", this.AccountType);
        }
    }
}

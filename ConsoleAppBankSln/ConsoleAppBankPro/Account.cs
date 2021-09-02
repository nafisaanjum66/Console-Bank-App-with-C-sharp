using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBankPro
{
    internal struct OurDate
    {
        private byte day;
        private byte month;
        private ushort year;

        public OurDate(byte day, byte month, ushort year)
        {
            if (day > 0 && day <= 31 && month >= 0 && month < 13)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }
            else
            {
                this.day = 0;
                this.month = 0;
                this.year = 0;
            }
        }

        public void ShowDate()
        {
            Console.WriteLine("Account Opening Date: {0}-{1}-{2}", this.day, this.month, this.year);
        }
    }

    internal struct OurAddress
    {
        private byte houseNo;
        private byte roadNo;
        private ushort postalCode;
        private string district;

        public OurAddress(byte houseNo, byte roadNo, ushort postalCode, string district)
        {
            this.houseNo = houseNo;
            this.roadNo = roadNo;
            this.postalCode = postalCode;
            this.district = district;
        }

        public void PrintAddress()
        {
            Console.WriteLine("Address Info: ");
            Console.WriteLine("House No: {0}", this.houseNo);
            Console.WriteLine("Road No: {0}", this.roadNo);
            Console.WriteLine("Postal Code: {0}", this.postalCode);
            Console.WriteLine("District: {0}", this.district);
        }
    }

    internal abstract class Account
    {
        private int id;
        private string name;
        private OurDate openingDate;
        private OurAddress address;
        private double balance;

        internal int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
        internal string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }
        
        internal OurDate OpeningDate
        {
            get { return this.openingDate; }
            set { this.openingDate = value; }
        }
        
        internal OurAddress Address
        {
            get { return this.address; }
            set { this.address = value; }
        }
        
        internal double Balance 
        {
            get { return this.balance; }
            set
            {
                if(value >= 0)
                    this.balance = value;
            }
        }

        internal Account(int id, string name, OurDate openingDate, OurAddress address, double balance)
        {
            this.Id = id;
            this.Name = name;
            this.OpeningDate = openingDate;
            this.Address = address;
            this.Deposit(balance);//this.Balance = balance;
        }

        internal void Deposit(double amount)
        {
            if (amount >= 500)
            {
                this.Balance += amount;
                Console.WriteLine("Deposit of {0} amount complete", amount);
            }
            else
                Console.WriteLine("{0} is not sufficient. Amount value need to be more than 500.", amount);

            //this.ShowInfo();
        }

        internal abstract bool Withdraw(double amount);

        internal void Transfer(Account receiver, double amount)
        {
            bool decision = this.Withdraw(amount);
            if (decision)
            {
                receiver.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Transfer Incomplete");
            }

            this.ShowInfo();
            receiver.ShowInfo();
        }

        internal virtual void ShowInfo()
        {
            Console.WriteLine("Account Information");
            Console.WriteLine("Account ID: {0}", this.Id);
            Console.WriteLine("Account Name: {0}", this.Name);
            this.OpeningDate.ShowDate();
            this.Address.PrintAddress();
            Console.WriteLine("Account Balance: {0}", this.Balance);

        }
    }
}

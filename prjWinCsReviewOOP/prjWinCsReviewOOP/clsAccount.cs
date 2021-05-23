using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsReviewOOP
{
    public class clsAccount
    {
        private string vNumber;
        private string vType;
        private clsDate vOpendate;
        private string vStatus;
        private decimal vBalance;

        public clsAccount()
        {
            vNumber = vType = vStatus = "Not Defined";
            vOpendate = new clsDate();
            vBalance = -1;

        }

        public clsAccount(string number, string type, int day, int month, int year, string status, decimal balance)
        {
            Number = number;
            Type = type;
            vOpendate = new clsDate(day, month, year);
            vStatus = status;
            vBalance = balance;
        }

        public string Number
        {
            get => vNumber;
            set
            {
                vNumber = value;
            }
        }

        public string Type
        {
            get => vType;
            set
            {
                vType = value;
            }
        }

        public clsDate OpenDate
        {
            get => vOpendate;
        }

        public string Status
        {
            get => vStatus;
        }

        public decimal Balance
        {
            get => vBalance;
        }

        public void Open(string number, string type)
        {
            Number = number;
            Type = type;
            vOpendate = new clsDate(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
            vStatus = "active";
            vBalance = 0;
        }

        /// <summary>
        /// returns true if amount is between 2 and 20000 else false.
        /// </summary>
        public bool Deposit(decimal amount)
        {
            if (amount >= 2 && amount <= 20000)
            {
                vBalance += amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// returns 0 (for successs), 1 (forMaximum), 2 (for Minimum), -1 (for Multiple 20), -2 (for insufficient funds)
        /// </summary>
        public int Withdraw(decimal amount)
        {
            if(amount > 500) { return 1; }
            else if (amount < 20) { return 2; }
            else if ((amount % 20) != 0) { return -1; }
            else if (amount > vBalance) { return -2; }
            else
            {
                vBalance -= amount;
                return 0;
            }
        }

        public string Consult()
        {
            string info = "Number: " + vNumber + "\nType: " + vType + "\nStatus: " + vStatus +
                "\nOpen Date: " + vOpendate.toNumber() + "\nBalance: $" + vBalance + "\n";
            return info;
        }

        public void Close()
        {
            vStatus = "closed";
        }
    }
}
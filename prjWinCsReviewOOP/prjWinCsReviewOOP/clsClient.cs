using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace prjWinCsReviewOOP
{
    public class clsClient
    {
        private string vNumber;
        private string vName;
        private string vStatus;
        private string vPin;
        private clsListAccount vAccounts;
        public clsClient()
        {
            vNumber = vName = vPin = vStatus = "Not Defined";
            vAccounts = new clsListAccount();
        }

        public clsClient(string number, string name, string pin, string status, clsListAccount accounts)
        {
            vNumber = number;
            vName = name;
            vPin = pin;
            vStatus = status;
            vAccounts = accounts;
        }

        public clsClient(string number, string name, string pin, string status)
        {
            vNumber = number;
            vName = name;
            vPin = pin;
            vStatus = status;
            vAccounts = new clsListAccount();
        }
        public string Name
        {
            get => vName;
            set
            {
                vName = value;
            }
        }
        public string Number
        {
            get => vNumber;
        }
        public string Pin
        {
            get => vPin;
            set
            {
                vPin = value;
            }
        }
        public string Status
        {
            get => vStatus;
        }

        public clsListAccount Accounts
        {
            get => vAccounts;
            set
            {
                vAccounts = value;
            }
        }
        public void Register(string number, string name, string pin)
        {
            vNumber = number;
            Name = name;
            Pin = pin;
            vStatus = "Active";
        }

        public string Display()
        {
            string info = "\n---- Client ----\nNumber: " + vNumber + "\nName: " + vName
                + "\nPin: " + vPin + "\nStatus: " + vStatus + "\n\n   Accounts---\n"
                + vAccounts.Display() + "\n";
            return info;
        }
    }
}
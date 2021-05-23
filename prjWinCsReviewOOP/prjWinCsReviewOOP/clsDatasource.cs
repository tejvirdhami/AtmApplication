using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinCsReviewOOP
{
    public static class clsDatasource
    {
        
        public static clsListClient getAllClients()
        {
            //--------------------------------------------TEXT FILE METHOD----------------------------------------------

            //clsListClient allClients = new clsListClient();
            //StreamReader myfile = new StreamReader("Clients.txt");
            //while (myfile.EndOfStream == false)
            //{
            //    string num = myfile.ReadLine();
            //    string nam = myfile.ReadLine();
            //    string stat = myfile.ReadLine();
            //    string pin = myfile.ReadLine();

            //    clsClient aclient = new clsClient(num, nam, pin, stat);
            //    allClients.Add(aclient);
            //        }
            //myfile.Close();
            //return allClients;

            //----------------------------------------DATABASE METHOD-------------------------------------------------
            clsListClient allClients = new clsListClient();
            OleDbConnection myCon = new OleDbConnection();
            myCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Tejvir Dhami\source\repos\prjWinCsReviewOOP\prjWinCsReviewOOP\databases\DBBank2003.mdb";
            myCon.Open();

            string sql = "SELECT [Number], ClientName, Pin, Status FROM Clients";
            OleDbCommand myCmd = new OleDbCommand(sql, myCon);

            OleDbDataReader myRder = myCmd.ExecuteReader();

            while(myRder.Read())
            {
                string num = myRder["Number"].ToString();
                string nam = myRder["ClientName"].ToString();
                string stat = myRder["Status"].ToString();
                string pin = myRder["Pin"].ToString();

                clsClient aclient = new clsClient(num, nam, pin, stat);
                allClients.Add(aclient);
            }
            myRder.Close();
            myCon.Close();
            return allClients;
        }

        public static clsListAccount GetThisClientAccounts(string clientNumber)
        {

            //-----------------------------------------TEXT FILE METHOD-------------------------------------------


            //clsListAccount clientAccounts = new clsListAccount();
            //StreamReader myfile = new StreamReader("Accounts.txt");
            //while (myfile.EndOfStream == false)
            //{
            //    string num = myfile.ReadLine();
            //    string typ = myfile.ReadLine();
            //    int day = Convert.ToInt32(myfile.ReadLine());
            //    int month = Convert.ToInt32(myfile.ReadLine());
            //    int year = Convert.ToInt32(myfile.ReadLine());
            //    string stat = myfile.ReadLine();
            //    decimal bal = Convert.ToDecimal(myfile.ReadLine());

            //    string clientID = myfile.ReadLine();
            //    if (clientNumber == clientID)
            //    {
            //        clsAccount anAcc = new clsAccount(num, typ, day, month, year, stat, bal);
            //        clientAccounts.Add(anAcc);
            //    }
            //}
            //    myfile.Close();
            //    return clientAccounts;


            //--------------------------------------------DATA BASE METHOD--------------------------------------------------
            clsListAccount clientAccounts = new clsListAccount();
            OleDbConnection myCon = new OleDbConnection();
            myCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Apple\source\repos\prjWinCsReviewOOP\prjWinCsReviewOOP\databases\DBBank2003.mdb";
            myCon.Open();

            string sql = "";
            sql = "SELECT [Number],Type,OpenDay,OpenMonth,OpenYear,Status,Balance,ClientID FROM Accounts WHERE ClientID ='" + clientNumber + "'";
            OleDbCommand mycmd = new OleDbCommand(sql, myCon);

            OleDbDataReader myRder = mycmd.ExecuteReader();
            while(myRder.Read())
            {
                string num = myRder["Number"].ToString();
                string typ = myRder["Type"].ToString();
                int day = Convert.ToInt32(myRder["OpenDay"].ToString());
                int month = Convert.ToInt32(myRder["OpenMonth"].ToString());
                int year = Convert.ToInt32(myRder["OpenYear"].ToString());
                string stat = myRder["Status"].ToString();
                decimal bal = Convert.ToDecimal(myRder["Balance"].ToString());

                clsAccount anAcc = new clsAccount(num, typ, day, month, year, stat, bal);
                clientAccounts.Add(anAcc);
            }
            myRder.Close();
            myCon.Close();
            return clientAccounts;
        }
    }
}
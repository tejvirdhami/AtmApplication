using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsReviewOOP
{
    public class clsListClient
    {
        // Private or Hidden dictionary to uncapsulate our own list.
        private Dictionary<string, clsClient> mylist;

        public clsListClient()
        {
            mylist = new Dictionary<string, clsClient>();
        }

        public int Quantity
        {
            get { return mylist.Count; }
            //Read only we cannot change the amount
        }

        public Dictionary<string, clsClient>.ValueCollection Element
        {
            get => mylist.Values;

        }

        public bool Add(clsClient client)
        {
            if (Exist(client.Number) == false)
            {
                mylist.Add(client.Number, client);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Delete(string number)
        {
            return mylist.Remove(number);
        }

        public clsClient Find(string number)
        {
            if (Exist(number) == true)
            {
                return mylist[number];
            }
            else
            {
                return null;
            }
        }

        public bool Exist(string number)
        {
            return mylist.ContainsKey(number);
        }

        public string Display()
        {
            string info = "";
            foreach (clsClient itm in mylist.Values)
            {
                info += itm.Display() + "\n";
            }
            return info;
        }
    }
}
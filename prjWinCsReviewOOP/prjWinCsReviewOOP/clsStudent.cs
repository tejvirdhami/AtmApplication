using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsReviewOOP
{
    public class clsStudent
    {
        // declare the fields
        private string vNumber;
        private string vName;
        private clsDate vBirthdate;
        private Single vGrade;
        // do not declare vAge because it does not store a value
        //private int vAge;


        //------------------------------PROPERTIES----------------------------
        public string Number
        {
            get
            {
                return vNumber;
            }
            set
            {
                vNumber = value;
            }
        }
        public string Name
        {
            get
            {
                return vName;
            }
            set
            {
                vName = value;
            }
        }
        public clsDate BirthDate
        {
            get
            {
                return vBirthdate;
            }
            set
            {
                vBirthdate = value;
            }
        }
        public Single Grade
        {
            get
            {
                return vGrade;
            }
            //set // NO set because this property is read only
            //{
            //    vGrade = value;
            //}
        }
        public int Age
        {
            get
            {
                return (DateTime.Today.Year - BirthDate.Year);
            }
            //set { vAge = value; } //READ ONLY
        }


        //-----------------------------------CONSTRUCTORS----------------------------------

        // one EMPTY
        public clsStudent()
        {
            vName = "Not defined";
            vBirthdate = new clsDate();
            vGrade = -1;
        }

        //One with all the parameters
        public clsStudent(string aNumber, string aName, int aDay, int aMonth, int aYear, Single aGrade)
        {
            Number = aNumber;
            Name = aName;
            vBirthdate = new clsDate(aDay, aMonth, aYear);
            vGrade = aGrade;
        }

        public clsStudent(string aName, clsDate aDate, Single aGrade)
        {
            Name = aName;
            BirthDate = aDate;
            vGrade = aGrade;
        }


        //-------------------------------------METHODS-------------------------------------------------
        public void Register(string vName, int aDay, int aMonth, int aYear)
        {
            Name = vName;
            BirthDate =  new clsDate(aDay, aMonth, aYear);
            vGrade = -1;
        }

        public bool ToGrade(Single aGrade)
        {
            if(aGrade >=0 && aGrade <=100)
            {
                vGrade = aGrade;
                return true;
            }
            else { return false; }
        }

        public string Display()
        {
            string info = "Number: " + Number +  "\nName: " + Name + "\nBirthDate : " + BirthDate.toLetter();
            info += "\nGrade: " + Grade + "/100 " + "\nAge: " + Age + " years \n";
            return info;
        }
    }
}

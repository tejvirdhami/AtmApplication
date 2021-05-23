using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinCsReviewOOP
{
    public class clsTime
    {
        // Dclaration of private fields (Variables that store the values of the properties)
        private int vHour;
        private int vMinute;
        private int vSecond;

        // Declaration of access methods to the properties.
        public int Hour
        {
            get // for readinmg the value of the field associated to the property
            {
                return vHour;
            }
            set // for writing a value to the associated field to the property
            {
                vHour = (value >= 0 && value <=23)? value : 0;
            }
        }

        public int Minute
        {
            get // for readinmg the value of the field associated to the property
            {
                return vMinute;
            }
            set // for writing a value to the associated field to the property
            {
                vMinute = (value >= 0 && value <= 59) ? value : 0;
            }
        }

        public int Second
        {
            get // for readinmg the value of the field associated to the property
            {
                return vSecond;
            }
            set // for writing a value to the associated field to the property
            {
                vSecond = (value >= 0 && value <= 59) ? value : 0;
            }
        }
        //Declaration of public methods
        public void Adjust(int anHour, int aMinute, int aSecond)
        {
            Hour = anHour;
            Minute = aMinute;
            Second = aSecond;
        }

        public string DisplayUniversal() // Method DisplayUniversal
        {
            string info;
            info = Hour + ":" + Minute + ":" + Second;
            return info;
        }

        public string DisplayStandard()
        {
            string info;
            if(Hour < 12)
            { return Hour + ":" + Minute + ":" + Second + " AM"; }
            else
            { 
                return (Hour - 12) + ":" + Minute + ":" + Second + " PM";
            }

            // OR
           // return ((Hour > 12) ? Hour - 12 : Hour) + ":" + Minute + ":" + Second + ((Hour > 12) ? " PM" : " Am");
        }
    }
}

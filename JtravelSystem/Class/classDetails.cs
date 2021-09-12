using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JtravelSystem.Class
{
    class classDetails
    {


        static string f;
        static string name;
        static string type;
        static string addon;


        static string f2;
        static string ft;
        static string code;
        static string code2;

        public static string flight
        {
            get
            {
                return f;
            }
            set
            {
                f = value;
            }
        }


        public static string flight2
        {
            get
            {
                return f2;
            }
            set
            {
                f2 = value;
            }
        }


        public static string guestName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public static string guestType
        {
            get
            {
                return type;
            }
            set
            {
              type  = value;
            }
        }


        public static string guestAddon
        {
            get
            {
                return addon;
            }
            set
            {
                addon = value;
            }
        }


        public static string fromTo
        {
            get
            {
                return ft;
            }
            set
            {
                ft = value;
            }
        }
      public static string flightcode
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }
     public static string flightcode2
        {
            get
            {
                return code2;
            }
            set
            {
                code2 = value;
            }


        }

    }
}

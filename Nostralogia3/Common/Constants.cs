using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3
{
    public class Constants
    {
        public const int ApplicationId = 6;

        public const string ConnectionMain = "ConnectionMain";
        public const string ConnectionGeo = "ConnectionGeo";
        public const string ConnectionSMGeneral = "ConnectionSMGeneral";

        public const string EmailFrom = "nostralogia@gmail.com";
        public const string PassFrom = "Shofar8385";

        public const int PassCodeLength = 12;
        public const int SaltLength = 10;

        public static DateTime DummyDate { get { return new DateTime(1800, 1, 1);  } }



        public const string ZeroStringComboText = "Select...";
        public const string ZeroStringComboValue = "-1";

        public static String SessionID { get { return "Nostra_SESSION_ID"; } }
        public static String SessionUName { get { return "Nostra_SESSION_UserName"; } }
        public static String SessionULevel { get { return "Nostra_SESSION_UserLevel"; } }

        public static String CoockieToken{ get { return "Nostra_COCKIE_Token"; } }
        public static String CoockieUserLevel { get { return "Nostra_COCKIE_ULevel"; } }

        protected static int _counter = 0;
        public static int Counter { get { return _counter++; } }

        public static string MarkerEdit { get { return "[EDIT]"; } }
        public static string MarkerDelete { get { return "[DELETE]"; } }

    }
}

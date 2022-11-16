using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3
{
    public class Constants
    {
        public class SessionCoockies
        {
            public static String SessionID { get { return "Nostra_SESSION_ID"; } }
            public static String SessionUName { get { return "Nostra_SESSION_UserName"; } }
            public static String SessionUID { get { return "Nostra_SESSION_UserID"; } }
            public static String SessionULevel { get { return "Nostra_SESSION_UserLevel"; } }

            public static String CoockieToken { get { return "Nostra_COCKIE_Token"; } }
            public static String CoockieUserLevel { get { return "Nostra_COCKIE_ULevel"; } }

        }
        public class Connections
        {
            public const string ConnectionMain = "ConnectionMain";
            public const string ConnectionGeo = "ConnectionGeo";
            public const string ConnectionSMGeneral = "ConnectionSMGeneral";

            public const string EmailFrom = "nostralogia@gmail.com";
            public const string PassFrom = "Shofar8385";


        }
        public class Values
        {
            public const int ApplicationId = 6;
            public const int PassCodeLength = 12;
            public const int SaltLength = 10;
            public const string ItemValue = "Value";
            public const string ItemText = "Text";

            public const int CAN_VIEW = 1;
            public const int CAN_EDIT = 2; 
            public const int CAN_ADD = 4;
            public const int CAN_DEACTIVATE = 8;
            public const int CAN_DELETE = 16;

            public const int VOLUNTIER_RIGHTS = 1;
            public const int RESEARCHER_RIGHTS = 2;
            public const int TEAMLEAD_RIGHTS = 3;
            public const int ADMIN_RIGHTS = 4;
            public static DateTime DummyDate { get { return new DateTime(1800, 1, 1); } }
            public const string ZeroStringComboText = "Select...";
            public const string ZeroStringComboValue = "-1";
            protected static int _counter = 0;
            public static int Counter { get { return _counter++; } }
            public static string MarkerEdit { get { return "[EDIT]"; } }            
            public static string MarkerDelete { get { return "[DELETE]"; } }
            public static string MarkerDeactivate { get { return "[DEACTIVATE]"; } }
        }
        public class Paths
        {
            public static string ImageRepository { get { return "wwwroot/Repository/PeopleImages";  } }
        }
        public class DataTypes
        {
            public const int DataPublic = 1;
        }

    }
}

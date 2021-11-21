﻿using System;
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

        public const string ZeroStringComboText = "Select...";
        public const string ZeroStringComboValue = "-1";

        public static String SessionID { get { return "Nostra_SESSION_ID"; } }
        public static String SessionUName { get { return "Nostra_SESSION_UserName"; } }
        public static String SessionULevel { get { return "Nostra_SESSION_UserLevel"; } }

        public static String CoockieToken{ get { return "Nostra_COCKIE_Token"; } }
        public static String CoockieUserLevel { get { return "Nostra_COCKIE_ULevel"; } }

    }
}

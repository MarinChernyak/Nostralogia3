using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class PeopleUser
    {
        public int Idperson { get; set; }
        public int Iduser { get; set; }
        public double Rating { get; set; }

        public virtual Person IdpersonNavigation { get; set; }
    }
}

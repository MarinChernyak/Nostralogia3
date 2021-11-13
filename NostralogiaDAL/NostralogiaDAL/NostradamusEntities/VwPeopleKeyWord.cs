using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class VwPeopleKeyWord
    {
        public int IdPerson { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public byte DataType { get; set; }
        public short Idkw { get; set; }
        public short? ReferenceId { get; set; }
        public byte AccessLevel { get; set; }
        public string AdvKeyWord { get; set; }
        public string KeyWordDescription { get; set; }
    }
}

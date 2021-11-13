using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.SMGeneralEntities
{
    public partial class Role
    {
        public short RoleId { get; set; }
        public short AppId { get; set; }
        public string RoleNameIds { get; set; }
        public string RoleDescription { get; set; }
        public byte AccessLevel { get; set; }
        public string RoleName { get; set; }

        public virtual Application App { get; set; }
    }
}

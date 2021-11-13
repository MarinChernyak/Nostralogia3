using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NostralogiaDAL.SMGeneralEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NostradamusDAL.Factory
{
    public class SMGeneralContextFactory : IDesignTimeDbContextFactory<SMGeneralContext>
    {
        public SMGeneralContext CreateDbContext(string[] args)
        {
            var connectionname = Constants.ConnectionSMGeneral;
            if (args != null && args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                connectionname = args[0];
            }
            var connection = new ConfigCreator(connectionname);
            var builder = new DbContextOptionsBuilder<SMGeneralContext>();
            builder.UseSqlServer(connection.ConnectionString);
            return new SMGeneralContext(builder.Options);
        }
    }
}

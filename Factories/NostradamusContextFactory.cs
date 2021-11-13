using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NostralogiaDAL.NostradamusEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NostradamusDAL.Factory
{
    public class NostradamusContextFactory : IDesignTimeDbContextFactory<NostradamusTestContext>
    {
        public NostradamusContextFactory()
        {
        }

        public NostradamusTestContext CreateDbContext(string[] args)
        {
            var connectionname = Constants.ConnectionMain;
            if (args != null && args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                connectionname = args[0];
            }
            var connection = new ConfigCreator(connectionname);
            var builder = new DbContextOptionsBuilder<NostradamusTestContext>();
            builder.UseSqlServer(connection.ConnectionString);
            return new NostradamusTestContext(builder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NostralogiaDAL.NostraGeoEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NostradamusDAL.Factory
{
    public class NostradamusGeoContextFactory : IDesignTimeDbContextFactory<NostraGeoContext>
    {
        public NostradamusGeoContextFactory()
        {
        }

        public NostraGeoContext CreateDbContext(string[] args)
        {
            var connectionname = Constants.ConnectionGeo;
            if (args != null && args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                connectionname = args[0];
            }
            var connection = new ConfigCreator(connectionname);
            var builder = new DbContextOptionsBuilder<NostraGeoContext>();
            builder.UseSqlServer(connection.ConnectionString);
            return new NostraGeoContext(builder.Options);
        }
    }

}

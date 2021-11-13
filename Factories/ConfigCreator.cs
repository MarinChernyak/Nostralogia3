using Microsoft.Extensions.Configuration;

namespace NostradamusDAL.Factory
{
    public class ConfigCreator
    {
        public string ConnectionString { get; }
        public ConfigCreator(string ConnectionName)
        {
            //ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString; ;
        }
    }
}

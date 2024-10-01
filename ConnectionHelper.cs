using System.Configuration;

namespace JanasInventoryManagementSystem
{
    public static class ConnectionHelper
    {
        public static string Connection(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}

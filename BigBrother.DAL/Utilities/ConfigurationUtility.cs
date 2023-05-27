using System.Configuration;

namespace BigBrother.DAL.Utilities
{
    internal static class ConfigurationUtility
    {
        public static string GetConnectionString()
        {
            // TODO Hard coded string
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["BigBrotherConnectionString"];
            return connectionStringSettings.ConnectionString;
        }
    }
}

namespace PayStuffWeb.Code
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public static class DatabaseConnection
    {
        public static IDbConnection Create()
        {
            var configValue = ConfigurationManager.ConnectionStrings["database"];
            return new SqlConnection(configValue.ConnectionString);
        }
    }
}
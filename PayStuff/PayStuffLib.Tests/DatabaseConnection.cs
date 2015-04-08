namespace PayStuffLib.Tests
{
    using System.Data;
    using System.Data.SqlClient;

    public static class DatabaseConnection
    {
        public static IDbConnection Create()
        {
            const string connectionString = "Server=127.0.0.1;Database=Experimental;User=Adama;Password=William";
            return new SqlConnection(connectionString);
        }
    }
}
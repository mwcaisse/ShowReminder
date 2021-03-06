using System;
using MySqlConnector;
using Serilog;
namespace ShowReminder.Web.Utils
{
    public class DatabaseHelper
    {
        public static void MigrateDatabase(string connectionString)
        {
            try
            {
                var databaseConnection = new MySqlConnection(connectionString);
                var evolve = new Evolve.Evolve(databaseConnection, Log.Information)
                {
                    Locations = new[]
                    {
                        "Database/Migrations"
                    },
                    IsEraseDisabled = true,
                    EnableClusterMode = true
                };

                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Fatal("Database migrations failed.", ex);
                throw;
            }
        }
    }
}
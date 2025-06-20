using School.DB.db;
using System.Configuration;
using System.Data.SQLite;

namespace SchoolManagementSystem.Database
{
    internal class DbCon
    {
        private static string connectionString = "Data Source=UnicomDB.db";

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionString);
            conn.Open();

            return conn;
        }
    }
}

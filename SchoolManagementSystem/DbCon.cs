using School.DB.db;
using System;
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

            try
            {
                conn.Open(); // Try to open the connection
            }
            catch (SQLiteException ex)
            {
                // Optional: Log or show the error message
                Console.WriteLine("Database connection error: " + ex.Message);
                // Re-throw if needed
                throw;
            }

            return conn;
        }

    }
}

using System;
using System.Data.SQLite;
using SchoolManagementSystem.Database;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class LoginController
    {
        public bool ValidateLogin(Login login)
        {
            bool isValid = false;

            using (SQLiteConnection conn = DbCon.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", login.Username);
                cmd.Parameters.AddWithValue("@password", login.Password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                isValid = count > 0;
            }

            return isValid;
        }
    }
}

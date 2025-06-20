using System;
using System.Data.SQLite;
using System.Windows.Forms;
using School.DB.db;
using SchoolManagementSystem.Database;
using SchoolManagementSystem.Views;

namespace SchoolManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Databasemaneger.CreateStudentTable();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            using (SQLiteConnection conn = DbCon.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    DashBoard dashboard = new DashBoard();
                    dashboard.Show();
                    this.Hide();  
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using SchoolManagementSystem.Database;
using SchoolManagementSystem.Module;

namespace SchoolManagementSystem.Controllers
{
    public class TeacherController
    {
        //private string connectionString = "Data Source=UnicomDB.db";
        public void AddTeacher(Teacher teacher)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Teachers (Name, Subject, Contact, Email) VALUES (@Name, @Subject, @Contact, @Email)";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", teacher.Name);
                cmd.Parameters.AddWithValue("@Subject", teacher.Subject);
                cmd.Parameters.AddWithValue("@Contact", teacher.Contact);
                cmd.Parameters.AddWithValue("@Email", teacher.Email);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Teachers";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Teacher teacher = new Teacher
                    {
                        TeacherId = Convert.ToInt32(reader["TeacherId"]),
                        Name = reader["Name"].ToString(),
                        Subject = reader["Subject"].ToString(),
                        Contact = reader["Contact"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                    teachers.Add(teacher);
                }
            }

            return teachers;
        }
    }
}

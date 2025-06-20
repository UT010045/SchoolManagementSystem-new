using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SchoolManagementSystem.Database;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class SubjectController
    {

        public void AddSubject(Subject subject)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Subject (SubjectName) VALUES (@name)";
                using (var command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@name", subject.SubjectName);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Subject> GetAllSubjects()
        {
            List<Subject> subjects = new List<Subject>();

            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Subject";
                using (var command = new SQLiteCommand(query, conn))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject
                        {
                            SubjectId = Convert.ToInt32(reader["SubjectId"]),
                            SubjectName = reader["SubjectName"].ToString()
                        });
                    }
                }
            }

            return subjects;
        }

        public void UpdateSubject(Subject subject)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Subject SET SubjectName = @name WHERE SubjectId = @id";
                using (var command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@name", subject.SubjectName);
                    command.Parameters.AddWithValue("@id", subject.SubjectId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSubject(int subjectId)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Subject WHERE SubjectId = @id";
                using (var command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", subjectId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

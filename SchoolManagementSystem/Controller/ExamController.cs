using SchoolManagementSystem.Database;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SchoolManagementSystem.Controllers
{
    public class ExamController
    {

        public void AddExam(Exam exam)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Exam (ExamName, ExamDate) VALUES (@ExamName, @ExamDate)";
                using (var command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@ExamName", exam.ExamName);
                    command.Parameters.AddWithValue("@ExamDate", exam.ExamDate.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Exam> GetAllExams()
        {
            List<Exam> exams = new List<Exam>();

            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Exam";
                using (var command = new SQLiteCommand(query, conn))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exams.Add(new Exam
                        {
                            ExamId = Convert.ToInt32(reader["ExamId"]),
                            ExamName = reader["ExamName"].ToString(),
                            ExamDate = DateTime.Parse(reader["ExamDate"].ToString())
                        });
                    }
                }
            }

            return exams;
        }

        public void UpdateExam(Exam updatedExam)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Exam SET ExamName = @ExamName, ExamDate = @ExamDate WHERE ExamId = @ExamId";
                using (var command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@ExamName", updatedExam.ExamName);
                    command.Parameters.AddWithValue("@ExamDate", updatedExam.ExamDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@ExamId", updatedExam.ExamId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteExam(int examId)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Exam WHERE ExamId = @ExamId";
                using (var command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@ExamId", examId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

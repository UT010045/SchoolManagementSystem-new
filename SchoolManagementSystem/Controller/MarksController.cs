using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Database;

namespace SchoolManagementSystem.Controllers
{
    public class MarkController
    {

        public void AddMark(Mark mark)
        {
            using (var conn = DbCon.GetConnection())
            {
                string query = "INSERT INTO Marks (StudentId, SubjectId, ExamId, MarksObtained) VALUES (@studentId, @subjectId, @examId, @marksObtained)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", mark.StudentId);
                    cmd.Parameters.AddWithValue("@subjectId", mark.SubjectId);
                    cmd.Parameters.AddWithValue("@examId", mark.ExamId);
                    cmd.Parameters.AddWithValue("@marksObtained", mark.MarksObtained);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Mark> GetAllMarks()
        {
            var marks = new List<Mark>();
            using (var conn = DbCon.GetConnection())
            {
                string query = "SELECT * FROM Marks";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marks.Add(new Mark
                        {
                            MarkId = Convert.ToInt32(reader["MarkId"]),
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            SubjectId = Convert.ToInt32(reader["SubjectId"]),
                            ExamId = Convert.ToInt32(reader["ExamId"]),
                            MarksObtained = Convert.ToInt32(reader["MarksObtained"])
                        });
                    }
                }
            }
            return marks;
        }

        public void DeleteMark(int markId)
        {
            using (var conn = DbCon.GetConnection())
            {
                string query = "DELETE FROM Marks WHERE MarkId = @markId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@markId", markId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMark(Mark mark)
        {
            using (var conn = DbCon.GetConnection())
            {
                string query = "UPDATE Marks SET StudentId = @studentId, SubjectId = @subjectId, ExamId = @examId, MarksObtained = @marksObtained WHERE MarkId = @markId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", mark.StudentId);
                    cmd.Parameters.AddWithValue("@subjectId", mark.SubjectId);
                    cmd.Parameters.AddWithValue("@examId", mark.ExamId);
                    cmd.Parameters.AddWithValue("@marksObtained", mark.MarksObtained);
                    cmd.Parameters.AddWithValue("@markId", mark.MarkId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

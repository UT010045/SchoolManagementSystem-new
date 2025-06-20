using System.Collections.Generic;
using System.Data.SQLite;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Database;

namespace SchoolManagementSystem.Controllers
{
    public class TimetableController
    {

        public static void AddTimetable(Timetable tt)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Timetable (ClassId, SubjectId, TeacherId, Day, StartTime, EndTime) VALUES (@ClassId, @SubjectId, @TeacherId, @Day, @StartTime, @EndTime)", conn);
                cmd.Parameters.AddWithValue("@ClassId", tt.ClassId);
                cmd.Parameters.AddWithValue("@SubjectId", tt.SubjectId);
                cmd.Parameters.AddWithValue("@TeacherId", tt.TeacherId);
                cmd.Parameters.AddWithValue("@Day", tt.Day);
                cmd.Parameters.AddWithValue("@StartTime", tt.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", tt.EndTime);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Timetable> GetAllTimetables()
        {
            List<Timetable> list = new List<Timetable>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Timetable", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Timetable
                    {
                        TimetableId = int.Parse(reader["TimetableId"].ToString()),
                        ClassId = int.Parse(reader["ClassId"].ToString()),
                        SubjectId = int.Parse(reader["SubjectId"].ToString()),
                        TeacherId = int.Parse(reader["TeacherId"].ToString()),
                        Day = reader["Day"].ToString(),
                        StartTime = reader["StartTime"].ToString(),
                        EndTime = reader["EndTime"].ToString()
                    });
                }
            }

            return list;
        }
    }
}

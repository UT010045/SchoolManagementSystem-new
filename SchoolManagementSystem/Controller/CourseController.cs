using SchoolManagementSystem.Database;
using SchoolManagementSystem.Models;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SchoolManagementSystem.Controllers
{
    public class CourseController
    {

        public void AddCourse(Course course)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Course (CourseName) VALUES (@CourseName)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();

            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Course";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            CourseId = reader.GetInt32(0),
                            CourseName = reader.GetString(1)
                        });
                    }
                }
                conn.Close();
            }

            return courses;
        }

        public void DeleteCourse(int courseId)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Course WHERE CourseId = @CourseId";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseId", courseId);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void UpdateCourse(Course updatedCourse)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Course SET CourseName = @CourseName WHERE CourseId = @CourseId";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseName", updatedCourse.CourseName);
                    cmd.Parameters.AddWithValue("@CourseId", updatedCourse.CourseId);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}

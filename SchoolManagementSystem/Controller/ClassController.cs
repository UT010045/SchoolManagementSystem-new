using System.Collections.Generic;
using System.Data.SQLite;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Database;

namespace SchoolManagementSystem.Controllers
{
    public class ClassController
    { 
    
        public void AddClass(Class cls)
        {
            using (var conn = DbCon.GetConnection())
            {
                string query = "INSERT INTO Class (ClassName, Section) VALUES (@ClassName, @Section)";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClassName", cls.ClassName);
                cmd.Parameters.AddWithValue("@Section", cls.Section);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateClass(Class cls)
        {
            using (var conn = DbCon.GetConnection())
            {
                string query = "UPDATE Class SET ClassName = @ClassName, Section = @Section WHERE ClassId = @ClassId";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClassName", cls.ClassName);
                cmd.Parameters.AddWithValue("@Section", cls.Section);
                cmd.Parameters.AddWithValue("@ClassId", cls.ClassId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteClass(int classId)
        {
            using (var conn = DbCon.GetConnection())
            {
                string query = "DELETE FROM Class WHERE ClassId = @ClassId";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClassId", classId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Class> GetAllClasses()
        {
            List<Class> classes = new List<Class>();

            using (var conn = DbCon.GetConnection())
            {
                string query = "SELECT * FROM Class";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    classes.Add(new Class
                    {
                        ClassId = int.Parse(reader["ClassId"].ToString()),
                        ClassName = reader["ClassName"].ToString(),
                        Section = reader["Section"].ToString()
                    });
                }
            }

            return classes;
        }

        public Class GetClassById(int id)
        {
            using (var conn = DbCon.GetConnection())
            {
                string query = "SELECT * FROM Class WHERE ClassId = @ClassId";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClassId", id);

                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Class
                    {
                        ClassId = int.Parse(reader["ClassId"].ToString()),
                        ClassName = reader["ClassName"].ToString(),
                        Section = reader["Section"].ToString()
                    };
                }
            }

            return null;
        }
    }
}

using SchoolManagementSystem.Database;
using SchoolManagementSystem.Model;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SchoolManagementSystem.Controllers
{
    public class StudentController
    {
        public void AddStudent(Student student)
        {
            using (var conn = DbCon.GetConnection())
            {
                string query = "INSERT INTO Student (Name, Age, Gender, Address, ContactNo) VALUES (@Name, @Age, @Gender, @Address, @ContactNo)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@Gender", student.Gender);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@ContactNo", student.ContactNo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var conn = DbCon.GetConnection())
            {
                string query = "UPDATE Student SET Name=@Name, Age=@Age, Gender=@Gender, Address=@Address, ContactNo=@ContactNo WHERE StudentId=@StudentId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@Gender", student.Gender);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@ContactNo", student.ContactNo);
                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (var conn = DbCon.GetConnection())
            {
                string query = "DELETE FROM Student WHERE StudentId=@StudentId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (var conn = DbCon.GetConnection())
            {
                string query = "SELECT * FROM Student";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            Name = reader["Name"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            Gender = reader["Gender"].ToString(),
                            Address = reader["Address"].ToString(),
                            ContactNo = Convert.ToInt32(reader["ContactNo"])
                        });
                    }
                }
            }

            return students;
        }
    }
}

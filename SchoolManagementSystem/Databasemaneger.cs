using SchoolManagementSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DB.db
{
    internal class Databasemaneger
    {

        public static void CreateStudentTable()
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Class (
                ClassId INTEGER PRIMARY KEY AUTOINCREMENT,
                ClassName TEXT NOT NULL,
                Section TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Course (
                CourseId INTEGER PRIMARY KEY AUTOINCREMENT,
                CourseName TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Exam (
                ExamId INTEGER PRIMARY KEY AUTOINCREMENT,
                ExamName TEXT NOT NULL,
                ExamDate DATE NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Mark (
                MarkId INTEGER PRIMARY KEY AUTOINCREMENT,
                StudentId INTEGER NOT NULL,
                SubjectId INTEGER NOT NULL,
                ExamId INTEGER NOT NULL,
                MarksObtained INTEGER NOT NULL,
                FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
                FOREIGN KEY (SubjectId) REFERENCES Subject(SubjectId),
                FOREIGN KEY (ExamId) REFERENCES Exam(ExamId)
            );

            CREATE TABLE IF NOT EXISTS Student (
                StudentId INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Age INTEGER NOT NULL,
                Gender TEXT NOT NULL,
                Address TEXT NOT NULL,
                ContactNo TEXT NOT NULL,
                ClassId INTEGER,
                FOREIGN KEY (ClassId) REFERENCES Class(ClassId)
            );

            CREATE TABLE IF NOT EXISTS Subject (
                SubjectId INTEGER PRIMARY KEY AUTOINCREMENT,
                SubjectName TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Teacher (
                TeacherId INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Subject TEXT NOT NULL,
                Contact TEXT NOT NULL,
                Email TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Users (
                UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL,
                Password TEXT NOT NULL
            );
        ";
                cmd.ExecuteNonQuery();

                // Insert sample data if not already present
                // Sample Users
                cmd.CommandText = "SELECT COUNT(*) FROM Users";
                long userCount = (long)cmd.ExecuteScalar();
                if (userCount == 0)
                {
                    cmd.CommandText = @"
                INSERT INTO Users (Username, Password) VALUES ('admin', 'admin');
                INSERT INTO Users (Username, Password) VALUES ('student', 'student');
            ";
                    cmd.ExecuteNonQuery();
                }

                // Sample Class
                cmd.CommandText = "SELECT COUNT(*) FROM Class";
                long classCount = (long)cmd.ExecuteScalar();
                if (classCount == 0)
                {
                    cmd.CommandText = "INSERT INTO Class (ClassName, Section) VALUES ('Grade 10', 'A')";
                    cmd.ExecuteNonQuery();
                }

                // Sample Course
                cmd.CommandText = "SELECT COUNT(*) FROM Course";
                long courseCount = (long)cmd.ExecuteScalar();
                if (courseCount == 0)
                {
                    cmd.CommandText = "INSERT INTO Course (CourseName) VALUES ('Science')";
                    cmd.ExecuteNonQuery();
                }

                // Sample Subject
                cmd.CommandText = "SELECT COUNT(*) FROM Subject";
                long subjectCount = (long)cmd.ExecuteScalar();
                if (subjectCount == 0)
                {
                    cmd.CommandText = "INSERT INTO Subject (SubjectName) VALUES ('Mathematics')";
                    cmd.ExecuteNonQuery();
                }

                // Sample Teacher
                cmd.CommandText = "SELECT COUNT(*) FROM Teacher";
                long teacherCount = (long)cmd.ExecuteScalar();
                if (teacherCount == 0)
                {
                    cmd.CommandText = @"
                INSERT INTO Teacher (Name, Subject, Contact, Email) 
                VALUES ('Mr. Silva', 'Mathematics', '0771234567', 'silva@example.com')";
                    cmd.ExecuteNonQuery();
                }

                // Sample Student
                cmd.CommandText = "SELECT COUNT(*) FROM Student";
                long studentCount = (long)cmd.ExecuteScalar();
                if (studentCount == 0)
                {
                    cmd.CommandText = @"
                INSERT INTO Student (Name, Age, Gender, Address, ContactNo, ClassId) 
                VALUES ('Kamal', 15, 'Male', 'Colombo', '0712345678', 1)";
                    cmd.ExecuteNonQuery();
                }

                // Sample Exam
                cmd.CommandText = "SELECT COUNT(*) FROM Exam";
                long examCount = (long)cmd.ExecuteScalar();
                if (examCount == 0)
                {
                    cmd.CommandText = @"
                INSERT INTO Exam (ExamName, ExamDate) 
                VALUES ('Midterm', '2025-07-15')";
                    cmd.ExecuteNonQuery();
                }

                // Sample Mark
                cmd.CommandText = "SELECT COUNT(*) FROM Mark";
                long markCount = (long)cmd.ExecuteScalar();
                if (markCount == 0)
                {
                    cmd.CommandText = @"
                INSERT INTO Mark (StudentId, SubjectId, ExamId, MarksObtained) 
                VALUES (1, 1, 1, 85)";
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

       
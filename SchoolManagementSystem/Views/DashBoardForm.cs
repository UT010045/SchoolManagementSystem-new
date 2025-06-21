using SchoolManagementSystem.Models;
using SchoolManagementSystem.Views; // Make sure to include this
using System;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            // Open Student Form
            StudentForm studentForm = new StudentForm();
            studentForm.Show();

        }
        private void btnTeacher_Click(object sender, EventArgs e)
        {
            // Open Teacher Form
            TeacherForm teacherForm = new TeacherForm();
            teacherForm.Show();

        }
        private void btnClass_Click(object sender, EventArgs e)
        {
            // Open Class Form
            ClassForm classForm = new ClassForm();
            classForm.Show();

        }
        private void btnCourse_Click(object sender, EventArgs e)
        {
            // Open Course Form
            CourseForm courseForm = new CourseForm();
            courseForm.Show();

        }
        private void btnSubject_Click(object sender, EventArgs e)
        {
            // Open Subject Form
            SubjectForm subjectForm = new SubjectForm();
            subjectForm.Show();

        }
        private void btnTimeTable_Click(object sender, EventArgs e)
        {
            // Open TimeTable Form
            TimetableForm timeTableForm = new TimetableForm();
            timeTableForm.Show();

        }
        private void btnExam_Click(object sender, EventArgs e)
        {
            // Open exam Form
            ExamForm examForm = new ExamForm();
            examForm.Show();

        }
        private void btnMarks_Click(object sender, EventArgs e)
        {
            // Open marks Form
            MarkForm marksForm = new MarkForm();
            marksForm.Show();

        }

    }
}

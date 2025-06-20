using SchoolManagementSystem.Controllers;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolManagementSystem.Views
{
    public partial class CourseForm : Form
    {
        private CourseController controller = new CourseController();
        private int selectedCourseId = 0;

        public CourseForm()
        {
            InitializeComponent();
            LoadCourses();
        }

        private void LoadCourses()
        {
            List<Course> courses = controller.GetAllCourses();
            dgvCourses.DataSource = null;
            dgvCourses.DataSource = courses;

            // ComboBox also update with course names
            comboBox1.Items.Clear();
            foreach (var course in courses)
            {
                comboBox1.Items.Add(course.CourseName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Please enter or select a course name.");
                return;
            }

            Course newCourse = new Course
            {
                CourseName = comboBox1.Text.Trim()
            };

            controller.AddCourse(newCourse);
            LoadCourses();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == 0)
            {
                MessageBox.Show("Please select a course to update.");
                return;
            }

            Course updatedCourse = new Course
            {
                CourseId = selectedCourseId,
                CourseName = comboBox1.Text.Trim()
            };

            controller.UpdateCourse(updatedCourse);
            LoadCourses();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == 0)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            controller.DeleteCourse(selectedCourseId);
            LoadCourses();
            ClearFields();
        }

        private void dataGridViewCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCourses.Rows[e.RowIndex];
                selectedCourseId = Convert.ToInt32(row.Cells["CourseId"].Value);
                comboBox1.Text = row.Cells["CourseName"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            comboBox1.Text = "";
            selectedCourseId = 0;
        }
    }
}

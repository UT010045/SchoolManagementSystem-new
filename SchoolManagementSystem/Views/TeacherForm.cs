using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolManagementSystem.Module;
using SchoolManagementSystem.Controllers;
using System.Xml.Linq;

namespace SchoolManagementSystem.Views
{
    public partial class TeacherForm : Form
    {
        private TeacherController teacherController = new TeacherController();

        public TeacherForm()
        {
            InitializeComponent();
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            List<Teacher> teachers = TeacherController.GetAllTeachers();
            dgvTeachers.DataSource = null; // reset binding
            dgvTeachers.DataSource = teachers;
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(txtContactNo.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill all the fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create new Teacher object
            Teacher newTeacher = new Teacher
            {
                Name = txtName.Text.Trim(),
                Subject = textBox2.Text.Trim(),
                Contact = txtContactNo.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            // Add teacher to controller
            teacherController.AddTeacher(newTeacher);

            // Refresh grid
            LoadTeachers();

            // Clear input fields
            ClearInputFields();

            MessageBox.Show("Teacher added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearInputFields()
        {
            txtName.Clear();
            textBox2.Clear();
            txtContactNo.Clear();
            txtEmail.Clear();
            txtName.Focus();
        }
    }
}

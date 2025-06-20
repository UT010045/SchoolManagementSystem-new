
using SchoolManagementSystem.Controllers;
using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SchoolManagementSystem.Views
{
    public partial class StudentForm : Form
    {
        private StudentController controller = new StudentController();
        public int selectedStudentId =0;

        public StudentForm()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            List<Student> students = controller.GetAllStudents();
            dgvStudent.DataSource = students;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            txtContactNo.Clear();
            cmbGender.SelectedIndex = -1;
            //selectedStudentId = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var student = new Student
                {
                    Name = txtName.Text,
                    Age = int.Parse(txtAge.Text),
                    Gender = cmbGender.Text,
                    Address = txtAddress.Text,
                    ContactNo = int.Parse(txtContactNo.Text)
                };

                controller.AddStudent(student);
                LoadStudents();
                ClearForm();
                MessageBox.Show("Student added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvStudent.Rows[e.RowIndex];
                selectedStudentId = Convert.ToInt32(row.Cells["StudentId"].Value);
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();
                cmbGender.Text = row.Cells["Gender"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtContactNo.Text = row.Cells["ContactNo"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == 0)
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            var student = new Student
            {
                StudentId = selectedStudentId,
                Name = txtName.Text,
                Age = int.Parse(txtAge.Text),
                Gender = cmbGender.Text,
                Address = txtAddress.Text,
                ContactNo = int.Parse(txtContactNo.Text)
            };

            controller.UpdateStudent(student);
            LoadStudents();
            ClearForm();
            MessageBox.Show("Student updated successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == 0)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            controller.DeleteStudent(selectedStudentId);
            LoadStudents();
            ClearForm();
            MessageBox.Show("Student deleted successfully!");
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

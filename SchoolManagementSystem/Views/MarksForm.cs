using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Controllers;

namespace SchoolManagementSystem.Views
{
    public partial class MarkForm : Form
    {
        private MarkController markController = new MarkController();
        private int selectedMarkId = 0;

        public MarkForm()
        {
            InitializeComponent();
            LoadComboData();
            LoadMarkData();
        }

        private void LoadComboData()
        {
            // Dummy Data - Replace with actual Student/Subject/Exam list from controllers
            cmbStudent.Items.Add(new { Text = "Student 1", Value = 1 });
            cmbStudent.Items.Add(new { Text = "Student 2", Value = 2 });
            cmbStudent.DisplayMember = "Text";
            cmbStudent.ValueMember = "Value";

            cmbSubject.Items.Add(new { Text = "Math", Value = 1 });
            cmbSubject.Items.Add(new { Text = "Science", Value = 2 });
            cmbSubject.DisplayMember = "Text";
            cmbSubject.ValueMember = "Value";

            cmbExam.Items.Add(new { Text = "Term 1", Value = 1 });
            cmbExam.Items.Add(new { Text = "Term 2", Value = 2 });
            cmbExam.DisplayMember = "Text";
            cmbExam.ValueMember = "Value";
        }

        private void LoadMarkData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = markController.GetAllMarks();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Mark mark = new Mark
            {
                StudentId = ((dynamic)cmbStudent.SelectedItem).Value,
                SubjectId = ((dynamic)cmbSubject.SelectedItem).Value,
                ExamId = ((dynamic)cmbExam.SelectedItem).Value,
                MarksObtained = int.Parse(txtMarksInput.Text)
            };

            markController.AddMark(mark);
            LoadMarkData();
            ClearFields();
        }

        private void dgvMarks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                selectedMarkId = Convert.ToInt32(row.Cells["MarkId"].Value);
                txtMarksInput.Text = row.Cells["MarksObtained"].Value.ToString();

                // You can match combo box selected item manually if needed.
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Mark mark = new Mark
            {
                MarkId = selectedMarkId,
                StudentId = ((dynamic)cmbStudent.SelectedItem).Value,
                SubjectId = ((dynamic)cmbSubject.SelectedItem).Value,
                ExamId = ((dynamic)cmbExam.SelectedItem).Value,
                MarksObtained = int.Parse(txtMarksInput.Text)
            };

            markController.UpdateMark(mark);
            LoadMarkData();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMarkId != 0)
            {
                markController.DeleteMark(selectedMarkId);
                LoadMarkData();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            selectedMarkId = 0;
            cmbStudent.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbExam.SelectedIndex = -1;
            txtMarksInput.Clear();
        }
    }
}

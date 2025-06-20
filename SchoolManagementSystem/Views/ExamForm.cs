using SchoolManagementSystem.Controllers;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolManagementSystem.Views
{
    public partial class ExamForm : Form
    {
        private ExamController controller = new ExamController();
        private int selectedExamId = 0;

        public ExamForm()
        {
            InitializeComponent();
            LoadExams();
        }

        private void LoadExams()
        {
            var examList = controller.GetAllExams();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = examList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Exam Name.");
                return;
            }

            var exam = new Exam
            {
                ExamName = textBox1.Text.Trim(),
                ExamDate = dtpExamDate.Value
            };

            controller.AddExam(exam);
            LoadExams();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedExamId == 0)
            {
                MessageBox.Show("Please select an exam to update.");
                return;
            }

            var updatedExam = new Exam
            {
                ExamId = selectedExamId,
                ExamName = textBox1.Text.Trim(),
                ExamDate = dtpExamDate.Value
            };

            controller.UpdateExam(updatedExam);
            LoadExams();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedExamId == 0)
            {
                MessageBox.Show("Please select an exam to delete.");
                return;
            }

            controller.DeleteExam(selectedExamId);
            LoadExams();
            ClearForm();
        }

        private void dgvExams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                selectedExamId = Convert.ToInt32(selectedRow.Cells["ExamId"].Value);
                textBox1.Text = selectedRow.Cells["ExamName"].Value.ToString();
                dtpExamDate.Value = Convert.ToDateTime(selectedRow.Cells["ExamDate"].Value);
            }
        }

        private void ClearForm()
        {
            selectedExamId = 0;
            textBox1.Clear();
            dtpExamDate.Value = DateTime.Now;
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {

        }
    }
}

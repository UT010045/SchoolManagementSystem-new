using System;
using System.Windows.Forms;
using SchoolManagementSystem.Controllers;
using SchoolManagementSystem.Models;
using System.Collections.Generic;

namespace SchoolManagementSystem.Views
{
    public partial class SubjectForm : Form
    {
        private SubjectController subjectController = new SubjectController();
        private int selectedSubjectId = 0;

        public SubjectForm()
        {
            InitializeComponent();
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            List<Subject> subjects = SubjectController.GetAllSubjects();
            dgvSubjects.DataSource = null; 
            dgvSubjects.DataSource = subjects;
            dgvSubjects.Columns["SubjectId"].HeaderText = "ID";
            dgvSubjects.Columns["SubjectName"].HeaderText = "Subject Name";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Please enter subject name.");
                return;
            }

            Subject newSubject = new Subject
            {
                SubjectName = txtSubject.Text.Trim()
            };

            subjectController.AddSubject(newSubject);
            ClearForm();
            LoadSubjects();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId == 0)
            {
                MessageBox.Show("Please select a subject to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Please enter subject name.");
                return;
            }

            Subject updatedSubject = new Subject
            {
                SubjectId = selectedSubjectId,
                SubjectName = txtSubject.Text.Trim()
            };

            subjectController.UpdateSubject(updatedSubject);
            ClearForm();
            LoadSubjects();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId == 0)
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this subject?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                subjectController.DeleteSubject(selectedSubjectId);
                ClearForm();
                LoadSubjects();
            }
        }

        private void dgvSubjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSubjects.CurrentRow != null && dgvSubjects.CurrentRow.Index >= 0)
            {
                Subject selected = dgvSubjects.CurrentRow.DataBoundItem as Subject;
                if (selected != null)
                {
                    selectedSubjectId = selected.SubjectId;
                    txtSubject.Text = selected.SubjectName;
                }
            }
        }

        private void ClearForm()
        {
            selectedSubjectId = 0;
            txtSubject.Clear();
            dgvSubjects.ClearSelection();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {

        }
    }
}

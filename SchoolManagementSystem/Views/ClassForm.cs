using SchoolManagementSystem.Controllers;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolManagementSystem.Views
{
    public partial class ClassForm : Form
    {
        private ClassController controller = new ClassController();
        private int selectedClassId = 0;

        public ClassForm()
        {
            InitializeComponent();
            LoadClasses();
        }

        private void LoadClasses()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = controller.GetAllClasses();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Class cls = new Class
            {
                ClassName = txtClassName.Text,
                Section = textBox2.Text
            };

            controller.AddClass(cls);
            LoadClasses();
            ClearFields();
        }

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedClassId = Convert.ToInt32(row.Cells["ClassId"].Value);
                txtClassName.Text = row.Cells["ClassName"].Value.ToString();
                textBox2.Text = row.Cells["Section"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var classList = controller.GetAllClasses();
            Class cls = classList.Find(c => c.ClassId == selectedClassId);
            if (cls != null)
            {
                cls.ClassName = txtClassName.Text;
                cls.Section = textBox2.Text;
                LoadClasses();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var classList = controller.GetAllClasses();
            Class cls = classList.Find(c => c.ClassId == selectedClassId);
            if (cls != null)
            {
                classList.Remove(cls);
                LoadClasses();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtClassName.Text = "";
            textBox2.Text = "";
            selectedClassId = 0;
        }
    }
}

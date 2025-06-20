using System;
using System.Windows.Forms;
using SchoolManagementSystem.Views; // Make sure to include this

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
            
            StudentForm studentForm = new StudentForm();
            studentForm.Show();
            
        }
    }
}

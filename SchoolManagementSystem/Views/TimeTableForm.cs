using System;
using System.Windows.Forms;
using SchoolManagementSystem.Controllers;
using SchoolManagementSystem.Models;
using System.Collections.Generic;

namespace SchoolManagementSystem.Views
{
    public partial class TimetableForm : Form
    {
        public TimetableForm()
        {
            InitializeComponent();
            LoadClassData();
            LoadSubjectData();
            LoadTeacherData();
            LoadDayOptions();
        }

        private void LoadClassData()
        {

            ClassController classController = new ClassController();
            var classList = classController.GetAllClasses();
            comboBoxClass.DataSource = classList;
            comboBoxClass.DisplayMember = "ClassName";
            comboBoxClass.ValueMember = "ClassId";
        }

        private void LoadSubjectData()
        {
            SubjectController SubjectController = new SubjectController();
            var subjectList = SubjectController.GetAllSubjects();
            comboBoxSubject.DataSource = subjectList;
            comboBoxSubject.DisplayMember = "SubjectName";
            comboBoxSubject.ValueMember = "SubjectId";
        }

        private void LoadTeacherData()
        {
         
            var teacherList = TeacherController.GetAllTeachers();
            comboBoxTeacher.DataSource = teacherList;
            comboBoxTeacher.DisplayMember = "Name";
            comboBoxTeacher.ValueMember = "TeacherId";
        }

        private void LoadDayOptions()
        {
            comboBoxDay.Items.Add("Monday");
            comboBoxDay.Items.Add("Tuesday");
            comboBoxDay.Items.Add("Wednesday");
            comboBoxDay.Items.Add("Thursday");
            comboBoxDay.Items.Add("Friday");
            comboBoxDay.Items.Add("Saturday");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxClass.SelectedValue == null ||
                comboBoxSubject.SelectedValue == null ||
                comboBoxTeacher.SelectedValue == null ||
                string.IsNullOrEmpty(comboBoxDay.Text) ||
                string.IsNullOrEmpty(textBoxStartTime.Text) ||
                string.IsNullOrEmpty(textBoxEndTime.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            Timetable timetable = new Timetable
            {
                ClassId = Convert.ToInt32(comboBoxClass.SelectedValue),
                SubjectId = Convert.ToInt32(comboBoxSubject.SelectedValue),
                TeacherId = Convert.ToInt32(comboBoxTeacher.SelectedValue),
                Day = comboBoxDay.Text,
                StartTime = textBoxStartTime.Text,
                EndTime = textBoxEndTime.Text
            };

            TimetableController.AddTimetable(timetable);
            MessageBox.Show("Timetable added successfully!");

            comboBoxClass.SelectedIndex = -1;
            comboBoxSubject.SelectedIndex = -1;
            comboBoxTeacher.SelectedIndex = -1;
            comboBoxDay.SelectedIndex = -1;
            textBoxStartTime.Clear();
            textBoxEndTime.Clear();
        }

    }
}


using Microsoft.Msagl.Drawing;
using SprintTrackerBasic.Tasks;
using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SprintTrackerBasic
{
    public partial class TaskCreator : Form
    {
        private TaskCreator parent;
        private string taskName = "";
        private DateTime dueDate;
        private string desc = "";
        private List<Users.TeamMember> assigned = new List<Users.TeamMember>();
        private List<TaskAbs> subTask = new List<TaskAbs>();
        private List<Issue> issues = new List<Issue>();
        ViewOrganizer vo = ViewOrganizer.GetInstance();
        private ToDoView todoview;

        private TaskAbs.Category currState;
        private bool isUrgent = false;
        private bool isMeeting = false;

        public TaskCreator(ToDoView tdv)
        {
            InitializeComponent();
            InitializeDateDropdown();
            todoview = tdv;
            InitializeEventHandlers();
        }

        public TaskCreator(TaskCreator parent)
        {
            InitializeComponent();
            InitializeDateDropdown();
            this.parent = parent;
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            radioButton1.CheckedChanged += ProgressRadioButton_CheckedChanged; // todo
            radioButton2.CheckedChanged += ProgressRadioButton_CheckedChanged; // doing
            radioButton3.CheckedChanged += ProgressRadioButton_CheckedChanged; // done

            // urgent
            radioButton4.CheckedChanged += IsUrgentRadioButton_CheckedChanged; // yes
            radioButton5.CheckedChanged += IsUrgentRadioButton_CheckedChanged; // no

            // meeting
            radioButton6.CheckedChanged += IsMeetingRadioButton_CheckedChanged; // yes
            radioButton7.CheckedChanged += IsMeetingRadioButton_CheckedChanged; // no

        }

        private void ProgressRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = (RadioButton)sender;

            // Ensure only the selected radio button is checked
            if (selectedRadioButton.Checked)
            {
                if (selectedRadioButton == radioButton1)
                {
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    currState = TaskAbs.Category.Todo;
                }
                else if (selectedRadioButton == radioButton2)
                {
                    radioButton1.Checked = false;
                    radioButton3.Checked = false;
                    currState = TaskAbs.Category.Doing;
                }
                else if (selectedRadioButton == radioButton3)
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    currState = TaskAbs.Category.Done;
                }
            }
        }

        private void IsUrgentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = (RadioButton)sender;

            // Ensure only the selected radio button is checked
            if (selectedRadioButton.Checked)
            {
                if (selectedRadioButton == radioButton4)
                {
                    radioButton5.Checked = false;
                    isUrgent = true;
                }
                else if (selectedRadioButton == radioButton5)
                {
                    radioButton4.Checked = false;
                }
            }
        }

        private void IsMeetingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = (RadioButton)sender;

            // Ensure only the selected radio button is checked
            if (selectedRadioButton.Checked)
            {
                if (selectedRadioButton == radioButton6)
                {
                    radioButton7.Checked = false;
                    isMeeting = true;
                }
                else if (selectedRadioButton == radioButton7)
                {
                    radioButton6.Checked = false;
                }
            }
        }

        private void InitializeDateDropdown()
        {
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            DateTime currentDate = DateTime.Now;
            DateTime pastMonth = currentDate.AddDays(-30);
            for (int i = 0; i < 60; i++)
            {
                DateTime dateToAdd = pastMonth.AddDays(i);
                comboBox2.Items.Add(dateToAdd.ToShortDateString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            taskName = textBox1.Text;
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(comboBox2.SelectedItem.ToString(), out DateTime selectedDate))
            {
                dueDate = selectedDate;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            desc = textBox3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AssignUser au = new AssignUser(this);
            this.Enabled = false;
            au.ShowDialog();
            this.Enabled = true;
        }

        public void AddingUser(TeamMember m)
        {
            if (!assigned.Contains(m))
            {
                listBox1.Items.Add("Name: " + m.name + ", Team: " + m.assignedTeam.GetName());
                assigned.Add(m);
            }
        }
        public void AddIssue(Issue issue)
        {
            issues.Add(issue);
        }


        //create task button
        private void button3_Click(object sender, EventArgs e)
        {
            TaskAbs task = vo.ParseData(taskName, dueDate, desc, assigned, subTask, currState);
            if (parent == null)
            {
                vo.AddTasks(task);

                todoview.AddingTask(task);
                todoview.AddTaskToTreeView(task);
            }
            else
            {
                parent.subTask.Add(task);
            }
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TaskCreator tc = new TaskCreator(this);
            this.Enabled = false;
            tc.ShowDialog();
            this.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Issues i = new Issues(this);
            this.Enabled = false;
            i.ShowDialog();
            this.Enabled = true;
        }
    }
}

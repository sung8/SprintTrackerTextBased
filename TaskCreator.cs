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

        public TaskCreator(ToDoView tdv)
        {
            InitializeComponent();
            InitializeDateDropdown();
            todoview = tdv;
        }

        public TaskCreator(TaskCreator parent)
        {
            InitializeComponent();
            InitializeDateDropdown();
            this.parent = parent;
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
            TaskAbs task = vo.ParseData(taskName, dueDate, desc, assigned, subTask);
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

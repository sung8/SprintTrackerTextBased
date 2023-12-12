using SprintTrackerBasic.Builder;
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
    public partial class TaskEdit : Form
    {
        TaskAbs taskToEdit;

        private TaskEdit parent;
        private string taskName;
        private DateTime dueDate;
        private string desc;
        private List<TaskAbs> subTask = new List<TaskAbs>();
        private List<Issue> issues = new List<Issue>();
        ViewOrganizer vo = ViewOrganizer.GetInstance();

        private TaskAbs.Category currState;
        private bool isUrgent = false;
        private bool isMeeting = false;
        TaskInfo taskInfo;
        public TaskEdit(TaskAbs task, TaskInfo ti)
        {
            InitializeComponent();
            this.taskToEdit = task;
            taskName = task.GetName();
            dueDate = task.GetDueDate();
            desc = task.GetDesc();
            InitializeDateDropdown();
            LoadData();
            this.taskInfo = ti;
        }

        /*public TaskEdit(TaskEdit parent)
        {
            InitializeComponent();
            this.parent = parent;
            InitializeDateDropdown();
            LoadData();
        }*/

        private void LoadData()
        {
            textBox1.Text = taskToEdit.GetName();
            //comboBox2.Text = taskToEdit.GetDueDate().ToString();
            // Find the index of the due date in the combo box items
            int selectedIndex = comboBox2.FindStringExact(taskToEdit.GetDueDate().ToShortDateString());
            // Set the selected index
            comboBox2.SelectedIndex = selectedIndex;
            if (taskToEdit.GetCategory() == TaskAbs.Category.Todo)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
            else if (taskToEdit.GetCategory() == TaskAbs.Category.Doing)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
                radioButton3.Checked = false;
            }
            else if (taskToEdit.GetCategory() == TaskAbs.Category.Done)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = true;
            }
            textBox3.Text = taskToEdit.GetDesc();
            InitializeEventHandlers();
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

        public void AddIssue(Issue issue)
        {
            issues.Add(issue);
        }

        // save changes 
        private void button3_1_Click(object sender, MouseEventArgs e)
        {
            taskToEdit.SetName(taskName);
            taskToEdit.SetDueDate(dueDate);
            taskToEdit.SetDesc(desc);
            taskToEdit.SetCategory(currState);
            taskInfo.Refresh();
            this.Close();
        }

        // add subtask
        private void button1_1_Click(object sender, EventArgs e)
        {
            TaskCreator te = new TaskCreator(this);
            this.Enabled = false;
            te.ShowDialog();
            this.Enabled = true;
        }

        // add issue
        private void button2_1_Click(object sender, EventArgs e)
        {
            //TaskCreator te = new TaskCreator(taskToEdit);
            Issues i = new Issues(this);
            this.Enabled = false;
            i.ShowDialog();
            this.Enabled = true;
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

        private void button3_1_Click(object sender, EventArgs e)
        {
            if (taskToEdit is TaskComposite)
            {
                TaskComposite taskComp = (TaskComposite)taskToEdit;
                foreach (TaskAbs subtask in subTask)
                {
                    taskComp.GetSubtasks().Add(subtask);
                }
                foreach (Issue issue in issues)
                {
                    taskComp.AddIssue(issue);
                }

            }
            else
            {
                if (subTask.Count != 0)
                {
                    //create a task composite based off of the original task 
                    TaskBuilderIF tb = TaskBuilderAbs.GetTaskBuilder("composite");
                    List<TeamMember> memb = new List<TeamMember>();
                    memb.Add(taskToEdit.GetAssignedMember());
                    //switches id 
                    var task = tb
                     .SetTaskName(taskToEdit.GetName())
                     .SetDueDate(taskToEdit.GetDueDate())
                     .SetDescription(taskToEdit.GetDesc())
                     .AddAssignedTeamMember(memb)
                     .AddChildren(subTask)
                     .SetCategory(currState)
                     .Build();

                    task.issues = taskToEdit.issues;
                    foreach (Issue issue in issues)
                    {

                        task.AddIssue(issue);
                    }
                    taskInfo.SetCurrTask(task);


                    if (vo.GetParentEdited() != null)
                    {

                        vo.GetParentEdited().AddChild(task);
                        vo.GetParentEdited().RemoveChild(taskToEdit);
                    }
                    else
                    {
                        //remove original non composite task from the view organizer
                        vo.GetAllCurrentTasks().Add(task);
                        vo.GetAllCurrentTasks().Remove(taskToEdit);
                    }

                    vo.SetParentEdited();  //nulls the parent field in vo to be ready for the next edit
                }
                else
                {
                    foreach (Issue issue in issues)
                    {

                        taskToEdit.AddIssue(issue);
                    }
                }
            }
        }

        public List<TaskAbs> GetTaskList()
        {
            return subTask;
        }
    }
}

using Microsoft.Msagl.Core.Geometry;
using Microsoft.VisualBasic;
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
using static SprintTrackerBasic.Tasks.TaskAbs;
using static System.Windows.Forms.DataFormats;

namespace SprintTrackerBasic
{
    public partial class ToDoView : Form
    {

        public ToDoView()
        {
            InitializeComponent();
        }


        // "New Task" button
        private void button1_Click(object sender, EventArgs e)
        {
            TaskCreator tc = new TaskCreator(this);
            this.Enabled = false;
            tc.ShowDialog();
            this.Enabled = true;

        }

        // "Add User" button
        private void button2_Click(object sender, EventArgs e)
        {
            AddUser ad = new AddUser();
            this.Enabled = false;
            ad.ShowDialog();
            this.Enabled = true;
        }

        public void AddingTask(TaskAbs ta)
        {
            //listBox1.Items.Add(ta.GetName());
        }

        /*public void AddTaskToTreeView(TaskAbs task, TreeNode parentNode = null)
        {
            TreeNode currentNode = new TreeNode(task.GetName());

            if (parentNode != null)
            {
                parentNode.Nodes.Add(currentNode);
            }
            else
            {
                treeView1.Nodes.Add(currentNode);
            }
            if (task is TaskComposite taskComposite)
            {
                foreach (TaskAbs subtask in taskComposite.GetSubtasks())
                {
                    AddTaskToTreeView(subtask, currentNode);
                }
            }
        }*/

        public void AddTaskToTreeView(TaskAbs task, TreeNode parentNode = null)
        {
            TreeNode currentNode = new TreeNode(task.GetName());

            if (parentNode != null)
            {
                parentNode.Nodes.Add(currentNode);
            }
            else
            {
                // Determine which TreeView to add the task based on its Category
                if (task.GetCategory() == Category.Todo)
                {
                    treeView1.Nodes.Add(currentNode);
                }
                else if (task.GetCategory() == Category.Doing)
                {
                    treeView2.Nodes.Add(currentNode);
                }
                else if (task.GetCategory() == Category.Done)
                {
                    treeView3.Nodes.Add(currentNode);
                }
            }

            if (task is TaskComposite taskComposite)
            {
                foreach (TaskAbs subtask in taskComposite.GetSubtasks())
                {
                    AddTaskToTreeView(subtask, currentNode);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            CalendarView cv = new CalendarView();
            cv.FormClosed += (s, args) => this.Show();
            this.Hide();
            cv.Show();

        }
    }
}

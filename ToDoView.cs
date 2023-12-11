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
            ColorNodesInAllTreeViews();
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

        /*        public void AddingTask(TaskAbs ta)
                {
                    //listBox1.Items.Add(ta.GetName());
                }*/

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
            TreeNode currentNode = new TreeNode(task.GetId() + ":" + task.GetName());

            if (parentNode != null)
            {
                parentNode.Nodes.Add(currentNode);
            }
            else
            {
                ViewOrganizer vo = ViewOrganizer.GetInstance();
                vo.AddByCategory(task);
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

        /// CHANGE COLOR OF TREE NODES (not implemented yet)
        private void ColorNodesInTreeView(TreeView treeView)
        {
            foreach (TreeNode rootNode in treeView.Nodes)
            {
                ColorNodes(rootNode);
            }
        }

        private void ColorNodes(TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                ColorNodes(childNode);

                if (childNode.Tag is TaskAbs task && task.IsUrgent())
                {
                    childNode.BackColor = Color.Red; // Set the desired color
                }
                else
                {
                    childNode.BackColor = Color.White; // Reset to default color
                }
            }
        }

        // Call this method for each TreeView
        private void ColorNodesInAllTreeViews()
        {
            ColorNodesInTreeView(treeView1);
            ColorNodesInTreeView(treeView2);
            ColorNodesInTreeView(treeView3);

        }
        /// END OF CHANGE COLOR OF TREE NODES (not implemented yet)

        // calendar view
        private void button3_Click(object sender, EventArgs e)
        {
            CalendarView cv = new CalendarView();
            cv.FormClosed += (s, args) => this.Show();
            this.Hide();
            cv.Show();

        }

        // notification log
        private void button4_Click(object sender, EventArgs e)
        {
            IssueNotificationLog logView = new IssueNotificationLog();
            logView.FormClosed += (s, args) => this.Show();
            this.Hide();
            logView.Show();
        }

        private void processTreeView_NodeDoubleClick(string nodeText)
        {
            // Find the index of the ':' character
            int colonIndex = nodeText.IndexOf(':');

            string result = "";

            // Check if the colon exists in the string
            if (colonIndex != -1)
            {
                // Extract the substring before the colon
                result = nodeText.Substring(0, colonIndex);
            }

            int id = int.Parse(result);

            ViewOrganizer vo = ViewOrganizer.GetInstance();

            TaskAbs currtask = vo.FindTaskById(id);

            TaskInfo infoView = new TaskInfo(currtask);
            infoView.FormClosed += (s, args) => this.Show();
            this.Hide();
            infoView.Show();
        }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Check if a valid node is selected
            if (e.Node != null)
            {
                processTreeView_NodeDoubleClick(e.Node.Text);
            }
        }

        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Check if a valid node is selected
            if (e.Node != null)
            {
                processTreeView_NodeDoubleClick(e.Node.Text);
            }
        }


        private void treeView3_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Check if a valid node is selected
            if (e.Node != null)
            {
                processTreeView_NodeDoubleClick(e.Node.Text);
            }
        }

        private void ToDoView_EnabledChanged(object sender, EventArgs e)
        {
        }

        private void ToDoView_VisibleChanged(object sender, EventArgs e)
        {
            /*ViewOrganizer vo = ViewOrganizer.GetInstance();

            List<TaskAbs> tasks = vo.GetAllCurrentTasks();

            foreach (TaskAbs t in tasks)
            {
                this.AddTaskToTreeView(t);
            }*/
        }
    }
}

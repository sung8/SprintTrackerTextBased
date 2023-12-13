using SprintTrackerBasic.Tasks;
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
    public partial class CalendarView : Form
    {
        private int count = 1;
        Label[] labels = new Label[14];
        Label[] dayLabels = new Label[7];
        TreeView[] trees = new TreeView[14];
        ViewOrganizer vo = ViewOrganizer.GetInstance();
        Color urgentTaskColor = Color.Orange;

        public CalendarView()
        {
            InitializeComponent();
            foreach (Sprint sprint in vo.GetSprints())
            {
                listBox1.Items.Add("sprint " + count + ": " + sprint.GetStringDayIdsAndDates());
                count++;
            }
        }

        private void CalendarView_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 14; i++)
            {
                trees[i] = (TreeView)this.Controls.Find("treeView" + (i + 1), true)[0];
            }
            for (int i = 0; i < 14; i++)
            {
                labels[i] = (Label)this.Controls.Find("label" + (i + 1), true)[0];
            }
            for (int i = 0; i < 7; i++)
            {
                dayLabels[i] = (Label)this.Controls.Find("label" + (i + 15), true)[0];
            }

            ManipulateDateTasks();
        }
        private void ManipulateDateTasks()
        {
            DateTime currentDate = DateTime.Today;
            for (int i = 0; i < 14; i++)
            {
                labels[i].Text = currentDate.AddDays(i).ToShortDateString();
                if (i < 7)
                {
                    dayLabels[i].Text = currentDate.AddDays(i).DayOfWeek.ToString();
                }
            }
            foreach (TaskAbs task in vo.GetAllCurrentTasks())
            {
                AddTaskToTreeView(task, DateTime.Today);
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void AddTaskToTreeView(TaskAbs task, DateTime startingTime)
        {
            DateTime dueDate = task.GetDueDate();

            int index = (dueDate - startingTime).Days;

            if (index >= 0 && index < 14)
            {
                TreeView treeView = GetTreeViewForIndex(index);

                TreeNode taskNode = new TreeNode(task.GetId() + ":" + task.GetName());

                if (task is TaskComposite taskComposite)
                {

                    AddSubtasksToNode(taskComposite, taskNode.Nodes);
                }
                if (vo.CheckUrgent(task))
                {
                    taskNode.BackColor = urgentTaskColor; // Set urgent task color
                }
                treeView.Nodes.Add(taskNode);
            }
        }

        private void AddSubtasksToNode(TaskComposite taskComposite, TreeNodeCollection parentNode)
        {
            foreach (TaskAbs subtask in taskComposite.GetSubtasks())
            {
                TreeNode subtaskNode = new TreeNode(subtask.GetId() + ":" + subtask.GetName().ToString());

                if (subtask is TaskComposite nestedComposite)
                {
                    AddSubtasksToNode(nestedComposite, subtaskNode.Nodes);
                }
                if (vo.CheckUrgent(subtask))
                {
                    subtaskNode.BackColor = urgentTaskColor; // Set urgent task color
                }
                parentNode.Add(subtaskNode);
            }
        }

        /*
        private void AddTaskToTreeView(TaskAbs task)
        {
            DateTime dueDate = task.GetDueDate();
            int index = (dueDate - DateTime.Today).Days;
            if (index >= 0 && index < 14)
            {
                TreeView treeView = GetTreeViewForIndex(index);
                TreeNode taskNode = new TreeNode(task.GetName().ToString()); 
                treeView.Nodes.Add(taskNode);
            }
        }*/
        private TreeView GetTreeViewForIndex(int index)
        {
            if (index >= 0 && index < 14)
            {
                return trees[index];
            }

            return null;
        }
        public void AddSprint(Sprint sprint)
        {
            listBox1.Items.Add("sprint " + count + ": " + sprint.GetStringDayIdsAndDates());
            count++;
        }



        private void ClearTreeViews()
        {
            foreach (TreeView treeView in trees)
            {
                treeView.Nodes.Clear();
            }
        }



        //create a sprint
        private void button3_Click_1(object sender, EventArgs e)
        {
            SprintCreator sc = new SprintCreator(this);
            this.Enabled = false;
            sc.ShowDialog();
            this.Enabled = true;
        }

        private void ManipulateDateTasks(Sprint selectedSprint)
        {
            DateTime sprintStartDate = selectedSprint.GetStart();

            for (int i = 0; i < 14; i++)
            {
                labels[i].Text = sprintStartDate.AddDays(i).ToShortDateString();
                if (i < 7)
                {
                    dayLabels[i].Text = sprintStartDate.AddDays(i).DayOfWeek.ToString();
                }
            }

            ClearTreeViews();

            foreach (TaskAbs task in vo.GetAllCurrentTasks())
            {
                AddTaskToTreeView(task, sprintStartDate);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Sprint selectedSprint = vo.GetSprints()[listBox1.SelectedIndex];
                ManipulateDateTasks(selectedSprint);
            }
        }
    }
}

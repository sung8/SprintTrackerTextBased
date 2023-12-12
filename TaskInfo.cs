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
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using SprintTrackerBasic.Decorated;
using SprintTrackerBasic.Users;

namespace SprintTrackerBasic
{
    public partial class TaskInfo : Form
    {
        TaskAbs currTask;
        public TaskInfo(TaskAbs task)
        {
            InitializeComponent();
            currTask = task;
            UpdateTaskInfo();
        }

        public void UpdateTaskInfo()
        {
            // Assuming GetLogHistory returns a List<string>        curr task is null for a child 
            List<string> info = new List<string>();
            info.Add("Task ID: " + currTask.GetId().ToString());
            info.Add("Task Name: " + currTask.GetName());
            info.Add("Task Owner: " + currTask.GetAssignedMember().GetName() + " (Team Name: " + currTask.GetAssignedMember().GetAssignedTeam().GetName() + ")");
            info.Add("Category: " + currTask.GetCategory().ToString());
            info.Add("Complete By: " + currTask.GetDueDate().ToShortDateString());


            if (currTask is TaskComposite)
            {
                TaskComposite temp = (TaskComposite)currTask;
                info.Add("Subtasks: ");
                info.Add(temp.Iterate());
            }

            if (currTask is MeetingTaskDecorator)
            {
                info.Add("Meeting Time: " + ((MeetingTaskDecorator)currTask).GetMeetingTime().ToString());
                info.Add("Attendees: ");
                List<TeamMember> tempList = ((MeetingTaskDecorator)currTask).GetAttendees();
                foreach (TeamMember attendee in tempList)
                {
                    info.Add(attendee.GetName() + " (Team Name: " + attendee.GetAssignedTeam().GetName() + ")");
                }
            }
            // Convert the list of strings to a single string with line breaks
            string text = string.Join(Environment.NewLine, info);

            // Set the label text
            label1.Text = text;
        }

        public void Refresh()
        {
            UpdateTaskInfo();
        }
        public void SetCurrTask(TaskAbs task)
        {
            currTask = task;
        }

        public void GraphTask(TaskComposite rootTask)
        {

            // Create the Windows Form and viewer
            Form form = new Form();
            GViewer viewer = new GViewer();

            // Create the graph
            Graph graph = new Graph("task");

            // Recursive helper method to add nodes and edges
            AddTaskToGraph(rootTask, graph);

            // Bind and display the graph
            viewer.Graph = graph;
            form.SuspendLayout();
            viewer.Dock = DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();
            form.ShowDialog();

        }

        public void AddTaskToGraph(TaskComposite task, Graph graph)
        {

            // Add node for this task
            graph.AddNode(task.GetId().ToString());
            List<TaskAbs> temp = task.GetSubtasks();

            // Recursively add child tasks
            foreach (TaskAbs childTask in temp)
            {
                graph.AddEdge(task.GetId().ToString(), childTask.GetId().ToString());
                if (childTask is TaskComposite)
                {
                    AddTaskToGraph((TaskComposite)childTask, graph);
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Tree View
        private void button1_Click(object sender, EventArgs e)
        {
            if (currTask is TaskComposite)
            {
                GraphTask((TaskComposite)currTask);
            } else
            {
                string message = "This task has no children";
                string title = "Graphing Error";
                MessageBox.Show(message, title);
            }

        }

        // Edit
        private void button2_Click(object sender, EventArgs e)
        {
            TaskEdit editForm = new TaskEdit(currTask, this);
            this.Enabled = false;
            editForm.ShowDialog();
            this.Enabled = true;
        }
    }
}

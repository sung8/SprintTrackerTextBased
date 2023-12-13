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
        private static ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        public TaskInfo(TaskAbs task)
        {
            InitializeComponent();
            currTask = task;
            UpdateTaskInfo();
            CheckAndResizeForm();
        }

        public void UpdateTaskInfo()
        {
            List<string> info = new List<string>();
            ViewOrganizer vo = ViewOrganizer.GetInstance();
            if (vo.CheckUrgent(currTask))
            {
                info.Add("!!! URGENT TASK !!!");
            }
            // Assuming GetLogHistory returns a List<string>        curr task is null for a child 
            info.Add("Task ID: " + ((TaskAbs)currTask).GetId().ToString());
            info.Add("Task Name: " + ((TaskAbs)currTask).GetName());
            info.Add("Task Owner: " + ((TaskAbs)currTask).GetAssignedMember().GetName() + " (Team Name: " + currTask.GetAssignedMember().GetAssignedTeam().GetName() + ")");
            info.Add("Category: " + ((TaskAbs)currTask).GetCategory().ToString());
            info.Add("Complete By: " + ((TaskAbs)currTask).GetDueDate().ToShortDateString());
            //info.Add("Description: " + ((TaskAbs)currTask).GetDesc());
            string s = WrapText(((TaskAbs)currTask).GetDesc(), this.Width-20);
            info.Add("Description: " + s);
            info.Add(" ");

            if (currTask is TaskComposite)
            {
                TaskComposite temp = (TaskComposite)currTask;
                info.Add("Subtasks: ");
                info.Add(temp.Iterate());
            }

            
            TaskDecorator d = vo.GetMeeting(currTask);
            if (d is MeetingTaskDecorator)
            {
                info.Add("Meeting Time: " + ((MeetingTaskDecorator)d).GetMeetingTime().ToString());
                info.Add("Attendees: ");
                List<TeamMember> tempList = ((MeetingTaskDecorator)d).GetAttendees();
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

        // Assuming this code is inside your Form class
        private void CheckAndResizeForm()
        {
            // Check if label1 content exceeds its bounds
            if (label1.Height < TextRenderer.MeasureText(label1.Text, label1.Font).Height)
            {
                // Resize the form to accommodate the larger label
                this.Height = label1.Height + 40; // You may adjust this based on your layout
            }
        }

        private string WrapText(string inputText, int maxWidth)
        {
            string[] words = inputText.Split(' ');

            StringBuilder sb = new StringBuilder();
            int currentLineLength = 0;

            foreach (string word in words)
            {
                if (currentLineLength + word.Length + 1 <= maxWidth)
                {
                    sb.Append(word + " ");
                    currentLineLength += word.Length + 1;
                }
                else
                {
                    sb.AppendLine();
                    sb.Append(word + " ");
                    currentLineLength = word.Length + 1;
                }
            }

            return sb.ToString().TrimEnd();
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
            rwLock.EnterWriteLock();
            try
            {
                TaskEdit editForm = new TaskEdit(currTask, this);
                this.Enabled = false;
                editForm.ShowDialog();
                this.Enabled = true;
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }
    }
}

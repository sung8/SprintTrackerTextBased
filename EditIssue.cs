using SprintTrackerBasic.Observer;
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
    public partial class EditIssue : Form
    {
        private TaskAbs parentTask;
        private string newName;
        private string newDesc;
        public EditIssue(TaskAbs task)
        {
            parentTask = task;
            InitializeComponent();
            foreach (Issue i in task.GetAllIssues())
            {
                listBox2.Items.Add(i.GetName());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            newName = textBox1.Text;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                Issue selectedIssue = (Issue) parentTask.GetAllIssues()[listBox2.SelectedIndex];

                // Populate title and description textboxes
                textBox1.Text = selectedIssue.GetName();
                textBox3.Text = selectedIssue.GetDesc();
                foreach(IssueObserverIF issueOb in selectedIssue.GetSubs())
                {
                    listBox1.Items.Add(issueOb);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            newDesc = textBox3.Text;
        }
    }
}

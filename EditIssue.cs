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
        int index = -1;
        private Issue selectedIssue;
        private string newName = "";
        private string newDesc = "";
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
                selectedIssue = (Issue)parentTask.GetAllIssues()[listBox2.SelectedIndex];
                index = listBox2.SelectedIndex;
                // Populate title and description textboxes
                textBox1.Text = selectedIssue.GetName();
                textBox3.Text = selectedIssue.GetDesc();
                foreach (IssueObserverIF issueOb in selectedIssue.GetSubs())
                {
                    listBox1.Items.Add(((Users.TeamMember)issueOb).name);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            newDesc = textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (newName != "")
            {
                selectedIssue.SetName(newName);
            }
            if (newDesc != "")
            {
                selectedIssue.SetDesc(newDesc);
            }
            if (index != -1)
            {
                parentTask.GetAllIssues()[index] = selectedIssue;
            }
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void listBox1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            int index1 = listBox1.IndexFromPoint(e.Location);

            if (index1 != -1)
            {

                listBox1.Items.RemoveAt(index);
            
                selectedIssue.Unsubscribe(selectedIssue.GetSubs()[index1]);
            }
        }
    }
}

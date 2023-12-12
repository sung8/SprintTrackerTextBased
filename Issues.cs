using SprintTrackerBasic.Observer;
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
    public partial class Issues : Form
    {
        private string title;
        private string desc;
        private List<IssueObserverIF> alerted = new List<IssueObserverIF>();
        private TaskCreator tc;
        private TaskEdit te;

        public Issues(TaskEdit te)
        {
            InitializeComponent();
            this.te = te;
        }
        public Issues(TaskCreator tc)
        {
            InitializeComponent();
            this.tc = tc;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            title = textBox1.Text;
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
            if (!alerted.Contains(m))
            {
                listBox1.Items.Add("Name: " + m.name + ", Team: " + m.assignedTeam.GetName());
                alerted.Add(m);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tasks.Issue.Status status = Tasks.Issue.Status.New;
            Tasks.Issue issue = new Tasks.Issue(title, desc, status);
            issue.SubscribeMultiple(alerted);      //subscribe those members to the issue
            if (tc != null)
            {
                tc.AddIssue(issue);
            }

            else
            {
                te.AddIssue(issue);
            }
       
            this.Close();
        }
    }
}

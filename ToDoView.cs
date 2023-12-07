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
    public partial class ToDoView : Form
    {
        public ToDoView()
        {
            InitializeComponent();
        }

        // "New Task" button
        private void button1_Click(object sender, EventArgs e)
        {
            Tasks.Task t1 = new Tasks.Task("hello");
            listBox1.Items.Add(t1.GetId() + " " + t1.GetName());
        }

        // "Add User" button
        private void button2_Click(object sender, EventArgs e)
        {
            Team team1 = new Team(1, "dev");
            team1.Add(new TeamMember(1, "joe", team1));
            team1.Add(new TeamMember(2, "sam", team1));
            team1.Add(new TeamMember(3, "kim", team1));
            foreach (TeamMember tm in team1.members)
            {
                listBox3.Items.Add(tm.name);
            }
            listBox3.Items.Add(team1.members[0].id + " " + team1.members[0].name);
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Level 1
            var root2 = new TaskComposite("Root");

            // Level 2
            var child1 = new TaskComposite("Child 1");
            root2.AddSubtask(child1);

            // Level 3 
            var grandChild1 = new TaskComposite("GrandChild 1");
            child1.AddSubtask(grandChild1);

            // Level 4
            var greatGrandChild = new Tasks.Task("Great Grand Child");
            grandChild1.AddSubtask(greatGrandChild);

            var details = new TaskDetails((Task)root2);
            details.Show();
        }
    }
}

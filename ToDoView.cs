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
            TaskCreator tc = new TaskCreator();
            this.Enabled = false;
            tc.ShowDialog();
            this.Enabled = true;
            
            Tasks.Task t1 = new Tasks.Task("hello");
            listBox1.Items.Add(t1.GetId() + " " + t1.GetName());
        }

        // "Add User" button
        private void button2_Click(object sender, EventArgs e)
        {
            AddUser ad = new AddUser();
            this.Enabled = false;
            ad.ShowDialog();
            this.Enabled = true;

            Team team1 = new Team(1, "dev");
            team1.AddTeamMember(new TeamMember(1, "joe", team1));
            team1.AddTeamMember(new TeamMember(2, "sam", team1));
            team1.AddTeamMember(new TeamMember(3, "kim", team1));
            foreach (TeamMember tm in team1.members)
            {
                listBox3.Items.Add(tm.name);
            }
            listBox3.Items.Add(team1.members[0].id + " " + team1.members[0].name);
        }


    }
}

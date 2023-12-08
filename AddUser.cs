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
    public partial class AddUser : Form
    {
        private string memberName;
        private int memberId = -1;
        private string teamName;
        private int teamId = 1;
        
        public AddUser()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            memberName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            memberId = int.Parse(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            teamName = textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(memberName) && memberId >= 0 && !string.IsNullOrEmpty(teamName))
            {
                ViewOrganizer vo = ViewOrganizer.getInstance();
                Users.Team existingTeam = null;
                for (int i = 0; i < vo.getTeams().Count; i++)
                {
                    if (vo.getTeams()[i].name == teamName)
                    {
                        existingTeam = vo.getTeams()[i];
                        break;
                    }
                }
                if (existingTeam != null)
                {
                    existingTeam.AddTeamMember(new Users.TeamMember(memberId, memberName));
                }
                else
                {
                    Users.Team newTeam = new Users.Team(teamId, teamName);
                    newTeam.AddTeamMember(new Users.TeamMember(memberId, memberName));
                    vo.getTeams().Add(newTeam);
                   
                }
                this.Close();
            }
        }
    }
}

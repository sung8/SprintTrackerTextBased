using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SprintTrackerBasic
{
    public partial class AddUserToMeeting : Form
    {
        ViewOrganizer vo = ViewOrganizer.GetInstance();
        List<TeamMember> attendees;
        public AddUserToMeeting()
        {
            InitializeComponent();
            InitializeComboBox();
            attendees = new List<TeamMember>();
        }

        private void InitializeComboBox()
        {
            foreach (Team t in vo.GetTeams())
            {
                foreach (TeamMember tm in t.GetTeamMembers())
                {
                    comboBox1.Items.Add(tm.GetId() + " " + tm.GetName() + " (Team: " + t.GetName() + ")");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // add user from comboBox into attendees list and add the combobox string into listBox1
            // Check if an item is selected in the comboBox
            if (comboBox1.SelectedIndex != -1)
            {
                // Get the selected user from the comboBox
                string selectedUser = comboBox1.SelectedItem.ToString();

                // Extract the TeamMember ID, member name, and team name from the selected string
                Match match = Regex.Match(selectedUser, @"(\d+) (.+) \(Team: (.+)\)");

                if (match.Success)
                {
                    int memberId = int.Parse(match.Groups[1].Value);
                    string memberName = match.Groups[2].Value;
                    string teamName = match.Groups[3].Value;

                    // Find the TeamMember object in the ViewOrganizer
                    TeamMember selectedTeamMember = vo.FindTeamMember(memberId, memberName, teamName);
                    label2.Text = selectedTeamMember.GetName();

                    // Add the selected TeamMember to the attendees list
                    if (selectedTeamMember != null)
                    {
                        attendees.Add(selectedTeamMember);

                        // Add the selected string to listBox1
                        listBox1.Items.Add(selectedUser);
                    }
                }
                else
                {
                    // Handle the case where the structure of the string is not as expected
                    MessageBox.Show("Invalid format of selected user string.", "Error");
                }
            }
        }

        // remove if double clicked
        /*private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Get the selected item when double-clicked
            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                listBox1.Items.Remove(selectedItem);

                // Extract the TeamMember ID, member name, and team name from the selected string
                int memberId = int.Parse(selectedItem.Split(' ')[0]);
                string memberName = selectedItem.Split(' ')[1];
                string teamName = selectedItem.Split(' ')[4].Trim('(', ')');

                // Remove the corresponding TeamMember from the attendees list
                TeamMember removedTeamMember = attendees.Find(tm =>
                    tm.GetId() == memberId &&
                    tm.GetName() == memberName &&
                    tm.GetAssignedTeam().GetName() == teamName);

                if (removedTeamMember != null)
                {
                    attendees.Remove(removedTeamMember);
                }
            }

        }*/
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Get the selected item when double-clicked
            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                listBox1.Items.Remove(selectedItem);

                // Extract the TeamMember ID, member name, and team name from the selected string
                Match match = Regex.Match(selectedItem, @"(\d+) (.+) \(Team: (.+)\)");

                if (match.Success)
                {
                    int memberId = int.Parse(match.Groups[1].Value);
                    string memberName = match.Groups[2].Value;
                    string teamName = match.Groups[3].Value;

                    // Remove the corresponding TeamMember from the attendees list
                    TeamMember removedTeamMember = attendees.Find(tm =>
                        tm.GetId() == memberId &&
                        tm.GetName() == memberName &&
                        tm.GetAssignedTeam().GetName() == teamName);

                    if (removedTeamMember != null)
                    {
                        attendees.Remove(removedTeamMember);
                    }
                }
                else
                {
                    // Handle the case where the structure of the string is not as expected
                    MessageBox.Show("Invalid format of selected user string.", "Error");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.attendees.Count > 0)
            {
                vo.AddAttendees(attendees);
            }
            this.Close();
        }
    }
}

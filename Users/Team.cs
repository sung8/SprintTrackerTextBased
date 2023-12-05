using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Users
{
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<TeamMember> members { get; set; }

        public Team(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.members = new List<TeamMember>();
        }

        public Team(int id, string name, List<TeamMember> members)
        {
            this.id = id;
            this.name = name;
            this.members = members;
        }

        public void Add(TeamMember member)
        {
            members.Add(member);
            member.assignedTeam = this;
        }

        public void DisplayTeamMembers()
        {
            Console.WriteLine($"Team: {this.name}, TeamId: {this.id}");
            foreach (var teamMember in this.members)
            {
                Console.WriteLine($"  Team Member: {teamMember.name}, MemberId: {teamMember.id}");
            }
        }
    }
}

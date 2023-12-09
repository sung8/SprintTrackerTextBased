using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Users
{
    public class Team
    {
        private int id;
        private string name;

        private List<TeamMember> members;
        //private HashSet<TeamMember> members = new HashSet<TeamMember>();
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
        public int GetId()
        {
            return this.id;
        }
        public string GetName()
        {
            return this.name;
        }
        public void AddTeamMember(TeamMember member)
        {
            members.Add(member);
            member.assignedTeam = this;
        }
        public List<TeamMember> GetTeamMembers()
        {
            return this.members;
        }
        /*public void DisplayTeamMembers()
        {
            Console.WriteLine($"Team: {this.name}, TeamId: {this.id}");
            foreach (var teamMember in this.members)
            {
                Console.WriteLine($"  Team Member: {teamMember.name}, MemberId: {teamMember.id}");
            }
        }*/
        public string GetStringTeamMembers()
        {
            var results = $"Team: {this.name}, TeamId: {this.id}\n";

            foreach (var teamMember in this.members)
            {
                results += $"  Team Member: {teamMember.name}, MemberId: {teamMember.id}\n";
            }

            return results;
        }
        public List<string> GetStringListTeamMembers()
        {
            var results = new List<string>();

            results.Add($"Team: {this.name}, TeamId: {this.id}");

            foreach (var teamMember in this.members)
            {
                results.Add($"  Team Member: {teamMember.name}, MemberId: {teamMember.id}");
            }

            return results;
        }
        public bool IsTeamMember(TeamMember member)
        {
            return members.Contains(member);
        }
    }
}

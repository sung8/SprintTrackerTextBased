using SprintTrackerBasic.Observer;
using SprintTrackerBasic.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Users
{
    public class TeamMember : IssueObserverIF
    {
        public int id { get; set; }
        public string name { get; set; }
        public Team assignedTeam { get; set; }

        public TeamMember(int memberId, string memberName)
        {
            this.id = memberId;
            this.name = memberName;
        }

        public TeamMember(int memberId, string memberName, Team team)
        {
            this.id = memberId;
            this.name = memberName;
            this.assignedTeam = team;
        }
        public string GetName()
        {
            return this.name;
        }
        public Team GetAssignedTeam()
        {
            return this.assignedTeam;
        }
        /*public void UpdateIssue(Issue issue, string attributeName, string updatedValue)
        {
            Console.WriteLine($"{this.GetName()} received update: {issue.GetName()}'s {attributeName} is changed to {updatedValue}");
        }*/
        public string UpdateIssue(Issue issue, string attributeName, string updatedValue)
        {
            return $"{this.GetName()} received update: {issue.GetName()}'s {attributeName} is changed to {updatedValue}";
        }
        // Implement Unsubscribe method from IssueObserverIF
        public void Unsubscribe(IssueObservableIF observable)
        {
            observable.Unsubscribe(this);
        }
    }
}

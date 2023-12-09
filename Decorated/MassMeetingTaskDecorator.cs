using SprintTrackerBasic.Tasks;
using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Decorated
{
    public class MassMeetingTaskDecorator : MeetingTaskDecorator
    {
        private List<Team> attendeeTeams;

        public MassMeetingTaskDecorator(TaskAbs decoratedTask, TimeOnly meetingTime, List<Team> teams)
            : base(decoratedTask, meetingTime)
        {
            this.attendeeTeams = teams;
        }

        public override List<TeamMember> GetAttendees()
        {
            var allAttendees = new List<TeamMember>();
            foreach (var team in attendeeTeams)
            {
                allAttendees.AddRange(team.GetTeamMembers());
            }
            return allAttendees;
        }
    }
}

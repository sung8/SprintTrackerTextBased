using SprintTrackerBasic.Tasks;
using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Decorated
{
    public class SmallMeetingTaskDecorator : MeetingTaskDecorator
    {
        private List<TeamMember> attendees;

        public SmallMeetingTaskDecorator(TaskAbs decoratedTask, TimeOnly meetingTime, List<TeamMember> members)
            : base(decoratedTask, meetingTime)
        {
            this.attendees = members;
        }

        public override List<TeamMember> GetAttendees()
        {
            return this.attendees;
        }
    }
}

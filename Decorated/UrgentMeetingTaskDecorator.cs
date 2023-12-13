using SprintTrackerBasic.Tasks;
using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Decorated
{
    public class UrgentMeetingTaskDecorator : MeetingTaskDecorator
    {
        private List<TeamMember> attendees;

        public UrgentMeetingTaskDecorator(TaskAbs decoratedTask, TimeOnly meetingTime, List<TeamMember> members)
            : base(decoratedTask, meetingTime)
        {
            this.attendees = members;
        }
        public override bool IsUrgent()
        {
            return true;
        }
        public override List<TeamMember> GetAttendees()
        {
            return this.attendees;
        }
    }
}

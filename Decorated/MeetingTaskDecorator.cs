using SprintTrackerBasic.Tasks;
using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Decorated
{
    public abstract class MeetingTaskDecorator : TaskDecorator
    {
        protected TimeOnly meetingTime;

        public MeetingTaskDecorator(TaskAbs decoratedTask) : base(decoratedTask)
        {
        }

        public MeetingTaskDecorator(TaskAbs decoratedTask, TimeOnly meetingTime) : base(decoratedTask)
        {
            this.meetingTime = meetingTime;
        }

        public void SetMeetingTime(TimeOnly time)
        {
            this.meetingTime = time;
        }

        public TimeOnly GetMeetingTime()
        {
            return this.meetingTime;
        }
        public TeamMember GetHost()
        {
            return base.GetCore().GetAssignedMember();
        }

        public abstract List<TeamMember> GetAttendees();

        public override bool IsMeeting()
        {
            return true;
        }
    }
}

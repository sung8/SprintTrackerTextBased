using SprintTrackerBasic.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Builder
{
    public interface TaskBuilderIF
    {
        public static abstract TaskBuilderIF GetTaskBuilder(string info);
        public TaskAbs Build();
        public TaskBuilderIF SetTaskName(string taskName);
        public TaskBuilderIF SetDueDate(DateTime dueDate);
        public TaskBuilderIF SetDescription(string description);
        public TaskBuilderIF AddAssignedTeamMember(List<Users.TeamMember> assign);


    }
}

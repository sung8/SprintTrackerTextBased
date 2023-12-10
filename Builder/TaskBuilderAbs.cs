using SprintTrackerBasic.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Builder
{
    public abstract class TaskBuilderAbs: TaskBuilderIF
    {
        private static TaskBuilderAbs taskBuilder = new TaskBuilder();
        private static TaskBuilderAbs compositeBuilder = new CompositeTaskBuilder();
        public string name { get; set; }
        public DateTime date { get; set; }
        public string desc { get; set; }
        public List<TaskAbs> subTask { get; set; }
        public List<Users.TeamMember> assigned { get; set; }

        public TaskBuilderIF SetTaskName(string taskName)
        {
            name = taskName;
            return this;
        }

        public TaskBuilderIF SetDueDate(DateTime dueDate)
        {
            date = dueDate;
            return this;
        }

        public TaskBuilderIF SetDescription(string description)
        {
            desc = description;
            return this;
        }

        public TaskBuilderIF AddAssignedTeamMember(List<Users.TeamMember> assign)
        {
            assigned = assign;
            return this;
        }

        public static TaskBuilderIF GetTaskBuilder(string info)
        {
            if (info == "task")
                return taskBuilder;
            else
                return compositeBuilder;
        }

        public TaskBuilderIF AddChildren(List<TaskAbs> children)
        {
            subTask = children;
            return this;
        }
        public abstract TaskAbs Build();




    }
}

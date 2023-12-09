using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public class TaskComposite : TaskAbs
    {
        protected List<TaskAbs> subtasks = new List<TaskAbs>();

        public TaskComposite()
        {

        }
        public TaskComposite(TeamMember assignedPerson, string taskName, DateOnly dueDate)
        {
            this.SetId();
            this.SetName(taskName);
            this.SetAssignedMember(assignedPerson);
            this.SetDueDate(dueDate);
            this.subtasks = new List<TaskAbs>();
        }
        public TaskComposite(TeamMember assignedPerson, string taskName, DateOnly dueDate, List<TaskAbs> children)
        {
            this.SetId();
            this.SetName(taskName);
            this.SetAssignedMember(assignedPerson);
            this.SetDueDate(dueDate);
            this.subtasks = children;
        }

        public void AddChild(TaskAbs task)
        {
            //subtasks.Add(task);
            task.SetParent(this);
            subtasks.Add(task);
            task.SetId();
            /*child.Parent = this;
            Children.Add(child);*/

        }

        public void RemoveChild(TaskAbs task)
        {
            subtasks.Remove(task);
        }
        public override string Iterate()
        {
            var result = $"{GetId()} {GetName()} \n";

            foreach (var child in subtasks)
            {
                result += $"- {child.Iterate()} \n";
            }

            return result;
        }
    }
}

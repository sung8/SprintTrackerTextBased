using Microsoft.Msagl.Core.Geometry;
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

        public List<TaskAbs> GetSubtasks()
        {
            return subtasks;
        }
        public TaskComposite()
        {

        }
        public TaskComposite(TeamMember assignedPerson, string taskName, DateTime dueDate, Category progress)
        {
            this.SetId();
            this.SetName(taskName);
            this.SetAssignedMember(assignedPerson);
            this.SetDueDate(dueDate);
            this.subtasks = new List<TaskAbs>();
            this.SetCategory(progress);
        }

        public TaskComposite(TeamMember assignedPerson, string taskName, DateTime dueDate, Category progress, string desc)
        {
            this.SetId();
            this.SetName(taskName);
            this.SetAssignedMember(assignedPerson);
            this.SetDueDate(dueDate);
            this.subtasks = new List<TaskAbs>();
            this.SetCategory(progress);
            this.SetDesc(desc);
        }
        public TaskComposite(TeamMember assignedPerson, string taskName, DateTime dueDate, List<TaskAbs> children, Category progress)
        {
            this.SetId();
            this.SetName(taskName);
            this.SetAssignedMember(assignedPerson);
            this.SetDueDate(dueDate);
            this.subtasks = children;
            this.SetCategory(progress);
        }

        public TaskComposite(TeamMember assignedPerson, string taskName, DateTime dueDate, List<TaskAbs> children, Category progress, string desc)
        {
            this.SetId();
            this.SetName(taskName);
            this.SetAssignedMember(assignedPerson);
            this.SetDueDate(dueDate);
            this.subtasks = children;
            this.SetCategory(progress);
            this.SetDesc(desc);
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

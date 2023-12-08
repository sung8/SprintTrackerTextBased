using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public class Issue: TaskComponentAbs
    {
        public enum Status
        {
            New,
            Updated,
            FixInProgress,
            Resolved
        }

        private string name;
        private string desc;
        //private DateOnly dateRaised;
        private Status currStatus;
        private TaskAbs parentTask;

        public Issue(string title, string desc, Status status)
        {
            this.name = title;
            this.desc = desc;
            this.currStatus = status;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string newName)
        {
            this.name = newName;
        }

        public string GetDesc()
        {
            return this.desc;
        }

        public void SetDesc(string newDesc)
        {
            this.desc = newDesc;
        }

        public Status GetStatus()
        {
            return this.currStatus;
        }

        public void SetStatus(Status newStatus)
        {
            if (newStatus is Status.Resolved)
            {
                this.ResolveIssue();
            }
            this.currStatus = newStatus;
            //ex:
            //myIssue.SetStatus(Issue.Status.New);
        }
        public void SetParentTask(TaskAbs t)
        {
            this.parentTask = t;
        }

        public void AssignToTask(TaskAbs task)
        {
            /*this.parentTask = task;
            task.Subscribe(new TeamMember("Issue Raiser")); */
        }

        protected void ResolveIssue()
        {
            if (parentTask != null)
            {
                // Use a TeamMember object here if needed
                //parentTask.Unsubscribe(subscriber);
            }

        }
    }
}

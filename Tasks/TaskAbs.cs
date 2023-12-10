using SprintTrackerBasic.Observer;
using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public abstract class TaskAbs: DayComponentIF
    {
        private int id;
        private string name;
        private DateTime dueDate;
        private TaskAbs? parent;
        private TeamMember assignedMember;
        public List<Issue> issues { get; set; } = new List<Issue>();
        private List<IssueObserverIF> observers = new List<IssueObserverIF>();

        public TaskAbs()
        {
        }

        public TaskAbs(TeamMember assignedPerson, string taskName, DateTime dueDate)
        {
            this.assignedMember = assignedPerson;
            this.name = taskName;
            this.dueDate = dueDate;
        }

        public int GetId()
        {
            return this.id;
        }
        public void SetId()
        {
            this.id = TaskIdGenerator.GenerateId(this);
        }
        public string GetName()
        {
            return this.name;
        }
        public void SetName(string newName)
        {
            this.name = newName;
        }
        public TaskAbs? GetParent()
        {
            return this.parent;
        }
        public void SetParent(TaskAbs parent)
        {
            this.parent = parent;
        }

        public void SetDueDate(DateTime date)
        {
            this.dueDate = date;
        }
        public DateTime GetDueDate()
        {
            return this.dueDate;
        }
        public void SetAssignedMember(TeamMember assignedPerson)
        {
            this.assignedMember = assignedPerson;
        }
        public TeamMember GetAssignedMember()
        {
            return this.assignedMember;
        }

        public void AddIssue(Issue newIssueReport)
        {
            this.issues.Add(newIssueReport);
            newIssueReport.SetParentTask(this);
        }
        public void AddIssue(Issue newIssueReport, List<IssueObserverIF> members)
        {
            this.issues.Add(newIssueReport);
            newIssueReport.SetParentTask(this);

            foreach (var member in members)
            {
                observers.Add(member);
            }
        }

        public List<Issue> GetAllIssues()
        {
            // Check if the task has issues
            if (this.issues == null || this.issues.Count == 0)
            {
                // No issues, return an empty list or null based on your preference
                return new List<Issue>();  // or return null;
            }

            // Return the list of issues
            return this.issues;
        }
        public void Subscribe(IssueObserverIF observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IssueObserverIF observer)
        {
            observers.Remove(observer);
        }

        private void NotifyObservers(string attributeName, string updatedValue)
        {
            foreach (var observer in observers)
            {
                observer.UpdateIssue(GetAllIssues().Last(), attributeName, updatedValue);
            }
        }

        //public abstract void Execute();
        //public abstract void Iterate();
        public abstract string Iterate();
    }

}


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
        public enum Category
        {
            Todo,
            Doing,
            Done
        }
        private int id;
        private string name;
        private string desc;
        private DateTime dueDate;
        private TaskAbs? parent;
        private TeamMember assignedMember;
        public List<Issue> issues { get; set; } = new List<Issue>();
        private List<IssueObserverIF> observers = new List<IssueObserverIF>();
        NotificationLog notifLog = NotificationLog.GetInstance();

        private Category currState;

        public TaskAbs()
        {
        }

        public TaskAbs(TeamMember assignedPerson, string taskName, DateTime dueDate)
        {
            this.assignedMember = assignedPerson;
            this.name = taskName;
            this.dueDate = dueDate;
            if (this.GetParent() != null)
            {
                this.currState = parent.GetCategory();
            }
            this.SetId();
        }

        public TaskAbs(TeamMember assignedPerson, string taskName, DateTime dueDate, Category progress, string desc)
        {
            this.assignedMember = assignedPerson;
            this.name = taskName;
            this.dueDate = dueDate;
            this.currState = progress;
            this.desc = desc;
            this.SetId();
        }

        public void SetCategory(Category progress)
        {
            this.currState = progress;
        }

        public Category GetCategory()
        {
            return this.currState;
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
        public string GetDesc()
        {
            return this.desc;
        }
        public void SetDesc(string newDesc)
        {
            this.desc = newDesc;
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
            notifLog.AddLog("Issue raised by " + this.GetAssignedMember().GetName() + ": " + newIssueReport.GetName() + " " + newIssueReport.GetStatus().ToString() + " | Task: " + this.GetId() + " " + this.GetName());
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

        public void NotifyObservers(string attributeName, string updatedValue)
        {
            foreach (var observer in observers)
            {
                observer.UpdateIssue(GetAllIssues().Last(), attributeName, updatedValue);
            }
        }

        //public abstract void Execute();
        //public abstract void Iterate();
        public abstract string Iterate();

        public virtual bool IsUrgent()
        {
            return false;
        }
        public virtual bool IsMeeting()
        {
            return false;
        }
    }

}


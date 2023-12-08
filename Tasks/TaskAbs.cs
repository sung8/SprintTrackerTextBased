using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public abstract class TaskAbs: IDayComponent
    {
        private int id;

        public string name { get; set; }

        public TaskAbs parent { get; set; }
        public List<TaskAbs> children { get; } = new List<TaskAbs>();

        private TeamMember assignedMember;
        public List<Issue> issues { get; set; } = new List<Issue>();
        private List<Users.IObserver<string>> observers = new List<Users.IObserver<string>>();

        public TaskAbs(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public int GetId()
        {
            return this.id;
        }

        public void AddChild(TaskAbs child)
        {
            child.parent = this;
            this.children.Add(child);
        }

        public abstract void Display();


        public void SetId()
        {
            this.id = TaskIdGenerator.GenerateId(this);
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
        public void AddIssue(Issue newIssueReport)
        {
            this.issues.Add(newIssueReport);
            newIssueReport.SetParentTask(this);
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

        public void Subscribe(Users.IObserver<string> observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(Users.IObserver<string> observer)
        {
            observers.Remove(observer);
        }
        private void NotifyObservers(string data)
        {
            foreach (var observer in observers)
            {
                observer.Update(data);
            }
        }

        //public abstract void Execute();
        public abstract void Iterate();
    }

}


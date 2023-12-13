using SprintTrackerBasic.Observer;
using SprintTrackerBasic.Tasks;
using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Decorated
{
    public class TaskDecorator : TaskAbs
    {
        private TaskAbs task;

        public TaskDecorator(TaskAbs decoratedTask)
        {
            this.task = decoratedTask;
        }
        public override string Iterate()
        {
            return task.Iterate();
        }
        public TaskAbs GetCore()
        {
            return this.task;
        }
        public new int GetId()
        {
            return task.GetId();
        }
        public new string GetName()
        {
            return task.GetName();
        }
        public new void SetName(string newName)
        {
            task.SetName(newName);
        }
        public new DateTime GetDueDate()
        {
            return task.GetDueDate();
        }
        public new void SetDueDate(DateTime date)
        {
            task.SetDueDate(date);
        }
        public new TaskAbs.Category GetCategory()
        {
            return task.GetCategory();
        }
        public new void SetCategory(Category progress)
        {
            task.SetCategory(progress);
        }
        public new TeamMember GetAssignedMember()
        {
            return task.GetAssignedMember();
        }
        public new void SetAssignedMember(TeamMember assignedPerson)
        {
            task.SetAssignedMember(assignedPerson);
        }
        public new TaskAbs? GetParent()
        {
            return task.GetParent();
        }
        public new void SetParent(TaskAbs parent)
        {
            task.SetParent(parent);
        }
        public new string GetDesc()
        {
            return task.GetDesc();
        }
        public new void SetDesc(string newDesc)
        {
            task.SetDesc(newDesc);
        }
        public new void AddIssue(Issue newIssueReport)
        {
            task.AddIssue(newIssueReport);
        }
        public new void AddIssue(Issue newIssueReport, List<IssueObserverIF> members)
        {
            task.AddIssue(newIssueReport, members);
        }

        public new List<Issue> GetAllIssues()
        {
            return task.GetAllIssues();
        }
        public new void Subscribe(IssueObserverIF observer)
        {
            task.Subscribe(observer);
        }

        public new void Unsubscribe(IssueObserverIF observer)
        {
            task.Unsubscribe(observer);
        }

        private new void NotifyObservers(string attributeName, string updatedValue)
        {
            task.NotifyObservers(attributeName, updatedValue);
        }

    }
}

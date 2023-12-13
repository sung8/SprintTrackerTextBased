using SprintTrackerBasic.Observer;
using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public class Issue: TaskComponentAbs, IssueObservableIF
    {
        NotificationLog notifLog = NotificationLog.GetInstance();
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
        private List<IssueObserverIF> subscribers = new List<IssueObserverIF>();

        public List<IssueObserverIF> GetSubs()
        {
            return subscribers; 
        }

        public Issue(string title, string desc, Status status, TaskAbs task)
        {
            this.name = title;
            this.desc = desc;
            this.currStatus = status;
            this.parentTask = task;
            /*notifLog.AddLog("Issue raised by " + parentTask.GetAssignedMember().GetName() + ": " + title + " " + status.ToString() + " | Task: " + task.GetId() + " " + task.GetName());*/
        }

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

        /*public void SetName(string newName)
        {
            this.name = newName;
        }*/
        public void SetName(string newName)
        {
            string oldName = this.name; // store the old value for comparison

            // Notify observers about the name change
            if (oldName != newName)
            {
                NotifyObservers("Name", newName);
            }
            this.name = newName;
        }

        public string GetDesc()
        {
            return this.desc;
        }

        /*public void SetDesc(string newDesc)
        {
            this.desc = newDesc;
        }*/
        public void SetDesc(string newDesc)
        {
            string oldDesc = this.desc; // store the old value for comparison
            this.desc = newDesc;

            // Notify observers about the description change
            if (oldDesc != newDesc)
            {
                NotifyObservers("Description", newDesc);
            }
        }

        public Status GetStatus()
        {
            return this.currStatus;
        }

        /*public void SetStatus(Status newStatus)
        {
            if (newStatus is Status.Resolved)
            {
                this.ResolveIssue();
            }
            this.currStatus = newStatus;
            //ex:
            //myIssue.SetStatus(Issue.Status.New);
        }*/
        public void SetParentTask(TaskAbs t)
        {
            this.parentTask = t;
        }

        public void SetStatus(Status newStatus)
        {
            if (newStatus == Status.Resolved)
            {
                // Create a copy of the subscribers list
                var subscribersCopy = new List<IssueObserverIF>(subscribers);

                // Notify observers
                NotifyObservers("Status", newStatus.ToString());

                // Unsubscribe the team members
                foreach (var subscriber in subscribersCopy)
                {
                    if (subscriber is TeamMember teamMember)
                    {
                        teamMember.Unsubscribe(this);
                    }
                }
            }

            this.currStatus = newStatus;
        }
        public string Unsubscribe(IssueObserverIF observer)
        {
            if (subscribers.Contains(observer))
            {

                subscribers.Remove(observer);

                TeamMember unsubscribedMember = observer as TeamMember;

                if (unsubscribedMember != null)
                {
                    notifLog.AddLog($"{unsubscribedMember.name} was unsubscribed from {parentTask.GetAssignedMember().GetName()}'s issue report {GetName()}");
                    return $"{unsubscribedMember.name} was unsubscribed from {parentTask.GetAssignedMember().GetName()}'s issue report {GetName()}";
                }
            }

            return "";
        }

        private void NotifyObservers(string attributeName, string updatedValue)
        {
            foreach (var observer in subscribers)
            {
                //observer.UpdateIssue(this, attributeName, updatedValue);

                notifLog.AddLog(observer.UpdateIssue(this, attributeName, updatedValue));
            }
        }

        /*public void SubscribeMultiple(List<IssueObserverIF> observers)
        {
            foreach (var observer in observers)
            {
                Subscribe(observer);
            }
        }*/
        public string SubscribeMultiple(List<IssueObserverIF> observers)
        {
            var results = "";

            foreach (var observer in observers)
            {
                results += Subscribe(observer);
            }

            //notifLog.AddLog(results);
            return results;
        }

        public string Subscribe(IssueObserverIF observer)
        {
            subscribers.Add(observer);

            if (observer is TeamMember teamMember)
            {
                notifLog.AddLog($"{teamMember.GetName()} subscribed to the issue: {GetName()}\n");
                return $"{teamMember.GetName()} subscribed to the issue: {GetName()}\n";
            }

            return "";
        }


        /*public void AlertAndUnsubscribeAll()
        {
            // Alert one last time that the issue is resolved
            NotifyObservers("Status", Status.Resolved.ToString());

            // Create a copy of the subscribers list
            var subscribersCopy = new List<IssueObserverIF>(subscribers);

            // Unsubscribe all observers
            foreach (var subscriber in subscribersCopy)
            {
                if (subscriber is TeamMember teamMember)
                {
                    teamMember.Unsubscribe(this);
                }
            }
        }*/
    }
}

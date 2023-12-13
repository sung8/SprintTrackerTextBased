using SprintTrackerBasic.Builder;
using SprintTrackerBasic.Decorated;
using SprintTrackerBasic.Tasks;
using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SprintTrackerBasic.Tasks.TaskAbs;

namespace SprintTrackerBasic
{
    public class ViewOrganizer
    {
        private List<Users.Team> teams = new List<Users.Team>();
        private List<Users.TeamMember> assigned = new List<Users.TeamMember>();
        private static ViewOrganizer instance = new ViewOrganizer();
        private List<TaskAbs> allTasks = new List<TaskAbs>();
        private List<TaskAbs> tasksTodo = new List<TaskAbs>();
        private List<TaskAbs> tasksDoing = new List<TaskAbs>();
        private List<TaskAbs> tasksDone = new List<TaskAbs>();
        private TaskComposite parentOfEdited;
        private List<Users.TeamMember> attendees = new List<Users.TeamMember>();
        private TimeOnly currMeetingTime;
        private List<TaskDecorator> urgent = new List<TaskDecorator>();
        private List<TaskDecorator> meeting = new List<TaskDecorator>();
        private List<Sprint> sprints = new List<Sprint>();

        private ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

        private ViewOrganizer() { }

        public void AddSprint(Sprint sprint)
        {
            try
            {
                rwLock.EnterWriteLock();
                sprints.Add(sprint);
            }
            finally { rwLock.ExitWriteLock(); }

        }
        public List<Sprint> GetSprints()
        {
            try
            {
                rwLock.EnterReadLock();
                return sprints;
            }
            finally { rwLock.ExitReadLock(); }
        }

        public static ViewOrganizer GetInstance()
        {
            return instance;
        }

        public List<Users.Team> GetTeams()
        {
            try
            {
                rwLock.EnterReadLock();
                return teams;
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }
        public void AddByCategory(TaskAbs task)
        {
            try
            {
                rwLock.EnterWriteLock();
                if (task.GetCategory() == TaskAbs.Category.Todo)
                {
                    tasksTodo.Add(task);
                }

                else if (task.GetCategory() == TaskAbs.Category.Doing)
                {
                    tasksDoing.Add(task);
                }
                else if (task.GetCategory() == TaskAbs.Category.Done)
                {
                    tasksDone.Add(task);
                }
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }

        public bool CheckUrgent(TaskAbs t)
        {
            try
            {
                rwLock.EnterReadLock();
                foreach (TaskDecorator d in urgent)
                {
                    if (d.GetName() == t.GetName() && d.GetId() == t.GetId() && d.GetAssignedMember() == t.GetAssignedMember())
                    {
                        return true;
                    }
                }
                return false;
            }
            finally {
                rwLock.ExitReadLock();
            }
        }

        public TaskDecorator GetMeeting(TaskAbs t)
        {
            try
            {
                rwLock.EnterReadLock();

                foreach (TaskDecorator d in meeting)
                {
                    if (d.GetName() == t.GetName() && d.GetId() == t.GetId() && d.GetAssignedMember() == t.GetAssignedMember())
                    {
                        return d;
                    }
                }
                return null;
            }
            finally { 
                rwLock.ExitReadLock(); 
            }
        }

        public void AddAttendees(List<TeamMember> tm)
        {
            try
            {
                rwLock.EnterWriteLock();
                attendees.AddRange(tm);
            }
            finally { 
                rwLock.ExitWriteLock(); 
            }
            // clear this after meeting task successfully made
        }
        public void SetNextMeetingTime(TimeOnly time)
        {
            try
            {
                rwLock.EnterWriteLock();
                this.currMeetingTime = time;
            }
            finally
            {
                rwLock.ExitWriteLock();
            }

        }

        public List<TaskAbs> GetAllCurrentTasks()
        {
            try
            {
                rwLock.EnterReadLock();
                return allTasks;
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }
        public void AddTasks(TaskAbs t)
        {
            try
            {
                rwLock.EnterWriteLock();
                allTasks.Add(t);
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }

        public TaskAbs FindTaskById(int id)
        {
            try
            {
                rwLock.EnterReadLock();
                //return allTasks.FirstOrDefault(task => task.GetId() == id);
                return FindTaskByIdRecursive(allTasks, id);
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }

        public TeamMember FindTeamMember(int memberId, string memberName, string teamName)
        {
            try
            {
                rwLock.EnterReadLock();
                foreach (Team team in teams)
                {
                    foreach (TeamMember teamMember in team.GetTeamMembers())
                    {
                        if (teamMember.GetId() == memberId &&
                            teamMember.GetName() == memberName &&
                            team.GetName() == teamName)
                        {
                            return teamMember; // Found a matching TeamMember
                        }
                    }
                }

                return null; // No matching TeamMember found
            }
            finally
            {
                rwLock.ExitReadLock();
            }
            /*TeamMember foundTeamMember = assigned.Find(tm =>
                tm.GetId() == memberId &&
                tm.GetName() == memberName &&
                tm.GetAssignedTeam().GetName() == teamName);

            return foundTeamMember;*/

            /*return assigned.FirstOrDefault(tm =>
                tm.GetId() == memberId &&
                tm.GetName() == memberName &&
                tm.GetAssignedTeam().GetName() == teamName);*/
        }

        //allowing for subtask info view
        private TaskAbs FindTaskByIdRecursive(IEnumerable<TaskAbs> tasks, int id, TaskComposite parent = null)
        {
            
            foreach (var task in tasks)
            {
                if (task.GetId() == id)
                {
                    parentOfEdited = parent;
                    return task;
                }

                if (task is TaskComposite taskComposite)
                {
                    var foundInSubtasks = FindTaskByIdRecursive(taskComposite.GetSubtasks(), id, taskComposite);
                    if (foundInSubtasks != null)
                    {
                        return foundInSubtasks;
                    }
                }
            }

            return null;
        }

        public TaskComposite GetParentEdited()
        {
            try
            {
                rwLock.EnterReadLock();
                return parentOfEdited;
            }
            finally { 
                rwLock.ExitReadLock();
            }
        }
        public void SetParentEdited()
        {
            try
            {
                rwLock.EnterWriteLock();
                parentOfEdited = null;
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }

        /*public void SortTodoViewTasks()
        {
            // Categorize tasks using LINQ
            tasksTodo.AddRange(allTasks.Where(task => task.GetCategory() == Category.Todo));
            tasksDoing.AddRange(allTasks.Where(task => task.GetCategory() == Category.Doing));
            tasksDone.AddRange(allTasks.Where(task => task.GetCategory() == Category.Done));
        }*/

        /*
        private string taskName = "";
        private DateTime dueDate;
        private string desc ="";
        private List<Users.TeamMember> assigned = new List<Users.TeamMember>();
        private List<TaskAbs> subTask = new List<TaskAbs>();
        */

        //public TaskAbs ParseData(string tn, DateTime dd, string d, List<TeamMember> a, List<TaskAbs> ta, TaskAbs.Category currState)
        public TaskAbs ParseData(string tn, DateTime dd, string d, List<TeamMember> a, List<TaskAbs> ta, TaskAbs.Category currState, bool isUrgent, bool isMeeting)
        {
            try
            {
                rwLock.EnterReadLock();
                TaskAbs temp;

                if (ta.Count == 0)
                {
                    TaskBuilderIF tb = TaskBuilderAbs.GetTaskBuilder("task");
                    var task = tb
                     .SetTaskName(tn)
                     .SetDueDate(dd)
                     .SetDescription(d)
                     .AddAssignedTeamMember(a)
                     .SetCategory(currState)
                     .Build();

                    temp = task;
                }
                else
                {
                    TaskBuilderIF tb = TaskBuilderAbs.GetTaskBuilder("composite");
                    var task = tb
                     .SetTaskName(tn)
                     .SetDueDate(dd)
                     .SetDescription(d)
                     .AddAssignedTeamMember(a)
                     .AddChildren(ta)
                     .SetCategory(currState)
                     .Build();
                    temp = task;
                }
                if (isUrgent && isMeeting)
                {
                    handleWrapping(temp, isUrgent);

                }
                else if (isUrgent)
                {
                    handleWrapping(temp);
                }
                else if (isMeeting)
                {
                    handleWrapping(temp, isUrgent);
                }
                return temp;
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }

        // meeting task wrapper handler
        public TaskDecorator handleWrapping(TaskAbs t, bool isUrgent)
        {
            TaskDecorator temp;
            if (isUrgent)
            {
                temp = new UrgentMeetingTaskDecorator(t, currMeetingTime, attendees);
                urgent.Add(temp);
                meeting.Add(temp);
                return temp;
            }
            temp = new SmallMeetingTaskDecorator(t, currMeetingTime, attendees);
            meeting.Add(temp);
            return temp;
        }

        // urgent task wrapper handler
        public TaskDecorator handleWrapping(TaskAbs t)
        {
            TaskDecorator temp = new UrgentTaskDecorator(t);
            urgent.Add(temp);
            return temp;
        }
    }
}

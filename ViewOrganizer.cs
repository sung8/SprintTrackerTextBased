using SprintTrackerBasic.Builder;
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

        private ViewOrganizer() { }


        public static ViewOrganizer GetInstance()
        {
            return instance;
        } 

        public List<Users.Team> GetTeams()
        {
            return teams;
        }
        public void AddByCategory(TaskAbs task)
        {
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
        public void AddTasks(TaskAbs t)
        {
            allTasks.Add(t);
        }

        public TaskAbs FindTaskById(int id)
        {
            return allTasks.FirstOrDefault(task => task.GetId() == id);
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
        public TaskAbs ParseData(string tn, DateTime dd, string d, List<TeamMember> a, List<TaskAbs> ta, TaskAbs.Category currState)
        {

            if(ta.Count == 0)
            {
                TaskBuilderIF tb = TaskBuilderAbs.GetTaskBuilder("task");
                var task = tb
                 .SetTaskName(tn)
                 .SetDueDate(dd)
                 .SetDescription(d)
                 .AddAssignedTeamMember(a)
                 .SetCategory(currState)
                 .Build();
              
                return task;
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
                return task;
            }
        }

    }
}

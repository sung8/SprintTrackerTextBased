using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public class Day: SprintComponentIF
    {
        private string id;
        // either 
        // 1. date in YYYYMMDD format
        // 2. something 1 - 14
        // ... as key for hashmap in sprint

        private DateTime dueDate;
        public List<TaskComposite> rootTasks { get; } = new List<TaskComposite>();

        public Day(DateTime dueDate)
        {
            this.dueDate = dueDate;
            //this.id = dueDate.ToString("yyyyMMdd");
        }
        public void AddTask(TaskComposite task)
        {
            rootTasks.Add(task);
        }
        public string GetId()
        {
            return this.id;
        }
        public List<TaskComposite> GetPrimaryTasks()
        {
            return this.rootTasks;
        }
        public DateTime GetDate()
        {
            return this.dueDate;
        }
    }
}

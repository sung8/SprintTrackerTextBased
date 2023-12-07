using SprintTrackerBasic.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic
{
    public class Sprint
    {
        // Map of day number to Day instance  
        public Dictionary<int, Day> Days { get; } =
          new Dictionary<int, Day>();

        public Sprint()
        {
            
        }

        public void AddTask(int dayNumber, TaskComposite task)
        {
            Days[dayNumber].Tasks.Add(task.GetId(), task);
        }

        public IEnumerable<TaskComposite> GetTasksForDay(int dayNumber)
        {
            return Days[dayNumber].Tasks.Values;
        }
    }
}

using SprintTrackerBasic.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic
{
    public class Day
    {
        private DateTime date;

        // Map of root task id to task  
        public Dictionary<int, TaskComposite> Tasks { get; } =
          new Dictionary<int, TaskComposite>();

        public Day(DateTime date)
        {
            this.date = date;
        }

    }
}

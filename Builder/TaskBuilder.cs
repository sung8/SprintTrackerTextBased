using SprintTrackerBasic.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Builder
{
    public class TaskBuilder: TaskBuilderAbs
    {

        public TaskBuilder() { }



        public override TaskAbs Build()
        {
            
            return new Tasks.Task(assigned[0], name, date, currState);
        }
    }
}

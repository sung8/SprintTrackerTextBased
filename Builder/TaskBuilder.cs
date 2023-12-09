using SprintTrackerBasic.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Builder
{
    public class TaskBuilder: AbsTaskBuilder
    {

        public TaskBuilder() { }

    

        public override TaskAbs Build()
        {
            return new Tasks.Task(name);
        }
    }
}

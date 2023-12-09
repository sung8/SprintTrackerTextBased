using SprintTrackerBasic.Tasks;
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
    }
}

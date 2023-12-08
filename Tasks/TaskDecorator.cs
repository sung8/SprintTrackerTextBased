using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public class TaskDecorator
    {
        TaskAbs task;

        public TaskDecorator(TaskAbs decoratedTask)
        {
            this.task = decoratedTask;
        }
        /*public override void Iterate()
        {

        }*/
    }
}

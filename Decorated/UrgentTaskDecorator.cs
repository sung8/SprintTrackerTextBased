using SprintTrackerBasic.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Decorated
{
    public class UrgentTaskDecorator : TaskDecorator
    {
        public UrgentTaskDecorator(TaskAbs decoratedTask) : base(decoratedTask)
        {

        }
    }
}

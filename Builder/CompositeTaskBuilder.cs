using SprintTrackerBasic.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Builder
{
    public class CompositeTaskBuilder: TaskBuilderAbs
    {

        public CompositeTaskBuilder() { }
        public override TaskAbs Build()
        {
            return new Tasks.TaskComposite(assigned[0], name, date, subTask);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Builder
{
    public abstract class AbsTaskBuilder: TaskBuilderIF
    {
        private static AbsTaskBuilder taskBuilder = new TaskBuilder();
        private static AbsTaskBuilder compositeBuilder = new CompositeTaskBuilder();
        public TaskBuilderIF GetTaskBuilder(string info)
        {
            if (info == "task")
                return taskBuilder;
            else
                return compositeBuilder;
        }


    }
}

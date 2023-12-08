using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    internal class TaskIdGenerator
    {
        private static int rootTaskCounter = 0;
        private static Dictionary<int, int> childTaskCounters = new Dictionary<int, int>();

        public static int GenerateRootId()
        {
            return ++rootTaskCounter;
            //return rootTaskCounter++;
        }

        public static int GenerateId(TaskAbs task)
        {
            if (task.GetParent() == null)
            {
                // This is a root node
                return GenerateRootId();

            }
            else
            {
                // This is a child node
                return GenerateChildId(task.GetParent());
            }
        }
        public static int GenerateChildId(TaskAbs parent)
        {

            if (!childTaskCounters.ContainsKey(parent.GetId()))
            {
                childTaskCounters[parent.GetId()] = 1;
            }

            int childId = parent.GetId() * 100 + childTaskCounters[parent.GetId()]++;

            return childId;

        }
    }
}

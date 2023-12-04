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
        }

        public static int GenerateId(int parentId)
        {
            if (parentId == 0)
            {
                return GenerateRootId();

            }
            else
            {
                if (!childTaskCounters.ContainsKey(parentId))
                {
                    childTaskCounters[parentId] = 1;
                }
                return parentId * 100 + childTaskCounters[parentId]++;
            }
        }
    }
}

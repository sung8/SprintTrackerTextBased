﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Builder
{
    public interface TaskBuilderIF
    {
        public TaskBuilderIF GetTaskBuilder(string info);

    }
}

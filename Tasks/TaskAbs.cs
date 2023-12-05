using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public abstract class TaskAbs
    {
        private int id;

        public string name { get; set; }

        public TaskAbs parent { get; set; }
        public List<TaskAbs> children { get; } = new List<TaskAbs>();

        public TaskAbs(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public int GetId()
        {
            if (this.id == 0)
            {
                this.id = this.parent == null
                  ? TaskIdGenerator.GenerateRootId()
                  : TaskIdGenerator.GenerateId(this.parent.id);
            }

            return this.id;
        }

        public void AddChild(TaskAbs child)
        {
            child.parent = this;
            this.children.Add(child);
        }

        public abstract void Display();
    }
}

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

        public string Name { get; set; }

        public TaskAbs Parent { get; set; }
        public List<TaskAbs> Children { get; } = new List<TaskAbs>();

        public TaskAbs(string name)
        {
            this.Name = name;
        }

        public int GetId()
        {
            if (this.id == 0)
            {
                this.id = this.Parent == null
                  ? TaskIdGenerator.GenerateRootId()
                  : TaskIdGenerator.GenerateId(this.Parent.id);
            }

            return this.id;
        }

        public void AddChild(TaskAbs child)
        {
            child.Parent = this;
            this.Children.Add(child);
        }

        public abstract void Display();
    }
}

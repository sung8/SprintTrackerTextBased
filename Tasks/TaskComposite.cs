using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public class TaskComposite : TaskAbs, ITaskComponent
    {
        public TaskComposite(string name) : base(name) { }

        public override void Display()
        {
            Console.WriteLine($"ID: {this.GetId()}");
            Console.WriteLine($"Name: {this.name}");

            foreach (var child in this.children)
                child.Display();
        }

        public void AddSubtask(TaskAbs subTask)
        {
            this.AddChild(subTask);
        }
    }
}

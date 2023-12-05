using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public class Task : TaskAbs, ITaskComponent
    {
        public Task(string name) : base(name) { }

        public override void Display()
        {
            Console.WriteLine($"ID: {this.GetId()}");
            Console.WriteLine($"Name: {this.name}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public class Task : TaskAbs
    {
        public Task(string tname): base(tname)
        {
            this.SetId();
        }

        public override void Iterate()
        {
            // Tasks have no children - do nothing
        }

        public override void Display()
        {
            Console.WriteLine($"ID: {this.GetId()}");
            Console.WriteLine($"Name: {this.name}");
        }
    }
}

using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SprintTrackerBasic.Tasks
{
    public class Task : TaskAbs
    {
        public Task()
        {

        }
        public Task(TeamMember assignedPerson, string taskName, DateTime dueDate, Category progress)
        {
            this.SetId();
            this.SetName(taskName);
            this.SetAssignedMember(assignedPerson);
            this.SetDueDate(dueDate);
            this.SetCategory(progress);
            
        }

        public override string Iterate()
        {
            return $"{GetId()}: {GetName()} (Task)";
        }

        /*public override void Display()
        {
            Console.WriteLine($"ID: {this.GetId()}");
            Console.WriteLine($"Name: {this.name}");
        }*/
    }
}

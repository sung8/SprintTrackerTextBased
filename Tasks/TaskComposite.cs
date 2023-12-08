using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public class TaskComposite : TaskAbs
    {
        public TaskComposite(string name) : base(name) {
            this.SetId();
        }

        public override void Display()
        {
            Console.WriteLine($"ID: {this.GetId()}");
            Console.WriteLine($"Name: {this.name}");

            foreach (var child in this.children)
                child.Display();
        }

        public void AddSubTask(TaskAbs subTask)
        {
            this.AddChild(subTask);
        }

        protected List<TaskAbs> subtasks = new List<TaskAbs>();



        public void AddChild(TaskAbs task)
        {
            //subtasks.Add(task);
            task.SetParent(this);
            subtasks.Add(task);
            task.SetId();
            /*child.Parent = this;
            Children.Add(child);*/

        }

        public void RemoveChild(TaskAbs task)
        {
            subtasks.Remove(task);
        }

        public List<TaskAbs> GetSubtasks()
        {
            return subtasks;
        }

        /*public override void Execute()
        {
            Console.WriteLine("Executing task " + this.GetId() + ": " + this.GetName());
            foreach (var task in subtasks)
            {
                task.Execute();
            }
        }*/
        public override void Iterate()
        {
            Console.WriteLine(GetId() + ": " + GetName());

            foreach (var child in subtasks)
            {
                child.Iterate();
            }
        }
    }
}

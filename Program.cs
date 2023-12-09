using SprintTrackerBasic.Tasks;

namespace SprintTrackerBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //transform console app to forms app
            Application.Run(new ToDoView());
            //////// EXAMPLE 1
            // Create root
            var root1 = new TaskComposite("Root");

            // Create two sub tasks
            var task1 = new Tasks.Task("Task 1");
            root1.AddSubTask(task1);

            var task2 = new Tasks.Task("Task 2");
            root1.AddSubTask(task2);

            // Display
            root1.Display();

            // Check IDs
            Console.WriteLine(root1.GetId()); // 1
            Console.WriteLine(task1.GetId()); // 101 
            Console.WriteLine(task2.GetId()); // 102

            //////// EXAMPLE 2

            // Level 1
            var root2 = new TaskComposite("Root");

            // Level 2
            var child1 = new TaskComposite("Child 1");
            root2.AddSubTask(child1);

            // Level 3 
            var grandChild1 = new TaskComposite("GrandChild 1");
            child1.AddSubTask(grandChild1);

            // Level 4
            var greatGrandChild = new Tasks.Task("Great Grand Child");
            grandChild1.AddSubTask(greatGrandChild);

            // Display structure
            root2.Display();

            // Output IDs
            Console.WriteLine(root2.GetId()); // 2
            Console.WriteLine(child1.GetId()); // 201
            Console.WriteLine(grandChild1.GetId()); // 20201
            Console.WriteLine(greatGrandChild.GetId()); // 2020101
        }
    }
}
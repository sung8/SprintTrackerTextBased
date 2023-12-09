using SprintTrackerBasic.Tasks;

namespace SprintTrackerBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //transform console app to forms app
            Application.Run(new ToDoView());
        }
    }
}
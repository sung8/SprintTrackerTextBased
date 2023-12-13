using SprintTrackerBasic.Tasks;
using System.Threading;
namespace SprintTrackerBasic
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //transform console app to forms app
            //Application.Run(new ToDoView());

                // Create two threads and start the application on each thread
                Thread thread1 = new Thread(new ThreadStart(StartInstance));
                Thread thread2 = new Thread(new ThreadStart(StartInstance));

                thread1.Start();
                thread2.Start();
        }

        static void StartInstance()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ToDoView());
        }
        
    }
}
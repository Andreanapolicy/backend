using ScrumBoard.ScrumBoard.Task;
using Task = ScrumBoard.ScrumBoard.Task.Task;

namespace ScrumBoard
{
    class Program
    {
        public static void Main()
        {
            ITask task = new Task("asd", "asd", 1);
            Console.WriteLine(task.Name + ' ' + task.Description + ' ' + task.Priority + ' ' + task.UUID);
        }
    }
}

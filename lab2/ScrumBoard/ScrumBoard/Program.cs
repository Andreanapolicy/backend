using ScrumBoard.ScrumBoard.Column;
using ScrumBoard.ScrumBoard.Column.ColumnFactory;
using ScrumBoard.ScrumBoard.Task;
using ScrumBoard.ScrumBoard.Task.TaskFactory;
using TaskFactory = ScrumBoard.ScrumBoard.Task.TaskFactory.TaskFactory;

namespace ScrumBoard
{
    class Program
    {
        public static void Main()
        {
            try
            {
                ITaskFactory taskFactory = new TaskFactory();
                IColumnFactory columnFactory = new ColumnFactory();

                IColumn column = columnFactory.createColumn("In Progress");
                ITask firstTask = taskFactory.createTask("Add plus to calculator", "Add plus to calculator to increase money input", TaskPriority.NORMAL);
                ITask secondTask = taskFactory.createTask("Add minus to calculator", "Add minus to calculator to increase money input", TaskPriority.NORMAL);

                Console.WriteLine(firstTask == secondTask);
                column.AddTask(firstTask);
                column.AddTask(secondTask);
                Console.WriteLine(column.GetTask(firstTask.UUID)?.Name + ' ' + column.GetTask(firstTask.UUID)?.Description);
                Console.WriteLine(column.GetAllTaskUUIDs()[0] + ' ' + column.GetAllTaskUUIDs()[1]);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

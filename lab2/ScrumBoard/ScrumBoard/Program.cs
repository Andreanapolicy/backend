using ScrumBoard.ScrumBoard.Board;
using ScrumBoard.ScrumBoard.Board.BoardFactory;
using ScrumBoard.ScrumBoard.Column;
using ScrumBoard.ScrumBoard.Column.ColumnFactory;
using ScrumBoard.ScrumBoard.Task;
using Task = ScrumBoard.ScrumBoard.Task.Task;

namespace ScrumBoard
{
    class Program
    {
        public static void Main()
        {
            try
            {
                IBoardFactory boardFactory = new BoardFactory();
                IColumnFactory columnFactory = new ColumnFactory();
                IBoard board = boardFactory.createBoard("Site Services(SS)");
                IColumn firstColumn = columnFactory.createColumn("In progress");
                ITask task = new Task("asd", "asd", TaskPriority.LOW);
                ITask task2 = new Task("asd", "asd", TaskPriority.EXTRA);
                Console.WriteLine(task.Name + ' ' + task.Description + ' ' + task.Priority + ' ' + task.UUID);
                Console.WriteLine(board.GetCountOfColumns());

                firstColumn.AddTask(task);
                firstColumn.AddTask(task2);
                Console.WriteLine(firstColumn.GetTask(task.UUID)?.Name + ' ' + firstColumn.GetTask(task.UUID)?.Description);
                Console.WriteLine(firstColumn.GetAllTaskUUIDs()[0] + ' ' + firstColumn.GetAllTaskUUIDs()[1]);
                firstColumn.RemoveTask(task2.UUID);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

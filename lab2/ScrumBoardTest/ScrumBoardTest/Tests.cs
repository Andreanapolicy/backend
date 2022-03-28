using NUnit.Framework;
using ScrumBoard.ScrumBoard.Board;
using ScrumBoard.ScrumBoard.Board.BoardFactory;
using ScrumBoard.ScrumBoard.Column;
using ScrumBoard.ScrumBoard.Column.ColumnFactory;
using ScrumBoard.ScrumBoard.Exception;
using ScrumBoard.ScrumBoard.Task;
using ScrumBoard.ScrumBoard.Task.TaskFactory;

namespace ScrumBoardTest;

[TestFixture]
public class TaskTests
{
    private ITaskFactory taskFactory;

    public TaskTests()
    {
        this.taskFactory = new TaskFactory();
    }

    [Test]
    public void TaskCreatesWithRightParams()
    {
        ITask task = taskFactory.createTask("Add plus to calculator", "Add plus to calculator to increase money input", TaskPriority.NORMAL);
        Assert.AreEqual(task.Name, "Add plus to calculator");
        Assert.AreEqual(task.Description, "Add plus to calculator to increase money input");
        Assert.AreEqual(task.Priority, TaskPriority.NORMAL);
    }

    [Test]
    public void TwoTasksIsNotEqualsBuUUID()
    {
        ITask firstTask = taskFactory.createTask("Add plus to calculator", "Add plus to calculator to increase money input", TaskPriority.NORMAL);
        ITask secondTask = taskFactory.createTask("Add minus to calculator", "Add minus to calculator to increase money input", TaskPriority.NORMAL);
        Assert.AreNotEqual(firstTask.UUID, secondTask.UUID);
    }
}

[TestFixture]
public class ColumnTests
{
    private ITaskFactory taskFactory;
    private IColumnFactory columnFactory;

    public ColumnTests()
    {
        this.taskFactory = new TaskFactory();
        this.columnFactory = new ColumnFactory();
    }

    [Test]
    public void ColumnCreatesWithRightParams()
    {
        IColumn column = columnFactory.createColumn("In Progress");
        Assert.AreEqual(column.Name, "In Progress");
        Assert.AreEqual(column.GetAllTaskUUIDs().Count, 0);
    }

    [Test]
    public void TryToAddTask()
    {
        IColumn column = columnFactory.createColumn("In Progress");
        ITask firstTask = taskFactory.createTask("Add plus to calculator", "Add plus to calculator to increase money input", TaskPriority.NORMAL);

        Assert.DoesNotThrow(() => column.AddTask(firstTask));
        Assert.AreSame(column.GetTask(firstTask.UUID), firstTask);
    }

    [Test]
    public void TryToDeleteTask()
    {
        IColumn column = columnFactory.createColumn("In Progress");
        ITask firstTask = taskFactory.createTask("Add plus to calculator", "Add plus to calculator to increase money input", TaskPriority.NORMAL);

        Assert.DoesNotThrow(() => column.AddTask(firstTask));
        Assert.AreSame(column.GetTask(firstTask.UUID), firstTask);

        Assert.DoesNotThrow(() => column.RemoveTask(firstTask.UUID));
        Assert.AreEqual(column.GetTask(firstTask.UUID), null);
    }

    [Test]
    public void TryToDeleteWrongTask()
    {
        IColumn column = columnFactory.createColumn("In Progress");
        ITask firstTask = taskFactory.createTask("Add plus to calculator", "Add plus to calculator to increase money input", TaskPriority.NORMAL);

        Assert.DoesNotThrow(() => column.AddTask(firstTask));
        Assert.AreSame(column.GetTask(firstTask.UUID), firstTask);

        Assert.Throws<TaskDoesNotExistException>(() => column.RemoveTask("asdasdada"));
    }

    [Test]
    public void TryToAddExistingTask()
    {
        IColumn column = columnFactory.createColumn("In Progress");
        ITask firstTask = taskFactory.createTask("Add plus to calculator", "Add plus to calculator to increase money input", TaskPriority.NORMAL);

        Assert.DoesNotThrow(() => column.AddTask(firstTask));
        Assert.AreSame(column.GetTask(firstTask.UUID), firstTask);

        Assert.Throws<TaskIsAlreadyExistException>(() => column.AddTask(firstTask));
    }

    [Test]
    public void TryToAddMoreThen2Tasks()
    {
        IColumn column = columnFactory.createColumn("In Progress");
        ITask firstTask = taskFactory.createTask("Add plus to calculator", "Add plus to calculator to increase money input", TaskPriority.NORMAL);
        ITask secondTask = taskFactory.createTask("Add minus to calculator", "Add minus to calculator to increase money input", TaskPriority.NORMAL);

        Assert.DoesNotThrow(() => column.AddTask(firstTask));
        Assert.AreSame(column.GetTask(firstTask.UUID), firstTask);

        Assert.DoesNotThrow(() => column.AddTask(secondTask));
        Assert.AreSame(column.GetTask(secondTask.UUID), secondTask);

        Assert.AreEqual(column.GetAllTaskUUIDs().Count, 2);
    }
}

[TestFixture]
public class BoardTests
{
    private ITaskFactory taskFactory;
    private IColumnFactory columnFactory;
    private IBoardFactory boardFactory;

    public BoardTests()
    {
        this.taskFactory = new TaskFactory();
        this.columnFactory = new ColumnFactory();
        this.boardFactory = new BoardFactory();
    }

    [Test]
    public void BoardCreatesWithRightParams()
    {
        IBoard board = boardFactory.createBoard("Site Services(SS)");
        Assert.AreEqual(board.Name, "Site Services(SS)");
        Assert.AreEqual(board.GetCountOfColumns(), 0);
        Assert.AreEqual(board.GetAllColumnUUIDs().Count, 0);
    }

    [Test]
    public void CannotAddTaskToBoardWithoutColumns()
    {
        IBoard board = boardFactory.createBoard("Site Services(SS)");
        ITask firstTask = taskFactory.createTask("Add plus to calculator", "Add plus to calculator to increase money input", TaskPriority.NORMAL);

        Assert.Throws<ColumnDoesNotExistException>(() => board.AddTask(firstTask));
    }

    [Test]
    public void AddColumnToEmptyBoard()
    {
        IBoard board = boardFactory.createBoard("Site Services(SS)");
        IColumn column = columnFactory.createColumn("In Progress");

        Assert.DoesNotThrow(() => board.AddColumn(column));
        Assert.AreSame(board.GetColumn(column.UUID), column);
        Assert.AreEqual(board.GetAllColumnUUIDs()[0], column.UUID);
        Assert.AreEqual(board.GetCountOfColumns(), 1);
    }
}

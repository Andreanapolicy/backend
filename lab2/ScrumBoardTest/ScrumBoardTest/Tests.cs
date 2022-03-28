using NUnit.Framework;
using ScrumBoard.ScrumBoard.Board;
using ScrumBoard.ScrumBoard.Board.BoardFactory;
using ScrumBoard.ScrumBoard.Column.ColumnFactory;
using ScrumBoard.ScrumBoard.Task;
using ScrumBoard.ScrumBoard.Task.TaskFactory;

namespace ScrumBoardTest;

[TestFixture]
public class Tests
{
    private ITaskFactory taskFactory;

    public Tests()
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

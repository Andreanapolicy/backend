using NUnit.Framework;
using ScrumBoard.ScrumBoard.Board;
using ScrumBoard.ScrumBoard.Board.BoardFactory;
using ScrumBoard.ScrumBoard.Column.ColumnFactory;
using ScrumBoard.ScrumBoard.Task.TaskFactory;

namespace ScrumBoardTest;

public class Tests
{
    private IBoardFactory boardFactory;
    private IColumnFactory columnFactory;
    private ITaskFactory taskFactory;

    public Tests()
    {
        this.boardFactory = new BoardFactory();
        this.columnFactory = new ColumnFactory();
        this.taskFactory = new TaskFactory();
    }

    [Test]
    public void Test1()
    {
        IBoard board = this.boardFactory.createBoard("Site Services(SS)");
        Assert.AreEqual(board.Name, "Site Services(SS)");
    }
}

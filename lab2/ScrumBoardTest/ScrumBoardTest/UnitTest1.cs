using NUnit.Framework;
using ScrumBoard.ScrumBoard.Board;

namespace ScrumBoardTest;

public class Tests
{
    [Test]
    public void Test1()
    {
        IBoard board = new Board("Site Services(SS)");
        Assert.AreEqual(board.Name, "Site Services(SS)");
    }
}

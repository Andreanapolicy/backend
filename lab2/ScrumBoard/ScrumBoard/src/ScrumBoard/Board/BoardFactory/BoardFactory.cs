namespace ScrumBoard.ScrumBoard.Board.BoardFactory;

public class BoardFactory : IBoardFactory
{
    public IBoard createBoard(string name)
    {
        return new Board(name);
    }
}

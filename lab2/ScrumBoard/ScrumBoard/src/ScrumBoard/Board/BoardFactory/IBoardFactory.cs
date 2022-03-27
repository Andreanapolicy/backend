namespace ScrumBoard.ScrumBoard.Board.BoardFactory;

public interface IBoardFactory
{
    public IBoard createBoard(string name);
}

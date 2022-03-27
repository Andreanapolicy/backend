namespace ScrumBoard.ScrumBoard.Exception;

public class ColumnDoesNotExistException : System.Exception
{
    public ColumnDoesNotExistException()
    {
    }

    public ColumnDoesNotExistException(string message)
        : base(message)
    {
    }

    public ColumnDoesNotExistException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}

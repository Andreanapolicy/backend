namespace ScrumBoard.ScrumBoard.Exception;

public class ColumnIsAlreadyExistException : System.Exception
{
    public ColumnIsAlreadyExistException()
    {
    }

    public ColumnIsAlreadyExistException(string message)
        : base(message)
    {
    }

    public ColumnIsAlreadyExistException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}

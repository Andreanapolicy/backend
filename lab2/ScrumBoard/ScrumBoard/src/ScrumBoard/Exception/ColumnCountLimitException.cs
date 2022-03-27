namespace ScrumBoard.ScrumBoard.Exception;

public class ColumnCountLimitException : System.Exception
{
    public ColumnCountLimitException()
    {
    }

    public ColumnCountLimitException(string message)
        : base(message)
    {
    }

    public ColumnCountLimitException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}

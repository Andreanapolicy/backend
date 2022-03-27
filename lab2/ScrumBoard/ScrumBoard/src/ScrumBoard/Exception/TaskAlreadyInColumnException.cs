namespace ScrumBoard.ScrumBoard.Exception;

public class TaskAlreadyInColumnException : System.Exception
{
    public TaskAlreadyInColumnException()
    {
    }

    public TaskAlreadyInColumnException(string message)
        : base(message)
    {
    }

    public TaskAlreadyInColumnException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}

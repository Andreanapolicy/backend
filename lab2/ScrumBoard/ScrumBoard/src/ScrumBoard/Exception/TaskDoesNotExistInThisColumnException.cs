namespace ScrumBoard.ScrumBoard.Exception;

public class TaskDoesNotExistInThisColumnException : System.Exception
{
    public TaskDoesNotExistInThisColumnException()
    {
    }

    public TaskDoesNotExistInThisColumnException(string message)
        : base(message)
    {
    }

    public TaskDoesNotExistInThisColumnException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}

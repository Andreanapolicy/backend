namespace ScrumBoard.ScrumBoard.Exception;

public class TaskDoesNotExistException : System.Exception
{
    public TaskDoesNotExistException()
    {
    }

    public TaskDoesNotExistException(string message)
        : base(message)
    {
    }

    public TaskDoesNotExistException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}

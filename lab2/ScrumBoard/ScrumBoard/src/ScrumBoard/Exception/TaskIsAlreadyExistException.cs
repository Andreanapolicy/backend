namespace ScrumBoard.ScrumBoard.Exception;

public class TaskIsAlreadyExistException : System.Exception
{
    public TaskIsAlreadyExistException()
    {
    }

    public TaskIsAlreadyExistException(string message)
        : base(message)
    {
    }

    public TaskIsAlreadyExistException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}

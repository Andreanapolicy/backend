namespace ScrumBoard.ScrumBoard.Task;

public interface ITask
{
    public string Name { get; set; }

    public string Description { get; set; }

    public TaskPriority Priority { get; set; }

    public string UUID { get; }
}

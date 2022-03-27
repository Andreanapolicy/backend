namespace ScrumBoard.ScrumBoard.Task;

public class Task : ITask
{
    public Task(string name, string description, int priority)
    {
        this.Name = name;
        this.Description = description;
        this.Priority = priority;
        this.UUID = Guid.NewGuid().ToString();
    }

    public string Name { get; set; }

    public string Description { get; set; }

    public int Priority { get; set; }

    public string UUID { get; }
}

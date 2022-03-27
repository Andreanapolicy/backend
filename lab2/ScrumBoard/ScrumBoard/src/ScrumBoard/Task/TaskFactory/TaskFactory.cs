namespace ScrumBoard.ScrumBoard.Task.TaskFactory;

public class TaskFactory : ITaskFactory
{
    public ITask createTask(string name, string description, TaskPriority priority)
    {
        return new Task(name, description, priority);
    }
}

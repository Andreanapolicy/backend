namespace ScrumBoard.ScrumBoard.Task.TaskFactory;

public interface ITaskFactory
{
    public ITask createTask(string name, string description, TaskPriority priority);
}

using ScrumBoard.ScrumBoard.Task;

namespace ScrumBoard.ScrumBoard.Column;

public interface IColumn
{
    public void AddTask(ITask task);

    public void RemoveTask(string taskUUID);

    public ITask? GetTask(string taskUUID);

    public List<string> GetAllTaskUUIDs();

    public string Name { get; set; }

    public string UUID { get; }
}

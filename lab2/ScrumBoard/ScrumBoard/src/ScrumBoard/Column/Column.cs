using System.Collections.ObjectModel;
using ScrumBoard.ScrumBoard.Exception;
using ScrumBoard.ScrumBoard.Task;

namespace ScrumBoard.ScrumBoard.Column;

public class Column : IColumn
{
    public Column(string name)
    {
        this.Name = name;
        this.UUID = Guid.NewGuid().ToString();
        this.Tasks = new SortedList<string, ITask>();
    }

    public void AddTask(ITask task)
    {
        if (this.Tasks.IndexOfKey(task.UUID) != -1)
        {
            throw new TaskIsAlreadyExistException("Error, this task is already in column");
        }

        this.Tasks.Add(task.UUID, task);
    }

    public void RemoveTask(string taskUUID)
    {
        int indexOfTask = this.Tasks.IndexOfKey(taskUUID);
        if (indexOfTask == -1)
        {
            throw new TaskDoesNotExistException("Error, this task does not exist in this column");
        }

        this.Tasks.RemoveAt(indexOfTask);
    }

    public ITask? GetTask(string taskUUID)
    {
        int indexOfTask = this.Tasks.IndexOfKey(taskUUID);
        if (indexOfTask == -1)
        {
            return null;
        }

        return this.Tasks.ElementAt(indexOfTask).Value;
    }

    public ReadOnlyCollection<string> GetAllTaskUUIDs()
    {
        return new ReadOnlyCollection<string>(this.Tasks.Keys);
    }

    public string Name { get; set; }

    public string UUID { get; }

    private SortedList<string, ITask> Tasks;
}

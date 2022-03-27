namespace ScrumBoard.ScrumBoard.Task;

public class TaskComparer : IComparer<ITask>
{
    public int Compare(ITask? firstTask, ITask? secondTask)
    {
        if (firstTask == null || secondTask == null)
        {
            return -1;
        }

        TaskPriority firstPriority = firstTask.Priority;
        TaskPriority secondPriority = secondTask.Priority;

        return firstPriority == secondPriority ? 0 : (firstPriority > secondPriority ? -1 : 1);
    }
}

using System.Collections.ObjectModel;
using ScrumBoard.ScrumBoard.Column;
using ScrumBoard.ScrumBoard.Task;

namespace ScrumBoard.ScrumBoard.Board;

public interface IBoard
{
    public void AddTask(ITask task);

    public void AddColumn(IColumn column);

    public void MoveTask(string taskUUID, string columnUUID);

    public void MoveColumn(string columnUUID, int position);

    public int GetCountOfColumns();

    public IColumn? GetColumn(string columnUUID);

    public ReadOnlyCollection<string> GetAllColumnUUIDs();

    public string Name { get; }

    public string UUID { get; }
}

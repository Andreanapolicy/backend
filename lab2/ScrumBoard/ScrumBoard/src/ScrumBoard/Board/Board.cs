using System.Collections.ObjectModel;
using ScrumBoard.ScrumBoard.Column;
using ScrumBoard.ScrumBoard.Exception;
using ScrumBoard.ScrumBoard.Task;

namespace ScrumBoard.ScrumBoard.Board;

public class Board : IBoard
{
    public Board(string name)
    {
        this.Name = name;
        this.UUID = Guid.NewGuid().ToString();
        this.Columns = new SortedList<IColumn, string>();
    }

    public void AddTask(ITask task)
    {
        if (IsTaskAlreadyExist(task.UUID))
        {
            throw new TaskIsAlreadyExistException("Error, this task is already exist");
        }

        if (GetCountOfColumns() == 0)
        {
            throw new ColumnDoesNotExistException("Error, there are no columns");
        }

        this.Columns.Keys[0].AddTask(task);
    }

    public void AddColumn(IColumn column)
    {
        if (IsColumnAlreadyExist(column.UUID))
        {
            throw new ColumnIsAlreadyExistException("Error, this column is already exist");
        }

        if (this.Columns.Count == COLUMN_LIMIT)
        {
            throw new ColumnCountLimitException("Error, limit of columns is " + COLUMN_LIMIT);
        }

        this.Columns.Add(column, column.UUID);
    }

    public void MoveTask(string taskUUID, string columnUUID)
    {
        if (!IsColumnAlreadyExist(columnUUID))
        {
            throw new ColumnDoesNotExistException("Error, this column does not exist");
        }

        if (!IsTaskAlreadyExist(taskUUID))
        {
            throw new TaskDoesNotExistException("Error, this task does not exist");
        }

        int indexOfColumn = this.Columns.IndexOfValue(columnUUID);

        if (this.Columns.ElementAt(indexOfColumn).Key.GetTask(taskUUID) != null)
        {
            return;
        }

        IColumn tasksColumn = GetColumnByTask(taskUUID);
        ITask? task = tasksColumn.GetTask(taskUUID);
        if (task == null)
        {
            throw new InconsistentStateException("Runtime error");
        }

        this.Columns.ElementAt(indexOfColumn).Key.AddTask(task);
        tasksColumn.RemoveTask(task.UUID);
    }

    public void MoveColumn(string columnUUID, int position) => throw new NotImplementedException();

    public int GetCountOfColumns()
    {
        return this.Columns.Count;
    }

    public IColumn? GetColumn(string columnUUID)
    {
        int indexOfColumn = this.Columns.IndexOfValue(columnUUID);
        if (indexOfColumn == -1)
        {
            return null;
        }

        return this.Columns.ElementAt(indexOfColumn).Key;
    }

    public ReadOnlyCollection<string> GetAllColumnUUIDs() => throw new NotImplementedException();

    public string Name { get; }

    public string UUID { get; }

    private bool IsTaskAlreadyExist(string taskUUID)
    {
        foreach (var columnInfo in this.Columns)
        {
            if (columnInfo.Key.GetTask(taskUUID) != null)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsColumnAlreadyExist(string columnUUID)
    {
        return this.Columns.IndexOfValue(columnUUID) != -1;
    }

    private IColumn GetColumnByTask(string taskUUID)
    {
        foreach (var columnInfo in this.Columns)
        {
            if (columnInfo.Key.GetTask(taskUUID) != null)
            {
                return columnInfo.Key;
            }
        }

        throw new InconsistentStateException("Runtime error");
    }

    private SortedList<IColumn, string> Columns;
    private const int COLUMN_LIMIT = 10;
}

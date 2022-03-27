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
        this.Columns = new List<IColumn>();
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

        this.Columns[0].AddTask(task);
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

        this.Columns.Add(column);
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

        IColumn newColumn = GetColumnByUUID(columnUUID);

        if (newColumn.GetTask(taskUUID) != null)
        {
            return;
        }

        IColumn tasksColumn = GetColumnByTask(taskUUID);
        ITask? task = tasksColumn.GetTask(taskUUID);
        if (task == null)
        {
            throw new InconsistentStateException("Runtime error");
        }

        newColumn.AddTask(task);
        tasksColumn.RemoveTask(task.UUID);
    }

    public void MoveColumn(string columnUUID, int position)
    {
        if (!IsColumnAlreadyExist(columnUUID))
        {
            throw new ColumnDoesNotExistException("Error, this column does not exist");
        }

        position = position >= this.Columns.Count ? this.Columns.Count : (position < 0 ? 0 : position);
        this.Columns.Insert(position, GetColumnByUUID(columnUUID));
    }

    public int GetCountOfColumns()
    {
        return this.Columns.Count;
    }

    public IColumn? GetColumn(string columnUUID)
    {
        try
        {
            return GetColumnByUUID(columnUUID);
        }
        catch (InconsistentStateException exception)
        {
            return null;
        }
    }

    public ReadOnlyCollection<string> GetAllColumnUUIDs()
    {
        List<string> collectionOfUUIDs = new List<string>();

        foreach (var column in Columns)
        {
            collectionOfUUIDs.Add(column.UUID);
        }

        return new ReadOnlyCollection<string>(collectionOfUUIDs);
    }

    public string Name { get; }

    public string UUID { get; }

    private bool IsTaskAlreadyExist(string taskUUID)
    {
        foreach (var columnInfo in this.Columns)
        {
            if (columnInfo.GetTask(taskUUID) != null)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsColumnAlreadyExist(string columnUUID)
    {
        try
        {
            GetColumnByUUID(columnUUID);
            return true;
        }
        catch (InconsistentStateException exception)
        {
            return false;
        }
    }

    private IColumn GetColumnByTask(string taskUUID)
    {
        foreach (var columnInfo in this.Columns)
        {
            if (columnInfo.GetTask(taskUUID) != null)
            {
                return columnInfo;
            }
        }

        throw new InconsistentStateException("Runtime error");
    }

    private IColumn GetColumnByUUID(string columnUUID)
    {
        foreach (var columnInfo in this.Columns)
        {
            if (columnInfo.UUID != columnUUID)
            {
                return columnInfo;
            }
        }

        throw new InconsistentStateException("Runtime error");
    }

    private List<IColumn> Columns;
    private const int COLUMN_LIMIT = 10;
}

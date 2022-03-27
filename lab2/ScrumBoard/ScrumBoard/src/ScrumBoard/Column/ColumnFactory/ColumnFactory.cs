namespace ScrumBoard.ScrumBoard.Column.ColumnFactory;

public class ColumnFactory : IColumnFactory
{
    public IColumn createColumn(string name)
    {
        return new Column(name);
    }
}

namespace Table2Model;

public class CustomResolver : SimpleCRUD.ITableNameResolver
{
    public string ResolveTableName(Type type)
    {
        return TableHelper.LowFirst(type.Name);
    }

}
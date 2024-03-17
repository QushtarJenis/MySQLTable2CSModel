namespace Table2Model;

public class CustomResolver : SimpleCRUD.ITableNameResolver
{
    public string ResolveTableName(Type type)
    {
        return type.Name.ToLower();
    }
}
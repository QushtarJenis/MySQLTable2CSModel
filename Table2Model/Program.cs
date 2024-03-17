global using Dapper;
using Table2Model;

SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
SimpleCRUD.SetTableNameResolver(new CustomResolver());

while (true)
{
    Option.SetOptions();
    TableHelper.WriteDatabase();
}

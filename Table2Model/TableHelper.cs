using System.Data;
using MySql.Data.MySqlClient;

namespace Table2Model;
public class TableHelper
{
    public static void WriteDatabase()
    {
        try
        {
            Option option = Utilities.GetConnectionOption();
            Dictionary<string, string> contentDic = [];
            using (var _connection = Utilities.GetOpenConnection())
            {
                DataTable tableList = _connection.GetSchema("Tables");
                if (tableList == null) return;

                foreach (DataRow row in tableList.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    string className = CupFirst(tableName);

                    string filePath = PathHelper.Combine(option.DirectoryPath, $"{className}.cs");
                    string content = GetTableContent(_connection, tableName, option);

                    if (!string.IsNullOrWhiteSpace(tableName) && !string.IsNullOrWhiteSpace(content))
                    {
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        contentDic[filePath] = content;
                    }
                }
            }

            foreach (var pair in contentDic)
            {
                string filePath = pair.Key;
                string content = pair.Value;
                if (!Directory.Exists(option.DirectoryPath)) Directory.CreateDirectory(option.DirectoryPath);
                File.WriteAllText(filePath, content);
            }
            Console.WriteLine("Successfully written on files!" + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Some error occured:");
            Console.WriteLine(ex.Message);
        }
    }

    private static string GetTableContent(MySqlConnection _connection, string tableName, Option option)
    {
        string querySql = $"SELECT COLUMN_NAME, DATA_TYPE, COLUMN_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @tableName AND TABLE_SCHEMA = @database";
        object queryObj = new { tableName, database = option.Database };

        List<Column> columnList = _connection.Query<Column>(querySql, queryObj).ToList();
        if (columnList == null || !(columnList.Count > 0)) return "";

        string className = CupFirst(tableName);
        string newLine = Environment.NewLine;
        string content = string.Empty;
        if (!string.IsNullOrWhiteSpace(option.NameSpace) && !option.NameSpace.Equals(";"))
            content += $"namespace {option.NameSpace};{newLine}{newLine}";

        content += $"public partial class {className}{newLine}";
        content += "{" + newLine;

        foreach (Column column in columnList)
        {
            content += "    " + column.ToString() + newLine;
        }

        content += "}" + newLine;
        return content;
    }

    public static string CupFirst(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;
        return char.ToUpper(input[0]) + input[1..];
    }

    public static string LowFirst(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return input;
        }
        return char.ToLower(input[0]) + input[1..];
    }

}


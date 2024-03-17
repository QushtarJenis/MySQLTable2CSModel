namespace Table2Model;
public class Utilities
{

    private static readonly string optionFilePath = "./customOption.txt";
    private static readonly Option defaultConnectionOption = new()
    {
        Server = "127.0.0.1",
        Port = "3306",
        Database = "",
        UId = "root",
        Password = "",
        Charset = "utf8mb4",
        NameSpace = "MODEL",
        DirectoryPath = PathHelper.Combine(PathHelper.GetDesktopPath(), "MODEL")
    };

    public static void SetConnectionOption(Option option)
    {
        File.WriteAllText(optionFilePath, JsonHelper.SerializeObject(option));
    }

    public static Option GetConnectionOption()
    {
        try
        {
            if (!File.Exists(optionFilePath)) return defaultConnectionOption;
            string content = File.ReadAllText(optionFilePath);
            if (string.IsNullOrWhiteSpace(content)) return defaultConnectionOption;

            return JsonHelper.DeSerializeObject<Option>(content);
        }
        catch
        {
            return defaultConnectionOption;
        }
    }

    public static string GetConnectionString()
    {
        Option option = GetConnectionOption();
        return $"server={option.Server};port={option.Port};database={option.Database};user={option.UId};password={option.Password};charset={option.Charset}";
    }

    public static MySql.Data.MySqlClient.MySqlConnection GetOpenConnection()
    {
        string connectionString = GetConnectionString();
        var connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        connection.Open();
        return connection;
    }

}
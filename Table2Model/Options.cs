namespace Table2Model;

public class Option
{
    public string Server { get; set; }
    public string Port { get; set; }
    public string Database { get; set; }
    public string UId { get; set; }
    public string Password { get; set; }
    public string Charset { get; set; }
    public string NameSpace { get; set; }
    public string DirectoryPath { get; set; }

    public static void SetOptions()
    {
        string newLine = Environment.NewLine;
    begin:
        try
        {
            Option option = Utilities.GetConnectionOption();

            Console.WriteLine($"IP: {option.Server}");
            string server = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(server)) server = option.Server;
            while (!RegexHelper.IsIP(server))
            {
                Console.WriteLine("Your IP is Incorrect!");
                Console.WriteLine("IP:");
                Console.WriteLine(option.Server);
                server = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(server)) server = option.Server;
            }
            option.Server = server;


            Console.WriteLine($"Port: {option.Port}");
            string port = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(port)) port = option.Port;
            while (string.IsNullOrWhiteSpace(port))
            {
                Console.WriteLine("User ID Can not be empty!");
                Console.WriteLine("User ID:");
                Console.WriteLine(option.Port);
                port = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(port)) port = option.Port;
            }
            option.Port = port;


            Console.WriteLine($"Database: {option.Database}");
            string database = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(database)) database = option.Database;
            while (string.IsNullOrWhiteSpace(database))
            {
                Console.WriteLine("Database Can not be empty!");
                Console.WriteLine("Database:");
                Console.WriteLine(option.Database);
                database = Console.ReadLine().Trim();
            }
            option.Database = database;


            Console.WriteLine($"User ID: {option.UId}");
            string uId = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(uId)) uId = option.UId;
            while (string.IsNullOrWhiteSpace(uId))
            {
                Console.WriteLine("User ID Can not be empty!");
                Console.WriteLine("User ID:");
                Console.WriteLine(option.UId);
                uId = Console.ReadLine().Trim();
            }
            option.UId = uId;


            Console.WriteLine($"Password: {option.Password}");
            string password = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(password)) password = option.Password;
            while (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password Can not be empty!");
                Console.WriteLine("Password:");
                Console.WriteLine(option.Password);
                password = Console.ReadLine().Trim();
            }
            option.Password = password;


            Console.WriteLine($"Charset: {option.Charset}");
            string charset = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(charset)) charset = option.Charset;
            while (string.IsNullOrWhiteSpace(charset))
            {
                Console.WriteLine("Charset Can not be empty!");
                Console.WriteLine("Charset:");
                Console.WriteLine(option.Charset);
                charset = Console.ReadLine().Trim();
            }
            option.Charset = charset;


            Console.WriteLine($"Namespace: {option.NameSpace}");
            string nameSpace = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(nameSpace)) nameSpace = option.NameSpace;
            while (string.IsNullOrWhiteSpace(nameSpace))
            {
                Console.WriteLine("Namespace not be empty!");
                Console.WriteLine("Namespace:");
                Console.WriteLine(option.Charset);
                nameSpace = Console.ReadLine().Trim();
            }
            if (nameSpace.EndsWith(';')) nameSpace = nameSpace[..^1];
            option.NameSpace = nameSpace;


            Console.WriteLine($"Folder Path: {option.DirectoryPath}");
            string directoryPath = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(directoryPath)) directoryPath = option.DirectoryPath;
            while (string.IsNullOrWhiteSpace(directoryPath))
            {
                Console.WriteLine("Folder Path Can not be empty");
                Console.WriteLine("Folder Path:");
                directoryPath = Console.ReadLine().Trim();
            }
            if (directoryPath.EndsWith('/')) directoryPath = directoryPath[..^1];
            option.DirectoryPath = directoryPath;

            Utilities.SetConnectionOption(option);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            goto begin;
        }
    }

}
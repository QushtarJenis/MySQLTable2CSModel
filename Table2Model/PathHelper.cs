namespace Table2Model;

public class PathHelper
{

    #region Combine 2 Paths +Combine(string path1, string path2)
    public static string Combine(string path1, string path2)
    {
        return path1.EndsWith('/') ? (path1 + path2) : path1 + '/' + path2;
    }
    #endregion

    #region Combine 3 Paths +Combine(string path1, string path2, string path3)
    public static string Combine(string path1, string path2, string path3)
    {
        return Combine(path1, Combine(path2, path3));
    }
    #endregion

    #region Combine 4 Paths +Combine(string path1, string path2, string path3, string path4)
    public static string Combine(string path1, string path2, string path3, string path4)
    {
        return Combine(path1, Combine(path2, path3, path4));
    }
    #endregion

    #region Combine Array Of Paths +Combine(string[] paths)
    public static string Combine(string[] paths)
    {
        string res = paths[0];

        for (int i = 1; i < paths.Length; i++)
        {
            res = Combine(res, paths[i]);
        }

        return res;
    }
    #endregion

    #region Get Desktop Path +GetDesktopPath()
    public static string GetDesktopPath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    }
    #endregion

}

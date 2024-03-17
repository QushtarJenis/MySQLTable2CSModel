using System.Text.RegularExpressions;

namespace Table2Model;
public class RegexHelper
{
    public static bool IsIP(string ip)
    {
        string Pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
        Regex check = new Regex(Pattern);
        if (string.IsNullOrEmpty(ip))
            return false;
        else
            return check.IsMatch(ip, 0);
    }

    public static bool IsEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        
        return Regex.IsMatch(email, pattern);
    }
}

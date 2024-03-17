using Newtonsoft.Json;

namespace Table2Model;
public class JsonHelper
{
    #region Convert Any Data Type To String +SerializeObject(object obj)
    public static string SerializeObject(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
    #endregion

    #region Convert String To Any Data Type +DeSerializeObject<T>(string str)
    public static T DeSerializeObject<T>(string str)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
        catch
        {
            return default;
        }
    }
    #endregion
    
}

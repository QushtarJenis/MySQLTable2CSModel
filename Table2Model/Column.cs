namespace Table2Model;

public class Column
{
    public string COLUMN_NAME { get; set; }
    public string DATA_TYPE { get; set; }
    public string COLUMN_TYPE { get; set; }

    public override string ToString()
    {
        bool isUnsigned = COLUMN_TYPE.Contains("unsigned", StringComparison.OrdinalIgnoreCase);
        return $"public {MapMySqlType2CSType(DATA_TYPE, isUnsigned)} {TableHelper.FirstChar2Upper(COLUMN_NAME)} {{ get; set; }}";
    }

    public static string MapMySqlType2CSType(string mysqlType, bool isUnsigned = false)
    {
        return mysqlType.Trim().ToLower() switch
        {
            "bigint" => isUnsigned ? "ulong" : "long",
            "binary" => "byte[]",
            "bit" => "bool", // or byte/byte[] for larger bit fields
            "blob" => "byte[]",
            "char" => "string",
            "date" => "DateTime",
            "datetime" => "DateTime",
            "decimal" => "decimal",
            "double" => "double",
            "enum" => "enum",
            "float" => "float",
            "geometry" => "byte[]",
            // "geometrycollection" => "string",
            "int" => isUnsigned ? "uint" : "int",
            "integer" => isUnsigned ? "uint" : "int",
            "json" => "string",
            // "linestring" => "___",
            "longblob" => "byte[]",
            "longtext" => "string",
            "mediumblob" => "byte[]",
            "mediumint" => "int",
            "mediumtext" => "string",
            // "multilinestring" => "___",
            // "multipoint" => "___",
            // "multipolygon" => "___",
            "numeric" => "decimal",
            // "point" => "___",
            // "polygon" => "___",
            "real" => "float",
            "set" => "string[]",
            "smallint" => isUnsigned ? "ushort" : "short",
            "text" => "string",
            "time" => "TimeSpan",
            "timestamp" => "DateTime",
            "tinyblob" => "byte[]",
            "tinyint" => isUnsigned ? "byte" : "sbyte",
            "tinytext" => "string",
            "varbinary" => "byte[]",
            "varchar" => "string",
            "year" => "int",
            "bool" => "bool",
            "boolean" => "bool",
            _ => "object"
        };
    }

}
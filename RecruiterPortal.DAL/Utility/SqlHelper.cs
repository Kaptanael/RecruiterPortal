using System.Data;

namespace RecruiterPortal.DAL.Utility
{
    public class SqlHelper
    {
        private static Dictionary<string, SqlDbType> typeMap;
        private static Dictionary<Type, SqlDbType> csharTypetoSQLDBTypeMap;
        
        static SqlHelper()
        {
            typeMap = new Dictionary<string, SqlDbType>();
            csharTypetoSQLDBTypeMap = new Dictionary<Type, SqlDbType>();

            csharTypetoSQLDBTypeMap[typeof(string)] = SqlDbType.NVarChar;
            csharTypetoSQLDBTypeMap[typeof(char[])] = SqlDbType.NVarChar;
            csharTypetoSQLDBTypeMap[typeof(byte)] = SqlDbType.TinyInt;
            csharTypetoSQLDBTypeMap[typeof(short)] = SqlDbType.SmallInt;
            csharTypetoSQLDBTypeMap[typeof(int)] = SqlDbType.Int;
            csharTypetoSQLDBTypeMap[typeof(long)] = SqlDbType.BigInt;
            csharTypetoSQLDBTypeMap[typeof(byte[])] = SqlDbType.Image;
            csharTypetoSQLDBTypeMap[typeof(byte[])] = SqlDbType.VarBinary;
            csharTypetoSQLDBTypeMap[typeof(bool)] = SqlDbType.Bit;
            csharTypetoSQLDBTypeMap[typeof(DateTime)] = SqlDbType.DateTime2;
            csharTypetoSQLDBTypeMap[typeof(DateTimeOffset)] = SqlDbType.DateTimeOffset;
            csharTypetoSQLDBTypeMap[typeof(decimal)] = SqlDbType.Money;
            csharTypetoSQLDBTypeMap[typeof(float)] = SqlDbType.Real;
            csharTypetoSQLDBTypeMap[typeof(double)] = SqlDbType.Float;
            csharTypetoSQLDBTypeMap[typeof(TimeSpan)] = SqlDbType.Time;        
            
            typeMap[("BigInt").ToLower()] = SqlDbType.BigInt;
            typeMap[("Binary").ToLower()] = SqlDbType.Binary;
            typeMap[("Bit").ToLower()] = SqlDbType.Bit;
            typeMap[("Char").ToLower()] = SqlDbType.Char;
            typeMap[("DateTime").ToLower()] = SqlDbType.DateTime;
            typeMap[("Decimal").ToLower()] = SqlDbType.Decimal;
            typeMap[("Float").ToLower()] = SqlDbType.Float;
            typeMap[("Image").ToLower()] = SqlDbType.Image;
            typeMap[("Int").ToLower()] = SqlDbType.Int;
            typeMap[("Money").ToLower()] = SqlDbType.Money;
            typeMap[("NChar").ToLower()] = SqlDbType.NChar;
            typeMap[("NText").ToLower()] = SqlDbType.NText;
            typeMap[("NVarChar").ToLower()] = SqlDbType.NVarChar;
            typeMap[("Real").ToLower()] = SqlDbType.Real;
            typeMap[("UniqueIdentifier").ToLower()] = SqlDbType.UniqueIdentifier;
            typeMap[("SmallDateTime").ToLower()] = SqlDbType.SmallDateTime;
            typeMap[("SmallInt").ToLower()] = SqlDbType.SmallInt;
            typeMap[("SmallMoney").ToLower()] = SqlDbType.SmallMoney;
            typeMap[("Text").ToLower()] = SqlDbType.Text;
            typeMap[("Timestamp").ToLower()] = SqlDbType.Timestamp;
            typeMap[("TinyInt").ToLower()] = SqlDbType.TinyInt;
            typeMap[("VarBinary").ToLower()] = SqlDbType.VarBinary;
            typeMap[("VarChar").ToLower()] = SqlDbType.VarChar;
            typeMap[("Variant").ToLower()] = SqlDbType.Variant;
            typeMap[("Xml").ToLower()] = SqlDbType.Xml;
            typeMap[("Udt").ToLower()] = SqlDbType.Udt;
            typeMap[("Structured").ToLower()] = SqlDbType.Structured;
            typeMap[("Date").ToLower()] = SqlDbType.Date;
            typeMap[("Time").ToLower()] = SqlDbType.Time;
            typeMap[("DateTime2").ToLower()] = SqlDbType.DateTime2;
            typeMap[("DateTimeOffset").ToLower()] = SqlDbType.DateTimeOffset;
        }
        
        public static SqlDbType GetDbType(string giveType)
        {           

            if (typeMap.ContainsKey(giveType))
            {
                return typeMap[giveType];
            }

            throw new ArgumentException($"{giveType} is not a supported SQLType");
        }

        public static SqlDbType GetDbTypeFromCsharpType(Type giveType)
        {
            if (csharTypetoSQLDBTypeMap.ContainsKey(giveType))
            {
                return csharTypetoSQLDBTypeMap[giveType];
            }

            throw new ArgumentException($"{giveType} is not a supported .NET class");
        }

        public static ParameterDirection GetDirection(string getType)
        {
            ParameterDirection direction;
            switch (getType)
            {
                case "IN":
                    direction = ParameterDirection.Input;
                    break;
                case "OUT":
                    direction = ParameterDirection.Output;
                    break;
                case "INOUT":
                    direction = ParameterDirection.InputOutput;
                    break;                
                default:
                    direction = ParameterDirection.Input;
                    break;
            }
            return direction;
        }
    }
}

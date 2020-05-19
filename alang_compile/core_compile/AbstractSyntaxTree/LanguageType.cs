using System.ComponentModel;

namespace core_compile.AbstractSyntaxTree
{
    public enum LanguageType
    {
        Pin,
        Int,
        Void,
        Time,
        Null
    }
    
    public static class StringExtension
    {

        public static string ToLower(this LanguageType me)
        {
            return me.ToString().ToLower();
        }
        public static  string ToEnumString(this LanguageType me)
        {
            switch (me)
            {
                case LanguageType.Pin:
                case LanguageType.Int:
                    return "int";
                case LanguageType.Void:
                    return "void";
                case LanguageType.Time:
                    return "unsigned long";
                case LanguageType.Null:
                    return "null";
                default:
                    return "Error";
            }
        }
    }
}
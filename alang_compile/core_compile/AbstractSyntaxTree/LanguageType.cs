using System.ComponentModel;

namespace core_compile.AbstractSyntaxTree
{
    public enum LanguageType
    {
        [Description("int")]
        Pin,
        [Description("int")]
        Int,
        [Description("void")]
        Void,
        [Description("time_t")]
        Time,
        [Description("null")]
        Null
    }
    
    public static class StringExtension
    {
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
                    return "time_t";
                case LanguageType.Null:
                    return "null";
                default:
                    return "Error";
            }
        }
    }
}
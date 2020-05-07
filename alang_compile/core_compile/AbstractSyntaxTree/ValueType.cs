using System;
using AntlrGen;

namespace core_compile.AbstractSyntaxTree
{

    public class Type
    {
        public static LanguageType GetType (ALangParser.FunctionContext context)
        {
            var type = context.TYPE().GetText();
            switch (type)
            {
                case "void" : 
                    return LanguageType.Void;
                case "int" :
                    return LanguageType.Int;
                case "float" :
                    return LanguageType.Float;
                case "Pin" :
                    return LanguageType.Pin;
                case "time" :
                    return LanguageType.Time;
                default:
                    return LanguageType.Null;
            }
        }
        public static LanguageType GetType (ALangParser.DclContext context)
        {
            var type = context.TYPE().GetText();
            switch (type)
            {
                case "void" : 
                    return LanguageType.Void;
                case "int" :
                    return LanguageType.Int;
                case "float" :
                    return LanguageType.Float;
                case "Pin" :
                    return LanguageType.Pin;
                case "time" :
                    return LanguageType.Time;
                default:
                    return LanguageType.Null;
            }
        }
    }
    public enum LanguageType
    {
        Pin,
        Void,
        Int,
        Float,
        Time,
        Null
    }
}
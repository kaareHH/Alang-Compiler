namespace core_compile.AbstractSyntaxTree
{
    public enum Operator
    {
        Addition ,
        Subtraction ,
        Multiplication,
        Division,
        Modulo,
        Greater,
        Less,
        GreaterEqual ,
        LessEqual ,
        EqualEqual ,
        OR,
        AND,
        InvalidOperator
    }
    
    public static class OperatorExtension
    {
        public static  string ToOperatorString(this Operator me)
        {
            switch (me)
            {
                case Operator.Addition:
                    return "+";
                case Operator.Subtraction:
                    return "-";
                case Operator.Multiplication:
                    return "*";
                case Operator.Division:
                    return "/";
                case Operator.Modulo:
                    return "%";
                case Operator.Greater:
                    return ">";
                case Operator.Less:
                    return "<";
                case Operator.GreaterEqual:
                    return ">=";
                case Operator.LessEqual:
                    return "<=";
                case Operator.EqualEqual:
                    return "==";
                case Operator.OR:
                    return "||";
                case Operator.AND:
                    return "&&";
                default:
                    return "Error";
            }
        }
        
        
    }
    
}
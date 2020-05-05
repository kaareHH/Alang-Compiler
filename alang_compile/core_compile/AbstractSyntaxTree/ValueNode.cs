namespace core_compile.AbstractSyntaxTree
{
    public class ValueNode : AstNode
    {
        public ValueType ValueType { get; set; }
        public object Value { get; set; }
    }
}
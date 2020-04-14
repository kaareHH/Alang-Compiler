using System.Collections.Generic;

namespace core_compile
{
    public interface INode{}

    public abstract class Node : INode { }

    public class StartNode : Node
    {
        public MultipleDeclarationsNode MultipleDeclarationNode { get; set; }
        public MultipleStatementsNode MultipleStatementsNode { get; set; }
    }

    public class MultipleStatementsNode : Node
    {
        public List<StatementNode> StatementNodes { get; set; }
    }

    public class MultipleDeclarationsNode : Node
    {
        public List<DeclarationNode> DeclarationNodes { get; set; }
    }
    
    public abstract class StatementNode : Node { }

    public class AssignStatementNode : StatementNode
    {
        public string Id { get; set; }
        public ValueNode Value { get; set; }
        public ExpressionNode Expression;
    }

    public class IfStatementNode : StatementNode
    {
        public ValueNode Value { get; set; }
        public ExpressionNode Expression { get; set; }
        public MultipleStatementsNode MultipleStatementsNode { get; set; }
    }

    public class RepeatStatementNode : StatementNode
    {
        public ValueNode Value { get; set; }
        public MultipleStatementsNode MultipleStatementsNode { get; set; }
    }

    public class OutputStatementNode : StatementNode
    {
        public Toggle Toggle { get; set; }
        public string Id { get; set; }
    }

    public class DeclarationNode : Node
    {
        public DeclarationType DeclarationType { get; set; }
        public string Id { get; set; }
        public ValueNode Value;
    }


    public class ExpressionNode : Node
    {
        public List<Operator> ExpressionOperators { get; set; }
        public List<ValueNode> Values { get; set; }
    }

    public enum Operator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class ValueNode : Node
    {
        public ValueKind ValueKind { get; set; }
        public object Value { get; set; }
    }

    public enum ValueKind
    {
        Id,
        Pin,
        Integer
    }
    
    public enum DeclarationType
    {
        Integer,
        Pin
    }

    public enum Toggle
    {
        On,
        Off
    }
}
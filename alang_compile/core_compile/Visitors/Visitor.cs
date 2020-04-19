namespace core_compile
{
    public abstract class Visitor<T>
    {
        public abstract T Visit(MultipleDeclarationsNode node);
        public abstract T Visit(MultipleStatementsNode node);
        public abstract T Visit(DeclarationNode node);
        public abstract T Visit(AssignStatementNode node);
        public abstract T Visit(IfStatementNode node);
        public abstract T Visit(RepeatStatementNode node);
        public abstract T Visit(OutputStatementNode node);
        public abstract T Visit(ExpressionNode node);
        public abstract T Visit(ValueNode node);

        public abstract T Visit(StartNode node);
    }
}
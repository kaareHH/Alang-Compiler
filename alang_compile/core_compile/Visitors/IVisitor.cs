using System;
using System.Linq;
using System.Runtime.Serialization;
using core_compile.AbstractSyntaxTree;

namespace core_compile.Visitors
{
    public interface IVisitor
    {
        public void Visit(AssignmentNode node);
        public void Visit(AstNode node);
        public void Visit(CompilationNode node);
        public void Visit(DeclarationNode node);
        public void Visit(ExpressionNode node);
        public void Visit(FunctionCallNode node);
        public void Visit(FunctionNode node);
        public void Visit(IdentfierNode node);
        public void Visit(IfNode node);
        public void Visit(ImportNode node);
        public void Visit(IntNode node);
        public void Visit(Location node);
        public void Visit(NullNode node);
        public void Visit(OutputNode node);
        public void Visit(ParameterNode node);
        public void Visit(PinNode node);
        public void Visit(TimeNode node);
        public void Visit(ValueNode node);
        public void Visit(WhileNode node);
    }
    
    
}
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
        public void Visit(NullNode node);
        public void Visit(OutputNode node);
        public void Visit(ParameterNode node);
        public void Visit(PinNode node);
        public void Visit(TimeNode node);
        public void Visit(ValueNode node);
        public void Visit(WhileNode node);
    }
    
    public interface ITypeCheckerVisitor
    {
        public LanguageType Visit(AssignmentNode node);
        public LanguageType Visit(AstNode node);
        public LanguageType Visit(CompilationNode node);
        public LanguageType Visit(DeclarationNode node);
        public LanguageType Visit(ExpressionNode node);
        public LanguageType Visit(FunctionCallNode node);
        public LanguageType Visit(FunctionNode node);
        public LanguageType Visit(IdentfierNode node);
        public LanguageType Visit(IfNode node);
        public LanguageType Visit(ImportNode node);
        public LanguageType Visit(IntNode node);
        public LanguageType Visit(NullNode node);
        public LanguageType Visit(OutputNode node);
        public LanguageType Visit(ParameterNode node);
        public LanguageType Visit(PinNode node);
        public LanguageType Visit(TimeNode node);
        public LanguageType Visit(ValueNode node);
        public LanguageType Visit(WhileNode node);
    }
}
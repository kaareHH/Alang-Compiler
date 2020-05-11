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
    
    public class CodeGenVisitor : IVisitor
    {
        public void Visit(AssignmentNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(AstNode node)
        {
            emit("gaaay");
        }

        public void Visit(CompilationNode node)
        {
            node.LeftMostChild.Accept(this);
        }

        public string program { get; set; } = "";
        private void emit(string code)
        {
            program += code;
        }
        public void Visit(DeclarationNode node)
        {
            emit(node.Type.ToString().ToLower());
            emit(" ");
            emit(node.Identifier);
            emit("=");
            node.PrimaryExpression.Accept(this);
            emit(";\n");
        }

        public void Visit(ExpressionNode node)
        {
            node.Left.Accept(this);
            emit(node.Operator.ToString());
            node.Right.Accept(this);
        }

        public void Visit(FunctionCallNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(FunctionNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(IdentfierNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(IfNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(ImportNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(IntNode node)
        {
            emit(node.Value.ToString());
        }

        public void Visit(Location node)
        {
            throw new NotImplementedException();
        }

        public void Visit(NullNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(OutputNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(ParameterNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(PinNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(TimeNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(ValueNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(WhileNode node)
        {
            throw new NotImplementedException();
        }
    }
}
using Antlr4.Runtime;
using AntlrGen;
using core_compile.AbstractSyntaxTree;
using System;
using System.Linq;
using System.Threading;
using Antlr4.Runtime.Tree;
using Type = core_compile.AbstractSyntaxTree.Type;

namespace core_compile.Visitors
{
    public class AstBuilderVisitor : ALangBaseVisitor<AstNode>
    {
        public override AstNode VisitStart(ALangParser.StartContext context)
        {
            var astRoot = new CompilationUnit(context);
            astRoot.AdoptChildren(context.commands().Accept(this));
            return astRoot;
        }

        public override AstNode VisitCommands(ALangParser.CommandsContext context)
        {
            
            AstNode node = ExtractCommandTypeNode(context);
            if (context.commands() != null)
                node.MakeSiblings(context.commands().Accept(this));
            
            return node;
        }

        private AstNode ExtractCommandTypeNode(ALangParser.CommandsContext context)
        {
            if(context.dcl() != null)
                return context.dcl().Accept(this);
            if (context.imports() != null)
                return context.imports().Accept(this);
            if (context.function() != null)
                return context.function().Accept(this);
            return new NullNode();
        }

        public override AstNode VisitDcl(ALangParser.DclContext context)
        {
            var node = new DeclarationNode(context);
            node.Value = context.primaryExpression().Accept(this) as ExpressionNode;
            node.Identifier = context.ID().GetText();
            node.Type = Type.GetType(context);
            
            return node;
        }
        

        public override AstNode VisitFunction(ALangParser.FunctionContext context)
        {
            var node = new FunctionNode();
            node.Identifier = context.ID().GetText();
            node.Type = Type.GetType(context);
            node.AdoptChildren(context.stmts().Accept(this));
            
            return node;
        }

        public override AstNode VisitImports(ALangParser.ImportsContext context)
        {
            var node = new ImportNode(context);
            node.Path = context.ALANGFILENAME().GetText();
            return node;
        }

        public override AstNode VisitStmts(ALangParser.StmtsContext context)
        {
            var node = ExtractStmtTypeNode(context);
            if (context.stmts().children != null)
                node.MakeSiblings(context.stmts().Accept(this));
            return node;
        }
        
        private AstNode ExtractStmtTypeNode(ALangParser.StmtsContext context)
        {
            if(context.dcl() != null)
                return context.dcl().Accept(this);
            if(context.ifstmt() != null)
                return context.ifstmt().Accept(this);
            if(context.functioncall() != null)
                return context.functioncall().Accept(this);
            if(context.outputstmt() != null)
                return context.outputstmt().Accept(this);
            return new NullNode();
        }

        public override AstNode VisitOutputstmt(ALangParser.OutputstmtContext context)
        {
            return new OutputNode(context);
        }

        public override AstNode VisitAlternative(ALangParser.AlternativeContext context)
        {
            var node = new IfNode(context);
            if (context.alternative() != null)
                node.Alternative = context.alternative().Accept(this) as IfNode;
            return node;
        }

        public override AstNode VisitIfstmt(ALangParser.IfstmtContext context)
        {
            var node = new IfNode(context);
            if (context.alternative() != null)
                node.Alternative = context.alternative().Accept(this) as IfNode;
            return node;
        }

        public override AstNode VisitFunctioncall(ALangParser.FunctioncallContext context)
        {
            return new FunctionCallNode(context);
        }
    }
}
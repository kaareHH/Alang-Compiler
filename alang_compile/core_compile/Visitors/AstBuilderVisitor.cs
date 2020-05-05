using Antlr4.Runtime;
using AntlrGen;
using core_compile.AbstractSyntaxTree;
using System;
using System.Linq;

namespace core_compile.Visitors
{
    public class AstBuilderVisitor : ALangBaseVisitor<AstNode>
    {
        public override AstNode VisitStart(ALangParser.StartContext context)
        {
            var imports = context.imports().Accept(this);
            var commands = context.commands().Accept(this);

            var programNode = MakeFamily(AstNodeType.Program,
                                         imports,
                                         commands);

            programNode.AddLocationFromContext(context);

            return programNode;
        }

        // TODO: Add location to import nodes
        public override AstNode VisitImports(ALangParser.ImportsContext context)
        {
            if (context.GetText() == "")
            {
                return new NullNode();
            }
            const int first = 0;
            ImportNode result = new ImportNode();
            result.AddLocationFromContext(context);

            result.Path = context.ALANGFILENAME(first).GetText();

            foreach (var import in context.ALANGFILENAME().Skip(1))
            {
                var newToken = new ImportNode();
                newToken.Path = import.GetText();
                result.MakeSiblings(newToken);
            }

            return result;
        }

        public override AstNode VisitCommands(ALangParser.CommandsContext context)
        {
            AstNode firstCommand;

            if (context.command().Length > 0)
            {
                firstCommand = context.command(0).Accept(this);

                for (int i = 1; i < context.command().Length; i++)
                {
                    var command = context.command(i).Accept(this);
                    firstCommand.MakeSiblings(command);
                }
            }
            else
            {
                firstCommand = new NullNode();
            }


            return firstCommand;
        }

        public override AstNode VisitDcl(ALangParser.DclContext context)
        {
            return new DeclarationNode();
        }

        public override AstNode VisitFunction(ALangParser.FunctionContext context)
        {
            return new FunctionNode();
        }

        private AstNode MakeFamily(AstNodeType parentType, params AstNode[] kids)
        {
            if (kids == null)
            {
                return null;
            }

            var parentNode = MakeNode(parentType);
            foreach (var kid in kids)
            {
                if (kid != null)
                {
                    parentNode.AdobtChildren(kid);
                }
            }

            return parentNode;
        }

        private AstNode MakeNode(AstNodeType type)
        {
            AstNode node;
            switch (type)
            {
                case AstNodeType.Program:
                    node = new ProgramNode();
                    break;
                case AstNodeType.Import:
                    node = new ImportNode();
                    break;
                case AstNodeType.Comment:
                    node = new CommentNode();
                    break;
                case AstNodeType.Function:
                    node = new FunctionNode();
                    break;
                case AstNodeType.Declaration:
                    node = new DeclarationNode();
                    break;
                default:
                    node = new NullNode();
                    break;
            }

            return node;
        }
    }
}
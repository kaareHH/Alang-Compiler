using System;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;
using core_compile.AbstractSyntaxTree;
using core_compile.SymbolTableClasses;

namespace core_compile.Visitors
{
    // TODO: Add reserved keywords to symboltable
    public class TypeCheckerVisitor : IVisitor
    {
        public SymbolTable CurrentSymbolTable { get; set; }

        public void Visit(CompilationNode node)
        {
            // System.Console.WriteLine("Visiting compilationNode");
            CurrentSymbolTable = node.SymbolTable;
            node.AcceptChildren(this);
        }

        public void Visit(DeclarationNode node)
        {
            // System.Console.WriteLine("Visiting dclNode");
            node.PrimaryExpression.Accept(this);



            // 3 + ((2 / 2) * 2) < 1

            // 3 > 4 && 00:00:00 > 12:12:12

            // 3 > 4 && 5 + 9
            
            // 3 + 2 * 2

            // (3 > 4) && (5 > 9)

            //       <
            //      / \
            //     +   1
            //    / \
            //   3   *
            //      / \
            //     2   2 


            // 3 > 4 && 00:00:00 > 12:12:12
            // 3 > 4
            //       >
            //      / \
            //     3   &&
            //        / \
            //       4   >
            //          / \ 
            //   00:00:00   12:12:12

            // if (node.Type != ExpressionNode.Type)
            //     throw error!!!!

            /*
           læs til right == null 

           læs expression operand, hvis det ikke er &&
           læs left og gem type
           læs operand og gem den
           læs right.left type og compare - check også operand er lovlig på type

           læs expression operand, hvis det er &&
           reset, nu kan der være nye typer
           */
        }

        public void Visit(AssignmentNode node)
        {
            // System.Console.WriteLine("Visiting AssignmentNode");
            node.Expression.Accept(this);
        }

        public void Visit(ExpressionNode node)
        {
            System.Console.WriteLine("Visiting Expression:");

            var temp = node as ExpressionNode;

            do
            {
                /*
                    læs til right == null 

                    læs expression operand, hvis det ikke er &&
                    læs left og gem type
                    læs operand og gem den
                    læs right.left type og compare - check også operand er lovlig på type

                    læs expression operand, hvis det er &&
                    reset, nu kan der være nye typer
                */
                // Tjek operator i if
                if (temp.Right != null)
                {
                    switch (temp.Operator)
                    {
                        case Operator.Addition:
                        case Operator.Subtraction:
                            break;
                        case Operator.Multiplication:
                        case Operator.Division:
                            break;
                        // send hjælp   
                        default:
                            break;
                    }

                }
                //  
                // er det godt?  ikke hvis i har anden ide
                // 
                /*
                var type = typeof temp.left 
                char op = temp.operand 

                // while (temp != null)
                // {
                        if temp.left.type == typeof int && temp.right.left == typeof int 

                            if temp.right.left.type = temp.left.type OG operand OK
                                ok
                            else
                                error 

                        if temp.left.type == typeof variable && samme for right side

                            if lookup var type of temp.left = lookup right side
                            if compare left og right OG operand OK
                                ok
                            else
                                error 	

                        Omvendt, første int, anden variable

                        omvendt, første variable, anden int 


                        slut i while løkken, sæt temp til ny right 
                        sæt ny operand til nye right's operand 

                            if opranden er && eller || 
                                reset type of temp 
                // }
                */

                System.Console.WriteLine("\t-Left: " + temp.Left + " ---> " + ((IntNode)temp.Left).Value);
                System.Console.WriteLine("\t\tOperator: " + temp.Operator);
                if (temp.Right.GetType() == typeof(IntNode))
                    System.Console.WriteLine("\t-Right: " + temp.Right + " ---> " + ((IntNode)temp.Right).Value);
            }
            while ((temp = temp.Right as ExpressionNode) != null);
        }

        public void Visit(FunctionCallNode node)
        {
            return;
        }

        public void Visit(FunctionNode node)
        {
            CurrentSymbolTable = node.SymbolTable;
            // Code here
            CurrentSymbolTable = node.SymbolTable.parent;
        }

        public void Visit(IdentfierNode node)
        {
            return;
        }

        public void Visit(IfNode node)
        {
            return;
        }

        public void Visit(ImportNode node)
        {
            return;
        }

        public void Visit(IntNode node)
        {
            return;
        }

        public void Visit(NullNode node)
        {
            return;
        }

        public void Visit(OutputNode node)
        {
            return;
        }

        public void Visit(ParameterNode node)
        {
            return;
        }

        public void Visit(PinNode node)
        {
            return;
        }

        public void Visit(TimeNode node)
        {
            return;
        }

        public void Visit(ValueNode node)
        {
            return;
        }

        public void Visit(WhileNode node)
        {
            return;
        }

        public void Visit(AstNode node)
        {
            return;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace core_compile
{
    public class Parse
    {
        List<Token> tokenStream = new List<Token>();
        public Parse(List<Token> _tokenStream)
        {
            this.tokenStream = _tokenStream;
            Declerations(tokenStream.FirstOrDefault());
        }

        public void Declerations(Token token)
        {
            Node node = new Node();
            node = Decleration(token);

            InterpretAST(node);

            //Declerations(token);

        }

        private void InterpretAST(Node node)
        {
            System.Console.WriteLine("\n");

            if(node.left != null)
            {
                System.Console.WriteLine("Root: " + node.op + ", left: " + node.left.op);
                InterpretAST(node.left);
            }
            if(node.right != null)
            {
                System.Console.WriteLine("Root: " + node.op + ", right: " + node.right.op);
                InterpretAST(node.right);
            }
        }

        private Node Decleration(Token token)
        {
            Node node = new Node();

            // Make INTDCL/PINDCL to leftmost child
            node.left = MakeLeaf(token.TokenValue, ConvertType(token));

            // Get the next token
            token = GetNext(token);

            // Set the next token as the root of the small part of the AST.
            node.op = token.TokenValue;
            node.type = ConvertType(token);

            // Evaluate right child
            node.right = EvalRight(token);

            return node;
            

        }

        private Node EvalRight(Token token)
        {
            Node node = new Node();

            // Ensure an EQUAL follows the ID
            if(Expect(token, TokenType.T_EQUAL))
            {
                token = GetNext(token);
                
                // Ensure an ID or INTLIT follows the EQUAL
                if(Expect(token, TokenType.T_ID) || Expect(token, TokenType.T_INTLIT)) 
                {
                    token = GetNext(token);

                    // Check if the decleration ends with a predicate.
                    if(Expect(token, TokenType.T_SEMICOLON))
                    {
                        node = MakeLeaf(token.TokenValue, ConvertType(token));
                    }
                    // Check if the decleration consists of an expresiion
                    else if(Expect(token, TokenType.T_PLUS) || Expect(token, TokenType.T_MINUS) || Expect(token, TokenType.T_MULTIPLY) || Expect(token, TokenType.T_DIVIDE)) 
                    {
                    
                        node = ArthExpr(token);
                    }
                    else 
                    {
                        System.Console.WriteLine("Expected either a SEMICOLON or an ArthExpr after " + token.TokenType);
                    }
                }
                else
                {
                    System.Console.WriteLine("Expected either ID or INTLIT after " + token.TokenType);
                }
                
            }
            else
            {
                System.Console.WriteLine("Expected EQUAL after " + token.TokenType);
            }
            
            return node;
        }

        private Node ArthExpr(Token token)
        {
           
            if(Expect(token, TokenType.T_SEMICOLON) == false)
            {
                Node n = new Node();
                Node left = new Node();
                Node right = new Node();

                System.Console.WriteLine("Making left child " + token.TokenValue + " next token is: " + GetNext(token).TokenValue);
                left = MakeLeaf(token.TokenValue, ConvertType(token));

                token = GetNext(token);
        
                right = ArthExpr(token);

                System.Console.WriteLine("Making n: operant" + token.TokenValue);
                n = MakeNode(token.TokenValue, left, right, ConvertType(token));
                return n;
            }

            return null;
        }

        public void Statements()
        {
            System.Console.WriteLine("Not implemented");
        }

        private Token GetNext(Token token)
        {
            // Get the current token
            Token currentToken = token;

            // Remove the current token to get the next
            tokenStream.Remove(token);

            // Return the new first token
            return tokenStream.FirstOrDefault();

        }

         private bool Expect(Token token, TokenType type)
        {
            Token nextToken = GetNext(token);

            if(nextToken.TokenType == type)
                return true;

            else
                return false;
        }
        

        private NodeType ConvertType(Token token)
        {
            NodeType nodeType = NodeType.N_BADNODE;
            

            switch(token.TokenType)
            {
                case TokenType.T_INTDCL:
                nodeType = NodeType.N_INTDCL;
                break;

                case TokenType.T_PINDCL:
                nodeType = NodeType.N_PINDCL;
                break;

                case TokenType.T_ID:
                nodeType = NodeType.N_ID;
                break;

                case TokenType.T_INTLIT:
                nodeType = NodeType.N_INTLIT;
                break;

                case TokenType.T_PLUS:
                nodeType = NodeType.N_PLUS;
                break;

                case TokenType.T_MINUS:
                nodeType = NodeType.N_MINUS;
                break;

                case TokenType.T_MULTIPLY:
                nodeType = NodeType.N_MULTIPLY;
                break;

                case TokenType.T_DIVIDE:
                nodeType = NodeType.N_DIVIDE;
                break;

                default:
                System.Console.WriteLine("Unknown token type");
                break;
            }

            return nodeType;
        }




        private Node MakeNode(string op, Node left, Node right, NodeType type)
        {

            Node node = new Node(op, left, right, type);

            return node;
        }

        /// <summary>
        ///  Creates a Leaf in the AST
        /// </summary>
        private Node MakeLeaf(string op, NodeType type) 
        {
            return MakeNode(op, null, null, type);
        }

        // Makes a Node with only one child
        private Node MakeUnary(string op, Node left, NodeType type)
        {
            return MakeNode(op, left, null, type);
        }



    }
}
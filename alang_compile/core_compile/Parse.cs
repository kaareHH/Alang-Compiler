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
            Declerations();
        }

        public void Declerations()
        {
            Node node = new Node();
            node = Decleration(tokenStream.FirstOrDefault());
            
            //Declerations();
            InterpretAST(node);

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
            token = GetNext();

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
            if(Expect(TokenType.T_EQUAL))
            {
                token = GetNext();
            
                
                // Ensure an ID or INTLIT follows the EQUAL
                if(Expect(TokenType.T_ID) || Expect(TokenType.T_INTLIT)) 
                {
                    token = GetNext();

                    // Check if the decleration ends with a predicate.
                    if(Expect(TokenType.T_SEMICOLON))
                    {
                        node = MakeLeaf(token.TokenValue, ConvertType(token));
                    }
                    // Check if the decleration consists of an expresiion
                    else if(Expect(TokenType.T_PLUS) || Expect(TokenType.T_MINUS) || Expect(TokenType.T_MULTIPLY) || Expect(TokenType.T_DIVIDE)) 
                    {
                    
                        node = ArthExpr(token);
                    }
                    else 
                    {
                        System.Console.WriteLine("Expected either a SEMICOLON or an ArthExpr after " + token.TokenValue);
                    }
                }
                else
                {
                    System.Console.WriteLine("Expected either ID or INTLIT after " + token.TokenValue);
                }
                
            }
            else
            {
                System.Console.WriteLine("Expected EQUAL after " + token.TokenValue);
            }
            
            return node;
        }

        private Node ArthExpr(Token token)
        {
            Node n = new Node();
            Node left = new Node();
            Node right = new Node();
            Token prevToken = token;
            if(token.TokenType == TokenType.T_ID || token.TokenType == TokenType.T_INTLIT)
            {
                // Make ID or INTLIT to left child
                left = MakeLeaf(token.TokenValue, ConvertType(token));
                if(Expect(TokenType.T_SEMICOLON))
                {
                    return left;
                }

                 // Next token is the operator
                if(Expect(TokenType.T_PLUS) || Expect(TokenType.T_MINUS) || Expect(TokenType.T_MULTIPLY) || Expect(TokenType.T_DIVIDE))
                {
                   token = GetNext(); 
                }
                else
                {
                    System.Console.WriteLine("Expected + - * / after " + token.TokenValue);
                    return null;
                }


                
                // Save the operator
                prevToken = token;

                // Next token is ID OR INTLIT which will be evaluated to left child again.
                token = GetNext();

        
                right = ArthExpr(token);
                n = MakeNode(prevToken.TokenValue, left, right, ConvertType(token));
                return n;
            }
            else 
            {
                System.Console.WriteLine("Expected ID or INTLIT after " + prevToken.TokenValue);
                return null;
            }

        }
        private Node Left(Token token)
        {
            Node node = new Node();

            MakeLeaf(token.TokenValue, ConvertType(token));
            token = GetNext();

            return node;
        }

        public void Statements()
        {
            System.Console.WriteLine("Not implemented");
        }

        private Token GetNext()
        {
            // Remove first token in List
            tokenStream.Remove(tokenStream.FirstOrDefault());
            // Return the new first token
            return tokenStream.FirstOrDefault();

        }

         private bool Expect(TokenType type)
        {
            List<Token> tmpList = new List<Token>();
            tmpList.AddRange(tokenStream);
             
            tmpList.Remove(tmpList.FirstOrDefault());

            Token nextToken = tmpList.FirstOrDefault();

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
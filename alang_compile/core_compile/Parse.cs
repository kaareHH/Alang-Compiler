using System;
using System.Collections.Generic;
using System.Linq;

namespace core_compile
{
    public class Parse
    {
        List<Token> tokenStream = new List<Token>();
        List<Node> stmtsNode = new List<Node>();
        List<Node> dclsNode = new List<Node>();
        public Parse(List<Token> _tokenStream)
        {
            this.tokenStream = _tokenStream;
            CreateAST();
        }

        public void CreateAST()
        {
            Node node = new Node();
            node.op = "start";
            node.type = NodeType.N_START;

            node.children.AddRange(Declerations(dclsNode));
            node.children.AddRange(Statements(stmtsNode));

            System.Console.WriteLine("Start has " + node.children.Count() + " children");
            foreach (var n in node.children)
            {
                InterpretAST(n);
                
            }
        }

        public List<Node> Declerations(List<Node> dclsNode)
        {
            dclsNode.Add(Decleration(tokenStream.FirstOrDefault()));

            if(tokenStream.Count() > 0 && 
              (tokenStream.FirstOrDefault().TokenType == TokenType.T_INTDCL || 
               tokenStream.FirstOrDefault().TokenType == TokenType.T_PINDCL))
               {
                   Declerations(dclsNode);
               }
               
            
            return dclsNode;
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
            if(node.children.Count > 0)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Root: " + node.op + ", has the following stmt children:");
                System.Console.WriteLine();
                foreach (var childNode in node.children)
                {

                    InterpretAST(childNode);
                    
                }
                
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
                        // Skip semicolon
                        token = GetNext();
                        token = GetNext();
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
                if(Expect(TokenType.T_SEMICOLON) || Expect(TokenType.T_PARANEND))
                {
                    //Skip the semicolon or paranthesis
                    token = GetNext();
                    token = GetNext();
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

        public List<Node> Statements(List<Node> stmtsNode)
        {

           stmtsNode.Add(Statement(tokenStream.FirstOrDefault()));

           if(tokenStream.Count > 0 && tokenStream.FirstOrDefault().TokenType != TokenType.T_WHITESPACE)
           {
               Statements(stmtsNode);
           }

            return stmtsNode;
        }

        private Node Statement(Token token)
        {
            Node node = new Node();

            if(token.TokenType == TokenType.T_IF)
            {
                node.left = EvalCond(token);
                node.op = token.TokenValue;
                node.type = ConvertType(token);

                node.children = Statements(node.children);
             
            }
            else if(token.TokenType == TokenType.T_REPEAT)
            {

            }
            else if(token.TokenType == TokenType.T_TOGGLE)
            {
                if(Expect(TokenType.T_ID))
                {
                    // Set prevToken to TOGGLE
                    Token prevToken = token;
                    // Fetch the ID
                    token = GetNext();
                    if(Expect(TokenType.T_SEMICOLON))
                    {
                        // Create the node where the root is ID and child is TOGGLE
                        node = MakeUnary(token.TokenValue, MakeLeaf(prevToken.TokenValue, ConvertType(prevToken)), ConvertType(token));
                        // Skip the semicolon
                        token = GetNext();
                        token = GetNext();
                    }
                    else
                    {
                        System.Console.WriteLine("Expected semicolon in the end of toggle statement");
                        return null;
                    }
                        
                }
                else
                {
                    System.Console.WriteLine("Expected ID after " + token.TokenType);
                    return null;
                }
                    
            }
            else if(token.TokenType == TokenType.T_ID)
            {
                if(Expect(TokenType.T_EQUAL))
                {
                    Token prevToken = token;
                    //Skip the equal
                    token = GetNext();
                    token = GetNext();
                    node = MakeUnary(prevToken.TokenValue, ArthExpr(token), ConvertType(prevToken));
                }
                else
                {
                    System.Console.WriteLine("Expected EQUAL after " + token.TokenValue);
                    return null;
                }
            }
            else
            {
                System.Console.WriteLine("Invalid token in statement " + token.TokenType);
                return null;
            }

            return node;
        }

        private Node EvalCond(Token token)
        {
            Node node = new Node();

            if(Expect(TokenType.T_PARANBEGIN))
            {
                token = GetNext();
                if(Expect(TokenType.T_ID) || Expect(TokenType.T_INTLIT))
                {
                    token = GetNext();

                    if(Expect(TokenType.T_LESSEQUAL) || Expect(TokenType.T_GREATEREQUAL) || Expect(TokenType.T_EQUALEQUAL) ||
                       Expect(TokenType.T_NOTEQUAL) || Expect(TokenType.T_LESS) || Expect(TokenType.T_GREATER))
                    {
                        Token prevToken = token;

                        token = GetNext();
                        node.left = MakeLeaf(prevToken.TokenValue, ConvertType(prevToken));

                        node.op = token.TokenValue;
                        node.type = ConvertType(token);

                        token = GetNext();
                        
                        if(Expect(TokenType.T_PLUS) || Expect(TokenType.T_MINUS) || 
                           Expect(TokenType.T_MULTIPLY) || Expect(TokenType.T_DIVIDE))
                           {
                                node.right = ArthExpr(token);
                           }
                                
                        else
                        {
                            if(Expect(TokenType.T_PARANEND))
                            {
                                node.right = MakeLeaf(token.TokenValue, ConvertType(token));
                                // Skip parenthesis
                                token = GetNext();
                                token = GetNext();
                            }
                            else
                            {
                                System.Console.WriteLine("Expected end-paranthesis after " + token.TokenValue);
                                return null;
                            }
                                
                        }     
                    }
                }
            }

            return node;
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

                case TokenType.T_TOGGLE:
                nodeType = NodeType.N_TOGGLE;
                break;

                case TokenType.T_EQUALEQUAL:
                nodeType = NodeType.N_EQUALEQUAL;
                break;

                case TokenType.T_NOTEQUAL:
                nodeType = NodeType.N_NOTEQUAL;
                break;

                case TokenType.T_GREATER:
                nodeType = NodeType.N_GREATER;
                break;

                case TokenType.T_LESS:
                nodeType = NodeType.N_LESS;
                break;

                case TokenType.T_GREATEREQUAL:
                nodeType = NodeType.N_GREATEREQUAL;
                break;

                case TokenType.T_LESSEQUAL:
                nodeType = NodeType.N_LESSEQUAL;
                break;

                case TokenType.T_IF:
                nodeType = NodeType.N_IF;
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
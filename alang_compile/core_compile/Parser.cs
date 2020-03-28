using System.Runtime.ConstrainedExecution;
using System.Linq;
using System.Collections.Generic;
using System;

namespace core_compile
{
    public class Parser
    {
        List<Token> tokenStream;
        Token currentToken;
        Token prevToken;

        public Parser(List<Token> _tokenStream)
        {
            this.tokenStream = _tokenStream;
            this.currentToken = tokenStream.FirstOrDefault();
            Parse(currentToken);
        }

        /// <summary>
        /// Gets the next token in the list
        /// </summary>
        private Token GetNext(Token token)
        {
            // Get the current token
            Token currentToken = token;

            // Set the previous token
            prevToken = token;

            // Remove the current token to get the next
            tokenStream.Remove(token);

            // Return the new first token
            return tokenStream.FirstOrDefault();

        }

        public void Parse(Token token) 
        {
            if(token.TokenType == TokenType.T_INTDCL || token.TokenType == TokenType.T_PINDCL)
            {
                Dcls(token);
            }
            else 
            {
                System.Console.WriteLine("Done reading the tokens");
            }

        }

        private void Dcls(Token token)
        {
            Node node;
            node = Dcl(token);

            System.Console.WriteLine(node.type);
            System.Console.WriteLine(node.left.type);
            System.Console.WriteLine(node.right.type);


            //Dcls();



        }

        private Node Dcl(Token token)
        {
            prevToken = token;
            if(token.TokenType == TokenType.T_INTDCL || token.TokenType == TokenType.T_PINDCL)
            {
                if(Expect(token, TokenType.T_ID))
                {

                    token = GetNext(token);

                    return MakeNode(token.TokenValue, 
                            MakeLeaf(prevToken.TokenValue, ConvertType(prevToken)), 
                            EvalRight(token), 
                            ConvertType(token));
                }
                else 
                {
                    System.Console.WriteLine("Invalid next token");
                    return null;
                }

            }
            else 
            {
                System.Console.WriteLine("Invalid token");
                return null;
            }
            

        }

        private bool Expect(Token token, TokenType type)
        {
            Token nextToken = GetNext(token);

            if(nextToken.TokenType == type)
                return true;

            else
                return false;
        }

        private Node EvalRight(Token token)
        {
            if(Expect(token, TokenType.T_EQUAL))
            {
                token = GetNext(token);

                if(Expect(token, TokenType.T_ID) || Expect(token, TokenType.T_INTLIT))
                {
                    token = GetNext(token);
                    if(Expect(token, TokenType.T_SEMICOLON)) // If the right side is finished
                    {
                        return MakeLeaf(token.TokenValue, ConvertType(token));
                    }
                    else if(Expect(token, TokenType.T_PLUS) || Expect(token, TokenType.T_MINUS) || Expect(token, TokenType.T_MULTIPLY) || Expect(token, TokenType.T_DIVIDE) )
                    {
                        Token prevToken = token;
                        token = GetNext(token);
                        return MakeNode(token.TokenValue, MakeLeaf(prevToken.TokenValue, ConvertType(prevToken)), SomeMethod(token), ConvertType(token));
                        // Do something iterative - If we hit this case, we are encountering an arthmetic operation
                    }
                    else 
                    {
                        System.Console.WriteLine("Expected either an arthmetic operation or a semicolon after " + token.TokenType);
                        return null;
                    }
                   
                }
                else
                {
                    System.Console.WriteLine("Expected ID or INTLIT after " + token.TokenType);
                    return null;
                }

            }
            else 
            {
                System.Console.WriteLine("Expected EQUAL after " + token.TokenType);
                return null;
            }
            
            
        }

        private Node SomeMethod(Token token)
        {
            // Recieves an operator (+ - * /)
            // Fetches next token (ID or INTLIT)
            token = GetNext(token);
            // Checks if the token after the INT or ID is another operator.
            // If it is, then create a Node and call this method for the right child.
            if(Expect(token, TokenType.T_PLUS) || Expect(token, TokenType.T_MINUS) || 
               Expect(token, TokenType.T_MULTIPLY) || Expect(token, TokenType.T_DIVIDE)) 
            {
                Token prevToken = token;
                token = GetNext(token);

                return MakeNode(token.TokenValue, MakeLeaf(prevToken.TokenValue, ConvertType(prevToken)), SomeMethod(token), ConvertType(token));

            }
            // If it is a semicolon, create a leaf
            else if(Expect(token, TokenType.T_SEMICOLON))
            {
                return MakeLeaf(token.TokenValue, ConvertType(token));                
            }
            // Otherwise error
            else 
            {
                System.Console.WriteLine("Expected either a SEMICOLON or an operator after " + token.TokenType);
                return null;            
            }

            
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

                default:
                System.Console.WriteLine("Unknown token type");
                break;
            }

            return nodeType;
        }

        
        /// <summary>
        /// Creates a Node in the AST
        /// </summary>
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
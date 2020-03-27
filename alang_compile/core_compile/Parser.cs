using System.Linq;
using System.Collections.Generic;

namespace core_compile
{
    public class Parser
    {
        List<Token> tokenStream;
        Token token;

        public Parser(List<Token> _tokenStream)
        {
            this.tokenStream = _tokenStream;
            this.token = tokenStream.FirstOrDefault();
        }

        /// <summary>
        /// Gets the next token in the list
        /// </summary>
        private Token GetNext(Token token)
        {
            // Get the current token
            Token currentToken = token;

            // Remove the current token to get the next
            tokenStream.Remove(token);

            // Return the new first token
            return tokenStream.FirstOrDefault();

        }

        public void Parse() 
        {
            if(token.TokenType == TokenType.T_INTDCL || token.TokenType == TokenType.T_PINDCL)
            {
                Dcls();
            }
        }

        private void Dcls()
        {
            Dcl();
            Dcls();

        }

        private Node Dcl()
        {
            if(token.TokenType == TokenType.T_INTDCL)
            {
                return MakeLeaf(token.TokenValue, ConvertType(token.TokenType));
            }

            return null;

        }

        private NodeType ConvertType(TokenType tokenType)
        {
            NodeType nodeType;

            switch(tokenType)
            {
                case TokenType.T_INTDCL:
                nodeType = NodeType.N_INTDCL;
                break;

                case TokenType.T_PINDCL:
                nodeType = NodeType.N_PINDCL;
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
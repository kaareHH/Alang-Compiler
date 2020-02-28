using System;

namespace ParserService
{
    public interface Tokenfactory
    {
        public Token TokenIdentifier(char identifier);
    }
    class FirstTokenFactory : Tokenfactory
    {
        public Token TokenIdentifier(char identifier)
        {
            switch (identifier)
            {
                case 'a':
                    return new AToken();
                case 'b':
                    return new BToken();
                default:
                    throw new LexicalException();
            }
        }
    }

    public class LexicalException : Exception
    {
    }

    internal class BToken : Token
    {
    }

    internal class AToken : Token
    {
    }
}

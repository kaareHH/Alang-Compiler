namespace core_compile
{
    public class Node
    {
        public string op {get; set;}
        public Node left {get; set;}
        public Node right {get; set;}
        public NodeType type {get; set;}

        public Node(string _op, Node _left, Node _right, NodeType _type)
        {
            this.op = _op;
            this.left = _left;
            this.right = _right;
            this.type = _type;
        }

        public Node()
        {

        }
    }


    public enum NodeType
    {
        N_INTLIT, N_INTDCL, N_PINDCL, N_OUTPUTPIN, N_INPUTPIN, N_ID, N_SEMICOLON,
        N_ON, N_OFF, N_TOGGLE,
        N_PLUS, N_MINUS, N_MULTIPLY, N_DIVIDE, N_EQUAL, 
        N_IF, N_ENDIF, N_REPEAT, N_ENDREPEAT, N_TIMES, N_THEN, 
        N_PARANBEGIN, N_PARANEND, N_WHITESPACE,
        N_BADNODE

    }

}
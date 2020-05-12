using System;
using System.Collections.Generic;
using System.Text;

namespace core_compile
{
    class Node
    {
        public string type;
        public string name;

        public List<Node> children = new List<Node>();
    }
}

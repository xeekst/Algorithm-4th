using System.Collections.Generic;

namespace BST
{
    public class TreeVisualizer
    {
        public Kind kind = new Kind();
        public List<Node> nodes = new List<Node>();
        public List<Edge> edges = new List<Edge>();

        public class Kind
        {
            public bool graph = true;
        }
        public class Node
        {
            public string id;
            public string label;
        }

        public class Edge
        {
            public string from;
            public string to;
            public string label = string.Empty;
             
        }
    }
}
using System.Collections.Generic;

namespace RegularExpression
{
    public class Grep
    {
        public bool Recognizes(string regex, string text)
        {
            HashSet<int> pc = new HashSet<int>();
            NFA nfa = new NFA(regex);
            DirectedDFS dfs = new DirectedDFS(nfa.Graph, 0);
            for (int v = 0; v < nfa.Graph.V(); v++)
            {
                if (dfs.Reachable(v)) pc.Add(v);
            }
            for (int i = 0; i < text.Length; i++)
            {
                HashSet<int> match = new HashSet<int>();
                foreach (int v in pc)
                {
                    if (v < regex.Length)
                    {
                        if (regex[v] == text[i] || regex[v] == '.')
                        {
                            match.Add(v + 1);
                        }
                    }
                }
                pc = new HashSet<int>();
                dfs = new DirectedDFS(nfa.Graph, match);
                for (int v = 0; v < nfa.Graph.V(); v++)
                {
                    if (dfs.Reachable(v)) pc.Add(v);
                }
            }
            foreach (int v in pc) if (v == regex.Length) return true;
            return false;
        }
    }
}
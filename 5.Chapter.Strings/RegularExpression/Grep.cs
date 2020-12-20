using System.Collections.Generic;

namespace RegularExpression
{
    public class Grep
    {
        public bool Recognizes(string regex, string text)
        {
            NFA nfa = new NFA(regex);
            return nfa.Recognizes(text);
        }
    }
}
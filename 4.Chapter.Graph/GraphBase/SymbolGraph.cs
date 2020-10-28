using System.Collections.Generic;

namespace GraphBase
{
    public class SymbolGraph
    {
        private Dictionary<string, int> _nameIndexDict;
        private Dictionary<int, string> _indexNameDict;
        private Graph g;
        public SymbolGraph(string[] keys)
        {
            g = new Graph(keys.Length);
            for (int index = 0; index < keys.Length; index++)
            {
                _nameIndexDict[keys[index]] = index;
                _indexNameDict[index] = keys[index];
            }
        }

        public void AddEdge(string sourceKey, string targetKey)
        {
            if (!_nameIndexDict.ContainsKey(sourceKey) || !_nameIndexDict.ContainsKey(targetKey)) return;
            int s = _nameIndexDict[sourceKey];
            int v = _nameIndexDict[targetKey];
            g.AddEdge(s, v);
        }

        public bool Contains(string key)
        {
            return _nameIndexDict.ContainsKey(key);
        }

        public Graph G => g;
    }
}
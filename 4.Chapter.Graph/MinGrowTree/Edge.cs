using System;
using System.Collections.Generic;

namespace MinGrowTree
{
    public class Edge : IComparable<Edge>
    {
        private int _v;
        private int _w;
        private double _weight;

        public double Weight => _weight;

        public Edge(int v, int w, double weight)
        {
            _v = v;
            _w = w;
            _weight = weight;
        }

        public int CompareTo(Edge e)
        {
            return _weight.CompareTo(e.Weight);
        }

        public int ThisVertex()
        {
            return _v;
        }

        public int OtherVertex(int v)
        {
            if (_v == v) return _w;
            else if (_w == v) return _v;
            else throw new ArgumentNullException();
        }

        public override string ToString()
        {
            return $"{_v}-{_w}";
        }
    }
}
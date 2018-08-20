using System;

namespace UnionF
{
    ///<summary>
    interface IUnionFind
    {
        void Init(int n);
        void Union(int i,int j);
        int Find(int i);
        bool connected(int i,int j);
    }

}
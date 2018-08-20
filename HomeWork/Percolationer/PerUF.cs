

using System;

namespace Percolationer
{
    class PerUF
    {
        public int[] id;
        public int len;
        public int size;
        public int count;
        public PerUF(int N)
        {
            size = N * N + 1;
            count = N * N;
            len = N;
            id = new int[size + 1];
            for (int index = 0; index < size + 1; index++)
            {
                id[index] = index;
            }

        }
        public void CreateVirtualPoint()
        {
            for (int index = 1; index <= len; index++)
            {
                id[Trans(1, index)] = id[0];
                int root = Find(len, index);
                id[len * len + 1] = id[len * len + 1] < root ? id[len * len + 1] : root;
            }
        }

        public int Trans(int x, int y)
        {
            if (x == 0 && y == 0) return 0;
            if (x == len + 1 && y == len + 1) return len * len + 1;
            return (x - 1) * len + y;
        }
        public int Find(int x, int y)
        {
            int i = Trans(x, y);
            while (id[i] != i)
            {
                id[i] = id[id[i]];
                i = id[i];
            }
            return i;
        }
        public void Union(int x1, int y1, int x2, int y2)
        {
            int ri = Find(x1, y1);
            int rj = Find(x2, y2);
            if (ri < rj)
            {
                id[rj] = id[ri];
            }
            else
            {
                id[ri] = id[rj];
            }
            count--;
        }
        public bool Connected(int x1, int y1, int x2, int y2)
        {
            int ri = Find(x1, y1);
            int rj = Find(x2, y2);
            if (ri == rj)
            {
                return true;
            }
            return false;
        }
        public int Count()
        {
            return count;
        }
        public void Print()
        {
            Console.WriteLine(" \t\t" + id[0]);
            for (int index = 1; index < size; index++)
            {
                Console.Write(id[index]);
                if (index % len == 0)
                {
                    Console.Write("\n");
                }
                else
                {
                    Console.Write("\t");
                }
            }

            Console.WriteLine(" \t\t" + id[size]);
        }
        public static void TestMain()
        {
            Percolationer.PerUF per = new Percolationer.PerUF(5);
            //per.Union(2, 1, 1, 1);
            for (int row = 1; row < 5; row++)
            {
                int y1 = row;
                int y2 = row + 1;
                per.Union(row, y1, row, y2);
            }
            for (int col = 1; col < 5; col++)
            {
                int x1 = col;
                int x2 = col + 1;
                per.Union(x1, col + 1, x2, col + 1);
            }
            per.CreateVirtualPoint();
            per.Print();
            Console.WriteLine(per.count);
        }
    }
}

using System;
using System.IO;
using System.Text;

namespace Percolationer
{
    public class Percolation
    {
        //private int[] connectId;
        private PerUF uf;
        private int[][] opId;
        private int size = 0;
        private int len;
        private int opcount;
        public int Trans(int x, int y)
        {
            return (x - 1) * len + y;
        }
        public Percolation(int N)
        {
            opcount = 0;
            uf = new PerUF(N);
            size = N * N + 1;
            len = N;
            opId = new int[N + 1][];
            for (int row = 1; row <= N; row++)
            {
                opId[row] = new int[N + 1];
                for (int col = 1; col <= N; col++)
                {
                    opId[row][col] = 0;
                }
            }
        }                //创建n-by-n网格,所有网站被阻止
        public Boolean IsValid(int row, int col)
        {
            if (row < 1 || row > len || col < 1 || col > len)
            {
                return false;
            }
            return true;
        }
        public void open(int row, int col)
        {
            if (isOpen(row, col)) return;
            opId[row][col] = 1;
            opcount++;
            if (row == 1) uf.Union(0, 0, row, col);
            if (row == len) uf.Union(row, col, len + 1, len + 1);
            //上
            if (IsValid(row - 1, col) && isOpen(row - 1, col))
            {
                uf.Union(row, col, row - 1, col);
            }
            //下
            if (IsValid(row + 1, col) && isOpen(row + 1, col))
            {
                uf.Union(row, col, row + 1, col);
            }
            //左
            if (IsValid(row, col - 1) && isOpen(row, col - 1))
            {
                uf.Union(row, col, row, col - 1);
            }
            if (IsValid(row, col + 1) && isOpen(row, col + 1))
            {
                uf.Union(row, col, row, col + 1);
            }
        }    // open site(row,col)如果它尚未
        public Boolean isOpen(int row, int col)
        {
            return opId[row][col] == 1 ? true : false;
        }  //是site(row,col)打开吗？
        public Boolean isFull(int row, int col)
        {
            return uf.Find(row, col) == 0 ? true : false;
        }  //是site(row,col)full？
        public int numberOfOpenSites()
        {
            return opcount;
        }       //开放站点的数量
        public Boolean percolates()
        {
            return isFull(len + 1, len + 1);
        }            //系统是否渗透？

        public static void main(string[] args)
        {
            int index = 0;
            Percolation per = null;
            using (StreamReader sr = new StreamReader(@"C:\Users\xeekseven\Downloads\percolation-testing\percolation\input50.txt", Encoding.UTF8))
            {
                string lineText = string.Empty;
                while ((lineText = sr.ReadLine()) != null)
                {
                    if (index == 0)
                    {
                        int N = int.Parse(lineText.Trim());
                        per = new Percolation(N);
                    }
                    else
                    {
                        int row = -1;
                        int col = -1;
                        string[] openXY = lineText.Split(' ');
                        for(int xyindex=0;xyindex<openXY.Length;xyindex++){
                            if(openXY[xyindex]==""){
                                continue;
                            }
                            if(row==-1){
                                row = int.Parse(openXY[xyindex]);
                            }else{
                                col = int.Parse(openXY[xyindex]);
                            }
                        }
                        if(row==11){
                            int i = row;
                        }
                        per.open(row, col);
                    }
                    index++;
                }

            }
            per.uf.Print();
            Console.WriteLine(per.isFull(per.uf.len+1,per.uf.len+1));
            Console.WriteLine(per.opcount);
        }   // test client(optional)

    }
}
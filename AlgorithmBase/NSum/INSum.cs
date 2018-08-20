using System;
using System.Collections.Generic;

namespace NSum{
     interface INSum{
         void Init(int[] array);
         int BinarySearch(int[] array,int value,int low,int high);

         LinkedList<int[]> GetZeroCount();
     }
}
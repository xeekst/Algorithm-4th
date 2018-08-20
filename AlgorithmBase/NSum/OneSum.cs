using System;
using System.Collections;
using System.Collections.Generic;

namespace NSum{
    class OneSum : INSum
    {
        public int[] numArray;
        public LinkedList<int[]> resultList;
        public void Init(int[] array)
        {
            numArray = array;
            resultList = new LinkedList<int[]>();
        }
        public int BinarySearch(int[] array,int value,int low,int high)
        {
            return -1;
        }

        public LinkedList<int[]> GetZeroCount()
        {
            for(int index=0;index<numArray.Length;index++){
                if(numArray[index]==0){
                    resultList.AddLast(new int[1]{numArray[index]});
                }
            }
            return resultList;
        }

        
    }
}
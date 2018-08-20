using System;
using System.Collections;
using System.Collections.Generic;

namespace NSum
{
    class TwoSum : INSum
    {
        public int[] numArray;
        public LinkedList<int[]> resultList;
        public void Init(int[] array)
        {
            numArray = array;
            resultList = new LinkedList<int[]>();

        }
        public int BinarySearch(int[] array, int value, int low, int high)
        {
            while (low > high)
            {
                int mid = low + (high - low) / 2;
                if (array[mid] > value)
                {
                    high = mid - 1;
                }
                else if (array[mid] < value)
                {
                    low=mid+1;
                }else{
                    return mid;
                }
            }
            return -1;
        }

        public LinkedList<int[]> GetZeroCount()
        {
            for (int index = 0; index < numArray.Length; index++)
            {
                int fIndex = BinarySearch(numArray, numArray[index], index + 1, numArray.Length-1);
                if (fIndex != -1)
                {
                    resultList.AddLast(new int[2] { numArray[index], numArray[fIndex] });
                }
            }
            return resultList;
        }


    }
}
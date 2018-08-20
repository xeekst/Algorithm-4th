using System;
using System.Collections;
using System.Collections.Generic;
using Sort;

namespace NSum
{
    class ThreeSum : INSum
    {
        public int[] numArray;
        public LinkedList<int[]> resultList;
        public void Init(int[] array)
        {
            numArray = array;
            numArray.QuickSort(SortOrder.Asc);
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
                    low = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }

        public LinkedList<int[]> GetZeroCount()
        {
            for (int index = 0; index < numArray.Length; index++)
            {
                for (int jindex = index + 1; jindex < numArray.Length; jindex++)
                {
                    int fvalue = (numArray[index] + numArray[jindex]) * -1;
                    int findex = BinarySearch(numArray, fvalue, jindex + 1, numArray.Length - 1);
                    if (findex != -1)
                    {
                        resultList.AddLast(new int[3] { numArray[index], numArray[jindex], numArray[findex] });
                    }
                }

            }
            return resultList;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class CountInversionsMergeSort
    {
        public void Main()
        {
            int[] arr = [3, 2, 1];
            int ans = MergeSort(arr, 0, arr.Length - 1);
            Console.WriteLine(ans);
        }

        private int MergeSort(int[] arr, int start, int end)
        {
            int count = 0;
            if(start < end)
            {
                int mid = start + (end - start) / 2;
                count += MergeSort(arr, start, mid);
                count += MergeSort(arr, mid + 1, end);

                count += MergeTwoSortedArray(arr, start, mid, end);
            }
            return count;
        }

        private int MergeTwoSortedArray(int[] arr, int start, int mid, int end)
        {
            // divide array into two parts that is left and right
            int leftArrlen = mid - start + 1;
            int rightArrLen = end - mid;

            int[] leftArr = new int[leftArrlen];
            int[] rightArr = new int[rightArrLen];

            // Fill the array
            for(int i = 0; i < leftArrlen; i++)
            {
                leftArr[i] = arr[start + i];
            }

            for(int i = 0; i < rightArrLen; i++)
            {
                rightArr[i] = arr[mid + i + 1];
            }

            int leftIdx = 0, rightIdx = 0, mainIdx = start;
            int count = 0;

            while(leftIdx < leftArrlen && rightIdx < rightArrLen)
            {
                if (leftArr[leftIdx] <= rightArr[rightIdx])
                {
                    arr[mainIdx] = leftArr[leftIdx];
                    mainIdx++;
                    leftIdx++;
                }
                else
                {
                    arr[mainIdx] = rightArr[rightIdx];
                    count += (mid - leftIdx) + 1;
                    mainIdx++;
                    rightIdx++;
                }
            }

            while(leftIdx < leftArrlen)
            {
                arr[mainIdx] = leftArr[leftIdx];
                mainIdx++;
                leftIdx++;
            }

            while(rightIdx < rightArrLen)
            {
                arr[mainIdx] = rightArr[rightIdx];
                mainIdx++;
                rightIdx++;
            }

            return count;
        }

        public void PrintArray(int[] arr)
        {
            foreach(int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}

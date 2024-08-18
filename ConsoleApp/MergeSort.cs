using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class MergeSort
    {
        public void Main()
        {
            int[] arr = { 2, 3, 5, 1, 9, 0 };
            MergeSortArray(arr, 0, arr.Length - 1);
            foreach(int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public void MergeSortArray(int[] arr, int start, int end)
        {
            if(start < end)
            {
                int mid = start + (end - start) / 2;

                MergeSortArray(arr, start, mid);
                MergeSortArray(arr, mid + 1, end);

                MergeTwoSortedArray(arr, start, mid, end);
            }
        }

        private void MergeTwoSortedArray(int[] arr, int start, int mid, int end)
        {
            int leftLen = mid - start + 1;
            int rightLen = end - mid;

            int[] leftArray = new int[leftLen];
            int[] rightArray = new int[rightLen];

            for(int i = 0; i < leftLen; i++)
            {
                leftArray[i] = arr[start + i];
            }

            for(int i = 0; i < rightLen; i++)
            {
                rightArray[i] = arr[mid + i + 1];
            }

            int idx1 = 0, idx2 = 0;
            int k = start;
            while(idx1 < leftLen && idx2 < rightLen)
            {
                if (leftArray[idx1] <= rightArray[idx2])
                {
                    arr[k] = leftArray[idx1];
                    idx1++;
                }
                else
                {
                    arr[k] = rightArray[idx2];
                    idx2++;
                }
                k++;
            }

            while(idx1 < leftLen)
            {
                arr[k] = leftArray[idx1];
                k++;
                idx1++;
            }

            while(idx2 < rightLen)
            {
                arr[k] = rightArray[idx2];
                k++;
                idx2++;
            }
        }
    }
}

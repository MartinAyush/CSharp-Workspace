using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class QuickSort
    {
        public void Main()
        {
            int[] arr = { 4, 5, 2, 5, 0, 1, 8 };
            QuickSortArray(arr, 0, arr.Length - 1);
            foreach(int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        private void Swap(int[] arr, int idx1, int idx2)
        {
            int temp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = temp;
        }

        private void QuickSortArray(int[] arr, int start, int end)
        {
            if(start < end)
            {
                int pivot = FindPivot(arr, start, end);
                QuickSortArray(arr, start, pivot - 1);
                QuickSortArray(arr, pivot + 1, end);
            }
        }

        private int FindPivot(int[] arr, int start, int end)
        {
            int mid = start + (end - start) / 2;

            Swap(arr, end, mid);

            int mainIdx = start;
            for(int i = start; i < end; i++)
            {
                if (arr[i] <= arr[end])
                {
                    Swap(arr, i, mainIdx);
                    mainIdx++;
                }
            }

            Swap(arr, mainIdx, end);
            return mainIdx;
        }
    }
}

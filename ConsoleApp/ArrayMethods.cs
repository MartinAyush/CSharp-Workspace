using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class ArrayMethods
    {
        public void Main()
        {
            List<int> array = new List<int> { 10, 20, 30, 40, 50, 60 };

            // Index of 
            //int ans = Array.IndexOf(array, 30);
            //Console.WriteLine(ans);

            // Binary Search
            //int idx = Array.BinarySearch(array, 30);
            //Console.WriteLine(idx);

            // Clear -> marks the element as 0 from index to the number of elements
            //Array.Clear(array, 2, 2);

            //int firstElement = array[0];
            //int lastElement = array[^1];

            // Add Range
            //List<int> newArray = new List<int>() { 1, 2, 3, 4 };
            //array.AddRange(newArray);

            // Insert Range
            //array.InsertRange(2, newArray);

            // Remove All
            //array.RemoveAll((x) =>
            //{
            //    return x > 10;
            //});

            // Contains 
            //bool flag1 = array.Contains(20);
            //Console.WriteLine(flag1);

            // Exists
            //bool flag = array.Exists((x) => 
            //{
            //    return x > 10 && x < 40;
            //});
            //Console.WriteLine(flag);



            //for (int i = 0; i < array.Count; i++)
            //{
            //    Console.Write(array[i] + " ");
            //}
            //Console.WriteLine();
        }

    }
}

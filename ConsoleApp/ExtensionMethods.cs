using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExtensionMethods
{
    public static class ExtensionMethods
    {
        // Extension methods are a way to add functionality to existing classes without having to modify the class code
        /*
         * Writing Extension method for some CLASS
         * 1. Create a class without the extension method.
         * 2. Create a static class with static method and this as first parameter.
         * 3. Access Extension method as instance method.
         * 
         * NOTE: Import the namespace in which the extension method is defined.
         * 
         * Extension method doesn't support method overriding.
         * We can add extension method to the sealed classes
         * Extension method can't be used to create fields and properties and events.
         */
        public static string ToggleCase(this string input)
        {
            if(input.Length > 0)
            {
                char[] inp = input.ToCharArray();
                inp[0] = Char.IsUpper(input[0]) ? Char.ToLower(input[0]) : Char.ToUpper(input[0]);
                return new string(inp);
            }
            return input;
        }

        // Write an extension method that adds two integers and returns the result.
        public static int AddTwoNumbers(this int num1, int num2)
        {
            return num1 + num2;
        }

        // Write an extension method that checks if a string is a palindrome.
        public static bool IsPalindrome(this string str1)
        {
            var str2 = new string(str1.Reverse().ToArray());
            Console.WriteLine("reversed string {0}", str2);
            return str2 == str1;
        }

        //  Write an extension method that converts a string to uppercase.
        public static string ToUppercase(this string str)
        {
            var ans = from c in str
                      select char.ToUpper(c);

            return new string(ans.ToArray());
        }

        // Write an extension method that finds the maximum value in an array of integers.
        public static int FindMaxValue(this int[] array)
        {
            return array.Max();
        }

        // Write an extension method that reverses the order of the elements in an array.

        // generic extension method
        public static T[] ReverseOrder<T>(this T[] array)
        {
            T[] ans = new T[array.Length];
            for(int i = 0; i < array.Length; ++i)
                ans[array.Length - i - 1] = array[i];

            return ans;
        }

        /*
         * DRIVER CODE
         * //int a1 = 10;
            //int a2 = 20;
            //Console.WriteLine(a1.AddTwoNumbers(a2)); 

            //string str = "NITIN";
            //Console.WriteLine(str.IsPalindrome());

            //string str = "KisdfkHHIUY";
            //Console.WriteLine(str.ToUppercase());

            //int[] arr = { 1, 2, 3, 7, 8, 4 };
            //int ans = arr.FindMaxValue();
            //Console.WriteLine(ans);

            //int[] ans = arr.ReverseOrder();
            //foreach(int ele in ans)
            //{
            //    Console.Write(ele + " ");
            //}
            //Console.WriteLine();

            //char[] str = { 'a', 'b', 'c' };
            //char[] ans2 = str.ReverseOrder();
            //foreach (char ele in ans2)
            //{
            //    Console.Write(ele + " ");
            //}
            //Console.WriteLine();
         */

    }
}

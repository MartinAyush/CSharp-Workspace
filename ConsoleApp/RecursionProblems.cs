using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class RecursionProblems
    {
        public void Main()
        {
            int[] arr = { 1, 2, 1 };
            List<int> output = new List<int>();
            PrintAllPermutationOfString("ABC", "");
        }

        public int countFriendsPairings(int n)
        {
            // Given N friends, each one can remain single or can be paired up with some other friend.
            // Each friend can be paired only once. Find out the total number of ways in which friends can remain single or can be paired up

            if (n == 1 || n == 2)
            {
                // for n = 1 => going single
                // for n = 2 => either both single or a pair
                return n;
            }

            // when a friend is going alone then the other friends are (N - 1) so compute result for (N - 1)
            int alone = countFriendsPairings(n - 1);

            // when a friend is going in a pair, it's block decision of self and a friend going with.
            // so when making a pair with another friend -> people execluded are 2
            // when chosing a friend for a pair choices are -> (N - 1) execluding me
            int pair = (n - 1) * countFriendsPairings(n - 2);

            return alone + pair;
        }

        public int FindPower(int number, int power)
        {
            if(power == 0)
            {
                return 1;
            }

            if(power == 1)
            {
                return number;
            }

            int ans = FindPower(number, power / 2);

            if(power % 2 == 0)
            {
                ans = ans * ans;
            }
            else
            {
                ans = number * ans * ans;
            }

            return ans;
        }

        public void PrintPattern(int rows, int i)
        {
            if(rows == 0)
            {
                return;
            }

            if(i < rows)
            {
                // basically representing => for(int i = 0; i < n; i++)
                Console.Write("* ");
                PrintPattern(rows, i + 1);
            }
            else
            {
                Console.WriteLine();
                PrintPattern(rows - 1, 0);
            }
            return;
        }

        public void PrintPattern2(int rows)
        {
            if(rows == 0)
            {
                return;
            }

            PrintPattern2(rows - 1);
            
            // for eliminating below loop, create a new function and print all the values using recursion
            for(int i = 0; i < rows; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }

        public void PrintSubsets(int[] arr, int idx, string ans)
        {
            if(idx == arr.Length)
            {
                Console.WriteLine(ans);
                return;
            }

            PrintSubsets(arr, idx + 1, ans + arr[idx].ToString());
            PrintSubsets(arr, idx + 1, ans);
            return;
        }

        public bool CheckSortedArray(int[] arr, int len)
        {
            if(len == 0 || len == 1)
            {
                return true;
            }

            if (arr[len - 1] < arr[len - 2])
            {
                return false;
            }

            return CheckSortedArray(arr, len - 1);
        }

        public void PrintPaths(int n, int m, int start1, int start2, string output)
        {
            if(start1 == n - 1 && start2 == m - 1)
            {
                Console.WriteLine(output);
                return;
            }

            if(start1 + 1 <= n) // moving down
            {
                PrintPaths(n, m, start1 + 1, start2, output + "D");
            }
            if(start2 + 1 <= m) // moving right
            {
                PrintPaths(n, m, start1, start2 + 1, output + "R");
            }
            if(start1 + 1 <= n && start2 + 1 <= m) // moving diagonally
            {
                PrintPaths(n, m, start1 + 1, start2 + 1, output + "X");
            }
            return;
        }

        public void JumpPaths(int len, int position, string output)
        {
            if(position == len - 1)
            {
                Console.WriteLine(output);
                return;
            }

            for(int i = 1; i <= 6; i++)
            {
                if((i + position) < len)
                {
                    JumpPaths(len, position + i, output + $"{i}");
                }
            }
            return;
        }

        public void PrintNumbers(int max, int num, ref List<int> ans)
        {
            if(num > max)
            {
                return;
            }

            ans.Add(num);
            Console.WriteLine(num);
            
            for(int i = (num == 0 ? 1 : 0); i <= 9; i++)
            {
                PrintNumbers(max, num * 10 + i, ref ans);
            }
            return;
        }

        public IList<int> LexicalOrder(int n)
        {
            List<int> ans = new List<int>();

            PrintNumbers(n, 0, ref ans);
            ans.RemoveAt(0);
            return (IList<int>)ans;
        }

        public void PrintAllPermutationOfString(string str, string output)
        {
            if(str.Length == 0)
            {
                Console.WriteLine(output);
                return;
            }

            for(int i = 0; i < str.Length; i++)
            {
                string ros = str.Substring(0, i) + str.Substring(i + 1);
                PrintAllPermutationOfString(ros, output + str[i]);
            }
            return;
        }

        public bool PrintAllSubSequence(int[] arr, int ans, int idx, ref List<int> output, int sum)
        {
            if(idx == arr.Length)
            {
                if (sum == ans)
                {
                    foreach (var item in output)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                    return true;
                }
                return false;
            }

            output.Add(arr[idx]);
            sum += arr[idx];
            if(PrintAllSubSequence(arr, ans, idx + 1, ref output, sum) == true)
            {
                return true;
            }
            output.Remove(arr[idx]);
            sum -= arr[idx];
            if(PrintAllSubSequence(arr, ans, idx + 1, ref output, sum) == true)
            {
                return true;
            }
            return false;
        }
    }
}

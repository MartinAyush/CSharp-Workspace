using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using TestApplication;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using CustomExtensionMethods;

namespace ConsoleApp
{
    public class TestClass
    {
        public void Main()
        {
            
        }

        public void PrintList(ListNode head)
        {
            while(head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
            Console.WriteLine();
        }

        public ListNode ReverseLL(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            ListNode next;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;

                prev = curr;
                curr = next;
            }

            return prev;
        }

        public int[] FrequencySort(int[] nums)
        {
            Dictionary<int, int> visited = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (visited.ContainsKey(nums[i]))
                {
                    visited[nums[i]]++;
                }
                else
                {
                    visited.Add(nums[i], 1);
                }
            }

            var some = visited.OrderByDescending(x => x.Key).ThenBy(x => x.Value);
            int[] ans = new int[nums.Length];
            int idx = 0;
            foreach(var item in some)
            {
                ans[idx++] = item.Key;
            }
            return ans;
        }
    }
}
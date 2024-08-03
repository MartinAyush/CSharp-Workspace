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
            string s = "  hello world  ";
            //string ans = ReverseWords(s);
            //Console.Write(ans);
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

        public bool CanBeEqual(int[] target, int[] arr)
        {
            int len1 = target.Length;
            int len2 = arr.Length;

            if(len1 != len2)
            {
                return false;
            }

            Dictionary<int, int> visited = new();
            foreach(int num in target)
            {
                if (visited.ContainsKey(num))
                {
                    visited[num]++;
                }
                else
                {
                    visited.Add(num, 1);
                }
            }

            foreach(int num in arr)
            {
                if (!visited.ContainsKey(num))
                {
                    return false;
                }
                else
                {
                    if (visited[num] == 1)
                    {
                        visited.Remove(num);
                    }
                    else
                    {
                        visited[num]--;

                    }
                }
            }

            return true;
        }
    }

    public class MinStack
    {
        Stack<int> _minValues;
        Stack<int> _mainStack;
        public MinStack()
        {
            _minValues = new Stack<int>();
            _mainStack = new Stack<int>();
        }

        public void Push(int val)
        {
            _mainStack.Push(val);
            if(_minValues.Count == 0 || val <= _minValues.Peek())
            {
                _minValues.Push(val);
            }
        }

        public void Pop()
        {
            if(_mainStack.Count > 0 && _minValues.Count > 0 && _mainStack.Peek() == _minValues.Peek())
            {
                _minValues.Pop();
            }
            _mainStack.Pop();

        }

        public int Top()
        {
            return _mainStack.Peek();
        }

        public int GetMin()
        {
            return _minValues.Peek();
        }
    }
}
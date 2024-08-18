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
using System.Text.RegularExpressions;
using ConsoleApp.StriverDsa;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp
{
    public class TestClass
    {
        public void Main()
        {
        }

        public void PrintLinkedList(ListNode head)
        {
            while(head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
            Console.WriteLine();
        }

        public void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        public bool IsAnagram(string s, string t)
        {
            int[] visited = new int[26];

            foreach(char ch in s)
            {
                visited[ch - 'a']++;
            }

            foreach(char ch in t)
            {
                if(visited[ch - 'a'] > 0)
                {
                    visited[ch - 'a']--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
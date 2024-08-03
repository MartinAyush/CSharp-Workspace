using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class LRUCache
    {
        // LRU => Least Recently Used cache
        /*
         * Using Double linked list to achieve the insertion at O(1)
         * using Dictionary to map key to their node location
         * Intution: when a node is used(get or put) move it next to head
         * so when comes to removing the node, then remove the node which is previous to tail that is second last node
         */
        
        Dictionary<int, Node> _mappings;
        Node _head;
        Node _tail;
        int _cacheCapacity;
        
        public LRUCache(int capacity)
        {
            _head = new Node(-1, -1);
            _tail = new Node(-1, -1);
            _head.Next = _tail;
            _tail.Prev = _head;
            _mappings = new Dictionary<int, Node>();
            _cacheCapacity = capacity;
        }

        public int Get(int key)
        {
            if (!_mappings.ContainsKey(key))
            {
                return -1;
            }
            else
            {
                Node tempNode = _mappings[key];
                Delete(tempNode);
                InsertAfterHead(tempNode);
                return tempNode.Value;
            }
        }

        public void Put(int key, int value)
        {
            if (_mappings.ContainsKey(key))
            {
                Node tempNode = _mappings[key];
                tempNode.Value = value;
                Delete(tempNode);
                InsertAfterHead(tempNode);
            }
            else
            {
                Node newNode = new Node(key, value);
                if(_cacheCapacity == _mappings.Count)
                {
                    Node tempNode = _tail.Prev;
                    Delete(tempNode);   
                    InsertAfterHead(newNode);
                }
                else
                {
                    InsertAfterHead(newNode);
                }
            }
        }

        private void Delete(Node node)
        {
            _mappings.Remove(node.Key);

            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }

        private void InsertAfterHead(Node node)
        {
            _mappings[node.Key] = node;

            node.Next = _head.Next;
            node.Next.Prev = node;
            _head.Next = node;
            node.Prev = _head;
        }
    }

    class Node 
    {
        public Node Next { get; set; }
        public Node Prev { get; set; }
        public int Key { get; set; }
        public int Value { get; set; }

        public Node(int key, int value)
        {
            this.Next = null;
            this.Prev = null;
            this.Key = key;
            this.Value = value;
        }
    }

}

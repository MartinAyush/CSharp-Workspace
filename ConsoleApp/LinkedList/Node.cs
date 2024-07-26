using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public class Node
    {
        // Each node in the linked list
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node Bottom { get; set; }

        //public Node Prev { get; set; } // DLL
        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
            this.Bottom = null;
            //this.Prev = null; // DLL
        }
    }

}

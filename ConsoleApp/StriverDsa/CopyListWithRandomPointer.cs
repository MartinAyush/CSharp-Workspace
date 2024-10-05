using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class CopyListWithRandomPointer
    {
        public void Main()
        {

        }

        //public Node CopyRandomList(Node head)
        //{
        //    if(head == null)
        //    {
        //        return null;
        //    }

        //    Dictionary<Node, Node> mappings = new Dictionary<Node, Node>();
        //    // create dummy nodes and put them in mapping with original nodes

        //    Node temp = head;

        //    while(temp != null)
        //    {
        //        mappings.Add(temp, new Node(temp.val));
        //        temp = temp.next;
        //    }

        //    // mark next and random pointers to correct location

        //    temp = head;

        //    while(temp != null)
        //    {
        //        if(temp.next == null)
        //        {
        //            mappings[temp].next = null;
        //        }
        //        else
        //        {
        //            mappings[temp].next = mappings[temp.next];
        //        }

        //        if(temp.random == null)
        //        {
        //            mappings[temp].random = null;
        //        }
        //        else
        //        {
        //            mappings[temp].random = mappings[temp.random];
        //        }

        //        temp = temp.next;
        //    }

        //    return mappings[head];
        //}
    }

    //public class Node
    //{
    //    public int val;
    //    public Node next;
    //    public Node random;

    //    public Node(int _val)
    //    {
    //        val = _val;
    //        next = null;
    //        random = null;
    //    }
    //}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.LinkedList
{
    public class CircularLinkedList
    {
        private Node head;

        public CircularLinkedList()
        {
            this.head = null;
        }

        public void InsertAtHead(int data)
        {
            Node newNode = new Node(data);
            if(head == null)
            {
                head = newNode;
                head.Next = head;
            }
            else
            {
                Node temp = head;
                do
                {
                    temp = temp.Next;
                }
                while (temp != head);

                temp.Next = newNode;
                newNode.Next = head;
                head = newNode;
            }
        }

        public void PrintLL()
        {
            Node temp = head;
            do
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
            while (temp != head);
            
            Console.WriteLine();
        }


        /*
         CircularLinkedList head = new CircularLinkedList();
            head.InsertAtHead(10);
            head.InsertAtHead(20);
            head.InsertAtHead(30);
            head.InsertAtHead(40);
            head.PrintLL();
         */
    }
}

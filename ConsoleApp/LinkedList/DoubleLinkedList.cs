using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class DoubleLinkedList
    {
        /*
         DoubleLinkedList dll = new DoubleLinkedList();
            dll.InsertAtHead(10);
            dll.InsertAtHead(20);
            dll.Traverse();
            dll.InsertAtTail(30);
            dll.Traverse();
            dll.InsertAtPosition(40, 2);
            dll.Traverse();
            dll.InsertAtPosition(50, 2);
            dll.Traverse();
            dll.DeleteHead();
            dll.Traverse();
            dll.DeleteTail();
            dll.Traverse();
            dll.DeleteAtPosition(3);
            dll.Traverse();
            dll.ReverseDLL();
            dll.Traverse();
         */
        //private Node head;
        //public DoubleLinkedList()
        //{
        //    this.head = null;
        //}
        //public void Traverse()
        //{
        //    Node temp = head;
        //    while(temp != null)
        //    {
        //        Console.Write(temp.Data + " -> ");
        //        temp = temp.Next;
        //    }
        //    Console.Write("NULL\n");
        //}
        //public void InsertAtHead(int data)
        //{
        //    Node newNode = new Node(data);
        //    if(head == null)
        //    {
        //        head = newNode;
        //    }
        //    else
        //    {
        //        newNode.Next = head;
        //        head.Prev = newNode;
        //        head = newNode;
        //    }
        //}
        //public void InsertAtTail(int data)
        //{
        //    Node newNode = new Node(data);
        //    Node temp = head;
        //    while(temp.Next != null)
        //    {
        //        temp = temp.Next;
        //    }
        //    temp.Next = newNode;
        //    newNode.Prev = temp;
        //}
        //public void InsertAtPosition(int data, int position)
        //{
        //    Node newNode = new Node(data);
        //    Node temp = head;
        //    for(int i = 1; i < position-1; i++)
        //    {
        //        temp = temp.Next;
        //    }

        //    newNode.Next = temp.Next;
        //    temp.Next = newNode;
        //    newNode.Next.Prev = newNode;
        //    newNode.Prev = temp;
        //}

        //public void DeleteHead()
        //{
        //    head = head.Next;
        //    head.Prev = null;
        //}
        //public void DeleteTail()
        //{
        //    Node temp = head;
        //    while(temp.Next.Next != null)
        //        temp = temp.Next;

        //    temp.Next = null;
        //}
        //public void DeleteAtPosition(int position)
        //{
        //    Node temp = head;
        //    for(int i = 1; i < position - 1; i++)
        //    {
        //        temp = temp.Next;
        //    }

        //    temp.Next = temp.Next.Next;
        //    temp.Next.Prev = temp;

        //}
    }
}

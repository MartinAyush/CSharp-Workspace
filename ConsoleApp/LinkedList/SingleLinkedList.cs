using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class SingleLinkedList
    {
        private Node head;

        public SingleLinkedList(Node node)
        {
            this.head = node;
        }

        public Node GiveHeadNode()
        {
            return head;
        }

        public void TraverseAll()
        {
            Node temp = head;
            while(temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }

        public void InsertAtHead(int data)
        {
            Node newNode = new Node(data);
            if(head == null)
                head = newNode;
            else
            {
                newNode.Next = head;
                head = newNode;
            }

        }

        public void InsertAtTail(int data)
        {
            Node newNode = new Node(data);
            if(head == null)
            {
                head = newNode;
            }
            else
            {
                Node temp = head;
                while(temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
            }
        }

        public void InsertAtPosition(int data, int position)
        {
            Node newNode = new Node(data);
            if(head == null)
            {
                head = newNode;
            }
            else
            {
                int pos = 2;
                Node temp = head;
                while(pos < position)
                {
                    temp = temp.Next;
                    pos++;
                }

                newNode.Next = temp.Next;
                temp.Next = newNode;
            }
        }

        public void DeleteHead()
        {
            if(head != null)
                head = head.Next;
        }

        public void DeleteTail()
        {
            if(head == null)
            {
                return;
            }
            else
            {
                Node temp = head;
                while(temp.Next.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = null;
            }
        }

        public void DeleteAtPosition(int position)
        {
            Node temp = head;
            int pos = 2;
            while(pos < position)
            {
                temp = temp.Next;
                pos++;
            }

            temp.Next = temp.Next.Next;
        }

        public void PrintRecursive(Node head)
        {
            if(head == null)
            {
                Console.WriteLine();
                return;
            }

            Console.Write(head.Data + " ");
            PrintRecursive(head.Next);
        }

        public void ReverseLL()
        {
            Node prev = null;
            Node curr = head;
            Node next;

            while(curr != null)
            {
                next = curr.Next;
                curr.Next = prev;

                prev = curr;
                curr = next;
            }

            head = prev;
        }

        public void MiddleOfLL()
        {
            Node slow = head;
            Node fast = head;

            while(fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Console.WriteLine(slow.Data);
        }

        public void MakeCycle()
        {
            Node temp = head;
            Node startCycle = null;
            int pos = 3;

            while(temp.Next != null)
            {
                if (pos == 0)
                    startCycle = temp;

                temp = temp.Next;
                pos--;
            }

            temp.Next = startCycle;

        }

        public void DetectCycle()
        {
            Node slow = head;
            Node fast = head;

            while(fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next;

                if(slow == fast)
                {
                    Console.WriteLine("True");
                    return;
                }
            }

            Console.WriteLine("No Cycle detected");
        }

        public void SegregateLL()
        {
            Node oddStart = null;
            Node evenStart = null;
            Node oddEnd = null;
            Node evenEnd = null;
            Node temp = head;
            while(temp != null)
            {
                int element = temp.Data;
                if(element % 2 == 0)
                {
                    // even
                    if(evenStart == null)
                    {
                        evenStart = temp;
                        evenEnd = evenStart;
                    }
                    else
                    {
                        evenEnd.Next = temp;
                        evenEnd = evenEnd.Next;
                    }
                }
                else
                {
                    // odd
                    if(oddStart == null)
                    {
                        oddStart = temp;
                        oddEnd = oddStart;
                    }
                    else
                    {
                        oddEnd.Next = temp;
                        oddEnd = oddEnd.Next;
                    }
                }
                temp = temp.Next;
            }

            evenEnd.Next = oddStart;
            oddEnd.Next = null;
            head = evenStart;
        }

        

        /*
          SingleLinkedList head = new SingleLinkedList();
            head.InsertAtHead(1);
            //head.InsertAtHead(20);
            //head.InsertAtHead(30);
            //head.TraverseAll();
            //head.InsertAtTail(50);
            //head.TraverseAll();
            //head.InsertAtPosition(40, 3);
            //head.TraverseAll();
            //head.DeleteHead();
            //head.TraverseAll();
            //head.DeleteTail();
            //head.TraverseAll();
            //head.DeleteAtPosition(2);
            //head.TraverseAll();

            //Node head2 = head.GiveHeadNode();
            //head.PrintRecursive(head2);

            head.InsertAtTail(2);
            head.InsertAtTail(3);
            head.InsertAtTail(4);
            head.InsertAtTail(5);
            head.InsertAtTail(6);
            head.InsertAtTail(7);
            head.TraverseAll();

            //head.ReverseLL();
            //head.TraverseAll();
            //head.MiddleOfLL();
            //head.MakeCycle();
            //head.DetectCycle();
            //head.TraverseAll();

            head.SegregateLL();
            head.TraverseAll();
         */
    }
}

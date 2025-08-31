using System.Collections.Generic;

namespace GameScriptManager
{
    public class StoryNodeLinkedList
    {
        public Node Head { get; private set; }

        public void AddNode(int number, string text)
        {
            Node newNode = new Node(number, text);
            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node cur = Head;
            while (cur.Next != null) cur = cur.Next;
            cur.Next = newNode;
        }

        // Public sort entry
        public void Sort()
        {
            Head = MergeSort(Head);
        }

        // MergeSort for linked list
        private Node MergeSort(Node head)
        {
            if (head == null || head.Next == null) return head;

            Node middle = GetMiddle(head);
            Node right = middle.Next;
            middle.Next = null;

            Node leftSorted = MergeSort(head);
            Node rightSorted = MergeSort(right);

            return SortedMerge(leftSorted, rightSorted);
        }

        private Node SortedMerge(Node a, Node b)
        {
            if (a == null) return b;
            if (b == null) return a;

            Node result;
            if (a.StoryNumber <= b.StoryNumber)
            {
                result = a;
                result.Next = SortedMerge(a.Next, b);
            }
            else
            {
                result = b;
                result.Next = SortedMerge(a, b.Next);
            }
            return result;
        }

        // fast/slow pointer
        private Node GetMiddle(Node head)
        {
            if (head == null) return head;
            Node slow = head, fast = head.Next;
            while (fast != null)
            {
                fast = fast.Next;
                if (fast != null)
                {
                    slow = slow.Next;
                    fast = fast.Next;
                }
            }
            return slow;
        }

        // Convert to list of strings for UI
        public List<string> ToStringList()
        {
            List<string> list = new List<string>();
            Node cur = Head;
            while (cur != null)
            {
                list.Add(cur.ToString());
                cur = cur.Next;
            }
            return list;
        }

        // Convert to list of Node references (if you prefer)
        public List<Node> ToNodeList()
        {
            List<Node> list = new List<Node>();
            Node cur = Head;
            while (cur != null)
            {
                list.Add(cur);
                cur = cur.Next;
            }
            return list;
        }
    }
}

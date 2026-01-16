using System;
using BrowserBuddy.Nodes;

namespace BrowserBuddy.Tabs
{
    class BrowserTab
    {
        private HistoryNode head;
        private HistoryNode current;

        public BrowserTab(string homePage)
        {
            head = new HistoryNode(homePage);
            current = head;
        }

        public void Visit(string url)
        {
            HistoryNode newNode = new HistoryNode(url);

            current.Next = null;   // clear forward history
            newNode.Prev = current;
            current.Next = newNode;
            current = newNode;

            Console.WriteLine("Visited: " + url);
        }

        public void Back()
        {
            if (current.Prev != null)
            {
                current = current.Prev;
                Console.WriteLine("Back to: " + current.Url);
            }
            else
            {
                Console.WriteLine("No previous page");
            }
        }

        public void Forward()
        {
            if (current.Next != null)
            {
                current = current.Next;
                Console.WriteLine("Forward to: " + current.Url);
            }
            else
            {
                Console.WriteLine("No forward page");
            }
        }

        public void ShowCurrent()
        {
            Console.WriteLine("Current Page: " + current.Url);
        }

        public HistoryNode GetHistoryHead()
        {
            return head;
        }
    }
}

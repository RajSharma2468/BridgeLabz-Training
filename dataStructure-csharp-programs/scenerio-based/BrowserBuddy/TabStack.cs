using System;
using BrowserBuddy.Nodes;

namespace BrowserBuddy.Stack
{
    class TabStack
    {
        private HistoryNode[] stack;
        private int top;

        public TabStack(int size)
        {
            stack = new HistoryNode[size];
            top = -1;
        }

        public void Push(HistoryNode tabHistory)
        {
            stack[++top] = tabHistory;
        }

        public HistoryNode Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("No closed tabs to restore");
                return null;
            }
            return stack[top--];
        }
    }
}

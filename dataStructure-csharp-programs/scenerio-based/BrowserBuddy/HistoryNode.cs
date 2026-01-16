using System;

namespace BrowserBuddy.Nodes
{
    class HistoryNode
    {
        public string Url;
        public HistoryNode Prev;
        public HistoryNode Next;

        public HistoryNode(string url)
        {
            Url = url;
            Prev = null;
            Next = null;
        }
    }
}

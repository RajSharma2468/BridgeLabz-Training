using System;
using BrowserBuddy.Tabs;
using BrowserBuddy.Stack;
using BrowserBuddy.Nodes;

namespace BrowserBuddy
{
    class Program
    {
        static void Main()
        {
            TabStack closedTabs = new TabStack(5);

            BrowserTab tab1 = new BrowserTab("google.com");
            tab1.Visit("youtube.com");
            tab1.Visit("github.com");

            tab1.Back();
            tab1.Forward();

            Console.WriteLine("\nClosing Tab...");
            closedTabs.Push(tab1.GetHistoryHead());

            Console.WriteLine("\nRestoring Last Closed Tab...");
            HistoryNode restoredHistory = closedTabs.Pop();

            if (restoredHistory != null)
            {
                BrowserTab restoredTab = new BrowserTab(restoredHistory.Url);
                restoredTab.ShowCurrent();
            }
        }
    }
}

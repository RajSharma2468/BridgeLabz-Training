using System;

class TextNode
{
    public string text;
    public TextNode prev, next;

    public TextNode(string text)
    {
        this.text = text;
    }
}

class TextEditor
{
    TextNode current;

    public void Add(string text)
    {
        TextNode node = new TextNode(text);

        if (current != null)
        {
            current.next = node;
            node.prev = current;
        }
        current = node;
    }

    public void Undo()
    {
        if (current != null && current.prev != null)
            current = current.prev;

        Console.WriteLine("Current Text: " + current.text);
    }
}

class Program
{
    static void Main()
    {
        TextEditor te = new TextEditor();
        te.Add("Hello");
        te.Add("Hello World");
        te.Undo();
    }
}

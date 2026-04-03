internal class Book
{
    private string title;
    private string author;

    public Book(string title, string author)
    {
        this.title = title;
        this.author = author;
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetAuthor()
    {
        return author;
    }

    public void SetTitle(string title)
    {
        this.title = title;
    }

    public void SetAuthor(string author)
    {
        this.author= author;
    }

    public override string ToString()
    {
        return $"Book Title: {title} | Book Author: {author}";
    }
}
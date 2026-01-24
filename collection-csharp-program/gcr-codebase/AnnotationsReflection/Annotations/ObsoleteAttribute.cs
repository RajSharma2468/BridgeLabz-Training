using System;

class LegacyAPI
{
    [Obsolete("OldFeature is obsolete. Use NewFeature instead.")]
    public void OldFeature()
    {
        Console.WriteLine("Old Feature Executed");
    }

    public void NewFeature()
    {
        Console.WriteLine("New Feature Executed");
    }
}

class Program
{
    static void Main()
    {
        LegacyAPI api = new LegacyAPI();
        api.OldFeature();   // Warning
        api.NewFeature();
    }
}

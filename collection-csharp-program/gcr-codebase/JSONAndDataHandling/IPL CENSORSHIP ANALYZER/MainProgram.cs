using System;

class Program
{
    static void Main()
    {
        var jsonMatches = JsonIplProcessor.Read("ipl_input.json");
        JsonIplProcessor.ApplyCensorship(jsonMatches);
        JsonIplProcessor.Write("ipl_output.json", jsonMatches);

        var csvMatches = CsvIplProcessor.Read("ipl_input.csv");
        CsvIplProcessor.Apply(csvMatches);
        CsvIplProcessor.Write("ipl_output.csv", csvMatches);

        Console.WriteLine("Censorship Done");
    }
}

using System.Collections.Generic;
using System.IO;

public class CsvMatch
{
    public int match_id;
    public string team1;
    public string team2;
    public int score_team1;
    public int score_team2;
    public string winner;
    public string player_of_match;
}

public static class CsvIplProcessor
{
    public static List<CsvMatch> Read(string path)
    {
        var lines = File.ReadAllLines(path);
        var list = new List<CsvMatch>();

        for (int i = 1; i < lines.Length; i++)
        {
            var p = lines[i].Split(',');

            CsvMatch m = new CsvMatch();
            m.match_id = int.Parse(p[0]);
            m.team1 = p[1];
            m.team2 = p[2];
            m.score_team1 = int.Parse(p[3]);
            m.score_team2 = int.Parse(p[4]);
            m.winner = p[5];
            m.player_of_match = p[6];

            list.Add(m);
        }

        return list;
    }

    public static void Apply(List<CsvMatch> matches)
    {
        foreach (var m in matches)
        {
            m.team1 = Censor.MaskTeam(m.team1);
            m.team2 = Censor.MaskTeam(m.team2);
            m.winner = Censor.MaskTeam(m.winner);
            m.player_of_match = "REDACTED";
        }
    }

    public static void Write(string path, List<CsvMatch> matches)
    {
        var lines = new List<string>();
        lines.Add("match_id,team1,team2,score_team1,score_team2,winner,player_of_match");

        foreach (var m in matches)
        {
            string line = m.match_id + "," +
                          m.team1 + "," +
                          m.team2 + "," +
                          m.score_team1 + "," +
                          m.score_team2 + "," +
                          m.winner + "," +
                          m.player_of_match;

            lines.Add(line);
        }

        File.WriteAllLines(path, lines);
    }
}

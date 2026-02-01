using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public static class JsonIplProcessor
{
    public static List<IplMatch> Read(string path)
    {
        return JsonConvert.DeserializeObject<List<IplMatch>>(File.ReadAllText(path));
    }

    public static void Write(string path, List<IplMatch> matches)
    {
        File.WriteAllText(path, JsonConvert.SerializeObject(matches, Formatting.Indented));
    }

    public static void ApplyCensorship(List<IplMatch> matches)
    {
        foreach (var m in matches)
        {
            m.team1 = Censor.MaskTeam(m.team1);
            m.team2 = Censor.MaskTeam(m.team2);
            m.winner = Censor.MaskTeam(m.winner);
            m.player_of_match = "REDACTED";

            var newScore = new Dictionary<string, int>();

            foreach (var s in m.score)
            {
                newScore[Censor.MaskTeam(s.Key)] = s.Value;
            }

            m.score = newScore;
        }
    }
}

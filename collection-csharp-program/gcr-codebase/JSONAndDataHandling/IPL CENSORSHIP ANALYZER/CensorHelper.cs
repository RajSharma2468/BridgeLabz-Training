public static class Censor
{
    public static string MaskTeam(string team)
    {
        var parts = team.Split(' ');
        if (parts.Length > 1)
            parts[1] = "***";

        return string.Join(" ", parts);
    }
}

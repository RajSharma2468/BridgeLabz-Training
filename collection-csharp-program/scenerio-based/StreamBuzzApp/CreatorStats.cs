using System;

public class CreatorStats
{
    public string CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }

    public CreatorStats(string creatorName, double[] weeklyLikes)
    {
        CreatorName = creatorName;
        WeeklyLikes = weeklyLikes;
    }
}

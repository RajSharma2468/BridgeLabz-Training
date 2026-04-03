using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        UserProfile user = new UserProfile("Rahul", 22);

        List<Workout> workouts = new List<Workout>();
        workouts.Add(new CardioWorkout("Running", 30));
        workouts.Add(new StrengthWorkout("Weight Training", 45));

        Console.WriteLine("FITTRACK FITNESS TRACKER");
        Console.WriteLine("------------------------");

        user.DisplayUser();
        Console.WriteLine();

        foreach (Workout w in workouts)
        {
            w.DisplayWorkout();
            Console.WriteLine("Calories Burned : " + w.CalculateCalories());

            if (w is ITrackable)
            {
                ((ITrackable)w).Track();
            }

            Console.WriteLine("------------------------");
        }
    }
}

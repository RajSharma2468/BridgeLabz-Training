abstract class Workout
{
    protected string workoutName;
    protected int duration;

    public Workout(string name, int duration)
    {
        this.workoutName = name;
        this.duration = duration;
    }

    public abstract int CalculateCalories();

    public virtual void DisplayWorkout()
    {
        Console.WriteLine("Workout Name : " + workoutName);
        Console.WriteLine("Duration     : " + duration + " minutes");
    }
}

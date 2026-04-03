class StrengthWorkout : Workout, ITrackable
{
    public StrengthWorkout(string name, int duration)
        : base(name, duration) { }

    public override int CalculateCalories()
    {
        return duration * 6;
    }

    public void Track()
    {
        Console.WriteLine("Tracking strength workout");
    }
}

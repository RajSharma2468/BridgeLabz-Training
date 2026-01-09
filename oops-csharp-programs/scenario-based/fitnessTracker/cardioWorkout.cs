class CardioWorkout : Workout, ITrackable
{
    public CardioWorkout(string name, int duration)
        : base(name, duration) { }

    public override int CalculateCalories()
    {
        return duration * 8;
    }

    public void Track()
    {
        Console.WriteLine("Tracking cardio workout");
    }
}

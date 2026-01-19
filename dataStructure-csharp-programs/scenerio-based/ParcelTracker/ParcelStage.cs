internal class ParcelStage
{
    public string StageName;
    public ParcelStage Next;

    public ParcelStage(string stageName)
    {
        StageName = stageName;
        Next = null;
    }

    public override string ToString()
    {
        return StageName;
    }
}

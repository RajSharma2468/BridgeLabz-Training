internal class UserSteps
{
    private string _userName;
    private int _steps;

    public UserSteps(string name, int steps)
    {
        _userName = name;
        _steps = steps;
    }

    public string GetUserName()
    {
        return _userName;
    }

    public int GetSteps()
    {
        return _steps;
    }

    public void UpdateSteps(int steps)
    {
        _steps = steps;
    }

    public override string ToString()
    {
        return _userName + " - " + _steps + " steps";
    }
}

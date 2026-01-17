using System;

internal class FitnessTrackerUtility : IFitnessTracker
{
    private UserSteps[] _users;
    private int _count;

    public FitnessTrackerUtility()
    {
        _users = new UserSteps[20]; // small group
        _count = 0;
    }

    public void AddOrUpdateUser()
    {
        Console.Write("\nEnter user name: ");
        string name = Console.ReadLine();

        Console.Write("Enter steps: ");
        int steps = int.Parse(Console.ReadLine());

        // Check if user exists → frequent updates
        for (int i = 0; i < _count; i++)
        {
            if (_users[i].GetUserName().Equals(name))
            {
                _users[i].UpdateSteps(steps);
                BubbleSort();
                Console.WriteLine("Steps updated successfully!");
                return;
            }
        }

        // New user
        _users[_count++] = new UserSteps(name, steps);
        BubbleSort();
        Console.WriteLine("User added successfully!");
    }

    public void ShowLeaderboard()
    {
        Console.WriteLine("\n🏆 DAILY STEP LEADERBOARD\n");

        if (_count == 0)
        {
            Console.WriteLine("No users available\n");
            return;
        }

        for (int i = 0; i < _count; i++)
        {
            Console.WriteLine((i + 1) + ". " + _users[i]);
        }
    }

    // ---------------- BUBBLE SORT ----------------
    private void BubbleSort()
    {
        for (int i = 0; i < _count - 1; i++)
        {
            for (int j = 0; j < _count - i - 1; j++)
            {
                if (_users[j].GetSteps() < _users[j + 1].GetSteps())
                {
                    UserSteps temp = _users[j];
                    _users[j] = _users[j + 1];
                    _users[j + 1] = temp;
                }
            }
        }
    }
}

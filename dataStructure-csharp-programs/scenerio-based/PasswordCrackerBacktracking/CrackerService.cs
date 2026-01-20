using Algorithms;

namespace Services
{
    public class CrackerService
    {
        public void StartCracking(string password, int length)
        {
            PasswordCracker cracker = new PasswordCracker();
            cracker.Start(password, length);
        }
    }
}

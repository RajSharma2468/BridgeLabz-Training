using System.Text.RegularExpressions;

namespace EmployeeWageApp.Utils
{
    public static class Validator
    {
        public static bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[A-Za-z\s]+$");
        }
    }
}

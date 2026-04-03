using System.Text.RegularExpressions;

namespace HealthCareApp.Utilities
{
    public static class RegexValidator
    {
        public static bool ValidatePhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        public static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
    }
}

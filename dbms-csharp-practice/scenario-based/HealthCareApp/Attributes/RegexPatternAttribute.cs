using System;
using System.Text.RegularExpressions;

namespace HealthCareApp.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RegexPatternAttribute : Attribute
    {
        public string Pattern { get; set; }

        public RegexPatternAttribute(string pattern)
        {
            Pattern = pattern;
        }

        public bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;

            return Regex.IsMatch(value, Pattern);
        }
    }
}

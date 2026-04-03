using EmployeeWageApp.Attributes;

namespace EmployeeWageApp.Models
{
    [InfoAttribute("Employee class with required properties")]
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public int DailyHours { get; set; }
        public int TotalHoursWorked { get; set; }

        public Employee() { }

        public Employee(string name, string type)
        {
            Name = name;
            Type = type;
            DailyHours = 0;
            TotalHoursWorked = 0;
        }
    }
}

namespace EmployeeWageComputation.Models
{
    class Employee : EmployeeBase
    {
        public Employee(int wage, int fullHours, int partHours)
        {
            wagePerHour = wage;
            fullDayHours = fullHours;
            partTimeHours = partHours;
        }

        public override int GetWagePerHour()
        {
            return wagePerHour;
        }

        public int GetFullDayHours()
        {
            return fullDayHours;
        }

        public int GetPartTimeHours()
        {
            return partTimeHours;
        }
    }
}

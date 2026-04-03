namespace EmployeeWageComputation.Models
{
    abstract class EmployeeBase
    {
        protected int wagePerHour;
        protected int fullDayHours;
        protected int partTimeHours;

        public abstract int GetWagePerHour();
    }
}

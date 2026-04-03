namespace EmployeeWageComputation.Interfaces
{
    interface IWageCalculator
    {
        void CalculateDailyWage();
        void CalculateMonthlyWage(int maxDays, int maxHours);
    }
}

using System;

// ================= INTERFACE =================
interface IApprovable
{
    bool ApproveLoan();
    double CalculateEMI();
}

// ================= APPLICANT =================
class Applicant
{
    private string name;
    private int creditScore;
    private double income;
    private double loanAmount;

    public Applicant(string name, int creditScore, double income, double loanAmount)
    {
        this.name = name;
        this.creditScore = creditScore;
        this.income = income;
        this.loanAmount = loanAmount;
    }

    public string GetName()
    {
        return name;
    }

    public double GetIncome()
    {
        return income;
    }

    public double GetLoanAmount()
    {
        return loanAmount;
    }

    // only accessible inside package / derived classes
    protected internal int GetCreditScore()
    {
        return creditScore;
    }
}

// ================= BASE LOAN CLASS =================
abstract class LoanApplication : IApprovable
{
    protected Applicant applicant;
    protected int term;               // months
    protected double interestRate;    // annual %
    private bool approved;

    protected LoanApplication(Applicant applicant, int term, double interestRate)
    {
        this.applicant = applicant;
        this.term = term;
        this.interestRate = interestRate;
    }

    protected void SetApprovalStatus(bool status)
    {
        approved = status;
    }

    public bool IsApproved()
    {
        return approved;
    }

    protected double EmiFormula(double principal, double annualRate, int months)
    {
        double R = annualRate / (12 * 100);
        return (principal * R * Math.Pow(1 + R, months)) /
               (Math.Pow(1 + R, months) - 1);
    }

    public abstract bool ApproveLoan();
    public abstract double CalculateEMI();
}

// ================= PERSONAL LOAN =================
class PersonalLoan : LoanApplication
{
    public PersonalLoan(Applicant applicant, int term)
        : base(applicant, term, 12.5)
    {
    }

    public override bool ApproveLoan()
    {
        if (applicant.GetCreditScore() >= 650 &&
            applicant.GetIncome() >= 30000)
        {
            SetApprovalStatus(true);
        }
        else
        {
            SetApprovalStatus(false);
        }

        return IsApproved();
    }

    public override double CalculateEMI()
    {
        return EmiFormula(applicant.GetLoanAmount(), interestRate, term);
    }
}

// ================= HOME LOAN =================
class HomeLoan : LoanApplication
{
    public HomeLoan(Applicant applicant, int term)
        : base(applicant, term, 8.5)
    {
    }

    public override bool ApproveLoan()
    {
        if (applicant.GetCreditScore() >= 700 &&
            applicant.GetIncome() >= 50000)
        {
            SetApprovalStatus(true);
        }
        else
        {
            SetApprovalStatus(false);
        }

        return IsApproved();
    }

    public override double CalculateEMI()
    {
        return EmiFormula(applicant.GetLoanAmount(), interestRate, term);
    }
}

// ================= AUTO LOAN =================
class AutoLoan : LoanApplication
{
    public AutoLoan(Applicant applicant, int term)
        : base(applicant, term, 9.5)
    {
    }

    public override bool ApproveLoan()
    {
        if (applicant.GetCreditScore() >= 680 &&
            applicant.GetIncome() >= 35000)
        {
            SetApprovalStatus(true);
        }
        else
        {
            SetApprovalStatus(false);
        }

        return IsApproved();
    }

    public override double CalculateEMI()
    {
        return EmiFormula(applicant.GetLoanAmount(), interestRate, term);
    }
}

// ================= MAIN =================
class LoanBuddyApp
{
    static void Main(string[] args)
    {
        Applicant applicant = new Applicant(
            "Rahul Sharma",
            720,
            60000,
            500000
        );

        LoanApplication loan = new HomeLoan(applicant, 240);

        Console.WriteLine("Applicant Name: " + applicant.GetName());

        if (loan.ApproveLoan())
        {
            Console.WriteLine("Loan Approved");
            Console.WriteLine("Monthly EMI: " +
                loan.CalculateEMI().ToString("0.00"));
        }
        else
        {
            Console.WriteLine("Loan Rejected");
        }
    }
}

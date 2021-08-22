using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bank_API.Models
{
    public class LoanData
    {
        double LoanAmmount;
        int LoanDurationInMonths;
        double AdminFees;
        double MonthlyPayment;
        double TotalInterest;
        double APR;

        public LoanData(double LoanAmmount, int LoanDurationInMonths, double AdminFees, double MonthlyPayment, double TotalInterest, double APR)
        {
            this.LoanAmmount = LoanAmmount;
            this.LoanDurationInMonths = LoanDurationInMonths;
            this.AdminFees = AdminFees;
            this.MonthlyPayment = MonthlyPayment;
            this.TotalInterest = TotalInterest;
            this.APR = APR;
        }

        public double MoneyLoaned => LoanAmmount;
        public int LoanLengthInMonths => LoanDurationInMonths;
        public double TotalAdminFees => AdminFees;
        public double SingleMonthlyPayment => MonthlyPayment;
        public double FullInterest => TotalInterest;
        public double APRPercentage => APR;
    }
}
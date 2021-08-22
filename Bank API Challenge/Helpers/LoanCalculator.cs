using System;

namespace Bank_API.Helpers
{
    public static class LoanCalculator
    {
        public static double CalculateMonthlyPayment(double LoanAmmount, double InterestRate, int LoanDurationInMonths, int PaymentsInAYear)
        {
            double InterestRatePerPayment = ((InterestRate / 100) / PaymentsInAYear);
            // Formula from calculatorsoup.com
            double MonthlyPayment = (LoanAmmount * InterestRatePerPayment * Math.Pow(1 + InterestRatePerPayment, LoanDurationInMonths)) / (Math.Pow(1 + InterestRatePerPayment, LoanDurationInMonths) - 1);

            return MonthlyPayment;
        }

        public static double CalculateTotalInterest(double LoanAmmount, double InterestRate, int LoanDurationInMonths, int PaymentsInAYear)
        {
            return (CalculateMonthlyPayment(LoanAmmount, InterestRate, LoanDurationInMonths, PaymentsInAYear) * LoanDurationInMonths) - LoanAmmount;
        }

        public static double CalculateAdminFees(double LoanAmmount)
        {
            if (LoanAmmount * 0.01 < 10000)
                return LoanAmmount * 0.01;
            else
                return 10000;
        }

        public static double CalculateAPR(double LoanAmmount, double InterestRate, int LoanDurationInMonths, int PaymentsInAYear)
        {
            double LoanWithFees = CalculateTotalInterest(LoanAmmount, InterestRate, LoanDurationInMonths, PaymentsInAYear) + CalculateAdminFees(LoanAmmount);
            // percentage APR formula from www.easyunitconverter.com
            return ((LoanWithFees / LoanAmmount) / (365 * (LoanDurationInMonths / 12))) * 365 * 100;

        }

    }
}
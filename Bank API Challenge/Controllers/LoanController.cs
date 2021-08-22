using Bank_API.Helpers;
using Bank_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bank_API_Challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        // GET /Loan?AuthToken= &LoanAmmount= &LoanDurationInMonths= &InterestRate= &PaymentsInAYear= 
        [HttpGet]
        public ActionResult GetLoanData(string AuthToken, double LoanAmmount, int LoanDurationInMonths, double InterestRate = 5, int PaymentsInAYear = 12)
        {
            // Auth token must be valid, get correct token here, placeholder is asd.
            if (!AuthToken.Equals("asd"))
            {
                return Unauthorized("Login token is invalid");
            }
            // Loan, loan duration, interest rate or payments in a year cannot be below 0
            else if (LoanAmmount <= 0 || LoanDurationInMonths <= 0 || InterestRate <= 0 || PaymentsInAYear <= 0)
            {
                return BadRequest("Loan ammount, loan duration, interest rate or payments in a year cannot be below 0");
            }
            else
            {
                double AdminFees =LoanCalculator.CalculateAdminFees(LoanAmmount);
                double MonthlyPayment = LoanCalculator.CalculateMonthlyPayment(LoanAmmount, InterestRate, LoanDurationInMonths, PaymentsInAYear);
                double TotalInterest = LoanCalculator.CalculateTotalInterest(LoanAmmount, InterestRate, LoanDurationInMonths, PaymentsInAYear);
                double APR = LoanCalculator.CalculateAPR(LoanAmmount, InterestRate, LoanDurationInMonths, PaymentsInAYear);

                LoanData CurrentLoan = new LoanData(LoanAmmount, LoanDurationInMonths, AdminFees, MonthlyPayment, TotalInterest, APR);

                return Ok(CurrentLoan);
            }

        }
    }
}
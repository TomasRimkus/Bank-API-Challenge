using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank_API_Challenge.Models
{
    public class RequestData
    {
        public string AuthToken;
        public double LoanAmmount;
        public int LoanDurationInMonths;
        public double InterestRate;
        public int PaymentsInAYear;
    }
}

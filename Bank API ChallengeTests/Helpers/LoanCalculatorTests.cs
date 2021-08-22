using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank_API.Helpers.Tests
{
    [TestClass()]
    public class LoanCalculatorTests
    {
        [TestMethod()]
        public void Calculates_Known_Admin_Fee_Given_Certain_Imput()
        {
            // Arrange

            double Expected = 5000;
            // Act

            double Result = LoanCalculator.CalculateAdminFees(500000);
            // Assert

            Assert.AreEqual(Expected, Result);
        }

        [TestMethod()]
        public void Calculates_Known_Monthly_Payment_Given_Certain_Imput()
        {
            // Arrange

            double Expected = 5303.28;
            // Act

            double Result = LoanCalculator.CalculateMonthlyPayment(500000, 5, 120, 12);
            // Assert

            Assert.AreEqual(Expected, Result);
        }

        [TestMethod()]
        public void Calculates_Known_Total_Interest_Given_Certain_Imput()
        {
            // Arrange

            double Expected = 136393.6;
            // Act

            double Result = LoanCalculator.CalculateTotalInterest(500000, 5, 120, 12);
            // Assert

            Assert.AreEqual(Expected, Result);
        }

        [TestMethod()]
        public void Calculates_Known_APR_Given_Certain_Imput()
        {
            // Arrange

            double Expected = 2.83;
            // Act

            double Result = LoanCalculator.CalculateAPR(500000, 5, 120, 12);
            // Assert

            Assert.AreEqual(Expected, Result);
        }
    }
}
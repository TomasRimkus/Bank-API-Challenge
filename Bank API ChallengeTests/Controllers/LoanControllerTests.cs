using Bank_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank_API_Challenge.Controllers.Tests
{
    [TestClass()]
    public class LoanControllerTests
    {
        [TestMethod()]
        public void GetLoanDataTest()
        {
            // Arrange
            LoanController TestInstance = new LoanController();
            LoanData CorrectData = new LoanData(500000, 120, 5000, 5303.28, 136393.6, 2.83);
            // Act
            IActionResult result = TestInstance.GetLoanData("asd", 500000, 120, 5, 12);
            // Assert
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var LoanData = okObjectResult.Value as LoanData;
            Assert.IsNotNull(LoanData);
            Assert.AreEqual(CorrectData.MoneyLoaned, LoanData.MoneyLoaned);
            Assert.AreEqual(CorrectData.LoanLengthInMonths, LoanData.LoanLengthInMonths);
            Assert.AreEqual(CorrectData.TotalAdminFees, LoanData.TotalAdminFees);
            Assert.AreEqual(CorrectData.SingleMonthlyPayment, LoanData.SingleMonthlyPayment);
            Assert.AreEqual(CorrectData.FullInterest, LoanData.FullInterest);
            Assert.AreEqual(CorrectData.APRPercentage, LoanData.APRPercentage);

        }
    }
}
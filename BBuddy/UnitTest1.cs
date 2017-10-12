using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace BBuddy
{
    [TestFixture]
    public class UnitTest1
    {
        private Accounting accounting;

        private IBudgetRepo stubRepo = Substitute.For<IBudgetRepo>();

        [SetUp]
        public void Setup()
        {
            accounting = new Accounting(stubRepo);
        }

        [Test]
        public void no_budget()
        {
            stubRepo.GetAll().Returns(new List<Budget>());
            TotalAmountShouldBe(0, "20170701", "20170701");
        }

        [Test]
        public void one_day_budget()
        {
            stubRepo.GetAll().Returns(new List<Budget>()
            {
                new Budget{Month="201707",Amount=31}
            });

            TotalAmountShouldBe(1, "20170701", "20170701");
        }

        private void TotalAmountShouldBe(int expected, string start, string end)
        {
            decimal totalAmount = accounting.TotalAmount(start, end);
            Assert.AreEqual(expected, totalAmount);
        }
    }

    public interface IBudgetRepo
    {
        List<Budget> GetAll();
    }

    public class Budget
    {
        public int Amount { get; set; }
        public string Month { get; set; }
    }
}
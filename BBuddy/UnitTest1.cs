using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
            GivenBudgets();
            TotalAmountShouldBe(0, "20170701", "20170701");
        }

        [Test]
        public void one_day_budget()
        {
            GivenBudgets(new Budget { Month = "201707", Amount = 31 });

            TotalAmountShouldBe(1, "20170701", "20170701");
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            stubRepo.GetAll().Returns(budgets.ToList());
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
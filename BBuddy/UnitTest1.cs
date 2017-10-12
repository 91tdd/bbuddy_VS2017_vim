using NSubstitute;
using NUnit.Framework;
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

        [Test]
        public void without_overlapping_before_budget_month()
        {
            GivenBudgets(new Budget { Month = "201707", Amount = 31 });
            TotalAmountShouldBe(0, "20170630", "20170630");
        }

        [Test]
        public void without_overlapping_after_budget_month()
        {
            GivenBudgets(new Budget { Month = "201707", Amount = 31 });
            TotalAmountShouldBe(0, "20170801", "20170801");
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
}
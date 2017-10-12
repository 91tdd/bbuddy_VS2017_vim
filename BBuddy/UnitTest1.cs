using NUnit.Framework;

namespace BBuddy
{
    [TestFixture]
    public class UnitTest1
    {
        private Accounting accounting;

        [SetUp]
        public void Setup()
        {
            accounting = new Accounting();
        }

        [Test]
        public void no_budget()
        {
            TotalAmountShouldBe(0, "20170701", "20170701");
        }

        private void TotalAmountShouldBe(int expected, string start, string end)
        {
            decimal totalAmount = accounting.TotalAmount(start, end);
            Assert.AreEqual(expected, totalAmount);
        }
    }
}
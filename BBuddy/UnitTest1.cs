using NUnit.Framework;

namespace BBuddy
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void no_budget()
        {
            Accounting accounting = new Accounting();
            decimal totalAmount = accounting.TotalAmount("20170701", "20170701");
            Assert.AreEqual(0, totalAmount);
        }
    }
}
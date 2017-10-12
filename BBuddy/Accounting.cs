using System.Linq;

namespace BBuddy
{
    public class Accounting
    {
        private readonly IBudgetRepo _budgetRepo;

        public Accounting(IBudgetRepo budgetRepo)
        {
            _budgetRepo = budgetRepo;
        }

        public decimal TotalAmount(string start, string end)
        {
            var budget = _budgetRepo.GetAll().FirstOrDefault();
            if (budget != null)
            {
                var period = new Period(start, end);
                if (period.WithoutOverlapping(budget))
                {
                    return 0;
                }

                var days = period.GetDays();
                return days;
            }

            return 0;
        }
    }
}
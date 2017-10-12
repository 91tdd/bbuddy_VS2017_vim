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
                var overlappingDays = new Period(start, end).GetOverlappingDays(budget);
                return overlappingDays;
            }

            return 0;
        }
    }
}
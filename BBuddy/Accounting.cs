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
            return _budgetRepo.GetAll()
                .Sum(b => b.GetOverlappingAmount(new Period(start, end)));
        }
    }
}
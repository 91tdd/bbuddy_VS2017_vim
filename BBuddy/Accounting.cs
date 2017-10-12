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
            var totalAmount = 0;
            foreach (var budget in _budgetRepo.GetAll())
            {
                totalAmount += budget.GetOverlappingAmount(new Period(start, end));
            }

            return totalAmount;
        }
    }
}
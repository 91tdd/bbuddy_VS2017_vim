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
                var overlappingDays = new Period(start, end).GetOverlappingDays(budget);
                var dailyAmount = budget.DailyAmount();

                totalAmount += overlappingDays * dailyAmount;
            }

            return totalAmount;
        }
    }
}
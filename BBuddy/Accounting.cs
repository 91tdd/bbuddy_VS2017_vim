using System;
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
                var startDate = DateTime.ParseExact(start, "yyyyMMdd", null);
                var endDate = DateTime.ParseExact(end, "yyyyMMdd", null);
                if (endDate < budget.FirstDay)
                {
                    return 0;
                }

                var days = (endDate.AddDays(1) - startDate).Days;
                return days;
            }

            return 0;
        }
    }
}
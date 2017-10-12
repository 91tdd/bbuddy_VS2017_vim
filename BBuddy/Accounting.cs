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
                var period = new Period(start, end);
                if (period.EndDate < budget.FirstDay)
                {
                    return 0;
                }

                var days = (period.EndDate.AddDays(1) - period.StartDate).Days;
                return days;
            }

            return 0;
        }
    }

    public class Period
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        private DateTime GetDateFromString(string date)
        {
            return DateTime.ParseExact(date, "yyyyMMdd", null);
        }

        public Period(string start, string end)
        {
            StartDate = GetDateFromString(start);
            EndDate = GetDateFromString(end);
        }
    }
}
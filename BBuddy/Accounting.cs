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

        public int GetDays()
        {
            return (this.EndDate.AddDays(1) - this.StartDate).Days;
        }

        public bool WithoutOverlapping(Budget budget)
        {
            if (StartDate > budget.LastDay)
            {
                return true;
            }
            return this.EndDate < budget.FirstDay;
        }
    }
}
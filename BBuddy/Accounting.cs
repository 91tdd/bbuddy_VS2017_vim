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
                var period = new Period(GetDateFromString(start), GetDateFromString(end));
                if (period.EndDate < budget.FirstDay)
                {
                    return 0;
                }

                var days = (GetDateFromString(end).AddDays(1) - GetDateFromString(start)).Days;
                return days;
            }

            return 0;
        }

        private DateTime GetDateFromString(string date)
        {
            return DateTime.ParseExact(date, "yyyyMMdd", null);
        }
    }

    public class Period
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
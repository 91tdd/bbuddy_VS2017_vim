using System;

namespace BBuddy
{
    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private DateTime GetDateFromString(string date)
        {
            return DateTime.ParseExact(date, "yyyyMMdd", null);
        }

        public Period(string start, string end)
        {
            StartDate = GetDateFromString(start);
            EndDate = GetDateFromString(end);
        }

        public int GetOverlappingDays(Budget budget)
        {
            if (WithoutOverlapping(budget))
            {
                return 0;
            }

            AdjustEndDate(budget);
            AdjustStartDate(budget);

            return (EndDate.AddDays(1) - StartDate).Days;
        }

        private void AdjustEndDate(Budget budget)
        {
            EndDate = EndDate > budget.LastDay ? budget.LastDay : EndDate;
        }

        public bool WithoutOverlapping(Budget budget)
        {
            return StartDate > budget.LastDay || EndDate < budget.FirstDay;
        }

        private void AdjustStartDate(Budget budget)
        {
            StartDate = StartDate < budget.FirstDay ? budget.FirstDay : StartDate;
        }
    }
}
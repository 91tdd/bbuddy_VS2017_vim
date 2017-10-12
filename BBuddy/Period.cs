using System;

namespace BBuddy
{
    public class Period
    {
        public DateTime StartDate { get; set; }
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

        public int GetOverlappingDays(Budget budget)
        {
            if (WithoutOverlapping(budget))
            {
                return 0;
            }

            AdjustStartDate(budget);
            return (this.EndDate.AddDays(1) - this.StartDate).Days;
        }

        public bool WithoutOverlapping(Budget budget)
        {
            return StartDate > budget.LastDay || EndDate < budget.FirstDay;
        }

        private void AdjustStartDate(Budget budget)
        {
            if (this.StartDate < budget.FirstDay)
            {
                this.StartDate = budget.FirstDay;
            }
        }
    }
}
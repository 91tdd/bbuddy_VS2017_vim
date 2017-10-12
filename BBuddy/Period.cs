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
            if (budget == null)
            {
                return 0;
            }

            if (WithoutOverlapping(budget))
            {
                return 0;
            }

            AdjustEndDate(budget); 
            AdjustStartDate(budget);

            return (this.EndDate.AddDays(1) - this.StartDate).Days;
        }

        private void AdjustEndDate(Budget budget)
        {
            if (EndDate > budget.LastDay)
            {
                EndDate = budget.LastDay;
            }
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
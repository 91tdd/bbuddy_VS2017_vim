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

        public int GetDays()
        {
            return (this.EndDate.AddDays(1) - this.StartDate).Days;
        }

        public bool WithoutOverlapping(Budget budget)
        {
            return StartDate > budget.LastDay || EndDate < budget.FirstDay;
        }
    }
}
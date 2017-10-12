using System;

namespace BBuddy
{
    public class Period
    {
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }

        private DateTime GetDateFromString(string date)
        {
            return DateTime.ParseExact(date, "yyyyMMdd", null);
        }

        public Period(string start, string end)
        {
            StartDate = GetDateFromString(start);
            EndDate = GetDateFromString(end);
        }

        public Period(DateTime firstDay, DateTime lastDay)
        {
            StartDate = firstDay;
            EndDate = lastDay;
        }

        public int GetOverlappingDays(Period period)
        {
            if (StartDate > EndDate)
            {
                return 0;
            }

            AdjustEndDate(period);
            AdjustStartDate(period);

            return (EndDate.AddDays(1) - StartDate).Days;
        }

        private void AdjustEndDate(Period period)
        {
            EndDate = EndDate > period.EndDate ? period.EndDate : EndDate;
        }

        private void AdjustStartDate(Period period)
        {
            StartDate = StartDate < period.StartDate ? period.StartDate : StartDate;
        }
    }
}
using System;

namespace BBuddy
{
    public class Budget
    {
        public int Amount { get; set; }
        public string Month { get; set; }

        private DateTime FirstDay
        {
            get
            {
                return DateTime.ParseExact(Month + "01", "yyyyMMdd", null);
            }
        }

        private DateTime LastDay
        {
            get
            {
                var days = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
                return DateTime.ParseExact(Month + days, "yyyyMMdd", null);
            }
        }

        private int DailyAmount()
        {
            return Amount / LastDay.Day;
        }

        public int GetOverlappingAmount(Period period)
        {
            var periodOfBudget = new Period(FirstDay, LastDay);
            return period.GetOverlappingDays(periodOfBudget) * DailyAmount();
        }
    }
}
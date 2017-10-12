using System;

namespace BBuddy
{
    public class Budget
    {
        public int Amount { get; set; }
        public string Month { get; set; }

        public DateTime FirstDay
        {
            get
            {
                return DateTime.ParseExact(Month + "01", "yyyyMMdd", null);
            }
        }

        public DateTime LastDay
        {
            get
            {
                var days = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
                return DateTime.ParseExact(Month + days, "yyyyMMdd", null);
            }
        }

        public int DailyAmount()
        {
            var daysOfBudgetMonth = this.LastDay.Day;
            var dailyAmount = this.Amount / daysOfBudgetMonth;
            return dailyAmount;
        }
    }
}
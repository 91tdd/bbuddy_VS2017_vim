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
    }
}
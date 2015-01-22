using System;
using System.Globalization;

namespace FitnessLibrary.Helper
{
    public static class WeekOfYear
    {
        public static int GetWeekOfYear(DateTime today)
        {
            var dfi = DateTimeFormatInfo.CurrentInfo;
            var cal = dfi.Calendar;
            var week = cal.GetWeekOfYear(today, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return week;
        }

        public static string GetWeekOfYearAsString(DateTime today)
        {
            return GetWeekOfYear(today).ToString().PadLeft(2, '0');
        }
    }
}

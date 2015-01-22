using System;
using System.Collections.Generic;
using System.Globalization;

namespace FitnessClientLibrary.Helper
{
    public static class WeeksHelper
    {
        public static IEnumerable<int> GetWeeks(DateTime dateTime)
        {
            var dfi = DateTimeFormatInfo.CurrentInfo;
            var countWeeks = dfi.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            var weeks = new List<int>();
            for(var i = 1; i <= countWeeks; i++)
                weeks.Add(i);
            return weeks;
        }

        public static int GetWeekOfYear(DateTime date)
        {
            var dfi = DateTimeFormatInfo.CurrentInfo;
            var cal = dfi.Calendar;
            var week = cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return week;
        }

        public static string GetWeekOfYearAsString(DateTime today)
        {
            return GetWeekOfYear(today).ToString().PadLeft(2, '0');
        }

        public static string[] WeekDays()
        {
            return Enum.GetNames(typeof(DayOfWeek));
        }
    }
}

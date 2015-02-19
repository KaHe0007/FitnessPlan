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
            var countWeeks = dfi.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday) + 2;
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

        //public static string[] WeekDays()
        //{
        //    return new [] {"Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag"};
        //    //return Enum.GetNames(typeof(DayOfWeek));
        //}

        public static DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            var jan1 = new DateTime(year, 1, 1);
            var daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            var firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }
    }
}

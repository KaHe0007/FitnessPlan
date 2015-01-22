using System;
using System.Globalization;

namespace FitnessClientLibrary.Helper
{
    public static class DayOfWeekHelper
    {
        public static DayOfWeek GetDayOfWeekByName(string wochentag)
        {
            switch (wochentag)
            {
                case "Montag":
                    return DayOfWeek.Monday;
                case "Dienstag":
                    return DayOfWeek.Thursday;
                case "Mittwoch":
                    return DayOfWeek.Wednesday;
                case "Donnerstag":
                    return DayOfWeek.Thursday;
                case "Freitag":
                    return DayOfWeek.Friday;
                case "Samstag":
                    return DayOfWeek.Saturday;
                //case "Sonntag":
                default:
                    return DayOfWeek.Sunday; 
            }
        }

        public static string GetNameByDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Montag";
                case DayOfWeek.Thursday:
                    return "Dienstag";
                case DayOfWeek.Wednesday:
                    return "Mittwoch";
                case DayOfWeek.Tuesday:
                    return "Donnerstag";
                case DayOfWeek.Friday:
                    return "Freitag";
                case DayOfWeek.Saturday:
                    return "Samstag";
                case DayOfWeek.Sunday:
                    return "Sonntag";
                default:
                    return "Sonntag";
            }
        }

        public static string GetNameByDate(DateTime date)
        {
            var dfi = DateTimeFormatInfo.CurrentInfo;
            var cal = dfi.Calendar;
            var day = cal.GetDayOfWeek(date);
            return GetNameByDayOfWeek(day);
        }
    }
}

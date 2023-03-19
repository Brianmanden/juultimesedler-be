using juultimesedler_be.DTOs;
using juultimesedler_be.Interfaces;
using System.Globalization;

namespace juultimesedler_be.Services
{
    public class TimeService : ITimeService
    {
        private int WeekNumber()
        {
            CultureInfo cultureInfo = new CultureInfo("da-DK");
            Calendar cal = cultureInfo.Calendar;
            CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;

            int weekNumber = cal.GetWeekOfYear(DateTime.Now, calendarWeekRule, DayOfWeek.Monday);
            return weekNumber;
        }

        private int[] WeekDates(int weekNumber)
        {
            int[] dates = new int[] {
                ISOWeek.ToDateTime(DateTime.Now.Year, weekNumber, DayOfWeek.Monday).Day,
                ISOWeek.ToDateTime(DateTime.Now.Year, weekNumber, DayOfWeek.Monday).AddDays(1).Day,
                ISOWeek.ToDateTime(DateTime.Now.Year, weekNumber, DayOfWeek.Monday).AddDays(2).Day,
                ISOWeek.ToDateTime(DateTime.Now.Year, weekNumber, DayOfWeek.Monday).AddDays(3).Day,
                ISOWeek.ToDateTime(DateTime.Now.Year, weekNumber, DayOfWeek.Monday).AddDays(4).Day,
                ISOWeek.ToDateTime(DateTime.Now.Year, weekNumber, DayOfWeek.Monday).AddDays(5).Day,
                ISOWeek.ToDateTime(DateTime.Now.Year, weekNumber, DayOfWeek.Monday).AddDays(6).Day,
            };
            return dates;
        }

        public string FormattedCurrentWeek()
        {
            string formattedWeekString =
                ISOWeek.GetWeekOfYear(DateTime.Now) < 10
                    ? "0" + ISOWeek.GetWeekOfYear(DateTime.Now).ToString()
                    : ISOWeek.GetWeekOfYear(DateTime.Now).ToString();

            return formattedWeekString;
        }

        public string FormattedCurrentYearAndWeek(DateTime? date = null)
        {
            date = date ?? DateTime.Now;

            string yearNumber = ISOWeek.GetYear((DateTime)date).ToString();
            string weekNumber = ISOWeek.GetWeekOfYear((DateTime)date) < 10
                ? "0" +  ISOWeek.GetWeekOfYear((DateTime)date).ToString()
                : ISOWeek.GetWeekOfYear((DateTime)date).ToString();

            return $"{yearNumber}_{weekNumber}";
        }

        public GetTimesheetWeekDTO GetCurrentTimesheetWeek()
        {
            int weekNumber = WeekNumber();
            GetTimesheetWeekDTO currentTimesheetWeek = new();
            currentTimesheetWeek.WeekNumber = weekNumber;
            currentTimesheetWeek.WeekDays = new string[]{
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            };
            currentTimesheetWeek.WeekDates = WeekDates(weekNumber);

            return currentTimesheetWeek;
        }

    }
}
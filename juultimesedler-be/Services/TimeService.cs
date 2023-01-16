using juultimesedler_be.Interfaces;
using System.Globalization;

namespace juultimesedler_be.Services
{
    public class TimeService : ITimeService
    {
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
    }
}

namespace juultimesedler_be.Interfaces;

public interface ITimeService
{
    /// <summary>
    /// Get the current weeknumber
    /// </summary>
    /// <returns>int</returns>
    public int GetCurrentWeekNumber();
    /// <summary>
    /// Get the week dates of the current week
    /// </summary>
    /// <param name="weekNumber"></param>
    /// <returns>Int array of dates. Eks.:[31, 1, 2, 3, 4, 5, 6]</returns>
    public int[] GetCurrentWeekDates(int weekNumber);
    public string FormattedCurrentWeek();
    public string FormattedCurrentYearAndWeek(DateTime? date);
}

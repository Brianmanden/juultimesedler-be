namespace juultimesedler_be.DTOs;

public class GetTimesheetWeekDTO
{
    public int WeekNumber { get; set; }
    public string[] WeekDays { get; set; }
    public int[] WeekDates { get; set; }
}

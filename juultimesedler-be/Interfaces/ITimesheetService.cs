using juultimesedler_be.DTOs;

namespace juultimesedler_be.Interfaces
{
    public interface ITimesheetService
    {
        public GetTimesheetWeekDTO GetTimesheetForCurrentWeek(int workerId);

        public GetTimesheetWeekDTO GetTimesheetByWeekNumber(int weekNumber, int workerId);
    }
}

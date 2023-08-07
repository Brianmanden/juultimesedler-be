using juultimesedler_be.DTOs;
using juultimesedler_be.Interfaces;

namespace juultimesedler_be.Services;

public class TimesheetService : ITimesheetService
{
    private ITimeService _timeService;
    public TimesheetService(ITimeService timeService)
    {
        _timeService = timeService;
    }

    public GetTimesheetWeekDTO GetTimesheetByWeekNumber(int weekNumber, int workerId)
    {
        int internalWeekNumber = weekNumber;
        List<GetTimesheetWeekDTO> demoTimesheets = new List<GetTimesheetWeekDTO>();

        GetTimesheetWeekDTO demoTimesheet1 = GetTimesheetForCurrentWeek(workerId);
        demoTimesheet1.WeekNumber = internalWeekNumber;
        demoTimesheets.Add(demoTimesheet1);

        GetTimesheetWeekDTO demoTimesheet2 = GetTimesheetForCurrentWeek(workerId);
        demoTimesheet2.WeekNumber = internalWeekNumber - 1;
        demoTimesheets.Add(demoTimesheet2);

        GetTimesheetWeekDTO demoTimesheet3 = GetTimesheetForCurrentWeek(workerId);
        demoTimesheet3.WeekNumber = internalWeekNumber - 2;
        demoTimesheets.Add(demoTimesheet3);

        var result = demoTimesheets.Where(sheet => sheet.WeekNumber == weekNumber).SingleOrDefault();

        return result;
    }

    public GetTimesheetWeekDTO GetTimesheetForCurrentWeek(int workerId)
    {
        //TODO: Should fetch timesheet from persistance layer (Umb DB)
        int weekNumber = _timeService.GetCurrentWeekNumber();
        GetTimesheetWeekDTO currentTimesheetWeek = new();
        currentTimesheetWeek.WeekNumber = weekNumber;
        currentTimesheetWeek.WeekDays = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        currentTimesheetWeek.WeekDates = _timeService.GetCurrentWeekDates(weekNumber);

        return currentTimesheetWeek;
    }
}
using juultimesedler_be.Models;

namespace juultimesedler_be.DTOs;

public class PutTimesheetDTO
{
    public int WorkerId { get; set; }
    public int WeekNumber { get; set; }
    public List<WorkDay>? Workdays { get; set; }
}
using juultimesedler_be.Models;
using System.Collections.Generic;

namespace juultimesedler_be.DTOs
{
    public class PutTimeSheetDTO
    {
        public int WorkerId { get; set; }
        public int WeekNumber { get; set; }
        public List<WorkDay>? Workdays { get; set; }
    }
}

namespace juultimesedler_be.DTOs
{
    public class TimeSheetDTO
    {
        public string SelectedProjectAdvanced{ get; set; }
        public string[] SelectedTasks { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string JobDesc { get; set; }
    }
}

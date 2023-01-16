namespace juultimesedler_be.Interfaces
{
    public interface ITimeService
    {
        public string FormattedCurrentWeek();

        public string FormattedCurrentYearAndWeek(DateTime? date);
    }
}

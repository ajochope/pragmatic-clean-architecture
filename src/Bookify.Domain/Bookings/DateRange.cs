namespace Bookify.Domain.Bookings
{
    public record DateRange
    {
        private DateRange()
        {
        }
        public DateOnly Start { get; private set; }
        public DateOnly End { get; private set; }
        public int LengthInDays => End.DayNumber - Start.DayNumber;
        public static DateRange Create(DateOnly start, DateOnly end)
        {
            if (start > end)
            {
                throw new ApplicationException("Start date must be before end date");
            }
            var dateRange = new DateRange { Start = start, End = end };
            return dateRange;
        }
    }
}
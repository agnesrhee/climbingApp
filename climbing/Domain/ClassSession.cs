namespace climbing.Domain
{
    public class ClassSession
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? InstructorName { get; set; }
        public bool IsCancelled { get; set; } = false;

        // Navigation
        public Class Class { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

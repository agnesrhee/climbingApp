namespace climbing.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClassSessionId { get; set; }
        public DateTime BookedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Confirmed"; // Confirmed, Cancelled, Waitlist

        // Navigation
        public User User { get; set; } = null!;
        public ClassSession ClassSession { get; set; } = null!;
    }
}

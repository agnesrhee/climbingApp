namespace climbing.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public DateTime BookedAt { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

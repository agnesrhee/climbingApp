namespace climbing.Domain
{
    public class Membership
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MembershipTierId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = "Active"; // Active, Cancelled, Expired

        // Navigation
        public User User { get; set; } = null!;
        public MembershipTier MembershipTier { get; set; } = null!;
    }
}
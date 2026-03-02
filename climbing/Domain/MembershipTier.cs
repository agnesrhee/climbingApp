namespace climbing.Domain
{
    public class MembershipTier
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string BillingFrequency { get; set; } = string.Empty; // e.g., "Monthly", "Yearly"
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    }
}

namespace EmergencyService.Domain.Entities
{
    public class Emergency
    {
        public int Id { get; set; }
        public string? VictimId { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string Status { get; set; } = "Pending";
        public string? ResponderId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

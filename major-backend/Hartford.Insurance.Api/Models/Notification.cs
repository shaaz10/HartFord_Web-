namespace Hartford.Insurance.Api.Models
{
    public class Notification : BaseEntity
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public string Message { get; set; } = string.Empty;
        public bool IsRead { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}

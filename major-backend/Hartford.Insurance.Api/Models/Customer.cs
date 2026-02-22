namespace Hartford.Insurance.Api.Models
{
    public class Customer : BaseEntity
    {
        public int? UserId { get; set; }
        public User? User { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}

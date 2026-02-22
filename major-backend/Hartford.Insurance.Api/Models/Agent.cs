namespace Hartford.Insurance.Api.Models
{
    public class Agent : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
    }
}

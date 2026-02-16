using System.ComponentModel.DataAnnotations;

namespace CustomerOrderAPIDemo.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string? Phone { get; set; }

        // Navigation Property (1 Customer → Many Orders)
        public List<Order>? Orders { get; set; }
    }
}

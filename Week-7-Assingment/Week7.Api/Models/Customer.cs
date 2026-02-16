using System.ComponentModel.DataAnnotations;

namespace Week7.Api.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // One Customer → Many Orders
        public ICollection<Order>? Orders { get; set; }
    }
}

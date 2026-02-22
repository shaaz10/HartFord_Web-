using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CrudCustomers.Models
{
    public class Customer
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public int TotalPurchases { get; set; }

        public bool IsActive { get; set; }

        public List<Feedback> Feedbacks { get; set; } = new();
    }
}



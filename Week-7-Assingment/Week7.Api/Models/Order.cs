using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week7.Api.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Range(1, 1000000)]
        public decimal TotalAmount { get; set; }

   
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }
    }
}

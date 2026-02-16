namespace Week7.Api.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace VideoShopRentalAPI.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customers { get; set; }
        public int MovieId { get; set; }
        public Movie? Movies { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int Quantity { get; set; }

        public bool IsPaid { get; set; }

        public ICollection<RentalDetail> RentalDetails { get; set; } = new List<RentalDetail>();
    }
}

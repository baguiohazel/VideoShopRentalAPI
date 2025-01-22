using System.Text.Json.Serialization;

namespace VideoShopRentalAPI.Models
{
    public class RentalHeader
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateOnly RentalDate { get; set; }
        public DateOnly? ReturnDate { get; set; }

        public Customer Customer { get; set; }
        public ICollection<RentalDetail> RentalDetails { get; set; }
    }
}

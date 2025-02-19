namespace VideoShopRentalAPI.Models
{
    public class RentalDetail
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customers { get; set; }
        public int RentalId { get; set; }
        public Rental? Rentals { get; set; }
        public int MovieId { get; set; }
        public Movie? Movies { get; set; }
        public string Status { get; set; } = "Rented";
    }
}

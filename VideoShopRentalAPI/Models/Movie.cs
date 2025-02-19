namespace VideoShopRentalAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateOnly DateRelease { get; set; }
        public string Director { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; } = true;


        public ICollection<Rental>? Rentals { get; set; }
        public ICollection<RentalDetail>? RentalDetails { get; set; }

    }
}

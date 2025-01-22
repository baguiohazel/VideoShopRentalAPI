namespace VideoShopRentalAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }

        public ICollection<RentalDetail> RentalDetails { get; set; }

    }
}

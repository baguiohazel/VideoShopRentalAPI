namespace VideoShopRentalAPI.Models
{
    public class Customer
    {
        public Customer() 
        { 
            RentalHeaders = new List<RentalHeader>();
        }

        public Customer(string name, string email, List<RentalHeader> rental =null)
        {
            Name = name;    
            Email = email;
            RentalHeaders = rental?? new List<RentalHeader>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<RentalHeader> RentalHeaders { get; set; }

    }
}

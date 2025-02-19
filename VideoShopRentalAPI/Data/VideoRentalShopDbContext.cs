using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using VideoShopRentalAPI.Models;

namespace VideoShopRentalAPI.Data
{
    public class VideoRentalShopDbContext : DbContext
    {
        
        public VideoRentalShopDbContext(DbContextOptions<VideoRentalShopDbContext> options) : base(options) { }

        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<RentalDetail> RentalDetails { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // One Customer → Many Rentals
            builder.Entity<Rental>()
                .HasOne(r => r.Customers)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // One Movie → Many RentalDetails (not Rentals directly)
            builder.Entity<RentalDetail>()
                .HasOne(rd => rd.Movies)
                .WithMany(m => m.RentalDetails)
                .HasForeignKey(rd => rd.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            // One Rental → Many RentalDetails
            builder.Entity<RentalDetail>()
                .HasOne(rd => rd.Rentals)
                .WithMany(r => r.RentalDetails)
                .HasForeignKey(rd => rd.RentalId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<RentalDetail>()
                .Property(rd => rd.Status)
                .HasDefaultValue("Rented");
        }
    }

}


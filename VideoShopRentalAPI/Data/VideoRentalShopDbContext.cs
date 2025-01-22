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
        public DbSet<RentalHeader> RentalHeaders { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            // One Customer -> Many RentalHeaders
            modelBuilder.Entity<RentalHeader>()
                .HasOne(rh => rh.Customer)
                .WithMany(c => c.RentalHeaders)
                .HasForeignKey(rh => rh.CustomerId);

            // One RentalHeader -> Many RentalDetails
            modelBuilder.Entity<RentalDetail>()
                .HasOne(rd => rd.RentalHeaders)
                .WithMany(rh => rh.RentalDetails)
                .HasForeignKey(rd => rd.RentalHeadersId);

            // RentalDetail links to Movie
            modelBuilder.Entity<RentalDetail>()
                        .HasOne(rd => rd.Movies)
                        .WithMany(k => k.RentalDetails)
                        .HasForeignKey(rd => rd.MovieId);
        }
    }

}


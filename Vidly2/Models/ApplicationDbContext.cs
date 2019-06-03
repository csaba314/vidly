using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // add a DbSet for a model class so EF can add it to a migration
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
//using System.Data.Entity;
//namespace Vidly.Models
//{
//    public class MyDBContext : DbContext
//    {
//        public MyDBContext()
//        {

//        }
//        public DbSet<Customer> Customers { get; set; } // My domain models
//        public DbSet<Movie> Movies { get; set; }// My domain models
//        public DbSet<MembershipType> MembershipType { get; set; }
//        public DbSet<MovieGenre> MovieGenre { get; set; }
//    }
//}

using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    public class MyDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipType { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public MyDBContext()
            : base("Vidly.Models.MyDbContext", throwIfV1Schema: false)
        {
        }

        public static MyDBContext Create()
        {
            return new MyDBContext();
        }
    }
}
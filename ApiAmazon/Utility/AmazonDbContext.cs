using ApiAmazon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiAmazon.Utility
{
    public class AmazonDbContext:IdentityDbContext<ApplicationUser>
    {
        public AmazonDbContext(DbContextOptions<AmazonDbContext> Options):base(Options) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Books> books { get; set;}

        public DbSet<Grocery> Grocery { get; set; }

        public DbSet<HomeDecore> homeDecores { get; set; }

        public DbSet<Kitchen> Kitchens { get; set; }

        public DbSet<Homefurnishing> Furnishing { get; set; }

        public DbSet<Clothing> Clothes { get; set; }

        public DbSet<Electronics> Electronics { get; set; }

        public DbSet<Cosmetics> cosmetics { get; set; }

        public DbSet<Jwellery> Jwellery { get; set; }
    }
}

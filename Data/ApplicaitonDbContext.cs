using Microsoft.EntityFrameworkCore;
using HeroesAPI.Models;

namespace HeroesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<HeroModel> heroes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroModel>().HasData(
                new HeroModel
                {
                    id = 1,
                    name = "Test",
                    Description = "Test",
                    rating = 5.5
                }) ;
        }
    }
}

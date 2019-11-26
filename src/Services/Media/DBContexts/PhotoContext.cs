using ApepMediaMicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace ApepMediaMicroService.DBContexts
{
    public class PhotoContext : DbContext
    {

        public PhotoContext(DbContextOptions<PhotoContext> options) : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasData(
                new Group
                {
                    Id = 1,
                    Name = "BJJ",
                    Description = "BJJ related stuff"
                },
                new Group
                {
                    Id = 2,
                    Name = "Holiday",
                    Description = "Holiday related media"
                },
                new Group
                {
                    Id = 3,
                    Name = "Random",
                    Description = "Random bs media"
                }
                );
        }

    }
}

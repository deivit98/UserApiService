using Microsoft.EntityFrameworkCore;
using UserData.DataAccess.Models;

namespace UserData.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed user data during creation of Database
            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.NewGuid(), UserName = "ivivan", DisplayName = "Ivan Ivanov", Email = "i.ivanov@example.com" },
                new User { Id = Guid.NewGuid(), UserName = "igeor", DisplayName = "Ivelina Georgieva", Email = "i.georgieva@example.com" },
                new User { Id = Guid.NewGuid(), UserName = "kivanova", DisplayName = "Katerina Ivanova", Email = "k.ivanova@example.com" },
                new User { Id = Guid.NewGuid(), UserName = "igerd", DisplayName = "Ivaila Gerdjikova", Email = "i.gerdjikova@example.com" },
                new User { Id = Guid.NewGuid(), UserName = "kakost", DisplayName = "Kaloqn Kostadinov", Email = "k.kostadinov@example.com" },
                new User { Id = Guid.NewGuid(), UserName = "gdimit", DisplayName = "Georgi Dimitrov", Email = "g.dimitrov@example.com" }
            );
        }
    }
}

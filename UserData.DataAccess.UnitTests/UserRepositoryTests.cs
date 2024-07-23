using Microsoft.EntityFrameworkCore;
using UserData.DataAccess.Models;
using UserData.DataAccess.Repositories;

namespace UserData.DataAccess.UnitTests
{
    public class UserRepositoryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _sut;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();

            AddUsersToDatabase(_context);

            _sut = new UserRepository(_context);
        }

        private void AddUsersToDatabase(ApplicationDbContext context)
        {
            _context.Users.AddRange(
                new User { Id = Guid.NewGuid(), UserName = "ivivan", DisplayName = "Ivan Ivanov", Email = "i.ivanov@example.com" },
                new User { Id = Guid.NewGuid(), UserName = "igeor", DisplayName = "Ivelina Georgieva", Email = "i.georgieva@example.com" },
                new User { Id = Guid.NewGuid(), UserName = "kivanova", DisplayName = "Katerina Ivanova", Email = "k.ivanova@example.com" },
                new User { Id = Guid.NewGuid(), UserName = "igerd", DisplayName = "Ivaila Gerdjikova", Email = "i.gerdjikova@example.com" },
                new User { Id = Guid.NewGuid(), UserName = "kakost", DisplayName = "Kaloqn Kostadinov", Email = "k.kostadinov@example.com" },
                new User { Id = Guid.NewGuid(), UserName = "gdimit", DisplayName = "Georgi Dimitrov", Email = "g.dimitrov@example.com" });
        }
    }
}

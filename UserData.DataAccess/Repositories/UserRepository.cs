using Microsoft.EntityFrameworkCore;
using UserData.DataAccess.Models;

namespace UserData.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;   
        }

        public async Task<IEnumerable<User>> GetUsers(string input)
        {
            return await _context.Users
                .AsQueryable()
                .AsNoTracking()
                .Where(x => 
                EF.Functions.ILike(x.DisplayName ,$"%{input}%") ||
                EF.Functions.ILike(x.Email, $"%{input}%") ||
                EF.Functions.ILike(x.Email, $"%{input}%"))
                .ToListAsync();
        }
    }
}

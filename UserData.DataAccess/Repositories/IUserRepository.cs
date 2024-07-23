using UserData.DataAccess.Models;

namespace UserData.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(string input);
    }
}

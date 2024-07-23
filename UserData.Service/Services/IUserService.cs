using UserData.Service.Models;

namespace UserData.Service.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsers(string input);
    }
}

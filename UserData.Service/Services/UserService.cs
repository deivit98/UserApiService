using UserData.DataAccess.Repositories;
using UserData.Service.Models;
using UserData.Service.Services;

namespace UserApplication.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserModel>> GetUsers(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<UserModel>();
            }

            var users = await _repository.GetUsers(input);

            if (!users.Any())
            {
                return new List<UserModel>();
            }

            var result = new List<UserModel>();

            foreach (var user in users)
            {
                result.Add(new UserModel { DisplayName =  user.DisplayName, UserName = user.UserName, Email = user.Email });
            }

            return result;
        }
    }
}

using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Services.UserServices
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByMail(string email)
        {
            User? user = await _userRepository.GetAsync(x => x.Email == email);
            return user;
        }
    }
}

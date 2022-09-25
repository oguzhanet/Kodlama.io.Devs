using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.UserServices
{
    public interface IUserService
    {
        public Task<User> GetByMail(string email);
    }
}

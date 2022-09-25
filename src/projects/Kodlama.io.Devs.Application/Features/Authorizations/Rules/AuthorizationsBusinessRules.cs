using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Rules
{
    public class AuthorizationsBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthorizationsBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserEmailShouldBeNotExists(string email)
        {
            User user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Email Adresi Kullanımda.");
        }

        public async Task UserPasswordShouldBeMatch(int id, string password)
        {
            User user = await _userRepository.GetAsync(u => u.Id == id);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException("Şifre Veya Email Hatalı");
        }

        public void UserShouldBeExists(User user)
        {
            if (user == null) throw new BusinessException("Kullanıcı Mevcut Değil.");
        }
    }
}

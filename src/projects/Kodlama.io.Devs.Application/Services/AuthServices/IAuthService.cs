using Core.Security.Entities;
using Core.Security.JWT;

namespace Kodlama.io.Devs.Application.Services.AuthServices
{
    public interface IAuthService
    {
        Task<AccessToken> CreateAccessToken(User user);
        Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
        Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
        Task DeleteOldRefreshTokens(int userId);
    }
}

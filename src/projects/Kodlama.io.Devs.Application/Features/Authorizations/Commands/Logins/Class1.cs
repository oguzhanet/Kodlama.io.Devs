using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authorizations.Dtos;
using Kodlama.io.Devs.Application.Features.Authorizations.Rules;
using Kodlama.io.Devs.Application.Services.AuthServices;
using Kodlama.io.Devs.Application.Services.UserServices;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Commands.Logins
{
    public class LoginCommand : IRequest<TokenDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IPAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, TokenDto>
        {
            private readonly IUserService _userService;
            private readonly IAuthService _authService;
            private readonly AuthorizationsBusinessRules _authorizationsBusinessRules;


            public LoginCommandHandler(IUserService userService, IAuthService authService, AuthorizationsBusinessRules authorizationsBusinessRules)
            {
                _userService = userService;
                _authService = authService;
                _authorizationsBusinessRules = authorizationsBusinessRules;
            }

            public async Task<TokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User user = await _userService.GetByMail(request.UserForLoginDto.Email);

                _authorizationsBusinessRules.UserShouldBeExists(user);

                await _authorizationsBusinessRules.UserPasswordShouldBeMatch(user.Id, request.UserForLoginDto.Password);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IPAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                await _authService.DeleteOldRefreshTokens(user.Id);

                TokenDto tokenDto = new();
                tokenDto.AccessToken = createdAccessToken;
                tokenDto.RefreshToken = addedRefreshToken;

                return tokenDto;
            }
        }
    }
}

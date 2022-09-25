using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authorizations.Dtos;
using Kodlama.io.Devs.Application.Features.Authorizations.Rules;
using Kodlama.io.Devs.Application.Services.AuthServices;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Commands.Registers
{
    public class RegisterCommand : IRequest<RegisterDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IPAddress { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly AuthorizationsBusinessRules _authorizationsBusinessRules;
            private readonly IAuthService _authService;

            public RegisterCommandHandler(IUserRepository userRepository, AuthorizationsBusinessRules authorizationsBusinessRules, IAuthService authService)
            {
                _userRepository = userRepository;
                _authorizationsBusinessRules = authorizationsBusinessRules;
                _authService = authService;
            }

            public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authorizationsBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);
                byte[] passWordHash, passWordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passWordHash, out passWordSalt);

                User user = new User
                {
                    Email = request.UserForRegisterDto.Email,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    PasswordHash = passWordHash,
                    PasswordSalt = passWordSalt,
                    Status = true,

                };

                User createdUser = await _userRepository.AddAsync(user);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IPAddress);

                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisterDto registeredDto = new()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken
                };
                return registeredDto;
            }
        }

    }
}

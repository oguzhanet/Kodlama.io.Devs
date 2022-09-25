using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.GitHubProfiles.Rules
{
    public class GitHubProfileRules
    {
        private readonly IGitHubProfileRepository _repository;

        public GitHubProfileRules(IGitHubProfileRepository repository)
        {
            _repository = repository;
        }

        public void UserNotFound(int user)
        {
            if (user == null) throw new BusinessException("User Not Found");
        }
    }
}

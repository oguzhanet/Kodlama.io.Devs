using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.GitHubProfiles.Queries.GetListGitHub
{
    public class GetListGitHubProfileQuery : IRequest<GitHubProfileListModel>
    {
        public PageRequest PageRequest { get; set; }


        public class GetListGitHubQueryHandler : IRequestHandler<GetListGitHubProfileQuery, GitHubProfileListModel>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;

            public GetListGitHubQueryHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository)
            {
                _mapper = mapper;
                _gitHubProfileRepository = gitHubProfileRepository;
            }

            public async Task<GitHubProfileListModel> Handle(GetListGitHubProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GitHubProfile> gitHubProfile =
                    await _gitHubProfileRepository.GetListAsync(include:
                                                                    x => x.Include(z => z.User),
                                                                    index: request.PageRequest.Page,
                                                                    size: request.PageRequest.PageSize);
                GitHubProfileListModel gitHubProfileListModel = _mapper.Map<GitHubProfileListModel>(gitHubProfile);
                return gitHubProfileListModel;
            }
        }
    }
}

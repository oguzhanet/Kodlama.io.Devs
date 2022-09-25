using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Commands.CreateGitHubProfile;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Commands.DeleteGitHubProfile;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Models;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Queries.GetListGitHub;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.GitHubProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GitHubProfile, CreatedGitHubProfileDto>().ReverseMap();
            CreateMap<GitHubProfile, CreateGitHubProfileCommand>().ReverseMap();

            CreateMap<GitHubProfile, DeletedGitHubProfileDto>().ReverseMap();
            CreateMap<GitHubProfile, DeleteGitHubProfileCommand>().ReverseMap();

            CreateMap<GitHubProfile, UpdatedGitHubProfileDto>().ReverseMap();
            CreateMap<GitHubProfile, UpdateGitHubProfileCommand>().ReverseMap();

            CreateMap<IPaginate<GitHubProfile>, GitHubProfileListModel>().ReverseMap();
            CreateMap<GitHubProfile, GetListGitHubProfileDto>()
                .ForMember(x=>x.UserFirstName,opt=>opt.MapFrom(x=>x.User.FirstName))
                .ForMember(x=>x.UserLastName,opt=>opt.MapFrom(x=>x.User.LastName))
                .ReverseMap();

            CreateMap<GitHubProfile, GetListGitHubProfileQuery>().ReverseMap();
        }
    }
}

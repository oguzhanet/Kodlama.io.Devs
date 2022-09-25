using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Dtos;

namespace Kodlama.io.Devs.Application.Features.GitHubProfiles.Models
{
    public class GitHubProfileListModel : BasePageableModel
    {
        public IList<GetListGitHubProfileDto> Items { get; set; }
    }
}

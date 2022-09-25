using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class GitHubProfile : Entity
    {
        public int UserId { get; set; }
        public string GitHubLink { get; set; }

        public virtual User? User { get; set; }

        public GitHubProfile()
        {

        }

        public GitHubProfile(int id, int userId, string gitHubLink) : this()
        {
            Id = id;
            UserId = userId;
            GitHubLink = gitHubLink;
        }
    }
}

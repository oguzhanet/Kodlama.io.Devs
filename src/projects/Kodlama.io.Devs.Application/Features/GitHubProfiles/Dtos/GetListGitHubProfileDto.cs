namespace Kodlama.io.Devs.Application.Features.GitHubProfiles.Dtos
{
    public class GetListGitHubProfileDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GitHubLink { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}

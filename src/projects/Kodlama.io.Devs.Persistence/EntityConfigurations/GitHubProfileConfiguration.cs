using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations
{
    public class GitHubProfileConfiguration : IEntityTypeConfiguration<GitHubProfile>
    {
        public void Configure(EntityTypeBuilder<GitHubProfile> builder)
        {
            builder.ToTable("GitHubProfiles").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.GitHubLink).HasColumnName("GitHubLink");

            builder.HasOne(x => x.User);
        }
    }
}

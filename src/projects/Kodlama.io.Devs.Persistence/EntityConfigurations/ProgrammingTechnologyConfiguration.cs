using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations
{
    public class ProgrammingTechnologyConfiguration : IEntityTypeConfiguration<ProgrammingTechnology>
    {
        public void Configure(EntityTypeBuilder<ProgrammingTechnology> builder)
        {
            builder.ToTable("ProgrammingTechnologies").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.HasOne(p => p.ProgrammingLanguage);
        }
    }
}

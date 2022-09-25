using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }
        public DbSet<GitHubProfile> GitHubProfiles { get; set; }



        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);


            /** Moved to EntityConfigurations folder **/

            //modelBuilder.Entity<ProgrammingLanguage>(a =>
            //{
            //    a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
            //    a.Property(p => p.Id).HasColumnName("Id");
            //    a.Property(p => p.Name).HasColumnName("Name");
            //    a.HasMany(p => p.ProgrammingTechnologies);
            //});
        }
    }
}

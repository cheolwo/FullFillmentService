using IdentityCommon.Models.ForApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace 계정Common.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserRoleDomainConfiguration());
            base.OnModelCreating(builder);
        }
    }
    public class UserRoleDomain
    {
        [Key, ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string DomainsJson { get; set; }
        [NotMapped]
        public List<Domain> Domains
        {
            get => string.IsNullOrEmpty(DomainsJson) ? new List<Domain>() : JsonSerializer.Deserialize<List<Domain>>(DomainsJson);
            set => DomainsJson = JsonSerializer.Serialize(value);
        }
    }
    public class Domain
    {
        public string Role { get; set; }
        public string DomainId { get; set; }
    }
    public class UserRoleDomainConfiguration : IEntityTypeConfiguration<UserRoleDomain>
    {
        public void Configure(EntityTypeBuilder<UserRoleDomain> builder)
        {
               
        }
    }
}

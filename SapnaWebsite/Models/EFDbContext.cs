using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SapnaWebsite.Models;

namespace SapnaWebsite.Models
{
    public class EFDbContext : IdentityDbContext<User, Role, int>
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberSkill> MemberSkills { get; set; }
        public DbSet<MemberSpecialization> MemberSpecialization { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectClient> ProjectClients { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<ProjectSkill> ProjectSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Specialization> Specialization { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Document>()
                .Ignore(x => x.Ducument);

            builder.Entity<Event>()
                .Ignore(x => x.Photo);

            builder.Entity<News>()
                .Ignore(x => x.photo);

            builder.Entity<Member>()
                .Ignore(x => x.ProfilePicture);

            builder.Entity<Client>()
                .Ignore(x => x.Logo);

            builder.Entity<Skill>()
                .Ignore(x => x.Logo);

            builder.Entity<Document>()
                .Property(x => x.DatePosted)
                .HasDefaultValueSql("CONVERT(date, GETDATE())");

            builder.Entity<Event>()
                .Property(x => x.DatePosted)
                .HasDefaultValueSql("CONVERT(date, GETDATE())");

            builder.Entity<News>()
                .Property(x => x.DatePosted)
                .HasDefaultValueSql("CONVERT(date, GETDATE())");

            builder.Entity<Member>()
                .Property(x => x.IsApprove)
                .HasDefaultValue(false);

            builder.Entity<User>()
               .HasOne(p => p.Member)
               .WithOne(i => i.User)
               .HasForeignKey<Member>(b => b.UserId);

            builder.Entity<ProjectMember>()
                .HasKey(x => new { x.ProjectId, x.MemberId });

            builder.Entity<ProjectClient>()
                .HasKey(x => new { x.ClientId, x.ProjectId });

            builder.Entity<MemberSkill>()
                .HasKey(x => new { x.MemberId, x.SkillId });

            builder.Entity<MemberSpecialization>()
                .HasKey(x => new { x.MemberId, x.SpecializationId });

            builder.Entity<ProjectSkill>()
                .HasKey(x => new { x.ProjectId, x.SkillId });
        }

        public DbSet<Role> Role { get; set; }
    }
}

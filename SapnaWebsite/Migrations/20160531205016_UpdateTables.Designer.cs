using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SapnaWebsite.Models;

namespace SapnaWebsite.Migrations
{
    [DbContext(typeof(EFDbContext))]
    [Migration("20160531205016_UpdateTables")]
    partial class UpdateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SapnaWebsite.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("SapnaWebsite.Models.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatePosted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CONVERT(date, GETDATE())");

                    b.Property<string>("Name");

                    b.HasKey("DocumentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("SapnaWebsite.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatePosted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CONVERT(date, GETDATE())");

                    b.Property<string>("Details")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SapnaWebsite.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<bool?>("IsApprove")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Major")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("SapnaStartYear");

                    b.Property<DateTime?>("SchoolGraduationDate");

                    b.Property<int>("UserId");

                    b.HasKey("MemberId");

                    b.HasIndex("UserId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("SapnaWebsite.Models.MemberSkill", b =>
                {
                    b.Property<int>("MemberId");

                    b.Property<int>("SkillId");

                    b.HasKey("MemberId", "SkillId");

                    b.HasIndex("MemberId");

                    b.HasIndex("SkillId");

                    b.ToTable("MemberSkills");
                });

            modelBuilder.Entity("SapnaWebsite.Models.MemberSpecialization", b =>
                {
                    b.Property<int>("MemberId");

                    b.Property<int>("SpecializationId");

                    b.HasKey("MemberId", "SpecializationId");

                    b.HasIndex("MemberId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("MemberSpecialization");
                });

            modelBuilder.Entity("SapnaWebsite.Models.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatePosted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CONVERT(date, GETDATE())");

                    b.Property<string>("Title");

                    b.Property<string>("details");

                    b.HasKey("NewsId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("SapnaWebsite.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCompleted");

                    b.Property<DateTime>("DateStarted");

                    b.Property<string>("Description");

                    b.Property<string>("TechnologiesUsed");

                    b.Property<string>("Title");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SapnaWebsite.Models.ProjectClient", b =>
                {
                    b.Property<int>("ClientId");

                    b.Property<int>("ProjectId");

                    b.HasKey("ClientId", "ProjectId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectClients");
                });

            modelBuilder.Entity("SapnaWebsite.Models.ProjectMember", b =>
                {
                    b.Property<int>("ProjectId");

                    b.Property<int>("MemberId");

                    b.HasKey("ProjectId", "MemberId");

                    b.HasIndex("MemberId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectMembers");
                });

            modelBuilder.Entity("SapnaWebsite.Models.ProjectSkill", b =>
                {
                    b.Property<int>("ProjectId");

                    b.Property<int>("SkillId");

                    b.HasKey("ProjectId", "SkillId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SkillId");

                    b.ToTable("ProjectSkills");
                });

            modelBuilder.Entity("SapnaWebsite.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SapnaWebsite.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Logo");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 80);

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("SapnaWebsite.Models.Specialization", b =>
                {
                    b.Property<int>("SpecializationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("SchoolOrSapna")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("SpecializationId");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("SapnaWebsite.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("SapnaWebsite.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("SapnaWebsite.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("SapnaWebsite.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<int>", b =>
                {
                    b.HasOne("SapnaWebsite.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SapnaWebsite.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SapnaWebsite.Models.Member", b =>
                {
                    b.HasOne("SapnaWebsite.Models.User")
                        .WithOne()
                        .HasForeignKey("SapnaWebsite.Models.Member", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SapnaWebsite.Models.MemberSkill", b =>
                {
                    b.HasOne("SapnaWebsite.Models.Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SapnaWebsite.Models.Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SapnaWebsite.Models.MemberSpecialization", b =>
                {
                    b.HasOne("SapnaWebsite.Models.Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SapnaWebsite.Models.Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SapnaWebsite.Models.ProjectClient", b =>
                {
                    b.HasOne("SapnaWebsite.Models.Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SapnaWebsite.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SapnaWebsite.Models.ProjectMember", b =>
                {
                    b.HasOne("SapnaWebsite.Models.Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SapnaWebsite.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SapnaWebsite.Models.ProjectSkill", b =>
                {
                    b.HasOne("SapnaWebsite.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SapnaWebsite.Models.Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

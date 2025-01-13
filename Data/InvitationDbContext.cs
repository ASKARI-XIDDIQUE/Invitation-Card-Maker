using Invitation_Card_Maker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Invitation_Card_Maker.Data
{
    public class InvitationDbContext:DbContext
    {
        public InvitationDbContext(DbContextOptions<InvitationDbContext> options):base(options)
        {
            
        }
        public DbSet<Template> Template { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<UserTemplate> UserTemplate { get; set; }
        public DbSet<CustomTemplates> CustomTemplates { get; set; }
        public DbSet<TemplateUserImages> TemplateUserImages { get; set; }
        public DbSet<TemplateTextBox> TemplateTextBox { get; set; }
        public DbSet<Stickers> Stickers { get; set; }
        public DbSet<TemplateStickers> TemplateStickers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminRoleId = Guid.NewGuid();
            var userRoleId = Guid.NewGuid();

            modelBuilder.Entity<Role>().HasData(
                new Role { GlobalId = adminRoleId, RoleName = "Admin" },
                new Role { GlobalId = userRoleId, RoleName = "User" }
            );

            // Seed data for Users
            var adminUserId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    GlobalId = adminUserId,
                    UserName = "admin",
                    Email = "admin@example.com",
                    Password = "admin123", 
                    Active = true,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    GlobalId = userId,
                    UserName = "user",
                    Email = "user@example.com",
                    Password = "user123", 
                    Active = true,
                    CreatedAt = DateTime.UtcNow
                }
            );

            
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    GlobalId = Guid.NewGuid(),
                    UserId = adminUserId,
                    RoleId = adminRoleId
                },
                new UserRole
                {
                    GlobalId = Guid.NewGuid(),
                    UserId = userId,
                    RoleId = userRoleId
                }
            );
        }
    }
}

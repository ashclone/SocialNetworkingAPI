using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetworkingAPI.Models;
using System.Reflection.Emit;

namespace SocialNetworkingAPI.data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, IdentityUserClaim<int>, ApplicationUserRole,
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUserLike> ApplicationUserLikes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasMany(e => e.ApplicationUserRole)
                    .WithOne(e => e.ApplicationUser)
                    .HasForeignKey(e => e.ApplicationUserId)
                    .IsRequired();

                entity.HasMany(e => e.SenderLikes)
                    .WithOne(e => e.Sender)
                    .HasForeignKey(e => e.SenderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.ReceiverLikes)
                    .WithOne(e => e.Receiver)
                    .HasForeignKey(e => e.ReceiverId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.SenderMessages)
                    .WithOne(e => e.Sender)
                    .HasForeignKey(e => e.SenderId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.ReceiverMessages)
                    .WithOne(e => e.Receiver)
                    .HasForeignKey(e => e.ReceiverId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ApplicationUserRole>(entity =>
            {
                entity.HasOne(e => e.ApplicationUser)
                    .WithMany(e => e.ApplicationUserRole)
                    .HasForeignKey(e => e.ApplicationUserId)
                    .IsRequired();

                entity.HasOne(e => e.ApplicationRole)
                    .WithMany(e => e.ApplicationUserRoles)
                    .HasForeignKey(e => e.ApplicationRoleId)
                    .IsRequired().OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ApplicationUserLike>(entity =>
            {
                entity.HasKey(e => new { e.SenderId, e.ReceiverId });

                entity.HasOne(e => e.Sender)
                    .WithMany(e => e.SenderLikes)
                    .HasForeignKey(e => e.SenderId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Receiver)
                    .WithMany(e => e.ReceiverLikes)
                    .HasForeignKey(e => e.ReceiverId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Message>(entity =>
            {
                entity.HasKey(e => new { e.SenderId, e.ReceiverId });

                entity.HasOne(e => e.Sender)
                    .WithMany(e => e.SenderMessages)
                    .HasForeignKey(e => e.SenderId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Receiver)
                    .WithMany(e => e.ReceiverMessages)
                    .HasForeignKey(e => e.ReceiverId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Photo>(entity =>
            {
                entity.HasOne(e => e.ApplicationUser)
                    .WithMany(e => e.Photots)
                    .HasForeignKey(e => e.ApplicationUserId)
                    .IsRequired();
            });
        }
    }
}

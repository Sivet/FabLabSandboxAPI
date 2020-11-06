using FabLabSandboxAPI.Authorization.AuthenticationDB;
using FabLabSandboxAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FabLabSandboxAPI.Data
{
    public class MakerSpaceContext : IdentityDbContext<AppUser>
    {
        public MakerSpaceContext(DbContextOptions<MakerSpaceContext> opt) : base(opt)
        {
            
        }
        public DbSet<MakerSpace> MakerSpaces {get; set;}
        public DbSet<Machine> Machines {get; set;}
        public DbSet<Event> Events {get; set;}
        public DbSet<Badge> Badges {get; set;}
        public DbSet<AppUser> User {get; set;}
        public DbSet<EventGivesBadges> eventGivesBadges {get; set;}
        public DbSet<MakerSpaceHasUser> makerSpaceHasUser {get; set;}
        public DbSet<UserAttendingEvent> userAttendingEvent {get; set;}
        public DbSet<UserEarnedBadges> userEarnedBadges {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MakerSpace>()
            .Property(x => x.IsAccepted)
            .HasDefaultValueSql("0");

            modelBuilder.Entity<EventGivesBadges>().HasKey(sc => new { sc.EventId, sc.BadgeId });
            modelBuilder.Entity<MakerSpaceHasUser>().HasKey(sc => new { sc.MakerSpaceId, sc.UserId });
            modelBuilder.Entity<UserAttendingEvent>().HasKey(sc => new { sc.UserId, sc.EventId });
            modelBuilder.Entity<UserEarnedBadges>().HasKey(sc => new { sc.UserId, sc.BadgeId });
        }
    }
}
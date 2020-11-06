using FabLabSandboxAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FabLabSandboxAPI.Data
{
    public class MakerSpaceContext : DbContext{
        public MakerSpaceContext(DbContextOptions<MakerSpaceContext> opt) : base(opt)
        {
            
        }
        public DbSet<MakerSpace> MakerSpaces {get; set;}
        public DbSet<Machine> Machines {get; set;}
        public DbSet<Event> Events {get; set;}
        public DbSet<Badge> Badges {get; set;}
        public DbSet<EventGivesBadges> eventGivesBadges {get; set;}
        //public DbSet<Address> Addresses {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<MakerSpace>()
            .Property(x => x.IsAccepted)
            .HasDefaultValueSql("0");

            modelBuilder.Entity<EventGivesBadges>().HasKey(sc => new { sc.EventId, sc.BadgeId });
        }
    }
}
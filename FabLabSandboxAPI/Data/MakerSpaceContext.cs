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


        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<MakerSpace>()
            .Property(x => x.IsAccepted)
            .HasDefaultValue(false);
        }
    }
}
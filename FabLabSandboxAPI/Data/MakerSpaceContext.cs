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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<MakerSpace>()
            .Property(x => x.IsAccepted)
            .HasDefaultValueSql("0");
        }*/
    }
}
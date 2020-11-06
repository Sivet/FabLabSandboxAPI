using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FabLabSandboxAPI.Authorization.AuthenticationDB
{
    public class AuthorizationDBContext : IdentityDbContext<AppUser>
    {
        public AuthorizationDBContext(DbContextOptions<AuthorizationDBContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

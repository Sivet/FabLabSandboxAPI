using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FabLabSandboxAPI.Models;
using System.ComponentModel.DataAnnotations;


namespace FabLabSandboxAPI.Authorization.AuthenticationDB
{
    public class AppUser : IdentityUser
    {
        public ICollection<MakerSpaceHasUser> MakerSpaces { get; set; }
        public ICollection<UserEarnedBadges> BadgesEarned { get; set; }

        public ICollection<UserAttendingEvent> Events { get; set; }
    }
}

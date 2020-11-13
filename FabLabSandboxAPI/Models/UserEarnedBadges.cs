using System.ComponentModel.DataAnnotations;
using FabLabSandboxAPI.Authorization.AuthenticationDB;
using System;
using Microsoft.AspNetCore.Identity;

namespace FabLabSandboxAPI.Models
{
    public class UserEarnedBadges
    {
        public string memberId { get; set; }
        public IdentityUser member { get; set; }

        public Guid BadgeId { get; set; }
        public Badge badge { get; set; }


    }
}
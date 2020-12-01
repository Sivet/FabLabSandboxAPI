using System.ComponentModel.DataAnnotations;
using FabLabSandboxAPI.Authorization.AuthenticationDB;
using System;
using Microsoft.AspNetCore.Identity;

namespace FabLabSandboxAPI.Models
{
    public class MakerSpaceHasUser
    {
        public string memberId { get; set; }
        public IdentityUser member { get; set; }

        public Guid MakerSpaceId { get; set; }
        public MakerSpace makerSpace { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using FabLabSandboxAPI.Authorization.AuthenticationDB;
using System;

namespace FabLabSandboxAPI.Models
{
    public class MakerSpaceHasUser
    {
        public Guid UserId { get; set; }
        public AppUser user { get; set; }

        public int MakerSpaceId { get; set; }
        public MakerSpace makerSpace { get; set; }


    }
}
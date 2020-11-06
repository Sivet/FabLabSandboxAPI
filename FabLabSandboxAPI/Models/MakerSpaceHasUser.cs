using System.ComponentModel.DataAnnotations;
using FabLabSandboxAPI.Authorization.AuthenticationDB;

namespace FabLabSandboxAPI.Models
{
    public class MakerSpaceHasUser
    {
        public int UserId { get; set; }
        public AppUser user { get; set; }

        public int MakerSpaceId { get; set; }
        public MakerSpace makerSpace { get; set; }


    }
}
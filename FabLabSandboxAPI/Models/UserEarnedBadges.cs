using System.ComponentModel.DataAnnotations;
using FabLabSandboxAPI.Authorization.AuthenticationDB;

namespace FabLabSandboxAPI.Models
{
    public class UserEarnedBadges
    {
        public int UserId { get; set; }
        public AppUser user { get; set; }

        public int BadgeId { get; set; }
        public Badge badge { get; set; }


    }
}
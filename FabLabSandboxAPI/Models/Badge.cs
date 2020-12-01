using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace FabLabSandboxAPI.Models
{
    public class Badge
    {
        [Key]
        public Guid BadgeId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [Required]
        public Guid BadgeLevelId { get; set; }

        [Required]
        public Level level { get; set; }

        public ICollection<EventGivesBadges> BadgesForEvents { get; set; }

        public ICollection<UserEarnedBadges> UsersEarned { get; set; }
    }
}
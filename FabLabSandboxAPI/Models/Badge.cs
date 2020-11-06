using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Models
{
    public class Badge
    {
        [Key]
        public int BadgeId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [Required]
        public int LevelID { get; set; }

        [Required]
        public Level level { get; set; }

        public ICollection<EventGivesBadges> Events { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Models
{
    public class EventGivesBadges
    {
        public int EventId { get; set; }
        public Event evt { get; set; }

        public int BadgeId { get; set; }
        public Badge badge { get; set; }


    }
}
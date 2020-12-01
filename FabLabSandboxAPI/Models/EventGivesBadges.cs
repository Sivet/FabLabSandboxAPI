using System.ComponentModel.DataAnnotations;
using System;

namespace FabLabSandboxAPI.Models
{
    public class EventGivesBadges
    {
        public Guid EventId { get; set; }
        public Event evt { get; set; }

        public Guid BadgeId { get; set; }
        public Badge badge { get; set; }


    }
}
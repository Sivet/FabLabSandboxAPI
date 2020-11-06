using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int MakerSpaceId { get; set; }
        
        [Required]
        public MakerSpace MakerSpace { get; set; }

        public ICollection<EventGivesBadges> BadgesGiven { get; set; }

        public ICollection<UserAttendingEvent> UsersAttending { get; set; }

    }
}
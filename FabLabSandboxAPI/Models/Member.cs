using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Models
{
    public class Member
    {
        [Key]
        public Guid MemberId { get; set; }

        [Required]
        [MaxLength(250)]
        public string MemberName { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string ZipCode { get; set; }
        
        public ICollection<MakerSpaceHasUser> MakerSpaces { get; set; }
        public ICollection<UserEarnedBadges> BadgesEarned { get; set; }
        public ICollection<UserAttendingEvent> Events { get; set; }

    }
}


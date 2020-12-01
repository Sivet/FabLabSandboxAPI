using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace FabLabSandboxAPI.Models
{
    public class MakerSpace
    {
        [Key]
        public Guid MakerSpaceId { get; set; }
        [Required]
        [MaxLength(250)]
        public string MakerSpaceName { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string ZipCode { get; set; }

        public bool? IsAccepted { get; set; } = false;

        public ICollection<Machine> Machines { get; set; }

        public ICollection<Event> EventsAtMakerSpace { get; set; }

        public ICollection<MakerSpaceHasUser> UsersAtMakerSpace {get; set;}

    }
}
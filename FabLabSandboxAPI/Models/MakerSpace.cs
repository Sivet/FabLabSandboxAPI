using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FabLabSandboxAPI.Models
{
    public class MakerSpace
    {
        [Key]
        public int MakerSpaceId { get; set; }
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

        /*[Required]
        public int MakerAddressId { get; set; }
        [Required]
        public Address MakerSpaceAdress { get; set; }*/

        public ICollection<Machine> Machines { get; set; }

        public ICollection<Event> EventsAtMakerSpace { get; set; }

        public ICollection<MakerSpaceHasUser> UsersAtMakerSpace {get; set;}

    }
}
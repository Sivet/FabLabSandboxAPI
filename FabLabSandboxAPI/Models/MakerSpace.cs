using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [MaxLength(4)]
        public string MakerSpacePostCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string MakerSpaceStreet { get; set; }

        [Required]
        [MaxLength(250)]
        public string MakerSpaceCity { get; set; }

        public ICollection<Machine> Machines { get; set; }

        public bool IsAccepted{ get; set; }

    }
}
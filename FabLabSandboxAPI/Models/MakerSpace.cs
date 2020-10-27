using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FabLabSandboxAPI.Models
{
    public class MakerSpace
    {

        [Key]
        public int Id { get; set; }
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

       /* [NotMapped]*/
        public ICollection <Machine> Machines { get; set; }

      /*   public void AddMachine(Machine machines)
        {
          Machine.Add(machines);
        }*/

        public bool? IsAccepted{ get; set; } = false;

    }
}
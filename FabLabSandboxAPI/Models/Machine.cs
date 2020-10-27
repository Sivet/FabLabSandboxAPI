using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Models
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }

        [Required]
        [MaxLength(150)]
        public string MachineName { get; set; }

        [Required]
         public string MachineSerialNumber { get; set; }

        [Required]
        public string MachineDescription { get; set; }

        [Required]

        //mayby it not neaded - just take usual prop -collumn - from DB???
        public int MakerSpaceId { get; set; }
        public MakerSpace MakerSpace { get; set; }
    }
}
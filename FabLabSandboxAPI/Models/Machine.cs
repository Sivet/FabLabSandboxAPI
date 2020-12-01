using System.ComponentModel.DataAnnotations;
using System;

namespace FabLabSandboxAPI.Models
{
    public class Machine
    {
        [Key]
        public Guid MachineId { get; set; }

        [Required]
        [MaxLength(150)]
        public string MachineName { get; set; }

        [Required]
         public string MachineSerialNumber { get; set; }

        [Required]
        public string MachineDescription { get; set; }

        [Required]
        public Guid MakerSpaceId { get; set; }
        [Required]
        public MakerSpace MakerSpace { get; set; }
    }
}
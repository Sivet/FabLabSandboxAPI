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
       
       /* [Required]
        public string MachineSerialNumber { get; set; }*/

        [Required]
        public string MachineDescription { get; set; }

        [Required]
        public MakerSpace MakerSpace { get; set; }

    }
}
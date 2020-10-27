using System.ComponentModel.DataAnnotations;
using FabLabSandboxAPI.Models;
using Newtonsoft.Json;

namespace FabLabSandboxAPI.Dtos.MachineDto
{
    public class MachineReadDto
    {

        /// <summary> Id for found some MakerSpase - DB do it self</summary>
        public int MachineId { get; set; }

        [Required]
        [MaxLength(150)]
        public string MachineName { get; set; }

        /*[Required]
        public string MachineSerialNumber { get; set; }*/

        [Required]
        public string MachineDescription { get; set; }

        [Required]
        public MakerSpaceIdReadDto MakerSpace { get; set; }

    }
}
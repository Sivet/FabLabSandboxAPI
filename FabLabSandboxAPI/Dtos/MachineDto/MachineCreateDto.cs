using System;
using System.ComponentModel.DataAnnotations;
using FabLabSandboxAPI.Models;

namespace FabLabSandboxAPI.Dtos.MachineDto
{
    public class MachineCreateDto
    {

        [Required]
        [MaxLength(150)]
        public string MachineName { get; set; }

        [Required]
         public string MachineSerialNumber { get; set; }

        [Required]
        public string MachineDescription { get; set; }

        [Required]
        public Guid MakerSpaceId { get; set; }

    }
}
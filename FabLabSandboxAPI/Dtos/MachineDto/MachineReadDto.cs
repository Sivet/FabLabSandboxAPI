using System.ComponentModel.DataAnnotations;
using FabLabSandboxAPI.Models;
using Newtonsoft.Json;
using System;

namespace FabLabSandboxAPI.Dtos.MachineDto
{
    public class MachineReadDto
    {

        /// <summary> Id for found some MakerSpase - DB do it self</summary>
        public Guid MachineId { get; set; }

        public string MachineName { get; set; }

        public string MachineSerialNumber { get; set; }

        public string MachineDescription { get; set; }

        public MakerSpaceIdReadDto MakerSpace { get; set; }

    }
}
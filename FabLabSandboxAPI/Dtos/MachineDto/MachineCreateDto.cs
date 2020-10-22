using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Dtos.MachineDto
{
    public class MachineCreateDto
    {

        /// <summary> Name for create MakerSpase - Required field</summary>
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        /// <summary> PostCode for create MakerSpase - Required field</summary>
        [Required]
        [MaxLength(4)]
        public string PostCode { get; set; }

        /// <summary> Street for create MakerSpase - Required field</summary>
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        /// <summary>City for create MakerSpase - Required field</summary>
        [Required]
        [MaxLength(250)]
        public string City { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Dtos
{
    public class MakerSpaceCreateDto
    {

        /// <summary> Name for create MakerSpase - Required field</summary>
        [Required]
        [MaxLength(250)]
        public string MakerSpaceName { get; set; }

        /// <summary> PostCode for create MakerSpase - Required field</summary>
        [Required]
        [MaxLength(4)]
        public string ZipCode { get; set; }

        /// <summary> Street for create MakerSpase - Required field</summary>
        [Required]
        [MaxLength(100)]
        public string StreetName { get; set; }

        /// <summary> Street for create MakerSpase - Required field</summary>
        [Required]
        [MaxLength(100)]
        public string StreetNumber { get; set; }

        /// <summary>City for create MakerSpase - Required field</summary>
        [Required]
        [MaxLength(250)]
        public string City { get; set; }

    }
}
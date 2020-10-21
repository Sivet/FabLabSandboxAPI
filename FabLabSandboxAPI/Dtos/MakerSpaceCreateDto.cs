using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Dtos
{
    public class MakerSpaceCreateDto
    {
        
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(4)]
        public string PostCode { get; set;}

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(250)]
        public string City { get; set; }
    }
}
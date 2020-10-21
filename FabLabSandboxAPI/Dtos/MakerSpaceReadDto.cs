using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Dtos
{
    public class MakerSpaceReadDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PostCode { get; set;}

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Dtos
{
    public class MakerSpaceCreateDto
    {
        [Required]
        public string name { get; set; }
    }
}
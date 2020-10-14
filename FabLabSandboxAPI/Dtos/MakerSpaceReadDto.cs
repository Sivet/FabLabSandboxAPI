using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Dtos
{
    public class MakerSpaceReadDto
    {
        public int Id { get; set; }
       
        [Required]
        public string name { get; set; }
    }
}
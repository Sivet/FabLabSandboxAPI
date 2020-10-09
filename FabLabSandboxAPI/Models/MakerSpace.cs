using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Models
{
    public class MakerSpace
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string name { get; set; }
    }
}
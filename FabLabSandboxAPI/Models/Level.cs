using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Models
{
    public class Level
    {
        [Key]
        public int LevelId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public int Value { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;
using System;

namespace FabLabSandboxAPI.Models
{
    public class Level
    {
        [Key]
        public Guid LevelId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public int Value { get; set; }

    }
}
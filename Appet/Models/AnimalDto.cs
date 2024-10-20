using System.ComponentModel.DataAnnotations;

namespace Appet.Models
{
    public class AnimalDto
    {

        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        [Required, MaxLength(100)]
        public string Species { get; set; } = "";

        [Required, MaxLength(100)]
        public string Owner { get; set; } = "";
    }
}

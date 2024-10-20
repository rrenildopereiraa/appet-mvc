using System.ComponentModel.DataAnnotations;

namespace Appet.Models
{
    public class ObservatoryDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        [Required, MaxLength(100)]
        public string Location { get; set; } = "";

        [Required, Range(0, 50, ErrorMessage = "The field telescopes count must be between {1} and {2}.")]
        public int TelescopesCount { get; set; }

    }
}

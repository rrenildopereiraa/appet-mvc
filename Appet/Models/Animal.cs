using System.ComponentModel.DataAnnotations;

namespace Appet.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = "";

        [MaxLength(100)]
        public string Species { get; set; } = "";

        [MaxLength(100)]
        public string Owner { get; set; } = "";
    }
}

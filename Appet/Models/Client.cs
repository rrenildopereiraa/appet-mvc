 using System.ComponentModel.DataAnnotations;

namespace Appet.Models
{
    public class Client
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = "";

        [MaxLength(100)]
        public string Address { get; set; } = "";

        [MaxLength(9)]
        public string Phone { get; set; } = "";
    }
}

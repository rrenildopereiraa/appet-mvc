using System.ComponentModel.DataAnnotations;

namespace Appet.Models
{
    public class AppointmentDto
    {
        [Required(ErrorMessage = "The client name field is required."), MaxLength(100)]
        public string ClientName { get; set; } = "";

        [Required(ErrorMessage = "The vet name field is required."), MaxLength(100)]
        public string VetName { get; set; } = "";

        public DateTime AppointmentDateTime { get; set; }

        [MaxLength(1000, ErrorMessage = "The field notes must be a maximum of {1} characters.")]
        public string Notes { get; set; } = "";
    }
}

using System.ComponentModel.DataAnnotations;

namespace Appet.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string ClientName { get; set; } = "";

        [MaxLength(100)]
        public string VetName { get; set; } = "";

        public DateTime AppointmentDateTime { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; } = "";
    }
}

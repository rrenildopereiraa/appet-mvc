using Microsoft.AspNetCore.Identity;

namespace Appet.Models
{
    public class AppetUser : IdentityUser
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}

using Appet.Models;
using Microsoft.EntityFrameworkCore;

namespace Appet.Services
{
    public class AppetContext : DbContext
    {

        public AppetContext(DbContextOptions options) : base(options) { }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Observatory> Observatories { get; set; }
        public DbSet<Vet> Vets { get; set; }
    }
}

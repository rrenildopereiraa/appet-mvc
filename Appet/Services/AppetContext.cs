using Appet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Appet.Services
{
    public class AppetContext : IdentityDbContext<AppetUser>
    {
        public AppetContext(DbContextOptions options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Observatory> Observatories { get; set; }
        public DbSet<Vet> Vets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var admin = new IdentityRole("Admin");
            admin.NormalizedName = "Admin";

            var client = new IdentityRole("Client");
            client.NormalizedName = "Client";

            modelBuilder.Entity<IdentityRole>().HasData(admin, client);
        }
    }
}
